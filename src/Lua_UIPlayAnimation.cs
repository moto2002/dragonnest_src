using AnimationOrTween;
using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIPlayAnimation : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Play(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
				bool forward;
				LuaObject.checkType(l, 2, out forward);
				uIPlayAnimation.Play(forward);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 3)
			{
				UIPlayAnimation uIPlayAnimation2 = (UIPlayAnimation)LuaObject.checkSelf(l);
				bool forward2;
				LuaObject.checkType(l, 2, out forward2);
				bool onlyIfDifferent;
				LuaObject.checkType(l, 3, out onlyIfDifferent);
				uIPlayAnimation2.Play(forward2, onlyIfDifferent);
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
	public static int get_current(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIPlayAnimation.current);
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
			UIPlayAnimation current;
			LuaObject.checkType<UIPlayAnimation>(l, 2, out current);
			UIPlayAnimation.current = current;
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
	public static int get_target(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayAnimation.target);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_target(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			Animation target;
			LuaObject.checkType<Animation>(l, 2, out target);
			uIPlayAnimation.target = target;
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
	public static int get_animator(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayAnimation.animator);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_animator(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			Animator animator;
			LuaObject.checkType<Animator>(l, 2, out animator);
			uIPlayAnimation.animator = animator;
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
	public static int get_clipName(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayAnimation.clipName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_clipName(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			string clipName;
			LuaObject.checkType(l, 2, out clipName);
			uIPlayAnimation.clipName = clipName;
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayAnimation.trigger);
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			Trigger trigger;
			LuaObject.checkEnum<Trigger>(l, 2, out trigger);
			uIPlayAnimation.trigger = trigger;
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayAnimation.playDirection);
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			Direction playDirection;
			LuaObject.checkEnum<Direction>(l, 2, out playDirection);
			uIPlayAnimation.playDirection = playDirection;
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayAnimation.resetOnPlay);
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			bool resetOnPlay;
			LuaObject.checkType(l, 2, out resetOnPlay);
			uIPlayAnimation.resetOnPlay = resetOnPlay;
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
	public static int get_clearSelection(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayAnimation.clearSelection);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_clearSelection(IntPtr l)
	{
		int result;
		try
		{
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			bool clearSelection;
			LuaObject.checkType(l, 2, out clearSelection);
			uIPlayAnimation.clearSelection = clearSelection;
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayAnimation.ifDisabledOnPlay);
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			EnableCondition ifDisabledOnPlay;
			LuaObject.checkEnum<EnableCondition>(l, 2, out ifDisabledOnPlay);
			uIPlayAnimation.ifDisabledOnPlay = ifDisabledOnPlay;
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlayAnimation.disableWhenFinished);
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			DisableCondition disableWhenFinished;
			LuaObject.checkEnum<DisableCondition>(l, 2, out disableWhenFinished);
			uIPlayAnimation.disableWhenFinished = disableWhenFinished;
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlayAnimation.onFinished);
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
			UIPlayAnimation uIPlayAnimation = (UIPlayAnimation)LuaObject.checkSelf(l);
			List<EventDelegate> onFinished;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onFinished);
			uIPlayAnimation.onFinished = onFinished;
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
		LuaObject.getTypeTable(l, "UIPlayAnimation");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlayAnimation.Play));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIPlayAnimation.get_current), new LuaCSFunction(Lua_UIPlayAnimation.set_current), false);
		LuaObject.addMember(l, "target", new LuaCSFunction(Lua_UIPlayAnimation.get_target), new LuaCSFunction(Lua_UIPlayAnimation.set_target), true);
		LuaObject.addMember(l, "animator", new LuaCSFunction(Lua_UIPlayAnimation.get_animator), new LuaCSFunction(Lua_UIPlayAnimation.set_animator), true);
		LuaObject.addMember(l, "clipName", new LuaCSFunction(Lua_UIPlayAnimation.get_clipName), new LuaCSFunction(Lua_UIPlayAnimation.set_clipName), true);
		LuaObject.addMember(l, "trigger", new LuaCSFunction(Lua_UIPlayAnimation.get_trigger), new LuaCSFunction(Lua_UIPlayAnimation.set_trigger), true);
		LuaObject.addMember(l, "playDirection", new LuaCSFunction(Lua_UIPlayAnimation.get_playDirection), new LuaCSFunction(Lua_UIPlayAnimation.set_playDirection), true);
		LuaObject.addMember(l, "resetOnPlay", new LuaCSFunction(Lua_UIPlayAnimation.get_resetOnPlay), new LuaCSFunction(Lua_UIPlayAnimation.set_resetOnPlay), true);
		LuaObject.addMember(l, "clearSelection", new LuaCSFunction(Lua_UIPlayAnimation.get_clearSelection), new LuaCSFunction(Lua_UIPlayAnimation.set_clearSelection), true);
		LuaObject.addMember(l, "ifDisabledOnPlay", new LuaCSFunction(Lua_UIPlayAnimation.get_ifDisabledOnPlay), new LuaCSFunction(Lua_UIPlayAnimation.set_ifDisabledOnPlay), true);
		LuaObject.addMember(l, "disableWhenFinished", new LuaCSFunction(Lua_UIPlayAnimation.get_disableWhenFinished), new LuaCSFunction(Lua_UIPlayAnimation.set_disableWhenFinished), true);
		LuaObject.addMember(l, "onFinished", new LuaCSFunction(Lua_UIPlayAnimation.get_onFinished), new LuaCSFunction(Lua_UIPlayAnimation.set_onFinished), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIPlayAnimation), typeof(MonoBehaviour));
	}
}
