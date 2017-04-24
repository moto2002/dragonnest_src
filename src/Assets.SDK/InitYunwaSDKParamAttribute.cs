using System;

namespace Assets.SDK
{
	public sealed class InitYunwaSDKParamAttribute : JoyYouComponentAttribute
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

		public override void DoInit()
		{
			base.DoInit();
		}
	}
}
