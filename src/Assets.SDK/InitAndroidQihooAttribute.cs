using System;

namespace Assets.SDK
{
	public sealed class InitAndroidQihooAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Qihoo__";
			}
		}

		public InitAndroidQihooAttribute(string notifyObjName, string url4cb, string appName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, null, notifyObjName, true, true, 0, url4cb + "__rxsn__" + appName, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
