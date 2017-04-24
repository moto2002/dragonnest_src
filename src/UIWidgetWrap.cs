using LuaInterface;
using System;
using UnityEngine;

public class UIWidgetWrap
{
	private static Type classType = typeof(UIWidget);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("RegisterUI", new LuaCSFunction(UIWidgetWrap.RegisterUI)),
			new LuaMethod("SetDimensions", new LuaCSFunction(UIWidgetWrap.SetDimensions)),
			new LuaMethod("GetSides", new LuaCSFunction(UIWidgetWrap.GetSides)),
			new LuaMethod("CalculateFinalAlpha", new LuaCSFunction(UIWidgetWrap.CalculateFinalAlpha)),
			new LuaMethod("Invalidate", new LuaCSFunction(UIWidgetWrap.Invalidate)),
			new LuaMethod("CalculateCumulativeAlpha", new LuaCSFunction(UIWidgetWrap.CalculateCumulativeAlpha)),
			new LuaMethod("SetRect", new LuaCSFunction(UIWidgetWrap.SetRect)),
			new LuaMethod("ResizeCollider", new LuaCSFunction(UIWidgetWrap.ResizeCollider)),
			new LuaMethod("FullCompareFunc", new LuaCSFunction(UIWidgetWrap.FullCompareFunc)),
			new LuaMethod("PanelCompareFunc", new LuaCSFunction(UIWidgetWrap.PanelCompareFunc)),
			new LuaMethod("CalculateBounds", new LuaCSFunction(UIWidgetWrap.CalculateBounds)),
			new LuaMethod("SetDirty", new LuaCSFunction(UIWidgetWrap.SetDirty)),
			new LuaMethod("MarkAsChanged", new LuaCSFunction(UIWidgetWrap.MarkAsChanged)),
			new LuaMethod("CreatePanel", new LuaCSFunction(UIWidgetWrap.CreatePanel)),
			new LuaMethod("SetPanel", new LuaCSFunction(UIWidgetWrap.SetPanel)),
			new LuaMethod("CheckLayer", new LuaCSFunction(UIWidgetWrap.CheckLayer)),
			new LuaMethod("ParentHasChanged", new LuaCSFunction(UIWidgetWrap.ParentHasChanged)),
			new LuaMethod("UpdateVisibility", new LuaCSFunction(UIWidgetWrap.UpdateVisibility)),
			new LuaMethod("UpdateTransform", new LuaCSFunction(UIWidgetWrap.UpdateTransform)),
			new LuaMethod("UpdateGeometry", new LuaCSFunction(UIWidgetWrap.UpdateGeometry)),
			new LuaMethod("ClearGeometry", new LuaCSFunction(UIWidgetWrap.ClearGeometry)),
			new LuaMethod("WriteToBuffers", new LuaCSFunction(UIWidgetWrap.WriteToBuffers)),
			new LuaMethod("MakePixelPerfect", new LuaCSFunction(UIWidgetWrap.MakePixelPerfect)),
			new LuaMethod("OnFill", new LuaCSFunction(UIWidgetWrap.OnFill)),
			new LuaMethod("New", new LuaCSFunction(UIWidgetWrap._CreateUIWidget)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIWidgetWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIWidgetWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("faraway", new LuaCSFunction(UIWidgetWrap.get_faraway), null),
			new LuaField("uid", new LuaCSFunction(UIWidgetWrap.get_uid), new LuaCSFunction(UIWidgetWrap.set_uid)),
			new LuaField("sid", new LuaCSFunction(UIWidgetWrap.get_sid), new LuaCSFunction(UIWidgetWrap.set_sid)),
			new LuaField("onChange", new LuaCSFunction(UIWidgetWrap.get_onChange), new LuaCSFunction(UIWidgetWrap.set_onChange)),
			new LuaField("autoResizeBoxCollider", new LuaCSFunction(UIWidgetWrap.get_autoResizeBoxCollider), new LuaCSFunction(UIWidgetWrap.set_autoResizeBoxCollider)),
			new LuaField("hideIfOffScreen", new LuaCSFunction(UIWidgetWrap.get_hideIfOffScreen), new LuaCSFunction(UIWidgetWrap.set_hideIfOffScreen)),
			new LuaField("autoFindPanel", new LuaCSFunction(UIWidgetWrap.get_autoFindPanel), new LuaCSFunction(UIWidgetWrap.set_autoFindPanel)),
			new LuaField("keepAspectRatio", new LuaCSFunction(UIWidgetWrap.get_keepAspectRatio), new LuaCSFunction(UIWidgetWrap.set_keepAspectRatio)),
			new LuaField("aspectRatio", new LuaCSFunction(UIWidgetWrap.get_aspectRatio), new LuaCSFunction(UIWidgetWrap.set_aspectRatio)),
			new LuaField("hitCheck", new LuaCSFunction(UIWidgetWrap.get_hitCheck), new LuaCSFunction(UIWidgetWrap.set_hitCheck)),
			new LuaField("panel", new LuaCSFunction(UIWidgetWrap.get_panel), new LuaCSFunction(UIWidgetWrap.set_panel)),
			new LuaField("storePanel", new LuaCSFunction(UIWidgetWrap.get_storePanel), new LuaCSFunction(UIWidgetWrap.set_storePanel)),
			new LuaField("geometry", new LuaCSFunction(UIWidgetWrap.get_geometry), new LuaCSFunction(UIWidgetWrap.set_geometry)),
			new LuaField("fillGeometry", new LuaCSFunction(UIWidgetWrap.get_fillGeometry), new LuaCSFunction(UIWidgetWrap.set_fillGeometry)),
			new LuaField("boxColliderCache", new LuaCSFunction(UIWidgetWrap.get_boxColliderCache), new LuaCSFunction(UIWidgetWrap.set_boxColliderCache)),
			new LuaField("calcRenderQueue", new LuaCSFunction(UIWidgetWrap.get_calcRenderQueue), new LuaCSFunction(UIWidgetWrap.set_calcRenderQueue)),
			new LuaField("drawCall", new LuaCSFunction(UIWidgetWrap.get_drawCall), new LuaCSFunction(UIWidgetWrap.set_drawCall)),
			new LuaField("drawRegion", new LuaCSFunction(UIWidgetWrap.get_drawRegion), new LuaCSFunction(UIWidgetWrap.set_drawRegion)),
			new LuaField("pivotOffset", new LuaCSFunction(UIWidgetWrap.get_pivotOffset), null),
			new LuaField("width", new LuaCSFunction(UIWidgetWrap.get_width), new LuaCSFunction(UIWidgetWrap.set_width)),
			new LuaField("height", new LuaCSFunction(UIWidgetWrap.get_height), new LuaCSFunction(UIWidgetWrap.set_height)),
			new LuaField("color", new LuaCSFunction(UIWidgetWrap.get_color), new LuaCSFunction(UIWidgetWrap.set_color)),
			new LuaField("alpha", new LuaCSFunction(UIWidgetWrap.get_alpha), new LuaCSFunction(UIWidgetWrap.set_alpha)),
			new LuaField("isVisible", new LuaCSFunction(UIWidgetWrap.get_isVisible), null),
			new LuaField("hasVertices", new LuaCSFunction(UIWidgetWrap.get_hasVertices), null),
			new LuaField("rawPivot", new LuaCSFunction(UIWidgetWrap.get_rawPivot), new LuaCSFunction(UIWidgetWrap.set_rawPivot)),
			new LuaField("pivot", new LuaCSFunction(UIWidgetWrap.get_pivot), new LuaCSFunction(UIWidgetWrap.set_pivot)),
			new LuaField("depth", new LuaCSFunction(UIWidgetWrap.get_depth), new LuaCSFunction(UIWidgetWrap.set_depth)),
			new LuaField("raycastDepth", new LuaCSFunction(UIWidgetWrap.get_raycastDepth), null),
			new LuaField("localCorners", new LuaCSFunction(UIWidgetWrap.get_localCorners), null),
			new LuaField("localSize", new LuaCSFunction(UIWidgetWrap.get_localSize), null),
			new LuaField("worldCorners", new LuaCSFunction(UIWidgetWrap.get_worldCorners), null),
			new LuaField("drawingDimensions", new LuaCSFunction(UIWidgetWrap.get_drawingDimensions), null),
			new LuaField("material", new LuaCSFunction(UIWidgetWrap.get_material), new LuaCSFunction(UIWidgetWrap.set_material)),
			new LuaField("mainTexture", new LuaCSFunction(UIWidgetWrap.get_mainTexture), new LuaCSFunction(UIWidgetWrap.set_mainTexture)),
			new LuaField("alphaTexture", new LuaCSFunction(UIWidgetWrap.get_alphaTexture), null),
			new LuaField("shader", new LuaCSFunction(UIWidgetWrap.get_shader), new LuaCSFunction(UIWidgetWrap.set_shader)),
			new LuaField("hasBoxCollider", new LuaCSFunction(UIWidgetWrap.get_hasBoxCollider), null),
			new LuaField("DefaultBoxCollider", new LuaCSFunction(UIWidgetWrap.get_DefaultBoxCollider), null),
			new LuaField("minWidth", new LuaCSFunction(UIWidgetWrap.get_minWidth), null),
			new LuaField("minHeight", new LuaCSFunction(UIWidgetWrap.get_minHeight), null),
			new LuaField("border", new LuaCSFunction(UIWidgetWrap.get_border), null)
		};
		LuaScriptMgr.RegisterLib(L, "UIWidget", typeof(UIWidget), regs, fields, typeof(UIRect));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIWidget(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIWidget class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIWidgetWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_faraway(IntPtr L)
	{
		LuaScriptMgr.Push(L, 2016);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uid(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.uid);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sid(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sid on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.sid);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.onChange);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoResizeBoxCollider(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoResizeBoxCollider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoResizeBoxCollider on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.autoResizeBoxCollider);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideIfOffScreen(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hideIfOffScreen");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hideIfOffScreen on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.hideIfOffScreen);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoFindPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoFindPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoFindPanel on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.autoFindPanel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepAspectRatio(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keepAspectRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keepAspectRatio on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.keepAspectRatio);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_aspectRatio(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspectRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspectRatio on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.aspectRatio);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hitCheck(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hitCheck");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hitCheck on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.hitCheck);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_panel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		LuaScriptMgr.Push(L, uIWidget.panel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_storePanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name storePanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index storePanel on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.storePanel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_geometry(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name geometry");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index geometry on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIWidget.geometry);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillGeometry(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillGeometry");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillGeometry on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.fillGeometry);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_boxColliderCache(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boxColliderCache");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boxColliderCache on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.boxColliderCache);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_calcRenderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name calcRenderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index calcRenderQueue on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.calcRenderQueue);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawCall(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawCall");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawCall on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.drawCall);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawRegion(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawRegion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawRegion on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.drawRegion);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivotOffset(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pivotOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pivotOffset on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.pivotOffset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name width");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index width on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.width);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.height);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_color(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.color);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		LuaScriptMgr.Push(L, uIWidget.alpha);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isVisible(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isVisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isVisible on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.isVisible);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasVertices(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hasVertices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hasVertices on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.hasVertices);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rawPivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rawPivot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rawPivot on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.rawPivot);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		LuaScriptMgr.Push(L, uIWidget.pivot);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.depth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_raycastDepth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name raycastDepth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index raycastDepth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.raycastDepth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localCorners(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		LuaScriptMgr.PushArray(L, uIWidget.localCorners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.localSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCorners(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		LuaScriptMgr.PushArray(L, uIWidget.worldCorners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawingDimensions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawingDimensions on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.drawingDimensions);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.material);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.mainTexture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alphaTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alphaTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alphaTexture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.alphaTexture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shader(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.shader);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasBoxCollider(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hasBoxCollider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hasBoxCollider on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.hasBoxCollider);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DefaultBoxCollider(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name DefaultBoxCollider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index DefaultBoxCollider on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.DefaultBoxCollider);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minWidth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minWidth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.minWidth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minHeight(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minHeight on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.minHeight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_border(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name border");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index border on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIWidget.border);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uid(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid on a nil value");
			}
		}
		uIWidget.uid = (uint)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sid(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sid on a nil value");
			}
		}
		uIWidget.sid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIWidget.onChange = (UIWidget.OnDimensionsChanged)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.OnDimensionsChanged));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIWidget.onChange = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoResizeBoxCollider(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoResizeBoxCollider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoResizeBoxCollider on a nil value");
			}
		}
		uIWidget.autoResizeBoxCollider = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideIfOffScreen(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hideIfOffScreen");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hideIfOffScreen on a nil value");
			}
		}
		uIWidget.hideIfOffScreen = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoFindPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoFindPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoFindPanel on a nil value");
			}
		}
		uIWidget.autoFindPanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepAspectRatio(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keepAspectRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keepAspectRatio on a nil value");
			}
		}
		uIWidget.keepAspectRatio = (UIWidget.AspectRatioSource)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.AspectRatioSource)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_aspectRatio(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspectRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspectRatio on a nil value");
			}
		}
		uIWidget.aspectRatio = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hitCheck(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hitCheck");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hitCheck on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIWidget.hitCheck = (UIWidget.HitCheck)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.HitCheck));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIWidget.hitCheck = delegate(Vector3 param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				object[] array = func.PopValues(oldTop);
				func.EndPCall(oldTop);
				return (bool)array[0];
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_panel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		uIWidget.panel = (UIPanel)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIPanel));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_storePanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name storePanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index storePanel on a nil value");
			}
		}
		uIWidget.storePanel = (UIPanel)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIPanel));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_geometry(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name geometry");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index geometry on a nil value");
			}
		}
		uIWidget.geometry = (UIGeometry)LuaScriptMgr.GetNetObject(L, 3, typeof(UIGeometry));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillGeometry(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillGeometry");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillGeometry on a nil value");
			}
		}
		uIWidget.fillGeometry = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_boxColliderCache(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boxColliderCache");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boxColliderCache on a nil value");
			}
		}
		uIWidget.boxColliderCache = (BoxCollider)LuaScriptMgr.GetUnityObject(L, 3, typeof(BoxCollider));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_calcRenderQueue(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name calcRenderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index calcRenderQueue on a nil value");
			}
		}
		uIWidget.calcRenderQueue = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawCall(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawCall");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawCall on a nil value");
			}
		}
		uIWidget.drawCall = (UIDrawCall)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIDrawCall));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawRegion(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawRegion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawRegion on a nil value");
			}
		}
		uIWidget.drawRegion = LuaScriptMgr.GetVector4(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_width(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name width");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index width on a nil value");
			}
		}
		uIWidget.width = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_height(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}
		uIWidget.height = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_color(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}
		uIWidget.color = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		uIWidget.alpha = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rawPivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rawPivot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rawPivot on a nil value");
			}
		}
		uIWidget.rawPivot = (UIWidget.Pivot)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.Pivot)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
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
		uIWidget.pivot = (UIWidget.Pivot)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.Pivot)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}
		uIWidget.depth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		uIWidget.material = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}
		uIWidget.mainTexture = (Texture)LuaScriptMgr.GetUnityObject(L, 3, typeof(Texture));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shader(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIWidget uIWidget = (UIWidget)luaObject;
		if (uIWidget == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}
		uIWidget.shader = (Shader)LuaScriptMgr.GetUnityObject(L, 3, typeof(Shader));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterUI(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		Component c = (Component)LuaScriptMgr.GetUnityObject(L, 2, typeof(Component));
		uIWidget.RegisterUI(c);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDimensions(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		int w = (int)LuaScriptMgr.GetNumber(L, 2);
		int h = (int)LuaScriptMgr.GetNumber(L, 3);
		uIWidget.SetDimensions(w, h);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSides(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		Transform relativeTo = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3[] sides = uIWidget.GetSides(relativeTo);
		LuaScriptMgr.PushArray(L, sides);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateFinalAlpha(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		int frameID = (int)LuaScriptMgr.GetNumber(L, 2);
		float d = uIWidget.CalculateFinalAlpha(frameID);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Invalidate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uIWidget.Invalidate(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateCumulativeAlpha(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		int frameID = (int)LuaScriptMgr.GetNumber(L, 2);
		float d = uIWidget.CalculateCumulativeAlpha(frameID);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		float x = (float)LuaScriptMgr.GetNumber(L, 2);
		float y = (float)LuaScriptMgr.GetNumber(L, 3);
		float width = (float)LuaScriptMgr.GetNumber(L, 4);
		float height = (float)LuaScriptMgr.GetNumber(L, 5);
		uIWidget.SetRect(x, y, width, height);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResizeCollider(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.ResizeCollider();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FullCompareFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget left = (UIWidget)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIWidget));
		UIWidget right = (UIWidget)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIWidget));
		int d = UIWidget.FullCompareFunc(left, right);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PanelCompareFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget left = (UIWidget)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIWidget));
		UIWidget right = (UIWidget)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIWidget));
		int d = UIWidget.PanelCompareFunc(left, right);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateBounds(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
			Bounds bound = uIWidget.CalculateBounds();
			LuaScriptMgr.Push(L, bound);
			return 1;
		}
		if (num == 2)
		{
			UIWidget uIWidget2 = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
			Transform relativeParent = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
			Bounds bound2 = uIWidget2.CalculateBounds(relativeParent);
			LuaScriptMgr.Push(L, bound2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIWidget.CalculateBounds");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDirty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.SetDirty();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkAsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.MarkAsChanged();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		UIPanel obj = uIWidget.CreatePanel();
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		UIPanel panel = (UIPanel)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIPanel));
		uIWidget.SetPanel(panel);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.CheckLayer();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParentHasChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.ParentHasChanged();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateVisibility(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
		bool b = uIWidget.UpdateVisibility(boolean, boolean2);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateTransform(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		int frame = (int)LuaScriptMgr.GetNumber(L, 2);
		bool b = uIWidget.UpdateTransform(frame);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateGeometry(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		int frame = (int)LuaScriptMgr.GetNumber(L, 2);
		bool b = uIWidget.UpdateGeometry(frame);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearGeometry(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.ClearGeometry();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WriteToBuffers(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		FastListV3 v = (FastListV3)LuaScriptMgr.GetNetObject(L, 2, typeof(FastListV3));
		FastListV2 u = (FastListV2)LuaScriptMgr.GetNetObject(L, 3, typeof(FastListV2));
		FastListColor32 c = (FastListColor32)LuaScriptMgr.GetNetObject(L, 4, typeof(FastListColor32));
		BetterList<Vector3> n = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 5, typeof(BetterList<Vector3>));
		BetterList<Vector4> t = (BetterList<Vector4>)LuaScriptMgr.GetNetObject(L, 6, typeof(BetterList<Vector4>));
		uIWidget.WriteToBuffers(v, u, c, n, t);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		uIWidget.MakePixelPerfect();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UIWidget uIWidget = (UIWidget)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIWidget");
		BetterList<Vector3> verts = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(BetterList<Vector3>));
		BetterList<Vector2> uvs = (BetterList<Vector2>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<Vector2>));
		BetterList<Color32> cols = (BetterList<Color32>)LuaScriptMgr.GetNetObject(L, 4, typeof(BetterList<Color32>));
		uIWidget.OnFill(verts, uvs, cols);
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
