using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Behaviour : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			Behaviour o = new Behaviour();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_enabled(IntPtr l)
	{
		int result;
		try
		{
			Behaviour behaviour = (Behaviour)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, behaviour.enabled);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_enabled(IntPtr l)
	{
		int result;
		try
		{
			Behaviour behaviour = (Behaviour)LuaObject.checkSelf(l);
			bool enabled;
			LuaObject.checkType(l, 2, out enabled);
			behaviour.enabled = enabled;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isActiveAndEnabled(IntPtr l)
	{
		int result;
		try
		{
			Behaviour behaviour = (Behaviour)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, behaviour.isActiveAndEnabled);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UnityEngine.Behaviour");
		LuaObject.addMember(l, "enabled", new LuaCSFunction(Lua_UnityEngine_Behaviour.get_enabled), new LuaCSFunction(Lua_UnityEngine_Behaviour.set_enabled), true);
		LuaObject.addMember(l, "isActiveAndEnabled", new LuaCSFunction(Lua_UnityEngine_Behaviour.get_isActiveAndEnabled), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Behaviour.constructor), typeof(Behaviour), typeof(Component));
	}
}
