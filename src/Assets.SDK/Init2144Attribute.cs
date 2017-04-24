using System;

namespace Assets.SDK
{
	public sealed class Init2144Attribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__2144__";
			}
		}

		public Init2144Attribute(int gameID, string appId, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(gameID, appId, notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
