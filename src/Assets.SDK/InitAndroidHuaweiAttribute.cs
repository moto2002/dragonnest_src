using System;

namespace Assets.SDK
{
	public sealed class InitAndroidHuaweiAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Huawei__";
			}
		}

		public InitAndroidHuaweiAttribute(string appId, string cpId, string payId, string fubiaoPrivateKey, string payPublicKey, string payPrivateKey, string companyName, string noficationObjectName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitAndroidHuaweiAttribute.paramsData(appId, cpId, payId, fubiaoPrivateKey, payPublicKey, payPrivateKey, companyName), noficationObjectName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string paramsData(string appId, string cpId, string payId, string fubiaoPrivateKey, string payPublicKey, string payPrivateKey, string companyName)
		{
			JoyYouSDKAttribute.ParamsCollector paramsCollector = new JoyYouSDKAttribute.ParamsCollector();
			paramsCollector.AddItemPair("appId", appId);
			paramsCollector.AddItemPair("cpId", cpId);
			paramsCollector.AddItemPair("payId", payId);
			paramsCollector.AddItemPair("fubiaoPrivateKey", fubiaoPrivateKey);
			paramsCollector.AddItemPair("payPublicKey", payPublicKey);
			paramsCollector.AddItemPair("payPrivateKey", payPrivateKey);
			paramsCollector.AddItemPair("companyName", companyName);
			return paramsCollector.GetJsonData();
		}
	}
}
