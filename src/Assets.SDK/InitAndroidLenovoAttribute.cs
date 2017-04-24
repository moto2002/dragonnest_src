using System;

namespace Assets.SDK
{
	public sealed class InitAndroidLenovoAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Lenovo__";
			}
		}

		public InitAndroidLenovoAttribute(string appId, string payKey, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitAndroidLenovoAttribute.CreateParams(appId, payKey), notifyObjName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string CreateParams(string appId, string payKey)
		{
			JoyYouSDKAttribute.ParamsCollector paramsCollector = new JoyYouSDKAttribute.ParamsCollector();
			paramsCollector.AddItemPair("appId", appId);
			paramsCollector.AddItemPair("payKey", payKey);
			return paramsCollector.GetJsonData();
		}
	}
}
