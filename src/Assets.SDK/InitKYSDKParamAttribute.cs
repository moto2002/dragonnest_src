using System;

namespace Assets.SDK
{
	public sealed class InitKYSDKParamAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Kuaiyong__";
			}
		}

		public InitKYSDKParamAttribute(string appKey, string payId, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, appKey, noficationObjectName, true, true, 0, payId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
