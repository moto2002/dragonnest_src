using LuaInterface;
using System;
using UnityEngine;

public class UIWidgetContainerWrap
{
	private static Type classType = typeof(UIWidgetContainer);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(UIWidgetContainerWrap._CreateUIWidgetContainer)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIWidgetContainerWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIWidgetContainerWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[0];
		LuaScriptMgr.RegisterLib(L, "UIWidgetContainer", typeof(UIWidgetContainer), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIWidgetContainer(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIWidgetContainer class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIWidgetContainerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object x = LuaScriptMgr.GetLuaObject(L, 1) as UnityEngine.Object;
		UnityEngine.Object y = LuaScriptMgr.GetLuaObject(L, 2) as UnityEngine.Object;
		bool b = x == y;
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
