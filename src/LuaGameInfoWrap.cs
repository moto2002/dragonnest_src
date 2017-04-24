using LuaInterface;
using System;

public class LuaGameInfoWrap
{
	private static Type classType = typeof(LuaGameInfo);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(LuaGameInfoWrap._CreateLuaGameInfo)),
			new LuaMethod("GetClassType", new LuaCSFunction(LuaGameInfoWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("single", new LuaCSFunction(LuaGameInfoWrap.get_single), null),
			new LuaField("name", new LuaCSFunction(LuaGameInfoWrap.get_name), new LuaCSFunction(LuaGameInfoWrap.set_name)),
			new LuaField("exp", new LuaCSFunction(LuaGameInfoWrap.get_exp), new LuaCSFunction(LuaGameInfoWrap.set_exp)),
			new LuaField("maxexp", new LuaCSFunction(LuaGameInfoWrap.get_maxexp), new LuaCSFunction(LuaGameInfoWrap.set_maxexp)),
			new LuaField("level", new LuaCSFunction(LuaGameInfoWrap.get_level), new LuaCSFunction(LuaGameInfoWrap.set_level)),
			new LuaField("ppt", new LuaCSFunction(LuaGameInfoWrap.get_ppt), new LuaCSFunction(LuaGameInfoWrap.set_ppt)),
			new LuaField("coin", new LuaCSFunction(LuaGameInfoWrap.get_coin), new LuaCSFunction(LuaGameInfoWrap.set_coin)),
			new LuaField("dia", new LuaCSFunction(LuaGameInfoWrap.get_dia), new LuaCSFunction(LuaGameInfoWrap.set_dia)),
			new LuaField("energy", new LuaCSFunction(LuaGameInfoWrap.get_energy), new LuaCSFunction(LuaGameInfoWrap.set_energy)),
			new LuaField("draggon", new LuaCSFunction(LuaGameInfoWrap.get_draggon), new LuaCSFunction(LuaGameInfoWrap.set_draggon))
		};
		LuaScriptMgr.RegisterLib(L, "LuaGameInfo", typeof(LuaGameInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaGameInfo(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			LuaGameInfo o = new LuaGameInfo();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: LuaGameInfo.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaGameInfoWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_single(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, LuaGameInfo.single);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_name(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.name);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_exp(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name exp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index exp on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.exp);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxexp(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxexp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxexp on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.maxexp);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_level(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.level);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ppt(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ppt");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ppt on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.ppt);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_coin(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name coin");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index coin on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.coin);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dia(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dia");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dia on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.dia);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_energy(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name energy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index energy on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.energy);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_draggon(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name draggon");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index draggon on a nil value");
			}
		}
		LuaScriptMgr.Push(L, luaGameInfo.draggon);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_name(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}
		luaGameInfo.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_exp(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name exp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index exp on a nil value");
			}
		}
		luaGameInfo.exp = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxexp(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxexp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxexp on a nil value");
			}
		}
		luaGameInfo.maxexp = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_level(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}
		luaGameInfo.level = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ppt(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ppt");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ppt on a nil value");
			}
		}
		luaGameInfo.ppt = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_coin(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name coin");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index coin on a nil value");
			}
		}
		luaGameInfo.coin = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dia(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dia");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dia on a nil value");
			}
		}
		luaGameInfo.dia = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_energy(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name energy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index energy on a nil value");
			}
		}
		luaGameInfo.energy = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_draggon(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGameInfo luaGameInfo = (LuaGameInfo)luaObject;
		if (luaGameInfo == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name draggon");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index draggon on a nil value");
			}
		}
		luaGameInfo.draggon = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}
