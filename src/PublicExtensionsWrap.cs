using LuaInterface;
using System;
using System.Collections.Generic;
using System.Reflection;

public class PublicExtensionsWrap
{
	private static Type classType = typeof(PublicExtensions);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CastNumberParameters", new LuaCSFunction(PublicExtensionsWrap.CastNumberParameters)),
			new LuaMethod("CallPublicMethod", new LuaCSFunction(PublicExtensionsWrap.CallPublicMethod)),
			new LuaMethod("CallStaticPublicMethod", new LuaCSFunction(PublicExtensionsWrap.CallStaticPublicMethod)),
			new LuaMethod("GetPublicField", new LuaCSFunction(PublicExtensionsWrap.GetPublicField)),
			new LuaMethod("GetStaticPublicField", new LuaCSFunction(PublicExtensionsWrap.GetStaticPublicField)),
			new LuaMethod("GetFieldInfo", new LuaCSFunction(PublicExtensionsWrap.GetFieldInfo)),
			new LuaMethod("GetPublicProperty", new LuaCSFunction(PublicExtensionsWrap.GetPublicProperty)),
			new LuaMethod("GetStaticPublicProperty", new LuaCSFunction(PublicExtensionsWrap.GetStaticPublicProperty)),
			new LuaMethod("GetPropertyInfo", new LuaCSFunction(PublicExtensionsWrap.GetPropertyInfo)),
			new LuaMethod("SetPublicField", new LuaCSFunction(PublicExtensionsWrap.SetPublicField)),
			new LuaMethod("SetStaticPublicField", new LuaCSFunction(PublicExtensionsWrap.SetStaticPublicField)),
			new LuaMethod("SetPublicProperty", new LuaCSFunction(PublicExtensionsWrap.SetPublicProperty)),
			new LuaMethod("SetStaticPublicProperty", new LuaCSFunction(PublicExtensionsWrap.SetStaticPublicProperty)),
			new LuaMethod("New", new LuaCSFunction(PublicExtensionsWrap._CreatePublicExtensions)),
			new LuaMethod("GetClassType", new LuaCSFunction(PublicExtensionsWrap.GetClassType))
		};
		LuaScriptMgr.RegisterLib(L, "PublicExtensions", regs);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreatePublicExtensions(IntPtr L)
	{
		LuaDLL.luaL_error(L, "PublicExtensions class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, PublicExtensionsWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CastNumberParameters(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object[] arrayObject = LuaScriptMgr.GetArrayObject<object>(L, 1);
		Type[] arrayObject2 = LuaScriptMgr.GetArrayObject<Type>(L, 2);
		List<Type[]> o = PublicExtensions.CastNumberParameters(arrayObject, arrayObject2);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallPublicMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 3, num - 2);
		object o = varObject.CallPublicMethod(luaString, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallStaticPublicMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 3, num - 2);
		object o = PublicExtensions.CallStaticPublicMethod(luaString, luaString2, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPublicField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object publicField = varObject.GetPublicField(luaString);
		LuaScriptMgr.PushVarObject(L, publicField);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStaticPublicField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object staticPublicField = PublicExtensions.GetStaticPublicField(luaString, luaString2);
		LuaScriptMgr.PushVarObject(L, staticPublicField);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFieldInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Type typeObject = LuaScriptMgr.GetTypeObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		BindingFlags flags = (BindingFlags)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(BindingFlags)));
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(typeObject, luaString, flags);
		LuaScriptMgr.PushObject(L, fieldInfo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPublicProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object publicProperty = varObject.GetPublicProperty(luaString);
		LuaScriptMgr.PushVarObject(L, publicProperty);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStaticPublicProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object staticPublicProperty = PublicExtensions.GetStaticPublicProperty(luaString, luaString2);
		LuaScriptMgr.PushVarObject(L, staticPublicProperty);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPropertyInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Type typeObject = LuaScriptMgr.GetTypeObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		BindingFlags flags = (BindingFlags)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(BindingFlags)));
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(typeObject, luaString, flags);
		LuaScriptMgr.PushObject(L, propertyInfo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPublicField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object varObject2 = LuaScriptMgr.GetVarObject(L, 3);
		varObject.SetPublicField(luaString, varObject2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStaticPublicField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		PublicExtensions.SetStaticPublicField(luaString, luaString2, varObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPublicProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object varObject2 = LuaScriptMgr.GetVarObject(L, 3);
		varObject.SetPublicProperty(luaString, varObject2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStaticPublicProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		PublicExtensions.SetStaticPublicProperty(luaString, luaString2, varObject);
		return 0;
	}
}
