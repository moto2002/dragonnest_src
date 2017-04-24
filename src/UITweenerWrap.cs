using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UITweenerWrap
{
	private static Type classType = typeof(UITweener);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetOnFinished", new LuaCSFunction(UITweenerWrap.SetOnFinished)),
			new LuaMethod("AddOnFinished", new LuaCSFunction(UITweenerWrap.AddOnFinished)),
			new LuaMethod("RemoveOnFinished", new LuaCSFunction(UITweenerWrap.RemoveOnFinished)),
			new LuaMethod("Sample", new LuaCSFunction(UITweenerWrap.Sample)),
			new LuaMethod("PlayForward", new LuaCSFunction(UITweenerWrap.PlayForward)),
			new LuaMethod("PlayReverse", new LuaCSFunction(UITweenerWrap.PlayReverse)),
			new LuaMethod("Play", new LuaCSFunction(UITweenerWrap.Play)),
			new LuaMethod("ResetToBeginning", new LuaCSFunction(UITweenerWrap.ResetToBeginning)),
			new LuaMethod("Toggle", new LuaCSFunction(UITweenerWrap.Toggle)),
			new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(UITweenerWrap.SetStartToCurrentValue)),
			new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(UITweenerWrap.SetEndToCurrentValue)),
			new LuaMethod("New", new LuaCSFunction(UITweenerWrap._CreateUITweener)),
			new LuaMethod("GetClassType", new LuaCSFunction(UITweenerWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UITweenerWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", new LuaCSFunction(UITweenerWrap.get_current), new LuaCSFunction(UITweenerWrap.set_current)),
			new LuaField("method", new LuaCSFunction(UITweenerWrap.get_method), new LuaCSFunction(UITweenerWrap.set_method)),
			new LuaField("style", new LuaCSFunction(UITweenerWrap.get_style), new LuaCSFunction(UITweenerWrap.set_style)),
			new LuaField("animationCurve", new LuaCSFunction(UITweenerWrap.get_animationCurve), new LuaCSFunction(UITweenerWrap.set_animationCurve)),
			new LuaField("ignoreTimeScale", new LuaCSFunction(UITweenerWrap.get_ignoreTimeScale), new LuaCSFunction(UITweenerWrap.set_ignoreTimeScale)),
			new LuaField("delay", new LuaCSFunction(UITweenerWrap.get_delay), new LuaCSFunction(UITweenerWrap.set_delay)),
			new LuaField("duration", new LuaCSFunction(UITweenerWrap.get_duration), new LuaCSFunction(UITweenerWrap.set_duration)),
			new LuaField("steeperCurves", new LuaCSFunction(UITweenerWrap.get_steeperCurves), new LuaCSFunction(UITweenerWrap.set_steeperCurves)),
			new LuaField("tweenGroup", new LuaCSFunction(UITweenerWrap.get_tweenGroup), new LuaCSFunction(UITweenerWrap.set_tweenGroup)),
			new LuaField("onFinished", new LuaCSFunction(UITweenerWrap.get_onFinished), new LuaCSFunction(UITweenerWrap.set_onFinished)),
			new LuaField("eventReceiver", new LuaCSFunction(UITweenerWrap.get_eventReceiver), new LuaCSFunction(UITweenerWrap.set_eventReceiver)),
			new LuaField("callWhenFinished", new LuaCSFunction(UITweenerWrap.get_callWhenFinished), new LuaCSFunction(UITweenerWrap.set_callWhenFinished)),
			new LuaField("amountPerDelta", new LuaCSFunction(UITweenerWrap.get_amountPerDelta), null),
			new LuaField("tweenFactor", new LuaCSFunction(UITweenerWrap.get_tweenFactor), new LuaCSFunction(UITweenerWrap.set_tweenFactor)),
			new LuaField("direction", new LuaCSFunction(UITweenerWrap.get_direction), null)
		};
		LuaScriptMgr.RegisterLib(L, "UITweener", typeof(UITweener), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUITweener(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UITweener class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UITweenerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UITweener.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_method(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name method");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index method on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.method);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_style(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name style");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index style on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.style);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animationCurve(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animationCurve");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animationCurve on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uITweener.animationCurve);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ignoreTimeScale(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreTimeScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreTimeScale on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.ignoreTimeScale);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_delay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name delay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index delay on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.delay);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_duration(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name duration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.duration);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_steeperCurves(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name steeperCurves");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index steeperCurves on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.steeperCurves);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenGroup(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenGroup");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenGroup on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.tweenGroup);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
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
		LuaScriptMgr.PushObject(L, uITweener.onFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventReceiver(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventReceiver");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventReceiver on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.eventReceiver);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_callWhenFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name callWhenFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index callWhenFinished on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.callWhenFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_amountPerDelta(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name amountPerDelta");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index amountPerDelta on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.amountPerDelta);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenFactor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenFactor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.tweenFactor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_direction(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name direction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index direction on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITweener.direction);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UITweener.current = (UITweener)LuaScriptMgr.GetUnityObject(L, 3, typeof(UITweener));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_method(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name method");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index method on a nil value");
			}
		}
		uITweener.method = (UITweener.Method)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UITweener.Method)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_style(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name style");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index style on a nil value");
			}
		}
		uITweener.style = (UITweener.Style)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UITweener.Style)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animationCurve(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animationCurve");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animationCurve on a nil value");
			}
		}
		uITweener.animationCurve = (AnimationCurve)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationCurve));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ignoreTimeScale(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreTimeScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreTimeScale on a nil value");
			}
		}
		uITweener.ignoreTimeScale = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_delay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name delay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index delay on a nil value");
			}
		}
		uITweener.delay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_duration(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name duration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
			}
		}
		uITweener.duration = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_steeperCurves(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name steeperCurves");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index steeperCurves on a nil value");
			}
		}
		uITweener.steeperCurves = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenGroup(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenGroup");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenGroup on a nil value");
			}
		}
		uITweener.tweenGroup = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
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
		uITweener.onFinished = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventReceiver(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventReceiver");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventReceiver on a nil value");
			}
		}
		uITweener.eventReceiver = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_callWhenFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name callWhenFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index callWhenFinished on a nil value");
			}
		}
		uITweener.callWhenFinished = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenFactor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITweener uITweener = (UITweener)luaObject;
		if (uITweener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenFactor on a nil value");
			}
		}
		uITweener.tweenFactor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetOnFinished(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate)))
		{
			UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
			EventDelegate onFinished = (EventDelegate)LuaScriptMgr.GetLuaObject(L, 2);
			uITweener.SetOnFinished(onFinished);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate.Callback)))
		{
			UITweener uITweener2 = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback onFinished2;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onFinished2 = (EventDelegate.Callback)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				onFinished2 = delegate
				{
					func.Call();
				};
			}
			uITweener2.SetOnFinished(onFinished2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UITweener.SetOnFinished");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddOnFinished(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate)))
		{
			UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
			EventDelegate del = (EventDelegate)LuaScriptMgr.GetLuaObject(L, 2);
			uITweener.AddOnFinished(del);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate.Callback)))
		{
			UITweener uITweener2 = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback del2;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				del2 = (EventDelegate.Callback)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				del2 = delegate
				{
					func.Call();
				};
			}
			uITweener2.AddOnFinished(del2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UITweener.AddOnFinished");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveOnFinished(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		EventDelegate del = (EventDelegate)LuaScriptMgr.GetNetObject(L, 2, typeof(EventDelegate));
		uITweener.RemoveOnFinished(del);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sample(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		float factor = (float)LuaScriptMgr.GetNumber(L, 2);
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		uITweener.Sample(factor, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayForward(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		uITweener.PlayForward();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayReverse(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		uITweener.PlayReverse();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uITweener.Play(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetToBeginning(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uITweener.ResetToBeginning(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Toggle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		uITweener.Toggle();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStartToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		uITweener.SetStartToCurrentValue();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetEndToCurrentValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITweener uITweener = (UITweener)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITweener");
		uITweener.SetEndToCurrentValue();
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
