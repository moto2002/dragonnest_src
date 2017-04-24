using LuaInterface;
using System;

public class TestProtolWrap
{
	private static Type classType = typeof(TestProtol);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(TestProtolWrap._CreateTestProtol)),
			new LuaMethod("GetClassType", new LuaCSFunction(TestProtolWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("data", new LuaCSFunction(TestProtolWrap.get_data), new LuaCSFunction(TestProtolWrap.set_data))
		};
		LuaScriptMgr.RegisterLib(L, "TestProtol", typeof(TestProtol), regs, fields, null);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTestProtol(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TestProtol class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, TestProtolWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_data(IntPtr L)
	{
		LuaScriptMgr.Push(L, TestProtol.data);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_data(IntPtr L)
	{
		TestProtol.data = LuaScriptMgr.GetStringBuffer(L, 3);
		return 0;
	}
}
