using System;

namespace Assets.SDK
{
	public sealed class InitBaidu91SDKParamAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Baidu91__";
			}
		}

		public InitBaidu91SDKParamAttribute(int appId, string appKey, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, noficationObjectName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
