using LuaInterface;
using System;
using UnityEngine;

public class SleepTimeoutWrap
{
	private static Type classType = typeof(SleepTimeout);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(SleepTimeoutWrap._CreateSleepTimeout)),
			new LuaMethod("GetClassType", new LuaCSFunction(SleepTimeoutWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("NeverSleep", new LuaCSFunction(SleepTimeoutWrap.get_NeverSleep), null),
			new LuaField("SystemSetting", new LuaCSFunction(SleepTimeoutWrap.get_SystemSetting), null)
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SleepTimeout", typeof(SleepTimeout), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSleepTimeout(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			SleepTimeout o = new SleepTimeout();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: SleepTimeout.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, SleepTimeoutWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_NeverSleep(IntPtr L)
	{
		LuaScriptMgr.Push(L, -1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SystemSetting(IntPtr L)
	{
		LuaScriptMgr.Push(L, -2);
		return 1;
	}
}
