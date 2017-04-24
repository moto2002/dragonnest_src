using LuaInterface;
using System;
using System.Reflection;
using System.Runtime.Serialization;

public class DelegateWrap
{
	private static Type classType = typeof(Delegate);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CreateDelegate", new LuaCSFunction(DelegateWrap.CreateDelegate)),
			new LuaMethod("DynamicInvoke", new LuaCSFunction(DelegateWrap.DynamicInvoke)),
			new LuaMethod("Clone", new LuaCSFunction(DelegateWrap.Clone)),
			new LuaMethod("GetObjectData", new LuaCSFunction(DelegateWrap.GetObjectData)),
			new LuaMethod("GetInvocationList", new LuaCSFunction(DelegateWrap.GetInvocationList)),
			new LuaMethod("Combine", new LuaCSFunction(DelegateWrap.Combine)),
			new LuaMethod("Remove", new LuaCSFunction(DelegateWrap.Remove)),
			new LuaMethod("RemoveAll", new LuaCSFunction(DelegateWrap.RemoveAll)),
			new LuaMethod("GetHashCode", new LuaCSFunction(DelegateWrap.GetHashCode)),
			new LuaMethod("Equals", new LuaCSFunction(DelegateWrap.Equals)),
			new LuaMethod("New", new LuaCSFunction(DelegateWrap._CreateDelegate)),
			new LuaMethod("GetClassType", new LuaCSFunction(DelegateWrap.GetClassType)),
			new LuaMethod("__add", new LuaCSFunction(DelegateWrap.Lua_Add)),
			new LuaMethod("__sub", new LuaCSFunction(DelegateWrap.Lua_Sub)),
			new LuaMethod("__eq", new LuaCSFunction(DelegateWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("Method", new LuaCSFunction(DelegateWrap.get_Method), null),
			new LuaField("Target", new LuaCSFunction(DelegateWrap.get_Target), null)
		};
		LuaScriptMgr.RegisterLib(L, "System.Delegate", typeof(Delegate), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDelegate(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Delegate class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelegateWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Method(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Delegate @delegate = (Delegate)luaObject;
		if (@delegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Method");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Method on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, @delegate.Method);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Target(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		Delegate @delegate = (Delegate)luaObject;
		if (@delegate == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Target on a nil value");
			}
		}
		LuaScriptMgr.PushVarObject(L, @delegate.Target);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateDelegate(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Type typeObject = LuaScriptMgr.GetTypeObject(L, 1);
			MethodInfo method = (MethodInfo)LuaScriptMgr.GetNetObject(L, 2, typeof(MethodInfo));
			Delegate o = Delegate.CreateDelegate(typeObject, method);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(MethodInfo), typeof(bool)))
		{
			Type typeObject2 = LuaScriptMgr.GetTypeObject(L, 1);
			MethodInfo method2 = (MethodInfo)LuaScriptMgr.GetLuaObject(L, 2);
			bool throwOnBindFailure = LuaDLL.lua_toboolean(L, 3);
			Delegate o2 = Delegate.CreateDelegate(typeObject2, method2, throwOnBindFailure);
			LuaScriptMgr.Push(L, o2);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(Type), typeof(string)))
		{
			Type typeObject3 = LuaScriptMgr.GetTypeObject(L, 1);
			Type typeObject4 = LuaScriptMgr.GetTypeObject(L, 2);
			string @string = LuaScriptMgr.GetString(L, 3);
			Delegate o3 = Delegate.CreateDelegate(typeObject3, typeObject4, @string);
			LuaScriptMgr.Push(L, o3);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(string)))
		{
			Type typeObject5 = LuaScriptMgr.GetTypeObject(L, 1);
			object varObject = LuaScriptMgr.GetVarObject(L, 2);
			string string2 = LuaScriptMgr.GetString(L, 3);
			Delegate o4 = Delegate.CreateDelegate(typeObject5, varObject, string2);
			LuaScriptMgr.Push(L, o4);
			return 1;
		}
		if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(MethodInfo)))
		{
			Type typeObject6 = LuaScriptMgr.GetTypeObject(L, 1);
			object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
			MethodInfo method3 = (MethodInfo)LuaScriptMgr.GetLuaObject(L, 3);
			Delegate o5 = Delegate.CreateDelegate(typeObject6, varObject2, method3);
			LuaScriptMgr.Push(L, o5);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(Type), typeof(string), typeof(bool)))
		{
			Type typeObject7 = LuaScriptMgr.GetTypeObject(L, 1);
			Type typeObject8 = LuaScriptMgr.GetTypeObject(L, 2);
			string string3 = LuaScriptMgr.GetString(L, 3);
			bool ignoreCase = LuaDLL.lua_toboolean(L, 4);
			Delegate o6 = Delegate.CreateDelegate(typeObject7, typeObject8, string3, ignoreCase);
			LuaScriptMgr.Push(L, o6);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(string), typeof(bool)))
		{
			Type typeObject9 = LuaScriptMgr.GetTypeObject(L, 1);
			object varObject3 = LuaScriptMgr.GetVarObject(L, 2);
			string string4 = LuaScriptMgr.GetString(L, 3);
			bool ignoreCase2 = LuaDLL.lua_toboolean(L, 4);
			Delegate o7 = Delegate.CreateDelegate(typeObject9, varObject3, string4, ignoreCase2);
			LuaScriptMgr.Push(L, o7);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(MethodInfo), typeof(bool)))
		{
			Type typeObject10 = LuaScriptMgr.GetTypeObject(L, 1);
			object varObject4 = LuaScriptMgr.GetVarObject(L, 2);
			MethodInfo method4 = (MethodInfo)LuaScriptMgr.GetLuaObject(L, 3);
			bool throwOnBindFailure2 = LuaDLL.lua_toboolean(L, 4);
			Delegate o8 = Delegate.CreateDelegate(typeObject10, varObject4, method4, throwOnBindFailure2);
			LuaScriptMgr.Push(L, o8);
			return 1;
		}
		if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(Type), typeof(string), typeof(bool), typeof(bool)))
		{
			Type typeObject11 = LuaScriptMgr.GetTypeObject(L, 1);
			Type typeObject12 = LuaScriptMgr.GetTypeObject(L, 2);
			string string5 = LuaScriptMgr.GetString(L, 3);
			bool ignoreCase3 = LuaDLL.lua_toboolean(L, 4);
			bool throwOnBindFailure3 = LuaDLL.lua_toboolean(L, 5);
			Delegate o9 = Delegate.CreateDelegate(typeObject11, typeObject12, string5, ignoreCase3, throwOnBindFailure3);
			LuaScriptMgr.Push(L, o9);
			return 1;
		}
		if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Type), typeof(object), typeof(string), typeof(bool), typeof(bool)))
		{
			Type typeObject13 = LuaScriptMgr.GetTypeObject(L, 1);
			object varObject5 = LuaScriptMgr.GetVarObject(L, 2);
			string string6 = LuaScriptMgr.GetString(L, 3);
			bool ignoreCase4 = LuaDLL.lua_toboolean(L, 4);
			bool throwOnBindFailure4 = LuaDLL.lua_toboolean(L, 5);
			Delegate o10 = Delegate.CreateDelegate(typeObject13, varObject5, string6, ignoreCase4, throwOnBindFailure4);
			LuaScriptMgr.Push(L, o10);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Delegate.CreateDelegate");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DynamicInvoke(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		Delegate @delegate = (Delegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate");
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 2, num - 1);
		object o = @delegate.DynamicInvoke(paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Delegate @delegate = (Delegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate");
		object o = @delegate.Clone();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetObjectData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Delegate @delegate = (Delegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate");
		SerializationInfo info = (SerializationInfo)LuaScriptMgr.GetNetObject(L, 2, typeof(SerializationInfo));
		StreamingContext context = (StreamingContext)LuaScriptMgr.GetNetObject(L, 3, typeof(StreamingContext));
		@delegate.GetObjectData(info, context);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInvocationList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Delegate @delegate = (Delegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate");
		Delegate[] invocationList = @delegate.GetInvocationList();
		LuaScriptMgr.PushArray(L, invocationList);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Combine(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			Delegate a = (Delegate)LuaScriptMgr.GetNetObject(L, 1, typeof(Delegate));
			Delegate b = (Delegate)LuaScriptMgr.GetNetObject(L, 2, typeof(Delegate));
			Delegate o = Delegate.Combine(a, b);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		if (LuaScriptMgr.CheckParamsType(L, typeof(Delegate), 1, num))
		{
			Delegate[] paramsObject = LuaScriptMgr.GetParamsObject<Delegate>(L, 1, num);
			Delegate o2 = Delegate.Combine(paramsObject);
			LuaScriptMgr.Push(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Delegate.Combine");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate source = (Delegate)LuaScriptMgr.GetNetObject(L, 1, typeof(Delegate));
		Delegate value = (Delegate)LuaScriptMgr.GetNetObject(L, 2, typeof(Delegate));
		Delegate o = Delegate.Remove(source, value);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate source = (Delegate)LuaScriptMgr.GetNetObject(L, 1, typeof(Delegate));
		Delegate value = (Delegate)LuaScriptMgr.GetNetObject(L, 2, typeof(Delegate));
		Delegate o = Delegate.RemoveAll(source, value);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Sub(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate source = (Delegate)LuaScriptMgr.GetNetObject(L, 1, typeof(Delegate));
		Delegate value = (Delegate)LuaScriptMgr.GetNetObject(L, 2, typeof(Delegate));
		Delegate o = Delegate.Remove(source, value);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate @delegate = LuaScriptMgr.GetLuaObject(L, 1) as Delegate;
		LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			Delegate b = LuaScriptMgr.GetLuaObject(L, 2) as Delegate;
			Delegate o = Delegate.Combine(@delegate, b);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
		Delegate b2 = DelegateFactory.CreateDelegate(@delegate.GetType(), luaFunction);
		Delegate o2 = Delegate.Combine(@delegate, b2);
		LuaScriptMgr.Push(L, o2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate d = LuaScriptMgr.GetLuaObject(L, 1) as Delegate;
		Delegate d2 = LuaScriptMgr.GetLuaObject(L, 2) as Delegate;
		bool b = d == d2;
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Delegate @delegate = (Delegate)LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate");
		int hashCode = @delegate.GetHashCode();
		LuaScriptMgr.Push(L, hashCode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Delegate @delegate = LuaScriptMgr.GetVarObject(L, 1) as Delegate;
		object varObject = LuaScriptMgr.GetVarObject(L, 2);
		bool b = (@delegate == null) ? (varObject == null) : @delegate.Equals(varObject);
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
