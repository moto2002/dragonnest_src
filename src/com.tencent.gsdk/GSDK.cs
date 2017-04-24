using System;
using UnityEngine;

namespace com.tencent.gsdk
{
	public class GSDK
	{
		private static AndroidJavaClass sGSDKPlatformClass;

		private static FpsRecorder sFpsRecorder;

		private static string mTagId;

		private static float sFpsInterval = 0.2f;

		private static GameObject sCallbackGameObject;

		public static void Init(string appid, bool debug, int env)
		{
			GSDKUtils.isDebug = debug;
			GSDK.sGSDKPlatformClass = new AndroidJavaClass("com.tencent.gsdk.api.GSDKPlatform");
			AndroidJavaObject GMContext = null;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				GMContext = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			if (GSDK.sGSDKPlatformClass != null && GMContext != null)
			{
				GMContext.Call("runOnUiThread", new object[]
				{
					new AndroidJavaRunnable(delegate
					{
						GSDK.sGSDKPlatformClass.CallStatic("GSDKInit", new object[]
						{
							GMContext,
							appid,
							debug,
							env
						});
					})
				});
			}
		}

		public static void SetUserName(int plat, string openid)
		{
			GSDK.sGSDKPlatformClass.CallStatic("GSDKSetUserName", new object[]
			{
				plat,
				openid
			});
		}

		public static void Start(int area, string tag, string roomip)
		{
			GSDK.mTagId = tag;
			if (GSDK.sCallbackGameObject == null)
			{
				GSDK.sCallbackGameObject = new GameObject("GSDKCallBackGameObejct");
				GSDK.sCallbackGameObject.AddComponent<GSDKCallBackComponent>();
				UnityEngine.Object.DontDestroyOnLoad(GSDK.sCallbackGameObject);
			}
			GSDK.sGSDKPlatformClass.CallStatic("GSDKStart", new object[]
			{
				area,
				roomip
			});
		}

		public static void End()
		{
			FpsInfo fpsInfo = null;
			if (GSDK.sFpsRecorder != null)
			{
				GSDK.sFpsRecorder.Finish();
				fpsInfo = GSDK.sFpsRecorder.GetLastFpsInfo();
			}
			string graphicsDeviceName = SystemInfo.graphicsDeviceName;
			GSDK.sGSDKPlatformClass.CallStatic("GSDKSaveGpuInfo", new object[]
			{
				graphicsDeviceName
			});
			if (fpsInfo == null)
			{
				GSDK.sGSDKPlatformClass.CallStatic("GSDKSaveFps", new object[]
				{
					string.Empty,
					-1,
					-1,
					-1,
					-1,
					-1,
					-1,
					-1,
					"-1"
				});
				GSDK.sGSDKPlatformClass.CallStatic("GSDKEnd", new object[0]);
			}
			else
			{
				GSDK.sGSDKPlatformClass.CallStatic("GSDKSaveFps", new object[]
				{
					fpsInfo.tag,
					fpsInfo.avg,
					fpsInfo.max,
					fpsInfo.min,
					fpsInfo.totalTimes,
					fpsInfo.heavyTimes,
					fpsInfo.lightTimes,
					fpsInfo.cusTimes,
					fpsInfo.fpsdots
				});
				GSDK.sGSDKPlatformClass.CallStatic("GSDKEnd", new object[0]);
			}
		}

		public static FpsInfo GetLastFpsInfo()
		{
			if (GSDK.sFpsRecorder != null)
			{
				return GSDK.sFpsRecorder.GetLastFpsInfo();
			}
			return null;
		}

		public static int GetFps()
		{
			if (GSDK.sFpsRecorder != null)
			{
				return GSDK.sFpsRecorder.GetFps();
			}
			return -1;
		}

		internal static void StartFps(int cusTs, int dotFreq)
		{
			if (GSDK.sFpsRecorder != null)
			{
				GSDK.sFpsRecorder.Clear();
			}
			GSDK.sFpsRecorder = new FpsRecorder(GSDK.sFpsInterval, cusTs, dotFreq);
			GSDK.sFpsRecorder.Start(GSDK.mTagId);
		}

		public static void SetEvent(int tag, bool status, string msg)
		{
			GSDK.sGSDKPlatformClass.CallStatic("GSDKSetEvent", new object[]
			{
				tag,
				status,
				msg
			});
		}

		public static string GetFpsInfo()
		{
			return GSDK.sFpsRecorder.GetFpsDotsStr();
		}

		public static string GetCpuList()
		{
			return GSDK.sGSDKPlatformClass.CallStatic<string>("getCpuList", new object[0]);
		}

		public static string GetMemList()
		{
			return GSDK.sGSDKPlatformClass.CallStatic<string>("getMemList", new object[0]);
		}

		public static string GetUdpList()
		{
			return GSDK.sGSDKPlatformClass.CallStatic<string>("getUdpList", new object[0]);
		}

		public static string GetSignalList()
		{
			return GSDK.sGSDKPlatformClass.CallStatic<string>("getSignalList", new object[0]);
		}
	}
}
