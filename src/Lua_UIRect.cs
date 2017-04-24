using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIRect : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int CalculateFinalAlpha(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			int frameID;
			LuaObject.checkType(l, 2, out frameID);
			float o = uIRect.CalculateFinalAlpha(frameID);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			bool includeChildren;
			LuaObject.checkType(l, 2, out includeChildren);
			uIRect.Invalidate(includeChildren);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			Transform relativeTo;
			LuaObject.checkType<Transform>(l, 2, out relativeTo);
			Vector3[] sides = uIRect.GetSides(relativeTo);
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
	public static int ManualUpdate(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			uIRect.ManualUpdate();
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
	public static int UpdateAnchors(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			uIRect.UpdateAnchors();
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
	public static int SetAnchor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, num, 2, typeof(GameObject)))
			{
				UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
				GameObject anchor;
				LuaObject.checkType<GameObject>(l, 2, out anchor);
				uIRect.SetAnchor(anchor);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Transform)))
			{
				UIRect uIRect2 = (UIRect)LuaObject.checkSelf(l);
				Transform anchor2;
				LuaObject.checkType<Transform>(l, 2, out anchor2);
				uIRect2.SetAnchor(anchor2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 6)
			{
				UIRect uIRect3 = (UIRect)LuaObject.checkSelf(l);
				GameObject go;
				LuaObject.checkType<GameObject>(l, 2, out go);
				int left;
				LuaObject.checkType(l, 3, out left);
				int bottom;
				LuaObject.checkType(l, 4, out bottom);
				int right;
				LuaObject.checkType(l, 5, out right);
				int top;
				LuaObject.checkType(l, 6, out top);
				uIRect3.SetAnchor(go, left, bottom, right, top);
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
	public static int ResetAnchors(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			uIRect.ResetAnchors();
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
	public static int SetRect(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			float x;
			LuaObject.checkType(l, 2, out x);
			float y;
			LuaObject.checkType(l, 3, out y);
			float width;
			LuaObject.checkType(l, 4, out width);
			float height;
			LuaObject.checkType(l, 5, out height);
			uIRect.SetRect(x, y, width, height);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			uIRect.ParentHasChanged();
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
	public static int ChangeParent(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
				uIRect.ChangeParent();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				UIRect uIRect2 = (UIRect)LuaObject.checkSelf(l);
				UIRect pt;
				LuaObject.checkType<UIRect>(l, 2, out pt);
				uIRect2.ChangeParent(pt);
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
	public static int SetPanel(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			UIPanel panel;
			LuaObject.checkType<UIPanel>(l, 2, out panel);
			uIRect.SetPanel(panel);
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
	public static int get_leftAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.leftAnchor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_leftAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			UIRect.AnchorPoint leftAnchor;
			LuaObject.checkType<UIRect.AnchorPoint>(l, 2, out leftAnchor);
			uIRect.leftAnchor = leftAnchor;
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
	public static int get_rightAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.rightAnchor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_rightAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			UIRect.AnchorPoint rightAnchor;
			LuaObject.checkType<UIRect.AnchorPoint>(l, 2, out rightAnchor);
			uIRect.rightAnchor = rightAnchor;
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
	public static int get_bottomAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.bottomAnchor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bottomAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			UIRect.AnchorPoint bottomAnchor;
			LuaObject.checkType<UIRect.AnchorPoint>(l, 2, out bottomAnchor);
			uIRect.bottomAnchor = bottomAnchor;
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
	public static int get_topAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.topAnchor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_topAnchor(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			UIRect.AnchorPoint topAnchor;
			LuaObject.checkType<UIRect.AnchorPoint>(l, 2, out topAnchor);
			uIRect.topAnchor = topAnchor;
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
	public static int get_updateAnchors(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIRect.updateAnchors);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_updateAnchors(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			UIRect.AnchorUpdate updateAnchors;
			LuaObject.checkEnum<UIRect.AnchorUpdate>(l, 2, out updateAnchors);
			uIRect.updateAnchors = updateAnchors;
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
	public static int get_finalAlpha(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.finalAlpha);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_finalAlpha(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			float finalAlpha;
			LuaObject.checkType(l, 2, out finalAlpha);
			uIRect.finalAlpha = finalAlpha;
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
	public static int get_cachedGameObject(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.cachedGameObject);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_cachedTransform(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.cachedTransform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_anchorCamera(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.anchorCamera);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isFullyAnchored(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.isFullyAnchored);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isAnchoredHorizontally(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.isAnchoredHorizontally);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isAnchoredVertically(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.isAnchoredVertically);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.canBeAnchored);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_parent(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.parent);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_root(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.root);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isAnchored(IntPtr l)
	{
		int result;
		try
		{
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.isAnchored);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.alpha);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			float alpha;
			LuaObject.checkType(l, 2, out alpha);
			uIRect.alpha = alpha;
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.localCorners);
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
			UIRect uIRect = (UIRect)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRect.worldCorners);
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
		LuaObject.getTypeTable(l, "UIRect");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.CalculateFinalAlpha));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.Invalidate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.GetSides));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.ManualUpdate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.UpdateAnchors));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.SetAnchor));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.ResetAnchors));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.SetRect));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.ParentHasChanged));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.ChangeParent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRect.SetPanel));
		LuaObject.addMember(l, "leftAnchor", new LuaCSFunction(Lua_UIRect.get_leftAnchor), new LuaCSFunction(Lua_UIRect.set_leftAnchor), true);
		LuaObject.addMember(l, "rightAnchor", new LuaCSFunction(Lua_UIRect.get_rightAnchor), new LuaCSFunction(Lua_UIRect.set_rightAnchor), true);
		LuaObject.addMember(l, "bottomAnchor", new LuaCSFunction(Lua_UIRect.get_bottomAnchor), new LuaCSFunction(Lua_UIRect.set_bottomAnchor), true);
		LuaObject.addMember(l, "topAnchor", new LuaCSFunction(Lua_UIRect.get_topAnchor), new LuaCSFunction(Lua_UIRect.set_topAnchor), true);
		LuaObject.addMember(l, "updateAnchors", new LuaCSFunction(Lua_UIRect.get_updateAnchors), new LuaCSFunction(Lua_UIRect.set_updateAnchors), true);
		LuaObject.addMember(l, "finalAlpha", new LuaCSFunction(Lua_UIRect.get_finalAlpha), new LuaCSFunction(Lua_UIRect.set_finalAlpha), true);
		LuaObject.addMember(l, "cachedGameObject", new LuaCSFunction(Lua_UIRect.get_cachedGameObject), null, true);
		LuaObject.addMember(l, "cachedTransform", new LuaCSFunction(Lua_UIRect.get_cachedTransform), null, true);
		LuaObject.addMember(l, "anchorCamera", new LuaCSFunction(Lua_UIRect.get_anchorCamera), null, true);
		LuaObject.addMember(l, "isFullyAnchored", new LuaCSFunction(Lua_UIRect.get_isFullyAnchored), null, true);
		LuaObject.addMember(l, "isAnchoredHorizontally", new LuaCSFunction(Lua_UIRect.get_isAnchoredHorizontally), null, true);
		LuaObject.addMember(l, "isAnchoredVertically", new LuaCSFunction(Lua_UIRect.get_isAnchoredVertically), null, true);
		LuaObject.addMember(l, "canBeAnchored", new LuaCSFunction(Lua_UIRect.get_canBeAnchored), null, true);
		LuaObject.addMember(l, "parent", new LuaCSFunction(Lua_UIRect.get_parent), null, true);
		LuaObject.addMember(l, "root", new LuaCSFunction(Lua_UIRect.get_root), null, true);
		LuaObject.addMember(l, "isAnchored", new LuaCSFunction(Lua_UIRect.get_isAnchored), null, true);
		LuaObject.addMember(l, "alpha", new LuaCSFunction(Lua_UIRect.get_alpha), new LuaCSFunction(Lua_UIRect.set_alpha), true);
		LuaObject.addMember(l, "localCorners", new LuaCSFunction(Lua_UIRect.get_localCorners), null, true);
		LuaObject.addMember(l, "worldCorners", new LuaCSFunction(Lua_UIRect.get_worldCorners), null, true);
		LuaObject.createTypeMetatable(l, null, typeof(UIRect), typeof(MonoBehaviour));
	}
}
