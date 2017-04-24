using System;

namespace Assets.SDK
{
	public sealed class InitAndroidAnzhiAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_AnZhi__";
			}
		}

		public InitAndroidAnzhiAttribute(string appKey, string appSecret, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey + "__JOYYOU__" + appSecret, notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
