using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_com_tencent_pandora_Logger : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Log_s(IntPtr l)
	{
		int result;
		try
		{
			string message;
			LuaObject.checkType(l, 1, out message);
			Logger.Log(message);
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
	public static int LogInfo_s(IntPtr l)
	{
		int result;
		try
		{
			string message;
			LuaObject.checkType(l, 1, out message);
			Logger.LogInfo(message);
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
	public static int LogWarning_s(IntPtr l)
	{
		int result;
		try
		{
			string message;
			LuaObject.checkType(l, 1, out message);
			Logger.LogWarning(message);
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
	public static int LogError_s(IntPtr l)
	{
		int result;
		try
		{
			string message;
			LuaObject.checkType(l, 1, out message);
			Logger.LogError(message);
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
	public static int set_HandleLog(IntPtr l)
	{
		int result;
		try
		{
			Action<string, string, Logger.Level> action;
			int num = LuaDelegation.checkDelegate(l, 2, out action);
			if (num == 0)
			{
				Logger.HandleLog = action;
			}
			else if (num == 1)
			{
				Logger.HandleLog = (Action<string, string, Logger.Level>)Delegate.Combine(Logger.HandleLog, action);
			}
			else if (num == 2)
			{
				Logger.HandleLog = (Action<string, string, Logger.Level>)Delegate.Remove(Logger.HandleLog, action);
			}
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
	public static int get_Enable(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Logger.Enable);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_Enable(IntPtr l)
	{
		int result;
		try
		{
			bool enable;
			LuaObject.checkType(l, 2, out enable);
			Logger.Enable = enable;
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
	public static int get_LogLevel(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)Logger.LogLevel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_LogLevel(IntPtr l)
	{
		int result;
		try
		{
			Logger.Level logLevel;
			LuaObject.checkEnum<Logger.Level>(l, 2, out logLevel);
			Logger.LogLevel = logLevel;
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
		LuaObject.getTypeTable(l, "com.tencent.pandora.Logger");
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_Logger.Log_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_Logger.LogInfo_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_Logger.LogWarning_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_Logger.LogError_s));
		LuaObject.addMember(l, "HandleLog", null, new LuaCSFunction(Lua_com_tencent_pandora_Logger.set_HandleLog), false);
		LuaObject.addMember(l, "Enable", new LuaCSFunction(Lua_com_tencent_pandora_Logger.get_Enable), new LuaCSFunction(Lua_com_tencent_pandora_Logger.set_Enable), false);
		LuaObject.addMember(l, "LogLevel", new LuaCSFunction(Lua_com_tencent_pandora_Logger.get_LogLevel), new LuaCSFunction(Lua_com_tencent_pandora_Logger.set_LogLevel), false);
		LuaObject.createTypeMetatable(l, null, typeof(Logger), typeof(MonoBehaviour));
	}
}
