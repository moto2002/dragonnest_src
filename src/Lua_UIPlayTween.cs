using AnimationOrTween;
using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIPlayTween : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Play(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool forward;
			LuaObject.checkType(l, 2, out forward);
			uIPlayTween.Play(forward);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Reset(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool forward;
			LuaObject.checkType(l, 2, out forward);
			uIPlayTween.Reset(forward);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int ResetByGroup(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool forward;
			LuaObject.checkType(l, 2, out forward);
			int resetGroup;
			LuaObject.checkType(l, 3, out resetGroup);
			uIPlayTween.ResetByGroup(forward, resetGroup);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int ResetExceptGroup(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool forward;
			LuaObject.checkType(l, 2, out forward);
			int exceptGroup;
			LuaObject.checkType(l, 3, out exceptGroup);
			uIPlayTween.ResetExceptGroup(forward, exceptGroup);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Stop(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			uIPlayTween.Stop();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int StopByGroup(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			int resetGroup;
			LuaObject.checkType(l, 2, out resetGroup);
			uIPlayTween.StopByGroup(resetGroup);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int StopExceptGroup(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			int exceptGroup;
			LuaObject.checkType(l, 2, out exceptGroup);
			uIPlayTween.StopExceptGroup(exceptGroup);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_current(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIPlayTween.current);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_current(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween current;
			LuaObject.checkType<UIPlayTween>(l, 2, out current);
			UIPlayTween.current = current;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_tweenTarget(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.tweenTarget);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_tweenTarget(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			GameObject tweenTarget;
			LuaObject.checkType<GameObject>(l, 2, out tweenTarget);
			uIPlayTween.tweenTarget = tweenTarget;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_tweenGroup(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.tweenGroup);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_tweenGroup(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			int tweenGroup;
			LuaObject.checkType(l, 2, out tweenGroup);
			uIPlayTween.tweenGroup = tweenGroup;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_trigger(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayTween.trigger);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_trigger(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			Trigger trigger;
			LuaObject.checkEnum<Trigger>(l, 2, out trigger);
			uIPlayTween.trigger = trigger;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_playDirection(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayTween.playDirection);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_playDirection(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			Direction playDirection;
			LuaObject.checkEnum<Direction>(l, 2, out playDirection);
			uIPlayTween.playDirection = playDirection;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_resetOnPlay(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.resetOnPlay);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_resetOnPlay(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool resetOnPlay;
			LuaObject.checkType(l, 2, out resetOnPlay);
			uIPlayTween.resetOnPlay = resetOnPlay;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_resetIfDisabled(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.resetIfDisabled);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_resetIfDisabled(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool resetIfDisabled;
			LuaObject.checkType(l, 2, out resetIfDisabled);
			uIPlayTween.resetIfDisabled = resetIfDisabled;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_ifDisabledOnPlay(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayTween.ifDisabledOnPlay);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_ifDisabledOnPlay(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			EnableCondition ifDisabledOnPlay;
			LuaObject.checkEnum<EnableCondition>(l, 2, out ifDisabledOnPlay);
			uIPlayTween.ifDisabledOnPlay = ifDisabledOnPlay;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_disableWhenFinished(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayTween.disableWhenFinished);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_disableWhenFinished(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			DisableCondition disableWhenFinished;
			LuaObject.checkEnum<DisableCondition>(l, 2, out disableWhenFinished);
			uIPlayTween.disableWhenFinished = disableWhenFinished;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_includeChildren(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.includeChildren);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_includeChildren(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			bool includeChildren;
			LuaObject.checkType(l, 2, out includeChildren);
			uIPlayTween.includeChildren = includeChildren;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_onFinished(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.onFinished);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onFinished(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			List<EventDelegate> onFinished;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onFinished);
			uIPlayTween.onFinished = onFinished;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_finishCb(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.finishCb);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_finishCb(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			EventDelegate finishCb;
			LuaObject.checkType<EventDelegate>(l, 2, out finishCb);
			uIPlayTween.finishCb = finishCb;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_finishEndCB(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayTween.finishEndCB);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_finishEndCB(IntPtr l)
	{
		int result;
		try
		{
			UIPlayTween uIPlayTween = (UIPlayTween)LuaObject.checkSelf(l);
			EventDelegate finishEndCB;
			LuaObject.checkType<EventDelegate>(l, 2, out finishEndCB);
			uIPlayTween.finishEndCB = finishEndCB;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIPlayTween");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.Play));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.Reset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.ResetByGroup));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.ResetExceptGroup));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.Stop));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.StopByGroup));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayTween.StopExceptGroup));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIPlayTween.get_current), new LuaCSFunction(Lua_UIPlayTween.set_current), false);
		LuaObject.addMember(l, "tweenTarget", new LuaCSFunction(Lua_UIPlayTween.get_tweenTarget), new LuaCSFunction(Lua_UIPlayTween.set_tweenTarget), true);
		LuaObject.addMember(l, "tweenGroup", new LuaCSFunction(Lua_UIPlayTween.get_tweenGroup), new LuaCSFunction(Lua_UIPlayTween.set_tweenGroup), true);
		LuaObject.addMember(l, "trigger", new LuaCSFunction(Lua_UIPlayTween.get_trigger), new LuaCSFunction(Lua_UIPlayTween.set_trigger), true);
		LuaObject.addMember(l, "playDirection", new LuaCSFunction(Lua_UIPlayTween.get_playDirection), new LuaCSFunction(Lua_UIPlayTween.set_playDirection), true);
		LuaObject.addMember(l, "resetOnPlay", new LuaCSFunction(Lua_UIPlayTween.get_resetOnPlay), new LuaCSFunction(Lua_UIPlayTween.set_resetOnPlay), true);
		LuaObject.addMember(l, "resetIfDisabled", new LuaCSFunction(Lua_UIPlayTween.get_resetIfDisabled), new LuaCSFunction(Lua_UIPlayTween.set_resetIfDisabled), true);
		LuaObject.addMember(l, "ifDisabledOnPlay", new LuaCSFunction(Lua_UIPlayTween.get_ifDisabledOnPlay), new LuaCSFunction(Lua_UIPlayTween.set_ifDisabledOnPlay), true);
		LuaObject.addMember(l, "disableWhenFinished", new LuaCSFunction(Lua_UIPlayTween.get_disableWhenFinished), new LuaCSFunction(Lua_UIPlayTween.set_disableWhenFinished), true);
		LuaObject.addMember(l, "includeChildren", new LuaCSFunction(Lua_UIPlayTween.get_includeChildren), new LuaCSFunction(Lua_UIPlayTween.set_includeChildren), true);
		LuaObject.addMember(l, "onFinished", new LuaCSFunction(Lua_UIPlayTween.get_onFinished), new LuaCSFunction(Lua_UIPlayTween.set_onFinished), true);
		LuaObject.addMember(l, "finishCb", new LuaCSFunction(Lua_UIPlayTween.get_finishCb), new LuaCSFunction(Lua_UIPlayTween.set_finishCb), true);
		LuaObject.addMember(l, "finishEndCB", new LuaCSFunction(Lua_UIPlayTween.get_finishEndCB), new LuaCSFunction(Lua_UIPlayTween.set_finishEndCB), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIPlayTween), typeof(MonoBehaviour));
	}
}
