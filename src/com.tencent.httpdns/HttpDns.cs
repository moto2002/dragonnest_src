using System;
using UnityEngine;
using XUtliPoolLib;

namespace com.tencent.httpdns
{
	public class HttpDns
	{
		private static AndroidJavaObject m_dnsJo;

		private static AndroidJavaClass sGSDKPlatformClass;

		private static bool inited;

		public static void Init()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			if (androidJavaClass == null)
			{
				return;
			}
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			if (@static == null)
			{
				return;
			}
			AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getApplicationContext", new object[0]);
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("com.tencent.msdk.dns.MSDKDnsResolver", new object[0]);
			XSingleton<XDebug>.singleton.AddLog("WGGetHostByName ========== " + androidJavaObject2, null, null, null, null, null, XDebugColor.XDebug_None);
			if (androidJavaObject2 == null)
			{
				return;
			}
			HttpDns.m_dnsJo = androidJavaObject2.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
			XSingleton<XDebug>.singleton.AddLog("WGGetHostByName ========== " + HttpDns.m_dnsJo, null, null, null, null, null, XDebugColor.XDebug_None);
			if (HttpDns.m_dnsJo == null)
			{
				return;
			}
			HttpDns.m_dnsJo.Call("init", new object[]
			{
				androidJavaObject
			});
			HttpDns.inited = true;
		}

		public static string GetHostByName(string url)
		{
			string text = url;
			if (text == null || text.Equals(string.Empty))
			{
				return null;
			}
			XSingleton<XDebug>.singleton.AddLog("originalUrl: " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = true;
			if (!text.Contains("://"))
			{
				flag = false;
				text = "http://" + text;
			}
			Uri uri = new Uri(text);
			string host = uri.Host;
			XSingleton<XDebug>.singleton.AddLog("originalDomain: " + host, null, null, null, null, null, XDebugColor.XDebug_None);
			string empty = string.Empty;
			string text2 = text;
			if (!flag)
			{
				text2 = text2.Replace("http://", string.Empty);
			}
			XSingleton<XDebug>.singleton.AddLog("convertedUrl: " + text2, null, null, null, null, null, XDebugColor.XDebug_None);
			return text2;
		}
	}
}
