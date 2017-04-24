using System;

namespace Assets.SDK
{
	public sealed class InitAndroidTencentAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Tencent__";
			}
		}

		public InitAndroidTencentAttribute(int qqAppId, string qqAppKey, string weixinAppId, string midasId, string msdkKey, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Concat(new object[]
		{
			qqAppId,
			"__JOYYOU__",
			qqAppKey,
			"__JOYYOU__",
			weixinAppId,
			"__JOYYOU__",
			msdkKey,
			"__JOYYOU__",
			midasId
		}), notifyObjName, true, true, 0, url4cb, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}
	}
}
