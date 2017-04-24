using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.SDK
{
	public sealed class InitAndroidKoreanAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Android_Korean__";
			}
		}

		public InitAndroidKoreanAttribute(string oneStoreId, string onestoreVerifyURL, string naverClientId, string naverClientSecret, string naverClientName, string naverCallbackIntentUrl, string naverIapKey, string naverVerifyURL, string googleClientId, string googleIapKey, string googleVerifyURL, string iapStyle, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitAndroidKoreanAttribute.createParams(oneStoreId, onestoreVerifyURL, naverClientId, naverClientSecret, naverClientName, naverCallbackIntentUrl, naverIapKey, naverVerifyURL, googleClientId, googleIapKey, googleVerifyURL), notifyObjName, true, true, 0, iapStyle, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string createParams(string oneStoreId, string onestoreVerifyURL, string naverClientId, string naverClientSecret, string naverClientName, string naverCallbackIntentUrl, string naverIapKey, string naverVerifyURL, string googleClientId, string googleIapKey, string googleVerifyURL)
		{
			string text = "{{\n {0} \n}}";
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("OneStoreId", oneStoreId);
			dictionary.Add("OneStoreVerifyURL", onestoreVerifyURL);
			dictionary.Add("NaverClientId", naverClientId);
			dictionary.Add("NaverClientSecret", naverClientSecret);
			dictionary.Add("NaverClientName", naverClientName);
			dictionary.Add("NaverCallbackIntentUrl", naverCallbackIntentUrl);
			dictionary.Add("NaverIapKey", naverIapKey);
			dictionary.Add("NaverVerifyURL", naverVerifyURL);
			dictionary.Add("GoogleClientID", googleClientId);
			dictionary.Add("GoogleIapKey", googleIapKey);
			dictionary.Add("GoogleVerifyURL", googleVerifyURL);
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
