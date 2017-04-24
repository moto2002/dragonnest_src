using System;

namespace Assets.SDK
{
	public sealed class InitBuglyComponentAttribute : JoyYouComponentAttribute
	{
		public string BuglyAppId
		{
			get;
			set;
		}

		public InitBuglyComponentAttribute(string appId)
		{
			this.BuglyAppId = appId;
		}
	}
}
