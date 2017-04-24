using System;

namespace Assets.SDK
{
	public sealed class InitTongbutuiSDKParamAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Tongbutui__";
			}
		}

		public InitTongbutuiSDKParamAttribute(int appId, string appKey, string noficationObjectName, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMsg, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, noficationObjectName, isLongConnect, rechargeEnable, rechargeAmount, closeRechargeAlertMsg, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
