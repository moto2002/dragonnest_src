using System;

namespace Assets.SDK
{
	public sealed class InitAndroidBaidu91Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Baidu91__";
			}
		}

		public InitAndroidBaidu91Attribute(int appId, string appKey, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
