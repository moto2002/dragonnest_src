using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_TweenPosition : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition o = new TweenPosition();
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			tweenPosition.SetStartToCurrentValue();
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			tweenPosition.SetEndToCurrentValue();
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
			Vector3 pos;
			LuaObject.checkType(l, 3, out pos);
			TweenPosition o = TweenPosition.Begin(go, duration, pos);
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.from);
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			Vector3 from;
			LuaObject.checkType(l, 2, out from);
			tweenPosition.from = from;
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.to);
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			Vector3 to;
			LuaObject.checkType(l, 2, out to);
			tweenPosition.to = to;
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
	public static int get_nox(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.nox);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_nox(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			bool nox;
			LuaObject.checkType(l, 2, out nox);
			tweenPosition.nox = nox;
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
	public static int get_noy(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.noy);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_noy(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			bool noy;
			LuaObject.checkType(l, 2, out noy);
			tweenPosition.noy = noy;
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
	public static int get_worldSpace(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.worldSpace);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_worldSpace(IntPtr l)
	{
		int result;
		try
		{
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			bool worldSpace;
			LuaObject.checkType(l, 2, out worldSpace);
			tweenPosition.worldSpace = worldSpace;
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.cachedTransform);
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenPosition.value);
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
			TweenPosition tweenPosition = (TweenPosition)LuaObject.checkSelf(l);
			Vector3 value;
			LuaObject.checkType(l, 2, out value);
			tweenPosition.value = value;
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
		LuaObject.getTypeTable(l, "TweenPosition");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenPosition.SetStartToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenPosition.SetEndToCurrentValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenPosition.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenPosition.get_from), new LuaCSFunction(Lua_TweenPosition.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenPosition.get_to), new LuaCSFunction(Lua_TweenPosition.set_to), true);
		LuaObject.addMember(l, "nox", new LuaCSFunction(Lua_TweenPosition.get_nox), new LuaCSFunction(Lua_TweenPosition.set_nox), true);
		LuaObject.addMember(l, "noy", new LuaCSFunction(Lua_TweenPosition.get_noy), new LuaCSFunction(Lua_TweenPosition.set_noy), true);
		LuaObject.addMember(l, "worldSpace", new LuaCSFunction(Lua_TweenPosition.get_worldSpace), new LuaCSFunction(Lua_TweenPosition.set_worldSpace), true);
		LuaObject.addMember(l, "cachedTransform", new LuaCSFunction(Lua_TweenPosition.get_cachedTransform), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_TweenPosition.get_value), new LuaCSFunction(Lua_TweenPosition.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenPosition.constructor), typeof(TweenPosition), typeof(UITweener));
	}
}
