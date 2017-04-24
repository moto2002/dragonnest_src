using System;

namespace Assets.SDK
{
	public sealed class InitSDOJailbreakAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__SDO__JAILBREAK__";
			}
		}

		public InitSDOJailbreakAttribute(int appId, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, null, notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
