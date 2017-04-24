using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Vector4 : LuaObject
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
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				float w;
				LuaObject.checkType(l, 5, out w);
				Vector4 o = new Vector4(x, y, z, w);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				float x2;
				LuaObject.checkType(l, 2, out x2);
				float y2;
				LuaObject.checkType(l, 3, out y2);
				float z2;
				LuaObject.checkType(l, 4, out z2);
				Vector4 o = new Vector4(x2, y2, z2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				float x3;
				LuaObject.checkType(l, 2, out x3);
				float y3;
				LuaObject.checkType(l, 3, out y3);
				Vector4 o = new Vector4(x3, y3);
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
	public static int Set(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			float new_x;
			LuaObject.checkType(l, 2, out new_x);
			float new_y;
			LuaObject.checkType(l, 3, out new_y);
			float new_z;
			LuaObject.checkType(l, 4, out new_z);
			float new_w;
			LuaObject.checkType(l, 5, out new_w);
			v.Set(new_x, new_y, new_z, new_w);
			LuaObject.pushValue(l, true);
			LuaObject.setBack(l, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Scale(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			Vector4 scale;
			LuaObject.checkType(l, 2, out scale);
			v.Scale(scale);
			LuaObject.pushValue(l, true);
			LuaObject.setBack(l, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Normalize(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			v.Normalize();
			LuaObject.pushValue(l, true);
			LuaObject.setBack(l, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SqrMagnitude(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			float o = vector.SqrMagnitude();
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
	public static int Lerp_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 from;
			LuaObject.checkType(l, 1, out from);
			Vector4 to;
			LuaObject.checkType(l, 2, out to);
			float t;
			LuaObject.checkType(l, 3, out t);
			Vector4 o = Vector4.Lerp(from, to, t);
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
	public static int MoveTowards_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 current;
			LuaObject.checkType(l, 1, out current);
			Vector4 target;
			LuaObject.checkType(l, 2, out target);
			float maxDistanceDelta;
			LuaObject.checkType(l, 3, out maxDistanceDelta);
			Vector4 o = Vector4.MoveTowards(current, target, maxDistanceDelta);
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
	public static int Scale_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 b;
			LuaObject.checkType(l, 2, out b);
			Vector4 o = Vector4.Scale(a, b);
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
	public static int Normalize_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 o = Vector4.Normalize(a);
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
	public static int Dot_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 b;
			LuaObject.checkType(l, 2, out b);
			float o = Vector4.Dot(a, b);
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
	public static int Project_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 b;
			LuaObject.checkType(l, 2, out b);
			Vector4 o = Vector4.Project(a, b);
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
	public static int Distance_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 b;
			LuaObject.checkType(l, 2, out b);
			float o = Vector4.Distance(a, b);
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
	public static int Magnitude_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			float o = Vector4.Magnitude(a);
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
	public static int SqrMagnitude_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			float o = Vector4.SqrMagnitude(a);
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
	public static int Min_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector4 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector4 o = Vector4.Min(lhs, rhs);
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
	public static int Max_s(IntPtr l)
	{
		int result;
		try
		{
			Vector4 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector4 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector4 o = Vector4.Max(lhs, rhs);
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
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 b;
			LuaObject.checkType(l, 2, out b);
			Vector4 o = a + b;
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
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 b;
			LuaObject.checkType(l, 2, out b);
			Vector4 o = a - b;
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
	public static int op_UnaryNegation(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			Vector4 o = -a;
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
			if (LuaObject.matchType(l, total, 1, typeof(float), typeof(Vector4)))
			{
				float d;
				LuaObject.checkType(l, 1, out d);
				Vector4 a;
				LuaObject.checkType(l, 2, out a);
				Vector4 o = d * a;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(Vector4), typeof(float)))
			{
				Vector4 a2;
				LuaObject.checkType(l, 1, out a2);
				float d2;
				LuaObject.checkType(l, 2, out d2);
				Vector4 o2 = a2 * d2;
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
	public static int op_Division(IntPtr l)
	{
		int result;
		try
		{
			Vector4 a;
			LuaObject.checkType(l, 1, out a);
			float d;
			LuaObject.checkType(l, 2, out d);
			Vector4 o = a / d;
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
			Vector4 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector4 rhs;
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
			Vector4 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector4 rhs;
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
	public static int get_kEpsilon(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, 1E-05f);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_x(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.x);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_x(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			float x;
			LuaObject.checkType(l, 2, out x);
			v.x = x;
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
	public static int get_y(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.y);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_y(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			float y;
			LuaObject.checkType(l, 2, out y);
			v.y = y;
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
	public static int get_z(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.z);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_z(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			float z;
			LuaObject.checkType(l, 2, out z);
			v.z = z;
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
	public static int get_w(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.w);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_w(IntPtr l)
	{
		int result;
		try
		{
			Vector4 v;
			LuaObject.checkType(l, 1, out v);
			float w;
			LuaObject.checkType(l, 2, out w);
			v.w = w;
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
	public static int get_normalized(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.normalized);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_magnitude(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.magnitude);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_sqrMagnitude(IntPtr l)
	{
		int result;
		try
		{
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, vector.sqrMagnitude);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_zero(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector4.zero);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_one(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector4.one);
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
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			int index;
			LuaObject.checkType(l, 2, out index);
			float o = vector[index];
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
			Vector4 vector;
			LuaObject.checkType(l, 1, out vector);
			int index;
			LuaObject.checkType(l, 2, out index);
			float value;
			LuaObject.checkType(l, 3, out value);
			vector[index] = value;
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
		LuaObject.getTypeTable(l, "UnityEngine.Vector4");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Set));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Scale));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Normalize));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.SqrMagnitude));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Lerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.MoveTowards_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Scale_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Normalize_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Dot_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Project_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Distance_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Magnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.SqrMagnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Min_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.Max_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_Addition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_Subtraction));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_UnaryNegation));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_Multiply));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_Division));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_Equality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.op_Inequality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector4.setItem));
		LuaObject.addMember(l, "kEpsilon", new LuaCSFunction(Lua_UnityEngine_Vector4.get_kEpsilon), null, false);
		LuaObject.addMember(l, "x", new LuaCSFunction(Lua_UnityEngine_Vector4.get_x), new LuaCSFunction(Lua_UnityEngine_Vector4.set_x), true);
		LuaObject.addMember(l, "y", new LuaCSFunction(Lua_UnityEngine_Vector4.get_y), new LuaCSFunction(Lua_UnityEngine_Vector4.set_y), true);
		LuaObject.addMember(l, "z", new LuaCSFunction(Lua_UnityEngine_Vector4.get_z), new LuaCSFunction(Lua_UnityEngine_Vector4.set_z), true);
		LuaObject.addMember(l, "w", new LuaCSFunction(Lua_UnityEngine_Vector4.get_w), new LuaCSFunction(Lua_UnityEngine_Vector4.set_w), true);
		LuaObject.addMember(l, "normalized", new LuaCSFunction(Lua_UnityEngine_Vector4.get_normalized), null, true);
		LuaObject.addMember(l, "magnitude", new LuaCSFunction(Lua_UnityEngine_Vector4.get_magnitude), null, true);
		LuaObject.addMember(l, "sqrMagnitude", new LuaCSFunction(Lua_UnityEngine_Vector4.get_sqrMagnitude), null, true);
		LuaObject.addMember(l, "zero", new LuaCSFunction(Lua_UnityEngine_Vector4.get_zero), null, false);
		LuaObject.addMember(l, "one", new LuaCSFunction(Lua_UnityEngine_Vector4.get_one), null, false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Vector4.constructor), typeof(Vector4), typeof(ValueType));
	}
}
