using LuaInterface;
using System;
using XUtliPoolLib;

public class XUtliPoolLib_XLuaLongWrap
{
	private static Type classType = typeof(XLuaLong);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Get", new LuaCSFunction(XUtliPoolLib_XLuaLongWrap.Get)),
			new LuaMethod("New", new LuaCSFunction(XUtliPoolLib_XLuaLongWrap._CreateXUtliPoolLib_XLuaLong)),
			new LuaMethod("GetClassType", new LuaCSFunction(XUtliPoolLib_XLuaLongWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("str", new LuaCSFunction(XUtliPoolLib_XLuaLongWrap.get_str), new LuaCSFunction(XUtliPoolLib_XLuaLongWrap.set_str))
		};
		LuaScriptMgr.RegisterLib(L, "XUtliPoolLib.XLuaLong", typeof(XLuaLong), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateXUtliPoolLib_XLuaLong(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			string luaString = LuaScriptMgr.GetLuaString(L, 1);
			XLuaLong o = new XLuaLong(luaString);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: XUtliPoolLib.XLuaLong.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, XUtliPoolLib_XLuaLongWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_str(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		XLuaLong xLuaLong = (XLuaLong)luaObject;
		if (xLuaLong == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name str");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index str on a nil value");
			}
		}
		LuaScriptMgr.Push(L, xLuaLong.str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_str(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		XLuaLong xLuaLong = (XLuaLong)luaObject;
		if (xLuaLong == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name str");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index str on a nil value");
			}
		}
		xLuaLong.str = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		XLuaLong xLuaLong = (XLuaLong)LuaScriptMgr.GetNetObjectSelf(L, 1, "XUtliPoolLib.XLuaLong");
		ulong d = xLuaLong.Get();
		LuaScriptMgr.Push(L, d);
		return 1;
	}
}
