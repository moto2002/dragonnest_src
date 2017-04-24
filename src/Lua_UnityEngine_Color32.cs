using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Color32 : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			byte r;
			LuaObject.checkType(l, 2, out r);
			byte g;
			LuaObject.checkType(l, 3, out g);
			byte b;
			LuaObject.checkType(l, 4, out b);
			byte a;
			LuaObject.checkType(l, 5, out a);
			Color32 c = new Color32(r, g, b, a);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, c);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Lerp_s(IntPtr l)
	{
		int result;
		try
		{
			Color32 a;
			LuaObject.checkValueType<Color32>(l, 1, out a);
			Color32 b;
			LuaObject.checkValueType<Color32>(l, 2, out b);
			float t;
			LuaObject.checkType(l, 3, out t);
			Color32 c = Color32.Lerp(a, b, t);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, c);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_r(IntPtr l)
	{
		int result;
		try
		{
			Color32 color;
			LuaObject.checkValueType<Color32>(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.r);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_r(IntPtr l)
	{
		int result;
		try
		{
			Color32 c;
			LuaObject.checkValueType<Color32>(l, 1, out c);
			byte r;
			LuaObject.checkType(l, 2, out r);
			c.r = r;
			LuaObject.setBack(l, c);
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
	public static int get_g(IntPtr l)
	{
		int result;
		try
		{
			Color32 color;
			LuaObject.checkValueType<Color32>(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.g);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_g(IntPtr l)
	{
		int result;
		try
		{
			Color32 c;
			LuaObject.checkValueType<Color32>(l, 1, out c);
			byte g;
			LuaObject.checkType(l, 2, out g);
			c.g = g;
			LuaObject.setBack(l, c);
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
	public static int get_b(IntPtr l)
	{
		int result;
		try
		{
			Color32 color;
			LuaObject.checkValueType<Color32>(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_b(IntPtr l)
	{
		int result;
		try
		{
			Color32 c;
			LuaObject.checkValueType<Color32>(l, 1, out c);
			byte b;
			LuaObject.checkType(l, 2, out b);
			c.b = b;
			LuaObject.setBack(l, c);
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
	public static int get_a(IntPtr l)
	{
		int result;
		try
		{
			Color32 color;
			LuaObject.checkValueType<Color32>(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.a);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_a(IntPtr l)
	{
		int result;
		try
		{
			Color32 c;
			LuaObject.checkValueType<Color32>(l, 1, out c);
			byte a;
			LuaObject.checkType(l, 2, out a);
			c.a = a;
			LuaObject.setBack(l, c);
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
		LuaObject.getTypeTable(l, "UnityEngine.Color32");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color32.Lerp_s));
		LuaObject.addMember(l, "r", new LuaCSFunction(Lua_UnityEngine_Color32.get_r), new LuaCSFunction(Lua_UnityEngine_Color32.set_r), true);
		LuaObject.addMember(l, "g", new LuaCSFunction(Lua_UnityEngine_Color32.get_g), new LuaCSFunction(Lua_UnityEngine_Color32.set_g), true);
		LuaObject.addMember(l, "b", new LuaCSFunction(Lua_UnityEngine_Color32.get_b), new LuaCSFunction(Lua_UnityEngine_Color32.set_b), true);
		LuaObject.addMember(l, "a", new LuaCSFunction(Lua_UnityEngine_Color32.get_a), new LuaCSFunction(Lua_UnityEngine_Color32.set_a), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Color32.constructor), typeof(Color32), typeof(ValueType));
	}
}
