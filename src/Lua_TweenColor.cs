using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_TweenColor : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenColor o = new TweenColor();
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			tweenColor.SetStartToCurrentValue();
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			tweenColor.SetEndToCurrentValue();
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
			GameObject go;
			LuaObject.checkType<GameObject>(l, 1, out go);
			float duration;
			LuaObject.checkType(l, 2, out duration);
			Color color;
			LuaObject.checkType(l, 3, out color);
			TweenColor o = TweenColor.Begin(go, duration, color);
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenColor.from);
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			Color from;
			LuaObject.checkType(l, 2, out from);
			tweenColor.from = from;
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenColor.to);
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			Color to;
			LuaObject.checkType(l, 2, out to);
			tweenColor.to = to;
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenColor.value);
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
			TweenColor tweenColor = (TweenColor)LuaObject.checkSelf(l);
			Color value;
			LuaObject.checkType(l, 2, out value);
			tweenColor.value = value;
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
		LuaObject.getTypeTable(l, "TweenColor");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenColor.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenColor.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenColor.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenColor.get_from), new LuaCSFunction(Lua_TweenColor.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenColor.get_to), new LuaCSFunction(Lua_TweenColor.set_to), true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenColor.get_value), new LuaCSFunction(Lua_TweenColor.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenColor.constructor), typeof(TweenColor), typeof(UITweener));
	}
}
