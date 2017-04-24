using System;

namespace Assets.SDK
{
	public sealed class InitAndroid7XZAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_7XZ__";
			}
		}

		public InitAndroid7XZAttribute(string appId, string appKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appId, notifyObjName, true, true, 0, appKey, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
