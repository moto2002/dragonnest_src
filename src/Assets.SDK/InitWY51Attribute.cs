using System;

namespace Assets.SDK
{
	public sealed class InitWY51Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__WY_51__";
			}
		}

		public InitWY51Attribute(string appId, string appKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey, notifyObjName, true, true, 0, appId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
