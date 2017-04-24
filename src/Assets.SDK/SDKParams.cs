using System;
using System.Reflection;
using UnityEngine;

namespace Assets.SDK
{
	public static class SDKParams
	{
		public static string Get3rdPlatformName(Type t)
		{
			string result = string.Empty;
			JoyYouSDKPlatformFilterAttribute[] array = (JoyYouSDKPlatformFilterAttribute[])t.GetCustomAttributes(typeof(JoyYouSDKPlatformFilterAttribute), false);
			if (array != null && array.Length > 0)
			{
				result = array[0].PlatformName;
			}
			return result;
		}

		public static JoyYouComponentAttribute[] GetJoyYouComponentAttribute(Type t)
		{
			return (JoyYouComponentAttribute[])t.GetCustomAttributes(typeof(JoyYouComponentAttribute), false);
		}

		private static void InitAdvertisementSDK(Type t)
		{
			InitAdvertisementAttribute[] array = (InitAdvertisementAttribute[])t.GetCustomAttributes(typeof(InitAdvertisementAttribute), false);
			if (array != null && array.Length > 0)
			{
				InitAdvertisementAttribute[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					InitAdvertisementAttribute initAdvertisementAttribute = array2[i];
					initAdvertisementAttribute.InitSDK();
				}
			}
		}

		private static bool Platform_Cast<T>(bool tag, JoyYouSDKAttribute attr) where T : class
		{
			return tag && attr is T;
		}

		private static void Init3rdPlatformSDK(Type t)
		{
			bool flag = false;
			string text = SDKParams.Get3rdPlatformName(t);
			object[] customAttributes = t.GetCustomAttributes(false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				object obj = customAttributes[i];
				JoyYouSDKAttribute joyYouSDKAttribute = obj as JoyYouSDKAttribute;
				if (joyYouSDKAttribute != null && joyYouSDKAttribute.NAME == text)
				{
					Debug.Log("SDK initialised begin --> " + text);
					joyYouSDKAttribute.InitSDK();
					flag = true;
					break;
				}
			}
			FieldInfo field = t.GetField("isInitialised", BindingFlags.Static | BindingFlags.NonPublic);
			field.SetValue(t, flag);
			if (!flag)
			{
				Debug.LogWarning("SDK initialised failed!");
			}
			else
			{
				Debug.Log("SDK initialised succeed --> " + text);
			}
		}

		private static void InitComponent(Type t)
		{
			JoyYouComponentAttribute[] joyYouComponentAttribute = SDKParams.GetJoyYouComponentAttribute(t);
			JoyYouComponentAttribute[] array = joyYouComponentAttribute;
			for (int i = 0; i < array.Length; i++)
			{
				JoyYouComponentAttribute joyYouComponentAttribute2 = array[i];
				if (joyYouComponentAttribute2 != null)
				{
					if (!joyYouComponentAttribute2.isDelayInit)
					{
						joyYouComponentAttribute2.DoInit();
					}
					if (joyYouComponentAttribute2 is InitRecNowComponentAttribute)
					{
						FieldInfo field = t.GetField("isSupported_IGameRecord", BindingFlags.Static | BindingFlags.NonPublic);
						field.SetValue(t, true);
						Debug.Log("RecNow Plugin Initialised.");
						FieldInfo field2 = t.GetField("IGameRecord_DelayInit", BindingFlags.Static | BindingFlags.NonPublic);
						MethodInfo method = t.GetMethod("AddEventObs");
						method.Invoke(null, new object[]
						{
							new IGameRecord_DelayInit(joyYouComponentAttribute2.DoInit)
						});
					}
					else if (joyYouComponentAttribute2 is InitJoymeComponentAttribute)
					{
						FieldInfo field3 = t.GetField("isSupported_IGameRecord", BindingFlags.Static | BindingFlags.NonPublic);
						field3.SetValue(t, true);
						Debug.Log("Joyme Plugin Initialised.");
						FieldInfo field4 = t.GetField("IGameRecord_DelayInit", BindingFlags.Static | BindingFlags.NonPublic);
						MethodInfo method2 = t.GetMethod("AddEventObs");
						method2.Invoke(null, new object[]
						{
							new IGameRecord_DelayInit(joyYouComponentAttribute2.DoInit)
						});
					}
				}
			}
		}

		public static void Parse(Type t)
		{
			SDKParams.InitAdvertisementSDK(t);
			SDKParams.Init3rdPlatformSDK(t);
			SDKParams.InitComponent(t);
		}
	}
}
