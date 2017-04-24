using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_TweenScale : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenScale o = new TweenScale();
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			tweenScale.SetStartToCurrentValue();
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			tweenScale.SetEndToCurrentValue();
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
			Vector3 scale;
			LuaObject.checkType(l, 3, out scale);
			TweenScale o = TweenScale.Begin(go, duration, scale);
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenScale.from);
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			Vector3 from;
			LuaObject.checkType(l, 2, out from);
			tweenScale.from = from;
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenScale.to);
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			Vector3 to;
			LuaObject.checkType(l, 2, out to);
			tweenScale.to = to;
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenScale.updateTable);
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			bool updateTable;
			LuaObject.checkType(l, 2, out updateTable);
			tweenScale.updateTable = updateTable;
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenScale.cachedTransform);
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenScale.value);
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
			TweenScale tweenScale = (TweenScale)LuaObject.checkSelf(l);
			Vector3 value;
			LuaObject.checkType(l, 2, out value);
			tweenScale.value = value;
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
		LuaObject.getTypeTable(l, "TweenScale");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenScale.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenScale.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenScale.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenScale.get_from), new LuaCSFunction(Lua_TweenScale.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenScale.get_to), new LuaCSFunction(Lua_TweenScale.set_to), true);
		LuaObject.addMember(l, "updateTable", new LuaCSFunction(Lua_TweenScale.get_updateTable), new LuaCSFunction(Lua_TweenScale.set_updateTable), true);
		LuaObject.addMember(l, "cachedTransform", new LuaCSFunction(Lua_TweenScale.get_cachedTransform), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenScale.get_value), new LuaCSFunction(Lua_TweenScale.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenScale.constructor), typeof(TweenScale), typeof(UITweener));
	}
}
