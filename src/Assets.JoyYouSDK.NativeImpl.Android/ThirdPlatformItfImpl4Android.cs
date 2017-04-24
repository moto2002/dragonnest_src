using Assets.SDK;
using System;

namespace Assets.JoyYouSDK.NativeImpl.Android
{
	public class ThirdPlatformItfImpl4Android : I3RDPlatformSDK
	{
		public ThirdPlatformItfImpl4Android(int appId, string appKey, bool logEnable, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMessage, string paramSendMsgNotiClass, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown)
		{
			AndroidBridge.CommonPlatformCall("Init", new object[]
			{
				appId,
				appKey,
				logEnable,
				isLongConnect,
				rechargeEnable,
				rechargeAmount,
				closeRechargeAlertMessage,
				paramSendMsgNotiClass,
				isOriPortrait,
				isOriLandscapeLeft,
				isOriLandscapeRight,
				isOriPortraitUpsideDown
			});
		}

		void I3RDPlatformSDK.ShowLoginView()
		{
			AndroidBridge.CommonPlatformCall("Login", new object[]
			{
				null,
				string.Empty,
				string.Empty
			});
		}

		void I3RDPlatformSDK.ShowLoginViewWithType(int type)
		{
			AndroidBridge.CommonPlatformCall("Login", new object[]
			{
				type
			});
		}

		void I3RDPlatformSDK.ShowCenterView()
		{
			AndroidBridge.CommonPlatformCall("ShowUserCentered", new object[0]);
		}

		void I3RDPlatformSDK.Pay(int paramPrice, string paramBillNo, string paramBillTitle, string paramRoleId, int paramZoneId)
		{
			AndroidBridge.CommonPlatformCall("PayGoods", new object[]
			{
				paramPrice,
				paramBillNo,
				paramBillTitle,
				paramRoleId,
				paramZoneId
			});
		}

		void I3RDPlatformSDK.Logout()
		{
			AndroidBridge.CommonPlatformCall("Logout", new object[0]);
		}
	}
}
