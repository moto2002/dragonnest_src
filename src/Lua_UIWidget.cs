using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIWidget : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIWidget o = new UIWidget();
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
	public static int RegisterUI(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Component c;
			LuaObject.checkType<Component>(l, 2, out c);
			uIWidget.RegisterUI(c);
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
	public static int SetDimensions(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int w;
			LuaObject.checkType(l, 2, out w);
			int h;
			LuaObject.checkType(l, 3, out h);
			uIWidget.SetDimensions(w, h);
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
	public static int GetSides(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Transform relativeTo;
			LuaObject.checkType<Transform>(l, 2, out relativeTo);
			Vector3[] sides = uIWidget.GetSides(relativeTo);
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
	public static int CalculateFinalAlpha(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int frameID;
			LuaObject.checkType(l, 2, out frameID);
			float o = uIWidget.CalculateFinalAlpha(frameID);
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
	public static int Invalidate(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool includeChildren;
			LuaObject.checkType(l, 2, out includeChildren);
			uIWidget.Invalidate(includeChildren);
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
	public static int CalculateCumulativeAlpha(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int frameID;
			LuaObject.checkType(l, 2, out frameID);
			float o = uIWidget.CalculateCumulativeAlpha(frameID);
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			float x;
			LuaObject.checkType(l, 2, out x);
			float y;
			LuaObject.checkType(l, 3, out y);
			float width;
			LuaObject.checkType(l, 4, out width);
			float height;
			LuaObject.checkType(l, 5, out height);
			uIWidget.SetRect(x, y, width, height);
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
	public static int ResizeCollider(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.ResizeCollider();
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
	public static int CalculateBounds(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
				Bounds bounds = uIWidget.CalculateBounds();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, bounds);
				result = 2;
			}
			else if (num == 2)
			{
				UIWidget uIWidget2 = (UIWidget)LuaObject.checkSelf(l);
				Transform relativeParent;
				LuaObject.checkType<Transform>(l, 2, out relativeParent);
				Bounds bounds2 = uIWidget2.CalculateBounds(relativeParent);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, bounds2);
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
	public static int SetDirty(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.SetDirty();
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
	public static int MarkAsChanged(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.MarkAsChanged();
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
	public static int CreatePanel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIPanel o = uIWidget.CreatePanel();
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
	public static int SetPanel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIPanel panel;
			LuaObject.checkType<UIPanel>(l, 2, out panel);
			uIWidget.SetPanel(panel);
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
	public static int CheckLayer(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.CheckLayer();
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.ParentHasChanged();
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
	public static int UpdateVisibility(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool visibleByAlpha;
			LuaObject.checkType(l, 2, out visibleByAlpha);
			bool visibleByPanel;
			LuaObject.checkType(l, 3, out visibleByPanel);
			bool b = uIWidget.UpdateVisibility(visibleByAlpha, visibleByPanel);
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
	public static int UpdateTransform(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int frame;
			LuaObject.checkType(l, 2, out frame);
			bool b = uIWidget.UpdateTransform(frame);
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
	public static int UpdateGeometry(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int frame;
			LuaObject.checkType(l, 2, out frame);
			bool b = uIWidget.UpdateGeometry(frame);
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
	public static int ClearGeometry(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.ClearGeometry();
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
	public static int WriteToBuffers(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			FastListV3 v;
			LuaObject.checkType<FastListV3>(l, 2, out v);
			FastListV2 u;
			LuaObject.checkType<FastListV2>(l, 3, out u);
			FastListColor32 c;
			LuaObject.checkType<FastListColor32>(l, 4, out c);
			BetterList<Vector3> n;
			LuaObject.checkType<BetterList<Vector3>>(l, 5, out n);
			BetterList<Vector4> t;
			LuaObject.checkType<BetterList<Vector4>>(l, 6, out t);
			uIWidget.WriteToBuffers(v, u, c, n, t);
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
	public static int MakePixelPerfect(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uIWidget.MakePixelPerfect();
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
	public static int OnFill(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			BetterList<Vector3> verts;
			LuaObject.checkType<BetterList<Vector3>>(l, 2, out verts);
			BetterList<Vector2> uvs;
			LuaObject.checkType<BetterList<Vector2>>(l, 3, out uvs);
			BetterList<Color32> cols;
			LuaObject.checkType<BetterList<Color32>>(l, 4, out cols);
			uIWidget.OnFill(verts, uvs, cols);
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
	public static int FullCompareFunc_s(IntPtr l)
	{
		int result;
		try
		{
			UIWidget left;
			LuaObject.checkType<UIWidget>(l, 1, out left);
			UIWidget right;
			LuaObject.checkType<UIWidget>(l, 2, out right);
			int i = UIWidget.FullCompareFunc(left, right);
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
	public static int PanelCompareFunc_s(IntPtr l)
	{
		int result;
		try
		{
			UIWidget left;
			LuaObject.checkType<UIWidget>(l, 1, out left);
			UIWidget right;
			LuaObject.checkType<UIWidget>(l, 2, out right);
			int i = UIWidget.PanelCompareFunc(left, right);
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
	public static int get_faraway(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, 2016);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_uid(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.uid);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_uid(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			uint uid;
			LuaObject.checkType(l, 2, out uid);
			uIWidget.uid = uid;
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
	public static int get_sid(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.sid);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_sid(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			string sid;
			LuaObject.checkType(l, 2, out sid);
			uIWidget.sid = sid;
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
	public static int set_onChange(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIWidget.OnDimensionsChanged onDimensionsChanged;
			int num = LuaDelegation.checkDelegate(l, 2, out onDimensionsChanged);
			if (num == 0)
			{
				uIWidget.onChange = onDimensionsChanged;
			}
			else if (num == 1)
			{
				UIWidget expr_30 = uIWidget;
				expr_30.onChange = (UIWidget.OnDimensionsChanged)Delegate.Combine(expr_30.onChange, onDimensionsChanged);
			}
			else if (num == 2)
			{
				UIWidget expr_53 = uIWidget;
				expr_53.onChange = (UIWidget.OnDimensionsChanged)Delegate.Remove(expr_53.onChange, onDimensionsChanged);
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
	public static int get_autoResizeBoxCollider(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.autoResizeBoxCollider);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_autoResizeBoxCollider(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool autoResizeBoxCollider;
			LuaObject.checkType(l, 2, out autoResizeBoxCollider);
			uIWidget.autoResizeBoxCollider = autoResizeBoxCollider;
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
	public static int get_hideIfOffScreen(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.hideIfOffScreen);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_hideIfOffScreen(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool hideIfOffScreen;
			LuaObject.checkType(l, 2, out hideIfOffScreen);
			uIWidget.hideIfOffScreen = hideIfOffScreen;
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
	public static int get_autoFindPanel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.autoFindPanel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_autoFindPanel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool autoFindPanel;
			LuaObject.checkType(l, 2, out autoFindPanel);
			uIWidget.autoFindPanel = autoFindPanel;
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
	public static int get_keepAspectRatio(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIWidget.keepAspectRatio);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_keepAspectRatio(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIWidget.AspectRatioSource keepAspectRatio;
			LuaObject.checkEnum<UIWidget.AspectRatioSource>(l, 2, out keepAspectRatio);
			uIWidget.keepAspectRatio = keepAspectRatio;
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
	public static int get_aspectRatio(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.aspectRatio);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_aspectRatio(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			float aspectRatio;
			LuaObject.checkType(l, 2, out aspectRatio);
			uIWidget.aspectRatio = aspectRatio;
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
	public static int set_hitCheck(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIWidget.HitCheck hitCheck;
			int num = LuaDelegation.checkDelegate(l, 2, out hitCheck);
			if (num == 0)
			{
				uIWidget.hitCheck = hitCheck;
			}
			else if (num == 1)
			{
				UIWidget expr_30 = uIWidget;
				expr_30.hitCheck = (UIWidget.HitCheck)Delegate.Combine(expr_30.hitCheck, hitCheck);
			}
			else if (num == 2)
			{
				UIWidget expr_53 = uIWidget;
				expr_53.hitCheck = (UIWidget.HitCheck)Delegate.Remove(expr_53.hitCheck, hitCheck);
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
	public static int get_panel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.panel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_panel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIPanel panel;
			LuaObject.checkType<UIPanel>(l, 2, out panel);
			uIWidget.panel = panel;
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
	public static int get_storePanel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.storePanel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_storePanel(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIPanel storePanel;
			LuaObject.checkType<UIPanel>(l, 2, out storePanel);
			uIWidget.storePanel = storePanel;
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
	public static int get_geometry(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.geometry);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_geometry(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIGeometry geometry;
			LuaObject.checkType<UIGeometry>(l, 2, out geometry);
			uIWidget.geometry = geometry;
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
	public static int get_fillGeometry(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.fillGeometry);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fillGeometry(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool fillGeometry;
			LuaObject.checkType(l, 2, out fillGeometry);
			uIWidget.fillGeometry = fillGeometry;
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
	public static int get_boxColliderCache(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.boxColliderCache);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_boxColliderCache(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			BoxCollider boxColliderCache;
			LuaObject.checkType<BoxCollider>(l, 2, out boxColliderCache);
			uIWidget.boxColliderCache = boxColliderCache;
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
	public static int get_calcRenderQueue(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.calcRenderQueue);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_calcRenderQueue(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			bool calcRenderQueue;
			LuaObject.checkType(l, 2, out calcRenderQueue);
			uIWidget.calcRenderQueue = calcRenderQueue;
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
	public static int get_drawCall(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.drawCall);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_drawCall(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIDrawCall drawCall;
			LuaObject.checkType<UIDrawCall>(l, 2, out drawCall);
			uIWidget.drawCall = drawCall;
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
	public static int get_drawRegion(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.drawRegion);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_drawRegion(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Vector4 drawRegion;
			LuaObject.checkType(l, 2, out drawRegion);
			uIWidget.drawRegion = drawRegion;
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
	public static int get_pivotOffset(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.pivotOffset);
			result = 2;
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.width);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_width(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int width;
			LuaObject.checkType(l, 2, out width);
			uIWidget.width = width;
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
	public static int get_height(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.height);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_height(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int height;
			LuaObject.checkType(l, 2, out height);
			uIWidget.height = height;
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
	public static int get_color(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.color);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_color(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Color color;
			LuaObject.checkType(l, 2, out color);
			uIWidget.color = color;
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
	public static int get_alpha(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.alpha);
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			float alpha;
			LuaObject.checkType(l, 2, out alpha);
			uIWidget.alpha = alpha;
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
	public static int get_isVisible(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.isVisible);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_hasVertices(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.hasVertices);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_rawPivot(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIWidget.rawPivot);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_rawPivot(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIWidget.Pivot rawPivot;
			LuaObject.checkEnum<UIWidget.Pivot>(l, 2, out rawPivot);
			uIWidget.rawPivot = rawPivot;
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIWidget.pivot);
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			UIWidget.Pivot pivot;
			LuaObject.checkEnum<UIWidget.Pivot>(l, 2, out pivot);
			uIWidget.pivot = pivot;
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.depth);
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			int depth;
			LuaObject.checkType(l, 2, out depth);
			uIWidget.depth = depth;
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
	public static int get_raycastDepth(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.raycastDepth);
			result = 2;
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.localCorners);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_localSize(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.localSize);
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
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.worldCorners);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_drawingDimensions(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.drawingDimensions);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_material(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.material);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_material(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Material material;
			LuaObject.checkType<Material>(l, 2, out material);
			uIWidget.material = material;
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
	public static int get_mainTexture(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.mainTexture);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mainTexture(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Texture mainTexture;
			LuaObject.checkType<Texture>(l, 2, out mainTexture);
			uIWidget.mainTexture = mainTexture;
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
	public static int get_alphaTexture(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.alphaTexture);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_shader(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.shader);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_shader(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			Shader shader;
			LuaObject.checkType<Shader>(l, 2, out shader);
			uIWidget.shader = shader;
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
	public static int get_hasBoxCollider(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.hasBoxCollider);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_DefaultBoxCollider(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.DefaultBoxCollider);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_minWidth(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.minWidth);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_minHeight(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.minHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_border(IntPtr l)
	{
		int result;
		try
		{
			UIWidget uIWidget = (UIWidget)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWidget.border);
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
		LuaObject.getTypeTable(l, "UIWidget");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.RegisterUI));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.SetDimensions));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.GetSides));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.CalculateFinalAlpha));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.Invalidate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.CalculateCumulativeAlpha));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.SetRect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.ResizeCollider));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.CalculateBounds));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.SetDirty));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.MarkAsChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.CreatePanel));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.SetPanel));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.CheckLayer));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.ParentHasChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.UpdateVisibility));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.UpdateTransform));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.UpdateGeometry));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.ClearGeometry));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.WriteToBuffers));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.MakePixelPerfect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.OnFill));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.FullCompareFunc_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWidget.PanelCompareFunc_s));
		LuaObject.addMember(l, "faraway", new LuaCSFunction(Lua_UIWidget.get_faraway), null, false);
		LuaObject.addMember(l, "uid", new LuaCSFunction(Lua_UIWidget.get_uid), new LuaCSFunction(Lua_UIWidget.set_uid), true);
		LuaObject.addMember(l, "sid", new LuaCSFunction(Lua_UIWidget.get_sid), new LuaCSFunction(Lua_UIWidget.set_sid), true);
		LuaObject.addMember(l, "onChange", null, new LuaCSFunction(Lua_UIWidget.set_onChange), true);
		LuaObject.addMember(l, "autoResizeBoxCollider", new LuaCSFunction(Lua_UIWidget.get_autoResizeBoxCollider), new LuaCSFunction(Lua_UIWidget.set_autoResizeBoxCollider), true);
		LuaObject.addMember(l, "hideIfOffScreen", new LuaCSFunction(Lua_UIWidget.get_hideIfOffScreen), new LuaCSFunction(Lua_UIWidget.set_hideIfOffScreen), true);
		LuaObject.addMember(l, "autoFindPanel", new LuaCSFunction(Lua_UIWidget.get_autoFindPanel), new LuaCSFunction(Lua_UIWidget.set_autoFindPanel), true);
		LuaObject.addMember(l, "keepAspectRatio", new LuaCSFunction(Lua_UIWidget.get_keepAspectRatio), new LuaCSFunction(Lua_UIWidget.set_keepAspectRatio), true);
		LuaObject.addMember(l, "aspectRatio", new LuaCSFunction(Lua_UIWidget.get_aspectRatio), new LuaCSFunction(Lua_UIWidget.set_aspectRatio), true);
		LuaObject.addMember(l, "hitCheck", null, new LuaCSFunction(Lua_UIWidget.set_hitCheck), true);
		LuaObject.addMember(l, "panel", new LuaCSFunction(Lua_UIWidget.get_panel), new LuaCSFunction(Lua_UIWidget.set_panel), true);
		LuaObject.addMember(l, "storePanel", new LuaCSFunction(Lua_UIWidget.get_storePanel), new LuaCSFunction(Lua_UIWidget.set_storePanel), true);
		LuaObject.addMember(l, "geometry", new LuaCSFunction(Lua_UIWidget.get_geometry), new LuaCSFunction(Lua_UIWidget.set_geometry), true);
		LuaObject.addMember(l, "fillGeometry", new LuaCSFunction(Lua_UIWidget.get_fillGeometry), new LuaCSFunction(Lua_UIWidget.set_fillGeometry), true);
		LuaObject.addMember(l, "boxColliderCache", new LuaCSFunction(Lua_UIWidget.get_boxColliderCache), new LuaCSFunction(Lua_UIWidget.set_boxColliderCache), true);
		LuaObject.addMember(l, "calcRenderQueue", new LuaCSFunction(Lua_UIWidget.get_calcRenderQueue), new LuaCSFunction(Lua_UIWidget.set_calcRenderQueue), true);
		LuaObject.addMember(l, "drawCall", new LuaCSFunction(Lua_UIWidget.get_drawCall), new LuaCSFunction(Lua_UIWidget.set_drawCall), true);
		LuaObject.addMember(l, "drawRegion", new LuaCSFunction(Lua_UIWidget.get_drawRegion), new LuaCSFunction(Lua_UIWidget.set_drawRegion), true);
		LuaObject.addMember(l, "pivotOffset", new LuaCSFunction(Lua_UIWidget.get_pivotOffset), null, true);
		LuaObject.addMember(l, "width", new LuaCSFunction(Lua_UIWidget.get_width), new LuaCSFunction(Lua_UIWidget.set_width), true);
		LuaObject.addMember(l, "height", new LuaCSFunction(Lua_UIWidget.get_height), new LuaCSFunction(Lua_UIWidget.set_height), true);
		LuaObject.addMember(l, "color", new LuaCSFunction(Lua_UIWidget.get_color), new LuaCSFunction(Lua_UIWidget.set_color), true);
		LuaObject.addMember(l, "alpha", new LuaCSFunction(Lua_UIWidget.get_alpha), new LuaCSFunction(Lua_UIWidget.set_alpha), true);
		LuaObject.addMember(l, "isVisible", new LuaCSFunction(Lua_UIWidget.get_isVisible), null, true);
		LuaObject.addMember(l, "hasVertices", new LuaCSFunction(Lua_UIWidget.get_hasVertices), null, true);
		LuaObject.addMember(l, "rawPivot", new LuaCSFunction(Lua_UIWidget.get_rawPivot), new LuaCSFunction(Lua_UIWidget.set_rawPivot), true);
		LuaObject.addMember(l, "pivot", new LuaCSFunction(Lua_UIWidget.get_pivot), new LuaCSFunction(Lua_UIWidget.set_pivot), true);
		LuaObject.addMember(l, "depth", new LuaCSFunction(Lua_UIWidget.get_depth), new LuaCSFunction(Lua_UIWidget.set_depth), true);
		LuaObject.addMember(l, "raycastDepth", new LuaCSFunction(Lua_UIWidget.get_raycastDepth), null, true);
		LuaObject.addMember(l, "localCorners", new LuaCSFunction(Lua_UIWidget.get_localCorners), null, true);
		LuaObject.addMember(l, "localSize", new LuaCSFunction(Lua_UIWidget.get_localSize), null, true);
		LuaObject.addMember(l, "worldCorners", new LuaCSFunction(Lua_UIWidget.get_worldCorners), null, true);
		LuaObject.addMember(l, "drawingDimensions", new LuaCSFunction(Lua_UIWidget.get_drawingDimensions), null, true);
		LuaObject.addMember(l, "material", new LuaCSFunction(Lua_UIWidget.get_material), new LuaCSFunction(Lua_UIWidget.set_material), true);
		LuaObject.addMember(l, "mainTexture", new LuaCSFunction(Lua_UIWidget.get_mainTexture), new LuaCSFunction(Lua_UIWidget.set_mainTexture), true);
		LuaObject.addMember(l, "alphaTexture", new LuaCSFunction(Lua_UIWidget.get_alphaTexture), null, true);
		LuaObject.addMember(l, "shader", new LuaCSFunction(Lua_UIWidget.get_shader), new LuaCSFunction(Lua_UIWidget.set_shader), true);
		LuaObject.addMember(l, "hasBoxCollider", new LuaCSFunction(Lua_UIWidget.get_hasBoxCollider), null, true);
		LuaObject.addMember(l, "DefaultBoxCollider", new LuaCSFunction(Lua_UIWidget.get_DefaultBoxCollider), null, true);
		LuaObject.addMember(l, "minWidth", new LuaCSFunction(Lua_UIWidget.get_minWidth), null, true);
		LuaObject.addMember(l, "minHeight", new LuaCSFunction(Lua_UIWidget.get_minHeight), null, true);
		LuaObject.addMember(l, "border", new LuaCSFunction(Lua_UIWidget.get_border), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIWidget.constructor), typeof(UIWidget), typeof(UIRect));
	}
}
