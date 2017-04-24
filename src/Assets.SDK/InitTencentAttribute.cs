using System;

namespace Assets.SDK
{
	public sealed class InitTencentAttribute : JoyYouSDKAttribute
	{
		public int qqAppId
		{
			get;
			set;
		}

		public string qqAppKey
		{
			get;
			set;
		}

		public string weixinAppId
		{
			get;
			set;
		}

		public string midasId
		{
			get;
			set;
		}

		public string msdkKey
		{
			get;
			set;
		}

		public new bool logEnable
		{
			get;
			set;
		}

		public override string NAME
		{
			get
			{
				return "__Tencent__";
			}
		}

		public InitTencentAttribute(int qqAppId, string qqAppKey, string weixinAppId, string midasId, string msdkKey, string notifyObjName, string url4cb, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, string.Concat(new object[]
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
			this.qqAppId = qqAppId;
			this.qqAppKey = qqAppKey;
			this.weixinAppId = weixinAppId;
			this.midasId = midasId;
			this.msdkKey = msdkKey;
			this.logEnable = logEnable;
		}
	}
}
