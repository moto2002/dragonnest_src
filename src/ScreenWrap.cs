using LuaInterface;
using System;
using UnityEngine;

public class ScreenWrap
{
	private static Type classType = typeof(Screen);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetResolution", new LuaCSFunction(ScreenWrap.SetResolution)),
			new LuaMethod("New", new LuaCSFunction(ScreenWrap._CreateScreen)),
			new LuaMethod("GetClassType", new LuaCSFunction(ScreenWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("resolutions", new LuaCSFunction(ScreenWrap.get_resolutions), null),
			new LuaField("GetResolution", new LuaCSFunction(ScreenWrap.get_GetResolution), null),
			new LuaField("currentResolution", new LuaCSFunction(ScreenWrap.get_currentResolution), null),
			new LuaField("showCursor", new LuaCSFunction(ScreenWrap.get_showCursor), new LuaCSFunction(ScreenWrap.set_showCursor)),
			new LuaField("lockCursor", new LuaCSFunction(ScreenWrap.get_lockCursor), new LuaCSFunction(ScreenWrap.set_lockCursor)),
			new LuaField("width", new LuaCSFunction(ScreenWrap.get_width), null),
			new LuaField("height", new LuaCSFunction(ScreenWrap.get_height), null),
			new LuaField("dpi", new LuaCSFunction(ScreenWrap.get_dpi), null),
			new LuaField("fullScreen", new LuaCSFunction(ScreenWrap.get_fullScreen), new LuaCSFunction(ScreenWrap.set_fullScreen)),
			new LuaField("autorotateToPortrait", new LuaCSFunction(ScreenWrap.get_autorotateToPortrait), new LuaCSFunction(ScreenWrap.set_autorotateToPortrait)),
			new LuaField("autorotateToPortraitUpsideDown", new LuaCSFunction(ScreenWrap.get_autorotateToPortraitUpsideDown), new LuaCSFunction(ScreenWrap.set_autorotateToPortraitUpsideDown)),
			new LuaField("autorotateToLandscapeLeft", new LuaCSFunction(ScreenWrap.get_autorotateToLandscapeLeft), new LuaCSFunction(ScreenWrap.set_autorotateToLandscapeLeft)),
			new LuaField("autorotateToLandscapeRight", new LuaCSFunction(ScreenWrap.get_autorotateToLandscapeRight), new LuaCSFunction(ScreenWrap.set_autorotateToLandscapeRight)),
			new LuaField("orientation", new LuaCSFunction(ScreenWrap.get_orientation), new LuaCSFunction(ScreenWrap.set_orientation)),
			new LuaField("sleepTimeout", new LuaCSFunction(ScreenWrap.get_sleepTimeout), new LuaCSFunction(ScreenWrap.set_sleepTimeout))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Screen", typeof(Screen), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateScreen(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Screen o = new Screen();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Screen.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, ScreenWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resolutions(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Screen.resolutions);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetResolution(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Screen.GetResolution);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentResolution(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Screen.currentResolution);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showCursor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.showCursor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lockCursor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.lockCursor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.width);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.height);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dpi(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.dpi);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fullScreen(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.fullScreen);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToPortrait(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToPortrait);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToPortraitUpsideDown(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToPortraitUpsideDown);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToLandscapeLeft(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToLandscapeLeft);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autorotateToLandscapeRight(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.autorotateToLandscapeRight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_orientation(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.orientation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sleepTimeout(IntPtr L)
	{
		LuaScriptMgr.Push(L, Screen.sleepTimeout);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showCursor(IntPtr L)
	{
		Screen.showCursor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lockCursor(IntPtr L)
	{
		Screen.lockCursor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fullScreen(IntPtr L)
	{
		Screen.fullScreen = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToPortrait(IntPtr L)
	{
		Screen.autorotateToPortrait = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToPortraitUpsideDown(IntPtr L)
	{
		Screen.autorotateToPortraitUpsideDown = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToLandscapeLeft(IntPtr L)
	{
		Screen.autorotateToLandscapeLeft = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autorotateToLandscapeRight(IntPtr L)
	{
		Screen.autorotateToLandscapeRight = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_orientation(IntPtr L)
	{
		Screen.orientation = (ScreenOrientation)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(ScreenOrientation)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepTimeout(IntPtr L)
	{
		Screen.sleepTimeout = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetResolution(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			int width = (int)LuaScriptMgr.GetNumber(L, 1);
			int height = (int)LuaScriptMgr.GetNumber(L, 2);
			bool boolean = LuaScriptMgr.GetBoolean(L, 3);
			Screen.SetResolution(width, height, boolean);
			return 0;
		}
		if (num == 4)
		{
			int width2 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height2 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
			int preferredRefreshRate = (int)LuaScriptMgr.GetNumber(L, 4);
			Screen.SetResolution(width2, height2, boolean2, preferredRefreshRate);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Screen.SetResolution");
		return 0;
	}
}
