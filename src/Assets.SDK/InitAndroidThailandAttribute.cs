using System;

namespace Assets.SDK
{
	public sealed class InitAndroidThailandAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Thailand__";
			}
		}

		public InitAndroidThailandAttribute(string serverId, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Empty, notifyObjName, true, true, 0, serverId, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
