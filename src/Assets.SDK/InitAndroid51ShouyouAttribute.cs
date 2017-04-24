using System;

namespace Assets.SDK
{
	public sealed class InitAndroid51ShouyouAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_51_Shouyou__";
			}
		}

		public InitAndroid51ShouyouAttribute(string appKey, string appSecret, string channelId, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitAndroid51ShouyouAttribute.paramsData(appKey, appSecret, channelId), notifyObjName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string paramsData(string appKey, string appSecret, string channelId)
		{
			JoyYouSDKAttribute.ParamsCollector paramsCollector = new JoyYouSDKAttribute.ParamsCollector();
			paramsCollector.AddItemPair("appKey", appKey);
			paramsCollector.AddItemPair("appSecret", appSecret);
			paramsCollector.AddItemPair("channelId", channelId);
			return paramsCollector.GetJsonData();
		}
	}
}
