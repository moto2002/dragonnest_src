using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using XUpdater;

namespace XUtliPoolLib
{
	public class XFetchVersionNetwork
	{
		public enum SocketState
		{
			State_Closed,
			State_Connecting,
			State_Connected
		}

		private Socket m_oSocket;

		private XFetchVersionNetwork.SocketState m_nState;

		private static byte[] m_oRecvBuff;

		private int m_nCurrRecvLen;

		public static int TotalRecvBytes;

		private AsyncCallback m_RecvCb;

		private AsyncCallback m_ConnectCb;

		public bool m_bRecvMsg = true;

		public bool m_bPause;

		public int m_nPauseRecvLen;

		private AddressFamily m_NetworkType = AddressFamily.InterNetwork;

		public XFetchVersionNetwork()
		{
			this.m_oSocket = null;
			this.m_nState = XFetchVersionNetwork.SocketState.State_Closed;
			XFetchVersionNetwork.m_oRecvBuff = null;
			this.m_nCurrRecvLen = 0;
			this.m_RecvCb = new AsyncCallback(this.RecvCallback);
			this.m_ConnectCb = new AsyncCallback(this.OnConnect);
		}

		private void GetNetworkType()
		{
			try
			{
				string[] array = XSingleton<XUpdater>.singleton.XPlatform.GetLoginServer("QQ").Split(new char[]
				{
					':'
				});
				IPAddress[] hostAddresses = Dns.GetHostAddresses(array[0]);
				this.m_NetworkType = hostAddresses[0].AddressFamily;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
			}
		}

		public bool Init()
		{
			this.GetNetworkType();
			try
			{
				this.m_nState = XFetchVersionNetwork.SocketState.State_Closed;
				this.m_oSocket = new Socket(this.m_NetworkType, SocketType.Stream, ProtocolType.Tcp);
				this.m_oSocket.NoDelay = true;
				if (XFetchVersionNetwork.m_oRecvBuff == null)
				{
					XFetchVersionNetwork.m_oRecvBuff = new byte[512];
				}
				this.m_nCurrRecvLen = 0;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, "new Socket Error!", null, null, null, null);
				return false;
			}
			return true;
		}

		public void UnInit()
		{
			this.Close();
		}

		private void OnConnect(IAsyncResult iar)
		{
			try
			{
				if (this.m_nState != XFetchVersionNetwork.SocketState.State_Closed)
				{
					Socket socket = (Socket)iar.AsyncState;
					socket.EndConnect(iar);
					this.SetState(XFetchVersionNetwork.SocketState.State_Connected);
					socket.BeginReceive(XFetchVersionNetwork.m_oRecvBuff, this.m_nCurrRecvLen, XFetchVersionNetwork.m_oRecvBuff.Length - this.m_nCurrRecvLen, SocketFlags.None, this.m_RecvCb, socket);
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				this.SetState(XFetchVersionNetwork.SocketState.State_Closed);
				this.Close();
			}
		}

		public bool Connect(string host, int port)
		{
			bool result;
			try
			{
				this.SetState(XFetchVersionNetwork.SocketState.State_Connecting);
				this.m_oSocket.BeginConnect(host, port, this.m_ConnectCb, this.m_oSocket);
				result = true;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				result = false;
			}
			return result;
		}

		public void Close()
		{
			this.m_nState = XFetchVersionNetwork.SocketState.State_Closed;
			if (this.m_oSocket == null)
			{
				return;
			}
			try
			{
				this.m_oSocket.Close();
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
			}
			this.m_oSocket = null;
		}

		public Socket GetSocket()
		{
			return this.m_oSocket;
		}

		public bool IsClosed()
		{
			return this.m_nState == XFetchVersionNetwork.SocketState.State_Closed;
		}

		private void SetState(XFetchVersionNetwork.SocketState nState)
		{
			this.m_nState = nState;
		}

		public void RecvCallback(IAsyncResult ar)
		{
			try
			{
				if (this.m_nState != XFetchVersionNetwork.SocketState.State_Closed)
				{
					Socket socket = (Socket)ar.AsyncState;
					int num = socket.EndReceive(ar);
					if (num > 0)
					{
						XFetchVersionNetwork.TotalRecvBytes += num;
						this.m_nCurrRecvLen += num;
						if (!this.DetectPacket())
						{
							if (this.m_nCurrRecvLen == XFetchVersionNetwork.m_oRecvBuff.Length)
							{
								XSingleton<XDebug>.singleton.AddWarningLog("RecvCallback error ! m_nCurrRecvLen == m_oRecvBuff.Length", null, null, null, null, null);
							}
							socket.BeginReceive(XFetchVersionNetwork.m_oRecvBuff, this.m_nCurrRecvLen, XFetchVersionNetwork.m_oRecvBuff.Length - this.m_nCurrRecvLen, SocketFlags.None, this.m_RecvCb, socket);
						}
					}
					else if (num == 0)
					{
						XSingleton<XDebug>.singleton.AddWarningLog("Close socket normally", null, null, null, null, null);
						this.Close();
					}
					else
					{
						XSingleton<XDebug>.singleton.AddWarningLog("Close socket, recv error!", null, null, null, null, null);
						this.Close();
					}
				}
			}
			catch (ObjectDisposedException)
			{
			}
			catch (SocketException ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				this.Close();
			}
			catch (Exception ex2)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex2.Message, null, null, null, null, null);
				this.Close();
			}
		}

		public bool DetectPacket()
		{
			if (this.m_nCurrRecvLen > 0)
			{
				int num = this.BreakPacket(XFetchVersionNetwork.m_oRecvBuff, 0, this.m_nCurrRecvLen);
				if (num != 0 && this.m_bRecvMsg)
				{
					byte[] array = new byte[num];
					Array.Copy(XFetchVersionNetwork.m_oRecvBuff, 0, array, 0, num);
					Encoding uTF = Encoding.UTF8;
					XSingleton<XUpdater>.singleton.SetServerVersion(uTF.GetString(array, 4, num - 4));
					return true;
				}
			}
			return false;
		}

		public int BreakPacket(byte[] data, int index, int len)
		{
			if (len < 4)
			{
				return 0;
			}
			int num = BitConverter.ToInt32(data, index);
			if (len < 4 + num)
			{
				return 0;
			}
			return num + 4;
		}
	}
}
