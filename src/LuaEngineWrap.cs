using LuaInterface;
using System;
using UnityEngine;

public class LuaEngineWrap
{
	private static Type classType = typeof(LuaEngine);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("InitLua", new LuaCSFunction(LuaEngineWrap.InitLua)),
			new LuaMethod("New", new LuaCSFunction(LuaEngineWrap._CreateLuaEngine)),
			new LuaMethod("GetClassType", new LuaCSFunction(LuaEngineWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(LuaEngineWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", new LuaCSFunction(LuaEngineWrap.get_Instance), new LuaCSFunction(LuaEngineWrap.set_Instance)),
			new LuaField("hotfixMgr", new LuaCSFunction(LuaEngineWrap.get_hotfixMgr), null),
			new LuaField("luaUIManager", new LuaCSFunction(LuaEngineWrap.get_luaUIManager), null),
			new LuaField("luaGameInfo", new LuaCSFunction(LuaEngineWrap.get_luaGameInfo), null)
		};
		LuaScriptMgr.RegisterLib(L, "LuaEngine", typeof(LuaEngine), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaEngine(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaEngine class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaEngineWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaEngine.Instance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hotfixMgr(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaEngine luaEngine = (LuaEngine)luaObject;
		if (luaEngine == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hotfixMgr");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hotfixMgr on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, luaEngine.hotfixMgr);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_luaUIManager(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaEngine luaEngine = (LuaEngine)luaObject;
		if (luaEngine == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaUIManager");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaUIManager on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, luaEngine.luaUIManager);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_luaGameInfo(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaEngine luaEngine = (LuaEngine)luaObject;
		if (luaEngine == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaGameInfo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaGameInfo on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, luaEngine.luaGameInfo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		LuaEngine.Instance = (LuaEngine)LuaScriptMgr.GetUnityObject(L, 3, typeof(LuaEngine));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaEngine luaEngine = (LuaEngine)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaEngine");
		luaEngine.InitLua();
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
