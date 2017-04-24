using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class PandoraSettings
	{
		public static Logger.Level DEFAULT_LOG_LEVEL = Logger.Level.Debug;

		public static RuntimePlatform Platform
		{
			get
			{
				return RuntimePlatform.Android;
			}
		}

		public static bool IsProductEnvironment
		{
			get;
			set;
		}

		public static bool UseStreamingAssets
		{
			get
			{
				return false;
			}
		}

		public static bool IsAndroidPlatform
		{
			get
			{
				return Application.platform == RuntimePlatform.Android;
			}
		}

		public static bool IsIOSPlatform
		{
			get
			{
				return Application.platform == RuntimePlatform.IPhonePlayer;
			}
		}

		public static bool IsWindowsPlatform
		{
			get
			{
				return Application.platform == RuntimePlatform.WindowsPlayer;
			}
		}

		public static bool RequestCgiByPost
		{
			get
			{
				return false;
			}
		}

		public static void ReadEnvironmentSetting()
		{
			try
			{
				string path = LocalDirectoryHelper.GetSettingsFolderPath() + "/settings.txt";
				if (File.Exists(path))
				{
					string json = File.ReadAllText(path);
					Dictionary<string, object> dictionary = Json.Deserialize(json) as Dictionary<string, object>;
					if (dictionary.ContainsKey("isProductEnvironment"))
					{
						PandoraSettings.IsProductEnvironment = (dictionary["isProductEnvironment"] as string == "1");
					}
				}
			}
			catch
			{
			}
		}

		public static string GetSdkVersion()
		{
			if (PandoraSettings.Platform == RuntimePlatform.IPhonePlayer)
			{
				return "DN-IOS-V1";
			}
			return "DN-Android-V1";
		}

		public static string GetCgiUrl(string appId)
		{
			if (PandoraSettings.IsProductEnvironment)
			{
				return "https://pandora.game.qq.com/cgi-bin/api/tplay/" + appId + "_cloud.cgi";
			}
			return "https://pandora.game.qq.com/cgi-bin/api/tplay/cloudtest_v3.cgi";
		}

		public static string GetTemporaryCachePath()
		{
			return Application.temporaryCachePath;
		}

		public static string GetAtmHost()
		{
			if (PandoraSettings.IsProductEnvironment)
			{
				return "jsonatm.broker.tplay.qq.com";
			}
			return "test.broker.tplay.qq.com";
		}

		public static int GetAtmPort()
		{
			if (PandoraSettings.IsProductEnvironment)
			{
				return 5692;
			}
			return 4567;
		}

		public static string GetFileProtocolToken()
		{
			return "file://";
		}

		public static string GetPlatformDescription()
		{
			if (PandoraSettings.Platform == RuntimePlatform.IPhonePlayer)
			{
				return "ios";
			}
			return "android";
		}
	}
}
