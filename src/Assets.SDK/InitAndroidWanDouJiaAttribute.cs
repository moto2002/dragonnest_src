using System;

namespace Assets.SDK
{
	public sealed class InitAndroidWanDouJiaAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_WanDouJia__";
			}
		}

		public InitAndroidWanDouJiaAttribute(int appId, string appKey, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, noficationObjectName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
