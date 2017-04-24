using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Object : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object o = new UnityEngine.Object();
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
	public static int GetInstanceID(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object @object = (UnityEngine.Object)LuaObject.checkSelf(l);
			int instanceID = @object.GetInstanceID();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, instanceID);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Instantiate_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UnityEngine.Object original;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out original);
				UnityEngine.Object o = UnityEngine.Object.Instantiate(original);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				UnityEngine.Object original2;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out original2);
				Vector3 position;
				LuaObject.checkType(l, 2, out position);
				Quaternion rotation;
				LuaObject.checkType(l, 3, out rotation);
				UnityEngine.Object o2 = UnityEngine.Object.Instantiate(original2, position, rotation);
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
	public static int Destroy_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UnityEngine.Object obj;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out obj);
				UnityEngine.Object.Destroy(obj);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				UnityEngine.Object obj2;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out obj2);
				float t;
				LuaObject.checkType(l, 2, out t);
				UnityEngine.Object.Destroy(obj2, t);
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
	public static int DestroyImmediate_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UnityEngine.Object obj;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out obj);
				UnityEngine.Object.DestroyImmediate(obj);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				UnityEngine.Object obj2;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out obj2);
				bool allowDestroyingAssets;
				LuaObject.checkType(l, 2, out allowDestroyingAssets);
				UnityEngine.Object.DestroyImmediate(obj2, allowDestroyingAssets);
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
	public static int FindObjectsOfType_s(IntPtr l)
	{
		int result;
		try
		{
			Type type;
			LuaObject.checkType(l, 1, out type);
			UnityEngine.Object[] a = UnityEngine.Object.FindObjectsOfType(type);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, a);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int FindObjectOfType_s(IntPtr l)
	{
		int result;
		try
		{
			Type type;
			LuaObject.checkType(l, 1, out type);
			UnityEngine.Object o = UnityEngine.Object.FindObjectOfType(type);
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
	public static int DontDestroyOnLoad_s(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object target;
			LuaObject.checkType<UnityEngine.Object>(l, 1, out target);
			UnityEngine.Object.DontDestroyOnLoad(target);
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
	public static int DestroyObject_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UnityEngine.Object obj;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out obj);
				UnityEngine.Object.DestroyObject(obj);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				UnityEngine.Object obj2;
				LuaObject.checkType<UnityEngine.Object>(l, 1, out obj2);
				float t;
				LuaObject.checkType(l, 2, out t);
				UnityEngine.Object.DestroyObject(obj2, t);
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
	public static int op_Equality(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object x;
			LuaObject.checkType<UnityEngine.Object>(l, 1, out x);
			UnityEngine.Object y;
			LuaObject.checkType<UnityEngine.Object>(l, 2, out y);
			bool b = x == y;
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
			UnityEngine.Object x;
			LuaObject.checkType<UnityEngine.Object>(l, 1, out x);
			UnityEngine.Object y;
			LuaObject.checkType<UnityEngine.Object>(l, 2, out y);
			bool b = x != y;
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
	public static int get_name(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object @object = (UnityEngine.Object)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @object.name);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_name(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object @object = (UnityEngine.Object)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			@object.name = name;
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
	public static int get_hideFlags(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object @object = (UnityEngine.Object)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)@object.hideFlags);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_hideFlags(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Object @object = (UnityEngine.Object)LuaObject.checkSelf(l);
			HideFlags hideFlags;
			LuaObject.checkEnum<HideFlags>(l, 2, out hideFlags);
			@object.hideFlags = hideFlags;
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
		LuaObject.getTypeTable(l, "UnityEngine.Object");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.GetInstanceID));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.Instantiate_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.Destroy_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.DestroyImmediate_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.FindObjectsOfType_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.FindObjectOfType_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.DontDestroyOnLoad_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.DestroyObject_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.op_Equality));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Object.op_Inequality));
		LuaObject.addMember(l, "name", new LuaCSFunction(Lua_UnityEngine_Object.get_name), new LuaCSFunction(Lua_UnityEngine_Object.set_name), true);
		LuaObject.addMember(l, "hideFlags", new LuaCSFunction(Lua_UnityEngine_Object.get_hideFlags), new LuaCSFunction(Lua_UnityEngine_Object.set_hideFlags), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Object.constructor), typeof(UnityEngine.Object));
	}
}
