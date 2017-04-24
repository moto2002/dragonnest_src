using System;

namespace Assets.SDK
{
	public sealed class InitSDOAppleAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__SDO_APPLE__";
			}
		}

		public InitSDOAppleAttribute(int appId, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, null, notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		public override void InitSDK()
		{
			Type typeFromHandle = typeof(JoyYouSDK);
			InitSDOPushAttribute customAttribute = typeFromHandle.GetCustomAttribute(false);
			if (customAttribute != null)
			{
				base.closeRechargeAlertMsg = customAttribute.AppId + ";" + customAttribute.AppKey;
			}
			base.InitSDK();
		}
	}
}
