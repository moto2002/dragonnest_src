using LuaInterface;
using System;
using UnityEngine;

public class MeshRendererWrap
{
	private static Type classType = typeof(MeshRenderer);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(MeshRendererWrap._CreateMeshRenderer)),
			new LuaMethod("GetClassType", new LuaCSFunction(MeshRendererWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(MeshRendererWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[0];
		LuaScriptMgr.RegisterLib(L, "UnityEngine.MeshRenderer", typeof(MeshRenderer), regs, fields, typeof(Renderer));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateMeshRenderer(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			MeshRenderer obj = new MeshRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: MeshRenderer.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, MeshRendererWrap.classType);
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
