using System;

namespace Assets.SDK
{
	public sealed class InitGiantAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__GIANT__";
			}
		}

		public InitGiantAttribute(int appId, string appName, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appName, notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
