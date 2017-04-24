using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIProgressBarWrap
{
	private static Type classType = typeof(UIProgressBar);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ForceUpdate", new LuaCSFunction(UIProgressBarWrap.ForceUpdate)),
			new LuaMethod("SetDynamicGround", new LuaCSFunction(UIProgressBarWrap.SetDynamicGround)),
			new LuaMethod("New", new LuaCSFunction(UIProgressBarWrap._CreateUIProgressBar)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIProgressBarWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIProgressBarWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", new LuaCSFunction(UIProgressBarWrap.get_current), new LuaCSFunction(UIProgressBarWrap.set_current)),
			new LuaField("bHideThumbAtEnds", new LuaCSFunction(UIProgressBarWrap.get_bHideThumbAtEnds), new LuaCSFunction(UIProgressBarWrap.set_bHideThumbAtEnds)),
			new LuaField("onDragFinished", new LuaCSFunction(UIProgressBarWrap.get_onDragFinished), new LuaCSFunction(UIProgressBarWrap.set_onDragFinished)),
			new LuaField("bHideFgAtEnds", new LuaCSFunction(UIProgressBarWrap.get_bHideFgAtEnds), new LuaCSFunction(UIProgressBarWrap.set_bHideFgAtEnds)),
			new LuaField("UseFillDir", new LuaCSFunction(UIProgressBarWrap.get_UseFillDir), new LuaCSFunction(UIProgressBarWrap.set_UseFillDir)),
			new LuaField("thumb", new LuaCSFunction(UIProgressBarWrap.get_thumb), new LuaCSFunction(UIProgressBarWrap.set_thumb)),
			new LuaField("mBG", new LuaCSFunction(UIProgressBarWrap.get_mBG), new LuaCSFunction(UIProgressBarWrap.set_mBG)),
			new LuaField("mFG", new LuaCSFunction(UIProgressBarWrap.get_mFG), new LuaCSFunction(UIProgressBarWrap.set_mFG)),
			new LuaField("mDG", new LuaCSFunction(UIProgressBarWrap.get_mDG), new LuaCSFunction(UIProgressBarWrap.set_mDG)),
			new LuaField("numberOfSteps", new LuaCSFunction(UIProgressBarWrap.get_numberOfSteps), new LuaCSFunction(UIProgressBarWrap.set_numberOfSteps)),
			new LuaField("onChange", new LuaCSFunction(UIProgressBarWrap.get_onChange), new LuaCSFunction(UIProgressBarWrap.set_onChange)),
			new LuaField("cachedTransform", new LuaCSFunction(UIProgressBarWrap.get_cachedTransform), null),
			new LuaField("cachedCamera", new LuaCSFunction(UIProgressBarWrap.get_cachedCamera), null),
			new LuaField("foregroundWidget", new LuaCSFunction(UIProgressBarWrap.get_foregroundWidget), new LuaCSFunction(UIProgressBarWrap.set_foregroundWidget)),
			new LuaField("backgroundWidget", new LuaCSFunction(UIProgressBarWrap.get_backgroundWidget), new LuaCSFunction(UIProgressBarWrap.set_backgroundWidget)),
			new LuaField("fillDirection", new LuaCSFunction(UIProgressBarWrap.get_fillDirection), new LuaCSFunction(UIProgressBarWrap.set_fillDirection)),
			new LuaField("value", new LuaCSFunction(UIProgressBarWrap.get_value), new LuaCSFunction(UIProgressBarWrap.set_value)),
			new LuaField("alpha", new LuaCSFunction(UIProgressBarWrap.get_alpha), new LuaCSFunction(UIProgressBarWrap.set_alpha))
		};
		LuaScriptMgr.RegisterLib(L, "UIProgressBar", typeof(UIProgressBar), regs, fields, typeof(UIWidgetContainer));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIProgressBar(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIProgressBar class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIProgressBarWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIProgressBar.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bHideThumbAtEnds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bHideThumbAtEnds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bHideThumbAtEnds on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.bHideThumbAtEnds);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
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
		LuaScriptMgr.Push(L, uIProgressBar.onDragFinished);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bHideFgAtEnds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bHideFgAtEnds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bHideFgAtEnds on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.bHideFgAtEnds);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UseFillDir(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name UseFillDir");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index UseFillDir on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.UseFillDir);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_thumb(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name thumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index thumb on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.thumb);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mBG(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mBG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mBG on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.mBG);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mFG(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mFG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mFG on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.mFG);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mDG(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mDG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mDG on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.mDG);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_numberOfSteps(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name numberOfSteps");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index numberOfSteps on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.numberOfSteps);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
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
		LuaScriptMgr.PushObject(L, uIProgressBar.onChange);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedTransform on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.cachedTransform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedCamera(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cachedCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cachedCamera on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.cachedCamera);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_foregroundWidget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name foregroundWidget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index foregroundWidget on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.foregroundWidget);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundWidget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backgroundWidget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backgroundWidget on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.backgroundWidget);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillDirection(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.fillDirection);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
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
		LuaScriptMgr.Push(L, uIProgressBar.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIProgressBar.alpha);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UIProgressBar.current = (UIProgressBar)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIProgressBar));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bHideThumbAtEnds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bHideThumbAtEnds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bHideThumbAtEnds on a nil value");
			}
		}
		uIProgressBar.bHideThumbAtEnds = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragFinished(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
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
			uIProgressBar.onDragFinished = (UIProgressBar.OnDragFinished)LuaScriptMgr.GetNetObject(L, 3, typeof(UIProgressBar.OnDragFinished));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIProgressBar.onDragFinished = delegate
			{
				func.Call();
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bHideFgAtEnds(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bHideFgAtEnds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bHideFgAtEnds on a nil value");
			}
		}
		uIProgressBar.bHideFgAtEnds = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_UseFillDir(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name UseFillDir");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index UseFillDir on a nil value");
			}
		}
		uIProgressBar.UseFillDir = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_thumb(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name thumb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index thumb on a nil value");
			}
		}
		uIProgressBar.thumb = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mBG(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mBG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mBG on a nil value");
			}
		}
		uIProgressBar.mBG = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mFG(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mFG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mFG on a nil value");
			}
		}
		uIProgressBar.mFG = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mDG(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mDG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mDG on a nil value");
			}
		}
		uIProgressBar.mDG = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_numberOfSteps(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name numberOfSteps");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index numberOfSteps on a nil value");
			}
		}
		uIProgressBar.numberOfSteps = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
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
		uIProgressBar.onChange = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_foregroundWidget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name foregroundWidget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index foregroundWidget on a nil value");
			}
		}
		uIProgressBar.foregroundWidget = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundWidget(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backgroundWidget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backgroundWidget on a nil value");
			}
		}
		uIProgressBar.backgroundWidget = (UIWidget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIWidget));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillDirection(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
			}
		}
		uIProgressBar.fillDirection = (UIProgressBar.FillDirection)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIProgressBar.FillDirection)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
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
		uIProgressBar.value = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)luaObject;
		if (uIProgressBar == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
			}
		}
		uIProgressBar.alpha = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForceUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIProgressBar uIProgressBar = (UIProgressBar)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProgressBar");
		uIProgressBar.ForceUpdate();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDynamicGround(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIProgressBar uIProgressBar = (UIProgressBar)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProgressBar");
		float length = (float)LuaScriptMgr.GetNumber(L, 2);
		int depth = (int)LuaScriptMgr.GetNumber(L, 3);
		uIProgressBar.SetDynamicGround(length, depth);
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
