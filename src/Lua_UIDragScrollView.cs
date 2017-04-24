using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIDragScrollView : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_scrollView(IntPtr l)
	{
		int result;
		try
		{
			UIDragScrollView uIDragScrollView = (UIDragScrollView)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIDragScrollView.scrollView);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_scrollView(IntPtr l)
	{
		int result;
		try
		{
			UIDragScrollView uIDragScrollView = (UIDragScrollView)LuaObject.checkSelf(l);
			UIScrollView scrollView;
			LuaObject.checkType<UIScrollView>(l, 2, out scrollView);
			uIDragScrollView.scrollView = scrollView;
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
		LuaObject.getTypeTable(l, "UIDragScrollView");
		LuaObject.addMember(l, "scrollView", new LuaCSFunction(Lua_UIDragScrollView.get_scrollView), new LuaCSFunction(Lua_UIDragScrollView.set_scrollView), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIDragScrollView), typeof(MonoBehaviour));
	}
}
