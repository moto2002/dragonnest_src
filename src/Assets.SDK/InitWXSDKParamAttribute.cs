using System;

namespace Assets.SDK
{
	public sealed class InitWXSDKParamAttribute : JoyYouComponentAttribute
	{
		public string appId
		{
			get;
			set;
		}

		public string appSecret
		{
			get;
			set;
		}

		public InitWXSDKParamAttribute(string appId, string appSecret)
		{
			this.appId = appId;
			this.appSecret = appSecret;
		}

		public override void DoInit()
		{
			base.DoInit();
			string format = "{{ \"appId\":\"{0}\", \"appSecrect\":\"{1}\" }}";
			string jsonData = string.Format(format, this.appId, this.appSecret);
			JoyYouNativeInterface.ShareSdkInit(0, jsonData);
		}
	}
}
