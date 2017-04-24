using com.tencent.pandora;
using System;

public class Lua_TweenWidth : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth o = new TweenWidth();
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
	public static int SetStartToCurrentValue(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			tweenWidth.SetStartToCurrentValue();
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
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			tweenWidth.SetEndToCurrentValue();
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
	public static int Begin_s(IntPtr l)
	{
		int result;
		try
		{
			UIWidget widget;
			LuaObject.checkType<UIWidget>(l, 1, out widget);
			float duration;
			LuaObject.checkType(l, 2, out duration);
			int width;
			LuaObject.checkType(l, 3, out width);
			TweenWidth o = TweenWidth.Begin(widget, duration, width);
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
	public static int get_from(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenWidth.from);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_from(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			int from;
			LuaObject.checkType(l, 2, out from);
			tweenWidth.from = from;
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
	public static int get_to(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenWidth.to);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_to(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			int to;
			LuaObject.checkType(l, 2, out to);
			tweenWidth.to = to;
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
	public static int get_updateTable(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenWidth.updateTable);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_updateTable(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			bool updateTable;
			LuaObject.checkType(l, 2, out updateTable);
			tweenWidth.updateTable = updateTable;
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
	public static int get_cachedWidget(IntPtr l)
	{
		int result;
		try
		{
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenWidth.cachedWidget);
			result = 2;
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
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenWidth.value);
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
			TweenWidth tweenWidth = (TweenWidth)LuaObject.checkSelf(l);
			int value;
			LuaObject.checkType(l, 2, out value);
			tweenWidth.value = value;
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
		LuaObject.getTypeTable(l, "TweenWidth");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenWidth.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenWidth.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenWidth.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenWidth.get_from), new LuaCSFunction(Lua_TweenWidth.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenWidth.get_to), new LuaCSFunction(Lua_TweenWidth.set_to), true);
		LuaObject.addMember(l, "updateTable", new LuaCSFunction(Lua_TweenWidth.get_updateTable), new LuaCSFunction(Lua_TweenWidth.set_updateTable), true);
		LuaObject.addMember(l, "cachedWidget", new LuaCSFunction(Lua_TweenWidth.get_cachedWidget), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenWidth.get_value), new LuaCSFunction(Lua_TweenWidth.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenWidth.constructor), typeof(TweenWidth), typeof(UITweener));
	}
}
