using System;

namespace Assets.SDK
{
	public sealed class InitAndroidSingaporeMalaysiaAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Singapore&Malaysia__";
			}
		}

		public InitAndroidSingaporeMalaysiaAttribute(int gameId, string appSecret, string lang, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(gameId, appSecret, notifyObjName, true, true, 0, lang, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
