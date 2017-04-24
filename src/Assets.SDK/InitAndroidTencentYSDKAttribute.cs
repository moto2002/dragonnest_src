using System;

namespace Assets.SDK
{
	public sealed class InitAndroidTencentYSDKAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_TencentYSDK__";
			}
		}

		public InitAndroidTencentYSDKAttribute(string qqAppId, string qqAppKey, string wxAppId, string wxAppKey, string msdkKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitAndroidTencentYSDKAttribute.CreateParams(qqAppId, qqAppKey, wxAppId, wxAppKey, msdkKey), notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string CreateParams(string qqAppId, string qqAppKey, string wxAppId, string wxAppKey, string msdkKey)
		{
			JoyYouSDKAttribute.ParamsCollector paramsCollector = new JoyYouSDKAttribute.ParamsCollector();
			paramsCollector.AddItemPair("qqAppId", qqAppId);
			paramsCollector.AddItemPair("qqAppKey", qqAppKey);
			paramsCollector.AddItemPair("wxAppId", wxAppId);
			paramsCollector.AddItemPair("wxAppKey", wxAppKey);
			paramsCollector.AddItemPair("msdkKey", msdkKey);
			return paramsCollector.GetJsonData();
		}
	}
}
