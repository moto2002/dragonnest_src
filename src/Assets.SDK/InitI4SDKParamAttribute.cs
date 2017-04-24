using System;

namespace Assets.SDK
{
	public sealed class InitI4SDKParamAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__I4SDK__";
			}
		}

		public InitI4SDKParamAttribute(int appId, string appKey, string noficationObjectName, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMsg, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, noficationObjectName, isLongConnect, rechargeEnable, rechargeAmount, closeRechargeAlertMsg, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
