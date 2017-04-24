using System;

namespace Assets.SDK
{
	public sealed class InitAndroidMuZhiWanAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_MuZhiWan__";
			}
		}

		public InitAndroidMuZhiWanAttribute(string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Empty, noficationObjectName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
