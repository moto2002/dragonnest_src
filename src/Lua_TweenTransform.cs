using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_TweenTransform : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			TweenTransform o = new TweenTransform();
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
	public static int Begin_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 3)
			{
				GameObject go;
				LuaObject.checkType<GameObject>(l, 1, out go);
				float duration;
				LuaObject.checkType(l, 2, out duration);
				Transform to;
				LuaObject.checkType<Transform>(l, 3, out to);
				TweenTransform o = TweenTransform.Begin(go, duration, to);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				GameObject go2;
				LuaObject.checkType<GameObject>(l, 1, out go2);
				float duration2;
				LuaObject.checkType(l, 2, out duration2);
				Transform from;
				LuaObject.checkType<Transform>(l, 3, out from);
				Transform to2;
				LuaObject.checkType<Transform>(l, 4, out to2);
				TweenTransform o2 = TweenTransform.Begin(go2, duration2, from, to2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
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
			TweenTransform tweenTransform = (TweenTransform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenTransform.from);
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
			TweenTransform tweenTransform = (TweenTransform)LuaObject.checkSelf(l);
			Transform from;
			LuaObject.checkType<Transform>(l, 2, out from);
			tweenTransform.from = from;
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
			TweenTransform tweenTransform = (TweenTransform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenTransform.to);
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
			TweenTransform tweenTransform = (TweenTransform)LuaObject.checkSelf(l);
			Transform to;
			LuaObject.checkType<Transform>(l, 2, out to);
			tweenTransform.to = to;
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
	public static int get_parentWhenFinished(IntPtr l)
	{
		int result;
		try
		{
			TweenTransform tweenTransform = (TweenTransform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, tweenTransform.parentWhenFinished);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_parentWhenFinished(IntPtr l)
	{
		int result;
		try
		{
			TweenTransform tweenTransform = (TweenTransform)LuaObject.checkSelf(l);
			bool parentWhenFinished;
			LuaObject.checkType(l, 2, out parentWhenFinished);
			tweenTransform.parentWhenFinished = parentWhenFinished;
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
		LuaObject.getTypeTable(l, "TweenTransform");
		LuaObject.addMember(l, new LuaCSFunction(Lua_TweenTransform.Begin_s));
		LuaObject.addMember(l, "from", new LuaCSFunction(Lua_TweenTransform.get_from), new LuaCSFunction(Lua_TweenTransform.set_from), true);
		LuaObject.addMember(l, "to", new LuaCSFunction(Lua_TweenTransform.get_to), new LuaCSFunction(Lua_TweenTransform.set_to), true);
		LuaObject.addMember(l, "parentWhenFinished", new LuaCSFunction(Lua_TweenTransform.get_parentWhenFinished), new LuaCSFunction(Lua_TweenTransform.set_parentWhenFinished), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_TweenTransform.constructor), typeof(TweenTransform), typeof(UITweener));
	}
}
