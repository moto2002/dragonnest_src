using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.SDK
{
	public sealed class InitThailandAttribute : JoyYouSDKAttribute
	{
		public override string NAME
		{
			get
			{
				return "__Thailand__";
			}
		}

		public InitThailandAttribute(string productId, string location, string serverId, string notifyObjName, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable) : base(0, InitThailandAttribute.createParams(productId, location, serverId), notifyObjName, true, true, 0, string.Empty, isOriPortrait, isOriLandscapeLeft, isOriLandscapeRight, isOriPortraitUpsideDown, logEnable)
		{
		}

		private static string createParams(string productId, string location, string serverId)
		{
			string text = "{{\n {0} \n}}";
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("productId", productId);
			dictionary.Add("location", location);
			dictionary.Add("serverId", serverId);
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
