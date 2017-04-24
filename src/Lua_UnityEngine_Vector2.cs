using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Vector2 : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			float x;
			LuaObject.checkType(l, 2, out x);
			float y;
			LuaObject.checkType(l, 3, out y);
			Vector2 o = new Vector2(x, y);
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
	public static int Set(IntPtr l)
	{
		int result;
		try
		{
			Vector2 v;
			LuaObject.checkType(l, 1, out v);
			float new_x;
			LuaObject.checkType(l, 2, out new_x);
			float new_y;
			LuaObject.checkType(l, 3, out new_y);
			v.Set(new_x, new_y);
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
			Vector2 v;
			LuaObject.checkType(l, 1, out v);
			Vector2 scale;
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
			Vector2 v;
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
			Vector2 vector;
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
			Vector2 from;
			LuaObject.checkType(l, 1, out from);
			Vector2 to;
			LuaObject.checkType(l, 2, out to);
			float t;
			LuaObject.checkType(l, 3, out t);
			Vector2 o = Vector2.Lerp(from, to, t);
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
			Vector2 current;
			LuaObject.checkType(l, 1, out current);
			Vector2 target;
			LuaObject.checkType(l, 2, out target);
			float maxDistanceDelta;
			LuaObject.checkType(l, 3, out maxDistanceDelta);
			Vector2 o = Vector2.MoveTowards(current, target, maxDistanceDelta);
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
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			Vector2 b;
			LuaObject.checkType(l, 2, out b);
			Vector2 o = Vector2.Scale(a, b);
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
			Vector2 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector2 rhs;
			LuaObject.checkType(l, 2, out rhs);
			float o = Vector2.Dot(lhs, rhs);
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
	public static int Angle_s(IntPtr l)
	{
		int result;
		try
		{
			Vector2 from;
			LuaObject.checkType(l, 1, out from);
			Vector2 to;
			LuaObject.checkType(l, 2, out to);
			float o = Vector2.Angle(from, to);
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
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			Vector2 b;
			LuaObject.checkType(l, 2, out b);
			float o = Vector2.Distance(a, b);
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
	public static int ClampMagnitude_s(IntPtr l)
	{
		int result;
		try
		{
			Vector2 vector;
			LuaObject.checkType(l, 1, out vector);
			float maxLength;
			LuaObject.checkType(l, 2, out maxLength);
			Vector2 o = Vector2.ClampMagnitude(vector, maxLength);
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
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			float o = Vector2.SqrMagnitude(a);
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
			Vector2 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector2 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector2 o = Vector2.Min(lhs, rhs);
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
			Vector2 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector2 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector2 o = Vector2.Max(lhs, rhs);
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
	public static int SmoothDamp_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 4)
			{
				Vector2 current;
				LuaObject.checkType(l, 1, out current);
				Vector2 target;
				LuaObject.checkType(l, 2, out target);
				Vector2 o;
				LuaObject.checkType(l, 3, out o);
				float smoothTime;
				LuaObject.checkType(l, 4, out smoothTime);
				Vector2 o2 = Vector2.SmoothDamp(current, target, ref o, smoothTime);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
				LuaObject.pushValue(l, o);
				result = 3;
			}
			else if (num == 5)
			{
				Vector2 current2;
				LuaObject.checkType(l, 1, out current2);
				Vector2 target2;
				LuaObject.checkType(l, 2, out target2);
				Vector2 o3;
				LuaObject.checkType(l, 3, out o3);
				float smoothTime2;
				LuaObject.checkType(l, 4, out smoothTime2);
				float maxSpeed;
				LuaObject.checkType(l, 5, out maxSpeed);
				Vector2 o4 = Vector2.SmoothDamp(current2, target2, ref o3, smoothTime2, maxSpeed);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o4);
				LuaObject.pushValue(l, o3);
				result = 3;
			}
			else if (num == 6)
			{
				Vector2 current3;
				LuaObject.checkType(l, 1, out current3);
				Vector2 target3;
				LuaObject.checkType(l, 2, out target3);
				Vector2 o5;
				LuaObject.checkType(l, 3, out o5);
				float smoothTime3;
				LuaObject.checkType(l, 4, out smoothTime3);
				float maxSpeed2;
				LuaObject.checkType(l, 5, out maxSpeed2);
				float deltaTime;
				LuaObject.checkType(l, 6, out deltaTime);
				Vector2 o6 = Vector2.SmoothDamp(current3, target3, ref o5, smoothTime3, maxSpeed2, deltaTime);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o6);
				LuaObject.pushValue(l, o5);
				result = 3;
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
	public static int op_Addition(IntPtr l)
	{
		int result;
		try
		{
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			Vector2 b;
			LuaObject.checkType(l, 2, out b);
			Vector2 o = a + b;
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
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			Vector2 b;
			LuaObject.checkType(l, 2, out b);
			Vector2 o = a - b;
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
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			Vector2 o = -a;
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
			if (LuaObject.matchType(l, total, 1, typeof(float), typeof(Vector2)))
			{
				float d;
				LuaObject.checkType(l, 1, out d);
				Vector2 a;
				LuaObject.checkType(l, 2, out a);
				Vector2 o = d * a;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(Vector2), typeof(float)))
			{
				Vector2 a2;
				LuaObject.checkType(l, 1, out a2);
				float d2;
				LuaObject.checkType(l, 2, out d2);
				Vector2 o2 = a2 * d2;
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
			Vector2 a;
			LuaObject.checkType(l, 1, out a);
			float d;
			LuaObject.checkType(l, 2, out d);
			Vector2 o = a / d;
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
			Vector2 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector2 rhs;
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
			Vector2 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector2 rhs;
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
			Vector2 vector;
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
			Vector2 v;
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
			Vector2 vector;
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
			Vector2 v;
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
	public static int get_normalized(IntPtr l)
	{
		int result;
		try
		{
			Vector2 vector;
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
			Vector2 vector;
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
			Vector2 vector;
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
			LuaObject.pushValue(l, Vector2.zero);
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
			LuaObject.pushValue(l, Vector2.one);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_up(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector2.up);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_right(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector2.right);
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
			Vector2 vector;
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
			Vector2 vector;
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
		LuaObject.getTypeTable(l, "UnityEngine.Vector2");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Set));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Scale));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Normalize));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.SqrMagnitude));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Lerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.MoveTowards_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Scale_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Dot_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Angle_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Distance_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.ClampMagnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.SqrMagnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Min_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.Max_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.SmoothDamp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_Addition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_Subtraction));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_UnaryNegation));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_Multiply));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_Division));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_Equality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.op_Inequality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector2.setItem));
		LuaObject.addMember(l, "kEpsilon", new LuaCSFunction(Lua_UnityEngine_Vector2.get_kEpsilon), null, false);
		LuaObject.addMember(l, "x", new LuaCSFunction(Lua_UnityEngine_Vector2.get_x), new LuaCSFunction(Lua_UnityEngine_Vector2.set_x), true);
		LuaObject.addMember(l, "y", new LuaCSFunction(Lua_UnityEngine_Vector2.get_y), new LuaCSFunction(Lua_UnityEngine_Vector2.set_y), true);
		LuaObject.addMember(l, "normalized", new LuaCSFunction(Lua_UnityEngine_Vector2.get_normalized), null, true);
		LuaObject.addMember(l, "magnitude", new LuaCSFunction(Lua_UnityEngine_Vector2.get_magnitude), null, true);
		LuaObject.addMember(l, "sqrMagnitude", new LuaCSFunction(Lua_UnityEngine_Vector2.get_sqrMagnitude), null, true);
		LuaObject.addMember(l, "zero", new LuaCSFunction(Lua_UnityEngine_Vector2.get_zero), null, false);
		LuaObject.addMember(l, "one", new LuaCSFunction(Lua_UnityEngine_Vector2.get_one), null, false);
		LuaObject.addMember(l, "up", new LuaCSFunction(Lua_UnityEngine_Vector2.get_up), null, false);
		LuaObject.addMember(l, "right", new LuaCSFunction(Lua_UnityEngine_Vector2.get_right), null, false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Vector2.constructor), typeof(Vector2), typeof(ValueType));
	}
}
