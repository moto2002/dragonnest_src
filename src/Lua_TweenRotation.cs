using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_TweenRotation : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenRotation o = new TweenRotation();
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			tweenRotation.SetStartToCurrentValue();
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			tweenRotation.SetEndToCurrentValue();
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
			Quaternion rot;
			LuaObject.checkType(l, 3, out rot);
			TweenRotation o = TweenRotation.Begin(go, duration, rot);
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenRotation.from);
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			Vector3 from;
			LuaObject.checkType(l, 2, out from);
			tweenRotation.from = from;
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenRotation.to);
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			Vector3 to;
			LuaObject.checkType(l, 2, out to);
			tweenRotation.to = to;
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
	public static int get_cachedTransform(IntPtr l)
	{
		int result;
		try
		{
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenRotation.cachedTransform);
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenRotation.value);
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
			TweenRotation tweenRotation = (TweenRotation)LuaObject.checkSelf(l);
			Quaternion value;
			LuaObject.checkType(l, 2, out value);
			tweenRotation.value = value;
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
		LuaObject.getTypeTable(l, "TweenRotation");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenRotation.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenRotation.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenRotation.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenRotation.get_from), new LuaCSFunction(Lua_TweenRotation.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenRotation.get_to), new LuaCSFunction(Lua_TweenRotation.set_to), true);
		LuaObject.addMember(l, "cachedTransform", new LuaCSFunction(Lua_TweenRotation.get_cachedTransform), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenRotation.get_value), new LuaCSFunction(Lua_TweenRotation.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenRotation.constructor), typeof(TweenRotation), typeof(UITweener));
	}
}
