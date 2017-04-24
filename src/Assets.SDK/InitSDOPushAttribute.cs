using System;

namespace Assets.SDK
{
	public sealed class InitSDOPushAttribute : JoyYouComponentAttribute
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

		public InitSDOPushAttribute(string appId, string appKey)
		{
			this.AppId = appId;
			this.AppKey = appKey;
		}
	}
}
