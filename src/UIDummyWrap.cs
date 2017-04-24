using LuaInterface;
using System;
using UILib;
using UnityEngine;

public class UIDummyWrap
{
	private static Type classType = typeof(UIDummy);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnFill", new LuaCSFunction(UIDummyWrap.OnFill)),
			new LuaMethod("LateUpdate", new LuaCSFunction(UIDummyWrap.LateUpdate)),
			new LuaMethod("Reset", new LuaCSFunction(UIDummyWrap.Reset)),
			new LuaMethod("GetPanel", new LuaCSFunction(UIDummyWrap.GetPanel)),
			new LuaMethod("New", new LuaCSFunction(UIDummyWrap._CreateUIDummy)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIDummyWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIDummyWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("RenderQueue", new LuaCSFunction(UIDummyWrap.get_RenderQueue), null),
			new LuaField("RefreshRenderQueue", new LuaCSFunction(UIDummyWrap.get_RefreshRenderQueue), new LuaCSFunction(UIDummyWrap.set_RefreshRenderQueue))
		};
		LuaScriptMgr.RegisterLib(L, "UIDummy", typeof(UIDummy), regs, fields, typeof(UIWidget));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIDummy(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIDummy class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIDummyWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_RenderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIDummy uIDummy = (UIDummy)luaObject;
		if (uIDummy == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name RenderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index RenderQueue on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIDummy.RenderQueue);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_RefreshRenderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIDummy uIDummy = (UIDummy)luaObject;
		if (uIDummy == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name RefreshRenderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index RefreshRenderQueue on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIDummy.RefreshRenderQueue);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RefreshRenderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIDummy uIDummy = (UIDummy)luaObject;
		if (uIDummy == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name RefreshRenderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index RefreshRenderQueue on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIDummy.RefreshRenderQueue = (RefreshRenderQueueCb)LuaScriptMgr.GetNetObject(L, 3, typeof(RefreshRenderQueueCb));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIDummy.RefreshRenderQueue = delegate(int param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				object[] array = func.PopValues(oldTop);
				func.EndPCall(oldTop);
				return (bool)array[0];
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UIDummy uIDummy = (UIDummy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIDummy");
		BetterList<Vector3> verts = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(BetterList<Vector3>));
		BetterList<Vector2> uvs = (BetterList<Vector2>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<Vector2>));
		BetterList<Color32> cols = (BetterList<Color32>)LuaScriptMgr.GetNetObject(L, 4, typeof(BetterList<Color32>));
		uIDummy.OnFill(verts, uvs, cols);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LateUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIDummy uIDummy = (UIDummy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIDummy");
		uIDummy.LateUpdate();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIDummy uIDummy = (UIDummy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIDummy");
		uIDummy.Reset();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIDummy uIDummy = (UIDummy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIDummy");
		IXUIPanel panel = uIDummy.GetPanel();
		LuaScriptMgr.PushObject(L, panel);
		return 1;
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
