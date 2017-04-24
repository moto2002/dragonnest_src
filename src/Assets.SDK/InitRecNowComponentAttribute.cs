using System;

namespace Assets.SDK
{
	public sealed class InitRecNowComponentAttribute : JoyYouComponentAttribute
	{
		public string theAppKey
		{
			get;
			private set;
		}

		public string theWeixinKey
		{
			get;
			private set;
		}

		public string theQQZoneKey
		{
			get;
			private set;
		}

		public InitRecNowComponentAttribute(string appKey, string weixinKey, string qqZoneKey, bool initInUse)
		{
			this.theAppKey = appKey;
			this.theWeixinKey = weixinKey;
			this.theQQZoneKey = qqZoneKey;
			base.isDelayInit = initInUse;
		}

		public InitRecNowComponentAttribute(string appKey, string weixinKey, string qqZoneKey) : this(appKey, weixinKey, qqZoneKey, true)
		{
		}

		public override void DoInit()
		{
			base.DoInit();
			JoyYouNativeInterface.InitGameRecordItf(this.theAppKey, this.theWeixinKey + ";" + this.theQQZoneKey);
		}
	}
}
