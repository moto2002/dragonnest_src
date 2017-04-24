using System;

namespace Assets.JoyYouSDK.NativeImpl
{
	public interface ITPNative
	{
		void _U3D_initSDK(int appId, string appKey, bool logEnable, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMsg, string notificationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown);

		void _U3D_showLoginView();

		void _U3D_showCenterView();

		void _U3D_logout();

		void _U3D_exchangeGoods(int paramPrice, string paramBillNo, string paramBillTitle, string paramRoleId, int paramZoneId);
	}
}
