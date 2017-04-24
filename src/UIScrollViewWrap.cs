using LuaInterface;
using System;
using UnityEngine;

public class UIScrollViewWrap
{
	private static Type classType = typeof(UIScrollView);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("NeedRecalcBounds", new LuaCSFunction(UIScrollViewWrap.NeedRecalcBounds)),
			new LuaMethod("RestrictWithinBounds", new LuaCSFunction(UIScrollViewWrap.RestrictWithinBounds)),
			new LuaMethod("DisableSpring", new LuaCSFunction(UIScrollViewWrap.DisableSpring)),
			new LuaMethod("UpdateScrollbars", new LuaCSFunction(UIScrollViewWrap.UpdateScrollbars)),
			new LuaMethod("SetDragAmount", new LuaCSFunction(UIScrollViewWrap.SetDragAmount)),
			new LuaMethod("ResetPosition", new LuaCSFunction(UIScrollViewWrap.ResetPosition)),
			new LuaMethod("UpdatePosition", new LuaCSFunction(UIScrollViewWrap.UpdatePosition)),
			new LuaMethod("OnScrollBar", new LuaCSFunction(UIScrollViewWrap.OnScrollBar)),
			new LuaMethod("MoveRelative", new LuaCSFunction(UIScrollViewWrap.MoveRelative)),
			new LuaMethod("MoveAbsolute", new LuaCSFunction(UIScrollViewWrap.MoveAbsolute)),
			new LuaMethod("Press", new LuaCSFunction(UIScrollViewWrap.Press)),
			new LuaMethod("Drag", new LuaCSFunction(UIScrollViewWrap.Drag)),
			new LuaMethod("Scroll", new LuaCSFunction(UIScrollViewWrap.Scroll)),
			new LuaMethod("SetAutoMove", new LuaCSFunction(UIScrollViewWrap.SetAutoMove)),
			new LuaMethod("New", new LuaCSFunction(UIScrollViewWrap._CreateUIScrollView)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIScrollViewWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIScrollViewWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("list", new LuaCSFunction(UIScrollViewWrap.get_list), new LuaCSFunction(UIScrollViewWrap.set_list)),
			new LuaField("movement", new LuaCSFunction(UIScrollViewWrap.get_movement), new LuaCSFunction(UIScrollViewWrap.set_movement)),
			new LuaField("dragEffect", new LuaCSFunction(UIScrollViewWrap.get_dragEffect), new LuaCSFunction(UIScrollViewWrap.set_dragEffect)),
			new LuaField("restrictWithinPanel", new LuaCSFunction(UIScrollViewWrap.get_restrictWithinPanel), new LuaCSFunction(UIScrollViewWrap.set_restrictWithinPanel)),
			new LuaField("disableDragIfFits", new LuaCSFunction(UIScrollViewWrap.get_disableDragIfFits), new LuaCSFunction(UIScrollViewWrap.set_disableDragIfFits)),
			new LuaField("smoothDragStart", new LuaCSFunction(UIScrollViewWrap.get_smoothDragStart), new LuaCSFunction(UIScrollViewWrap.set_smoothDragStart)),
			new LuaField("iOSDragEmulation", new LuaCSFunction(UIScrollViewWrap.get_iOSDragEmulation), new LuaCSFunction(UIScrollViewWrap.set_iOSDragEmulation)),
			new LuaField("scrollWheelFactor", new LuaCSFunction(UIScrollViewWrap.get_scrollWheelFactor), new LuaCSFunction(UIScrollViewWrap.set_scrollWheelFactor)),
			new LuaField("momentumAmount", new LuaCSFunction(UIScrollViewWrap.get_momentumAmount), new LuaCSFunction(UIScrollViewWrap.set_momentumAmount)),
			new LuaField("horizontalScrollBar", new LuaCSFunction(UIScrollViewWrap.get_horizontalScrollBar), new LuaCSFunction(UIScrollViewWrap.set_horizontalScrollBar)),
			new LuaField("verticalScrollBar", new LuaCSFunction(UIScrollViewWrap.get_verticalScrollBar), new LuaCSFunction(UIScrollViewWrap.set_verticalScrollBar)),
			new LuaField("showScrollBars", new LuaCSFunction(UIScrollViewWrap.get_showScrollBars), new LuaCSFunction(UIScrollViewWrap.set_showScrollBars)),
			new LuaField("customMovement", new LuaCSFunction(UIScrollViewWrap.get_customMovement), new LuaCSFunction(UIScrollViewWrap.set_customMovement)),
			new LuaField("contentPivot", new LuaCSFunction(UIScrollViewWrap.get_contentPivot), new LuaCSFunction(UIScrollViewWrap.set_contentPivot)),
			new LuaField("onDragFinished", new LuaCSFunction(UIScrollViewWrap.get_onDragFinished), new LuaCSFunction(UIScrollViewWrap.set_onDragFinished)),
			new LuaField("moveControllerTime", new LuaCSFunction(UIScrollViewWrap.get_moveControllerTime), new LuaCSFunction(UIScrollViewWrap.set_moveControllerTime)),
			new LuaField("panel", new LuaCSFunction(UIScrollViewWrap.get_panel), null),
			new LuaField("isDragging", new LuaCSFunction(UIScrollViewWrap.get_isDragging), null),
			new LuaField("bounds", new LuaCSFunction(UIScrollViewWrap.get_bounds), null),
			new LuaField("canMoveHorizontally", new LuaCSFunction(UIScrollViewWrap.get_canMoveHorizontally), null),
			new LuaField("canMoveVertically", new LuaCSFunction(UIScrollViewWrap.get_canMoveVertically), null),
			new LuaField("shouldMoveHorizontally", new LuaCSFunction(UIScrollViewWrap.get_shouldMoveHorizontally), null),
			new LuaField("shouldMoveVertically", new LuaCSFunction(UIScrollViewWrap.get_shouldMoveVertically), null),
			new LuaField("currentMomentum", new LuaCSFunction(UIScrollViewWrap.get_currentMomentum), new LuaCSFunction(UIScrollViewWrap.set_currentMomentum))
		};
		LuaScriptMgr.RegisterLib(L, "UIScrollView", typeof(UIScrollView), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIScrollView(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIScrollView class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIScrollViewWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_list(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UIScrollView.list);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_movement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name movement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index movement on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.movement);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dragEffect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragEffect on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.dragEffect);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_restrictWithinPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name restrictWithinPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index restrictWithinPanel on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.restrictWithinPanel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disableDragIfFits(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableDragIfFits");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableDragIfFits on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.disableDragIfFits);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_smoothDragStart(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name smoothDragStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index smoothDragStart on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.smoothDragStart);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_iOSDragEmulation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name iOSDragEmulation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index iOSDragEmulation on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.iOSDragEmulation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scrollWheelFactor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollWheelFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollWheelFactor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.scrollWheelFactor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_momentumAmount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name momentumAmount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index momentumAmount on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.momentumAmount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizontalScrollBar(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name horizontalScrollBar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index horizontalScrollBar on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.horizontalScrollBar);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verticalScrollBar(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name verticalScrollBar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index verticalScrollBar on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.verticalScrollBar);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showScrollBars(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name showScrollBars");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index showScrollBars on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.showScrollBars);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_customMovement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name customMovement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index customMovement on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.customMovement);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_contentPivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name contentPivot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index contentPivot on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.contentPivot);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragFinished on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.onDragFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_moveControllerTime(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name moveControllerTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index moveControllerTime on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.moveControllerTime);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_panel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
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
		LuaScriptMgr.Push(L, uIScrollView.panel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDragging(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDragging");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDragging on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.isDragging);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.bounds);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canMoveHorizontally(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canMoveHorizontally");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canMoveHorizontally on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.canMoveHorizontally);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canMoveVertically(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canMoveVertically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canMoveVertically on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.canMoveVertically);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shouldMoveHorizontally(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shouldMoveHorizontally");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shouldMoveHorizontally on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.shouldMoveHorizontally);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shouldMoveVertically(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shouldMoveVertically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shouldMoveVertically on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.shouldMoveVertically);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentMomentum(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentMomentum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentMomentum on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIScrollView.currentMomentum);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		UIScrollView.list = (BetterList<UIScrollView>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<UIScrollView>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_movement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name movement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index movement on a nil value");
			}
		}
		uIScrollView.movement = (UIScrollView.Movement)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIScrollView.Movement)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dragEffect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragEffect on a nil value");
			}
		}
		uIScrollView.dragEffect = (UIScrollView.DragEffect)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIScrollView.DragEffect)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_restrictWithinPanel(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name restrictWithinPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index restrictWithinPanel on a nil value");
			}
		}
		uIScrollView.restrictWithinPanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disableDragIfFits(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableDragIfFits");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableDragIfFits on a nil value");
			}
		}
		uIScrollView.disableDragIfFits = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_smoothDragStart(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name smoothDragStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index smoothDragStart on a nil value");
			}
		}
		uIScrollView.smoothDragStart = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_iOSDragEmulation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name iOSDragEmulation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index iOSDragEmulation on a nil value");
			}
		}
		uIScrollView.iOSDragEmulation = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scrollWheelFactor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollWheelFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollWheelFactor on a nil value");
			}
		}
		uIScrollView.scrollWheelFactor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_momentumAmount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name momentumAmount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index momentumAmount on a nil value");
			}
		}
		uIScrollView.momentumAmount = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizontalScrollBar(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name horizontalScrollBar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index horizontalScrollBar on a nil value");
			}
		}
		uIScrollView.horizontalScrollBar = (UIProgressBar)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIProgressBar));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verticalScrollBar(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name verticalScrollBar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index verticalScrollBar on a nil value");
			}
		}
		uIScrollView.verticalScrollBar = (UIProgressBar)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIProgressBar));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showScrollBars(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name showScrollBars");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index showScrollBars on a nil value");
			}
		}
		uIScrollView.showScrollBars = (UIScrollView.ShowCondition)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIScrollView.ShowCondition)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_customMovement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name customMovement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index customMovement on a nil value");
			}
		}
		uIScrollView.customMovement = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_contentPivot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name contentPivot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index contentPivot on a nil value");
			}
		}
		uIScrollView.contentPivot = (UIWidget.Pivot)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIWidget.Pivot)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragFinished on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIScrollView.onDragFinished = (UIScrollView.OnDragFinished)LuaScriptMgr.GetNetObject(L, 3, typeof(UIScrollView.OnDragFinished));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIScrollView.onDragFinished = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_moveControllerTime(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name moveControllerTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index moveControllerTime on a nil value");
			}
		}
		uIScrollView.moveControllerTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentMomentum(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIScrollView uIScrollView = (UIScrollView)luaObject;
		if (uIScrollView == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentMomentum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentMomentum on a nil value");
			}
		}
		uIScrollView.currentMomentum = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NeedRecalcBounds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		uIScrollView.NeedRecalcBounds();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RestrictWithinBounds(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			bool b = uIScrollView.RestrictWithinBounds(boolean);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 4)
		{
			UIScrollView uIScrollView2 = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 2);
			bool boolean3 = LuaScriptMgr.GetBoolean(L, 3);
			bool boolean4 = LuaScriptMgr.GetBoolean(L, 4);
			bool b2 = uIScrollView2.RestrictWithinBounds(boolean2, boolean3, boolean4);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIScrollView.RestrictWithinBounds");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DisableSpring(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		uIScrollView.DisableSpring();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateScrollbars(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
			uIScrollView.UpdateScrollbars();
			return 0;
		}
		if (num == 2)
		{
			UIScrollView uIScrollView2 = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			uIScrollView2.UpdateScrollbars(boolean);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIScrollView.UpdateScrollbars");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDragAmount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		float x = (float)LuaScriptMgr.GetNumber(L, 2);
		float y = (float)LuaScriptMgr.GetNumber(L, 3);
		bool boolean = LuaScriptMgr.GetBoolean(L, 4);
		uIScrollView.SetDragAmount(x, y, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetPosition(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
			uIScrollView.ResetPosition();
			return 0;
		}
		if (num == 2)
		{
			UIScrollView uIScrollView2 = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
			float pos = (float)LuaScriptMgr.GetNumber(L, 2);
			uIScrollView2.ResetPosition(pos);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIScrollView.ResetPosition");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdatePosition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		uIScrollView.UpdatePosition();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnScrollBar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		uIScrollView.OnScrollBar();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveRelative(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		uIScrollView.MoveRelative(vector);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveAbsolute(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		Vector3 vector = LuaScriptMgr.GetVector3(L, 2);
		uIScrollView.MoveAbsolute(vector);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Press(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uIScrollView.Press(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Drag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		uIScrollView.Drag();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Scroll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		float delta = (float)LuaScriptMgr.GetNumber(L, 2);
		uIScrollView.Scroll(delta);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAutoMove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UIScrollView uIScrollView = (UIScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIScrollView");
		float from = (float)LuaScriptMgr.GetNumber(L, 2);
		float to = (float)LuaScriptMgr.GetNumber(L, 3);
		float moveSpeed = (float)LuaScriptMgr.GetNumber(L, 4);
		uIScrollView.SetAutoMove(from, to, moveSpeed);
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
