using LuaInterface;
using System;
using UnityEngine;

public class TweenPositionWrap
{
	private static Type classType = typeof(TweenPosition);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Begin", new LuaCSFunction(TweenPositionWrap.Begin)),
			new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenPositionWrap.SetStartToCurrentValue)),
			new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenPositionWrap.SetEndToCurrentValue)),
			new LuaMethod("New", new LuaCSFunction(TweenPositionWrap._CreateTweenPosition)),
			new LuaMethod("GetClassType", new LuaCSFunction(TweenPositionWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(TweenPositionWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("from", new LuaCSFunction(TweenPositionWrap.get_from), new LuaCSFunction(TweenPositionWrap.set_from)),
			new LuaField("to", new LuaCSFunction(TweenPositionWrap.get_to), new LuaCSFunction(TweenPositionWrap.set_to)),
			new LuaField("nox", new LuaCSFunction(TweenPositionWrap.get_nox), new LuaCSFunction(TweenPositionWrap.set_nox)),
			new LuaField("noy", new LuaCSFunction(TweenPositionWrap.get_noy), new LuaCSFunction(TweenPositionWrap.set_noy)),
			new LuaField("worldSpace", new LuaCSFunction(TweenPositionWrap.get_worldSpace), new LuaCSFunction(TweenPositionWrap.set_worldSpace)),
			new LuaField("cachedTransform", new LuaCSFunction(TweenPositionWrap.get_cachedTransform), null),
			new LuaField("value", new LuaCSFunction(TweenPositionWrap.get_value), new LuaCSFunction(TweenPositionWrap.set_value))
		};
		LuaScriptMgr.RegisterLib(L, "TweenPosition", typeof(TweenPosition), regs, fields, typeof(UITweener));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTweenPosition(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TweenPosition class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, TweenPositionWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		LuaScriptMgr.Push(L, tweenPosition.from);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		LuaScriptMgr.Push(L, tweenPosition.to);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nox(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nox");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nox on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenPosition.nox);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_noy(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name noy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index noy on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenPosition.noy);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldSpace(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldSpace on a nil value");
			}
		}
		LuaScriptMgr.Push(L, tweenPosition.worldSpace);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		LuaScriptMgr.Push(L, tweenPosition.cachedTransform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		LuaScriptMgr.Push(L, tweenPosition.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		tweenPosition.from = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		tweenPosition.to = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_nox(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nox");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nox on a nil value");
			}
		}
		tweenPosition.nox = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_noy(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name noy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index noy on a nil value");
			}
		}
		tweenPosition.noy = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_worldSpace(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldSpace on a nil value");
			}
		}
		tweenPosition.worldSpace = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenPosition tweenPosition = (TweenPosition)luaObject;
		if (tweenPosition == null)
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
		tweenPosition.value = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		float duration = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector3 vector = LuaScriptMgr.GetVector3(L, 3);
		TweenPosition obj = TweenPosition.Begin(go, duration, vector);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStartToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenPosition tweenPosition = (TweenPosition)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenPosition");
		tweenPosition.SetStartToCurrentValue();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetEndToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenPosition tweenPosition = (TweenPosition)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenPosition");
		tweenPosition.SetEndToCurrentValue();
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
