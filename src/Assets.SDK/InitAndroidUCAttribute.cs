using System;

namespace Assets.SDK
{
	public sealed class InitAndroidUCAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_UC__";
			}
		}

		public InitAndroidUCAttribute(int cpId, int uc_game_id, int serverId, bool useStandardUI, string notiObjname, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(cpId, uc_game_id.ToString(), notiObjname, true, useStandardUI, serverId, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
