using System;

namespace Assets.SDK
{
	public sealed class InitAndroidMeizuAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_MeiZu__";
			}
		}

		public InitAndroidMeizuAttribute(int appId, string appKey, string apkSecret, string url, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, string.Concat(new string[]
		{
			appKey,
			"__joyyou__",
			apkSecret,
			"__joyyou__",
			url
		}), notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
