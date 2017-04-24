using LuaInterface;
using System;
using UnityEngine;

public class UIButtonColorWrap
{
	private static Type classType = typeof(UIButtonColor);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetState", new LuaCSFunction(UIButtonColorWrap.SetState)),
			new LuaMethod("New", new LuaCSFunction(UIButtonColorWrap._CreateUIButtonColor)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIButtonColorWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIButtonColorWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("tweenTarget", new LuaCSFunction(UIButtonColorWrap.get_tweenTarget), new LuaCSFunction(UIButtonColorWrap.set_tweenTarget)),
			new LuaField("hover", new LuaCSFunction(UIButtonColorWrap.get_hover), new LuaCSFunction(UIButtonColorWrap.set_hover)),
			new LuaField("pressed", new LuaCSFunction(UIButtonColorWrap.get_pressed), new LuaCSFunction(UIButtonColorWrap.set_pressed)),
			new LuaField("disabledColor", new LuaCSFunction(UIButtonColorWrap.get_disabledColor), new LuaCSFunction(UIButtonColorWrap.set_disabledColor)),
			new LuaField("changeStateSprite", new LuaCSFunction(UIButtonColorWrap.get_changeStateSprite), new LuaCSFunction(UIButtonColorWrap.set_changeStateSprite)),
			new LuaField("duration", new LuaCSFunction(UIButtonColorWrap.get_duration), new LuaCSFunction(UIButtonColorWrap.set_duration)),
			new LuaField("state", new LuaCSFunction(UIButtonColorWrap.get_state), new LuaCSFunction(UIButtonColorWrap.set_state)),
			new LuaField("defaultColor", new LuaCSFunction(UIButtonColorWrap.get_defaultColor), new LuaCSFunction(UIButtonColorWrap.set_defaultColor)),
			new LuaField("isEnabled", new LuaCSFunction(UIButtonColorWrap.get_isEnabled), new LuaCSFunction(UIButtonColorWrap.set_isEnabled))
		};
		LuaScriptMgr.RegisterLib(L, "UIButtonColor", typeof(UIButtonColor), regs, fields, typeof(UIWidgetContainer));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIButtonColor(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIButtonColor class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIButtonColorWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenTarget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTarget on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.tweenTarget);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hover(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hover");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hover on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.hover);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pressed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pressed on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.pressed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disabledColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disabledColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disabledColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.disabledColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_changeStateSprite(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name changeStateSprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index changeStateSprite on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.changeStateSprite);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_duration(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name duration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.duration);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_state(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name state");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index state on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.state);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.defaultColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isEnabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isEnabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isEnabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIButtonColor.isEnabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenTarget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTarget on a nil value");
			}
		}
		uIButtonColor.tweenTarget = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hover(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hover");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hover on a nil value");
			}
		}
		uIButtonColor.hover = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pressed(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pressed on a nil value");
			}
		}
		uIButtonColor.pressed = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disabledColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disabledColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disabledColor on a nil value");
			}
		}
		uIButtonColor.disabledColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_changeStateSprite(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name changeStateSprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index changeStateSprite on a nil value");
			}
		}
		uIButtonColor.changeStateSprite = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_duration(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name duration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index duration on a nil value");
			}
		}
		uIButtonColor.duration = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_state(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name state");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index state on a nil value");
			}
		}
		uIButtonColor.state = (UIButtonColor.State)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIButtonColor.State)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultColor on a nil value");
			}
		}
		uIButtonColor.defaultColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isEnabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIButtonColor uIButtonColor = (UIButtonColor)luaObject;
		if (uIButtonColor == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isEnabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isEnabled on a nil value");
			}
		}
		uIButtonColor.isEnabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIButtonColor uIButtonColor = (UIButtonColor)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIButtonColor");
		UIButtonColor.State state = (UIButtonColor.State)((int)LuaScriptMgr.GetNetObject(L, 2, typeof(UIButtonColor.State)));
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		uIButtonColor.SetState(state, boolean);
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
