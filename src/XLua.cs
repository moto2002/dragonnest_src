using LuaInterface;
using System;

public class XLua
{
	public static void ReqNextDayInfo()
	{
	}

	public static void CallNextDay(uint status, uint time)
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		luaScriptMgr.DoFile("LuaSystemActivityDlg.lua");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("LuaSystemActivityDlg.OnXkcbStatus");
		luaFunction.Call(new object[]
		{
			status,
			time
		});
	}

	public static void CallOnline(uint index, bool canclaim)
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		luaScriptMgr.DoFile("LuaSystemActivityDlg.lua");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("LuaSystemActivityDlg.OnXkcbOnline");
		luaFunction.Call(new object[]
		{
			index,
			canclaim
		});
	}

	public static void NotifyRoute(uint _type, byte[] bytes, int length)
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		luaScriptMgr.DoFile("LuaNotifyProcess.lua");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("LuaNotifyProcess.Process");
		luaFunction.Call(new object[]
		{
			_type,
			Hotfix.LuaProtoBuffer(bytes, length),
			length
		});
	}

	public static object[] FetchRegistID()
	{
		LuaScriptMgr luaScriptMgr = HotfixManager.Instance.GetLuaScriptMgr();
		luaScriptMgr.DoFile("LuaNotifyProcess.lua");
		LuaFunction luaFunction = luaScriptMgr.GetLuaFunction("LuaNotifyProcess.FetchRegistedID");
		return luaFunction.Call();
	}
}
