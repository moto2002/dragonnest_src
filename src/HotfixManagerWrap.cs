using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

public class HotfixManagerWrap
{
	private static Type classType = typeof(HotfixManager);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LoadHotfix", new LuaCSFunction(HotfixManagerWrap.LoadHotfix)),
			new LuaMethod("Dispose", new LuaCSFunction(HotfixManagerWrap.Dispose)),
			new LuaMethod("DoLuaFile", new LuaCSFunction(HotfixManagerWrap.DoLuaFile)),
			new LuaMethod("TryFixMsglist", new LuaCSFunction(HotfixManagerWrap.TryFixMsglist)),
			new LuaMethod("TryFixClick", new LuaCSFunction(HotfixManagerWrap.TryFixClick)),
			new LuaMethod("TryFixNet", new LuaCSFunction(HotfixManagerWrap.TryFixNet)),
			new LuaMethod("TryFixRefresh", new LuaCSFunction(HotfixManagerWrap.TryFixRefresh)),
			new LuaMethod("TryFixHandler", new LuaCSFunction(HotfixManagerWrap.TryFixHandler)),
			new LuaMethod("RegistedPtc", new LuaCSFunction(HotfixManagerWrap.RegistedPtc)),
			new LuaMethod("GetLuaScriptMgr", new LuaCSFunction(HotfixManagerWrap.GetLuaScriptMgr)),
			new LuaMethod("OnEnterScene", new LuaCSFunction(HotfixManagerWrap.OnEnterScene)),
			new LuaMethod("OnEnterSceneFinally", new LuaCSFunction(HotfixManagerWrap.OnEnterSceneFinally)),
			new LuaMethod("OnAttachToHost", new LuaCSFunction(HotfixManagerWrap.OnAttachToHost)),
			new LuaMethod("OnReconnect", new LuaCSFunction(HotfixManagerWrap.OnReconnect)),
			new LuaMethod("OnDetachFromHost", new LuaCSFunction(HotfixManagerWrap.OnDetachFromHost)),
			new LuaMethod("FadeShow", new LuaCSFunction(HotfixManagerWrap.FadeShow)),
			new LuaMethod("OnPause", new LuaCSFunction(HotfixManagerWrap.OnPause)),
			new LuaMethod("New", new LuaCSFunction(HotfixManagerWrap._CreateHotfixManager)),
			new LuaMethod("GetClassType", new LuaCSFunction(HotfixManagerWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("CLICK_LUA_FILE", new LuaCSFunction(HotfixManagerWrap.get_CLICK_LUA_FILE), null),
			new LuaField("NET_LUA_FILE", new LuaCSFunction(HotfixManagerWrap.get_NET_LUA_FILE), null),
			new LuaField("DOC_LUA_FILE", new LuaCSFunction(HotfixManagerWrap.get_DOC_LUA_FILE), null),
			new LuaField("MSG_LUE_FILE", new LuaCSFunction(HotfixManagerWrap.get_MSG_LUE_FILE), null),
			new LuaField("useHotfix", new LuaCSFunction(HotfixManagerWrap.get_useHotfix), new LuaCSFunction(HotfixManagerWrap.set_useHotfix)),
			new LuaField("hotmsglist", new LuaCSFunction(HotfixManagerWrap.get_hotmsglist), new LuaCSFunction(HotfixManagerWrap.set_hotmsglist)),
			new LuaField("Instance", new LuaCSFunction(HotfixManagerWrap.get_Instance), null)
		};
		LuaScriptMgr.RegisterLib(L, "HotfixManager", typeof(HotfixManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateHotfixManager(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			HotfixManager o = new HotfixManager();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: HotfixManager.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, HotfixManagerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CLICK_LUA_FILE(IntPtr L)
	{
		LuaScriptMgr.Push(L, "HotfixClick.lua");
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_NET_LUA_FILE(IntPtr L)
	{
		LuaScriptMgr.Push(L, "HotfixNet.lua");
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DOC_LUA_FILE(IntPtr L)
	{
		LuaScriptMgr.Push(L, "HotfixDocument.lua");
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MSG_LUE_FILE(IntPtr L)
	{
		LuaScriptMgr.Push(L, "HotfixMsglist.lua");
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useHotfix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		HotfixManager hotfixManager = (HotfixManager)luaObject;
		if (hotfixManager == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useHotfix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useHotfix on a nil value");
			}
		}
		LuaScriptMgr.Push(L, hotfixManager.useHotfix);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hotmsglist(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		HotfixManager hotfixManager = (HotfixManager)luaObject;
		if (hotfixManager == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hotmsglist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hotmsglist on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, hotfixManager.hotmsglist);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, HotfixManager.Instance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useHotfix(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		HotfixManager hotfixManager = (HotfixManager)luaObject;
		if (hotfixManager == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useHotfix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useHotfix on a nil value");
			}
		}
		hotfixManager.useHotfix = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hotmsglist(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		HotfixManager hotfixManager = (HotfixManager)luaObject;
		if (hotfixManager == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hotmsglist");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hotmsglist on a nil value");
			}
		}
		hotfixManager.hotmsglist = (Dictionary<string, string>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<string, string>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadHotfix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
		Action finish;
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			finish = (Action)LuaScriptMgr.GetNetObject(L, 2, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			finish = delegate
			{
				func.Call();
			};
		}
		hotfixManager.LoadHotfix(finish);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Dispose(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.Dispose();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DoLuaFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool b = hotfixManager.DoLuaFile(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryFixMsglist(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.TryFixMsglist();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryFixClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		HotfixMode mode = (HotfixMode)((int)LuaScriptMgr.GetNetObject(L, 2, typeof(HotfixMode)));
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		bool b = hotfixManager.TryFixClick(mode, luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryFixNet(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
			HotfixMode mode = (HotfixMode)((int)LuaScriptMgr.GetNetObject(L, 2, typeof(HotfixMode)));
			string luaString = LuaScriptMgr.GetLuaString(L, 3);
			bool b = hotfixManager.TryFixNet(mode, luaString);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 4)
		{
			HotfixManager hotfixManager2 = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
			HotfixMode mode2 = (HotfixMode)((int)LuaScriptMgr.GetNetObject(L, 2, typeof(HotfixMode)));
			uint udid = (uint)LuaScriptMgr.GetNumber(L, 3);
			object varObject = LuaScriptMgr.GetVarObject(L, 4);
			bool b2 = hotfixManager2.TryFixNet(mode2, udid, varObject);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: HotfixManager.TryFixNet");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryFixRefresh(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		HotfixMode mode = (HotfixMode)((int)LuaScriptMgr.GetNetObject(L, 2, typeof(HotfixMode)));
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 4, typeof(GameObject));
		bool b = hotfixManager.TryFixRefresh(mode, luaString, go);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryFixHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		HotfixMode mode = (HotfixMode)((int)LuaScriptMgr.GetNetObject(L, 2, typeof(HotfixMode)));
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 4, typeof(GameObject));
		bool b = hotfixManager.TryFixHandler(mode, luaString, go);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegistedPtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		uint type = (uint)LuaScriptMgr.GetNumber(L, 2);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 3);
		int length = (int)LuaScriptMgr.GetNumber(L, 4);
		hotfixManager.RegistedPtc(type, arrayNumber, length);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLuaScriptMgr(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		LuaScriptMgr luaScriptMgr = hotfixManager.GetLuaScriptMgr();
		LuaScriptMgr.PushObject(L, luaScriptMgr);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnEnterScene(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.OnEnterScene();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnEnterSceneFinally(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.OnEnterSceneFinally();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnAttachToHost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.OnAttachToHost();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnReconnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.OnReconnect();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDetachFromHost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		hotfixManager.OnDetachFromHost();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FadeShow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		hotfixManager.FadeShow(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HotfixManager hotfixManager = (HotfixManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "HotfixManager");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		hotfixManager.OnPause(boolean);
		return 0;
	}
}
