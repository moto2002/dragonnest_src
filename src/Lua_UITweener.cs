using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UITweener : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetOnFinished(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(EventDelegate)))
			{
				UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
				EventDelegate onFinished;
				LuaObject.checkType<EventDelegate>(l, 2, out onFinished);
				uITweener.SetOnFinished(onFinished);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(EventDelegate.Callback)))
			{
				UITweener uITweener2 = (UITweener)LuaObject.checkSelf(l);
				EventDelegate.Callback onFinished2;
				LuaDelegation.checkDelegate(l, 2, out onFinished2);
				uITweener2.SetOnFinished(onFinished2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int AddOnFinished(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(EventDelegate)))
			{
				UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
				EventDelegate del;
				LuaObject.checkType<EventDelegate>(l, 2, out del);
				uITweener.AddOnFinished(del);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(EventDelegate.Callback)))
			{
				UITweener uITweener2 = (UITweener)LuaObject.checkSelf(l);
				EventDelegate.Callback del2;
				LuaDelegation.checkDelegate(l, 2, out del2);
				uITweener2.AddOnFinished(del2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int RemoveOnFinished(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			EventDelegate del;
			LuaObject.checkType<EventDelegate>(l, 2, out del);
			uITweener.RemoveOnFinished(del);
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
	public static int Sample(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			float factor;
			LuaObject.checkType(l, 2, out factor);
			bool isFinished;
			LuaObject.checkType(l, 3, out isFinished);
			uITweener.Sample(factor, isFinished);
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
	public static int PlayForward(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			uITweener.PlayForward();
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
	public static int PlayReverse(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			uITweener.PlayReverse();
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
	public static int Play(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			bool forward;
			LuaObject.checkType(l, 2, out forward);
			uITweener.Play(forward);
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
	public static int ResetToBeginning(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			bool forward;
			LuaObject.checkType(l, 2, out forward);
			uITweener.ResetToBeginning(forward);
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
	public static int Toggle(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			uITweener.Toggle();
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
	public static int SetStartToCurrentValue(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			uITweener.SetStartToCurrentValue();
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
	public static int SetEndToCurrentValue(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			uITweener.SetEndToCurrentValue();
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
			LuaObject.pushValue(l, UITweener.current);
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
			UITweener current;
			LuaObject.checkType<UITweener>(l, 2, out current);
			UITweener.current = current;
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
	public static int get_method(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uITweener.method);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_method(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			UITweener.Method method;
			LuaObject.checkEnum<UITweener.Method>(l, 2, out method);
			uITweener.method = method;
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
	public static int get_style(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uITweener.style);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_style(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			UITweener.Style style;
			LuaObject.checkEnum<UITweener.Style>(l, 2, out style);
			uITweener.style = style;
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
	public static int get_animationCurve(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.animationCurve);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_animationCurve(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			AnimationCurve animationCurve;
			LuaObject.checkType<AnimationCurve>(l, 2, out animationCurve);
			uITweener.animationCurve = animationCurve;
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
	public static int get_ignoreTimeScale(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.ignoreTimeScale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_ignoreTimeScale(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			bool ignoreTimeScale;
			LuaObject.checkType(l, 2, out ignoreTimeScale);
			uITweener.ignoreTimeScale = ignoreTimeScale;
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
	public static int get_delay(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.delay);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_delay(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			float delay;
			LuaObject.checkType(l, 2, out delay);
			uITweener.delay = delay;
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
	public static int get_duration(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.duration);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_duration(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			float duration;
			LuaObject.checkType(l, 2, out duration);
			uITweener.duration = duration;
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
	public static int get_steeperCurves(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.steeperCurves);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_steeperCurves(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			bool steeperCurves;
			LuaObject.checkType(l, 2, out steeperCurves);
			uITweener.steeperCurves = steeperCurves;
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
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.tweenGroup);
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
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			int tweenGroup;
			LuaObject.checkType(l, 2, out tweenGroup);
			uITweener.tweenGroup = tweenGroup;
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
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.onFinished);
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
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			List<EventDelegate> onFinished;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onFinished);
			uITweener.onFinished = onFinished;
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
	public static int get_eventReceiver(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.eventReceiver);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_eventReceiver(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			GameObject eventReceiver;
			LuaObject.checkType<GameObject>(l, 2, out eventReceiver);
			uITweener.eventReceiver = eventReceiver;
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
	public static int get_callWhenFinished(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.callWhenFinished);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_callWhenFinished(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			string callWhenFinished;
			LuaObject.checkType(l, 2, out callWhenFinished);
			uITweener.callWhenFinished = callWhenFinished;
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
	public static int get_amountPerDelta(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.amountPerDelta);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_tweenFactor(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uITweener.tweenFactor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_tweenFactor(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			float tweenFactor;
			LuaObject.checkType(l, 2, out tweenFactor);
			uITweener.tweenFactor = tweenFactor;
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
	public static int get_direction(IntPtr l)
	{
		int result;
		try
		{
			UITweener uITweener = (UITweener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uITweener.direction);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UITweener");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.SetOnFinished));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.AddOnFinished));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.RemoveOnFinished));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.Sample));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.PlayForward));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.PlayReverse));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.Play));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.ResetToBeginning));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.Toggle));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UITweener.SetEndToCurrentValue));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UITweener.get_current), new LuaCSFunction(Lua_UITweener.set_current), false);
		LuaObject.addMember(l, "method", new LuaCSFunction(Lua_UITweener.get_method), new LuaCSFunction(Lua_UITweener.set_method), true);
		LuaObject.addMember(l, "style", new LuaCSFunction(Lua_UITweener.get_style), new LuaCSFunction(Lua_UITweener.set_style), true);
		LuaObject.addMember(l, "animationCurve", new LuaCSFunction(Lua_UITweener.get_animationCurve), new LuaCSFunction(Lua_UITweener.set_animationCurve), true);
		LuaObject.addMember(l, "ignoreTimeScale", new LuaCSFunction(Lua_UITweener.get_ignoreTimeScale), new LuaCSFunction(Lua_UITweener.set_ignoreTimeScale), true);
		LuaObject.addMember(l, "delay", new LuaCSFunction(Lua_UITweener.get_delay), new LuaCSFunction(Lua_UITweener.set_delay), true);
		LuaObject.addMember(l, "duration", new LuaCSFunction(Lua_UITweener.get_duration), new LuaCSFunction(Lua_UITweener.set_duration), true);
		LuaObject.addMember(l, "steeperCurves", new LuaCSFunction(Lua_UITweener.get_steeperCurves), new LuaCSFunction(Lua_UITweener.set_steeperCurves), true);
		LuaObject.addMember(l, "tweenGroup", new LuaCSFunction(Lua_UITweener.get_tweenGroup), new LuaCSFunction(Lua_UITweener.set_tweenGroup), true);
		LuaObject.addMember(l, "onFinished", new LuaCSFunction(Lua_UITweener.get_onFinished), new LuaCSFunction(Lua_UITweener.set_onFinished), true);
		LuaObject.addMember(l, "eventReceiver", new LuaCSFunction(Lua_UITweener.get_eventReceiver), new LuaCSFunction(Lua_UITweener.set_eventReceiver), true);
		LuaObject.addMember(l, "callWhenFinished", new LuaCSFunction(Lua_UITweener.get_callWhenFinished), new LuaCSFunction(Lua_UITweener.set_callWhenFinished), true);
		LuaObject.addMember(l, "amountPerDelta", new LuaCSFunction(Lua_UITweener.get_amountPerDelta), null, true);
		LuaObject.addMember(l, "tweenFactor", new LuaCSFunction(Lua_UITweener.get_tweenFactor), new LuaCSFunction(Lua_UITweener.set_tweenFactor), true);
		LuaObject.addMember(l, "direction", new LuaCSFunction(Lua_UITweener.get_direction), null, true);
		LuaObject.createTypeMetatable(l, null, typeof(UITweener), typeof(MonoBehaviour));
	}
}
