using LuaInterface;
using System;

public class LuaStringBufferWrap
{
	private static Type classType = typeof(LuaStringBuffer);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Set", new LuaCSFunction(LuaStringBufferWrap.Set)),
			new LuaMethod("Copy", new LuaCSFunction(LuaStringBufferWrap.Copy)),
			new LuaMethod("New", new LuaCSFunction(LuaStringBufferWrap._CreateLuaStringBuffer)),
			new LuaMethod("GetClassType", new LuaCSFunction(LuaStringBufferWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("buffer", new LuaCSFunction(LuaStringBufferWrap.get_buffer), new LuaCSFunction(LuaStringBufferWrap.set_buffer))
		};
		LuaScriptMgr.RegisterLib(L, "LuaStringBuffer", typeof(LuaStringBuffer), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaStringBuffer(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 0)
		{
			LuaStringBuffer lsb = new LuaStringBuffer();
			LuaScriptMgr.Push(L, lsb);
			return 1;
		}
		if (num == 1)
		{
			byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
			LuaStringBuffer lsb2 = new LuaStringBuffer(arrayNumber);
			LuaScriptMgr.Push(L, lsb2);
			return 1;
		}
		if (num == 2)
		{
			IntPtr source = (IntPtr)((long)LuaScriptMgr.GetNumber(L, 1));
			int len = (int)LuaScriptMgr.GetNumber(L, 2);
			LuaStringBuffer lsb3 = new LuaStringBuffer(source, len);
			LuaScriptMgr.Push(L, lsb3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: LuaStringBuffer.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaStringBufferWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buffer(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaStringBuffer luaStringBuffer = (LuaStringBuffer)luaObject;
		if (luaStringBuffer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buffer on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, luaStringBuffer.buffer);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buffer(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaStringBuffer luaStringBuffer = (LuaStringBuffer)luaObject;
		if (luaStringBuffer == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buffer on a nil value");
			}
		}
		luaStringBuffer.buffer = LuaScriptMgr.GetArrayNumber<byte>(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaStringBuffer luaStringBuffer = (LuaStringBuffer)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaStringBuffer");
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		luaStringBuffer.Set(arrayNumber);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Copy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LuaStringBuffer luaStringBuffer = (LuaStringBuffer)LuaScriptMgr.GetNetObjectSelf(L, 1, "LuaStringBuffer");
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		int length = (int)LuaScriptMgr.GetNumber(L, 3);
		luaStringBuffer.Copy(arrayNumber, length);
		return 0;
	}
}
