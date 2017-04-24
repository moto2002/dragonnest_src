using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIProgressBar : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar o = new UIProgressBar();
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
	public static int ForceUpdate(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			uIProgressBar.ForceUpdate();
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
	public static int SetDynamicGround(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			float length;
			LuaObject.checkType(l, 2, out length);
			int depth;
			LuaObject.checkType(l, 3, out depth);
			uIProgressBar.SetDynamicGround(length, depth);
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
	public static int get_current(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIProgressBar.current);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_current(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar current;
			LuaObject.checkType<UIProgressBar>(l, 2, out current);
			UIProgressBar.current = current;
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
	public static int get_bHideThumbAtEnds(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.bHideThumbAtEnds);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bHideThumbAtEnds(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			bool bHideThumbAtEnds;
			LuaObject.checkType(l, 2, out bHideThumbAtEnds);
			uIProgressBar.bHideThumbAtEnds = bHideThumbAtEnds;
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
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIProgressBar.OnDragFinished onDragFinished;
			int num = LuaDelegation.checkDelegate(l, 2, out onDragFinished);
			if (num == 0)
			{
				uIProgressBar.onDragFinished = onDragFinished;
			}
			else if (num == 1)
			{
				UIProgressBar expr_30 = uIProgressBar;
				expr_30.onDragFinished = (UIProgressBar.OnDragFinished)Delegate.Combine(expr_30.onDragFinished, onDragFinished);
			}
			else if (num == 2)
			{
				UIProgressBar expr_53 = uIProgressBar;
				expr_53.onDragFinished = (UIProgressBar.OnDragFinished)Delegate.Remove(expr_53.onDragFinished, onDragFinished);
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
	public static int get_bHideFgAtEnds(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.bHideFgAtEnds);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bHideFgAtEnds(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			bool bHideFgAtEnds;
			LuaObject.checkType(l, 2, out bHideFgAtEnds);
			uIProgressBar.bHideFgAtEnds = bHideFgAtEnds;
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
	public static int get_UseFillDir(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.UseFillDir);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_UseFillDir(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			bool useFillDir;
			LuaObject.checkType(l, 2, out useFillDir);
			uIProgressBar.UseFillDir = useFillDir;
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
	public static int get_thumb(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.thumb);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_thumb(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			Transform thumb;
			LuaObject.checkType<Transform>(l, 2, out thumb);
			uIProgressBar.thumb = thumb;
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
	public static int get_mBG(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.mBG);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mBG(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIWidget mBG;
			LuaObject.checkType<UIWidget>(l, 2, out mBG);
			uIProgressBar.mBG = mBG;
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
	public static int get_mFG(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.mFG);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mFG(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIWidget mFG;
			LuaObject.checkType<UIWidget>(l, 2, out mFG);
			uIProgressBar.mFG = mFG;
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
	public static int get_mDG(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.mDG);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mDG(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIWidget mDG;
			LuaObject.checkType<UIWidget>(l, 2, out mDG);
			uIProgressBar.mDG = mDG;
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
	public static int get_numberOfSteps(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.numberOfSteps);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_numberOfSteps(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			int numberOfSteps;
			LuaObject.checkType(l, 2, out numberOfSteps);
			uIProgressBar.numberOfSteps = numberOfSteps;
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
	public static int get_onChange(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.onChange);
			result = 2;
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
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			List<EventDelegate> onChange;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onChange);
			uIProgressBar.onChange = onChange;
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
	public static int get_cachedTransform(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.cachedTransform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_cachedCamera(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.cachedCamera);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_foregroundWidget(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.foregroundWidget);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_foregroundWidget(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIWidget foregroundWidget;
			LuaObject.checkType<UIWidget>(l, 2, out foregroundWidget);
			uIProgressBar.foregroundWidget = foregroundWidget;
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
	public static int get_backgroundWidget(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.backgroundWidget);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_backgroundWidget(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIWidget backgroundWidget;
			LuaObject.checkType<UIWidget>(l, 2, out backgroundWidget);
			uIProgressBar.backgroundWidget = backgroundWidget;
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
	public static int get_fillDirection(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIProgressBar.fillDirection);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fillDirection(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			UIProgressBar.FillDirection fillDirection;
			LuaObject.checkEnum<UIProgressBar.FillDirection>(l, 2, out fillDirection);
			uIProgressBar.fillDirection = fillDirection;
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
	public static int get_value(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.value);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_value(IntPtr l)
	{
		int result;
		try
		{
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			float value;
			LuaObject.checkType(l, 2, out value);
			uIProgressBar.value = value;
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
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIProgressBar.alpha);
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
			UIProgressBar uIProgressBar = (UIProgressBar)LuaObject.checkSelf(l);
			float alpha;
			LuaObject.checkType(l, 2, out alpha);
			uIProgressBar.alpha = alpha;
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
		LuaObject.getTypeTable(l, "UIProgressBar");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIProgressBar.ForceUpdate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIProgressBar.SetDynamicGround));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIProgressBar.get_current), new LuaCSFunction(Lua_UIProgressBar.set_current), false);
		LuaObject.addMember(l, "bHideThumbAtEnds", new LuaCSFunction(Lua_UIProgressBar.get_bHideThumbAtEnds), new LuaCSFunction(Lua_UIProgressBar.set_bHideThumbAtEnds), true);
		LuaObject.addMember(l, "onDragFinished", null, new LuaCSFunction(Lua_UIProgressBar.set_onDragFinished), true);
		LuaObject.addMember(l, "bHideFgAtEnds", new LuaCSFunction(Lua_UIProgressBar.get_bHideFgAtEnds), new LuaCSFunction(Lua_UIProgressBar.set_bHideFgAtEnds), true);
		LuaObject.addMember(l, "UseFillDir", new LuaCSFunction(Lua_UIProgressBar.get_UseFillDir), new LuaCSFunction(Lua_UIProgressBar.set_UseFillDir), true);
		LuaObject.addMember(l, "thumb", new LuaCSFunction(Lua_UIProgressBar.get_thumb), new LuaCSFunction(Lua_UIProgressBar.set_thumb), true);
		LuaObject.addMember(l, "mBG", new LuaCSFunction(Lua_UIProgressBar.get_mBG), new LuaCSFunction(Lua_UIProgressBar.set_mBG), true);
		LuaObject.addMember(l, "mFG", new LuaCSFunction(Lua_UIProgressBar.get_mFG), new LuaCSFunction(Lua_UIProgressBar.set_mFG), true);
		LuaObject.addMember(l, "mDG", new LuaCSFunction(Lua_UIProgressBar.get_mDG), new LuaCSFunction(Lua_UIProgressBar.set_mDG), true);
		LuaObject.addMember(l, "numberOfSteps", new LuaCSFunction(Lua_UIProgressBar.get_numberOfSteps), new LuaCSFunction(Lua_UIProgressBar.set_numberOfSteps), true);
		LuaObject.addMember(l, "onChange", new LuaCSFunction(Lua_UIProgressBar.get_onChange), new LuaCSFunction(Lua_UIProgressBar.set_onChange), true);
		LuaObject.addMember(l, "cachedTransform", new LuaCSFunction(Lua_UIProgressBar.get_cachedTransform), null, true);
		LuaObject.addMember(l, "cachedCamera", new LuaCSFunction(Lua_UIProgressBar.get_cachedCamera), null, true);
		LuaObject.addMember(l, "foregroundWidget", new LuaCSFunction(Lua_UIProgressBar.get_foregroundWidget), new LuaCSFunction(Lua_UIProgressBar.set_foregroundWidget), true);
		LuaObject.addMember(l, "backgroundWidget", new LuaCSFunction(Lua_UIProgressBar.get_backgroundWidget), new LuaCSFunction(Lua_UIProgressBar.set_backgroundWidget), true);
		LuaObject.addMember(l, "fillDirection", new LuaCSFunction(Lua_UIProgressBar.get_fillDirection), new LuaCSFunction(Lua_UIProgressBar.set_fillDirection), true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_UIProgressBar.get_value), new LuaCSFunction(Lua_UIProgressBar.set_value), true);
		LuaObject.addMember(l, "alpha", new LuaCSFunction(Lua_UIProgressBar.get_alpha), new LuaCSFunction(Lua_UIProgressBar.set_alpha), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIProgressBar.constructor), typeof(UIProgressBar), typeof(UIWidgetContainer));
	}
}
