using LuaInterface;
using System;
using UnityEngine;

public class UICenterOnChildWrap
{
	private static Type classType = typeof(UICenterOnChild);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Recenter", new LuaCSFunction(UICenterOnChildWrap.Recenter)),
			new LuaMethod("CenterOn", new LuaCSFunction(UICenterOnChildWrap.CenterOn)),
			new LuaMethod("New", new LuaCSFunction(UICenterOnChildWrap._CreateUICenterOnChild)),
			new LuaMethod("GetClassType", new LuaCSFunction(UICenterOnChildWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UICenterOnChildWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("springStrength", new LuaCSFunction(UICenterOnChildWrap.get_springStrength), new LuaCSFunction(UICenterOnChildWrap.set_springStrength)),
			new LuaField("nextPageThreshold", new LuaCSFunction(UICenterOnChildWrap.get_nextPageThreshold), new LuaCSFunction(UICenterOnChildWrap.set_nextPageThreshold)),
			new LuaField("onFinished", new LuaCSFunction(UICenterOnChildWrap.get_onFinished), new LuaCSFunction(UICenterOnChildWrap.set_onFinished)),
			new LuaField("centeredObject", new LuaCSFunction(UICenterOnChildWrap.get_centeredObject), null)
		};
		LuaScriptMgr.RegisterLib(L, "UICenterOnChild", typeof(UICenterOnChild), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUICenterOnChild(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UICenterOnChild class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICenterOnChildWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_springStrength(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name springStrength");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index springStrength on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICenterOnChild.springStrength);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nextPageThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextPageThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextPageThreshold on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICenterOnChild.nextPageThreshold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onFinished on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICenterOnChild.onFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_centeredObject(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name centeredObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index centeredObject on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICenterOnChild.centeredObject);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_springStrength(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name springStrength");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index springStrength on a nil value");
			}
		}
		uICenterOnChild.springStrength = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_nextPageThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextPageThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextPageThreshold on a nil value");
			}
		}
		uICenterOnChild.nextPageThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)luaObject;
		if (uICenterOnChild == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onFinished on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uICenterOnChild.onFinished = (SpringPanel.OnFinished)LuaScriptMgr.GetNetObject(L, 3, typeof(SpringPanel.OnFinished));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uICenterOnChild.onFinished = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Recenter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICenterOnChild");
		uICenterOnChild.Recenter();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CenterOn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UICenterOnChild uICenterOnChild = (UICenterOnChild)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICenterOnChild");
		Transform target = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		uICenterOnChild.CenterOn(target);
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
