using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Transform : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetParent(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Transform parent;
				LuaObject.checkType<Transform>(l, 2, out parent);
				transform.SetParent(parent);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 3)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				Transform parent2;
				LuaObject.checkType<Transform>(l, 2, out parent2);
				bool worldPositionStays;
				LuaObject.checkType(l, 3, out worldPositionStays);
				transform2.SetParent(parent2, worldPositionStays);
				LuaObject.pushValue(l, true);
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
	public static int Translate(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 translation;
				LuaObject.checkType(l, 2, out translation);
				transform.Translate(translation);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Vector3), typeof(Transform)))
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				Vector3 translation2;
				LuaObject.checkType(l, 2, out translation2);
				Transform relativeTo;
				LuaObject.checkType<Transform>(l, 3, out relativeTo);
				transform2.Translate(translation2, relativeTo);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Vector3), typeof(Space)))
			{
				Transform transform3 = (Transform)LuaObject.checkSelf(l);
				Vector3 translation3;
				LuaObject.checkType(l, 2, out translation3);
				Space relativeTo2;
				LuaObject.checkEnum<Space>(l, 3, out relativeTo2);
				transform3.Translate(translation3, relativeTo2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				Transform transform4 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				transform4.Translate(x, y, z);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(float), typeof(float), typeof(float), typeof(Transform)))
			{
				Transform transform5 = (Transform)LuaObject.checkSelf(l);
				float x2;
				LuaObject.checkType(l, 2, out x2);
				float y2;
				LuaObject.checkType(l, 3, out y2);
				float z2;
				LuaObject.checkType(l, 4, out z2);
				Transform relativeTo3;
				LuaObject.checkType<Transform>(l, 5, out relativeTo3);
				transform5.Translate(x2, y2, z2, relativeTo3);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(float), typeof(float), typeof(float), typeof(Space)))
			{
				Transform transform6 = (Transform)LuaObject.checkSelf(l);
				float x3;
				LuaObject.checkType(l, 2, out x3);
				float y3;
				LuaObject.checkType(l, 3, out y3);
				float z3;
				LuaObject.checkType(l, 4, out z3);
				Space relativeTo4;
				LuaObject.checkEnum<Space>(l, 5, out relativeTo4);
				transform6.Translate(x3, y3, z3, relativeTo4);
				LuaObject.pushValue(l, true);
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
	public static int Rotate(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 eulerAngles;
				LuaObject.checkType(l, 2, out eulerAngles);
				transform.Rotate(eulerAngles);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Vector3), typeof(float)))
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				Vector3 axis;
				LuaObject.checkType(l, 2, out axis);
				float angle;
				LuaObject.checkType(l, 3, out angle);
				transform2.Rotate(axis, angle);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Vector3), typeof(Space)))
			{
				Transform transform3 = (Transform)LuaObject.checkSelf(l);
				Vector3 eulerAngles2;
				LuaObject.checkType(l, 2, out eulerAngles2);
				Space relativeTo;
				LuaObject.checkEnum<Space>(l, 3, out relativeTo);
				transform3.Rotate(eulerAngles2, relativeTo);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Vector3), typeof(float), typeof(Space)))
			{
				Transform transform4 = (Transform)LuaObject.checkSelf(l);
				Vector3 axis2;
				LuaObject.checkType(l, 2, out axis2);
				float angle2;
				LuaObject.checkType(l, 3, out angle2);
				Space relativeTo2;
				LuaObject.checkEnum<Space>(l, 4, out relativeTo2);
				transform4.Rotate(axis2, angle2, relativeTo2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(float), typeof(float), typeof(float)))
			{
				Transform transform5 = (Transform)LuaObject.checkSelf(l);
				float xAngle;
				LuaObject.checkType(l, 2, out xAngle);
				float yAngle;
				LuaObject.checkType(l, 3, out yAngle);
				float zAngle;
				LuaObject.checkType(l, 4, out zAngle);
				transform5.Rotate(xAngle, yAngle, zAngle);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 5)
			{
				Transform transform6 = (Transform)LuaObject.checkSelf(l);
				float xAngle2;
				LuaObject.checkType(l, 2, out xAngle2);
				float yAngle2;
				LuaObject.checkType(l, 3, out yAngle2);
				float zAngle2;
				LuaObject.checkType(l, 4, out zAngle2);
				Space relativeTo3;
				LuaObject.checkEnum<Space>(l, 5, out relativeTo3);
				transform6.Rotate(xAngle2, yAngle2, zAngle2, relativeTo3);
				LuaObject.pushValue(l, true);
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
	public static int RotateAround(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 point;
			LuaObject.checkType(l, 2, out point);
			Vector3 axis;
			LuaObject.checkType(l, 3, out axis);
			float angle;
			LuaObject.checkType(l, 4, out angle);
			transform.RotateAround(point, axis, angle);
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
	public static int LookAt(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Vector3)))
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 worldPosition;
				LuaObject.checkType(l, 2, out worldPosition);
				transform.LookAt(worldPosition);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Transform)))
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				Transform target;
				LuaObject.checkType<Transform>(l, 2, out target);
				transform2.LookAt(target);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Vector3), typeof(Vector3)))
			{
				Transform transform3 = (Transform)LuaObject.checkSelf(l);
				Vector3 worldPosition2;
				LuaObject.checkType(l, 2, out worldPosition2);
				Vector3 worldUp;
				LuaObject.checkType(l, 3, out worldUp);
				transform3.LookAt(worldPosition2, worldUp);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(Transform), typeof(Vector3)))
			{
				Transform transform4 = (Transform)LuaObject.checkSelf(l);
				Transform target2;
				LuaObject.checkType<Transform>(l, 2, out target2);
				Vector3 worldUp2;
				LuaObject.checkType(l, 3, out worldUp2);
				transform4.LookAt(target2, worldUp2);
				LuaObject.pushValue(l, true);
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
	public static int TransformDirection(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 direction;
				LuaObject.checkType(l, 2, out direction);
				Vector3 o = transform.TransformDirection(direction);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o2 = transform2.TransformDirection(x, y, z);
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
	public static int InverseTransformDirection(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 direction;
				LuaObject.checkType(l, 2, out direction);
				Vector3 o = transform.InverseTransformDirection(direction);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o2 = transform2.InverseTransformDirection(x, y, z);
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
	public static int TransformVector(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 vector;
				LuaObject.checkType(l, 2, out vector);
				Vector3 o = transform.TransformVector(vector);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o2 = transform2.TransformVector(x, y, z);
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
	public static int InverseTransformVector(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 vector;
				LuaObject.checkType(l, 2, out vector);
				Vector3 o = transform.InverseTransformVector(vector);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o2 = transform2.InverseTransformVector(x, y, z);
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
	public static int TransformPoint(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 position;
				LuaObject.checkType(l, 2, out position);
				Vector3 o = transform.TransformPoint(position);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o2 = transform2.TransformPoint(x, y, z);
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
	public static int InverseTransformPoint(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				Transform transform = (Transform)LuaObject.checkSelf(l);
				Vector3 position;
				LuaObject.checkType(l, 2, out position);
				Vector3 o = transform.InverseTransformPoint(position);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 4)
			{
				Transform transform2 = (Transform)LuaObject.checkSelf(l);
				float x;
				LuaObject.checkType(l, 2, out x);
				float y;
				LuaObject.checkType(l, 3, out y);
				float z;
				LuaObject.checkType(l, 4, out z);
				Vector3 o2 = transform2.InverseTransformPoint(x, y, z);
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
	public static int DetachChildren(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			transform.DetachChildren();
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
	public static int SetAsFirstSibling(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			transform.SetAsFirstSibling();
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
	public static int SetAsLastSibling(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			transform.SetAsLastSibling();
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
	public static int SetSiblingIndex(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			int siblingIndex;
			LuaObject.checkType(l, 2, out siblingIndex);
			transform.SetSiblingIndex(siblingIndex);
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
	public static int GetSiblingIndex(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			int siblingIndex = transform.GetSiblingIndex();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, siblingIndex);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Find(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			Transform o = transform.Find(name);
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
	public static int IsChildOf(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Transform parent;
			LuaObject.checkType<Transform>(l, 2, out parent);
			bool b = transform.IsChildOf(parent);
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
	public static int FindChild(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			Transform o = transform.FindChild(name);
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
	public static int GetChild(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			Transform child = transform.GetChild(index);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, child);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_position(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.position);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_position(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 position;
			LuaObject.checkType(l, 2, out position);
			transform.position = position;
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
	public static int get_localPosition(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.localPosition);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_localPosition(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 localPosition;
			LuaObject.checkType(l, 2, out localPosition);
			transform.localPosition = localPosition;
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
	public static int get_eulerAngles(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.eulerAngles);
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
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 eulerAngles;
			LuaObject.checkType(l, 2, out eulerAngles);
			transform.eulerAngles = eulerAngles;
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
	public static int get_localEulerAngles(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.localEulerAngles);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_localEulerAngles(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 localEulerAngles;
			LuaObject.checkType(l, 2, out localEulerAngles);
			transform.localEulerAngles = localEulerAngles;
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
	public static int get_right(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.right);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_right(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 right;
			LuaObject.checkType(l, 2, out right);
			transform.right = right;
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
	public static int get_up(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.up);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_up(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 up;
			LuaObject.checkType(l, 2, out up);
			transform.up = up;
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
	public static int get_forward(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.forward);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_forward(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 forward;
			LuaObject.checkType(l, 2, out forward);
			transform.forward = forward;
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
	public static int get_rotation(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.rotation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_rotation(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Quaternion rotation;
			LuaObject.checkType(l, 2, out rotation);
			transform.rotation = rotation;
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
	public static int get_localRotation(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.localRotation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_localRotation(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Quaternion localRotation;
			LuaObject.checkType(l, 2, out localRotation);
			transform.localRotation = localRotation;
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
	public static int get_localScale(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.localScale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_localScale(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Vector3 localScale;
			LuaObject.checkType(l, 2, out localScale);
			transform.localScale = localScale;
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
	public static int get_parent(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.parent);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_parent(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			Transform parent;
			LuaObject.checkType<Transform>(l, 2, out parent);
			transform.parent = parent;
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
	public static int get_worldToLocalMatrix(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.worldToLocalMatrix);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_localToWorldMatrix(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.localToWorldMatrix);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_root(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.root);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_childCount(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.childCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_lossyScale(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.lossyScale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hasChanged(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, transform.hasChanged);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_hasChanged(IntPtr l)
	{
		int result;
		try
		{
			Transform transform = (Transform)LuaObject.checkSelf(l);
			bool hasChanged;
			LuaObject.checkType(l, 2, out hasChanged);
			transform.hasChanged = hasChanged;
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
		LuaObject.getTypeTable(l, "UnityEngine.Transform");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.SetParent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.Translate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.Rotate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.RotateAround));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.LookAt));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.TransformDirection));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.InverseTransformDirection));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.TransformVector));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.InverseTransformVector));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.TransformPoint));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.InverseTransformPoint));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.DetachChildren));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.SetAsFirstSibling));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.SetAsLastSibling));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.SetSiblingIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.GetSiblingIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.Find));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.IsChildOf));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.FindChild));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Transform.GetChild));
		LuaObject.addMember(l, "position", new LuaCSFunction(Lua_UnityEngine_Transform.get_position), new LuaCSFunction(Lua_UnityEngine_Transform.set_position), true);
		LuaObject.addMember(l, "localPosition", new LuaCSFunction(Lua_UnityEngine_Transform.get_localPosition), new LuaCSFunction(Lua_UnityEngine_Transform.set_localPosition), true);
		LuaObject.addMember(l, "eulerAngles", new LuaCSFunction(Lua_UnityEngine_Transform.get_eulerAngles), new LuaCSFunction(Lua_UnityEngine_Transform.set_eulerAngles), true);
		LuaObject.addMember(l, "localEulerAngles", new LuaCSFunction(Lua_UnityEngine_Transform.get_localEulerAngles), new LuaCSFunction(Lua_UnityEngine_Transform.set_localEulerAngles), true);
		LuaObject.addMember(l, "right", new LuaCSFunction(Lua_UnityEngine_Transform.get_right), new LuaCSFunction(Lua_UnityEngine_Transform.set_right), true);
		LuaObject.addMember(l, "up", new LuaCSFunction(Lua_UnityEngine_Transform.get_up), new LuaCSFunction(Lua_UnityEngine_Transform.set_up), true);
		LuaObject.addMember(l, "forward", new LuaCSFunction(Lua_UnityEngine_Transform.get_forward), new LuaCSFunction(Lua_UnityEngine_Transform.set_forward), true);
		LuaObject.addMember(l, "rotation", new LuaCSFunction(Lua_UnityEngine_Transform.get_rotation), new LuaCSFunction(Lua_UnityEngine_Transform.set_rotation), true);
		LuaObject.addMember(l, "localRotation", new LuaCSFunction(Lua_UnityEngine_Transform.get_localRotation), new LuaCSFunction(Lua_UnityEngine_Transform.set_localRotation), true);
		LuaObject.addMember(l, "localScale", new LuaCSFunction(Lua_UnityEngine_Transform.get_localScale), new LuaCSFunction(Lua_UnityEngine_Transform.set_localScale), true);
		LuaObject.addMember(l, "parent", new LuaCSFunction(Lua_UnityEngine_Transform.get_parent), new LuaCSFunction(Lua_UnityEngine_Transform.set_parent), true);
		LuaObject.addMember(l, "worldToLocalMatrix", new LuaCSFunction(Lua_UnityEngine_Transform.get_worldToLocalMatrix), null, true);
		LuaObject.addMember(l, "localToWorldMatrix", new LuaCSFunction(Lua_UnityEngine_Transform.get_localToWorldMatrix), null, true);
		LuaObject.addMember(l, "root", new LuaCSFunction(Lua_UnityEngine_Transform.get_root), null, true);
		LuaObject.addMember(l, "childCount", new LuaCSFunction(Lua_UnityEngine_Transform.get_childCount), null, true);
		LuaObject.addMember(l, "lossyScale", new LuaCSFunction(Lua_UnityEngine_Transform.get_lossyScale), null, true);
		LuaObject.addMember(l, "hasChanged", new LuaCSFunction(Lua_UnityEngine_Transform.get_hasChanged), new LuaCSFunction(Lua_UnityEngine_Transform.set_hasChanged), true);
		LuaObject.createTypeMetatable(l, null, typeof(Transform), typeof(Component));
	}
}
