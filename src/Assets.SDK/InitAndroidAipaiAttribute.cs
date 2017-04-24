using System;

namespace Assets.SDK
{
	public sealed class InitAndroidAipaiAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_AiPai__";
			}
		}

		public InitAndroidAipaiAttribute(string appSecret, string deamonURL, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, deamonURL, notifyObjName, true, true, 0, appSecret, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
