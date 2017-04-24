using System;

namespace Assets.SDK
{
	public sealed class InitAndroidSDKBUSSDAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__AndroidSDKBUSSD__";
			}
		}

		public InitAndroidSDKBUSSDAttribute(int appId, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, null, notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
