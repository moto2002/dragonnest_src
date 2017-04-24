using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Random : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UnityEngine.Random o = new UnityEngine.Random();
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
	public static int Range_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(int), typeof(int)))
			{
				int min;
				LuaObject.checkType(l, 1, out min);
				int max;
				LuaObject.checkType(l, 2, out max);
				int i = UnityEngine.Random.Range(min, max);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(float), typeof(float)))
			{
				float min2;
				LuaObject.checkType(l, 1, out min2);
				float max2;
				LuaObject.checkType(l, 2, out max2);
				float o = UnityEngine.Random.Range(min2, max2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_seed(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.seed);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_seed(IntPtr l)
	{
		int result;
		try
		{
			int seed;
			LuaObject.checkType(l, 2, out seed);
			UnityEngine.Random.seed = seed;
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
	public static int get_value(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.value);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_insideUnitSphere(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.insideUnitSphere);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_insideUnitCircle(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.insideUnitCircle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_onUnitSphere(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.onUnitSphere);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_rotation(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.rotation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_rotationUniform(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UnityEngine.Random.rotationUniform);
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
		LuaObject.getTypeTable(l, "UnityEngine.Random");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Random.Range_s));
		LuaObject.addMember(l, "seed", new LuaCSFunction(Lua_UnityEngine_Random.get_seed), new LuaCSFunction(Lua_UnityEngine_Random.set_seed), false);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_UnityEngine_Random.get_value), null, false);
		LuaObject.addMember(l, "insideUnitSphere", new LuaCSFunction(Lua_UnityEngine_Random.get_insideUnitSphere), null, false);
		LuaObject.addMember(l, "insideUnitCircle", new LuaCSFunction(Lua_UnityEngine_Random.get_insideUnitCircle), null, false);
		LuaObject.addMember(l, "onUnitSphere", new LuaCSFunction(Lua_UnityEngine_Random.get_onUnitSphere), null, false);
		LuaObject.addMember(l, "rotation", new LuaCSFunction(Lua_UnityEngine_Random.get_rotation), null, false);
		LuaObject.addMember(l, "rotationUniform", new LuaCSFunction(Lua_UnityEngine_Random.get_rotationUniform), null, false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Random.constructor), typeof(UnityEngine.Random));
	}
}
