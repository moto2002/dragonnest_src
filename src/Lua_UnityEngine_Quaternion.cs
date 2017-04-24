using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Quaternion : LuaObject
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
			float z;
			LuaObject.checkType(l, 4, out z);
			float w;
			LuaObject.checkType(l, 5, out w);
			Quaternion o = new Quaternion(x, y, z, w);
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
			Quaternion v;
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
	public static int ToAngleAxis(IntPtr l)
	{
		int result;
		try
		{
			Quaternion v;
			LuaObject.checkType(l, 1, out v);
			float o;
			Vector3 o2;
			v.ToAngleAxis(out o, out o2);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			LuaObject.pushValue(l, o2);
			LuaObject.setBack(l, v);
			result = 3;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetFromToRotation(IntPtr l)
	{
		int result;
		try
		{
			Quaternion v;
			LuaObject.checkType(l, 1, out v);
			Vector3 fromDirection;
			LuaObject.checkType(l, 2, out fromDirection);
			Vector3 toDirection;
			LuaObject.checkType(l, 3, out toDirection);
			v.SetFromToRotation(fromDirection, toDirection);
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
	public static int SetLookRotation(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Quaternion v;
				LuaObject.checkType(l, 1, out v);
				Vector3 lookRotation;
				LuaObject.checkType(l, 2, out lookRotation);
				v.SetLookRotation(lookRotation);
				LuaObject.pushValue(l, true);
				LuaObject.setBack(l, v);
				result = 1;
			}
			else if (num == 3)
			{
				Quaternion v2;
				LuaObject.checkType(l, 1, out v2);
				Vector3 view;
				LuaObject.checkType(l, 2, out view);
				Vector3 up;
				LuaObject.checkType(l, 3, out up);
				v2.SetLookRotation(view, up);
				LuaObject.pushValue(l, true);
				LuaObject.setBack(l, v2);
				result = 1;
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
	public static int Dot_s(IntPtr l)
	{
		int result;
		try
		{
			Quaternion a;
			LuaObject.checkType(l, 1, out a);
			Quaternion b;
			LuaObject.checkType(l, 2, out b);
			float o = Quaternion.Dot(a, b);
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
	public static int AngleAxis_s(IntPtr l)
	{
		int result;
		try
		{
			float angle;
			LuaObject.checkType(l, 1, out angle);
			Vector3 axis;
			LuaObject.checkType(l, 2, out axis);
			Quaternion o = Quaternion.AngleAxis(angle, axis);
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
	public static int FromToRotation_s(IntPtr l)
	{
		int result;
		try
		{
			Vector3 fromDirection;
			LuaObject.checkType(l, 1, out fromDirection);
			Vector3 toDirection;
			LuaObject.checkType(l, 2, out toDirection);
			Quaternion o = Quaternion.FromToRotation(fromDirection, toDirection);
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
	public static int LookRotation_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				Vector3 forward;
				LuaObject.checkType(l, 1, out forward);
				Quaternion o = Quaternion.LookRotation(forward);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 2)
			{
				Vector3 forward2;
				LuaObject.checkType(l, 1, out forward2);
				Vector3 upwards;
				LuaObject.checkType(l, 2, out upwards);
				Quaternion o2 = Quaternion.LookRotation(forward2, upwards);
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
	public static int Slerp_s(IntPtr l)
	{
		int result;
		try
		{
			Quaternion from;
			LuaObject.checkType(l, 1, out from);
			Quaternion to;
			LuaObject.checkType(l, 2, out to);
			float t;
			LuaObject.checkType(l, 3, out t);
			Quaternion o = Quaternion.Slerp(from, to, t);
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
			Quaternion from;
			LuaObject.checkType(l, 1, out from);
			Quaternion to;
			LuaObject.checkType(l, 2, out to);
			float t;
			LuaObject.checkType(l, 3, out t);
			Quaternion o = Quaternion.Lerp(from, to, t);
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
			Quaternion from;
			LuaObject.checkType(l, 1, out from);
			Quaternion to;
			LuaObject.checkType(l, 2, out to);
			float maxDegreesDelta;
			LuaObject.checkType(l, 3, out maxDegreesDelta);
			Quaternion o = Quaternion.RotateTowards(from, to, maxDegreesDelta);
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
	public static int Inverse_s(IntPtr l)
	{
		int result;
		try
		{
			Quaternion rotation;
			LuaObject.checkType(l, 1, out rotation);
			Quaternion o = Quaternion.Inverse(rotation);
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
			Quaternion a;
			LuaObject.checkType(l, 1, out a);
			Quaternion b;
			LuaObject.checkType(l, 2, out b);
			float o = Quaternion.Angle(a, b);
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
	public static int Euler_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				Vector3 euler;
				LuaObject.checkType(l, 1, out euler);
				Quaternion o = Quaternion.Euler(euler);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				float x;
				LuaObject.checkType(l, 1, out x);
				float y;
				LuaObject.checkType(l, 2, out y);
				float z;
				LuaObject.checkType(l, 3, out z);
				Quaternion o2 = Quaternion.Euler(x, y, z);
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
	public static int op_Multiply(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(Quaternion), typeof(Vector3)))
			{
				Quaternion rotation;
				LuaObject.checkType(l, 1, out rotation);
				Vector3 point;
				LuaObject.checkType(l, 2, out point);
				Vector3 o = rotation * point;
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(Quaternion), typeof(Quaternion)))
			{
				Quaternion lhs;
				LuaObject.checkType(l, 1, out lhs);
				Quaternion rhs;
				LuaObject.checkType(l, 2, out rhs);
				Quaternion o2 = lhs * rhs;
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
	public static int op_Equality(IntPtr l)
	{
		int result;
		try
		{
			Quaternion lhs;
			LuaObject.checkType(l, 1, out lhs);
			Quaternion rhs;
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
			Quaternion lhs;
			LuaObject.checkType(l, 1, out lhs);
			Quaternion rhs;
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
			LuaObject.pushValue(l, 1E-06f);
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
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, quaternion.x);
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
			Quaternion v;
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
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, quaternion.y);
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
			Quaternion v;
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
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, quaternion.z);
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
			Quaternion v;
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
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, quaternion.w);
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
			Quaternion v;
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
	public static int get_identity(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Quaternion.identity);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_eulerAngles(IntPtr l)
	{
		int result;
		try
		{
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, quaternion.eulerAngles);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_eulerAngles(IntPtr l)
	{
		int result;
		try
		{
			Quaternion v;
			LuaObject.checkType(l, 1, out v);
			Vector3 eulerAngles;
			LuaObject.checkType(l, 2, out eulerAngles);
			v.eulerAngles = eulerAngles;
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
	public static int getItem(IntPtr l)
	{
		int result;
		try
		{
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			int index;
			LuaObject.checkType(l, 2, out index);
			float o = quaternion[index];
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
			Quaternion quaternion;
			LuaObject.checkType(l, 1, out quaternion);
			int index;
			LuaObject.checkType(l, 2, out index);
			float value;
			LuaObject.checkType(l, 3, out value);
			quaternion[index] = value;
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
		LuaObject.getTypeTable(l, "UnityEngine.Quaternion");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Set));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.ToAngleAxis));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.SetFromToRotation));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.SetLookRotation));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Dot_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.AngleAxis_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.FromToRotation_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.LookRotation_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Slerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Lerp_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.RotateTowards_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Inverse_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Angle_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.Euler_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.op_Multiply));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.op_Equality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.op_Inequality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.setItem));
		LuaObject.addMember(l, "kEpsilon", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_kEpsilon), null, false);
		LuaObject.addMember(l, "x", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_x), new LuaCSFunction(Lua_UnityEngine_Quaternion.set_x), true);
		LuaObject.addMember(l, "y", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_y), new LuaCSFunction(Lua_UnityEngine_Quaternion.set_y), true);
		LuaObject.addMember(l, "z", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_z), new LuaCSFunction(Lua_UnityEngine_Quaternion.set_z), true);
		LuaObject.addMember(l, "w", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_w), new LuaCSFunction(Lua_UnityEngine_Quaternion.set_w), true);
		LuaObject.addMember(l, "identity", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_identity), null, false);
		LuaObject.addMember(l, "eulerAngles", new LuaCSFunction(Lua_UnityEngine_Quaternion.get_eulerAngles), new LuaCSFunction(Lua_UnityEngine_Quaternion.set_eulerAngles), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Quaternion.constructor), typeof(Quaternion), typeof(ValueType));
	}
}
