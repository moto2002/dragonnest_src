using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Color : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 5)
			{
				float r;
				LuaObject.checkType(l, 2, out r);
				float g;
				LuaObject.checkType(l, 3, out g);
				float b;
				LuaObject.checkType(l, 4, out b);
				float a;
				LuaObject.checkType(l, 5, out a);
				Color o = new Color(r, g, b, a);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				float r2;
				LuaObject.checkType(l, 2, out r2);
				float g2;
				LuaObject.checkType(l, 3, out g2);
				float b2;
				LuaObject.checkType(l, 4, out b2);
				Color o = new Color(r2, g2, b2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				result = LuaObject.error(l, "New object failed.");
			}
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
			Color a;
			LuaObject.checkType(l, 1, out a);
			Color b;
			LuaObject.checkType(l, 2, out b);
			float t;
			LuaObject.checkType(l, 3, out t);
			Color o = Color.Lerp(a, b, t);
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
	public static int op_Addition(IntPtr l)
	{
		int result;
		try
		{
			Color a;
			LuaObject.checkType(l, 1, out a);
			Color b;
			LuaObject.checkType(l, 2, out b);
			Color o = a + b;
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
	public static int op_Subtraction(IntPtr l)
	{
		int result;
		try
		{
			Color a;
			LuaObject.checkType(l, 1, out a);
			Color b;
			LuaObject.checkType(l, 2, out b);
			Color o = a - b;
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
	public static int op_Multiply(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(float), typeof(Color)))
			{
				float b;
				LuaObject.checkType(l, 1, out b);
				Color a;
				LuaObject.checkType(l, 2, out a);
				Color o = b * a;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(Color), typeof(float)))
			{
				Color a2;
				LuaObject.checkType(l, 1, out a2);
				float b2;
				LuaObject.checkType(l, 2, out b2);
				Color o2 = a2 * b2;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(Color), typeof(Color)))
			{
				Color a3;
				LuaObject.checkType(l, 1, out a3);
				Color b3;
				LuaObject.checkType(l, 2, out b3);
				Color o3 = a3 * b3;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o3);
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
	public static int op_Division(IntPtr l)
	{
		int result;
		try
		{
			Color a;
			LuaObject.checkType(l, 1, out a);
			float b;
			LuaObject.checkType(l, 2, out b);
			Color o = a / b;
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
	public static int op_Equality(IntPtr l)
	{
		int result;
		try
		{
			Color lhs;
			LuaObject.checkType(l, 1, out lhs);
			Color rhs;
			LuaObject.checkType(l, 2, out rhs);
			bool b = lhs == rhs;
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int op_Inequality(IntPtr l)
	{
		int result;
		try
		{
			Color lhs;
			LuaObject.checkType(l, 1, out lhs);
			Color rhs;
			LuaObject.checkType(l, 2, out rhs);
			bool b = lhs != rhs;
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
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
			Color color;
			LuaObject.checkType(l, 1, out color);
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
			Color v;
			LuaObject.checkType(l, 1, out v);
			float r;
			LuaObject.checkType(l, 2, out r);
			v.r = r;
			LuaObject.setBack(l, v);
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
			Color color;
			LuaObject.checkType(l, 1, out color);
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
			Color v;
			LuaObject.checkType(l, 1, out v);
			float g;
			LuaObject.checkType(l, 2, out g);
			v.g = g;
			LuaObject.setBack(l, v);
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
			Color color;
			LuaObject.checkType(l, 1, out color);
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
			Color v;
			LuaObject.checkType(l, 1, out v);
			float b;
			LuaObject.checkType(l, 2, out b);
			v.b = b;
			LuaObject.setBack(l, v);
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
			Color color;
			LuaObject.checkType(l, 1, out color);
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
			Color v;
			LuaObject.checkType(l, 1, out v);
			float a;
			LuaObject.checkType(l, 2, out a);
			v.a = a;
			LuaObject.setBack(l, v);
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
	public static int get_red(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.red);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_green(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.green);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_blue(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.blue);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_white(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.white);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_black(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.black);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_yellow(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.yellow);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_cyan(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.cyan);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_magenta(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.magenta);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_gray(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.gray);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_grey(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.grey);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_clear(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Color.clear);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_grayscale(IntPtr l)
	{
		int result;
		try
		{
			Color color;
			LuaObject.checkType(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.grayscale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_linear(IntPtr l)
	{
		int result;
		try
		{
			Color color;
			LuaObject.checkType(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.linear);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_gamma(IntPtr l)
	{
		int result;
		try
		{
			Color color;
			LuaObject.checkType(l, 1, out color);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, color.gamma);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int getItem(IntPtr l)
	{
		int result;
		try
		{
			Color color;
			LuaObject.checkType(l, 1, out color);
			int index;
			LuaObject.checkType(l, 2, out index);
			float o = color[index];
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
	public static int setItem(IntPtr l)
	{
		int result;
		try
		{
			Color color;
			LuaObject.checkType(l, 1, out color);
			int index;
			LuaObject.checkType(l, 2, out index);
			float value;
			LuaObject.checkType(l, 3, out value);
			color[index] = value;
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
		LuaObject.getTypeTable(l, "UnityEngine.Color");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.Lerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.op_Addition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.op_Subtraction));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.op_Multiply));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.op_Division));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.op_Equality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.op_Inequality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Color.setItem));
		LuaObject.addMember(l, "r", new LuaCSFunction(Lua_UnityEngine_Color.get_r), new LuaCSFunction(Lua_UnityEngine_Color.set_r), true);
		LuaObject.addMember(l, "g", new LuaCSFunction(Lua_UnityEngine_Color.get_g), new LuaCSFunction(Lua_UnityEngine_Color.set_g), true);
		LuaObject.addMember(l, "b", new LuaCSFunction(Lua_UnityEngine_Color.get_b), new LuaCSFunction(Lua_UnityEngine_Color.set_b), true);
		LuaObject.addMember(l, "a", new LuaCSFunction(Lua_UnityEngine_Color.get_a), new LuaCSFunction(Lua_UnityEngine_Color.set_a), true);
		LuaObject.addMember(l, "red", new LuaCSFunction(Lua_UnityEngine_Color.get_red), null, false);
		LuaObject.addMember(l, "green", new LuaCSFunction(Lua_UnityEngine_Color.get_green), null, false);
		LuaObject.addMember(l, "blue", new LuaCSFunction(Lua_UnityEngine_Color.get_blue), null, false);
		LuaObject.addMember(l, "white", new LuaCSFunction(Lua_UnityEngine_Color.get_white), null, false);
		LuaObject.addMember(l, "black", new LuaCSFunction(Lua_UnityEngine_Color.get_black), null, false);
		LuaObject.addMember(l, "yellow", new LuaCSFunction(Lua_UnityEngine_Color.get_yellow), null, false);
		LuaObject.addMember(l, "cyan", new LuaCSFunction(Lua_UnityEngine_Color.get_cyan), null, false);
		LuaObject.addMember(l, "magenta", new LuaCSFunction(Lua_UnityEngine_Color.get_magenta), null, false);
		LuaObject.addMember(l, "gray", new LuaCSFunction(Lua_UnityEngine_Color.get_gray), null, false);
		LuaObject.addMember(l, "grey", new LuaCSFunction(Lua_UnityEngine_Color.get_grey), null, false);
		LuaObject.addMember(l, "clear", new LuaCSFunction(Lua_UnityEngine_Color.get_clear), null, false);
		LuaObject.addMember(l, "grayscale", new LuaCSFunction(Lua_UnityEngine_Color.get_grayscale), null, true);
		LuaObject.addMember(l, "linear", new LuaCSFunction(Lua_UnityEngine_Color.get_linear), null, true);
		LuaObject.addMember(l, "gamma", new LuaCSFunction(Lua_UnityEngine_Color.get_gamma), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Color.constructor), typeof(Color), typeof(ValueType));
	}
}
