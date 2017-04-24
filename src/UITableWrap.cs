using LuaInterface;
using System;
using UnityEngine;

public class UITableWrap
{
	private static Type classType = typeof(UITable);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Reposition", new LuaCSFunction(UITableWrap.Reposition)),
			new LuaMethod("RepositionOnlyOneLevel", new LuaCSFunction(UITableWrap.RepositionOnlyOneLevel)),
			new LuaMethod("New", new LuaCSFunction(UITableWrap._CreateUITable)),
			new LuaMethod("GetClassType", new LuaCSFunction(UITableWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UITableWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("columns", new LuaCSFunction(UITableWrap.get_columns), new LuaCSFunction(UITableWrap.set_columns)),
			new LuaField("direction", new LuaCSFunction(UITableWrap.get_direction), new LuaCSFunction(UITableWrap.set_direction)),
			new LuaField("sorting", new LuaCSFunction(UITableWrap.get_sorting), new LuaCSFunction(UITableWrap.set_sorting)),
			new LuaField("hideInactive", new LuaCSFunction(UITableWrap.get_hideInactive), new LuaCSFunction(UITableWrap.set_hideInactive)),
			new LuaField("keepWithinPanel", new LuaCSFunction(UITableWrap.get_keepWithinPanel), new LuaCSFunction(UITableWrap.set_keepWithinPanel)),
			new LuaField("padding", new LuaCSFunction(UITableWrap.get_padding), new LuaCSFunction(UITableWrap.set_padding)),
			new LuaField("onReposition", new LuaCSFunction(UITableWrap.get_onReposition), new LuaCSFunction(UITableWrap.set_onReposition)),
			new LuaField("repositionNow", null, new LuaCSFunction(UITableWrap.set_repositionNow)),
			new LuaField("children", new LuaCSFunction(UITableWrap.get_children), null)
		};
		LuaScriptMgr.RegisterLib(L, "UITable", typeof(UITable), regs, fields, typeof(UIWidgetContainer));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUITable(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UITable class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UITableWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_columns(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name columns");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index columns on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.columns);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_direction(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name direction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index direction on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.direction);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sorting(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sorting");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sorting on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.sorting);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideInactive(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hideInactive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hideInactive on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.hideInactive);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepWithinPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keepWithinPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keepWithinPanel on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.keepWithinPanel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_padding(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name padding");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index padding on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.padding);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onReposition(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onReposition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onReposition on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITable.onReposition);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_children(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name children");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index children on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uITable.children);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_columns(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name columns");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index columns on a nil value");
			}
		}
		uITable.columns = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_direction(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name direction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index direction on a nil value");
			}
		}
		uITable.direction = (UITable.Direction)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UITable.Direction)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sorting(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sorting");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sorting on a nil value");
			}
		}
		uITable.sorting = (UITable.Sorting)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UITable.Sorting)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideInactive(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hideInactive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hideInactive on a nil value");
			}
		}
		uITable.hideInactive = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepWithinPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keepWithinPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keepWithinPanel on a nil value");
			}
		}
		uITable.keepWithinPanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_padding(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name padding");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index padding on a nil value");
			}
		}
		uITable.padding = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onReposition(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onReposition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onReposition on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uITable.onReposition = (UITable.OnReposition)LuaScriptMgr.GetNetObject(L, 3, typeof(UITable.OnReposition));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uITable.onReposition = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_repositionNow(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITable uITable = (UITable)luaObject;
		if (uITable == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name repositionNow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index repositionNow on a nil value");
			}
		}
		uITable.repositionNow = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reposition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITable uITable = (UITable)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITable");
		uITable.Reposition();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RepositionOnlyOneLevel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITable uITable = (UITable)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITable");
		uITable.RepositionOnlyOneLevel();
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
