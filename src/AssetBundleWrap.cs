using LuaInterface;
using System;
using UnityEngine;

public class AssetBundleWrap
{
	private static Type classType = typeof(AssetBundle);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CreateFromMemory", new LuaCSFunction(AssetBundleWrap.CreateFromMemory)),
			new LuaMethod("CreateFromMemoryImmediate", new LuaCSFunction(AssetBundleWrap.CreateFromMemoryImmediate)),
			new LuaMethod("CreateFromFile", new LuaCSFunction(AssetBundleWrap.CreateFromFile)),
			new LuaMethod("Contains", new LuaCSFunction(AssetBundleWrap.Contains)),
			new LuaMethod("Load", new LuaCSFunction(AssetBundleWrap.Load)),
			new LuaMethod("LoadAsync", new LuaCSFunction(AssetBundleWrap.LoadAsync)),
			new LuaMethod("LoadAll", new LuaCSFunction(AssetBundleWrap.LoadAll)),
			new LuaMethod("Unload", new LuaCSFunction(AssetBundleWrap.Unload)),
			new LuaMethod("New", new LuaCSFunction(AssetBundleWrap._CreateAssetBundle)),
			new LuaMethod("GetClassType", new LuaCSFunction(AssetBundleWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(AssetBundleWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("mainAsset", new LuaCSFunction(AssetBundleWrap.get_mainAsset), null)
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AssetBundle", typeof(AssetBundle), regs, fields, typeof(UnityEngine.Object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssetBundle(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			AssetBundle obj = new AssetBundle();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, AssetBundleWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainAsset(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		AssetBundle assetBundle = (AssetBundle)luaObject;
		if (assetBundle == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainAsset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainAsset on a nil value");
			}
		}
		LuaScriptMgr.Push(L, assetBundle.mainAsset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateFromMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		AssetBundleCreateRequest o = AssetBundle.CreateFromMemory(arrayNumber);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateFromMemoryImmediate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		AssetBundle obj = AssetBundle.CreateFromMemoryImmediate(arrayNumber);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateFromFile(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			string luaString = LuaScriptMgr.GetLuaString(L, 1);
			AssetBundle obj = AssetBundle.CreateFromFile(luaString);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 2)
		{
			string luaString2 = LuaScriptMgr.GetLuaString(L, 1);
			int offset = (int)LuaScriptMgr.GetNumber(L, 2);
			AssetBundle obj2 = AssetBundle.CreateFromFile(luaString2, offset);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.CreateFromFile");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AssetBundle assetBundle = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		bool b = assetBundle.Contains(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Load(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			AssetBundle assetBundle = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			UnityEngine.Object obj = assetBundle.Load(luaString);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 3)
		{
			AssetBundle assetBundle2 = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			Type typeObject = LuaScriptMgr.GetTypeObject(L, 3);
			UnityEngine.Object obj2 = assetBundle2.Load(luaString2, typeObject);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.Load");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadAsync(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AssetBundle assetBundle = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		Type typeObject = LuaScriptMgr.GetTypeObject(L, 3);
		AssetBundleRequest o = assetBundle.LoadAsync(luaString, typeObject);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadAll(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			AssetBundle assetBundle = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
			UnityEngine.Object[] o = assetBundle.LoadAll();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		if (num == 2)
		{
			AssetBundle assetBundle2 = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
			Type typeObject = LuaScriptMgr.GetTypeObject(L, 2);
			UnityEngine.Object[] o2 = assetBundle2.LoadAll(typeObject);
			LuaScriptMgr.PushArray(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAll");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Unload(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AssetBundle assetBundle = (AssetBundle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle");
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		assetBundle.Unload(boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object x = LuaScriptMgr.GetLuaObject(L, 1) as UnityEngine.Object;
		UnityEngine.Object y = LuaScriptMgr.GetLuaObject(L, 2) as UnityEngine.Object;
		bool b = x == y;
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
