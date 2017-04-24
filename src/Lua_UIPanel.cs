using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIPanel : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIPanel o = new UIPanel();
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
	public static int GetSides(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Transform relativeTo;
			LuaObject.checkType<Transform>(l, 2, out relativeTo);
			Vector3[] sides = uIPanel.GetSides(relativeTo);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, sides);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Invalidate(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool includeChildren;
			LuaObject.checkType(l, 2, out includeChildren);
			uIPanel.Invalidate(includeChildren);
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
	public static int CalculateFinalAlpha(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			int frameID;
			LuaObject.checkType(l, 2, out frameID);
			float o = uIPanel.CalculateFinalAlpha(frameID);
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
	public static int SetRect(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			float x;
			LuaObject.checkType(l, 2, out x);
			float y;
			LuaObject.checkType(l, 3, out y);
			float width;
			LuaObject.checkType(l, 4, out width);
			float height;
			LuaObject.checkType(l, 5, out height);
			uIPanel.SetRect(x, y, width, height);
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
	public static int IsVisible(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, num, 2, typeof(UIWidget)))
			{
				UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
				UIWidget w;
				LuaObject.checkType<UIWidget>(l, 2, out w);
				bool b = uIPanel.IsVisible(w);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Vector3)))
			{
				UIPanel uIPanel2 = (UIPanel)LuaObject.checkSelf(l);
				Vector3 worldPos;
				LuaObject.checkType(l, 2, out worldPos);
				bool b2 = uIPanel2.IsVisible(worldPos);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b2);
				result = 2;
			}
			else if (num == 5)
			{
				UIPanel uIPanel3 = (UIPanel)LuaObject.checkSelf(l);
				Vector3 a;
				LuaObject.checkType(l, 2, out a);
				Vector3 b3;
				LuaObject.checkType(l, 3, out b3);
				Vector3 c;
				LuaObject.checkType(l, 4, out c);
				Vector3 d;
				LuaObject.checkType(l, 5, out d);
				bool b4 = uIPanel3.IsVisible(a, b3, c, d);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b4);
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
	public static int Affects(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIWidget w;
			LuaObject.checkType<UIWidget>(l, 2, out w);
			bool b = uIPanel.Affects(w);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int RebuildAllDrawCalls(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.RebuildAllDrawCalls();
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
	public static int SetDirty(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.SetDirty();
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
	public static int SetEnable(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.SetEnable();
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
	public static int ParentHasChanged(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.ParentHasChanged();
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
	public static int SetPanel(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIPanel panel;
			LuaObject.checkType<UIPanel>(l, 2, out panel);
			uIPanel.SetPanel(panel);
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
	public static int UpdateNeedUpdate(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.UpdateNeedUpdate();
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
	public static int SortWidgets(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.SortWidgets();
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
	public static int FindDrawCall(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIWidget w;
			LuaObject.checkType<UIWidget>(l, 2, out w);
			UIDrawCall o = uIPanel.FindDrawCall(w);
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
	public static int AddWidget(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIWidget w;
			LuaObject.checkType<UIWidget>(l, 2, out w);
			uIPanel.AddWidget(w);
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
	public static int RemoveWidget(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIWidget w;
			LuaObject.checkType<UIWidget>(l, 2, out w);
			uIPanel.RemoveWidget(w);
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
	public static int Refresh(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			uIPanel.Refresh();
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
	public static int CalculateConstrainOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Vector2 min;
			LuaObject.checkType(l, 2, out min);
			Vector2 max;
			LuaObject.checkType(l, 3, out max);
			Vector3 o = uIPanel.CalculateConstrainOffset(min, max);
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
	public static int ConstrainTargetToBounds(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 3)
			{
				UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
				Transform target;
				LuaObject.checkType<Transform>(l, 2, out target);
				bool immediate;
				LuaObject.checkType(l, 3, out immediate);
				bool b = uIPanel.ConstrainTargetToBounds(target, immediate);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (num == 4)
			{
				UIPanel uIPanel2 = (UIPanel)LuaObject.checkSelf(l);
				Transform target2;
				LuaObject.checkType<Transform>(l, 2, out target2);
				Bounds bounds;
				LuaObject.checkValueType<Bounds>(l, 3, out bounds);
				bool immediate2;
				LuaObject.checkType(l, 4, out immediate2);
				bool b2 = uIPanel2.ConstrainTargetToBounds(target2, ref bounds, immediate2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b2);
				LuaObject.pushValue(l, bounds);
				result = 3;
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
	public static int GetViewSize(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Vector2 viewSize = uIPanel.GetViewSize();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, viewSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int CompareFunc_s(IntPtr l)
	{
		int result;
		try
		{
			UIPanel a;
			LuaObject.checkType<UIPanel>(l, 1, out a);
			UIPanel b;
			LuaObject.checkType<UIPanel>(l, 2, out b);
			int i = UIPanel.CompareFunc(a, b);
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
	public static int Find_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				Transform trans;
				LuaObject.checkType<Transform>(l, 1, out trans);
				UIPanel o = UIPanel.Find(trans);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 2)
			{
				Transform trans2;
				LuaObject.checkType<Transform>(l, 1, out trans2);
				bool createIfMissing;
				LuaObject.checkType(l, 2, out createIfMissing);
				UIPanel o2 = UIPanel.Find(trans2, createIfMissing);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
				result = 2;
			}
			else if (num == 3)
			{
				Transform trans3;
				LuaObject.checkType<Transform>(l, 1, out trans3);
				bool createIfMissing2;
				LuaObject.checkType(l, 2, out createIfMissing2);
				int layer;
				LuaObject.checkType(l, 3, out layer);
				UIPanel o3 = UIPanel.Find(trans3, createIfMissing2, layer);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o3);
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
	public static int get_list(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIPanel.list);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_list(IntPtr l)
	{
		int result;
		try
		{
			BetterList<UIPanel> list;
			LuaObject.checkType<BetterList<UIPanel>>(l, 2, out list);
			UIPanel.list = list;
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
	public static int set_onGeometryUpdated(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIPanel.OnGeometryUpdated onGeometryUpdated;
			int num = LuaDelegation.checkDelegate(l, 2, out onGeometryUpdated);
			if (num == 0)
			{
				uIPanel.onGeometryUpdated = onGeometryUpdated;
			}
			else if (num == 1)
			{
				UIPanel expr_30 = uIPanel;
				expr_30.onGeometryUpdated = (UIPanel.OnGeometryUpdated)Delegate.Combine(expr_30.onGeometryUpdated, onGeometryUpdated);
			}
			else if (num == 2)
			{
				UIPanel expr_53 = uIPanel;
				expr_53.onGeometryUpdated = (UIPanel.OnGeometryUpdated)Delegate.Remove(expr_53.onGeometryUpdated, onGeometryUpdated);
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
	public static int get_showVertexCount(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.showVertexCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_showVertexCount(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool showVertexCount;
			LuaObject.checkType(l, 2, out showVertexCount);
			uIPanel.showVertexCount = showVertexCount;
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
	public static int get_vertexCount(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.vertexCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_vertexCount(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			int vertexCount;
			LuaObject.checkType(l, 2, out vertexCount);
			uIPanel.vertexCount = vertexCount;
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
	public static int get_showInPanelTool(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.showInPanelTool);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_showInPanelTool(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool showInPanelTool;
			LuaObject.checkType(l, 2, out showInPanelTool);
			uIPanel.showInPanelTool = showInPanelTool;
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
	public static int get_generateNormals(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.generateNormals);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_generateNormals(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool generateNormals;
			LuaObject.checkType(l, 2, out generateNormals);
			uIPanel.generateNormals = generateNormals;
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
	public static int get_widgetsAreStatic(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.widgetsAreStatic);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_widgetsAreStatic(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool widgetsAreStatic;
			LuaObject.checkType(l, 2, out widgetsAreStatic);
			uIPanel.widgetsAreStatic = widgetsAreStatic;
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
	public static int get_cullWhileDragging(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.cullWhileDragging);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cullWhileDragging(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool cullWhileDragging;
			LuaObject.checkType(l, 2, out cullWhileDragging);
			uIPanel.cullWhileDragging = cullWhileDragging;
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
	public static int get_alwaysOnScreen(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.alwaysOnScreen);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_alwaysOnScreen(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool alwaysOnScreen;
			LuaObject.checkType(l, 2, out alwaysOnScreen);
			uIPanel.alwaysOnScreen = alwaysOnScreen;
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
	public static int get_anchorOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.anchorOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_anchorOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool anchorOffset;
			LuaObject.checkType(l, 2, out anchorOffset);
			uIPanel.anchorOffset = anchorOffset;
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
	public static int get_renderQueue(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPanel.renderQueue);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_renderQueue(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIPanel.RenderQueue renderQueue;
			LuaObject.checkEnum<UIPanel.RenderQueue>(l, 2, out renderQueue);
			uIPanel.renderQueue = renderQueue;
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
	public static int get_startingRenderQueue(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.startingRenderQueue);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_startingRenderQueue(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			int startingRenderQueue;
			LuaObject.checkType(l, 2, out startingRenderQueue);
			uIPanel.startingRenderQueue = startingRenderQueue;
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
	public static int get_widgets(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.widgets);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_widgets(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			BetterList<UIWidget> widgets;
			LuaObject.checkType<BetterList<UIWidget>>(l, 2, out widgets);
			uIPanel.widgets = widgets;
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
	public static int get_drawCalls(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.drawCalls);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_drawCalls(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			BetterList<UIDrawCall> drawCalls;
			LuaObject.checkType<BetterList<UIDrawCall>>(l, 2, out drawCalls);
			uIPanel.drawCalls = drawCalls;
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
	public static int get_worldToLocal(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.worldToLocal);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_worldToLocal(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Matrix4x4 worldToLocal;
			LuaObject.checkValueType<Matrix4x4>(l, 2, out worldToLocal);
			uIPanel.worldToLocal = worldToLocal;
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
	public static int get_drawCallClipRange(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.drawCallClipRange);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_drawCallClipRange(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Vector4 drawCallClipRange;
			LuaObject.checkType(l, 2, out drawCallClipRange);
			uIPanel.drawCallClipRange = drawCallClipRange;
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
	public static int set_onClipMove(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIPanel.OnClippingMoved onClippingMoved;
			int num = LuaDelegation.checkDelegate(l, 2, out onClippingMoved);
			if (num == 0)
			{
				uIPanel.onClipMove = onClippingMoved;
			}
			else if (num == 1)
			{
				UIPanel expr_30 = uIPanel;
				expr_30.onClipMove = (UIPanel.OnClippingMoved)Delegate.Combine(expr_30.onClipMove, onClippingMoved);
			}
			else if (num == 2)
			{
				UIPanel expr_53 = uIPanel;
				expr_53.onClipMove = (UIPanel.OnClippingMoved)Delegate.Remove(expr_53.onClipMove, onClippingMoved);
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
	public static int get_NeedUpdate(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.NeedUpdate);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_NeedUpdate(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool needUpdate;
			LuaObject.checkType(l, 2, out needUpdate);
			uIPanel.NeedUpdate = needUpdate;
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
	public static int get_mNeedUpdateRuntime(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.mNeedUpdateRuntime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mNeedUpdateRuntime(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			bool mNeedUpdateRuntime;
			LuaObject.checkType(l, 2, out mNeedUpdateRuntime);
			uIPanel.mNeedUpdateRuntime = mNeedUpdateRuntime;
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
	public static int get_updateFrame(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.updateFrame);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_updateFrame(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			int updateFrame;
			LuaObject.checkType(l, 2, out updateFrame);
			uIPanel.updateFrame = updateFrame;
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
	public static int get_nextUnusedDepth(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIPanel.nextUnusedDepth);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_canBeAnchored(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.canBeAnchored);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_alpha(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.alpha);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_alpha(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			float alpha;
			LuaObject.checkType(l, 2, out alpha);
			uIPanel.alpha = alpha;
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
	public static int get_depth(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.depth);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_depth(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			int depth;
			LuaObject.checkType(l, 2, out depth);
			uIPanel.depth = depth;
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
	public static int get_sortingOrder(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.sortingOrder);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_sortingOrder(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			int sortingOrder;
			LuaObject.checkType(l, 2, out sortingOrder);
			uIPanel.sortingOrder = sortingOrder;
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
	public static int get_width(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.width);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_height(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.height);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_halfPixelOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.halfPixelOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_usedForUI(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.usedForUI);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_drawCallOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.drawCallOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_clipping(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPanel.clipping);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_clipping(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			UIDrawCall.Clipping clipping;
			LuaObject.checkEnum<UIDrawCall.Clipping>(l, 2, out clipping);
			uIPanel.clipping = clipping;
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
	public static int get_parentPanel(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.parentPanel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_clipCount(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.clipCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hasClipping(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.hasClipping);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hasCumulativeClipping(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.hasCumulativeClipping);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_clipOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.clipOffset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_clipOffset(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Vector2 clipOffset;
			LuaObject.checkType(l, 2, out clipOffset);
			uIPanel.clipOffset = clipOffset;
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
	public static int get_baseClipRegion(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.baseClipRegion);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_baseClipRegion(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Vector4 baseClipRegion;
			LuaObject.checkType(l, 2, out baseClipRegion);
			uIPanel.baseClipRegion = baseClipRegion;
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
	public static int get_finalClipRegion(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.finalClipRegion);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_clipSoftness(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.clipSoftness);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_clipSoftness(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			Vector2 clipSoftness;
			LuaObject.checkType(l, 2, out clipSoftness);
			uIPanel.clipSoftness = clipSoftness;
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
	public static int get_localCorners(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.localCorners);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_worldCorners(IntPtr l)
	{
		int result;
		try
		{
			UIPanel uIPanel = (UIPanel)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPanel.worldCorners);
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
		LuaObject.getTypeTable(l, "UIPanel");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.GetSides));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.Invalidate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.CalculateFinalAlpha));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.SetRect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.IsVisible));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.Affects));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.RebuildAllDrawCalls));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.SetDirty));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.SetEnable));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.ParentHasChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.SetPanel));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.UpdateNeedUpdate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.SortWidgets));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.FindDrawCall));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.AddWidget));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.RemoveWidget));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.Refresh));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.CalculateConstrainOffset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.ConstrainTargetToBounds));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.GetViewSize));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.CompareFunc_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPanel.Find_s));
		LuaObject.addMember(l, "list", new LuaCSFunction(Lua_UIPanel.get_list), new LuaCSFunction(Lua_UIPanel.set_list), false);
		LuaObject.addMember(l, "onGeometryUpdated", null, new LuaCSFunction(Lua_UIPanel.set_onGeometryUpdated), true);
		LuaObject.addMember(l, "showVertexCount", new LuaCSFunction(Lua_UIPanel.get_showVertexCount), new LuaCSFunction(Lua_UIPanel.set_showVertexCount), true);
		LuaObject.addMember(l, "vertexCount", new LuaCSFunction(Lua_UIPanel.get_vertexCount), new LuaCSFunction(Lua_UIPanel.set_vertexCount), true);
		LuaObject.addMember(l, "showInPanelTool", new LuaCSFunction(Lua_UIPanel.get_showInPanelTool), new LuaCSFunction(Lua_UIPanel.set_showInPanelTool), true);
		LuaObject.addMember(l, "generateNormals", new LuaCSFunction(Lua_UIPanel.get_generateNormals), new LuaCSFunction(Lua_UIPanel.set_generateNormals), true);
		LuaObject.addMember(l, "widgetsAreStatic", new LuaCSFunction(Lua_UIPanel.get_widgetsAreStatic), new LuaCSFunction(Lua_UIPanel.set_widgetsAreStatic), true);
		LuaObject.addMember(l, "cullWhileDragging", new LuaCSFunction(Lua_UIPanel.get_cullWhileDragging), new LuaCSFunction(Lua_UIPanel.set_cullWhileDragging), true);
		LuaObject.addMember(l, "alwaysOnScreen", new LuaCSFunction(Lua_UIPanel.get_alwaysOnScreen), new LuaCSFunction(Lua_UIPanel.set_alwaysOnScreen), true);
		LuaObject.addMember(l, "anchorOffset", new LuaCSFunction(Lua_UIPanel.get_anchorOffset), new LuaCSFunction(Lua_UIPanel.set_anchorOffset), true);
		LuaObject.addMember(l, "renderQueue", new LuaCSFunction(Lua_UIPanel.get_renderQueue), new LuaCSFunction(Lua_UIPanel.set_renderQueue), true);
		LuaObject.addMember(l, "startingRenderQueue", new LuaCSFunction(Lua_UIPanel.get_startingRenderQueue), new LuaCSFunction(Lua_UIPanel.set_startingRenderQueue), true);
		LuaObject.addMember(l, "widgets", new LuaCSFunction(Lua_UIPanel.get_widgets), new LuaCSFunction(Lua_UIPanel.set_widgets), true);
		LuaObject.addMember(l, "drawCalls", new LuaCSFunction(Lua_UIPanel.get_drawCalls), new LuaCSFunction(Lua_UIPanel.set_drawCalls), true);
		LuaObject.addMember(l, "worldToLocal", new LuaCSFunction(Lua_UIPanel.get_worldToLocal), new LuaCSFunction(Lua_UIPanel.set_worldToLocal), true);
		LuaObject.addMember(l, "drawCallClipRange", new LuaCSFunction(Lua_UIPanel.get_drawCallClipRange), new LuaCSFunction(Lua_UIPanel.set_drawCallClipRange), true);
		LuaObject.addMember(l, "onClipMove", null, new LuaCSFunction(Lua_UIPanel.set_onClipMove), true);
		LuaObject.addMember(l, "NeedUpdate", new LuaCSFunction(Lua_UIPanel.get_NeedUpdate), new LuaCSFunction(Lua_UIPanel.set_NeedUpdate), true);
		LuaObject.addMember(l, "mNeedUpdateRuntime", new LuaCSFunction(Lua_UIPanel.get_mNeedUpdateRuntime), new LuaCSFunction(Lua_UIPanel.set_mNeedUpdateRuntime), true);
		LuaObject.addMember(l, "updateFrame", new LuaCSFunction(Lua_UIPanel.get_updateFrame), new LuaCSFunction(Lua_UIPanel.set_updateFrame), true);
		LuaObject.addMember(l, "nextUnusedDepth", new LuaCSFunction(Lua_UIPanel.get_nextUnusedDepth), null, false);
		LuaObject.addMember(l, "canBeAnchored", new LuaCSFunction(Lua_UIPanel.get_canBeAnchored), null, true);
		LuaObject.addMember(l, "alpha", new LuaCSFunction(Lua_UIPanel.get_alpha), new LuaCSFunction(Lua_UIPanel.set_alpha), true);
		LuaObject.addMember(l, "depth", new LuaCSFunction(Lua_UIPanel.get_depth), new LuaCSFunction(Lua_UIPanel.set_depth), true);
		LuaObject.addMember(l, "sortingOrder", new LuaCSFunction(Lua_UIPanel.get_sortingOrder), new LuaCSFunction(Lua_UIPanel.set_sortingOrder), true);
		LuaObject.addMember(l, "width", new LuaCSFunction(Lua_UIPanel.get_width), null, true);
		LuaObject.addMember(l, "height", new LuaCSFunction(Lua_UIPanel.get_height), null, true);
		LuaObject.addMember(l, "halfPixelOffset", new LuaCSFunction(Lua_UIPanel.get_halfPixelOffset), null, true);
		LuaObject.addMember(l, "usedForUI", new LuaCSFunction(Lua_UIPanel.get_usedForUI), null, true);
		LuaObject.addMember(l, "drawCallOffset", new LuaCSFunction(Lua_UIPanel.get_drawCallOffset), null, true);
		LuaObject.addMember(l, "clipping", new LuaCSFunction(Lua_UIPanel.get_clipping), new LuaCSFunction(Lua_UIPanel.set_clipping), true);
		LuaObject.addMember(l, "parentPanel", new LuaCSFunction(Lua_UIPanel.get_parentPanel), null, true);
		LuaObject.addMember(l, "clipCount", new LuaCSFunction(Lua_UIPanel.get_clipCount), null, true);
		LuaObject.addMember(l, "hasClipping", new LuaCSFunction(Lua_UIPanel.get_hasClipping), null, true);
		LuaObject.addMember(l, "hasCumulativeClipping", new LuaCSFunction(Lua_UIPanel.get_hasCumulativeClipping), null, true);
		LuaObject.addMember(l, "clipOffset", new LuaCSFunction(Lua_UIPanel.get_clipOffset), new LuaCSFunction(Lua_UIPanel.set_clipOffset), true);
		LuaObject.addMember(l, "baseClipRegion", new LuaCSFunction(Lua_UIPanel.get_baseClipRegion), new LuaCSFunction(Lua_UIPanel.set_baseClipRegion), true);
		LuaObject.addMember(l, "finalClipRegion", new LuaCSFunction(Lua_UIPanel.get_finalClipRegion), null, true);
		LuaObject.addMember(l, "clipSoftness", new LuaCSFunction(Lua_UIPanel.get_clipSoftness), new LuaCSFunction(Lua_UIPanel.set_clipSoftness), true);
		LuaObject.addMember(l, "localCorners", new LuaCSFunction(Lua_UIPanel.get_localCorners), null, true);
		LuaObject.addMember(l, "worldCorners", new LuaCSFunction(Lua_UIPanel.get_worldCorners), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIPanel.constructor), typeof(UIPanel), typeof(UIRect));
	}
}
