using LuaInterface;
using System;
using UnityEngine;

public class TweenWidthWrap
{
	private static Type classType = typeof(TweenWidth);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Begin", new LuaCSFunction(TweenWidthWrap.Begin)),
			new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenWidthWrap.SetStartToCurrentValue)),
			new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenWidthWrap.SetEndToCurrentValue)),
			new LuaMethod("New", new LuaCSFunction(TweenWidthWrap._CreateTweenWidth)),
			new LuaMethod("GetClassType", new LuaCSFunction(TweenWidthWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(TweenWidthWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("from", new LuaCSFunction(TweenWidthWrap.get_from), new LuaCSFunction(TweenWidthWrap.set_from)),
			new LuaField("to", new LuaCSFunction(TweenWidthWrap.get_to), new LuaCSFunction(TweenWidthWrap.set_to)),
			new LuaField("updateTable", new LuaCSFunction(TweenWidthWrap.get_updateTable), new LuaCSFunction(TweenWidthWrap.set_updateTable)),
			new LuaField("cachedWidget", new LuaCSFunction(TweenWidthWrap.get_cachedWidget), null),
			new LuaField("value", new LuaCSFunction(TweenWidthWrap.get_value), new LuaCSFunction(TweenWidthWrap.set_value))
		};
		LuaScriptMgr.RegisterLib(L, "TweenWidth", typeof(TweenWidth), regs, fields, typeof(UITweener));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTweenWidth(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TweenWidth class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, TweenWidthWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name from");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index from on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenWidth.from);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name to");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index to on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenWidth.to);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateTable(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateTable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateTable on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenWidth.updateTable);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedWidget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedWidget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedWidget on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenWidth.cachedWidget);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenWidth.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name from");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index from on a nil value");
			}
		}
		tweenWidth.from = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name to");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index to on a nil value");
			}
		}
		tweenWidth.to = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateTable(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateTable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateTable on a nil value");
			}
		}
		tweenWidth.updateTable = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenWidth tweenWidth = (TweenWidth)luaObject;
		if (tweenWidth == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}
		tweenWidth.value = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIWidget widget = (UIWidget)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIWidget));
		float duration = (float)LuaScriptMgr.GetNumber(L, 2);
		int width = (int)LuaScriptMgr.GetNumber(L, 3);
		TweenWidth obj = TweenWidth.Begin(widget, duration, width);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStartToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenWidth tweenWidth = (TweenWidth)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenWidth");
		tweenWidth.SetStartToCurrentValue();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetEndToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenWidth tweenWidth = (TweenWidth)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenWidth");
		tweenWidth.SetEndToCurrentValue();
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
