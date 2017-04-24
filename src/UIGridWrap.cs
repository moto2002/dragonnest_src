using LuaInterface;
using System;
using UnityEngine;

public class UIGridWrap
{
	private static Type classType = typeof(UIGrid);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetChildList", new LuaCSFunction(UIGridWrap.GetChildList)),
			new LuaMethod("GetChild", new LuaCSFunction(UIGridWrap.GetChild)),
			new LuaMethod("AddChild", new LuaCSFunction(UIGridWrap.AddChild)),
			new LuaMethod("RemoveChild", new LuaCSFunction(UIGridWrap.RemoveChild)),
			new LuaMethod("SortByName", new LuaCSFunction(UIGridWrap.SortByName)),
			new LuaMethod("SortHorizontal", new LuaCSFunction(UIGridWrap.SortHorizontal)),
			new LuaMethod("SortVertical", new LuaCSFunction(UIGridWrap.SortVertical)),
			new LuaMethod("Reposition", new LuaCSFunction(UIGridWrap.Reposition)),
			new LuaMethod("ConstrainWithinPanel", new LuaCSFunction(UIGridWrap.ConstrainWithinPanel)),
			new LuaMethod("CloseList", new LuaCSFunction(UIGridWrap.CloseList)),
			new LuaMethod("New", new LuaCSFunction(UIGridWrap._CreateUIGrid)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIGridWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIGridWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("arrangement", new LuaCSFunction(UIGridWrap.get_arrangement), new LuaCSFunction(UIGridWrap.set_arrangement)),
			new LuaField("sorting", new LuaCSFunction(UIGridWrap.get_sorting), new LuaCSFunction(UIGridWrap.set_sorting)),
			new LuaField("pivot", new LuaCSFunction(UIGridWrap.get_pivot), new LuaCSFunction(UIGridWrap.set_pivot)),
			new LuaField("reverse", new LuaCSFunction(UIGridWrap.get_reverse), new LuaCSFunction(UIGridWrap.set_reverse)),
			new LuaField("maxPerLine", new LuaCSFunction(UIGridWrap.get_maxPerLine), new LuaCSFunction(UIGridWrap.set_maxPerLine)),
			new LuaField("cellWidth", new LuaCSFunction(UIGridWrap.get_cellWidth), new LuaCSFunction(UIGridWrap.set_cellWidth)),
			new LuaField("cellHeight", new LuaCSFunction(UIGridWrap.get_cellHeight), new LuaCSFunction(UIGridWrap.set_cellHeight)),
			new LuaField("animateSmoothly", new LuaCSFunction(UIGridWrap.get_animateSmoothly), new LuaCSFunction(UIGridWrap.set_animateSmoothly)),
			new LuaField("animateSmoothlySpeed", new LuaCSFunction(UIGridWrap.get_animateSmoothlySpeed), new LuaCSFunction(UIGridWrap.set_animateSmoothlySpeed)),
			new LuaField("hideInactive", new LuaCSFunction(UIGridWrap.get_hideInactive), new LuaCSFunction(UIGridWrap.set_hideInactive)),
			new LuaField("keepWithinPanel", new LuaCSFunction(UIGridWrap.get_keepWithinPanel), new LuaCSFunction(UIGridWrap.set_keepWithinPanel)),
			new LuaField("onReposition", new LuaCSFunction(UIGridWrap.get_onReposition), new LuaCSFunction(UIGridWrap.set_onReposition)),
			new LuaField("onCustomSort", new LuaCSFunction(UIGridWrap.get_onCustomSort), new LuaCSFunction(UIGridWrap.set_onCustomSort)),
			new LuaField("repositionNow", null, new LuaCSFunction(UIGridWrap.set_repositionNow)),
			new LuaField("panel", new LuaCSFunction(UIGridWrap.get_panel), null)
		};
		LuaScriptMgr.RegisterLib(L, "UIGrid", typeof(UIGrid), regs, fields, typeof(UIWidgetContainer));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIGrid(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIGrid class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIGridWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_arrangement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name arrangement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index arrangement on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.arrangement);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sorting(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		LuaScriptMgr.Push(L, uIGrid.sorting);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pivot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pivot on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.pivot);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_reverse(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverse on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.reverse);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxPerLine(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxPerLine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxPerLine on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.maxPerLine);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cellWidth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellWidth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.cellWidth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cellHeight(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellHeight on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.cellHeight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animateSmoothly(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animateSmoothly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animateSmoothly on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.animateSmoothly);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animateSmoothlySpeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animateSmoothlySpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animateSmoothlySpeed on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.animateSmoothlySpeed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideInactive(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		LuaScriptMgr.Push(L, uIGrid.hideInactive);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepWithinPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		LuaScriptMgr.Push(L, uIGrid.keepWithinPanel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onReposition(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		LuaScriptMgr.Push(L, uIGrid.onReposition);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onCustomSort(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onCustomSort");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onCustomSort on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.onCustomSort);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_panel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name panel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index panel on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIGrid.panel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_arrangement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name arrangement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index arrangement on a nil value");
			}
		}
		uIGrid.arrangement = (UIGrid.Arrangement)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIGrid.Arrangement)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sorting(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		uIGrid.sorting = (UIGrid.Sorting)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIGrid.Sorting)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pivot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pivot on a nil value");
			}
		}
		uIGrid.pivot = (UIWidget.Pivot)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.Pivot)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_reverse(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverse on a nil value");
			}
		}
		uIGrid.reverse = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxPerLine(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxPerLine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxPerLine on a nil value");
			}
		}
		uIGrid.maxPerLine = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellWidth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellWidth on a nil value");
			}
		}
		uIGrid.cellWidth = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellHeight(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellHeight on a nil value");
			}
		}
		uIGrid.cellHeight = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animateSmoothly(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animateSmoothly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animateSmoothly on a nil value");
			}
		}
		uIGrid.animateSmoothly = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animateSmoothlySpeed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animateSmoothlySpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animateSmoothlySpeed on a nil value");
			}
		}
		uIGrid.animateSmoothlySpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideInactive(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		uIGrid.hideInactive = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepWithinPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		uIGrid.keepWithinPanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onReposition(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
			uIGrid.onReposition = (UIGrid.OnReposition)LuaScriptMgr.GetNetObject(L, 3, typeof(UIGrid.OnReposition));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIGrid.onReposition = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onCustomSort(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onCustomSort");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onCustomSort on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIGrid.onCustomSort = (BetterList<Transform>.CompareFunc)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<Transform>.CompareFunc));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIGrid.onCustomSort = delegate(Transform param0, Transform param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				object[] array = func.PopValues(oldTop);
				func.EndPCall(oldTop);
				return (int)array[0];
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_repositionNow(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIGrid uIGrid = (UIGrid)luaObject;
		if (uIGrid == null)
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
		uIGrid.repositionNow = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
		BetterList<Transform> childList = uIGrid.GetChildList();
		LuaScriptMgr.PushObject(L, childList);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
		int index = (int)LuaScriptMgr.GetNumber(L, 2);
		Transform child = uIGrid.GetChild(index);
		LuaScriptMgr.Push(L, child);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddChild(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
			Transform trans = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
			uIGrid.AddChild(trans);
			return 0;
		}
		if (num == 3)
		{
			UIGrid uIGrid2 = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
			Transform trans2 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
			int index = (int)LuaScriptMgr.GetNumber(L, 3);
			uIGrid2.AddChild(trans2, index);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIGrid.AddChild");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveChild(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIGrid), typeof(Transform)))
		{
			UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
			Transform t = (Transform)LuaScriptMgr.GetLuaObject(L, 2);
			bool b = uIGrid.RemoveChild(t);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIGrid), typeof(int)))
		{
			UIGrid uIGrid2 = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
			int index = (int)LuaDLL.lua_tonumber(L, 2);
			Transform obj = uIGrid2.RemoveChild(index);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIGrid.RemoveChild");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortByName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform a = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Transform b = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		int d = UIGrid.SortByName(a, b);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortHorizontal(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform a = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Transform b = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		int d = UIGrid.SortHorizontal(a, b);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortVertical(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform a = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Transform b = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		int d = UIGrid.SortVertical(a, b);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reposition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
		uIGrid.Reposition();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConstrainWithinPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
		uIGrid.ConstrainWithinPanel();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CloseList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIGrid uIGrid = (UIGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIGrid");
		uIGrid.CloseList();
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
