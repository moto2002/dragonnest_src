using LuaInterface;
using System;
using UnityEngine;

public class TweenRotationWrap
{
	private static Type classType = typeof(TweenRotation);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Begin", new LuaCSFunction(TweenRotationWrap.Begin)),
			new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenRotationWrap.SetStartToCurrentValue)),
			new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenRotationWrap.SetEndToCurrentValue)),
			new LuaMethod("New", new LuaCSFunction(TweenRotationWrap._CreateTweenRotation)),
			new LuaMethod("GetClassType", new LuaCSFunction(TweenRotationWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(TweenRotationWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("from", new LuaCSFunction(TweenRotationWrap.get_from), new LuaCSFunction(TweenRotationWrap.set_from)),
			new LuaField("to", new LuaCSFunction(TweenRotationWrap.get_to), new LuaCSFunction(TweenRotationWrap.set_to)),
			new LuaField("cachedTransform", new LuaCSFunction(TweenRotationWrap.get_cachedTransform), null),
			new LuaField("value", new LuaCSFunction(TweenRotationWrap.get_value), new LuaCSFunction(TweenRotationWrap.set_value))
		};
		LuaScriptMgr.RegisterLib(L, "TweenRotation", typeof(TweenRotation), regs, fields, typeof(UITweener));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTweenRotation(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TweenRotation class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, TweenRotationWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		LuaScriptMgr.Push(L, tweenRotation.from);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		LuaScriptMgr.Push(L, tweenRotation.to);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		LuaScriptMgr.Push(L, tweenRotation.cachedTransform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		LuaScriptMgr.Push(L, tweenRotation.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_from(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		tweenRotation.from = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_to(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		tweenRotation.to = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		TweenRotation tweenRotation = (TweenRotation)luaObject;
		if (tweenRotation == null)
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
		tweenRotation.value = LuaScriptMgr.GetQuaternion(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		float duration = (float)LuaScriptMgr.GetNumber(L, 2);
		Quaternion quaternion = LuaScriptMgr.GetQuaternion(L, 3);
		TweenRotation obj = TweenRotation.Begin(go, duration, quaternion);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStartToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenRotation tweenRotation = (TweenRotation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenRotation");
		tweenRotation.SetStartToCurrentValue();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetEndToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TweenRotation tweenRotation = (TweenRotation)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenRotation");
		tweenRotation.SetEndToCurrentValue();
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
