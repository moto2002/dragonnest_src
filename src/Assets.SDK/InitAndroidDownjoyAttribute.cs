using System;

namespace Assets.SDK
{
	public sealed class InitAndroidDownjoyAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Downjoy__";
			}
		}

		public InitAndroidDownjoyAttribute(int appId, string appKey, int merchantId, int serverSeqNum, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(appId, string.Concat(new string[]
		{
			appKey,
			"__JOYYOU__",
			merchantId.ToString(),
			"__JOYYOU__",
			serverSeqNum.ToString()
		}), notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
