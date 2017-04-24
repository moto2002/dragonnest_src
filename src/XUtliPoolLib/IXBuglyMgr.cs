using System;

namespace XUtliPoolLib
{
	public interface IXBuglyMgr : IXInterface
	{
		void ReportCrashToBugly(string serverid, string rolename, string openid, string version, string realtime, string content);
	}
}
