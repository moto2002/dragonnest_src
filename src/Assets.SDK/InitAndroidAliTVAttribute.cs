using System;

namespace Assets.SDK
{
	public sealed class InitAndroidAliTVAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_AliTV__";
			}
		}

		public InitAndroidAliTVAttribute(string appkey, string appsecret, string notifyUrl, string gamename, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Concat(new string[]
		{
			appkey,
			"__JOYYOU__",
			appsecret,
			"__JOYYOU__",
			notifyUrl
		}), notifyObjName, true, true, 0, gamename, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
