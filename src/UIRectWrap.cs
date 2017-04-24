using LuaInterface;
using System;
using UnityEngine;

public class UIRectWrap
{
	private static Type classType = typeof(UIRect);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CalculateFinalAlpha", new LuaCSFunction(UIRectWrap.CalculateFinalAlpha)),
			new LuaMethod("Invalidate", new LuaCSFunction(UIRectWrap.Invalidate)),
			new LuaMethod("GetSides", new LuaCSFunction(UIRectWrap.GetSides)),
			new LuaMethod("ManualUpdate", new LuaCSFunction(UIRectWrap.ManualUpdate)),
			new LuaMethod("UpdateAnchors", new LuaCSFunction(UIRectWrap.UpdateAnchors)),
			new LuaMethod("SetAnchor", new LuaCSFunction(UIRectWrap.SetAnchor)),
			new LuaMethod("ResetAnchors", new LuaCSFunction(UIRectWrap.ResetAnchors)),
			new LuaMethod("SetRect", new LuaCSFunction(UIRectWrap.SetRect)),
			new LuaMethod("ParentHasChanged", new LuaCSFunction(UIRectWrap.ParentHasChanged)),
			new LuaMethod("ChangeParent", new LuaCSFunction(UIRectWrap.ChangeParent)),
			new LuaMethod("SetPanel", new LuaCSFunction(UIRectWrap.SetPanel)),
			new LuaMethod("New", new LuaCSFunction(UIRectWrap._CreateUIRect)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIRectWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIRectWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("leftAnchor", new LuaCSFunction(UIRectWrap.get_leftAnchor), new LuaCSFunction(UIRectWrap.set_leftAnchor)),
			new LuaField("rightAnchor", new LuaCSFunction(UIRectWrap.get_rightAnchor), new LuaCSFunction(UIRectWrap.set_rightAnchor)),
			new LuaField("bottomAnchor", new LuaCSFunction(UIRectWrap.get_bottomAnchor), new LuaCSFunction(UIRectWrap.set_bottomAnchor)),
			new LuaField("topAnchor", new LuaCSFunction(UIRectWrap.get_topAnchor), new LuaCSFunction(UIRectWrap.set_topAnchor)),
			new LuaField("updateAnchors", new LuaCSFunction(UIRectWrap.get_updateAnchors), new LuaCSFunction(UIRectWrap.set_updateAnchors)),
			new LuaField("finalAlpha", new LuaCSFunction(UIRectWrap.get_finalAlpha), new LuaCSFunction(UIRectWrap.set_finalAlpha)),
			new LuaField("cachedGameObject", new LuaCSFunction(UIRectWrap.get_cachedGameObject), null),
			new LuaField("cachedTransform", new LuaCSFunction(UIRectWrap.get_cachedTransform), null),
			new LuaField("anchorCamera", new LuaCSFunction(UIRectWrap.get_anchorCamera), null),
			new LuaField("isFullyAnchored", new LuaCSFunction(UIRectWrap.get_isFullyAnchored), null),
			new LuaField("isAnchoredHorizontally", new LuaCSFunction(UIRectWrap.get_isAnchoredHorizontally), null),
			new LuaField("isAnchoredVertically", new LuaCSFunction(UIRectWrap.get_isAnchoredVertically), null),
			new LuaField("canBeAnchored", new LuaCSFunction(UIRectWrap.get_canBeAnchored), null),
			new LuaField("parent", new LuaCSFunction(UIRectWrap.get_parent), null),
			new LuaField("root", new LuaCSFunction(UIRectWrap.get_root), null),
			new LuaField("isAnchored", new LuaCSFunction(UIRectWrap.get_isAnchored), null),
			new LuaField("alpha", new LuaCSFunction(UIRectWrap.get_alpha), new LuaCSFunction(UIRectWrap.set_alpha)),
			new LuaField("localCorners", new LuaCSFunction(UIRectWrap.get_localCorners), null),
			new LuaField("worldCorners", new LuaCSFunction(UIRectWrap.get_worldCorners), null)
		};
		LuaScriptMgr.RegisterLib(L, "UIRect", typeof(UIRect), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIRect(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIRect class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIRectWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_leftAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leftAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leftAnchor on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIRect.leftAnchor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rightAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rightAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rightAnchor on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIRect.rightAnchor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bottomAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bottomAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bottomAnchor on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIRect.bottomAnchor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_topAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name topAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index topAnchor on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIRect.topAnchor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateAnchors(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateAnchors");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateAnchors on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.updateAnchors);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalAlpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finalAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finalAlpha on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.finalAlpha);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedGameObject(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedGameObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedGameObject on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.cachedGameObject);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedTransform on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.cachedTransform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anchorCamera(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anchorCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anchorCamera on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.anchorCamera);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isFullyAnchored(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isFullyAnchored");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isFullyAnchored on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.isFullyAnchored);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredHorizontally(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAnchoredHorizontally");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAnchoredHorizontally on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.isAnchoredHorizontally);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredVertically(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAnchoredVertically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAnchoredVertically on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.isAnchoredVertically);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canBeAnchored(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canBeAnchored");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canBeAnchored on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.canBeAnchored);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parent(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parent");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parent on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.parent);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_root(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name root");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index root on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.root);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchored(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAnchored");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAnchored on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.isAnchored);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIRect.alpha);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localCorners(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localCorners");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localCorners on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, uIRect.localCorners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCorners(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldCorners");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldCorners on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, uIRect.worldCorners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_leftAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leftAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leftAnchor on a nil value");
			}
		}
		uIRect.leftAnchor = (UIRect.AnchorPoint)LuaScriptMgr.GetNetObject(L, 3, typeof(UIRect.AnchorPoint));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rightAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rightAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rightAnchor on a nil value");
			}
		}
		uIRect.rightAnchor = (UIRect.AnchorPoint)LuaScriptMgr.GetNetObject(L, 3, typeof(UIRect.AnchorPoint));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bottomAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bottomAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bottomAnchor on a nil value");
			}
		}
		uIRect.bottomAnchor = (UIRect.AnchorPoint)LuaScriptMgr.GetNetObject(L, 3, typeof(UIRect.AnchorPoint));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_topAnchor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name topAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index topAnchor on a nil value");
			}
		}
		uIRect.topAnchor = (UIRect.AnchorPoint)LuaScriptMgr.GetNetObject(L, 3, typeof(UIRect.AnchorPoint));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateAnchors(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateAnchors");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateAnchors on a nil value");
			}
		}
		uIRect.updateAnchors = (UIRect.AnchorUpdate)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIRect.AnchorUpdate)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finalAlpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finalAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finalAlpha on a nil value");
			}
		}
		uIRect.finalAlpha = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIRect uIRect = (UIRect)luaObject;
		if (uIRect == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
			}
		}
		uIRect.alpha = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateFinalAlpha(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		int frameID = (int)LuaScriptMgr.GetNumber(L, 2);
		float d = uIRect.CalculateFinalAlpha(frameID);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Invalidate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uIRect.Invalidate(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSides(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		Transform relativeTo = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3[] sides = uIRect.GetSides(relativeTo);
		LuaScriptMgr.PushArray(L, sides);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ManualUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		uIRect.ManualUpdate();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateAnchors(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		uIRect.UpdateAnchors();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAnchor(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIRect), typeof(GameObject)))
		{
			UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
			GameObject anchor = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			uIRect.SetAnchor(anchor);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIRect), typeof(Transform)))
		{
			UIRect uIRect2 = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
			Transform anchor2 = (Transform)LuaScriptMgr.GetLuaObject(L, 2);
			uIRect2.SetAnchor(anchor2);
			return 0;
		}
		if (num == 6)
		{
			UIRect uIRect3 = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
			GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
			int left = (int)LuaScriptMgr.GetNumber(L, 3);
			int bottom = (int)LuaScriptMgr.GetNumber(L, 4);
			int right = (int)LuaScriptMgr.GetNumber(L, 5);
			int top = (int)LuaScriptMgr.GetNumber(L, 6);
			uIRect3.SetAnchor(go, left, bottom, right, top);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIRect.SetAnchor");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetAnchors(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		uIRect.ResetAnchors();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		float x = (float)LuaScriptMgr.GetNumber(L, 2);
		float y = (float)LuaScriptMgr.GetNumber(L, 3);
		float width = (float)LuaScriptMgr.GetNumber(L, 4);
		float height = (float)LuaScriptMgr.GetNumber(L, 5);
		uIRect.SetRect(x, y, width, height);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParentHasChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		uIRect.ParentHasChanged();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeParent(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
			uIRect.ChangeParent();
			return 0;
		}
		if (num == 2)
		{
			UIRect uIRect2 = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
			UIRect pt = (UIRect)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIRect));
			uIRect2.ChangeParent(pt);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIRect.ChangeParent");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIRect uIRect = (UIRect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIRect");
		UIPanel panel = (UIPanel)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIPanel));
		uIRect.SetPanel(panel);
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
