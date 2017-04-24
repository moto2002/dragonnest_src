using System;

namespace Assets.SDK
{
	public sealed class InitAndroidMumayiAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Mumayi__";
			}
		}

		public InitAndroidMumayiAttribute(string appkey, string gamename, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appkey, notifyObjName, true, true, 0, gamename, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
