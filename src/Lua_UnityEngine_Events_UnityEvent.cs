using com.tencent.pandora;
using System;
using UnityEngine.Events;

public class Lua_UnityEngine_Events_UnityEvent : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UnityEvent o = new UnityEvent();
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
	public static int AddListener(IntPtr l)
	{
		int result;
		try
		{
			UnityEvent unityEvent = (UnityEvent)LuaObject.checkSelf(l);
			UnityAction call;
			LuaDelegation.checkDelegate(l, 2, out call);
			unityEvent.AddListener(call);
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
	public static int RemoveListener(IntPtr l)
	{
		int result;
		try
		{
			UnityEvent unityEvent = (UnityEvent)LuaObject.checkSelf(l);
			UnityAction call;
			LuaDelegation.checkDelegate(l, 2, out call);
			unityEvent.RemoveListener(call);
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
	public static int Invoke(IntPtr l)
	{
		int result;
		try
		{
			UnityEvent unityEvent = (UnityEvent)LuaObject.checkSelf(l);
			unityEvent.Invoke();
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
		LuaObject.getTypeTable(l, "UnityEngine.Events.UnityEvent");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEvent.AddListener));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEvent.RemoveListener));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEvent.Invoke));
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Events_UnityEvent.constructor), typeof(UnityEvent), typeof(UnityEventBase));
	}
}
