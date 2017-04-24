using com.tencent.pandora.MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace com.tencent.pandora
{
	internal abstract class AbstractTcpClient : MonoBehaviour
	{
		public enum SocketState
		{
			Disconnect,
			Connecting,
			Success,
			Failed
		}

		protected const int HEADER_SIZE = 4;

		protected const int SEND_BUFFER_SIZE = 262144;

		protected const int MAX_SHARED_BUFFER_LENGTH = 4194304;

		protected static Dictionary<string, object> EMPTY_PACKET = new Dictionary<string, object>();

		private object _lockObj = new object();

		protected Socket _socket;

		protected string _host;

		protected string _address;

		protected int _port;

		private byte[] _sharedBuffer = new byte[1024];

		private byte[] _bodyBuffer;

		private int _bodyLength;

		private int _readBodyLength;

		private byte[] _headerBuffer;

		private Queue<Dictionary<string, object>> _sendQueue;

		private Coroutine _waitCoroutine;

		private Coroutine _sendCoroutine;

		private Coroutine _receiveCoroutine;

		private volatile AbstractTcpClient.SocketState _state;

		private Action _callback;

		private bool _canConnectAlternateIp;

		public bool PauseSending
		{
			get;
			set;
		}

		public string AlternateIp1
		{
			get;
			set;
		}

		public string AlternateIp2
		{
			get;
			set;
		}

		private bool CanConnectAlternateIp
		{
			get
			{
				bool result = this._canConnectAlternateIp && (!string.IsNullOrEmpty(this.AlternateIp1) || !string.IsNullOrEmpty(this.AlternateIp2));
				this._canConnectAlternateIp = false;
				return result;
			}
		}

		protected AbstractTcpClient.SocketState State
		{
			get
			{
				object lockObj = this._lockObj;
				AbstractTcpClient.SocketState state;
				lock (lockObj)
				{
					state = this._state;
				}
				return state;
			}
			set
			{
				object lockObj = this._lockObj;
				lock (lockObj)
				{
					this._state = value;
				}
			}
		}

		public void Reconnect()
		{
			this.Connect(this._host, this._port, null);
		}

		public void Connect(string host, int port, Action callback)
		{
			if (this.State == AbstractTcpClient.SocketState.Connecting)
			{
				return;
			}
			this.Close();
			this._host = host;
			this._port = port;
			this._callback = callback;
			this._sendQueue = new Queue<Dictionary<string, object>>();
			this.State = AbstractTcpClient.SocketState.Connecting;
			this._canConnectAlternateIp = true;
			Logger.LogInfo(string.Concat(new object[]
			{
				"开始连接Socket : ",
				this._host,
				":",
				this._port
			}));
			this.SafeStartCoroutine(ref this._waitCoroutine, this.WaitSocketConnect());
			Dns.BeginGetHostAddresses(host, new AsyncCallback(this.OnGetHostAddress), host);
		}

		private void OnGetHostAddress(IAsyncResult result)
		{
			try
			{
				IPAddress[] array = Dns.EndGetHostAddresses(result);
				if (array != null && array.Length != 0)
				{
					int num = new System.Random().Next(array.Length);
					IPAddress address = array[num];
					this.BeginConnectHost(address, this._port);
				}
				else
				{
					this.InnerHandleSocketConnectFailed();
				}
			}
			catch
			{
				this.InnerHandleSocketConnectFailed();
			}
		}

		private void BeginConnectHost(IPAddress address, int port)
		{
			try
			{
				this._address = address.ToString();
				this._socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				this._socket.SendBufferSize = 262144;
				this._socket.BeginConnect(address, port, new AsyncCallback(this.OnConnectHost), this._socket);
			}
			catch
			{
			}
		}

		private void OnConnectHost(IAsyncResult result)
		{
			try
			{
				Socket socket = result.AsyncState as Socket;
				if (socket.Connected)
				{
					this._headerBuffer = new byte[4];
					this._bodyLength = 0;
					this._readBodyLength = 0;
					this.State = AbstractTcpClient.SocketState.Success;
				}
				else
				{
					this.InnerHandleSocketConnectFailed();
				}
			}
			catch
			{
				this.InnerHandleSocketConnectFailed();
			}
		}

		private void InnerHandleSocketConnectFailed()
		{
			if (this.CanConnectAlternateIp)
			{
				try
				{
					this.ConnectAlternateIp();
				}
				catch
				{
					this.State = AbstractTcpClient.SocketState.Failed;
				}
			}
			else
			{
				this.State = AbstractTcpClient.SocketState.Failed;
			}
		}

		private void ConnectAlternateIp()
		{
			IPAddress targetIpAddress = this.GetTargetIpAddress();
			this.BeginConnectHost(targetIpAddress, this._port);
		}

		private IPAddress GetTargetIpAddress()
		{
			AddressFamily localIpAddressFamily = this.GetLocalIpAddressFamily();
			if (localIpAddressFamily == AddressFamily.InterNetwork)
			{
				return IPAddress.Parse(this.SelectAlternateIp());
			}
			return IPAddress.Parse("64:ff9b::" + this.SelectAlternateIp());
		}

		private string SelectAlternateIp()
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(this.AlternateIp1))
			{
				list.Add(this.AlternateIp1);
			}
			if (!string.IsNullOrEmpty(this.AlternateIp2))
			{
				list.Add(this.AlternateIp2);
			}
			int index = new System.Random().Next(0, list.Count);
			return list[index];
		}

		private AddressFamily GetLocalIpAddressFamily()
		{
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			if (hostEntry.AddressList.Length == 0)
			{
				return AddressFamily.InterNetwork;
			}
			IPAddress[] addressList = hostEntry.AddressList;
			for (int i = 0; i < addressList.Length; i++)
			{
				IPAddress iPAddress = addressList[i];
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return AddressFamily.InterNetwork;
				}
			}
			return AddressFamily.InterNetworkV6;
		}

		[DebuggerHidden]
		private IEnumerator WaitSocketConnect()
		{
			AbstractTcpClient.<WaitSocketConnect>c__IteratorD <WaitSocketConnect>c__IteratorD = new AbstractTcpClient.<WaitSocketConnect>c__IteratorD();
			<WaitSocketConnect>c__IteratorD.<>f__this = this;
			return <WaitSocketConnect>c__IteratorD;
		}

		[DebuggerHidden]
		protected IEnumerator DaemonReceive()
		{
			AbstractTcpClient.<DaemonReceive>c__IteratorE <DaemonReceive>c__IteratorE = new AbstractTcpClient.<DaemonReceive>c__IteratorE();
			<DaemonReceive>c__IteratorE.<>f__this = this;
			return <DaemonReceive>c__IteratorE;
		}

		private byte[] GetBodyBuffer(int bodyLen)
		{
			if (this._sharedBuffer.Length < bodyLen)
			{
				int i = this._sharedBuffer.Length;
				while (i < bodyLen)
				{
					i *= 2;
					if (i > 4194304)
					{
						i = 4194304;
						break;
					}
				}
				this._sharedBuffer = new byte[i];
				return this._sharedBuffer;
			}
			return this._sharedBuffer;
		}

		[DebuggerHidden]
		protected IEnumerator DaemonSend()
		{
			AbstractTcpClient.<DaemonSend>c__IteratorF <DaemonSend>c__IteratorF = new AbstractTcpClient.<DaemonSend>c__IteratorF();
			<DaemonSend>c__IteratorF.<>f__this = this;
			return <DaemonSend>c__IteratorF;
		}

		protected virtual byte[] SerializePacket(Dictionary<string, object> packet)
		{
			packet["send_timestamp"] = TimeHelper.NowMilliseconds().ToString();
			string content = Json.Serialize(packet);
			byte[] array = Zlib.Compress(content);
			byte[] bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(array.Length));
			byte[] array2 = new byte[bytes.Length + array.Length];
			Array.Copy(bytes, 0, array2, 0, bytes.Length);
			Array.Copy(array, 0, array2, bytes.Length, array.Length);
			return array2;
		}

		protected abstract void OnConnected();

		protected virtual void OnConnectFailed()
		{
			this._sendQueue.Clear();
			Logger.Log("<color=#ff0000>Broker Socket</color> 连接失败: " + this._host + " : " + this._port.ToString());
		}

		protected abstract void OnReceived(byte[] content, int length);

		public void Send(Dictionary<string, object> packet)
		{
			if (this.State == AbstractTcpClient.SocketState.Disconnect || this.State == AbstractTcpClient.SocketState.Failed)
			{
				this.Reconnect();
			}
			this._sendQueue.Enqueue(packet);
		}

		public virtual void Close()
		{
			this.State = AbstractTcpClient.SocketState.Disconnect;
			if (this._socket != null)
			{
				this._socket.Close();
				this._socket = null;
			}
			this.SafeStopCoroutine(ref this._waitCoroutine);
			this.SafeStopCoroutine(ref this._receiveCoroutine);
			this.SafeStopCoroutine(ref this._sendCoroutine);
		}

		protected void SafeStartCoroutine(ref Coroutine coroutineRef, IEnumerator enumerator)
		{
			if (coroutineRef != null)
			{
				base.StopCoroutine(coroutineRef);
			}
			coroutineRef = base.StartCoroutine(enumerator);
		}

		protected void SafeStopCoroutine(ref Coroutine coroutineRef)
		{
			if (coroutineRef != null)
			{
				base.StopCoroutine(coroutineRef);
				coroutineRef = null;
			}
		}

		protected string GetNetworkType()
		{
			NetworkReachability internetReachability = Application.internetReachability;
			if (internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
			{
				return "Mobile";
			}
			if (internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork)
			{
				return "None";
			}
			return "Lan";
		}

		public override string ToString()
		{
			return string.Format("{0} {1}:{2}", "Socket", this._host, this._port.ToString());
		}
	}
}
