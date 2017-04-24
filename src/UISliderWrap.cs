using LuaInterface;
using System;
using UILib;
using UnityEngine;

public class UISliderWrap
{
	private static Type classType = typeof(UISlider);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(UISliderWrap._CreateUISlider)),
			new LuaMethod("GetClassType", new LuaCSFunction(UISliderWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UISliderWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("eventHandler", new LuaCSFunction(UISliderWrap.get_eventHandler), new LuaCSFunction(UISliderWrap.set_eventHandler))
		};
		LuaScriptMgr.RegisterLib(L, "UISlider", typeof(UISlider), regs, fields, typeof(UIProgressBar));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUISlider(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UISlider class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UISliderWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventHandler(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISlider uISlider = (UISlider)luaObject;
		if (uISlider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventHandler");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventHandler on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISlider.eventHandler);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventHandler(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISlider uISlider = (UISlider)luaObject;
		if (uISlider == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventHandler");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventHandler on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uISlider.eventHandler = (SliderValueChangeEventHandler)LuaScriptMgr.GetNetObject(L, 3, typeof(SliderValueChangeEventHandler));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uISlider.eventHandler = delegate(float param0)
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
