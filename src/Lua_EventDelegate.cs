using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_EventDelegate : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				EventDelegate o = new EventDelegate();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 2)
			{
				EventDelegate.Callback call;
				LuaDelegation.checkDelegate(l, 2, out call);
				EventDelegate o = new EventDelegate(call);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				MonoBehaviour target;
				LuaObject.checkType<MonoBehaviour>(l, 2, out target);
				string methodName;
				LuaObject.checkType(l, 3, out methodName);
				EventDelegate o = new EventDelegate(target, methodName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				result = LuaObject.error(l, "New object failed.");
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Setz(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			EventDelegate.Callback call;
			LuaDelegation.checkDelegate(l, 2, out call);
			eventDelegate.Setz(call);
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
	public static int Set(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			MonoBehaviour target;
			LuaObject.checkType<MonoBehaviour>(l, 2, out target);
			string methodName;
			LuaObject.checkType(l, 3, out methodName);
			eventDelegate.Set(target, methodName);
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
	public static int Execute(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			bool b = eventDelegate.Execute();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Clear(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			eventDelegate.Clear();
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
	public static int Execute_s(IntPtr l)
	{
		int result;
		try
		{
			List<EventDelegate> list;
			LuaObject.checkType<List<EventDelegate>>(l, 1, out list);
			EventDelegate.Execute(list);
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
	public static int IsValid_s(IntPtr l)
	{
		int result;
		try
		{
			List<EventDelegate> list;
			LuaObject.checkType<List<EventDelegate>>(l, 1, out list);
			bool b = EventDelegate.IsValid(list);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Set_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list);
				EventDelegate del;
				LuaObject.checkType<EventDelegate>(l, 2, out del);
				EventDelegate.Set(list, del);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
			{
				List<EventDelegate> list2;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list2);
				EventDelegate.Callback callback;
				LuaDelegation.checkDelegate(l, 2, out callback);
				EventDelegate.Set(list2, callback);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int Add_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list);
				EventDelegate ev;
				LuaObject.checkType<EventDelegate>(l, 2, out ev);
				EventDelegate.Add(list, ev);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
			{
				List<EventDelegate> list2;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list2);
				EventDelegate.Callback callback;
				LuaDelegation.checkDelegate(l, 2, out callback);
				EventDelegate.Add(list2, callback);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(bool)))
			{
				List<EventDelegate> list3;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list3);
				EventDelegate ev2;
				LuaObject.checkType<EventDelegate>(l, 2, out ev2);
				bool oneShot;
				LuaObject.checkType(l, 3, out oneShot);
				EventDelegate.Add(list3, ev2, oneShot);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback), typeof(bool)))
			{
				List<EventDelegate> list4;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list4);
				EventDelegate.Callback callback2;
				LuaDelegation.checkDelegate(l, 2, out callback2);
				bool oneShot2;
				LuaObject.checkType(l, 3, out oneShot2);
				EventDelegate.Add(list4, callback2, oneShot2);
				LuaObject.pushValue(l, true);
				result = 1;
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
	public static int Remove_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list);
				EventDelegate ev;
				LuaObject.checkType<EventDelegate>(l, 2, out ev);
				bool b = EventDelegate.Remove(list, ev);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
			{
				List<EventDelegate> list2;
				LuaObject.checkType<List<EventDelegate>>(l, 1, out list2);
				EventDelegate.Callback callback;
				LuaDelegation.checkDelegate(l, 2, out callback);
				bool b2 = EventDelegate.Remove(list2, callback);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b2);
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
	public static int get_oneShot(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventDelegate.oneShot);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_oneShot(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			bool oneShot;
			LuaObject.checkType(l, 2, out oneShot);
			eventDelegate.oneShot = oneShot;
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
	public static int get_target(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventDelegate.target);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_target(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			MonoBehaviour target;
			LuaObject.checkType<MonoBehaviour>(l, 2, out target);
			eventDelegate.target = target;
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
	public static int get_methodName(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventDelegate.methodName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_methodName(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			string methodName;
			LuaObject.checkType(l, 2, out methodName);
			eventDelegate.methodName = methodName;
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
	public static int get_parameters(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventDelegate.parameters);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isValid(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventDelegate.isValid);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isEnabled(IntPtr l)
	{
		int result;
		try
		{
			EventDelegate eventDelegate = (EventDelegate)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventDelegate.isEnabled);
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
		LuaObject.getTypeTable(l, "EventDelegate");
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Setz));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Set));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Execute));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Clear));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Execute_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.IsValid_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Set_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Add_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_EventDelegate.Remove_s));
		LuaObject.addMember(l, "oneShot", new LuaCSFunction(Lua_EventDelegate.get_oneShot), new LuaCSFunction(Lua_EventDelegate.set_oneShot), true);
		LuaObject.addMember(l, "target", new LuaCSFunction(Lua_EventDelegate.get_target), new LuaCSFunction(Lua_EventDelegate.set_target), true);
		LuaObject.addMember(l, "methodName", new LuaCSFunction(Lua_EventDelegate.get_methodName), new LuaCSFunction(Lua_EventDelegate.set_methodName), true);
		LuaObject.addMember(l, "parameters", new LuaCSFunction(Lua_EventDelegate.get_parameters), null, true);
		LuaObject.addMember(l, "isValid", new LuaCSFunction(Lua_EventDelegate.get_isValid), null, true);
		LuaObject.addMember(l, "isEnabled", new LuaCSFunction(Lua_EventDelegate.get_isEnabled), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_EventDelegate.constructor), typeof(EventDelegate));
	}
}
