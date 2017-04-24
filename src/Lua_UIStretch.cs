using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIStretch : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_uiCamera(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIStretch.uiCamera);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_uiCamera(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			Camera uiCamera;
			LuaObject.checkType<Camera>(l, 2, out uiCamera);
			uIStretch.uiCamera = uiCamera;
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
	public static int get_container(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIStretch.container);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_container(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			GameObject container;
			LuaObject.checkType<GameObject>(l, 2, out container);
			uIStretch.container = container;
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
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIStretch.style);
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
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			UIStretch.Style style;
			LuaObject.checkEnum<UIStretch.Style>(l, 2, out style);
			uIStretch.style = style;
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
	public static int get_runOnlyOnce(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIStretch.runOnlyOnce);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_runOnlyOnce(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			bool runOnlyOnce;
			LuaObject.checkType(l, 2, out runOnlyOnce);
			uIStretch.runOnlyOnce = runOnlyOnce;
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
	public static int get_relativeSize(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIStretch.relativeSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_relativeSize(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			Vector2 relativeSize;
			LuaObject.checkType(l, 2, out relativeSize);
			uIStretch.relativeSize = relativeSize;
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
	public static int get_initialSize(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIStretch.initialSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_initialSize(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			Vector2 initialSize;
			LuaObject.checkType(l, 2, out initialSize);
			uIStretch.initialSize = initialSize;
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
	public static int get_borderPadding(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIStretch.borderPadding);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_borderPadding(IntPtr l)
	{
		int result;
		try
		{
			UIStretch uIStretch = (UIStretch)LuaObject.checkSelf(l);
			Vector2 borderPadding;
			LuaObject.checkType(l, 2, out borderPadding);
			uIStretch.borderPadding = borderPadding;
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
		LuaObject.getTypeTable(l, "UIStretch");
		LuaObject.addMember(l, "uiCamera", new LuaCSFunction(Lua_UIStretch.get_uiCamera), new LuaCSFunction(Lua_UIStretch.set_uiCamera), true);
		LuaObject.addMember(l, "container", new LuaCSFunction(Lua_UIStretch.get_container), new LuaCSFunction(Lua_UIStretch.set_container), true);
		LuaObject.addMember(l, "style", new LuaCSFunction(Lua_UIStretch.get_style), new LuaCSFunction(Lua_UIStretch.set_style), true);
		LuaObject.addMember(l, "runOnlyOnce", new LuaCSFunction(Lua_UIStretch.get_runOnlyOnce), new LuaCSFunction(Lua_UIStretch.set_runOnlyOnce), true);
		LuaObject.addMember(l, "relativeSize", new LuaCSFunction(Lua_UIStretch.get_relativeSize), new LuaCSFunction(Lua_UIStretch.set_relativeSize), true);
		LuaObject.addMember(l, "initialSize", new LuaCSFunction(Lua_UIStretch.get_initialSize), new LuaCSFunction(Lua_UIStretch.set_initialSize), true);
		LuaObject.addMember(l, "borderPadding", new LuaCSFunction(Lua_UIStretch.get_borderPadding), new LuaCSFunction(Lua_UIStretch.set_borderPadding), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIStretch), typeof(MonoBehaviour));
	}
}
