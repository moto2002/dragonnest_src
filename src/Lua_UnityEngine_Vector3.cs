using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Vector3 : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 4)
			{
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o = new Vector3(x, y, z);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				float x2;
				LuaObject.checkType(l, 2, out x2);
				float y2;
				LuaObject.checkType(l, 3, out y2);
				Vector3 o = new Vector3(x2, y2);
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
			Vector3 v;
			LuaObject.checkType(l, 1, out v);
			float new_x;
			LuaObject.checkType(l, 2, out new_x);
			float new_y;
			LuaObject.checkType(l, 3, out new_y);
			float new_z;
			LuaObject.checkType(l, 4, out new_z);
			v.Set(new_x, new_y, new_z);
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
			Vector3 v;
			LuaObject.checkType(l, 1, out v);
			Vector3 scale;
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
			Vector3 v;
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
	public static int Lerp_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 from;
			LuaObject.checkType(l, 1, out from);
			Vector3 to;
			LuaObject.checkType(l, 2, out to);
			float t;
			LuaObject.checkType(l, 3, out t);
			Vector3 o = Vector3.Lerp(from, to, t);
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
	public static int Slerp_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 from;
			LuaObject.checkType(l, 1, out from);
			Vector3 to;
			LuaObject.checkType(l, 2, out to);
			float t;
			LuaObject.checkType(l, 3, out t);
			Vector3 o = Vector3.Slerp(from, to, t);
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
	public static int OrthoNormalize_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Vector3 o;
				LuaObject.checkType(l, 1, out o);
				Vector3 o2;
				LuaObject.checkType(l, 2, out o2);
				Vector3.OrthoNormalize(ref o, ref o2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				LuaObject.pushValue(l, o2);
				result = 3;
			}
			else if (num == 3)
			{
				Vector3 o3;
				LuaObject.checkType(l, 1, out o3);
				Vector3 o4;
				LuaObject.checkType(l, 2, out o4);
				Vector3 o5;
				LuaObject.checkType(l, 3, out o5);
				Vector3.OrthoNormalize(ref o3, ref o4, ref o5);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o3);
				LuaObject.pushValue(l, o4);
				LuaObject.pushValue(l, o5);
				result = 4;
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
	public static int MoveTowards_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 current;
			LuaObject.checkType(l, 1, out current);
			Vector3 target;
			LuaObject.checkType(l, 2, out target);
			float maxDistanceDelta;
			LuaObject.checkType(l, 3, out maxDistanceDelta);
			Vector3 o = Vector3.MoveTowards(current, target, maxDistanceDelta);
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
	public static int RotateTowards_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 current;
			LuaObject.checkType(l, 1, out current);
			Vector3 target;
			LuaObject.checkType(l, 2, out target);
			float maxRadiansDelta;
			LuaObject.checkType(l, 3, out maxRadiansDelta);
			float maxMagnitudeDelta;
			LuaObject.checkType(l, 4, out maxMagnitudeDelta);
			Vector3 o = Vector3.RotateTowards(current, target, maxRadiansDelta, maxMagnitudeDelta);
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
				Vector3 current;
				LuaObject.checkType(l, 1, out current);
				Vector3 target;
				LuaObject.checkType(l, 2, out target);
				Vector3 o;
				LuaObject.checkType(l, 3, out o);
				float smoothTime;
				LuaObject.checkType(l, 4, out smoothTime);
				Vector3 o2 = Vector3.SmoothDamp(current, target, ref o, smoothTime);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
				LuaObject.pushValue(l, o);
				result = 3;
			}
			else if (num == 5)
			{
				Vector3 current2;
				LuaObject.checkType(l, 1, out current2);
				Vector3 target2;
				LuaObject.checkType(l, 2, out target2);
				Vector3 o3;
				LuaObject.checkType(l, 3, out o3);
				float smoothTime2;
				LuaObject.checkType(l, 4, out smoothTime2);
				float maxSpeed;
				LuaObject.checkType(l, 5, out maxSpeed);
				Vector3 o4 = Vector3.SmoothDamp(current2, target2, ref o3, smoothTime2, maxSpeed);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o4);
				LuaObject.pushValue(l, o3);
				result = 3;
			}
			else if (num == 6)
			{
				Vector3 current3;
				LuaObject.checkType(l, 1, out current3);
				Vector3 target3;
				LuaObject.checkType(l, 2, out target3);
				Vector3 o5;
				LuaObject.checkType(l, 3, out o5);
				float smoothTime3;
				LuaObject.checkType(l, 4, out smoothTime3);
				float maxSpeed2;
				LuaObject.checkType(l, 5, out maxSpeed2);
				float deltaTime;
				LuaObject.checkType(l, 6, out deltaTime);
				Vector3 o6 = Vector3.SmoothDamp(current3, target3, ref o5, smoothTime3, maxSpeed2, deltaTime);
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
	public static int Scale_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			Vector3 b;
			LuaObject.checkType(l, 2, out b);
			Vector3 o = Vector3.Scale(a, b);
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
	public static int Cross_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector3 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector3 o = Vector3.Cross(lhs, rhs);
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
	public static int Reflect_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 inDirection;
			LuaObject.checkType(l, 1, out inDirection);
			Vector3 inNormal;
			LuaObject.checkType(l, 2, out inNormal);
			Vector3 o = Vector3.Reflect(inDirection, inNormal);
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
			Vector3 value;
			LuaObject.checkType(l, 1, out value);
			Vector3 o = Vector3.Normalize(value);
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
			Vector3 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector3 rhs;
			LuaObject.checkType(l, 2, out rhs);
			float o = Vector3.Dot(lhs, rhs);
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
			Vector3 vector;
			LuaObject.checkType(l, 1, out vector);
			Vector3 onNormal;
			LuaObject.checkType(l, 2, out onNormal);
			Vector3 o = Vector3.Project(vector, onNormal);
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
	public static int ProjectOnPlane_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 vector;
			LuaObject.checkType(l, 1, out vector);
			Vector3 planeNormal;
			LuaObject.checkType(l, 2, out planeNormal);
			Vector3 o = Vector3.ProjectOnPlane(vector, planeNormal);
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
			Vector3 from;
			LuaObject.checkType(l, 1, out from);
			Vector3 to;
			LuaObject.checkType(l, 2, out to);
			float o = Vector3.Angle(from, to);
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			Vector3 b;
			LuaObject.checkType(l, 2, out b);
			float o = Vector3.Distance(a, b);
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
			Vector3 vector;
			LuaObject.checkType(l, 1, out vector);
			float maxLength;
			LuaObject.checkType(l, 2, out maxLength);
			Vector3 o = Vector3.ClampMagnitude(vector, maxLength);
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			float o = Vector3.Magnitude(a);
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			float o = Vector3.SqrMagnitude(a);
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
			Vector3 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector3 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector3 o = Vector3.Min(lhs, rhs);
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
			Vector3 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector3 rhs;
			LuaObject.checkType(l, 2, out rhs);
			Vector3 o = Vector3.Max(lhs, rhs);
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			Vector3 b;
			LuaObject.checkType(l, 2, out b);
			Vector3 o = a + b;
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			Vector3 b;
			LuaObject.checkType(l, 2, out b);
			Vector3 o = a - b;
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			Vector3 o = -a;
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
			if (LuaObject.matchType(l, total, 1, typeof(float), typeof(Vector3)))
			{
				float d;
				LuaObject.checkType(l, 1, out d);
				Vector3 a;
				LuaObject.checkType(l, 2, out a);
				Vector3 o = d * a;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(Vector3), typeof(float)))
			{
				Vector3 a2;
				LuaObject.checkType(l, 1, out a2);
				float d2;
				LuaObject.checkType(l, 2, out d2);
				Vector3 o2 = a2 * d2;
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
			Vector3 a;
			LuaObject.checkType(l, 1, out a);
			float d;
			LuaObject.checkType(l, 2, out d);
			Vector3 o = a / d;
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
			Vector3 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector3 rhs;
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
			Vector3 lhs;
			LuaObject.checkType(l, 1, out lhs);
			Vector3 rhs;
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
			Vector3 vector;
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
			Vector3 v;
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
			Vector3 vector;
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
			Vector3 v;
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
			Vector3 vector;
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
			Vector3 v;
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
	public static int get_normalized(IntPtr l)
	{
		int result;
		try
		{
			Vector3 vector;
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
			Vector3 vector;
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
			Vector3 vector;
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
			LuaObject.pushValue(l, Vector3.zero);
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
			LuaObject.pushValue(l, Vector3.one);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_forward(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector3.forward);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_back(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector3.back);
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
			LuaObject.pushValue(l, Vector3.up);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_down(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector3.down);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_left(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Vector3.left);
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
			LuaObject.pushValue(l, Vector3.right);
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
			Vector3 vector;
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
			Vector3 vector;
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
		LuaObject.getTypeTable(l, "UnityEngine.Vector3");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Set));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Scale));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Normalize));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Lerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Slerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.OrthoNormalize_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.MoveTowards_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.RotateTowards_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.SmoothDamp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Scale_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Cross_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Reflect_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Normalize_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Dot_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Project_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.ProjectOnPlane_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Angle_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Distance_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.ClampMagnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Magnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.SqrMagnitude_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Min_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.Max_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_Addition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_Subtraction));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_UnaryNegation));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_Multiply));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_Division));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_Equality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.op_Inequality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Vector3.setItem));
		LuaObject.addMember(l, "kEpsilon", new LuaCSFunction(Lua_UnityEngine_Vector3.get_kEpsilon), null, false);
		LuaObject.addMember(l, "x", new LuaCSFunction(Lua_UnityEngine_Vector3.get_x), new LuaCSFunction(Lua_UnityEngine_Vector3.set_x), true);
		LuaObject.addMember(l, "y", new LuaCSFunction(Lua_UnityEngine_Vector3.get_y), new LuaCSFunction(Lua_UnityEngine_Vector3.set_y), true);
		LuaObject.addMember(l, "z", new LuaCSFunction(Lua_UnityEngine_Vector3.get_z), new LuaCSFunction(Lua_UnityEngine_Vector3.set_z), true);
		LuaObject.addMember(l, "normalized", new LuaCSFunction(Lua_UnityEngine_Vector3.get_normalized), null, true);
		LuaObject.addMember(l, "magnitude", new LuaCSFunction(Lua_UnityEngine_Vector3.get_magnitude), null, true);
		LuaObject.addMember(l, "sqrMagnitude", new LuaCSFunction(Lua_UnityEngine_Vector3.get_sqrMagnitude), null, true);
		LuaObject.addMember(l, "zero", new LuaCSFunction(Lua_UnityEngine_Vector3.get_zero), null, false);
		LuaObject.addMember(l, "one", new LuaCSFunction(Lua_UnityEngine_Vector3.get_one), null, false);
		LuaObject.addMember(l, "forward", new LuaCSFunction(Lua_UnityEngine_Vector3.get_forward), null, false);
		LuaObject.addMember(l, "back", new LuaCSFunction(Lua_UnityEngine_Vector3.get_back), null, false);
		LuaObject.addMember(l, "up", new LuaCSFunction(Lua_UnityEngine_Vector3.get_up), null, false);
		LuaObject.addMember(l, "down", new LuaCSFunction(Lua_UnityEngine_Vector3.get_down), null, false);
		LuaObject.addMember(l, "left", new LuaCSFunction(Lua_UnityEngine_Vector3.get_left), null, false);
		LuaObject.addMember(l, "right", new LuaCSFunction(Lua_UnityEngine_Vector3.get_right), null, false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Vector3.constructor), typeof(Vector3), typeof(ValueType));
	}
}
