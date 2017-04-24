using System;

namespace Assets.SDK
{
	public sealed class InitHaimaSDKParamAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Haima__";
			}
		}

		public InitHaimaSDKParamAttribute(string appId, string appVKey, string cpKey, string channelId, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Concat(new string[]
		{
			appId,
			";",
			appVKey,
			";",
			cpKey
		}), noficationObjectName, true, true, 0, channelId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
