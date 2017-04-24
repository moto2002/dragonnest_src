using System;

namespace Assets.SDK
{
	public sealed class InitAndroidCoolpadAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Coolpad__";
			}
		}

		public InitAndroidCoolpadAttribute(string appId, string orderServerRequset, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitAndroidCoolpadAttribute.CreateParams(appId, orderServerRequset), notifyObjName, true, true, 0, null, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string CreateParams(string appId, string orderServerRequset)
		{
			JoyYouSDKAttribute.ParamsCollector paramsCollector = new JoyYouSDKAttribute.ParamsCollector();
			paramsCollector.AddItemPair("appId", appId);
			paramsCollector.AddItemPair("orderServerRequset", orderServerRequset);
			return paramsCollector.GetJsonData();
		}
	}
}
