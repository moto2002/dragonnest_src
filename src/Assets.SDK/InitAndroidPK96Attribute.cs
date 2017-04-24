using System;

namespace Assets.SDK
{
	public sealed class InitAndroidPK96Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__AndroidSDKPK96__";
			}
		}

		public InitAndroidPK96Attribute(string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Empty, notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
