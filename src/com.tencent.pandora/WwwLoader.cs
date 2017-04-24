using com.tencent.pandora.MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class WwwLoader : MonoBehaviour
	{
		private const int MAX_RETRY_COUNT = 5;

		private int _retryCount;

		public void LoadRemoteConfig(UserData userData, Action<RemoteConfig> callback)
		{
			base.StartCoroutine(this.GetRemoteConfig(userData, callback));
		}

		[DebuggerHidden]
		private IEnumerator GetRemoteConfig(UserData userData, Action<RemoteConfig> callback)
		{
			WwwLoader.<GetRemoteConfig>c__IteratorB <GetRemoteConfig>c__IteratorB = new WwwLoader.<GetRemoteConfig>c__IteratorB();
			<GetRemoteConfig>c__IteratorB.userData = userData;
			<GetRemoteConfig>c__IteratorB.callback = callback;
			<GetRemoteConfig>c__IteratorB.<$>userData = userData;
			<GetRemoteConfig>c__IteratorB.<$>callback = callback;
			<GetRemoteConfig>c__IteratorB.<>f__this = this;
			return <GetRemoteConfig>c__IteratorB;
		}

		private Dictionary<string, string> GenerateCgiHeaders(UserData userData)
		{
			return new Dictionary<string, string>
			{
				{
					"User-Agent",
					"Pandora(" + userData.sSdkVersion + ")"
				}
			};
		}

		private string GenerateCgiGetParams(UserData userData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("openid=");
			stringBuilder.Append(userData.sOpenId);
			stringBuilder.Append("&partition=");
			stringBuilder.Append(userData.sPartition);
			stringBuilder.Append("&gameappversion=");
			stringBuilder.Append(userData.sGameVer);
			stringBuilder.Append("&areaid=");
			stringBuilder.Append(userData.sArea);
			stringBuilder.Append("&appid=");
			stringBuilder.Append(userData.sAppId);
			stringBuilder.Append("&acctype=");
			stringBuilder.Append(userData.sAcountType);
			stringBuilder.Append("&platid=");
			stringBuilder.Append(userData.sPlatID);
			stringBuilder.Append("&sdkversion=");
			stringBuilder.Append(userData.sSdkVersion);
			stringBuilder.Append("&_pdr_time=");
			stringBuilder.Append(TimeHelper.NowSeconds());
			return stringBuilder.ToString();
		}

		private string GenerateCgiPostParams(UserData userData)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["openid"] = userData.sOpenId;
			dictionary["partition"] = userData.sPartition;
			dictionary["gameappversion"] = userData.sGameVer;
			dictionary["areaid"] = userData.sArea;
			dictionary["acctype"] = userData.sAcountType;
			dictionary["platid"] = userData.sPlatID;
			dictionary["appid"] = userData.sAppId;
			dictionary["sdkversion"] = userData.sSdkVersion;
			string rawData = Json.Serialize(dictionary);
			return MsdkTea.Encode(rawData);
		}

		private byte[] GenerateCgiPostData(UserData userData)
		{
			string s = "{\"data\":\"" + this.GenerateCgiPostParams(userData) + "\",\"encrypt\" : \"true\"}";
			return Encoding.UTF8.GetBytes(s);
		}

		private RemoteConfig ParseCgiResponse(byte[] data)
		{
			string text = string.Empty;
			if (PandoraSettings.RequestCgiByPost)
			{
				string @string = Encoding.UTF8.GetString(data);
				Dictionary<string, object> dictionary = Json.Deserialize(@string) as Dictionary<string, object>;
				byte[] encodedDataBytes = Convert.FromBase64String(dictionary["data"] as string);
				text = MsdkTea.Decode(encodedDataBytes);
			}
			else
			{
				text = Encoding.UTF8.GetString(data);
			}
			Logger.LogInfo("获得RemoteConfig： " + text);
			if (string.IsNullOrEmpty(text))
			{
				return new RemoteConfig("{}");
			}
			return new RemoteConfig(text);
		}

		public void LoadWww(string url, string requestJson, bool isPost, Action<string> callback)
		{
			base.StartCoroutine(this.RequestWww(url, requestJson, isPost, callback));
		}

		[DebuggerHidden]
		private IEnumerator RequestWww(string url, string requestJson, bool isPost, Action<string> callback)
		{
			WwwLoader.<RequestWww>c__IteratorC <RequestWww>c__IteratorC = new WwwLoader.<RequestWww>c__IteratorC();
			<RequestWww>c__IteratorC.isPost = isPost;
			<RequestWww>c__IteratorC.requestJson = requestJson;
			<RequestWww>c__IteratorC.url = url;
			<RequestWww>c__IteratorC.callback = callback;
			<RequestWww>c__IteratorC.<$>isPost = isPost;
			<RequestWww>c__IteratorC.<$>requestJson = requestJson;
			<RequestWww>c__IteratorC.<$>url = url;
			<RequestWww>c__IteratorC.<$>callback = callback;
			<RequestWww>c__IteratorC.<>f__this = this;
			return <RequestWww>c__IteratorC;
		}

		private string GenerateGetParams(string requestJson)
		{
			if (string.IsNullOrEmpty(requestJson))
			{
				return string.Empty;
			}
			Dictionary<string, object> dictionary = Json.Deserialize(requestJson) as Dictionary<string, object>;
			bool flag = true;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string current in dictionary.Keys)
			{
				if (dictionary[current] != null)
				{
					if (flag)
					{
						flag = false;
						stringBuilder.Append("?");
					}
					else
					{
						stringBuilder.Append("&");
					}
					stringBuilder.Append(current + "=");
					stringBuilder.Append(dictionary[current].ToString());
				}
			}
			return stringBuilder.ToString();
		}

		private byte[] GeneratePostData(string requestJson)
		{
			if (string.IsNullOrEmpty(requestJson))
			{
				return new byte[0];
			}
			return Encoding.UTF8.GetBytes(requestJson);
		}

		public void Clear()
		{
			this._retryCount = 0;
		}
	}
}
