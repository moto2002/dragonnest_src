using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIButton : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIButton o = new UIButton();
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
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			UIButtonColor.State state;
			LuaObject.checkEnum<UIButtonColor.State>(l, 2, out state);
			bool immediate;
			LuaObject.checkType(l, 3, out immediate);
			uIButton.SetState(state, immediate);
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
			LuaObject.pushValue(l, UIButton.current);
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
			UIButton current;
			LuaObject.checkType<UIButton>(l, 2, out current);
			UIButton.current = current;
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
	public static int get_dragHighlight(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.dragHighlight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_dragHighlight(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			bool dragHighlight;
			LuaObject.checkType(l, 2, out dragHighlight);
			uIButton.dragHighlight = dragHighlight;
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
	public static int get_hoverSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.hoverSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_hoverSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			string hoverSprite;
			LuaObject.checkType(l, 2, out hoverSprite);
			uIButton.hoverSprite = hoverSprite;
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
	public static int get_pressedSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.pressedSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pressedSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			string pressedSprite;
			LuaObject.checkType(l, 2, out pressedSprite);
			uIButton.pressedSprite = pressedSprite;
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
	public static int get_disabledSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.disabledSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_disabledSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			string disabledSprite;
			LuaObject.checkType(l, 2, out disabledSprite);
			uIButton.disabledSprite = disabledSprite;
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
	public static int get_pixelSnap(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.pixelSnap);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pixelSnap(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			bool pixelSnap;
			LuaObject.checkType(l, 2, out pixelSnap);
			uIButton.pixelSnap = pixelSnap;
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
	public static int get_onClick(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.onClick);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onClick(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			List<EventDelegate> onClick;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onClick);
			uIButton.onClick = onClick;
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
	public static int get_cacheCol(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.cacheCol);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cacheCol(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			Collider cacheCol;
			LuaObject.checkType<Collider>(l, 2, out cacheCol);
			uIButton.cacheCol = cacheCol;
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
	public static int get_cacheC2d(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.cacheC2d);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cacheC2d(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			Collider2D cacheC2d;
			LuaObject.checkType<Collider2D>(l, 2, out cacheC2d);
			uIButton.cacheC2d = cacheC2d;
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
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.isEnabled);
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
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			bool isEnabled;
			LuaObject.checkType(l, 2, out isEnabled);
			uIButton.isEnabled = isEnabled;
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
	public static int get_normalSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIButton.normalSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_normalSprite(IntPtr l)
	{
		int result;
		try
		{
			UIButton uIButton = (UIButton)LuaObject.checkSelf(l);
			string normalSprite;
			LuaObject.checkType(l, 2, out normalSprite);
			uIButton.normalSprite = normalSprite;
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
		LuaObject.getTypeTable(l, "UIButton");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIButton.SetState));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIButton.get_current), new LuaCSFunction(Lua_UIButton.set_current), false);
		LuaObject.addMember(l, "dragHighlight", new LuaCSFunction(Lua_UIButton.get_dragHighlight), new LuaCSFunction(Lua_UIButton.set_dragHighlight), true);
		LuaObject.addMember(l, "hoverSprite", new LuaCSFunction(Lua_UIButton.get_hoverSprite), new LuaCSFunction(Lua_UIButton.set_hoverSprite), true);
		LuaObject.addMember(l, "pressedSprite", new LuaCSFunction(Lua_UIButton.get_pressedSprite), new LuaCSFunction(Lua_UIButton.set_pressedSprite), true);
		LuaObject.addMember(l, "disabledSprite", new LuaCSFunction(Lua_UIButton.get_disabledSprite), new LuaCSFunction(Lua_UIButton.set_disabledSprite), true);
		LuaObject.addMember(l, "pixelSnap", new LuaCSFunction(Lua_UIButton.get_pixelSnap), new LuaCSFunction(Lua_UIButton.set_pixelSnap), true);
		LuaObject.addMember(l, "onClick", new LuaCSFunction(Lua_UIButton.get_onClick), new LuaCSFunction(Lua_UIButton.set_onClick), true);
		LuaObject.addMember(l, "cacheCol", new LuaCSFunction(Lua_UIButton.get_cacheCol), new LuaCSFunction(Lua_UIButton.set_cacheCol), true);
		LuaObject.addMember(l, "cacheC2d", new LuaCSFunction(Lua_UIButton.get_cacheC2d), new LuaCSFunction(Lua_UIButton.set_cacheC2d), true);
		LuaObject.addMember(l, "isEnabled", new LuaCSFunction(Lua_UIButton.get_isEnabled), new LuaCSFunction(Lua_UIButton.set_isEnabled), true);
		LuaObject.addMember(l, "normalSprite", new LuaCSFunction(Lua_UIButton.get_normalSprite), new LuaCSFunction(Lua_UIButton.set_normalSprite), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIButton.constructor), typeof(UIButton), typeof(UIButtonColor));
	}
}
