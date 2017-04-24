using Assets.SDK;
using System;
using UnityEngine;

namespace Assets.JoyYouSDK.NativeImpl
{
	public static class ThirdPlatformAdapter
	{
		private static ITPNative tpItf;

		public static void InitSDK(int appId, string appKey, bool logEnable, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMsg, string notificationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown)
		{
			if (ThirdPlatformAdapter.tpItf != null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				ThirdPlatformAdapter.tpItf._U3D_initSDK(appId, appKey, logEnable, isLongConnect, rechargeEnable, rechargeAmount, closeRechargeAlertMsg, notificationObjectName, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown);
			}
			else
			{
				JoyYouInterfaceSimulator.NotificationObjeName = notificationObjectName;
			}
		}

		public static void ShowLoginView()
		{
			if (ThirdPlatformAdapter.tpItf != null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				ThirdPlatformAdapter.tpItf._U3D_showLoginView();
			}
			else
			{
				JoyYouInterfaceSimulator.ShowLoginView();
			}
		}

		public static void ShowCenterView()
		{
			if (ThirdPlatformAdapter.tpItf != null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				ThirdPlatformAdapter.tpItf._U3D_showCenterView();
			}
			else
			{
				JoyYouInterfaceSimulator.ShowCenterView();
			}
		}

		public static void Logout()
		{
			if (ThirdPlatformAdapter.tpItf != null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				ThirdPlatformAdapter.tpItf._U3D_logout();
			}
			else
			{
				JoyYouInterfaceSimulator.Logout();
			}
		}

		public static void ExchangeGoods(int price, string billNo, string billTitle, string roleId, int zoneId)
		{
			if (ThirdPlatformAdapter.tpItf != null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
			{
				ThirdPlatformAdapter.tpItf._U3D_exchangeGoods(price, billNo, billTitle, roleId, zoneId);
			}
			else
			{
				JoyYouInterfaceSimulator.Pay();
			}
		}
	}
}
