using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIAnchor : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_uiCamera(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAnchor.uiCamera);
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
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			Camera uiCamera;
			LuaObject.checkType<Camera>(l, 2, out uiCamera);
			uIAnchor.uiCamera = uiCamera;
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
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAnchor.container);
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
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			GameObject container;
			LuaObject.checkType<GameObject>(l, 2, out container);
			uIAnchor.container = container;
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
	public static int get_side(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIAnchor.side);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_side(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			UIAnchor.Side side;
			LuaObject.checkEnum<UIAnchor.Side>(l, 2, out side);
			uIAnchor.side = side;
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
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAnchor.runOnlyOnce);
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
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			bool runOnlyOnce;
			LuaObject.checkType(l, 2, out runOnlyOnce);
			uIAnchor.runOnlyOnce = runOnlyOnce;
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
	public static int get_relativeOffset(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAnchor.relativeOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_relativeOffset(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			Vector2 relativeOffset;
			LuaObject.checkType(l, 2, out relativeOffset);
			uIAnchor.relativeOffset = relativeOffset;
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
	public static int get_pixelOffset(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIAnchor.pixelOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pixelOffset(IntPtr l)
	{
		int result;
		try
		{
			UIAnchor uIAnchor = (UIAnchor)LuaObject.checkSelf(l);
			Vector2 pixelOffset;
			LuaObject.checkType(l, 2, out pixelOffset);
			uIAnchor.pixelOffset = pixelOffset;
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
		LuaObject.getTypeTable(l, "UIAnchor");
		LuaObject.addMember(l, "uiCamera", new LuaCSFunction(Lua_UIAnchor.get_uiCamera), new LuaCSFunction(Lua_UIAnchor.set_uiCamera), true);
		LuaObject.addMember(l, "container", new LuaCSFunction(Lua_UIAnchor.get_container), new LuaCSFunction(Lua_UIAnchor.set_container), true);
		LuaObject.addMember(l, "side", new LuaCSFunction(Lua_UIAnchor.get_side), new LuaCSFunction(Lua_UIAnchor.set_side), true);
		LuaObject.addMember(l, "runOnlyOnce", new LuaCSFunction(Lua_UIAnchor.get_runOnlyOnce), new LuaCSFunction(Lua_UIAnchor.set_runOnlyOnce), true);
		LuaObject.addMember(l, "relativeOffset", new LuaCSFunction(Lua_UIAnchor.get_relativeOffset), new LuaCSFunction(Lua_UIAnchor.set_relativeOffset), true);
		LuaObject.addMember(l, "pixelOffset", new LuaCSFunction(Lua_UIAnchor.get_pixelOffset), new LuaCSFunction(Lua_UIAnchor.set_pixelOffset), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIAnchor), typeof(MonoBehaviour));
	}
}
