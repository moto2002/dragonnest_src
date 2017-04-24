using System;

namespace Assets.SDK
{
	public sealed class InitAndroidM4399Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_M4399__";
			}
		}

		public InitAndroidM4399Attribute(int appId, string appKey, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, appKey, noficationObjectName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
