using LuaInterface;
using System;
using UnityEngine;

public class UICameraWrap
{
	private static Type classType = typeof(UICamera);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("IsPressed", new LuaCSFunction(UICameraWrap.IsPressed)),
			new LuaMethod("Raycast", new LuaCSFunction(UICameraWrap.Raycast)),
			new LuaMethod("IsHighlighted", new LuaCSFunction(UICameraWrap.IsHighlighted)),
			new LuaMethod("FindCameraForLayer", new LuaCSFunction(UICameraWrap.FindCameraForLayer)),
			new LuaMethod("Notify", new LuaCSFunction(UICameraWrap.Notify)),
			new LuaMethod("FindPath", new LuaCSFunction(UICameraWrap.FindPath)),
			new LuaMethod("GetMouse", new LuaCSFunction(UICameraWrap.GetMouse)),
			new LuaMethod("GetTouch", new LuaCSFunction(UICameraWrap.GetTouch)),
			new LuaMethod("RemoveTouch", new LuaCSFunction(UICameraWrap.RemoveTouch)),
			new LuaMethod("ProcessMouse", new LuaCSFunction(UICameraWrap.ProcessMouse)),
			new LuaMethod("ProcessTouches", new LuaCSFunction(UICameraWrap.ProcessTouches)),
			new LuaMethod("ProcessOthers", new LuaCSFunction(UICameraWrap.ProcessOthers)),
			new LuaMethod("ProcessTouch", new LuaCSFunction(UICameraWrap.ProcessTouch)),
			new LuaMethod("ShowTooltip", new LuaCSFunction(UICameraWrap.ShowTooltip)),
			new LuaMethod("New", new LuaCSFunction(UICameraWrap._CreateUICamera)),
			new LuaMethod("GetClassType", new LuaCSFunction(UICameraWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UICameraWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("list", new LuaCSFunction(UICameraWrap.get_list), new LuaCSFunction(UICameraWrap.set_list)),
			new LuaField("onScreenResize", new LuaCSFunction(UICameraWrap.get_onScreenResize), new LuaCSFunction(UICameraWrap.set_onScreenResize)),
			new LuaField("eventType", new LuaCSFunction(UICameraWrap.get_eventType), new LuaCSFunction(UICameraWrap.set_eventType)),
			new LuaField("eventReceiverMask", new LuaCSFunction(UICameraWrap.get_eventReceiverMask), new LuaCSFunction(UICameraWrap.set_eventReceiverMask)),
			new LuaField("debug", new LuaCSFunction(UICameraWrap.get_debug), new LuaCSFunction(UICameraWrap.set_debug)),
			new LuaField("useMouse", new LuaCSFunction(UICameraWrap.get_useMouse), new LuaCSFunction(UICameraWrap.set_useMouse)),
			new LuaField("useTouch", new LuaCSFunction(UICameraWrap.get_useTouch), new LuaCSFunction(UICameraWrap.set_useTouch)),
			new LuaField("allowMultiTouch", new LuaCSFunction(UICameraWrap.get_allowMultiTouch), new LuaCSFunction(UICameraWrap.set_allowMultiTouch)),
			new LuaField("useKeyboard", new LuaCSFunction(UICameraWrap.get_useKeyboard), new LuaCSFunction(UICameraWrap.set_useKeyboard)),
			new LuaField("useController", new LuaCSFunction(UICameraWrap.get_useController), new LuaCSFunction(UICameraWrap.set_useController)),
			new LuaField("stickyTooltip", new LuaCSFunction(UICameraWrap.get_stickyTooltip), new LuaCSFunction(UICameraWrap.set_stickyTooltip)),
			new LuaField("tooltipDelay", new LuaCSFunction(UICameraWrap.get_tooltipDelay), new LuaCSFunction(UICameraWrap.set_tooltipDelay)),
			new LuaField("mouseDragThreshold", new LuaCSFunction(UICameraWrap.get_mouseDragThreshold), new LuaCSFunction(UICameraWrap.set_mouseDragThreshold)),
			new LuaField("mouseClickThreshold", new LuaCSFunction(UICameraWrap.get_mouseClickThreshold), new LuaCSFunction(UICameraWrap.set_mouseClickThreshold)),
			new LuaField("touchDragThreshold", new LuaCSFunction(UICameraWrap.get_touchDragThreshold), new LuaCSFunction(UICameraWrap.set_touchDragThreshold)),
			new LuaField("touchClickThreshold", new LuaCSFunction(UICameraWrap.get_touchClickThreshold), new LuaCSFunction(UICameraWrap.set_touchClickThreshold)),
			new LuaField("rangeDistance", new LuaCSFunction(UICameraWrap.get_rangeDistance), new LuaCSFunction(UICameraWrap.set_rangeDistance)),
			new LuaField("scrollAxisName", new LuaCSFunction(UICameraWrap.get_scrollAxisName), new LuaCSFunction(UICameraWrap.set_scrollAxisName)),
			new LuaField("verticalAxisName", new LuaCSFunction(UICameraWrap.get_verticalAxisName), new LuaCSFunction(UICameraWrap.set_verticalAxisName)),
			new LuaField("horizontalAxisName", new LuaCSFunction(UICameraWrap.get_horizontalAxisName), new LuaCSFunction(UICameraWrap.set_horizontalAxisName)),
			new LuaField("submitKey0", new LuaCSFunction(UICameraWrap.get_submitKey0), new LuaCSFunction(UICameraWrap.set_submitKey0)),
			new LuaField("submitKey1", new LuaCSFunction(UICameraWrap.get_submitKey1), new LuaCSFunction(UICameraWrap.set_submitKey1)),
			new LuaField("cancelKey0", new LuaCSFunction(UICameraWrap.get_cancelKey0), new LuaCSFunction(UICameraWrap.set_cancelKey0)),
			new LuaField("cancelKey1", new LuaCSFunction(UICameraWrap.get_cancelKey1), new LuaCSFunction(UICameraWrap.set_cancelKey1)),
			new LuaField("touchFx", new LuaCSFunction(UICameraWrap.get_touchFx), new LuaCSFunction(UICameraWrap.set_touchFx)),
			new LuaField("onCustomInput", new LuaCSFunction(UICameraWrap.get_onCustomInput), new LuaCSFunction(UICameraWrap.set_onCustomInput)),
			new LuaField("showTooltips", new LuaCSFunction(UICameraWrap.get_showTooltips), new LuaCSFunction(UICameraWrap.set_showTooltips)),
			new LuaField("lastTouchPosition", new LuaCSFunction(UICameraWrap.get_lastTouchPosition), new LuaCSFunction(UICameraWrap.set_lastTouchPosition)),
			new LuaField("lastClickPosition", new LuaCSFunction(UICameraWrap.get_lastClickPosition), new LuaCSFunction(UICameraWrap.set_lastClickPosition)),
			new LuaField("lastHit", new LuaCSFunction(UICameraWrap.get_lastHit), new LuaCSFunction(UICameraWrap.set_lastHit)),
			new LuaField("current", new LuaCSFunction(UICameraWrap.get_current), new LuaCSFunction(UICameraWrap.set_current)),
			new LuaField("currentCamera", new LuaCSFunction(UICameraWrap.get_currentCamera), new LuaCSFunction(UICameraWrap.set_currentCamera)),
			new LuaField("currentScheme", new LuaCSFunction(UICameraWrap.get_currentScheme), new LuaCSFunction(UICameraWrap.set_currentScheme)),
			new LuaField("currentTouchID", new LuaCSFunction(UICameraWrap.get_currentTouchID), new LuaCSFunction(UICameraWrap.set_currentTouchID)),
			new LuaField("currentKey", new LuaCSFunction(UICameraWrap.get_currentKey), new LuaCSFunction(UICameraWrap.set_currentKey)),
			new LuaField("currentTouch", new LuaCSFunction(UICameraWrap.get_currentTouch), new LuaCSFunction(UICameraWrap.set_currentTouch)),
			new LuaField("inputHasFocus", new LuaCSFunction(UICameraWrap.get_inputHasFocus), new LuaCSFunction(UICameraWrap.set_inputHasFocus)),
			new LuaField("genericEventHandler", new LuaCSFunction(UICameraWrap.get_genericEventHandler), new LuaCSFunction(UICameraWrap.set_genericEventHandler)),
			new LuaField("fallThrough", new LuaCSFunction(UICameraWrap.get_fallThrough), new LuaCSFunction(UICameraWrap.set_fallThrough)),
			new LuaField("controller", new LuaCSFunction(UICameraWrap.get_controller), new LuaCSFunction(UICameraWrap.set_controller)),
			new LuaField("isDragging", new LuaCSFunction(UICameraWrap.get_isDragging), new LuaCSFunction(UICameraWrap.set_isDragging)),
			new LuaField("hoveredObject", new LuaCSFunction(UICameraWrap.get_hoveredObject), new LuaCSFunction(UICameraWrap.set_hoveredObject)),
			new LuaField("clickpath", new LuaCSFunction(UICameraWrap.get_clickpath), new LuaCSFunction(UICameraWrap.set_clickpath)),
			new LuaField("currentRay", new LuaCSFunction(UICameraWrap.get_currentRay), null),
			new LuaField("cachedCamera", new LuaCSFunction(UICameraWrap.get_cachedCamera), null),
			new LuaField("selectedObject", new LuaCSFunction(UICameraWrap.get_selectedObject), new LuaCSFunction(UICameraWrap.set_selectedObject)),
			new LuaField("touchCount", new LuaCSFunction(UICameraWrap.get_touchCount), null),
			new LuaField("dragCount", new LuaCSFunction(UICameraWrap.get_dragCount), null),
			new LuaField("mainCamera", new LuaCSFunction(UICameraWrap.get_mainCamera), null),
			new LuaField("eventHandler", new LuaCSFunction(UICameraWrap.get_eventHandler), null)
		};
		LuaScriptMgr.RegisterLib(L, "UICamera", typeof(UICamera), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUICamera(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UICamera class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICameraWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_list(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UICamera.list);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onScreenResize(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.onScreenResize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.eventType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventReceiverMask(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventReceiverMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventReceiverMask on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, uICamera.eventReceiverMask);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_debug(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name debug");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index debug on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.debug);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useMouse(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMouse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMouse on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.useMouse);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useTouch(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useTouch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useTouch on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.useTouch);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allowMultiTouch(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowMultiTouch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowMultiTouch on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.allowMultiTouch);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useKeyboard(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useKeyboard");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useKeyboard on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.useKeyboard);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useController(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useController");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useController on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.useController);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stickyTooltip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stickyTooltip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stickyTooltip on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.stickyTooltip);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tooltipDelay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tooltipDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tooltipDelay on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.tooltipDelay);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mouseDragThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mouseDragThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mouseDragThreshold on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.mouseDragThreshold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mouseClickThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mouseClickThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mouseClickThreshold on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.mouseClickThreshold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchDragThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchDragThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchDragThreshold on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.touchDragThreshold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchClickThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchClickThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchClickThreshold on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.touchClickThreshold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rangeDistance(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rangeDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rangeDistance on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.rangeDistance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scrollAxisName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollAxisName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollAxisName on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.scrollAxisName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verticalAxisName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name verticalAxisName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index verticalAxisName on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.verticalAxisName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizontalAxisName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name horizontalAxisName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index horizontalAxisName on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.horizontalAxisName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_submitKey0(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name submitKey0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index submitKey0 on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.submitKey0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_submitKey1(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name submitKey1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index submitKey1 on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.submitKey1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cancelKey0(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cancelKey0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cancelKey0 on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.cancelKey0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cancelKey1(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cancelKey1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cancelKey1 on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.cancelKey1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchFx(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchFx");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchFx on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.touchFx);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onCustomInput(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.onCustomInput);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showTooltips(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.showTooltips);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastTouchPosition(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.lastTouchPosition);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastClickPosition(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.lastClickPosition);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastHit(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.lastHit);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentCamera(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.currentCamera);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentScheme(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.currentScheme);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentTouchID(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.currentTouchID);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentKey(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.currentKey);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentTouch(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UICamera.currentTouch);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputHasFocus(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.inputHasFocus);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_genericEventHandler(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.genericEventHandler);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fallThrough(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.fallThrough);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_controller(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UICamera.controller);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDragging(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.isDragging);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hoveredObject(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.hoveredObject);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clickpath(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.clickpath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentRay(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.currentRay);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedCamera(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedCamera on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uICamera.cachedCamera);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectedObject(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.selectedObject);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.touchCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dragCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.dragCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainCamera(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.mainCamera);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventHandler(IntPtr L)
	{
		LuaScriptMgr.Push(L, UICamera.eventHandler);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		UICamera.list = (BetterList<UICamera>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<UICamera>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onScreenResize(IntPtr L)
	{
		LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			UICamera.onScreenResize = (UICamera.OnScreenResize)LuaScriptMgr.GetNetObject(L, 3, typeof(UICamera.OnScreenResize));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			UICamera.onScreenResize = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventType on a nil value");
			}
		}
		uICamera.eventType = (UICamera.EventType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UICamera.EventType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventReceiverMask(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventReceiverMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventReceiverMask on a nil value");
			}
		}
		uICamera.eventReceiverMask = (LayerMask)LuaScriptMgr.GetNetObject(L, 3, typeof(LayerMask));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_debug(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name debug");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index debug on a nil value");
			}
		}
		uICamera.debug = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useMouse(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMouse");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMouse on a nil value");
			}
		}
		uICamera.useMouse = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useTouch(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useTouch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useTouch on a nil value");
			}
		}
		uICamera.useTouch = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_allowMultiTouch(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowMultiTouch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowMultiTouch on a nil value");
			}
		}
		uICamera.allowMultiTouch = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useKeyboard(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useKeyboard");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useKeyboard on a nil value");
			}
		}
		uICamera.useKeyboard = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useController(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useController");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useController on a nil value");
			}
		}
		uICamera.useController = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stickyTooltip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stickyTooltip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stickyTooltip on a nil value");
			}
		}
		uICamera.stickyTooltip = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tooltipDelay(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tooltipDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tooltipDelay on a nil value");
			}
		}
		uICamera.tooltipDelay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mouseDragThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mouseDragThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mouseDragThreshold on a nil value");
			}
		}
		uICamera.mouseDragThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mouseClickThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mouseClickThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mouseClickThreshold on a nil value");
			}
		}
		uICamera.mouseClickThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_touchDragThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchDragThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchDragThreshold on a nil value");
			}
		}
		uICamera.touchDragThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_touchClickThreshold(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchClickThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchClickThreshold on a nil value");
			}
		}
		uICamera.touchClickThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rangeDistance(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rangeDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rangeDistance on a nil value");
			}
		}
		uICamera.rangeDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scrollAxisName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollAxisName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollAxisName on a nil value");
			}
		}
		uICamera.scrollAxisName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verticalAxisName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name verticalAxisName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index verticalAxisName on a nil value");
			}
		}
		uICamera.verticalAxisName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizontalAxisName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name horizontalAxisName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index horizontalAxisName on a nil value");
			}
		}
		uICamera.horizontalAxisName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_submitKey0(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name submitKey0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index submitKey0 on a nil value");
			}
		}
		uICamera.submitKey0 = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_submitKey1(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name submitKey1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index submitKey1 on a nil value");
			}
		}
		uICamera.submitKey1 = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cancelKey0(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cancelKey0");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cancelKey0 on a nil value");
			}
		}
		uICamera.cancelKey0 = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cancelKey1(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cancelKey1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cancelKey1 on a nil value");
			}
		}
		uICamera.cancelKey1 = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_touchFx(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UICamera uICamera = (UICamera)luaObject;
		if (uICamera == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchFx");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchFx on a nil value");
			}
		}
		uICamera.touchFx = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onCustomInput(IntPtr L)
	{
		LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			UICamera.onCustomInput = (UICamera.OnCustomInput)LuaScriptMgr.GetNetObject(L, 3, typeof(UICamera.OnCustomInput));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			UICamera.onCustomInput = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showTooltips(IntPtr L)
	{
		UICamera.showTooltips = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastTouchPosition(IntPtr L)
	{
		UICamera.lastTouchPosition = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastClickPosition(IntPtr L)
	{
		UICamera.lastClickPosition = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastHit(IntPtr L)
	{
		UICamera.lastHit = (RaycastHit)LuaScriptMgr.GetNetObject(L, 3, typeof(RaycastHit));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UICamera.current = (UICamera)LuaScriptMgr.GetUnityObject(L, 3, typeof(UICamera));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentCamera(IntPtr L)
	{
		UICamera.currentCamera = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentScheme(IntPtr L)
	{
		UICamera.currentScheme = (UICamera.ControlScheme)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UICamera.ControlScheme)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentTouchID(IntPtr L)
	{
		UICamera.currentTouchID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentKey(IntPtr L)
	{
		UICamera.currentKey = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentTouch(IntPtr L)
	{
		UICamera.currentTouch = (UICamera.MouseOrTouch)LuaScriptMgr.GetNetObject(L, 3, typeof(UICamera.MouseOrTouch));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inputHasFocus(IntPtr L)
	{
		UICamera.inputHasFocus = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_genericEventHandler(IntPtr L)
	{
		UICamera.genericEventHandler = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fallThrough(IntPtr L)
	{
		UICamera.fallThrough = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_controller(IntPtr L)
	{
		UICamera.controller = (UICamera.MouseOrTouch)LuaScriptMgr.GetNetObject(L, 3, typeof(UICamera.MouseOrTouch));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isDragging(IntPtr L)
	{
		UICamera.isDragging = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hoveredObject(IntPtr L)
	{
		UICamera.hoveredObject = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clickpath(IntPtr L)
	{
		UICamera.clickpath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectedObject(IntPtr L)
	{
		UICamera.selectedObject = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPressed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		bool b = UICamera.IsPressed(go);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
		RaycastHit hit;
		bool b = UICamera.Raycast(vector, out hit);
		LuaScriptMgr.Push(L, b);
		LuaScriptMgr.Push(L, hit);
		return 2;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsHighlighted(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		bool b = UICamera.IsHighlighted(go);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindCameraForLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int layer = (int)LuaScriptMgr.GetNumber(L, 1);
		UICamera obj = UICamera.FindCameraForLayer(layer);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Notify(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		UICamera.Notify(go, luaString, varObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string str = UICamera.FindPath(go);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int button = (int)LuaScriptMgr.GetNumber(L, 1);
		UICamera.MouseOrTouch mouse = UICamera.GetMouse(button);
		LuaScriptMgr.PushObject(L, mouse);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTouch(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int id = (int)LuaScriptMgr.GetNumber(L, 1);
		UICamera.MouseOrTouch touch = UICamera.GetTouch(id);
		LuaScriptMgr.PushObject(L, touch);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveTouch(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int id = (int)LuaScriptMgr.GetNumber(L, 1);
		UICamera.RemoveTouch(id);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessMouse(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UICamera uICamera = (UICamera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICamera");
		uICamera.ProcessMouse();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessTouches(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UICamera uICamera = (UICamera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICamera");
		uICamera.ProcessTouches();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessOthers(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UICamera uICamera = (UICamera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICamera");
		uICamera.ProcessOthers();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessTouch(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UICamera uICamera = (UICamera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICamera");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
		uICamera.ProcessTouch(boolean, boolean2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ShowTooltip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UICamera uICamera = (UICamera)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICamera");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uICamera.ShowTooltip(boolean);
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
