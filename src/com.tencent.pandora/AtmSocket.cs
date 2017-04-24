using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class AtmSocket : AbstractTcpClient
	{
		public const int RECONNECT_INTERVAL = 10;

		public const int MAX_PACKET_LENGTH = 4096;

		public const int C2S_LOG = 5000;

		private int _callId;

		private float _lastReceivedTime;

		private static Dictionary<string, object> _bodyDict = new Dictionary<string, object>();

		private static List<Dictionary<string, object>> _extendObjList = new List<Dictionary<string, object>>();

		private static Dictionary<string, object> _idObj = new Dictionary<string, object>();

		private static Dictionary<string, object> _typeObj = new Dictionary<string, object>();

		private static Dictionary<string, object> _valueObj = new Dictionary<string, object>();

		private string _systemInfo;

		public void Report(string error, int id = 0, int type = 0)
		{
			try
			{
				if (Pandora.Instance.IsDebug)
				{
					Logger.Log("上报ATM: " + error + " CallId: " + this._callId.ToString());
				}
				string body = this.GenerateBody(error, id, type);
				Dictionary<string, object> dictionary = this.GeneratePacket(body);
				if (dictionary != AbstractTcpClient.EMPTY_PACKET)
				{
					if (Time.realtimeSinceStartup - this._lastReceivedTime > 10f && base.State == AbstractTcpClient.SocketState.Success)
					{
						this.Close();
					}
					base.Send(dictionary);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("上报流水日志失败：  " + error + " " + ex.Message);
			}
		}

		private string GenerateBody(string message, int id, int type)
		{
			UserData userData = Pandora.Instance.GetUserData();
			AtmSocket._bodyDict["str_openid"] = userData.sOpenId;
			AtmSocket._bodyDict["spartition"] = userData.sPartition;
			AtmSocket._bodyDict["splatid"] = userData.sPlatID;
			AtmSocket._bodyDict["str_userip"] = "10.0.0.1";
			AtmSocket._bodyDict["str_respara"] = message + this.GetSystemInfo();
			AtmSocket._bodyDict["uint_report_type"] = 2;
			AtmSocket._bodyDict["uint_toreturncode"] = 1;
			AtmSocket._bodyDict["uint_log_level"] = 2;
			AtmSocket._bodyDict["str_openid"] = userData.sOpenId;
			AtmSocket._bodyDict["sarea"] = userData.sArea;
			AtmSocket._bodyDict["str_hardware_os"] = "unity";
			AtmSocket._bodyDict["str_sdk_version"] = userData.sSdkVersion;
			AtmSocket._bodyDict["uint_serialtime"] = TimeHelper.NowSeconds();
			AtmSocket._bodyDict["extend"] = this.GetExtendObjList(id, type, message);
			return Json.Serialize(AtmSocket._bodyDict);
		}

		private List<Dictionary<string, object>> GetExtendObjList(int id, int type, string content)
		{
			if (AtmSocket._extendObjList.Count == 0)
			{
				AtmSocket._idObj["name"] = "attr_id_0";
				AtmSocket._idObj["value"] = id;
				AtmSocket._extendObjList.Add(AtmSocket._idObj);
				AtmSocket._typeObj["name"] = "attr_type_0";
				AtmSocket._typeObj["value"] = type;
				AtmSocket._extendObjList.Add(AtmSocket._typeObj);
				AtmSocket._valueObj["name"] = "attr_value_0";
				AtmSocket._valueObj["value"] = content;
				AtmSocket._extendObjList.Add(AtmSocket._valueObj);
			}
			AtmSocket._idObj["value"] = id.ToString();
			AtmSocket._typeObj["value"] = type.ToString();
			AtmSocket._valueObj["value"] = "1";
			if (type == 2)
			{
				AtmSocket._valueObj["value"] = content + this.GetSystemInfo();
			}
			return AtmSocket._extendObjList;
		}

		private string GetSystemInfo()
		{
			if (string.IsNullOrEmpty(this._systemInfo))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("|DeviceModel=");
				stringBuilder.Append(SystemInfo.deviceModel);
				stringBuilder.Append("&DeviceType=");
				stringBuilder.Append(SystemInfo.deviceType);
				stringBuilder.Append("&OperatingSystem=");
				stringBuilder.Append(SystemInfo.operatingSystem);
				stringBuilder.Append("&ProcessorType=");
				stringBuilder.Append(SystemInfo.processorType);
				stringBuilder.Append("&SystemMemorySize=");
				stringBuilder.Append(SystemInfo.systemMemorySize);
				stringBuilder.Append("&GraphicsDeviceName=");
				stringBuilder.Append(SystemInfo.graphicsDeviceName);
				this._systemInfo = stringBuilder.ToString();
			}
			return this._systemInfo;
		}

		private Dictionary<string, object> GeneratePacket(string body)
		{
			UserData userData = Pandora.Instance.GetUserData();
			if (string.IsNullOrEmpty(userData.sOpenId))
			{
				return AbstractTcpClient.EMPTY_PACKET;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["seq_id"] = this._callId++;
			dictionary["cmd_id"] = 5000;
			dictionary["type"] = 1;
			dictionary["from_ip"] = "10.0.0.108";
			dictionary["process_id"] = 1;
			dictionary["mod_id"] = 10;
			dictionary["version"] = userData.sSdkVersion;
			dictionary["body"] = body;
			dictionary["app_id"] = userData.sAppId;
			dictionary["network_type"] = base.GetNetworkType();
			return dictionary;
		}

		protected override void OnConnected()
		{
			this._lastReceivedTime = Time.realtimeSinceStartup;
			if (Pandora.Instance.IsDebug)
			{
				Logger.LogInfo("<color=#00ff00>Atm Socket</color> 连接成功: " + this._host + this._address + this._port.ToString());
			}
		}

		protected override void OnReceived(byte[] content, int length)
		{
			this._lastReceivedTime = Time.realtimeSinceStartup;
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log("收到ATM上报回包： " + Zlib.Decompress(content, length));
			}
		}

		protected override byte[] SerializePacket(Dictionary<string, object> packet)
		{
			byte[] array = base.SerializePacket(packet);
			if (array.Length > 4096)
			{
				Logger.LogWarning("上报包字节长度超过4K，当前包长： " + array.Length);
			}
			return array;
		}
	}
}
