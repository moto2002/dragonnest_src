using LuaInterface;
using System;

public class DebuggerWrap
{
	private static Type classType = typeof(Debugger);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Log", new LuaCSFunction(DebuggerWrap.Log)),
			new LuaMethod("LogWarning", new LuaCSFunction(DebuggerWrap.LogWarning)),
			new LuaMethod("LogError", new LuaCSFunction(DebuggerWrap.LogError)),
			new LuaMethod("New", new LuaCSFunction(DebuggerWrap._CreateDebugger)),
			new LuaMethod("GetClassType", new LuaCSFunction(DebuggerWrap.GetClassType))
		};
		LuaScriptMgr.RegisterLib(L, "Debugger", regs);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDebugger(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Debugger class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, DebuggerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Log(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 2, num - 1);
		Debugger.Log(luaString, paramsObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogWarning(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 2, num - 1);
		Debugger.LogWarning(luaString, paramsObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogError(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 2, num - 1);
		Debugger.LogError(luaString, paramsObject);
		return 0;
	}
}
