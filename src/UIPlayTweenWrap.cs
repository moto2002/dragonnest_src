using AnimationOrTween;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayTweenWrap
{
	private static Type classType = typeof(UIPlayTween);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Play", new LuaCSFunction(UIPlayTweenWrap.Play)),
			new LuaMethod("Reset", new LuaCSFunction(UIPlayTweenWrap.Reset)),
			new LuaMethod("ResetByGroup", new LuaCSFunction(UIPlayTweenWrap.ResetByGroup)),
			new LuaMethod("ResetExceptGroup", new LuaCSFunction(UIPlayTweenWrap.ResetExceptGroup)),
			new LuaMethod("Stop", new LuaCSFunction(UIPlayTweenWrap.Stop)),
			new LuaMethod("StopByGroup", new LuaCSFunction(UIPlayTweenWrap.StopByGroup)),
			new LuaMethod("StopExceptGroup", new LuaCSFunction(UIPlayTweenWrap.StopExceptGroup)),
			new LuaMethod("New", new LuaCSFunction(UIPlayTweenWrap._CreateUIPlayTween)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIPlayTweenWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIPlayTweenWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", new LuaCSFunction(UIPlayTweenWrap.get_current), new LuaCSFunction(UIPlayTweenWrap.set_current)),
			new LuaField("tweenTarget", new LuaCSFunction(UIPlayTweenWrap.get_tweenTarget), new LuaCSFunction(UIPlayTweenWrap.set_tweenTarget)),
			new LuaField("tweenGroup", new LuaCSFunction(UIPlayTweenWrap.get_tweenGroup), new LuaCSFunction(UIPlayTweenWrap.set_tweenGroup)),
			new LuaField("trigger", new LuaCSFunction(UIPlayTweenWrap.get_trigger), new LuaCSFunction(UIPlayTweenWrap.set_trigger)),
			new LuaField("playDirection", new LuaCSFunction(UIPlayTweenWrap.get_playDirection), new LuaCSFunction(UIPlayTweenWrap.set_playDirection)),
			new LuaField("resetOnPlay", new LuaCSFunction(UIPlayTweenWrap.get_resetOnPlay), new LuaCSFunction(UIPlayTweenWrap.set_resetOnPlay)),
			new LuaField("resetIfDisabled", new LuaCSFunction(UIPlayTweenWrap.get_resetIfDisabled), new LuaCSFunction(UIPlayTweenWrap.set_resetIfDisabled)),
			new LuaField("ifDisabledOnPlay", new LuaCSFunction(UIPlayTweenWrap.get_ifDisabledOnPlay), new LuaCSFunction(UIPlayTweenWrap.set_ifDisabledOnPlay)),
			new LuaField("disableWhenFinished", new LuaCSFunction(UIPlayTweenWrap.get_disableWhenFinished), new LuaCSFunction(UIPlayTweenWrap.set_disableWhenFinished)),
			new LuaField("includeChildren", new LuaCSFunction(UIPlayTweenWrap.get_includeChildren), new LuaCSFunction(UIPlayTweenWrap.set_includeChildren)),
			new LuaField("onFinished", new LuaCSFunction(UIPlayTweenWrap.get_onFinished), new LuaCSFunction(UIPlayTweenWrap.set_onFinished)),
			new LuaField("finishCb", new LuaCSFunction(UIPlayTweenWrap.get_finishCb), new LuaCSFunction(UIPlayTweenWrap.set_finishCb)),
			new LuaField("finishEndCB", new LuaCSFunction(UIPlayTweenWrap.get_finishEndCB), new LuaCSFunction(UIPlayTweenWrap.set_finishEndCB))
		};
		LuaScriptMgr.RegisterLib(L, "UIPlayTween", typeof(UIPlayTween), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIPlayTween(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIPlayTween class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIPlayTweenWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIPlayTween.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenTarget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTarget on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.tweenTarget);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenGroup(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
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
		LuaScriptMgr.Push(L, uIPlayTween.tweenGroup);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_trigger(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name trigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index trigger on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.trigger);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playDirection(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playDirection on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.playDirection);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resetOnPlay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetOnPlay on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.resetOnPlay);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resetIfDisabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetIfDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetIfDisabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.resetIfDisabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ifDisabledOnPlay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ifDisabledOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ifDisabledOnPlay on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.ifDisabledOnPlay);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disableWhenFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableWhenFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableWhenFinished on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.disableWhenFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_includeChildren(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name includeChildren");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index includeChildren on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIPlayTween.includeChildren);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
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
		LuaScriptMgr.PushObject(L, uIPlayTween.onFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finishCb(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishCb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishCb on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIPlayTween.finishCb);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finishEndCB(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishEndCB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishEndCB on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIPlayTween.finishEndCB);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UIPlayTween.current = (UIPlayTween)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIPlayTween));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenTarget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTarget on a nil value");
			}
		}
		uIPlayTween.tweenTarget = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenGroup(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
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
		uIPlayTween.tweenGroup = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_trigger(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name trigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index trigger on a nil value");
			}
		}
		uIPlayTween.trigger = (Trigger)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(Trigger)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playDirection(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playDirection on a nil value");
			}
		}
		uIPlayTween.playDirection = (Direction)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(Direction)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resetOnPlay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetOnPlay on a nil value");
			}
		}
		uIPlayTween.resetOnPlay = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resetIfDisabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetIfDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetIfDisabled on a nil value");
			}
		}
		uIPlayTween.resetIfDisabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ifDisabledOnPlay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ifDisabledOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ifDisabledOnPlay on a nil value");
			}
		}
		uIPlayTween.ifDisabledOnPlay = (EnableCondition)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(EnableCondition)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disableWhenFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableWhenFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableWhenFinished on a nil value");
			}
		}
		uIPlayTween.disableWhenFinished = (DisableCondition)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(DisableCondition)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_includeChildren(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name includeChildren");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index includeChildren on a nil value");
			}
		}
		uIPlayTween.includeChildren = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
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
		uIPlayTween.onFinished = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finishCb(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishCb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishCb on a nil value");
			}
		}
		uIPlayTween.finishCb = (EventDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(EventDelegate));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finishEndCB(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)luaObject;
		if (uIPlayTween == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishEndCB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishEndCB on a nil value");
			}
		}
		uIPlayTween.finishEndCB = (EventDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(EventDelegate));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uIPlayTween.Play(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uIPlayTween.Reset(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetByGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		int resetGroup = (int)LuaScriptMgr.GetNumber(L, 3);
		uIPlayTween.ResetByGroup(boolean, resetGroup);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetExceptGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		int exceptGroup = (int)LuaScriptMgr.GetNumber(L, 3);
		uIPlayTween.ResetExceptGroup(boolean, exceptGroup);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		uIPlayTween.Stop();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopByGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		int resetGroup = (int)LuaScriptMgr.GetNumber(L, 2);
		uIPlayTween.StopByGroup(resetGroup);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopExceptGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIPlayTween uIPlayTween = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		int exceptGroup = (int)LuaScriptMgr.GetNumber(L, 2);
		uIPlayTween.StopExceptGroup(exceptGroup);
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
