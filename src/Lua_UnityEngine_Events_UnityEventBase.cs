using com.tencent.pandora;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Lua_UnityEngine_Events_UnityEventBase : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetPersistentEventCount(IntPtr l)
	{
		int result;
		try
		{
			UnityEventBase unityEventBase = (UnityEventBase)LuaObject.checkSelf(l);
			int persistentEventCount = unityEventBase.GetPersistentEventCount();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, persistentEventCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetPersistentTarget(IntPtr l)
	{
		int result;
		try
		{
			UnityEventBase unityEventBase = (UnityEventBase)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			UnityEngine.Object persistentTarget = unityEventBase.GetPersistentTarget(index);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, persistentTarget);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetPersistentMethodName(IntPtr l)
	{
		int result;
		try
		{
			UnityEventBase unityEventBase = (UnityEventBase)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			string persistentMethodName = unityEventBase.GetPersistentMethodName(index);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, persistentMethodName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SetPersistentListenerState(IntPtr l)
	{
		int result;
		try
		{
			UnityEventBase unityEventBase = (UnityEventBase)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			UnityEventCallState state;
			LuaObject.checkEnum<UnityEventCallState>(l, 3, out state);
			unityEventBase.SetPersistentListenerState(index, state);
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
	public static int RemoveAllListeners(IntPtr l)
	{
		int result;
		try
		{
			UnityEventBase unityEventBase = (UnityEventBase)LuaObject.checkSelf(l);
			unityEventBase.RemoveAllListeners();
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
	public static int GetValidMethodInfo_s(IntPtr l)
	{
		int result;
		try
		{
			object obj;
			LuaObject.checkType<object>(l, 1, out obj);
			string functionName;
			LuaObject.checkType(l, 2, out functionName);
			Type[] argumentTypes;
			LuaObject.checkArray<Type>(l, 3, out argumentTypes);
			MethodInfo validMethodInfo = UnityEventBase.GetValidMethodInfo(obj, functionName, argumentTypes);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, validMethodInfo);
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
		LuaObject.getTypeTable(l, "UnityEngine.Events.UnityEventBase");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEventBase.GetPersistentEventCount));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEventBase.GetPersistentTarget));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEventBase.GetPersistentMethodName));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEventBase.SetPersistentListenerState));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEventBase.RemoveAllListeners));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEventBase.GetValidMethodInfo_s));
		LuaObject.createTypeMetatable(l, null, typeof(UnityEventBase));
	}
}
