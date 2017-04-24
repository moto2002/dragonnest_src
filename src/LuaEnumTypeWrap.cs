using LuaInterface;
using System;

public class LuaEnumTypeWrap
{
	private static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("AAA", new LuaCSFunction(LuaEnumTypeWrap.GetAAA)),
		new LuaMethod("BBB", new LuaCSFunction(LuaEnumTypeWrap.GetBBB)),
		new LuaMethod("CCC", new LuaCSFunction(LuaEnumTypeWrap.GetCCC)),
		new LuaMethod("DDD", new LuaCSFunction(LuaEnumTypeWrap.GetDDD)),
		new LuaMethod("IntToEnum", new LuaCSFunction(LuaEnumTypeWrap.IntToEnum))
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "LuaEnumType", typeof(LuaEnumType), LuaEnumTypeWrap.enums);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAAA(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaEnumType.AAA);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBBB(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaEnumType.BBB);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCCC(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaEnumType.CCC);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDDD(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaEnumType.DDD);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		LuaEnumType luaEnumType = (LuaEnumType)num;
		LuaScriptMgr.Push(L, luaEnumType);
		return 1;
	}
}
