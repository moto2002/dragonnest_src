using LuaInterface;
using System;
using UnityEngine;

public class ColliderWrap
{
	private static Type classType = typeof(Collider);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ClosestPointOnBounds", new LuaCSFunction(ColliderWrap.ClosestPointOnBounds)),
			new LuaMethod("Raycast", new LuaCSFunction(ColliderWrap.Raycast)),
			new LuaMethod("New", new LuaCSFunction(ColliderWrap._CreateCollider)),
			new LuaMethod("GetClassType", new LuaCSFunction(ColliderWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(ColliderWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("enabled", new LuaCSFunction(ColliderWrap.get_enabled), new LuaCSFunction(ColliderWrap.set_enabled)),
			new LuaField("attachedRigidbody", new LuaCSFunction(ColliderWrap.get_attachedRigidbody), null),
			new LuaField("isTrigger", new LuaCSFunction(ColliderWrap.get_isTrigger), new LuaCSFunction(ColliderWrap.set_isTrigger)),
			new LuaField("material", new LuaCSFunction(ColliderWrap.get_material), new LuaCSFunction(ColliderWrap.set_material)),
			new LuaField("sharedMaterial", new LuaCSFunction(ColliderWrap.get_sharedMaterial), new LuaCSFunction(ColliderWrap.set_sharedMaterial)),
			new LuaField("bounds", new LuaCSFunction(ColliderWrap.get_bounds), null)
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Collider", typeof(Collider), regs, fields, typeof(Component));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateCollider(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Collider obj = new Collider();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Collider.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, ColliderWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, collider.enabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_attachedRigidbody(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attachedRigidbody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attachedRigidbody on a nil value");
			}
		}
		LuaScriptMgr.Push(L, collider.attachedRigidbody);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isTrigger(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTrigger on a nil value");
			}
		}
		LuaScriptMgr.Push(L, collider.isTrigger);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		LuaScriptMgr.Push(L, collider.material);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sharedMaterial(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
			}
		}
		LuaScriptMgr.Push(L, collider.sharedMaterial);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}
		LuaScriptMgr.Push(L, collider.bounds);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}
		collider.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isTrigger(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTrigger on a nil value");
			}
		}
		collider.isTrigger = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		collider.material = (PhysicMaterial)LuaScriptMgr.GetUnityObject(L, 3, typeof(PhysicMaterial));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMaterial(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Collider collider = (Collider)luaObject;
		if (collider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
			}
		}
		collider.sharedMaterial = (PhysicMaterial)LuaScriptMgr.GetUnityObject(L, 3, typeof(PhysicMaterial));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClosestPointOnBounds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Collider collider = (Collider)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Collider");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		Vector3 v = collider.ClosestPointOnBounds(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Collider collider = (Collider)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Collider");
		Ray ray = LuaScriptMgr.GetRay(L, 2);
		float distance = (float)LuaScriptMgr.GetNumber(L, 4);
		RaycastHit hit;
		bool b = collider.Raycast(ray, out hit, distance);
		LuaScriptMgr.Push(L, b);
		LuaScriptMgr.Push(L, hit);
		return 2;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object x = LuaScriptMgr.GetLuaObject(L, 1) as UnityEngine.Object;
		UnityEngine.Object y = LuaScriptMgr.GetLuaObject(L, 2) as UnityEngine.Object;
		bool b = x == y;
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
