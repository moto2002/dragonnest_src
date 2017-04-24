using com.tencent.pandora;
using System;
using System.Collections;
using UnityEngine;

public class Lua_UnityEngine_MonoBehaviour : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour o = new MonoBehaviour();
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
	public static int Invoke(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
			string methodName;
			LuaObject.checkType(l, 2, out methodName);
			float time;
			LuaObject.checkType(l, 3, out time);
			monoBehaviour.Invoke(methodName, time);
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
	public static int InvokeRepeating(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
			string methodName;
			LuaObject.checkType(l, 2, out methodName);
			float time;
			LuaObject.checkType(l, 3, out time);
			float repeatRate;
			LuaObject.checkType(l, 4, out repeatRate);
			monoBehaviour.InvokeRepeating(methodName, time, repeatRate);
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
	public static int CancelInvoke(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
				monoBehaviour.CancelInvoke();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				MonoBehaviour monoBehaviour2 = (MonoBehaviour)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				monoBehaviour2.CancelInvoke(methodName);
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
	public static int IsInvoking(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
				bool b = monoBehaviour.IsInvoking();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (num == 2)
			{
				MonoBehaviour monoBehaviour2 = (MonoBehaviour)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				bool b2 = monoBehaviour2.IsInvoking(methodName);
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
	public static int StartCoroutine(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, num, 2, typeof(string)))
			{
				MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				Coroutine o = monoBehaviour.StartCoroutine(methodName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(IEnumerator)))
			{
				MonoBehaviour monoBehaviour2 = (MonoBehaviour)LuaObject.checkSelf(l);
				IEnumerator routine;
				LuaObject.checkType<IEnumerator>(l, 2, out routine);
				Coroutine o2 = monoBehaviour2.StartCoroutine(routine);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
				result = 2;
			}
			else if (num == 3)
			{
				MonoBehaviour monoBehaviour3 = (MonoBehaviour)LuaObject.checkSelf(l);
				string methodName2;
				LuaObject.checkType(l, 2, out methodName2);
				object value;
				LuaObject.checkType<object>(l, 3, out value);
				Coroutine o3 = monoBehaviour3.StartCoroutine(methodName2, value);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o3);
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
	public static int StartCoroutine_Auto(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
			IEnumerator routine;
			LuaObject.checkType<IEnumerator>(l, 2, out routine);
			Coroutine o = monoBehaviour.StartCoroutine_Auto(routine);
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
	public static int StopCoroutine(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 2, typeof(Coroutine)))
			{
				MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
				Coroutine routine;
				LuaObject.checkType<Coroutine>(l, 2, out routine);
				monoBehaviour.StopCoroutine(routine);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(IEnumerator)))
			{
				MonoBehaviour monoBehaviour2 = (MonoBehaviour)LuaObject.checkSelf(l);
				IEnumerator routine2;
				LuaObject.checkType<IEnumerator>(l, 2, out routine2);
				monoBehaviour2.StopCoroutine(routine2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 2, typeof(string)))
			{
				MonoBehaviour monoBehaviour3 = (MonoBehaviour)LuaObject.checkSelf(l);
				string methodName;
				LuaObject.checkType(l, 2, out methodName);
				monoBehaviour3.StopCoroutine(methodName);
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
	public static int StopAllCoroutines(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
			monoBehaviour.StopAllCoroutines();
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
	public static int print_s(IntPtr l)
	{
		int result;
		try
		{
			object message;
			LuaObject.checkType<object>(l, 1, out message);
			MonoBehaviour.print(message);
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
	public static int get_useGUILayout(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, monoBehaviour.useGUILayout);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_useGUILayout(IntPtr l)
	{
		int result;
		try
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)LuaObject.checkSelf(l);
			bool useGUILayout;
			LuaObject.checkType(l, 2, out useGUILayout);
			monoBehaviour.useGUILayout = useGUILayout;
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
		LuaObject.getTypeTable(l, "UnityEngine.MonoBehaviour");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.Invoke));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.InvokeRepeating));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.CancelInvoke));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.IsInvoking));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.StartCoroutine));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.StartCoroutine_Auto));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.StopCoroutine));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.StopAllCoroutines));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.print_s));
		LuaObject.addMember(l, "useGUILayout", new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.get_useGUILayout), new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.set_useGUILayout), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_MonoBehaviour.constructor), typeof(MonoBehaviour), typeof(Behaviour));
	}
}
