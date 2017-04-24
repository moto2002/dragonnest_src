using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIButtonColor : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor o = new UIButtonColor();
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
	public static int SetState(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			UIButtonColor.State state;
			LuaObject.checkEnum<UIButtonColor.State>(l, 2, out state);
			bool instant;
			LuaObject.checkType(l, 3, out instant);
			uIButtonColor.SetState(state, instant);
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
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.tweenTarget);
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
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			GameObject tweenTarget;
			LuaObject.checkType<GameObject>(l, 2, out tweenTarget);
			uIButtonColor.tweenTarget = tweenTarget;
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
	public static int get_hover(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.hover);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_hover(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			Color hover;
			LuaObject.checkType(l, 2, out hover);
			uIButtonColor.hover = hover;
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
	public static int get_pressed(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.pressed);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pressed(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			Color pressed;
			LuaObject.checkType(l, 2, out pressed);
			uIButtonColor.pressed = pressed;
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
	public static int get_disabledColor(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.disabledColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_disabledColor(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			Color disabledColor;
			LuaObject.checkType(l, 2, out disabledColor);
			uIButtonColor.disabledColor = disabledColor;
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
	public static int get_changeStateSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.changeStateSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_changeStateSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			bool changeStateSprite;
			LuaObject.checkType(l, 2, out changeStateSprite);
			uIButtonColor.changeStateSprite = changeStateSprite;
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
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.duration);
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
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			float duration;
			LuaObject.checkType(l, 2, out duration);
			uIButtonColor.duration = duration;
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
	public static int get_state(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIButtonColor.state);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_state(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			UIButtonColor.State state;
			LuaObject.checkEnum<UIButtonColor.State>(l, 2, out state);
			uIButtonColor.state = state;
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
	public static int get_defaultColor(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.defaultColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_defaultColor(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			Color defaultColor;
			LuaObject.checkType(l, 2, out defaultColor);
			uIButtonColor.defaultColor = defaultColor;
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
	public static int get_isEnabled(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButtonColor.isEnabled);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_isEnabled(IntPtr l)
	{
		int result;
		try
		{
			UIButtonColor uIButtonColor = (UIButtonColor)LuaObject.checkSelf(l);
			bool isEnabled;
			LuaObject.checkType(l, 2, out isEnabled);
			uIButtonColor.isEnabled = isEnabled;
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
		LuaObject.getTypeTable(l, "UIButtonColor");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIButtonColor.SetState));
		LuaObject.addMember(l, "tweenTarget", new LuaCSFunction(Lua_UIButtonColor.get_tweenTarget), new LuaCSFunction(Lua_UIButtonColor.set_tweenTarget), true);
		LuaObject.addMember(l, "hover", new LuaCSFunction(Lua_UIButtonColor.get_hover), new LuaCSFunction(Lua_UIButtonColor.set_hover), true);
		LuaObject.addMember(l, "pressed", new LuaCSFunction(Lua_UIButtonColor.get_pressed), new LuaCSFunction(Lua_UIButtonColor.set_pressed), true);
		LuaObject.addMember(l, "disabledColor", new LuaCSFunction(Lua_UIButtonColor.get_disabledColor), new LuaCSFunction(Lua_UIButtonColor.set_disabledColor), true);
		LuaObject.addMember(l, "changeStateSprite", new LuaCSFunction(Lua_UIButtonColor.get_changeStateSprite), new LuaCSFunction(Lua_UIButtonColor.set_changeStateSprite), true);
		LuaObject.addMember(l, "duration", new LuaCSFunction(Lua_UIButtonColor.get_duration), new LuaCSFunction(Lua_UIButtonColor.set_duration), true);
		LuaObject.addMember(l, "state", new LuaCSFunction(Lua_UIButtonColor.get_state), new LuaCSFunction(Lua_UIButtonColor.set_state), true);
		LuaObject.addMember(l, "defaultColor", new LuaCSFunction(Lua_UIButtonColor.get_defaultColor), new LuaCSFunction(Lua_UIButtonColor.set_defaultColor), true);
		LuaObject.addMember(l, "isEnabled", new LuaCSFunction(Lua_UIButtonColor.get_isEnabled), new LuaCSFunction(Lua_UIButtonColor.set_isEnabled), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIButtonColor.constructor), typeof(UIButtonColor), typeof(UIWidgetContainer));
	}
}
