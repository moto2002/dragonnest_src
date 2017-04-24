using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIEventTrigger : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_current(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIEventTrigger.current);
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
			UIEventTrigger current;
			LuaObject.checkType<UIEventTrigger>(l, 2, out current);
			UIEventTrigger.current = current;
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
	public static int get_onHoverOver(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onHoverOver);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onHoverOver(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onHoverOver;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onHoverOver);
			uIEventTrigger.onHoverOver = onHoverOver;
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
	public static int get_onHoverOut(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onHoverOut);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onHoverOut(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onHoverOut;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onHoverOut);
			uIEventTrigger.onHoverOut = onHoverOut;
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
	public static int get_onPress(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onPress);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onPress(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onPress;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onPress);
			uIEventTrigger.onPress = onPress;
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
	public static int get_onRelease(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onRelease);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onRelease(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onRelease;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onRelease);
			uIEventTrigger.onRelease = onRelease;
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
	public static int get_onSelect(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onSelect);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onSelect(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onSelect;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onSelect);
			uIEventTrigger.onSelect = onSelect;
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
	public static int get_onDeselect(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onDeselect);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onDeselect(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onDeselect;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onDeselect);
			uIEventTrigger.onDeselect = onDeselect;
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
	public static int get_onClick(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onClick);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onClick(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onClick;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onClick);
			uIEventTrigger.onClick = onClick;
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
	public static int get_onDoubleClick(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onDoubleClick);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onDoubleClick(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onDoubleClick;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onDoubleClick);
			uIEventTrigger.onDoubleClick = onDoubleClick;
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
	public static int get_onDragOver(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onDragOver);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onDragOver(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onDragOver;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onDragOver);
			uIEventTrigger.onDragOver = onDragOver;
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
	public static int get_onDragOut(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventTrigger.onDragOut);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onDragOut(IntPtr l)
	{
		int result;
		try
		{
			UIEventTrigger uIEventTrigger = (UIEventTrigger)LuaObject.checkSelf(l);
			List<EventDelegate> onDragOut;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onDragOut);
			uIEventTrigger.onDragOut = onDragOut;
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
		LuaObject.getTypeTable(l, "UIEventTrigger");
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIEventTrigger.get_current), new LuaCSFunction(Lua_UIEventTrigger.set_current), false);
		LuaObject.addMember(l, "onHoverOver", new LuaCSFunction(Lua_UIEventTrigger.get_onHoverOver), new LuaCSFunction(Lua_UIEventTrigger.set_onHoverOver), true);
		LuaObject.addMember(l, "onHoverOut", new LuaCSFunction(Lua_UIEventTrigger.get_onHoverOut), new LuaCSFunction(Lua_UIEventTrigger.set_onHoverOut), true);
		LuaObject.addMember(l, "onPress", new LuaCSFunction(Lua_UIEventTrigger.get_onPress), new LuaCSFunction(Lua_UIEventTrigger.set_onPress), true);
		LuaObject.addMember(l, "onRelease", new LuaCSFunction(Lua_UIEventTrigger.get_onRelease), new LuaCSFunction(Lua_UIEventTrigger.set_onRelease), true);
		LuaObject.addMember(l, "onSelect", new LuaCSFunction(Lua_UIEventTrigger.get_onSelect), new LuaCSFunction(Lua_UIEventTrigger.set_onSelect), true);
		LuaObject.addMember(l, "onDeselect", new LuaCSFunction(Lua_UIEventTrigger.get_onDeselect), new LuaCSFunction(Lua_UIEventTrigger.set_onDeselect), true);
		LuaObject.addMember(l, "onClick", new LuaCSFunction(Lua_UIEventTrigger.get_onClick), new LuaCSFunction(Lua_UIEventTrigger.set_onClick), true);
		LuaObject.addMember(l, "onDoubleClick", new LuaCSFunction(Lua_UIEventTrigger.get_onDoubleClick), new LuaCSFunction(Lua_UIEventTrigger.set_onDoubleClick), true);
		LuaObject.addMember(l, "onDragOver", new LuaCSFunction(Lua_UIEventTrigger.get_onDragOver), new LuaCSFunction(Lua_UIEventTrigger.set_onDragOver), true);
		LuaObject.addMember(l, "onDragOut", new LuaCSFunction(Lua_UIEventTrigger.get_onDragOut), new LuaCSFunction(Lua_UIEventTrigger.set_onDragOut), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIEventTrigger), typeof(MonoBehaviour));
	}
}
