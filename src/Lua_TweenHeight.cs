using com.tencent.pandora;
using System;

public class Lua_TweenHeight : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenHeight o = new TweenHeight();
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			tweenHeight.SetStartToCurrentValue();
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			tweenHeight.SetEndToCurrentValue();
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
			int height;
			LuaObject.checkType(l, 3, out height);
			TweenHeight o = TweenHeight.Begin(widget, duration, height);
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenHeight.from);
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			int from;
			LuaObject.checkType(l, 2, out from);
			tweenHeight.from = from;
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenHeight.to);
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			int to;
			LuaObject.checkType(l, 2, out to);
			tweenHeight.to = to;
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenHeight.updateTable);
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			bool updateTable;
			LuaObject.checkType(l, 2, out updateTable);
			tweenHeight.updateTable = updateTable;
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenHeight.cachedWidget);
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenHeight.value);
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
			TweenHeight tweenHeight = (TweenHeight)LuaObject.checkSelf(l);
			int value;
			LuaObject.checkType(l, 2, out value);
			tweenHeight.value = value;
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
		LuaObject.getTypeTable(l, "TweenHeight");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenHeight.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenHeight.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenHeight.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenHeight.get_from), new LuaCSFunction(Lua_TweenHeight.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenHeight.get_to), new LuaCSFunction(Lua_TweenHeight.set_to), true);
		LuaObject.addMember(l, "updateTable", new LuaCSFunction(Lua_TweenHeight.get_updateTable), new LuaCSFunction(Lua_TweenHeight.set_updateTable), true);
		LuaObject.addMember(l, "cachedWidget", new LuaCSFunction(Lua_TweenHeight.get_cachedWidget), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenHeight.get_value), new LuaCSFunction(Lua_TweenHeight.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenHeight.constructor), typeof(TweenHeight), typeof(UITweener));
	}
}
