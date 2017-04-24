using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIScrollView : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int NeedRecalcBounds(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			uIScrollView.NeedRecalcBounds();
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
	public static int RestrictWithinBounds(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
				bool instant;
				LuaObject.checkType(l, 2, out instant);
				bool b = uIScrollView.RestrictWithinBounds(instant);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (num == 4)
			{
				UIScrollView uIScrollView2 = (UIScrollView)LuaObject.checkSelf(l);
				bool instant2;
				LuaObject.checkType(l, 2, out instant2);
				bool horizontal;
				LuaObject.checkType(l, 3, out horizontal);
				bool vertical;
				LuaObject.checkType(l, 4, out vertical);
				bool b2 = uIScrollView2.RestrictWithinBounds(instant2, horizontal, vertical);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b2);
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
	public static int DisableSpring(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			uIScrollView.DisableSpring();
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
	public static int UpdateScrollbars(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
				uIScrollView.UpdateScrollbars();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				UIScrollView uIScrollView2 = (UIScrollView)LuaObject.checkSelf(l);
				bool recalculateBounds;
				LuaObject.checkType(l, 2, out recalculateBounds);
				uIScrollView2.UpdateScrollbars(recalculateBounds);
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
	public static int SetDragAmount(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			float x;
			LuaObject.checkType(l, 2, out x);
			float y;
			LuaObject.checkType(l, 3, out y);
			bool updateScrollbars;
			LuaObject.checkType(l, 4, out updateScrollbars);
			uIScrollView.SetDragAmount(x, y, updateScrollbars);
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
	public static int ResetPosition(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
				uIScrollView.ResetPosition();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				UIScrollView uIScrollView2 = (UIScrollView)LuaObject.checkSelf(l);
				float pos;
				LuaObject.checkType(l, 2, out pos);
				uIScrollView2.ResetPosition(pos);
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
	public static int UpdatePosition(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			uIScrollView.UpdatePosition();
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
	public static int OnScrollBar(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			uIScrollView.OnScrollBar();
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
	public static int MoveRelative(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			Vector3 relative;
			LuaObject.checkType(l, 2, out relative);
			uIScrollView.MoveRelative(relative);
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
	public static int MoveAbsolute(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			Vector3 absolute;
			LuaObject.checkType(l, 2, out absolute);
			uIScrollView.MoveAbsolute(absolute);
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
	public static int Press(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			bool pressed;
			LuaObject.checkType(l, 2, out pressed);
			uIScrollView.Press(pressed);
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
	public static int Drag(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			uIScrollView.Drag();
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
	public static int Scroll(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			float delta;
			LuaObject.checkType(l, 2, out delta);
			uIScrollView.Scroll(delta);
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
	public static int SetAutoMove(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			float from;
			LuaObject.checkType(l, 2, out from);
			float to;
			LuaObject.checkType(l, 3, out to);
			float moveSpeed;
			LuaObject.checkType(l, 4, out moveSpeed);
			uIScrollView.SetAutoMove(from, to, moveSpeed);
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
	public static int get_list(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIScrollView.list);
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
			BetterList<UIScrollView> list;
			LuaObject.checkType<BetterList<UIScrollView>>(l, 2, out list);
			UIScrollView.list = list;
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
	public static int get_movement(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIScrollView.movement);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_movement(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIScrollView.Movement movement;
			LuaObject.checkEnum<UIScrollView.Movement>(l, 2, out movement);
			uIScrollView.movement = movement;
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
	public static int get_dragEffect(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIScrollView.dragEffect);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_dragEffect(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIScrollView.DragEffect dragEffect;
			LuaObject.checkEnum<UIScrollView.DragEffect>(l, 2, out dragEffect);
			uIScrollView.dragEffect = dragEffect;
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
	public static int get_restrictWithinPanel(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.restrictWithinPanel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_restrictWithinPanel(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			bool restrictWithinPanel;
			LuaObject.checkType(l, 2, out restrictWithinPanel);
			uIScrollView.restrictWithinPanel = restrictWithinPanel;
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
	public static int get_disableDragIfFits(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.disableDragIfFits);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_disableDragIfFits(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			bool disableDragIfFits;
			LuaObject.checkType(l, 2, out disableDragIfFits);
			uIScrollView.disableDragIfFits = disableDragIfFits;
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
	public static int get_smoothDragStart(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.smoothDragStart);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_smoothDragStart(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			bool smoothDragStart;
			LuaObject.checkType(l, 2, out smoothDragStart);
			uIScrollView.smoothDragStart = smoothDragStart;
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
	public static int get_iOSDragEmulation(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.iOSDragEmulation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_iOSDragEmulation(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			bool iOSDragEmulation;
			LuaObject.checkType(l, 2, out iOSDragEmulation);
			uIScrollView.iOSDragEmulation = iOSDragEmulation;
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
	public static int get_scrollWheelFactor(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.scrollWheelFactor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_scrollWheelFactor(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			float scrollWheelFactor;
			LuaObject.checkType(l, 2, out scrollWheelFactor);
			uIScrollView.scrollWheelFactor = scrollWheelFactor;
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
	public static int get_momentumAmount(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.momentumAmount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_momentumAmount(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			float momentumAmount;
			LuaObject.checkType(l, 2, out momentumAmount);
			uIScrollView.momentumAmount = momentumAmount;
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
	public static int get_horizontalScrollBar(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.horizontalScrollBar);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_horizontalScrollBar(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIProgressBar horizontalScrollBar;
			LuaObject.checkType<UIProgressBar>(l, 2, out horizontalScrollBar);
			uIScrollView.horizontalScrollBar = horizontalScrollBar;
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
	public static int get_verticalScrollBar(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.verticalScrollBar);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_verticalScrollBar(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIProgressBar verticalScrollBar;
			LuaObject.checkType<UIProgressBar>(l, 2, out verticalScrollBar);
			uIScrollView.verticalScrollBar = verticalScrollBar;
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
	public static int get_showScrollBars(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIScrollView.showScrollBars);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_showScrollBars(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIScrollView.ShowCondition showScrollBars;
			LuaObject.checkEnum<UIScrollView.ShowCondition>(l, 2, out showScrollBars);
			uIScrollView.showScrollBars = showScrollBars;
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
	public static int get_customMovement(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.customMovement);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_customMovement(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			Vector2 customMovement;
			LuaObject.checkType(l, 2, out customMovement);
			uIScrollView.customMovement = customMovement;
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
	public static int get_contentPivot(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIScrollView.contentPivot);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_contentPivot(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIWidget.Pivot contentPivot;
			LuaObject.checkEnum<UIWidget.Pivot>(l, 2, out contentPivot);
			uIScrollView.contentPivot = contentPivot;
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
	public static int set_onDragFinished(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			UIScrollView.OnDragFinished onDragFinished;
			int num = LuaDelegation.checkDelegate(l, 2, out onDragFinished);
			if (num == 0)
			{
				uIScrollView.onDragFinished = onDragFinished;
			}
			else if (num == 1)
			{
				UIScrollView expr_30 = uIScrollView;
				expr_30.onDragFinished = (UIScrollView.OnDragFinished)Delegate.Combine(expr_30.onDragFinished, onDragFinished);
			}
			else if (num == 2)
			{
				UIScrollView expr_53 = uIScrollView;
				expr_53.onDragFinished = (UIScrollView.OnDragFinished)Delegate.Remove(expr_53.onDragFinished, onDragFinished);
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
	public static int get_moveControllerTime(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.moveControllerTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_moveControllerTime(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			float moveControllerTime;
			LuaObject.checkType(l, 2, out moveControllerTime);
			uIScrollView.moveControllerTime = moveControllerTime;
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
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.panel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isDragging(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.isDragging);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_bounds(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.bounds);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_canMoveHorizontally(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.canMoveHorizontally);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_canMoveVertically(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.canMoveVertically);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_shouldMoveHorizontally(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.shouldMoveHorizontally);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_shouldMoveVertically(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.shouldMoveVertically);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_currentMomentum(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIScrollView.currentMomentum);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_currentMomentum(IntPtr l)
	{
		int result;
		try
		{
			UIScrollView uIScrollView = (UIScrollView)LuaObject.checkSelf(l);
			Vector3 currentMomentum;
			LuaObject.checkType(l, 2, out currentMomentum);
			uIScrollView.currentMomentum = currentMomentum;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIScrollView");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.NeedRecalcBounds));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.RestrictWithinBounds));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.DisableSpring));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.UpdateScrollbars));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.SetDragAmount));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.ResetPosition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.UpdatePosition));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.OnScrollBar));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.MoveRelative));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.MoveAbsolute));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.Press));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.Drag));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.Scroll));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIScrollView.SetAutoMove));
		LuaObject.addMember(l, "list", new LuaCSFunction(Lua_UIScrollView.get_list), new LuaCSFunction(Lua_UIScrollView.set_list), false);
		LuaObject.addMember(l, "movement", new LuaCSFunction(Lua_UIScrollView.get_movement), new LuaCSFunction(Lua_UIScrollView.set_movement), true);
		LuaObject.addMember(l, "dragEffect", new LuaCSFunction(Lua_UIScrollView.get_dragEffect), new LuaCSFunction(Lua_UIScrollView.set_dragEffect), true);
		LuaObject.addMember(l, "restrictWithinPanel", new LuaCSFunction(Lua_UIScrollView.get_restrictWithinPanel), new LuaCSFunction(Lua_UIScrollView.set_restrictWithinPanel), true);
		LuaObject.addMember(l, "disableDragIfFits", new LuaCSFunction(Lua_UIScrollView.get_disableDragIfFits), new LuaCSFunction(Lua_UIScrollView.set_disableDragIfFits), true);
		LuaObject.addMember(l, "smoothDragStart", new LuaCSFunction(Lua_UIScrollView.get_smoothDragStart), new LuaCSFunction(Lua_UIScrollView.set_smoothDragStart), true);
		LuaObject.addMember(l, "iOSDragEmulation", new LuaCSFunction(Lua_UIScrollView.get_iOSDragEmulation), new LuaCSFunction(Lua_UIScrollView.set_iOSDragEmulation), true);
		LuaObject.addMember(l, "scrollWheelFactor", new LuaCSFunction(Lua_UIScrollView.get_scrollWheelFactor), new LuaCSFunction(Lua_UIScrollView.set_scrollWheelFactor), true);
		LuaObject.addMember(l, "momentumAmount", new LuaCSFunction(Lua_UIScrollView.get_momentumAmount), new LuaCSFunction(Lua_UIScrollView.set_momentumAmount), true);
		LuaObject.addMember(l, "horizontalScrollBar", new LuaCSFunction(Lua_UIScrollView.get_horizontalScrollBar), new LuaCSFunction(Lua_UIScrollView.set_horizontalScrollBar), true);
		LuaObject.addMember(l, "verticalScrollBar", new LuaCSFunction(Lua_UIScrollView.get_verticalScrollBar), new LuaCSFunction(Lua_UIScrollView.set_verticalScrollBar), true);
		LuaObject.addMember(l, "showScrollBars", new LuaCSFunction(Lua_UIScrollView.get_showScrollBars), new LuaCSFunction(Lua_UIScrollView.set_showScrollBars), true);
		LuaObject.addMember(l, "customMovement", new LuaCSFunction(Lua_UIScrollView.get_customMovement), new LuaCSFunction(Lua_UIScrollView.set_customMovement), true);
		LuaObject.addMember(l, "contentPivot", new LuaCSFunction(Lua_UIScrollView.get_contentPivot), new LuaCSFunction(Lua_UIScrollView.set_contentPivot), true);
		LuaObject.addMember(l, "onDragFinished", null, new LuaCSFunction(Lua_UIScrollView.set_onDragFinished), true);
		LuaObject.addMember(l, "moveControllerTime", new LuaCSFunction(Lua_UIScrollView.get_moveControllerTime), new LuaCSFunction(Lua_UIScrollView.set_moveControllerTime), true);
		LuaObject.addMember(l, "panel", new LuaCSFunction(Lua_UIScrollView.get_panel), null, true);
		LuaObject.addMember(l, "isDragging", new LuaCSFunction(Lua_UIScrollView.get_isDragging), null, true);
		LuaObject.addMember(l, "bounds", new LuaCSFunction(Lua_UIScrollView.get_bounds), null, true);
		LuaObject.addMember(l, "canMoveHorizontally", new LuaCSFunction(Lua_UIScrollView.get_canMoveHorizontally), null, true);
		LuaObject.addMember(l, "canMoveVertically", new LuaCSFunction(Lua_UIScrollView.get_canMoveVertically), null, true);
		LuaObject.addMember(l, "shouldMoveHorizontally", new LuaCSFunction(Lua_UIScrollView.get_shouldMoveHorizontally), null, true);
		LuaObject.addMember(l, "shouldMoveVertically", new LuaCSFunction(Lua_UIScrollView.get_shouldMoveVertically), null, true);
		LuaObject.addMember(l, "currentMomentum", new LuaCSFunction(Lua_UIScrollView.get_currentMomentum), new LuaCSFunction(Lua_UIScrollView.set_currentMomentum), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIScrollView), typeof(MonoBehaviour));
	}
}
