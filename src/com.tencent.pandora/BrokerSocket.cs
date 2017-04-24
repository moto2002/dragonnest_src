using com.tencent.pandora.MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class BrokerSocket : AbstractTcpClient
	{
		public const int PUSH = 1;

		public const int PULL = 2;

		public const int HEARTBEAT_INTERVAL = 30;

		public const int HEARTEART_TIMEOUT = 5;

		public const int C2S_LOGIN = 1001;

		public const int S2C_LOGIN = 1001;

		public const int C2S_HEARTBEAT = 1002;

		public const int S2C_HEARTBEAT = 1002;

		public const int S2C_PUSH = 1003;

		public const int C2S_ACTION = 9000;

		public const int S2C_ACTION = 9000;

		public const int C2S_STATS = 5001;

		public const int S2C_STATS = 5001;

		private int _retryCount;

		private bool _hasHeartbeatResponse;

		private uint _heartbeatCallId;

		private Coroutine _heartbeatCoroutine;

		private float _lastHeartbeatTime;

		private float _lastReconnectTime;

		private Coroutine _reconnectCoroutine;

		protected override void OnConnected()
		{
			if (Pandora.Instance.IsDebug)
			{
				Logger.LogInfo("<color=#00ff00>Broker Socket</color> 连接成功: " + this._host + this._address + this._port.ToString());
			}
			this.SendLogin();
		}

		protected override void OnReceived(byte[] content, int length)
		{
			string text = Zlib.Decompress(content, length);
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log("Broker 收到回包: ");
				Logger.Log(text);
			}
			Dictionary<string, object> dictionary = Json.Deserialize(text) as Dictionary<string, object>;
			int num = (int)((long)dictionary["type"]);
			int commandId = (int)((long)dictionary["cmd_id"]);
			uint callId = (uint)((long)dictionary["seq_id"]);
			if (num == 2)
			{
				this.HandlePullMessage(callId, commandId, dictionary["body"] as string);
			}
			else if (num == 1)
			{
				this.HandlePushMessage(callId, commandId, dictionary["body"] as string);
			}
		}

		private void HandlePullMessage(uint callId, int commandId, string message)
		{
			this._hasHeartbeatResponse = true;
			if (commandId != 1001)
			{
				if (commandId != 1002)
				{
					if (commandId == 9000)
					{
						CSharpInterface.ExecuteLuaCallback(callId, message);
					}
				}
			}
			else
			{
				this.EnterHeartbeatState();
			}
		}

		private void HandlePushMessage(uint callId, int commandId, string message)
		{
			if (commandId == 1003)
			{
				CSharpInterface.ExecuteLuaCallback(0u, message);
			}
		}

		private void EnterHeartbeatState()
		{
			base.SafeStopCoroutine(ref this._reconnectCoroutine);
			this._lastHeartbeatTime = Time.realtimeSinceStartup;
			base.SafeStartCoroutine(ref this._heartbeatCoroutine, this.DaemonHeartbeat());
		}

		private void EnterReconnectState()
		{
			this._retryCount = 0;
			base.SafeStopCoroutine(ref this._heartbeatCoroutine);
			base.SafeStartCoroutine(ref this._reconnectCoroutine, this.DaemonReconnect());
		}

		public void SendLogin()
		{
			string text = this.GenerateBody();
			Dictionary<string, object> dictionary = this.GeneratePacket(this._heartbeatCallId++, text, 1001, 1, 10);
			if (dictionary == AbstractTcpClient.EMPTY_PACKET)
			{
				return;
			}
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log("Broker 发送信息，命令字： " + 1001 + " \u3000内容：\u3000");
				Logger.Log(text);
			}
			base.Send(dictionary);
		}

		public void SendHeartbeat()
		{
			string text = this.GenerateBody();
			Dictionary<string, object> dictionary = this.GeneratePacket(this._heartbeatCallId++, text, 1002, 1, 10);
			if (dictionary == AbstractTcpClient.EMPTY_PACKET)
			{
				return;
			}
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log("Broker 发送信息，命令字： " + 1002 + " \u3000内容：\u3000");
				Logger.Log(text);
			}
			base.Send(dictionary);
		}

		private string GenerateBody()
		{
			UserData userData = Pandora.Instance.GetUserData();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["open_id"] = userData.sOpenId;
			dictionary["app_id"] = userData.sAppId;
			dictionary["sarea"] = userData.sArea;
			dictionary["splatid"] = userData.sPlatID;
			dictionary["spartition"] = userData.sPartition;
			dictionary["access_token"] = userData.sAccessToken;
			dictionary["acctype"] = userData.sAcountType;
			return Json.Serialize(dictionary);
		}

		[DebuggerHidden]
		private IEnumerator DaemonHeartbeat()
		{
			BrokerSocket.<DaemonHeartbeat>c__Iterator10 <DaemonHeartbeat>c__Iterator = new BrokerSocket.<DaemonHeartbeat>c__Iterator10();
			<DaemonHeartbeat>c__Iterator.<>f__this = this;
			return <DaemonHeartbeat>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator DaemonReconnect()
		{
			BrokerSocket.<DaemonReconnect>c__Iterator11 <DaemonReconnect>c__Iterator = new BrokerSocket.<DaemonReconnect>c__Iterator11();
			<DaemonReconnect>c__Iterator.<>f__this = this;
			return <DaemonReconnect>c__Iterator;
		}

		private int GetReconnectInterval(int retryCount)
		{
			int num = 1 << retryCount + 3;
			return num + UnityEngine.Random.Range(0, num);
		}

		public void Send(uint callId, string requestBody, int commandId)
		{
			Dictionary<string, object> dictionary = this.GeneratePacket(callId, requestBody, commandId, 1, 10);
			if (dictionary == AbstractTcpClient.EMPTY_PACKET)
			{
				return;
			}
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log(string.Concat(new object[]
				{
					"Broker 发送信息，CommandId： ",
					commandId,
					" \u3000CallId：\u3000",
					callId.ToString()
				}));
				Logger.Log(requestBody);
			}
			base.Send(dictionary);
		}

		private Dictionary<string, object> GeneratePacket(uint callId, string body, int commandId, int type = 1, int moduleId = 10)
		{
			UserData userData = Pandora.Instance.GetUserData();
			if (string.IsNullOrEmpty(userData.sOpenId))
			{
				return AbstractTcpClient.EMPTY_PACKET;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["seq_id"] = callId;
			dictionary["cmd_id"] = commandId;
			dictionary["type"] = type;
			dictionary["from_ip"] = "10.0.0.108";
			dictionary["process_id"] = 1;
			dictionary["mod_id"] = moduleId;
			dictionary["version"] = userData.sSdkVersion;
			dictionary["body"] = body;
			dictionary["app_id"] = userData.sAppId;
			dictionary["network_type"] = base.GetNetworkType();
			return dictionary;
		}

		public override void Close()
		{
			base.SafeStopCoroutine(ref this._heartbeatCoroutine);
			base.SafeStopCoroutine(ref this._reconnectCoroutine);
			base.Close();
		}
	}
}
