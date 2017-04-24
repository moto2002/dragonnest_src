using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.SDK
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public abstract class JoyYouSDKAttribute : Attribute
	{
		public class ParamsCollector
		{
			private Dictionary<string, object> paramsDict = new Dictionary<string, object>();

			public JoyYouSDKAttribute.ParamsCollector AddItemPair(string key, object value)
			{
				this.paramsDict.Add(key, value);
				return this;
			}

			public string GetJsonData()
			{
				string text = "{{\n {0} \n}}";
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				string value = "\"";
				string value2 = ":";
				foreach (KeyValuePair<string, object> current in this.paramsDict)
				{
					num++;
					stringBuilder.Append(value).Append(current.Key).Append(value).Append(value2);
					if (current.Value.GetType() == typeof(string))
					{
						stringBuilder.Append(value).Append(current.Value).Append(value);
					}
					else if (current.Value.GetType() == typeof(int) || current.Value.GetType() == typeof(long) || current.Value.GetType() == typeof(float) || current.Value.GetType() == typeof(double))
					{
						stringBuilder.Append(current.Value);
					}
					if (num < this.paramsDict.Count)
					{
						stringBuilder.Append(",\n");
					}
				}
				text = string.Format(text, stringBuilder.ToString());
				return text;
			}
		}

		public abstract string NAME
		{
			get;
		}

		public int appId
		{
			get;
			private set;
		}

		public string appKey
		{
			get;
			private set;
		}

		public string notifyObjName
		{
			get;
			private set;
		}

		public bool logEnable
		{
			get;
			private set;
		}

		public int rechargeAmount
		{
			get;
			private set;
		}

		public bool isLongConnect
		{
			get;
			private set;
		}

		public bool rechargeEnable
		{
			get;
			private set;
		}

		public string closeRechargeAlertMsg
		{
			get;
			protected set;
		}

		public bool isOriLandscapeLeft
		{
			get;
			private set;
		}

		public bool isOriLandscapeRight
		{
			get;
			private set;
		}

		public bool isOriPortrait
		{
			get;
			private set;
		}

		public bool isOriPortraitUpsideDown
		{
			get;
			private set;
		}

		public JoyYouSDKAttribute(int appId, string appKey, string noficationObjectName, bool isLongConnect, bool rechargeEnable, int rechargeAmount, string closeRechargeAlertMsg, bool isOriPortrait, bool isOriLandscapeLeft, bool isOriLandscapeRight, bool isOriPortraitUpsideDown, bool logEnable)
		{
			this.appId = appId;
			this.appKey = appKey;
			this.notifyObjName = noficationObjectName;
			this.logEnable = logEnable;
			this.rechargeAmount = rechargeAmount;
			this.isLongConnect = isLongConnect;
			this.rechargeEnable = rechargeEnable;
			this.closeRechargeAlertMsg = closeRechargeAlertMsg;
			this.isOriLandscapeLeft = isOriLandscapeLeft;
			this.isOriLandscapeRight = isOriLandscapeRight;
			this.isOriPortrait = isOriPortrait;
			this.isOriPortraitUpsideDown = isOriPortraitUpsideDown;
		}

		public virtual void InitSDK()
		{
			Debug.Log("------SDK Init Description Class------ : " + base.GetType().ToString());
			JoyYouNativeInterface.InitSDK(this.appId, this.appKey, this.logEnable, this.isLongConnect, this.rechargeEnable, this.rechargeAmount, this.closeRechargeAlertMsg, this.notifyObjName, this.isOriPortrait, this.isOriLandscapeLeft, this.isOriLandscapeRight, this.isOriPortraitUpsideDown);
		}

		public bool IsPlatformMatched(string name)
		{
			bool flag = !string.IsNullOrEmpty(name) && name == this.NAME;
			bool flag2 = true;
			return flag && flag2;
		}
	}
}
