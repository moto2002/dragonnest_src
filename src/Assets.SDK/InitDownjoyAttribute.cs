using System;

namespace Assets.SDK
{
	public sealed class InitDownjoyAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Downjoy__";
			}
		}

		public InitDownjoyAttribute(int appId, string appKey, int merchantId, int serverId, string notiObjname, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, notiObjname, true, true, merchantId, serverId.ToString(), isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
