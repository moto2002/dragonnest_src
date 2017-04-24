using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIEventListener : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Get_s(IntPtr l)
	{
		int result;
		try
		{
			GameObject go;
			LuaObject.checkType<GameObject>(l, 1, out go);
			UIEventListener o = UIEventListener.Get(go);
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
	public static int get_parameter(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIEventListener.parameter);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_parameter(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			object parameter;
			LuaObject.checkType<object>(l, 2, out parameter);
			uIEventListener.parameter = parameter;
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
	public static int set_onSubmit(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.VoidDelegate voidDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out voidDelegate);
			if (num == 0)
			{
				uIEventListener.onSubmit = voidDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onSubmit = (UIEventListener.VoidDelegate)Delegate.Combine(expr_30.onSubmit, voidDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onSubmit = (UIEventListener.VoidDelegate)Delegate.Remove(expr_53.onSubmit, voidDelegate);
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
	public static int set_onClick(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.VoidDelegate voidDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out voidDelegate);
			if (num == 0)
			{
				uIEventListener.onClick = voidDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_30.onClick, voidDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_53.onClick, voidDelegate);
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
	public static int set_onDoubleClick(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.VoidDelegate voidDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out voidDelegate);
			if (num == 0)
			{
				uIEventListener.onDoubleClick = voidDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onDoubleClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_30.onDoubleClick, voidDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onDoubleClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_53.onDoubleClick, voidDelegate);
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
	public static int set_onLongPress(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.VoidDelegate voidDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out voidDelegate);
			if (num == 0)
			{
				uIEventListener.onLongPress = voidDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onLongPress = (UIEventListener.VoidDelegate)Delegate.Combine(expr_30.onLongPress, voidDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onLongPress = (UIEventListener.VoidDelegate)Delegate.Remove(expr_53.onLongPress, voidDelegate);
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
	public static int set_onHover(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.BoolDelegate boolDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out boolDelegate);
			if (num == 0)
			{
				uIEventListener.onHover = boolDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_30.onHover, boolDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onHover = (UIEventListener.BoolDelegate)Delegate.Remove(expr_53.onHover, boolDelegate);
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
	public static int set_onPress(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.BoolDelegate boolDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out boolDelegate);
			if (num == 0)
			{
				uIEventListener.onPress = boolDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(expr_30.onPress, boolDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onPress = (UIEventListener.BoolDelegate)Delegate.Remove(expr_53.onPress, boolDelegate);
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
	public static int set_onSelect(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.BoolDelegate boolDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out boolDelegate);
			if (num == 0)
			{
				uIEventListener.onSelect = boolDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onSelect = (UIEventListener.BoolDelegate)Delegate.Combine(expr_30.onSelect, boolDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onSelect = (UIEventListener.BoolDelegate)Delegate.Remove(expr_53.onSelect, boolDelegate);
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
	public static int set_onScroll(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.FloatDelegate floatDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out floatDelegate);
			if (num == 0)
			{
				uIEventListener.onScroll = floatDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onScroll = (UIEventListener.FloatDelegate)Delegate.Combine(expr_30.onScroll, floatDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onScroll = (UIEventListener.FloatDelegate)Delegate.Remove(expr_53.onScroll, floatDelegate);
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
	public static int set_onDrag(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.VectorDelegate vectorDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out vectorDelegate);
			if (num == 0)
			{
				uIEventListener.onDrag = vectorDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(expr_30.onDrag, vectorDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onDrag = (UIEventListener.VectorDelegate)Delegate.Remove(expr_53.onDrag, vectorDelegate);
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
	public static int set_onDrop(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.ObjectDelegate objectDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out objectDelegate);
			if (num == 0)
			{
				uIEventListener.onDrop = objectDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onDrop = (UIEventListener.ObjectDelegate)Delegate.Combine(expr_30.onDrop, objectDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onDrop = (UIEventListener.ObjectDelegate)Delegate.Remove(expr_53.onDrop, objectDelegate);
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
	public static int set_onKey(IntPtr l)
	{
		int result;
		try
		{
			UIEventListener uIEventListener = (UIEventListener)LuaObject.checkSelf(l);
			UIEventListener.KeyCodeDelegate keyCodeDelegate;
			int num = LuaDelegation.checkDelegate(l, 2, out keyCodeDelegate);
			if (num == 0)
			{
				uIEventListener.onKey = keyCodeDelegate;
			}
			else if (num == 1)
			{
				UIEventListener expr_30 = uIEventListener;
				expr_30.onKey = (UIEventListener.KeyCodeDelegate)Delegate.Combine(expr_30.onKey, keyCodeDelegate);
			}
			else if (num == 2)
			{
				UIEventListener expr_53 = uIEventListener;
				expr_53.onKey = (UIEventListener.KeyCodeDelegate)Delegate.Remove(expr_53.onKey, keyCodeDelegate);
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

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIEventListener");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIEventListener.Get_s));
		LuaObject.addMember(l, "parameter", new LuaCSFunction(Lua_UIEventListener.get_parameter), new LuaCSFunction(Lua_UIEventListener.set_parameter), true);
		LuaObject.addMember(l, "onSubmit", null, new LuaCSFunction(Lua_UIEventListener.set_onSubmit), true);
		LuaObject.addMember(l, "onClick", null, new LuaCSFunction(Lua_UIEventListener.set_onClick), true);
		LuaObject.addMember(l, "onDoubleClick", null, new LuaCSFunction(Lua_UIEventListener.set_onDoubleClick), true);
		LuaObject.addMember(l, "onLongPress", null, new LuaCSFunction(Lua_UIEventListener.set_onLongPress), true);
		LuaObject.addMember(l, "onHover", null, new LuaCSFunction(Lua_UIEventListener.set_onHover), true);
		LuaObject.addMember(l, "onPress", null, new LuaCSFunction(Lua_UIEventListener.set_onPress), true);
		LuaObject.addMember(l, "onSelect", null, new LuaCSFunction(Lua_UIEventListener.set_onSelect), true);
		LuaObject.addMember(l, "onScroll", null, new LuaCSFunction(Lua_UIEventListener.set_onScroll), true);
		LuaObject.addMember(l, "onDrag", null, new LuaCSFunction(Lua_UIEventListener.set_onDrag), true);
		LuaObject.addMember(l, "onDrop", null, new LuaCSFunction(Lua_UIEventListener.set_onDrop), true);
		LuaObject.addMember(l, "onKey", null, new LuaCSFunction(Lua_UIEventListener.set_onKey), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIEventListener), typeof(MonoBehaviour));
	}
}
