using System;

namespace Assets.SDK
{
	public sealed class InitAndroid2144Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_2144__";
			}
		}

		public InitAndroid2144Attribute(string appKey, string appSecret, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey, notifyObjName, true, true, 0, appSecret, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
