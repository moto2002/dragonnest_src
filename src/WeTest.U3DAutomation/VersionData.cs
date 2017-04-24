using System;

namespace WeTest.U3DAutomation
{
	[Serializable]
	internal class VersionData
	{
		public string sdkVersion;

		public string engine;

		public string engineVersion;

		public string sdkUIType;

		public VersionData()
		{
			this.sdkVersion = VersionInfo.SDK_VERSION;
			this.engine = VersionInfo.ENGINE;
			this.sdkUIType = VersionInfo.SDK_UI;
		}
	}
}
