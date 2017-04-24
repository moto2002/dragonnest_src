using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventDelegateWrap
{
	private static Type classType = typeof(EventDelegate);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Equals", new LuaCSFunction(EventDelegateWrap.Equals)),
			new LuaMethod("GetHashCode", new LuaCSFunction(EventDelegateWrap.GetHashCode)),
			new LuaMethod("Setz", new LuaCSFunction(EventDelegateWrap.Setz)),
			new LuaMethod("Set", new LuaCSFunction(EventDelegateWrap.Set)),
			new LuaMethod("Execute", new LuaCSFunction(EventDelegateWrap.Execute)),
			new LuaMethod("Clear", new LuaCSFunction(EventDelegateWrap.Clear)),
			new LuaMethod("ToString", new LuaCSFunction(EventDelegateWrap.ToString)),
			new LuaMethod("IsValid", new LuaCSFunction(EventDelegateWrap.IsValid)),
			new LuaMethod("Add", new LuaCSFunction(EventDelegateWrap.Add)),
			new LuaMethod("Remove", new LuaCSFunction(EventDelegateWrap.Remove)),
			new LuaMethod("New", new LuaCSFunction(EventDelegateWrap._CreateEventDelegate)),
			new LuaMethod("GetClassType", new LuaCSFunction(EventDelegateWrap.GetClassType)),
			new LuaMethod("__tostring", new LuaCSFunction(EventDelegateWrap.Lua_ToString))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("oneShot", new LuaCSFunction(EventDelegateWrap.get_oneShot), new LuaCSFunction(EventDelegateWrap.set_oneShot)),
			new LuaField("target", new LuaCSFunction(EventDelegateWrap.get_target), new LuaCSFunction(EventDelegateWrap.set_target)),
			new LuaField("methodName", new LuaCSFunction(EventDelegateWrap.get_methodName), new LuaCSFunction(EventDelegateWrap.set_methodName)),
			new LuaField("parameters", new LuaCSFunction(EventDelegateWrap.get_parameters), null),
			new LuaField("isValid", new LuaCSFunction(EventDelegateWrap.get_isValid), null),
			new LuaField("isEnabled", new LuaCSFunction(EventDelegateWrap.get_isEnabled), null)
		};
		LuaScriptMgr.RegisterLib(L, "EventDelegate", typeof(EventDelegate), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateEventDelegate(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 0)
		{
			EventDelegate o = new EventDelegate();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		if (num == 1)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			EventDelegate.Callback call;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				call = (EventDelegate.Callback)LuaScriptMgr.GetNetObject(L, 1, typeof(EventDelegate.Callback));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 1);
				call = delegate
				{
					func.Call();
				};
			}
			EventDelegate o2 = new EventDelegate(call);
			LuaScriptMgr.PushObject(L, o2);
			return 1;
		}
		if (num == 2)
		{
			MonoBehaviour target = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
			string @string = LuaScriptMgr.GetString(L, 2);
			EventDelegate o3 = new EventDelegate(target, @string);
			LuaScriptMgr.PushObject(L, o3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: EventDelegate.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, EventDelegateWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_oneShot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name oneShot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index oneShot on a nil value");
			}
		}
		LuaScriptMgr.Push(L, eventDelegate.oneShot);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_target(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}
		LuaScriptMgr.Push(L, eventDelegate.target);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_methodName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name methodName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index methodName on a nil value");
			}
		}
		LuaScriptMgr.Push(L, eventDelegate.methodName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parameters(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parameters");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parameters on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, eventDelegate.parameters);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isValid(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isValid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isValid on a nil value");
			}
		}
		LuaScriptMgr.Push(L, eventDelegate.isValid);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isEnabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isEnabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isEnabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, eventDelegate.isEnabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_oneShot(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name oneShot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index oneShot on a nil value");
			}
		}
		eventDelegate.oneShot = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_target(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}
		eventDelegate.target = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 3, typeof(MonoBehaviour));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_methodName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		EventDelegate eventDelegate = (EventDelegate)luaObject;
		if (eventDelegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name methodName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index methodName on a nil value");
			}
		}
		eventDelegate.methodName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_ToString(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		if (luaObject != null)
		{
			LuaScriptMgr.Push(L, luaObject.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: EventDelegate");
		}
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		EventDelegate eventDelegate = LuaScriptMgr.GetVarObject(L, 1) as EventDelegate;
		object varObject = LuaScriptMgr.GetVarObject(L, 2);
		bool b = (eventDelegate == null) ? (varObject == null) : eventDelegate.Equals(varObject);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		EventDelegate eventDelegate = (EventDelegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "EventDelegate");
		int hashCode = eventDelegate.GetHashCode();
		LuaScriptMgr.Push(L, hashCode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Setz(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		EventDelegate eventDelegate = (EventDelegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "EventDelegate");
		LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
		EventDelegate.Callback call;
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			call = (EventDelegate.Callback)LuaScriptMgr.GetNetObject(L, 2, typeof(EventDelegate.Callback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			call = delegate
			{
				func.Call();
			};
		}
		eventDelegate.Setz(call);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
		{
			List<EventDelegate> list = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			EventDelegate del = (EventDelegate)LuaScriptMgr.GetLuaObject(L, 2);
			EventDelegate.Set(list, del);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
		{
			List<EventDelegate> list2 = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (EventDelegate.Callback)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				callback = delegate
				{
					func.Call();
				};
			}
			EventDelegate.Set(list2, callback);
			return 0;
		}
		if (num == 3)
		{
			EventDelegate eventDelegate = (EventDelegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "EventDelegate");
			MonoBehaviour target = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 2, typeof(MonoBehaviour));
			string luaString = LuaScriptMgr.GetLuaString(L, 3);
			eventDelegate.Set(target, luaString);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: EventDelegate.Set");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Execute(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>)))
		{
			List<EventDelegate> list = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			EventDelegate.Execute(list);
			return 0;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(EventDelegate)))
		{
			EventDelegate eventDelegate = (EventDelegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "EventDelegate");
			bool b = eventDelegate.Execute();
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: EventDelegate.Execute");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		EventDelegate eventDelegate = (EventDelegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "EventDelegate");
		eventDelegate.Clear();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		EventDelegate eventDelegate = (EventDelegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "EventDelegate");
		string str = eventDelegate.ToString();
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsValid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<EventDelegate> list = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 1, typeof(List<EventDelegate>));
		bool b = EventDelegate.IsValid(list);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Add(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
		{
			List<EventDelegate> list = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			EventDelegate ev = (EventDelegate)LuaScriptMgr.GetLuaObject(L, 2);
			EventDelegate.Add(list, ev);
			return 0;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
		{
			List<EventDelegate> list2 = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (EventDelegate.Callback)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				callback = delegate
				{
					func.Call();
				};
			}
			EventDelegate.Add(list2, callback);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(bool)))
		{
			List<EventDelegate> list3 = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			EventDelegate ev2 = (EventDelegate)LuaScriptMgr.GetLuaObject(L, 2);
			bool oneShot = LuaDLL.lua_toboolean(L, 3);
			EventDelegate.Add(list3, ev2, oneShot);
			return 0;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback), typeof(bool)))
		{
			List<EventDelegate> list4 = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback callback2;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				callback2 = (EventDelegate.Callback)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				callback2 = delegate
				{
					func.Call();
				};
			}
			bool oneShot2 = LuaDLL.lua_toboolean(L, 3);
			EventDelegate.Add(list4, callback2, oneShot2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: EventDelegate.Add");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Remove(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
		{
			List<EventDelegate> list = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			EventDelegate ev = (EventDelegate)LuaScriptMgr.GetLuaObject(L, 2);
			bool b = EventDelegate.Remove(list, ev);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
		{
			List<EventDelegate> list2 = (List<EventDelegate>)LuaScriptMgr.GetLuaObject(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (EventDelegate.Callback)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				callback = delegate
				{
					func.Call();
				};
			}
			bool b2 = EventDelegate.Remove(list2, callback);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: EventDelegate.Remove");
		return 0;
	}
}
