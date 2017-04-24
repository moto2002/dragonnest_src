using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_AnimatedAlpha : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_alpha(IntPtr l)
	{
		int result;
		try
		{
			AnimatedAlpha animatedAlpha = (AnimatedAlpha)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, animatedAlpha.alpha);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_alpha(IntPtr l)
	{
		int result;
		try
		{
			AnimatedAlpha animatedAlpha = (AnimatedAlpha)LuaObject.checkSelf(l);
			float alpha;
			LuaObject.checkType(l, 2, out alpha);
			animatedAlpha.alpha = alpha;
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
		LuaObject.getTypeTable(l, "AnimatedAlpha");
		LuaObject.addMember(l, "alpha", new LuaCSFunction(Lua_AnimatedAlpha.get_alpha), new LuaCSFunction(Lua_AnimatedAlpha.set_alpha), true);
		LuaObject.createTypeMetatable(l, null, typeof(AnimatedAlpha), typeof(MonoBehaviour));
	}
}
