using System;

namespace Assets.SDK
{
	public sealed class InitGuopanAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Guopan__";
			}
		}

		public InitGuopanAttribute(string appId, string appKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey, notifyObjName, true, true, 0, appId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
