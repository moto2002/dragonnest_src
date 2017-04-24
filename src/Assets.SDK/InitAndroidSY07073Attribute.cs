using System;

namespace Assets.SDK
{
	public sealed class InitAndroidSY07073Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_SY07073__";
			}
		}

		public InitAndroidSY07073Attribute(string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, null, notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
