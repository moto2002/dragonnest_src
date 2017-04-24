using System;

namespace Assets.SDK
{
	public sealed class InitJoymeComponentAttribute : JoyYouComponentAttribute
	{
		public string theAppKey
		{
			get;
			private set;
		}

		public string theAppSecret
		{
			get;
			private set;
		}

		public string theRazorKey
		{
			get;
			private set;
		}

		public string theQQAppKey
		{
			get;
			private set;
		}

		public string theWeixinAppId
		{
			get;
			private set;
		}

		public string theWeixinAppKey
		{
			get;
			private set;
		}

		public string theWeiboAppKey
		{
			get;
			private set;
		}

		public bool logEnable
		{
			get;
			private set;
		}

		public bool debugEnable
		{
			get;
			private set;
		}

		public InitJoymeComponentAttribute(string appKey, string appSecret, string razorKey, string qqAppKey, string weixinAppId, string weixinAppKey, string weiboAppKey, bool debugEnable, bool logEnable, bool initInUse)
		{
			this.theAppKey = appKey;
			this.theAppSecret = appSecret;
			this.theRazorKey = razorKey;
			this.theQQAppKey = qqAppKey;
			this.theWeixinAppId = weixinAppId;
			this.theWeixinAppKey = weixinAppKey;
			this.theWeiboAppKey = weiboAppKey;
			this.logEnable = logEnable;
			this.debugEnable = debugEnable;
			base.isDelayInit = initInUse;
		}

		public InitJoymeComponentAttribute(string appKey, string appSecret, string razorKey, string qqAppKey, string weixinAppId, string weixinAppKey, string weiboAppKey, bool debugEnable, bool logEnable) : this(appKey, appSecret, razorKey, qqAppKey, weixinAppId, weixinAppKey, weiboAppKey, debugEnable, logEnable, true)
		{
		}

		public override void DoInit()
		{
			base.DoInit();
			JoyYouSDKAttribute.ParamsCollector paramsCollector = new JoyYouSDKAttribute.ParamsCollector();
			paramsCollector.AddItemPair("appKey", this.theAppKey);
			paramsCollector.AddItemPair("appSecret", this.theAppSecret);
			paramsCollector.AddItemPair("razorKey", this.theRazorKey);
			paramsCollector.AddItemPair("qqAppKey", this.theQQAppKey);
			paramsCollector.AddItemPair("weixinAppId", this.theWeixinAppId);
			paramsCollector.AddItemPair("weixinAppKey", this.theWeixinAppKey);
			paramsCollector.AddItemPair("weiboAppKey", this.theWeiboAppKey);
			paramsCollector.AddItemPair("=ITF=", base.GetType().Name);
			paramsCollector.AddItemPair("debug", (!this.debugEnable) ? 0 : 1);
			paramsCollector.AddItemPair("log", (!this.logEnable) ? 0 : 1);
			JoyYouNativeInterface.InitGameRecordItf(this.theAppKey, paramsCollector.GetJsonData());
		}
	}
}
