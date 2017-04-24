using LuaInterface;
using System;
using UILib;
using UnityEngine;

public class DelManagerWrap
{
	private static Type classType = typeof(DelManager);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Clear", new LuaCSFunction(DelManagerWrap.Clear)),
			new LuaMethod("New", new LuaCSFunction(DelManagerWrap._CreateDelManager)),
			new LuaMethod("GetClassType", new LuaCSFunction(DelManagerWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("onGoClick", new LuaCSFunction(DelManagerWrap.get_onGoClick), new LuaCSFunction(DelManagerWrap.set_onGoClick)),
			new LuaField("fButtonDelegate", new LuaCSFunction(DelManagerWrap.get_fButtonDelegate), new LuaCSFunction(DelManagerWrap.set_fButtonDelegate)),
			new LuaField("sButtonDelegate", new LuaCSFunction(DelManagerWrap.get_sButtonDelegate), new LuaCSFunction(DelManagerWrap.set_sButtonDelegate)),
			new LuaField("sprClickEventHandler", new LuaCSFunction(DelManagerWrap.get_sprClickEventHandler), new LuaCSFunction(DelManagerWrap.set_sprClickEventHandler))
		};
		LuaScriptMgr.RegisterLib(L, "DelManager", typeof(DelManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDelManager(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			DelManager o = new DelManager();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: DelManager.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelManagerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onGoClick(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelManager.onGoClick);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fButtonDelegate(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelManager.fButtonDelegate);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sButtonDelegate(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelManager.sButtonDelegate);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sprClickEventHandler(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelManager.sprClickEventHandler);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onGoClick(IntPtr L)
	{
		LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			DelManager.onGoClick = (DelManager.GameObjDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(DelManager.GameObjDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			DelManager.onGoClick = delegate(GameObject param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fButtonDelegate(IntPtr L)
	{
		LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			DelManager.fButtonDelegate = (ButtonClickEventHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ButtonClickEventHandler));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			DelManager.fButtonDelegate = delegate(IXUIButton param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.PushObject(L, param0);
				func.PCall(oldTop, 1);
				object[] array = func.PopValues(oldTop);
				func.EndPCall(oldTop);
				return (bool)array[0];
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sButtonDelegate(IntPtr L)
	{
		LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			DelManager.sButtonDelegate = (ButtonClickEventHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(ButtonClickEventHandler));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			DelManager.sButtonDelegate = delegate(IXUIButton param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.PushObject(L, param0);
				func.PCall(oldTop, 1);
				object[] array = func.PopValues(oldTop);
				func.EndPCall(oldTop);
				return (bool)array[0];
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sprClickEventHandler(IntPtr L)
	{
		LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			DelManager.sprClickEventHandler = (SpriteClickEventHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(SpriteClickEventHandler));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			DelManager.sprClickEventHandler = delegate(IXUISprite param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.PushObject(L, param0);
				func.PCall(oldTop, 1);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		DelManager.Clear();
		return 0;
	}
}
