using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_TweenAlpha : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenAlpha o = new TweenAlpha();
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			tweenAlpha.SetStartToCurrentValue();
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			tweenAlpha.SetEndToCurrentValue();
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
			float alpha;
			LuaObject.checkType(l, 3, out alpha);
			TweenAlpha o = TweenAlpha.Begin(go, duration, alpha);
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenAlpha.from);
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			float from;
			LuaObject.checkType(l, 2, out from);
			tweenAlpha.from = from;
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenAlpha.to);
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			float to;
			LuaObject.checkType(l, 2, out to);
			tweenAlpha.to = to;
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
	public static int get_cachedRect(IntPtr l)
	{
		int result;
		try
		{
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenAlpha.cachedRect);
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenAlpha.value);
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
			TweenAlpha tweenAlpha = (TweenAlpha)LuaObject.checkSelf(l);
			float value;
			LuaObject.checkType(l, 2, out value);
			tweenAlpha.value = value;
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
		LuaObject.getTypeTable(l, "TweenAlpha");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenAlpha.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenAlpha.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenAlpha.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenAlpha.get_from), new LuaCSFunction(Lua_TweenAlpha.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenAlpha.get_to), new LuaCSFunction(Lua_TweenAlpha.set_to), true);
		LuaObject.addMember(l, "cachedRect", new LuaCSFunction(Lua_TweenAlpha.get_cachedRect), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenAlpha.get_value), new LuaCSFunction(Lua_TweenAlpha.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenAlpha.constructor), typeof(TweenAlpha), typeof(UITweener));
	}
}
