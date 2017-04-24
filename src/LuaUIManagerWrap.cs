using LuaInterface;
using System;
using UnityEngine;

public class LuaUIManagerWrap
{
	private static Type classType = typeof(LuaUIManager);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("IsUIShowed", new LuaCSFunction(LuaUIManagerWrap.IsUIShowed)),
			new LuaMethod("Load", new LuaCSFunction(LuaUIManagerWrap.Load)),
			new LuaMethod("Hide", new LuaCSFunction(LuaUIManagerWrap.Hide)),
			new LuaMethod("GetDlgObj", new LuaCSFunction(LuaUIManagerWrap.GetDlgObj)),
			new LuaMethod("IDHide", new LuaCSFunction(LuaUIManagerWrap.IDHide)),
			new LuaMethod("Destroy", new LuaCSFunction(LuaUIManagerWrap.Destroy)),
			new LuaMethod("IDDestroy", new LuaCSFunction(LuaUIManagerWrap.IDDestroy)),
			new LuaMethod("Clear", new LuaCSFunction(LuaUIManagerWrap.Clear)),
			new LuaMethod("New", new LuaCSFunction(LuaUIManagerWrap._CreateLuaUIManager)),
			new LuaMethod("GetClassType", new LuaCSFunction(LuaUIManagerWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", new LuaCSFunction(LuaUIManagerWrap.get_Instance), null)
		};
		LuaScriptMgr.RegisterLib(L, "LuaUIManager", typeof(LuaUIManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaUIManager(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			LuaUIManager o = new LuaUIManager();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: LuaUIManager.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaUIManagerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, LuaUIManager.Instance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsUIShowed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		bool b = luaUIManager.IsUIShowed();
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool b = luaUIManager.Load(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Hide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool b = luaUIManager.Hide(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDlgObj(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		GameObject dlgObj = luaUIManager.GetDlgObj(luaString);
		LuaScriptMgr.Push(L, dlgObj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IDHide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		uint id = (uint)LuaScriptMgr.GetNumber(L, 2);
		bool b = luaUIManager.IDHide(id);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Destroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool b = luaUIManager.Destroy(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IDDestroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		uint id = (uint)LuaScriptMgr.GetNumber(L, 2);
		bool b = luaUIManager.IDDestroy(id);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaUIManager luaUIManager = (LuaUIManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaUIManager");
		luaUIManager.Clear();
		return 0;
	}
}
