using System;

namespace Assets.SDK
{
	public sealed class InitAndroidDyooAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Dyoo__";
			}
		}

		public InitAndroidDyooAttribute(string appID, string appSecret, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appID, notifyObjName, true, true, 0, appSecret, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
