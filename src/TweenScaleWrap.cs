using LuaInterface;
using System;
using UnityEngine;

public class TweenScaleWrap
{
	private static Type classType = typeof(TweenScale);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Begin", new LuaCSFunction(TweenScaleWrap.Begin)),
			new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenScaleWrap.SetStartToCurrentValue)),
			new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenScaleWrap.SetEndToCurrentValue)),
			new LuaMethod("New", new LuaCSFunction(TweenScaleWrap._CreateTweenScale)),
			new LuaMethod("GetClassType", new LuaCSFunction(TweenScaleWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(TweenScaleWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("from", new LuaCSFunction(TweenScaleWrap.get_from), new LuaCSFunction(TweenScaleWrap.set_from)),
			new LuaField("to", new LuaCSFunction(TweenScaleWrap.get_to), new LuaCSFunction(TweenScaleWrap.set_to)),
			new LuaField("updateTable", new LuaCSFunction(TweenScaleWrap.get_updateTable), new LuaCSFunction(TweenScaleWrap.set_updateTable)),
			new LuaField("cachedTransform", new LuaCSFunction(TweenScaleWrap.get_cachedTransform), null),
			new LuaField("value", new LuaCSFunction(TweenScaleWrap.get_value), new LuaCSFunction(TweenScaleWrap.set_value))
		};
		LuaScriptMgr.RegisterLib(L, "TweenScale", typeof(TweenScale), regs, fields, typeof(UITweener));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTweenScale(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TweenScale class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, TweenScaleWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		LuaScriptMgr.Push(L, tweenScale.from);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		LuaScriptMgr.Push(L, tweenScale.to);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateTable(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		LuaScriptMgr.Push(L, tweenScale.updateTable);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedTransform on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenScale.cachedTransform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		LuaScriptMgr.Push(L, tweenScale.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		tweenScale.from = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		tweenScale.to = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateTable(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		tweenScale.updateTable = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenScale tweenScale = (TweenScale)luaObject;
		if (tweenScale == null)
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
		tweenScale.value = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		float duration = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector3 vector = LuaScriptMgr.GetVector3(L, 3);
		TweenScale obj = TweenScale.Begin(go, duration, vector);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStartToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenScale tweenScale = (TweenScale)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenScale");
		tweenScale.SetStartToCurrentValue();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetEndToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenScale tweenScale = (TweenScale)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenScale");
		tweenScale.SetEndToCurrentValue();
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
