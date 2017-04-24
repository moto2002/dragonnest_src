using System;

namespace Assets.SDK
{
	public sealed class InitAndroidGuopanAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Guopan__";
			}
		}

		public InitAndroidGuopanAttribute(string appId, string appKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey, notifyObjName, true, true, 0, appId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
