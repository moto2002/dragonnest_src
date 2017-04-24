using LuaInterface;
using System;
using UnityEngine;

public class LuaDlgWrap
{
	private static Type classType = typeof(LuaDlg);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnHide", new LuaCSFunction(LuaDlgWrap.OnHide)),
			new LuaMethod("Destroy", new LuaCSFunction(LuaDlgWrap.Destroy)),
			new LuaMethod("OnDestroy", new LuaCSFunction(LuaDlgWrap.OnDestroy)),
			new LuaMethod("OnShow", new LuaCSFunction(LuaDlgWrap.OnShow)),
			new LuaMethod("New", new LuaCSFunction(LuaDlgWrap._CreateLuaDlg)),
			new LuaMethod("GetClassType", new LuaCSFunction(LuaDlgWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(LuaDlgWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[0];
		LuaScriptMgr.RegisterLib(L, "LuaDlg", typeof(LuaDlg), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaDlg(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaDlg class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaDlgWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnHide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaDlg luaDlg = (LuaDlg)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaDlg");
		luaDlg.OnHide();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Destroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaDlg luaDlg = (LuaDlg)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaDlg");
		luaDlg.Destroy();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDestroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaDlg luaDlg = (LuaDlg)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaDlg");
		luaDlg.OnDestroy();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnShow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaDlg luaDlg = (LuaDlg)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaDlg");
		luaDlg.OnShow();
		return 0;
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
