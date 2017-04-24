using System;
using UnityEngine;

namespace Assets.JoyYouSDK.NativeImpl.Android
{
	public static class AndroidBridge
	{
		private static string IStatisticalData_native_objname = "__IStatisticalData";

		private static string IHuanleSDK_native_objname = "__ICommonSDKPlatform";

		private static string IDeviceInfo_native_objname = "__IDeviceInfomation";

		private static string IGameRecord_native_objname = "__";

		private static void AndroidInvoke(string _itf_obj_name, string method, params object[] args)
		{
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.joyyou.itf.JoyyouInterfaceFactory"))
						{
							string methodName = (!(_itf_obj_name == AndroidBridge.IHuanleSDK_native_objname)) ? ((!(_itf_obj_name == AndroidBridge.IStatisticalData_native_objname)) ? ((!(_itf_obj_name == AndroidBridge.IDeviceInfo_native_objname)) ? ((!(_itf_obj_name == AndroidBridge.IGameRecord_native_objname)) ? "ERROR_ITF_NAME" : "initInstance4GameRecord") : "initInstance4DeviceInfomation") : "initInstance4Statistical") : "initInstance4BridgedCommonSDKPlatform";
							androidJavaClass2.CallStatic(methodName, new object[]
							{
								@static
							});
							using (AndroidJavaObject static2 = androidJavaClass2.GetStatic<AndroidJavaObject>(_itf_obj_name))
							{
								static2.Call(method, args);
							}
						}
					}
				}
			}
		}

		private static T AndroidInvoke<T>(string _itf_obj_name, string method, params object[] args)
		{
			T result = default(T);
			if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.joyyou.itf.JoyyouInterfaceFactory"))
						{
							string methodName = (!(_itf_obj_name == AndroidBridge.IHuanleSDK_native_objname)) ? ((!(_itf_obj_name == AndroidBridge.IStatisticalData_native_objname)) ? ((!(_itf_obj_name == AndroidBridge.IDeviceInfo_native_objname)) ? ((!(_itf_obj_name == AndroidBridge.IGameRecord_native_objname)) ? "ERROR_ITF_NAME" : "initInstance4GameRecord") : "initInstance4DeviceInfomation") : "initInstance4Statistical") : "initInstance4BridgedCommonSDKPlatform";
							androidJavaClass2.CallStatic(methodName, new object[]
							{
								@static
							});
							using (AndroidJavaObject static2 = androidJavaClass2.GetStatic<AndroidJavaObject>(_itf_obj_name))
							{
								return static2.Call<T>(method, args);
							}
						}
					}
				}
				return result;
			}
			return result;
		}

		public static void CommonPlatformCall(string method, params object[] args)
		{
			AndroidBridge.AndroidInvoke(AndroidBridge.IHuanleSDK_native_objname, method, args);
		}

		public static T CommonPlatformCall<T>(string method, params object[] args)
		{
			return AndroidBridge.AndroidInvoke<T>(AndroidBridge.IHuanleSDK_native_objname, method, args);
		}

		public static void StatisticalDataCall(string method, params object[] args)
		{
			AndroidBridge.AndroidInvoke(AndroidBridge.IStatisticalData_native_objname, method, args);
		}

		public static T StatisticalDataCall<T>(string method, params object[] args)
		{
			return AndroidBridge.AndroidInvoke<T>(AndroidBridge.IStatisticalData_native_objname, method, args);
		}

		public static void DeviceInfomationCall(string method, params object[] args)
		{
			AndroidBridge.AndroidInvoke(AndroidBridge.IDeviceInfo_native_objname, method, args);
		}

		public static T DeviceInfomationCall<T>(string method, params object[] args)
		{
			return AndroidBridge.AndroidInvoke<T>(AndroidBridge.IDeviceInfo_native_objname, method, args);
		}

		public static void GameRecordCall(string method, params object[] args)
		{
			AndroidBridge.AndroidInvoke(AndroidBridge.IGameRecord_native_objname, method, args);
		}

		public static T GameRecordCall<T>(string method, params object[] args)
		{
			return AndroidBridge.AndroidInvoke<T>(AndroidBridge.IGameRecord_native_objname, method, args);
		}
	}
}
