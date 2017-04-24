using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIToggleWrap
{
	private static Type classType = typeof(UIToggle);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetActiveToggle", new LuaCSFunction(UIToggleWrap.GetActiveToggle)),
			new LuaMethod("ForceSetActive", new LuaCSFunction(UIToggleWrap.ForceSetActive)),
			new LuaMethod("New", new LuaCSFunction(UIToggleWrap._CreateUIToggle)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIToggleWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIToggleWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("list", new LuaCSFunction(UIToggleWrap.get_list), new LuaCSFunction(UIToggleWrap.set_list)),
			new LuaField("current", new LuaCSFunction(UIToggleWrap.get_current), new LuaCSFunction(UIToggleWrap.set_current)),
			new LuaField("group", new LuaCSFunction(UIToggleWrap.get_group), new LuaCSFunction(UIToggleWrap.set_group)),
			new LuaField("activeSprite", new LuaCSFunction(UIToggleWrap.get_activeSprite), new LuaCSFunction(UIToggleWrap.set_activeSprite)),
			new LuaField("activeSprite2", new LuaCSFunction(UIToggleWrap.get_activeSprite2), new LuaCSFunction(UIToggleWrap.set_activeSprite2)),
			new LuaField("activeAnimation", new LuaCSFunction(UIToggleWrap.get_activeAnimation), new LuaCSFunction(UIToggleWrap.set_activeAnimation)),
			new LuaField("startsActive", new LuaCSFunction(UIToggleWrap.get_startsActive), new LuaCSFunction(UIToggleWrap.set_startsActive)),
			new LuaField("instantTween", new LuaCSFunction(UIToggleWrap.get_instantTween), new LuaCSFunction(UIToggleWrap.set_instantTween)),
			new LuaField("optionCanBeNone", new LuaCSFunction(UIToggleWrap.get_optionCanBeNone), new LuaCSFunction(UIToggleWrap.set_optionCanBeNone)),
			new LuaField("onChange", new LuaCSFunction(UIToggleWrap.get_onChange), new LuaCSFunction(UIToggleWrap.set_onChange)),
			new LuaField("value", new LuaCSFunction(UIToggleWrap.get_value), new LuaCSFunction(UIToggleWrap.set_value))
		};
		LuaScriptMgr.RegisterLib(L, "UIToggle", typeof(UIToggle), regs, fields, typeof(UIWidgetContainer));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIToggle(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIToggle class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIToggleWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_list(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UIToggle.list);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIToggle.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_group(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.group);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeSprite(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeSprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeSprite on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.activeSprite);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeSprite2(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeSprite2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeSprite2 on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.activeSprite2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeAnimation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeAnimation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeAnimation on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.activeAnimation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startsActive(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startsActive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startsActive on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.startsActive);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_instantTween(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name instantTween");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index instantTween on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.instantTween);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_optionCanBeNone(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name optionCanBeNone");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index optionCanBeNone on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.optionCanBeNone);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
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
		LuaScriptMgr.PushObject(L, uIToggle.onChange);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIToggle.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		UIToggle.list = (BetterList<UIToggle>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<UIToggle>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UIToggle.current = (UIToggle)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIToggle));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_group(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}
		uIToggle.group = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeSprite(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeSprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeSprite on a nil value");
			}
		}
		uIToggle.activeSprite = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeSprite2(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeSprite2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeSprite2 on a nil value");
			}
		}
		uIToggle.activeSprite2 = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeAnimation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeAnimation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeAnimation on a nil value");
			}
		}
		uIToggle.activeAnimation = (Animation)LuaScriptMgr.GetUnityObject(L, 3, typeof(Animation));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startsActive(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startsActive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startsActive on a nil value");
			}
		}
		uIToggle.startsActive = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_instantTween(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name instantTween");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index instantTween on a nil value");
			}
		}
		uIToggle.instantTween = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_optionCanBeNone(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name optionCanBeNone");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index optionCanBeNone on a nil value");
			}
		}
		uIToggle.optionCanBeNone = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
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
		uIToggle.onChange = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIToggle uIToggle = (UIToggle)luaObject;
		if (uIToggle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}
		uIToggle.value = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetActiveToggle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int group = (int)LuaScriptMgr.GetNumber(L, 1);
		UIToggle activeToggle = UIToggle.GetActiveToggle(group);
		LuaScriptMgr.Push(L, activeToggle);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForceSetActive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIToggle uIToggle = (UIToggle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIToggle");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		uIToggle.ForceSetActive(boolean);
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
