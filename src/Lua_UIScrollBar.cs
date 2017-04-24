using com.tencent.pandora;
using System;

public class Lua_UIScrollBar : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIScrollBar o = new UIScrollBar();
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
	public static int ForceUpdate(IntPtr l)
	{
		int result;
		try
		{
			UIScrollBar uIScrollBar = (UIScrollBar)LuaObject.checkSelf(l);
			uIScrollBar.ForceUpdate();
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
	public static int get_barSize(IntPtr l)
	{
		int result;
		try
		{
			UIScrollBar uIScrollBar = (UIScrollBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollBar.barSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_barSize(IntPtr l)
	{
		int result;
		try
		{
			UIScrollBar uIScrollBar = (UIScrollBar)LuaObject.checkSelf(l);
			float barSize;
			LuaObject.checkType(l, 2, out barSize);
			uIScrollBar.barSize = barSize;
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
		LuaObject.getTypeTable(l, "UIScrollBar");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollBar.ForceUpdate));
		LuaObject.addMember(l, "barSize", new LuaCSFunction(Lua_UIScrollBar.get_barSize), new LuaCSFunction(Lua_UIScrollBar.set_barSize), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIScrollBar.constructor), typeof(UIScrollBar), typeof(UISlider));
	}
}
