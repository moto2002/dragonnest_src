using System;

namespace Assets.SDK
{
	public sealed class InitAdvertisementAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__NONE_ADV__DEFAULT__";
			}
		}

		public InitAdvertisementAttribute(string notiObjname, string propertyId, string defaultContentId, bool logEnable) : base(0, propertyId, notiObjname, true, true, 0, defaultContentId, false, false, false, false, logEnable)
		{
		}

		public override void InitSDK()
		{
			string appKey = base.appKey;
			string closeRechargeAlertMsg = base.closeRechargeAlertMsg;
			bool logEnable = base.logEnable;
			JoyYouNativeInterface.initAdv(appKey, closeRechargeAlertMsg, logEnable);
		}
	}
}
