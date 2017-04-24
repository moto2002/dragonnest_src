using System;
using XUtliPoolLib;

public class AIMgrUtil
{
	private static IXAIGeneralMgr _ai_general_mgr;

	public static IXAIGeneralMgr GetAIMgrInterface()
	{
		if (AIMgrUtil._ai_general_mgr == null || AIMgrUtil._ai_general_mgr.Deprecated)
		{
			AIMgrUtil._ai_general_mgr = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXAIGeneralMgr>(XSingleton<XCommon>.singleton.XHash("XAIGeneralMgr"));
		}
		return AIMgrUtil._ai_general_mgr;
	}
}
