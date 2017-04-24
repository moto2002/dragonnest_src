using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.SDK
{
	public sealed class InitKoreanAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Korean__";
			}
		}

		public InitKoreanAttribute(int gameId, string naverClientId, string naverClientSecret, string naverClientName, string naverCallbackIntentUrl, string googleClientId, string iapPaymentCB, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(gameId, InitKoreanAttribute.createParams(naverClientId, naverClientSecret, naverClientName, naverCallbackIntentUrl, googleClientId), notifyObjName, true, true, 0, iapPaymentCB, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string createParams(string naverClientId, string naverClientSecret, string naverClientName, string naverCallbackIntentUrl, string googleClientId)
		{
			string text = "{{\n {0} \n}}";
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("NaverClientId", naverClientId);
			dictionary.Add("NaverClientSecret", naverClientSecret);
			dictionary.Add("NaverClientName", naverClientName);
			dictionary.Add("NaverCallbackIntentUrl", naverCallbackIntentUrl);
			dictionary.Add("GoogleClientId", googleClientId);
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			string value = "\"";
			string value2 = ":";
			foreach (KeyValuePair<string, string> current in dictionary)
			{
				num++;
				stringBuilder.Append(value).Append(current.Key).Append(value).Append(value2).Append(value).Append(current.Value).Append(value);
				if (num < dictionary.Count)
				{
					stringBuilder.Append(",\n");
				}
			}
			text = string.Format(text, stringBuilder.ToString());
			return text;
		}
	}
}
