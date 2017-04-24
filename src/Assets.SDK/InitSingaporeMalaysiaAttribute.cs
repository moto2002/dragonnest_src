using System;

namespace Assets.SDK
{
	public sealed class InitSingaporeMalaysiaAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Singapore&Malaysia__";
			}
		}

		public InitSingaporeMalaysiaAttribute(int gameId, string appSecret, string lang, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(gameId, appSecret, notifyObjName, true, true, 0, lang, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
