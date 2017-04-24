using LuaInterface;
using System;

public class PrivateExtensionsWrap
{
	private static Type classType = typeof(PrivateExtensions);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CallPrivateMethod", new LuaCSFunction(PrivateExtensionsWrap.CallPrivateMethod)),
			new LuaMethod("CallStaticPrivateMethod", new LuaCSFunction(PrivateExtensionsWrap.CallStaticPrivateMethod)),
			new LuaMethod("GetPrivateField", new LuaCSFunction(PrivateExtensionsWrap.GetPrivateField)),
			new LuaMethod("GetStaticPrivateField", new LuaCSFunction(PrivateExtensionsWrap.GetStaticPrivateField)),
			new LuaMethod("GetPrivateProperty", new LuaCSFunction(PrivateExtensionsWrap.GetPrivateProperty)),
			new LuaMethod("GetStaticPrivateProperty", new LuaCSFunction(PrivateExtensionsWrap.GetStaticPrivateProperty)),
			new LuaMethod("SetPrivateField", new LuaCSFunction(PrivateExtensionsWrap.SetPrivateField)),
			new LuaMethod("SetStaticPrivateField", new LuaCSFunction(PrivateExtensionsWrap.SetStaticPrivateField)),
			new LuaMethod("SetPrivateProperty", new LuaCSFunction(PrivateExtensionsWrap.SetPrivateProperty)),
			new LuaMethod("SetStaticPrivateProperty", new LuaCSFunction(PrivateExtensionsWrap.SetStaticPrivateProperty)),
			new LuaMethod("New", new LuaCSFunction(PrivateExtensionsWrap._CreatePrivateExtensions)),
			new LuaMethod("GetClassType", new LuaCSFunction(PrivateExtensionsWrap.GetClassType))
		};
		LuaScriptMgr.RegisterLib(L, "PrivateExtensions", regs);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreatePrivateExtensions(IntPtr L)
	{
		LuaDLL.luaL_error(L, "PrivateExtensions class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, PrivateExtensionsWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallPrivateMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 3, num - 2);
		object o = varObject.CallPrivateMethod(luaString, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallStaticPrivateMethod(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 3, num - 2);
		object o = PrivateExtensions.CallStaticPrivateMethod(luaString, luaString2, paramsObject);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPrivateField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object privateField = varObject.GetPrivateField(luaString);
		LuaScriptMgr.PushVarObject(L, privateField);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStaticPrivateField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object staticPrivateField = PrivateExtensions.GetStaticPrivateField(luaString, luaString2);
		LuaScriptMgr.PushVarObject(L, staticPrivateField);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPrivateProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object privateProperty = varObject.GetPrivateProperty(luaString);
		LuaScriptMgr.PushVarObject(L, privateProperty);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStaticPrivateProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object staticPrivateProperty = PrivateExtensions.GetStaticPrivateProperty(luaString, luaString2);
		LuaScriptMgr.PushVarObject(L, staticPrivateProperty);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPrivateField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object varObject2 = LuaScriptMgr.GetVarObject(L, 3);
		varObject.SetPrivateField(luaString, varObject2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStaticPrivateField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		PrivateExtensions.SetStaticPrivateField(luaString, luaString2, varObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPrivateProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		object varObject2 = LuaScriptMgr.GetVarObject(L, 3);
		varObject.SetPrivateProperty(luaString, varObject2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStaticPrivateProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 3);
		PrivateExtensions.SetStaticPrivateProperty(luaString, luaString2, varObject);
		return 0;
	}
}
