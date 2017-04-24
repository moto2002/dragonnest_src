using Assets.SDK;
using System;
using UnityEngine;
using XUtliPoolLib;

public class XBuglyMgr : MonoBehaviour, IXInterface, IXBuglyMgr
{
	private JoyYouSDK _interface;

	public bool Deprecated
	{
		get;
		set;
	}

	private void Awake()
	{
		this._interface = new JoyYouSDK();
		BuglyAgent.ConfigDebugMode(false);
		switch (Application.platform)
		{
		case RuntimePlatform.IPhonePlayer:
			BuglyAgent.InitWithAppId("i1105309683");
			break;
		case RuntimePlatform.Android:
			BuglyAgent.InitWithAppId("1105309683");
			break;
		}
		BuglyAgent.EnableExceptionHandler();
	}

	public void ReportCrashToBugly(string serverid, string rolename, string openid, string version, string realtime, string content)
	{
		BuglyAgent.ReportException("Exception", string.Format("ServerID: {0}  RoleName: {1}  OpenID: {2}  Version: {3}  RealTime:  {4}", new object[]
		{
			serverid,
			rolename,
			openid,
			version,
			realtime
		}), content);
	}
}
