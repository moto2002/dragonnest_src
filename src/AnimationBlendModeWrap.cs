using LuaInterface;
using System;
using UnityEngine;

public class AnimationBlendModeWrap
{
	private static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Blend", new LuaCSFunction(AnimationBlendModeWrap.GetBlend)),
		new LuaMethod("Additive", new LuaCSFunction(AnimationBlendModeWrap.GetAdditive)),
		new LuaMethod("IntToEnum", new LuaCSFunction(AnimationBlendModeWrap.IntToEnum))
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationBlendMode", typeof(AnimationBlendMode), AnimationBlendModeWrap.enums);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBlend(IntPtr L)
	{
		LuaScriptMgr.Push(L, AnimationBlendMode.Blend);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAdditive(IntPtr L)
	{
		LuaScriptMgr.Push(L, AnimationBlendMode.Additive);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		AnimationBlendMode animationBlendMode = (AnimationBlendMode)num;
		LuaScriptMgr.Push(L, animationBlendMode);
		return 1;
	}
}
