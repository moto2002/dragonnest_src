using System;

namespace Assets.SDK
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class InitBaiduStatSDKParamAttribute : Attribute
	{
		public bool isUse;

		public bool enableExceptionLog;

		public string channelId;

		public int logStrategy;

		public int logSendInterval;

		public bool logSendWifyOnly;

		public int sessionResumeInterval;

		public string appKey;

		public InitBaiduStatSDKParamAttribute(bool isUse, bool enableExceptionLog, string channelId, int logStrategy, int logSendInterval, bool logSendWifyOnly, int sessionResumeInterval, string appKey)
		{
			this.isUse = isUse;
			this.enableExceptionLog = enableExceptionLog;
			this.channelId = channelId;
			this.logStrategy = logStrategy;
			this.logSendInterval = logSendInterval;
			this.logSendWifyOnly = logSendWifyOnly;
			this.sessionResumeInterval = sessionResumeInterval;
			this.appKey = appKey;
		}
	}
}
