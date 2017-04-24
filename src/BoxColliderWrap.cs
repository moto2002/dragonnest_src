using LuaInterface;
using System;
using UnityEngine;

public class BoxColliderWrap
{
	private static Type classType = typeof(BoxCollider);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(BoxColliderWrap._CreateBoxCollider)),
			new LuaMethod("GetClassType", new LuaCSFunction(BoxColliderWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(BoxColliderWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("center", new LuaCSFunction(BoxColliderWrap.get_center), new LuaCSFunction(BoxColliderWrap.set_center)),
			new LuaField("size", new LuaCSFunction(BoxColliderWrap.get_size), new LuaCSFunction(BoxColliderWrap.set_size))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.BoxCollider", typeof(BoxCollider), regs, fields, typeof(Collider));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateBoxCollider(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			BoxCollider obj = new BoxCollider();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: BoxCollider.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, BoxColliderWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_center(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		BoxCollider boxCollider = (BoxCollider)luaObject;
		if (boxCollider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name center");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index center on a nil value");
			}
		}
		LuaScriptMgr.Push(L, boxCollider.center);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_size(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		BoxCollider boxCollider = (BoxCollider)luaObject;
		if (boxCollider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name size");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index size on a nil value");
			}
		}
		LuaScriptMgr.Push(L, boxCollider.size);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_center(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		BoxCollider boxCollider = (BoxCollider)luaObject;
		if (boxCollider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name center");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index center on a nil value");
			}
		}
		boxCollider.center = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_size(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		BoxCollider boxCollider = (BoxCollider)luaObject;
		if (boxCollider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name size");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index size on a nil value");
			}
		}
		boxCollider.size = LuaScriptMgr.GetVector3(L, 3);
		return 0;
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
