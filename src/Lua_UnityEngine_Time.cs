using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Time : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			Time o = new Time();
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
	public static int get_time(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.time);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_timeSinceLevelLoad(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.timeSinceLevelLoad);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_deltaTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.deltaTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_fixedTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.fixedTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_unscaledTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.unscaledTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_unscaledDeltaTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.unscaledDeltaTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_fixedDeltaTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.fixedDeltaTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fixedDeltaTime(IntPtr l)
	{
		int result;
		try
		{
			float fixedDeltaTime;
			LuaObject.checkType(l, 2, out fixedDeltaTime);
			Time.fixedDeltaTime = fixedDeltaTime;
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
	public static int get_maximumDeltaTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.maximumDeltaTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_maximumDeltaTime(IntPtr l)
	{
		int result;
		try
		{
			float maximumDeltaTime;
			LuaObject.checkType(l, 2, out maximumDeltaTime);
			Time.maximumDeltaTime = maximumDeltaTime;
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
	public static int get_smoothDeltaTime(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.smoothDeltaTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_timeScale(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.timeScale);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_timeScale(IntPtr l)
	{
		int result;
		try
		{
			float timeScale;
			LuaObject.checkType(l, 2, out timeScale);
			Time.timeScale = timeScale;
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
	public static int get_frameCount(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.frameCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_renderedFrameCount(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.renderedFrameCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_realtimeSinceStartup(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.realtimeSinceStartup);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_captureFramerate(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Time.captureFramerate);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_captureFramerate(IntPtr l)
	{
		int result;
		try
		{
			int captureFramerate;
			LuaObject.checkType(l, 2, out captureFramerate);
			Time.captureFramerate = captureFramerate;
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
		LuaObject.getTypeTable(l, "UnityEngine.Time");
		LuaObject.addMember(l, "time", new LuaCSFunction(Lua_UnityEngine_Time.get_time), null, false);
		LuaObject.addMember(l, "timeSinceLevelLoad", new LuaCSFunction(Lua_UnityEngine_Time.get_timeSinceLevelLoad), null, false);
		LuaObject.addMember(l, "deltaTime", new LuaCSFunction(Lua_UnityEngine_Time.get_deltaTime), null, false);
		LuaObject.addMember(l, "fixedTime", new LuaCSFunction(Lua_UnityEngine_Time.get_fixedTime), null, false);
		LuaObject.addMember(l, "unscaledTime", new LuaCSFunction(Lua_UnityEngine_Time.get_unscaledTime), null, false);
		LuaObject.addMember(l, "unscaledDeltaTime", new LuaCSFunction(Lua_UnityEngine_Time.get_unscaledDeltaTime), null, false);
		LuaObject.addMember(l, "fixedDeltaTime", new LuaCSFunction(Lua_UnityEngine_Time.get_fixedDeltaTime), new LuaCSFunction(Lua_UnityEngine_Time.set_fixedDeltaTime), false);
		LuaObject.addMember(l, "maximumDeltaTime", new LuaCSFunction(Lua_UnityEngine_Time.get_maximumDeltaTime), new LuaCSFunction(Lua_UnityEngine_Time.set_maximumDeltaTime), false);
		LuaObject.addMember(l, "smoothDeltaTime", new LuaCSFunction(Lua_UnityEngine_Time.get_smoothDeltaTime), null, false);
		LuaObject.addMember(l, "timeScale", new LuaCSFunction(Lua_UnityEngine_Time.get_timeScale), new LuaCSFunction(Lua_UnityEngine_Time.set_timeScale), false);
		LuaObject.addMember(l, "frameCount", new LuaCSFunction(Lua_UnityEngine_Time.get_frameCount), null, false);
		LuaObject.addMember(l, "renderedFrameCount", new LuaCSFunction(Lua_UnityEngine_Time.get_renderedFrameCount), null, false);
		LuaObject.addMember(l, "realtimeSinceStartup", new LuaCSFunction(Lua_UnityEngine_Time.get_realtimeSinceStartup), null, false);
		LuaObject.addMember(l, "captureFramerate", new LuaCSFunction(Lua_UnityEngine_Time.get_captureFramerate), new LuaCSFunction(Lua_UnityEngine_Time.set_captureFramerate), false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Time.constructor), typeof(Time));
	}
}
