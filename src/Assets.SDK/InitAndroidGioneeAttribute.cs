using System;

namespace Assets.SDK
{
	public sealed class InitAndroidGioneeAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Gionee__";
			}
		}

		public InitAndroidGioneeAttribute(string apiKey, string url4createOrder, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, apiKey, notifyObjName, true, true, 0, url4createOrder, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
