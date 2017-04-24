using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIGrid : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIGrid o = new UIGrid();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetChildList(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			BetterList<Transform> childList = uIGrid.GetChildList();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, childList);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetChild(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			Transform child = uIGrid.GetChild(index);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, child);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int AddChild(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
				Transform trans;
				LuaObject.checkType<Transform>(l, 2, out trans);
				uIGrid.AddChild(trans);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Transform), typeof(int)))
			{
				UIGrid uIGrid2 = (UIGrid)LuaObject.checkSelf(l);
				Transform trans2;
				LuaObject.checkType<Transform>(l, 2, out trans2);
				int index;
				LuaObject.checkType(l, 3, out index);
				uIGrid2.AddChild(trans2, index);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Transform), typeof(bool)))
			{
				UIGrid uIGrid3 = (UIGrid)LuaObject.checkSelf(l);
				Transform trans3;
				LuaObject.checkType<Transform>(l, 2, out trans3);
				bool sort;
				LuaObject.checkType(l, 3, out sort);
				uIGrid3.AddChild(trans3, sort);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int RemoveChild(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Transform)))
			{
				UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
				Transform t;
				LuaObject.checkType<Transform>(l, 2, out t);
				bool b = uIGrid.RemoveChild(t);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(int)))
			{
				UIGrid uIGrid2 = (UIGrid)LuaObject.checkSelf(l);
				int index;
				LuaObject.checkType(l, 2, out index);
				Transform o = uIGrid2.RemoveChild(index);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Reposition(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			uIGrid.Reposition();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int ConstrainWithinPanel(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			uIGrid.ConstrainWithinPanel();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int CloseList(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			uIGrid.CloseList();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SortByName_s(IntPtr l)
	{
		int result;
		try
		{
			Transform a;
			LuaObject.checkType<Transform>(l, 1, out a);
			Transform b;
			LuaObject.checkType<Transform>(l, 2, out b);
			int i = UIGrid.SortByName(a, b);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SortHorizontal_s(IntPtr l)
	{
		int result;
		try
		{
			Transform a;
			LuaObject.checkType<Transform>(l, 1, out a);
			Transform b;
			LuaObject.checkType<Transform>(l, 2, out b);
			int i = UIGrid.SortHorizontal(a, b);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SortVertical_s(IntPtr l)
	{
		int result;
		try
		{
			Transform a;
			LuaObject.checkType<Transform>(l, 1, out a);
			Transform b;
			LuaObject.checkType<Transform>(l, 2, out b);
			int i = UIGrid.SortVertical(a, b);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_arrangement(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIGrid.arrangement);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_arrangement(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			UIGrid.Arrangement arrangement;
			LuaObject.checkEnum<UIGrid.Arrangement>(l, 2, out arrangement);
			uIGrid.arrangement = arrangement;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_sorting(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIGrid.sorting);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_sorting(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			UIGrid.Sorting sorting;
			LuaObject.checkEnum<UIGrid.Sorting>(l, 2, out sorting);
			uIGrid.sorting = sorting;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_pivot(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIGrid.pivot);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pivot(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			UIWidget.Pivot pivot;
			LuaObject.checkEnum<UIWidget.Pivot>(l, 2, out pivot);
			uIGrid.pivot = pivot;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_reverse(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.reverse);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_reverse(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			bool reverse;
			LuaObject.checkType(l, 2, out reverse);
			uIGrid.reverse = reverse;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_maxPerLine(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.maxPerLine);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_maxPerLine(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			int maxPerLine;
			LuaObject.checkType(l, 2, out maxPerLine);
			uIGrid.maxPerLine = maxPerLine;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_cellWidth(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.cellWidth);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cellWidth(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			float cellWidth;
			LuaObject.checkType(l, 2, out cellWidth);
			uIGrid.cellWidth = cellWidth;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_cellHeight(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.cellHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cellHeight(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			float cellHeight;
			LuaObject.checkType(l, 2, out cellHeight);
			uIGrid.cellHeight = cellHeight;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_animateSmoothly(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.animateSmoothly);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_animateSmoothly(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			bool animateSmoothly;
			LuaObject.checkType(l, 2, out animateSmoothly);
			uIGrid.animateSmoothly = animateSmoothly;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_animateSmoothlySpeed(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.animateSmoothlySpeed);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_animateSmoothlySpeed(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			float animateSmoothlySpeed;
			LuaObject.checkType(l, 2, out animateSmoothlySpeed);
			uIGrid.animateSmoothlySpeed = animateSmoothlySpeed;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hideInactive(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.hideInactive);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_hideInactive(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			bool hideInactive;
			LuaObject.checkType(l, 2, out hideInactive);
			uIGrid.hideInactive = hideInactive;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_keepWithinPanel(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.keepWithinPanel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_keepWithinPanel(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			bool keepWithinPanel;
			LuaObject.checkType(l, 2, out keepWithinPanel);
			uIGrid.keepWithinPanel = keepWithinPanel;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onReposition(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			UIGrid.OnReposition onReposition;
			int num = LuaDelegation.checkDelegate(l, 2, out onReposition);
			if (num == 0)
			{
				uIGrid.onReposition = onReposition;
			}
			else if (num == 1)
			{
				UIGrid expr_30 = uIGrid;
				expr_30.onReposition = (UIGrid.OnReposition)Delegate.Combine(expr_30.onReposition, onReposition);
			}
			else if (num == 2)
			{
				UIGrid expr_53 = uIGrid;
				expr_53.onReposition = (UIGrid.OnReposition)Delegate.Remove(expr_53.onReposition, onReposition);
			}
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onCustomSort(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			BetterList<Transform>.CompareFunc compareFunc;
			int num = LuaDelegation.checkDelegate(l, 2, out compareFunc);
			if (num == 0)
			{
				uIGrid.onCustomSort = compareFunc;
			}
			else if (num == 1)
			{
				UIGrid expr_30 = uIGrid;
				expr_30.onCustomSort = (BetterList<Transform>.CompareFunc)Delegate.Combine(expr_30.onCustomSort, compareFunc);
			}
			else if (num == 2)
			{
				UIGrid expr_53 = uIGrid;
				expr_53.onCustomSort = (BetterList<Transform>.CompareFunc)Delegate.Remove(expr_53.onCustomSort, compareFunc);
			}
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_repositionNow(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			bool repositionNow;
			LuaObject.checkType(l, 2, out repositionNow);
			uIGrid.repositionNow = repositionNow;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_panel(IntPtr l)
	{
		int result;
		try
		{
			UIGrid uIGrid = (UIGrid)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIGrid.panel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIGrid");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.GetChildList));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.GetChild));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.AddChild));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.RemoveChild));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.Reposition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.ConstrainWithinPanel));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.CloseList));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.SortByName_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.SortHorizontal_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIGrid.SortVertical_s));
		LuaObject.addMember(l, "arrangement", new LuaCSFunction(Lua_UIGrid.get_arrangement), new LuaCSFunction(Lua_UIGrid.set_arrangement), true);
		LuaObject.addMember(l, "sorting", new LuaCSFunction(Lua_UIGrid.get_sorting), new LuaCSFunction(Lua_UIGrid.set_sorting), true);
		LuaObject.addMember(l, "pivot", new LuaCSFunction(Lua_UIGrid.get_pivot), new LuaCSFunction(Lua_UIGrid.set_pivot), true);
		LuaObject.addMember(l, "reverse", new LuaCSFunction(Lua_UIGrid.get_reverse), new LuaCSFunction(Lua_UIGrid.set_reverse), true);
		LuaObject.addMember(l, "maxPerLine", new LuaCSFunction(Lua_UIGrid.get_maxPerLine), new LuaCSFunction(Lua_UIGrid.set_maxPerLine), true);
		LuaObject.addMember(l, "cellWidth", new LuaCSFunction(Lua_UIGrid.get_cellWidth), new LuaCSFunction(Lua_UIGrid.set_cellWidth), true);
		LuaObject.addMember(l, "cellHeight", new LuaCSFunction(Lua_UIGrid.get_cellHeight), new LuaCSFunction(Lua_UIGrid.set_cellHeight), true);
		LuaObject.addMember(l, "animateSmoothly", new LuaCSFunction(Lua_UIGrid.get_animateSmoothly), new LuaCSFunction(Lua_UIGrid.set_animateSmoothly), true);
		LuaObject.addMember(l, "animateSmoothlySpeed", new LuaCSFunction(Lua_UIGrid.get_animateSmoothlySpeed), new LuaCSFunction(Lua_UIGrid.set_animateSmoothlySpeed), true);
		LuaObject.addMember(l, "hideInactive", new LuaCSFunction(Lua_UIGrid.get_hideInactive), new LuaCSFunction(Lua_UIGrid.set_hideInactive), true);
		LuaObject.addMember(l, "keepWithinPanel", new LuaCSFunction(Lua_UIGrid.get_keepWithinPanel), new LuaCSFunction(Lua_UIGrid.set_keepWithinPanel), true);
		LuaObject.addMember(l, "onReposition", null, new LuaCSFunction(Lua_UIGrid.set_onReposition), true);
		LuaObject.addMember(l, "onCustomSort", null, new LuaCSFunction(Lua_UIGrid.set_onCustomSort), true);
		LuaObject.addMember(l, "repositionNow", null, new LuaCSFunction(Lua_UIGrid.set_repositionNow), true);
		LuaObject.addMember(l, "panel", new LuaCSFunction(Lua_UIGrid.get_panel), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIGrid.constructor), typeof(UIGrid), typeof(UIWidgetContainer));
	}
}
