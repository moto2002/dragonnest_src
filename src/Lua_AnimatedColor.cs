using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_AnimatedColor : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_color(IntPtr l)
	{
		int result;
		try
		{
			AnimatedColor animatedColor = (AnimatedColor)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, animatedColor.color);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_color(IntPtr l)
	{
		int result;
		try
		{
			AnimatedColor animatedColor = (AnimatedColor)LuaObject.checkSelf(l);
			Color color;
			LuaObject.checkType(l, 2, out color);
			animatedColor.color = color;
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
		LuaObject.getTypeTable(l, "AnimatedColor");
		LuaObject.addMember(l, "color", new LuaCSFunction(Lua_AnimatedColor.get_color), new LuaCSFunction(Lua_AnimatedColor.set_color), true);
		LuaObject.createTypeMetatable(l, null, typeof(AnimatedColor), typeof(MonoBehaviour));
	}
}
