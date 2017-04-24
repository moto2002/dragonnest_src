using System;

namespace Assets.SDK
{
	public sealed class InitQQSDKParamAttribute : JoyYouComponentAttribute
	{
		public string AppId
		{
			get;
			private set;
		}

		public string AppKey
		{
			get;
			private set;
		}

		public InitQQSDKParamAttribute(string appId, string appKey)
		{
			this.AppId = appId;
			this.AppKey = appKey;
		}

		public override void DoInit()
		{
			base.DoInit();
			string format = "{{ \"appId\":\"{0}\", \"appKey\":\"{1}\" }}";
			string jsonData = string.Format(format, this.AppId, this.AppKey);
			JoyYouNativeInterface.ShareSdkInit(1, jsonData);
		}
	}
}
