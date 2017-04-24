using LuaInterface;
using System;
using UnityEngine;

public class TouchPhaseWrap
{
	private static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Began", new LuaCSFunction(TouchPhaseWrap.GetBegan)),
		new LuaMethod("Moved", new LuaCSFunction(TouchPhaseWrap.GetMoved)),
		new LuaMethod("Stationary", new LuaCSFunction(TouchPhaseWrap.GetStationary)),
		new LuaMethod("Ended", new LuaCSFunction(TouchPhaseWrap.GetEnded)),
		new LuaMethod("Canceled", new LuaCSFunction(TouchPhaseWrap.GetCanceled)),
		new LuaMethod("IntToEnum", new LuaCSFunction(TouchPhaseWrap.IntToEnum))
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TouchPhase", typeof(TouchPhase), TouchPhaseWrap.enums);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBegan(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Began);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMoved(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Moved);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStationary(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Stationary);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnded(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Ended);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCanceled(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Canceled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		TouchPhase touchPhase = (TouchPhase)num;
		LuaScriptMgr.Push(L, touchPhase);
		return 1;
	}
}
