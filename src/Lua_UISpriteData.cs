using com.tencent.pandora;
using System;

public class Lua_UISpriteData : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData o = new UISpriteData();
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
	public static int SetRect(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int x;
			LuaObject.checkType(l, 2, out x);
			int y;
			LuaObject.checkType(l, 3, out y);
			int width;
			LuaObject.checkType(l, 4, out width);
			int height;
			LuaObject.checkType(l, 5, out height);
			uISpriteData.SetRect(x, y, width, height);
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
	public static int SetPadding(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int left;
			LuaObject.checkType(l, 2, out left);
			int bottom;
			LuaObject.checkType(l, 3, out bottom);
			int right;
			LuaObject.checkType(l, 4, out right);
			int top;
			LuaObject.checkType(l, 5, out top);
			uISpriteData.SetPadding(left, bottom, right, top);
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
	public static int SetBorder(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int left;
			LuaObject.checkType(l, 2, out left);
			int bottom;
			LuaObject.checkType(l, 3, out bottom);
			int right;
			LuaObject.checkType(l, 4, out right);
			int top;
			LuaObject.checkType(l, 5, out top);
			uISpriteData.SetBorder(left, bottom, right, top);
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
	public static int CopyFrom(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			UISpriteData sd;
			LuaObject.checkType<UISpriteData>(l, 2, out sd);
			uISpriteData.CopyFrom(sd);
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
	public static int CopyBorderFrom(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			UISpriteData sd;
			LuaObject.checkType<UISpriteData>(l, 2, out sd);
			uISpriteData.CopyBorderFrom(sd);
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
	public static int get_name(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.name);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_name(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			uISpriteData.name = name;
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
	public static int get_x(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.x);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_x(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int x;
			LuaObject.checkType(l, 2, out x);
			uISpriteData.x = x;
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
	public static int get_y(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.y);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_y(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int y;
			LuaObject.checkType(l, 2, out y);
			uISpriteData.y = y;
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
	public static int get_width(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.width);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_width(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int width;
			LuaObject.checkType(l, 2, out width);
			uISpriteData.width = width;
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
	public static int get_height(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.height);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_height(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int height;
			LuaObject.checkType(l, 2, out height);
			uISpriteData.height = height;
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
	public static int get_borderLeft(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.borderLeft);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_borderLeft(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int borderLeft;
			LuaObject.checkType(l, 2, out borderLeft);
			uISpriteData.borderLeft = borderLeft;
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
	public static int get_borderRight(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.borderRight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_borderRight(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int borderRight;
			LuaObject.checkType(l, 2, out borderRight);
			uISpriteData.borderRight = borderRight;
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
	public static int get_borderTop(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.borderTop);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_borderTop(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int borderTop;
			LuaObject.checkType(l, 2, out borderTop);
			uISpriteData.borderTop = borderTop;
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
	public static int get_borderBottom(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.borderBottom);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_borderBottom(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int borderBottom;
			LuaObject.checkType(l, 2, out borderBottom);
			uISpriteData.borderBottom = borderBottom;
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
	public static int get_paddingLeft(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.paddingLeft);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_paddingLeft(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int paddingLeft;
			LuaObject.checkType(l, 2, out paddingLeft);
			uISpriteData.paddingLeft = paddingLeft;
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
	public static int get_paddingRight(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.paddingRight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_paddingRight(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int paddingRight;
			LuaObject.checkType(l, 2, out paddingRight);
			uISpriteData.paddingRight = paddingRight;
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
	public static int get_paddingTop(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.paddingTop);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_paddingTop(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int paddingTop;
			LuaObject.checkType(l, 2, out paddingTop);
			uISpriteData.paddingTop = paddingTop;
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
	public static int get_paddingBottom(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.paddingBottom);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_paddingBottom(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			int paddingBottom;
			LuaObject.checkType(l, 2, out paddingBottom);
			uISpriteData.paddingBottom = paddingBottom;
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
	public static int get_hasBorder(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.hasBorder);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hasPadding(IntPtr l)
	{
		int result;
		try
		{
			UISpriteData uISpriteData = (UISpriteData)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteData.hasPadding);
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
		LuaObject.getTypeTable(l, "UISpriteData");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteData.SetRect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteData.SetPadding));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteData.SetBorder));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteData.CopyFrom));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteData.CopyBorderFrom));
		LuaObject.addMember(l, "name", new LuaCSFunction(Lua_UISpriteData.get_name), new LuaCSFunction(Lua_UISpriteData.set_name), true);
		LuaObject.addMember(l, "x", new LuaCSFunction(Lua_UISpriteData.get_x), new LuaCSFunction(Lua_UISpriteData.set_x), true);
		LuaObject.addMember(l, "y", new LuaCSFunction(Lua_UISpriteData.get_y), new LuaCSFunction(Lua_UISpriteData.set_y), true);
		LuaObject.addMember(l, "width", new LuaCSFunction(Lua_UISpriteData.get_width), new LuaCSFunction(Lua_UISpriteData.set_width), true);
		LuaObject.addMember(l, "height", new LuaCSFunction(Lua_UISpriteData.get_height), new LuaCSFunction(Lua_UISpriteData.set_height), true);
		LuaObject.addMember(l, "borderLeft", new LuaCSFunction(Lua_UISpriteData.get_borderLeft), new LuaCSFunction(Lua_UISpriteData.set_borderLeft), true);
		LuaObject.addMember(l, "borderRight", new LuaCSFunction(Lua_UISpriteData.get_borderRight), new LuaCSFunction(Lua_UISpriteData.set_borderRight), true);
		LuaObject.addMember(l, "borderTop", new LuaCSFunction(Lua_UISpriteData.get_borderTop), new LuaCSFunction(Lua_UISpriteData.set_borderTop), true);
		LuaObject.addMember(l, "borderBottom", new LuaCSFunction(Lua_UISpriteData.get_borderBottom), new LuaCSFunction(Lua_UISpriteData.set_borderBottom), true);
		LuaObject.addMember(l, "paddingLeft", new LuaCSFunction(Lua_UISpriteData.get_paddingLeft), new LuaCSFunction(Lua_UISpriteData.set_paddingLeft), true);
		LuaObject.addMember(l, "paddingRight", new LuaCSFunction(Lua_UISpriteData.get_paddingRight), new LuaCSFunction(Lua_UISpriteData.set_paddingRight), true);
		LuaObject.addMember(l, "paddingTop", new LuaCSFunction(Lua_UISpriteData.get_paddingTop), new LuaCSFunction(Lua_UISpriteData.set_paddingTop), true);
		LuaObject.addMember(l, "paddingBottom", new LuaCSFunction(Lua_UISpriteData.get_paddingBottom), new LuaCSFunction(Lua_UISpriteData.set_paddingBottom), true);
		LuaObject.addMember(l, "hasBorder", new LuaCSFunction(Lua_UISpriteData.get_hasBorder), null, true);
		LuaObject.addMember(l, "hasPadding", new LuaCSFunction(Lua_UISpriteData.get_hasPadding), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UISpriteData.constructor), typeof(UISpriteData));
	}
}
