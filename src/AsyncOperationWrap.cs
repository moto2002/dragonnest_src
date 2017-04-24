using LuaInterface;
using System;
using UnityEngine;

public class AsyncOperationWrap
{
	private static Type classType = typeof(AsyncOperation);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(AsyncOperationWrap._CreateAsyncOperation)),
			new LuaMethod("GetClassType", new LuaCSFunction(AsyncOperationWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("isDone", new LuaCSFunction(AsyncOperationWrap.get_isDone), null),
			new LuaField("progress", new LuaCSFunction(AsyncOperationWrap.get_progress), null),
			new LuaField("priority", new LuaCSFunction(AsyncOperationWrap.get_priority), new LuaCSFunction(AsyncOperationWrap.set_priority)),
			new LuaField("allowSceneActivation", new LuaCSFunction(AsyncOperationWrap.get_allowSceneActivation), new LuaCSFunction(AsyncOperationWrap.set_allowSceneActivation))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AsyncOperation", typeof(AsyncOperation), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAsyncOperation(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			AsyncOperation o = new AsyncOperation();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: AsyncOperation.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, AsyncOperationWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDone(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation asyncOperation = (AsyncOperation)luaObject;
		if (asyncOperation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDone");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDone on a nil value");
			}
		}
		LuaScriptMgr.Push(L, asyncOperation.isDone);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_progress(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation asyncOperation = (AsyncOperation)luaObject;
		if (asyncOperation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name progress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index progress on a nil value");
			}
		}
		LuaScriptMgr.Push(L, asyncOperation.progress);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_priority(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation asyncOperation = (AsyncOperation)luaObject;
		if (asyncOperation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}
		LuaScriptMgr.Push(L, asyncOperation.priority);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allowSceneActivation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation asyncOperation = (AsyncOperation)luaObject;
		if (asyncOperation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowSceneActivation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowSceneActivation on a nil value");
			}
		}
		LuaScriptMgr.Push(L, asyncOperation.allowSceneActivation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_priority(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation asyncOperation = (AsyncOperation)luaObject;
		if (asyncOperation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}
		asyncOperation.priority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_allowSceneActivation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation asyncOperation = (AsyncOperation)luaObject;
		if (asyncOperation == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowSceneActivation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowSceneActivation on a nil value");
			}
		}
		asyncOperation.allowSceneActivation = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}
