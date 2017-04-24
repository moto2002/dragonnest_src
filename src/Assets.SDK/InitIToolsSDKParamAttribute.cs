using System;

namespace Assets.SDK
{
	public sealed class InitIToolsSDKParamAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__iTools__";
			}
		}

		public InitIToolsSDKParamAttribute(int appId, string appKey, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown) : base(appId, appKey, noficationObjectName, true, true, 100, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, false)
		{
		}
	}
}
