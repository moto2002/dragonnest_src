using System;

namespace Assets.SDK
{
	public sealed class InitAndroidXiaomiAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Xiaomi__";
			}
		}

		public InitAndroidXiaomiAttribute(string appId, string appKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey, notifyObjName, true, true, 0, appId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
