using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIImageButton : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_target(IntPtr l)
	{
		int result;
		try
		{
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.target);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			UISprite target;
			LuaObject.checkType<UISprite>(l, 2, out target);
			uIImageButton.target = target;
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.normalSprite);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			string normalSprite;
			LuaObject.checkType(l, 2, out normalSprite);
			uIImageButton.normalSprite = normalSprite;
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.hoverSprite);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			string hoverSprite;
			LuaObject.checkType(l, 2, out hoverSprite);
			uIImageButton.hoverSprite = hoverSprite;
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.pressedSprite);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			string pressedSprite;
			LuaObject.checkType(l, 2, out pressedSprite);
			uIImageButton.pressedSprite = pressedSprite;
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.disabledSprite);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			string disabledSprite;
			LuaObject.checkType(l, 2, out disabledSprite);
			uIImageButton.disabledSprite = disabledSprite;
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.pixelSnap);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			bool pixelSnap;
			LuaObject.checkType(l, 2, out pixelSnap);
			uIImageButton.pixelSnap = pixelSnap;
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIImageButton.isEnabled);
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
			UIImageButton uIImageButton = (UIImageButton)LuaObject.checkSelf(l);
			bool isEnabled;
			LuaObject.checkType(l, 2, out isEnabled);
			uIImageButton.isEnabled = isEnabled;
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
		LuaObject.getTypeTable(l, "UIImageButton");
		LuaObject.addMember(l, "target", new LuaCSFunction(Lua_UIImageButton.get_target), new LuaCSFunction(Lua_UIImageButton.set_target), true);
		LuaObject.addMember(l, "normalSprite", new LuaCSFunction(Lua_UIImageButton.get_normalSprite), new LuaCSFunction(Lua_UIImageButton.set_normalSprite), true);
		LuaObject.addMember(l, "hoverSprite", new LuaCSFunction(Lua_UIImageButton.get_hoverSprite), new LuaCSFunction(Lua_UIImageButton.set_hoverSprite), true);
		LuaObject.addMember(l, "pressedSprite", new LuaCSFunction(Lua_UIImageButton.get_pressedSprite), new LuaCSFunction(Lua_UIImageButton.set_pressedSprite), true);
		LuaObject.addMember(l, "disabledSprite", new LuaCSFunction(Lua_UIImageButton.get_disabledSprite), new LuaCSFunction(Lua_UIImageButton.set_disabledSprite), true);
		LuaObject.addMember(l, "pixelSnap", new LuaCSFunction(Lua_UIImageButton.get_pixelSnap), new LuaCSFunction(Lua_UIImageButton.set_pixelSnap), true);
		LuaObject.addMember(l, "isEnabled", new LuaCSFunction(Lua_UIImageButton.get_isEnabled), new LuaCSFunction(Lua_UIImageButton.set_isEnabled), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIImageButton), typeof(MonoBehaviour));
	}
}
