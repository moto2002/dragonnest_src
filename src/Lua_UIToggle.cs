using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIToggle : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIToggle o = new UIToggle();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int ForceSetActive(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			bool state;
			LuaObject.checkType(l, 2, out state);
			uIToggle.ForceSetActive(state);
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
	public static int GetActiveToggle_s(IntPtr l)
	{
		int result;
		try
		{
			int group;
			LuaObject.checkType(l, 1, out group);
			UIToggle activeToggle = UIToggle.GetActiveToggle(group);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, activeToggle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_list(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIToggle.list);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_list(IntPtr l)
	{
		int result;
		try
		{
			BetterList<UIToggle> list;
			LuaObject.checkType<BetterList<UIToggle>>(l, 2, out list);
			UIToggle.list = list;
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
			LuaObject.pushValue(l, UIToggle.current);
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
			UIToggle current;
			LuaObject.checkType<UIToggle>(l, 2, out current);
			UIToggle.current = current;
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
	public static int get_group(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.group);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_group(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			int group;
			LuaObject.checkType(l, 2, out group);
			uIToggle.group = group;
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
	public static int get_activeSprite(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.activeSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_activeSprite(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			UIWidget activeSprite;
			LuaObject.checkType<UIWidget>(l, 2, out activeSprite);
			uIToggle.activeSprite = activeSprite;
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
	public static int get_activeSprite2(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.activeSprite2);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_activeSprite2(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			UIWidget activeSprite;
			LuaObject.checkType<UIWidget>(l, 2, out activeSprite);
			uIToggle.activeSprite2 = activeSprite;
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
	public static int get_activeAnimation(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.activeAnimation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_activeAnimation(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			Animation activeAnimation;
			LuaObject.checkType<Animation>(l, 2, out activeAnimation);
			uIToggle.activeAnimation = activeAnimation;
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
	public static int get_startsActive(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.startsActive);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startsActive(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			bool startsActive;
			LuaObject.checkType(l, 2, out startsActive);
			uIToggle.startsActive = startsActive;
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
	public static int get_instantTween(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.instantTween);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_instantTween(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			bool instantTween;
			LuaObject.checkType(l, 2, out instantTween);
			uIToggle.instantTween = instantTween;
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
	public static int get_optionCanBeNone(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.optionCanBeNone);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_optionCanBeNone(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			bool optionCanBeNone;
			LuaObject.checkType(l, 2, out optionCanBeNone);
			uIToggle.optionCanBeNone = optionCanBeNone;
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
	public static int get_onChange(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.onChange);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onChange(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			List<EventDelegate> onChange;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onChange);
			uIToggle.onChange = onChange;
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
	public static int get_value(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIToggle.value);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_value(IntPtr l)
	{
		int result;
		try
		{
			UIToggle uIToggle = (UIToggle)LuaObject.checkSelf(l);
			bool value;
			LuaObject.checkType(l, 2, out value);
			uIToggle.value = value;
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
		LuaObject.getTypeTable(l, "UIToggle");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIToggle.ForceSetActive));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIToggle.GetActiveToggle_s));
		LuaObject.addMember(l, "list", new LuaCSFunction(Lua_UIToggle.get_list), new LuaCSFunction(Lua_UIToggle.set_list), false);
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIToggle.get_current), new LuaCSFunction(Lua_UIToggle.set_current), false);
		LuaObject.addMember(l, "group", new LuaCSFunction(Lua_UIToggle.get_group), new LuaCSFunction(Lua_UIToggle.set_group), true);
		LuaObject.addMember(l, "activeSprite", new LuaCSFunction(Lua_UIToggle.get_activeSprite), new LuaCSFunction(Lua_UIToggle.set_activeSprite), true);
		LuaObject.addMember(l, "activeSprite2", new LuaCSFunction(Lua_UIToggle.get_activeSprite2), new LuaCSFunction(Lua_UIToggle.set_activeSprite2), true);
		LuaObject.addMember(l, "activeAnimation", new LuaCSFunction(Lua_UIToggle.get_activeAnimation), new LuaCSFunction(Lua_UIToggle.set_activeAnimation), true);
		LuaObject.addMember(l, "startsActive", new LuaCSFunction(Lua_UIToggle.get_startsActive), new LuaCSFunction(Lua_UIToggle.set_startsActive), true);
		LuaObject.addMember(l, "instantTween", new LuaCSFunction(Lua_UIToggle.get_instantTween), new LuaCSFunction(Lua_UIToggle.set_instantTween), true);
		LuaObject.addMember(l, "optionCanBeNone", new LuaCSFunction(Lua_UIToggle.get_optionCanBeNone), new LuaCSFunction(Lua_UIToggle.set_optionCanBeNone), true);
		LuaObject.addMember(l, "onChange", new LuaCSFunction(Lua_UIToggle.get_onChange), new LuaCSFunction(Lua_UIToggle.set_onChange), true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_UIToggle.get_value), new LuaCSFunction(Lua_UIToggle.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIToggle.constructor), typeof(UIToggle), typeof(UIWidgetContainer));
	}
}
