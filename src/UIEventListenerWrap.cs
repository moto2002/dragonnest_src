using LuaInterface;
using System;
using UnityEngine;

public class UIEventListenerWrap
{
	private static Type classType = typeof(UIEventListener);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Get", new LuaCSFunction(UIEventListenerWrap.Get)),
			new LuaMethod("New", new LuaCSFunction(UIEventListenerWrap._CreateUIEventListener)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIEventListenerWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIEventListenerWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("parameter", new LuaCSFunction(UIEventListenerWrap.get_parameter), new LuaCSFunction(UIEventListenerWrap.set_parameter)),
			new LuaField("onSubmit", new LuaCSFunction(UIEventListenerWrap.get_onSubmit), new LuaCSFunction(UIEventListenerWrap.set_onSubmit)),
			new LuaField("onClick", new LuaCSFunction(UIEventListenerWrap.get_onClick), new LuaCSFunction(UIEventListenerWrap.set_onClick)),
			new LuaField("onDoubleClick", new LuaCSFunction(UIEventListenerWrap.get_onDoubleClick), new LuaCSFunction(UIEventListenerWrap.set_onDoubleClick)),
			new LuaField("onLongPress", new LuaCSFunction(UIEventListenerWrap.get_onLongPress), new LuaCSFunction(UIEventListenerWrap.set_onLongPress)),
			new LuaField("onHover", new LuaCSFunction(UIEventListenerWrap.get_onHover), new LuaCSFunction(UIEventListenerWrap.set_onHover)),
			new LuaField("onPress", new LuaCSFunction(UIEventListenerWrap.get_onPress), new LuaCSFunction(UIEventListenerWrap.set_onPress)),
			new LuaField("onSelect", new LuaCSFunction(UIEventListenerWrap.get_onSelect), new LuaCSFunction(UIEventListenerWrap.set_onSelect)),
			new LuaField("onScroll", new LuaCSFunction(UIEventListenerWrap.get_onScroll), new LuaCSFunction(UIEventListenerWrap.set_onScroll)),
			new LuaField("onDrag", new LuaCSFunction(UIEventListenerWrap.get_onDrag), new LuaCSFunction(UIEventListenerWrap.set_onDrag)),
			new LuaField("onDrop", new LuaCSFunction(UIEventListenerWrap.get_onDrop), new LuaCSFunction(UIEventListenerWrap.set_onDrop)),
			new LuaField("onKey", new LuaCSFunction(UIEventListenerWrap.get_onKey), new LuaCSFunction(UIEventListenerWrap.set_onKey))
		};
		LuaScriptMgr.RegisterLib(L, "UIEventListener", typeof(UIEventListener), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIEventListener(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIEventListener class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIEventListenerWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parameter(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parameter on a nil value");
			}
		}
		LuaScriptMgr.PushVarObject(L, uIEventListener.parameter);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSubmit(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSubmit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onSubmit);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onClick(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onClick);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDoubleClick(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDoubleClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDoubleClick on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onDoubleClick);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onLongPress(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onLongPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onLongPress on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onLongPress);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onHover(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onHover");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onHover on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onHover);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPress(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onPress on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onPress);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSelect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSelect on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onSelect);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onScroll(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onScroll");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onScroll on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onScroll);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDrag(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrag on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onDrag);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDrop(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrop on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onDrop);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onKey(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onKey");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onKey on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIEventListener.onKey);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_parameter(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parameter on a nil value");
			}
		}
		uIEventListener.parameter = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSubmit(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSubmit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onSubmit = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.VoidDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onSubmit = delegate(GameObject param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onClick = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.VoidDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onClick = delegate(GameObject param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDoubleClick(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDoubleClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDoubleClick on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onDoubleClick = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.VoidDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onDoubleClick = delegate(GameObject param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onLongPress(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onLongPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onLongPress on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onLongPress = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.VoidDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onLongPress = delegate(GameObject param0)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(oldTop, 1);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onHover(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onHover");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onHover on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onHover = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.BoolDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onHover = delegate(GameObject param0, bool param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPress(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onPress on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onPress = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.BoolDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onPress = delegate(GameObject param0, bool param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSelect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSelect on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onSelect = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.BoolDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onSelect = delegate(GameObject param0, bool param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onScroll(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onScroll");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onScroll on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onScroll = (UIEventListener.FloatDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.FloatDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onScroll = delegate(GameObject param0, float param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrag(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrag on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onDrag = (UIEventListener.VectorDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.VectorDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onDrag = delegate(GameObject param0, Vector2 param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrop(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrop on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onDrop = (UIEventListener.ObjectDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.ObjectDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onDrop = delegate(GameObject param0, GameObject param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onKey(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIEventListener uIEventListener = (UIEventListener)luaObject;
		if (uIEventListener == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onKey");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onKey on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIEventListener.onKey = (UIEventListener.KeyCodeDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIEventListener.KeyCodeDelegate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIEventListener.onKey = delegate(GameObject param0, KeyCode param1)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				func.PCall(oldTop, 2);
				func.EndPCall(oldTop);
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		UIEventListener obj = UIEventListener.Get(go);
		LuaScriptMgr.Push(L, obj);
		return 1;
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
