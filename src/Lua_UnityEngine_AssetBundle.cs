using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_AssetBundle : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			AssetBundle o = new AssetBundle();
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
	public static int Contains(IntPtr l)
	{
		int result;
		try
		{
			AssetBundle assetBundle = (AssetBundle)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			bool b = assetBundle.Contains(name);
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
	public static int Load(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				AssetBundle assetBundle = (AssetBundle)LuaObject.checkSelf(l);
				string name;
				LuaObject.checkType(l, 2, out name);
				UnityEngine.Object o = assetBundle.Load(name);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 3)
			{
				AssetBundle assetBundle2 = (AssetBundle)LuaObject.checkSelf(l);
				string name2;
				LuaObject.checkType(l, 2, out name2);
				Type type;
				LuaObject.checkType(l, 3, out type);
				UnityEngine.Object o2 = assetBundle2.Load(name2, type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
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
	public static int LoadAsync(IntPtr l)
	{
		int result;
		try
		{
			AssetBundle assetBundle = (AssetBundle)LuaObject.checkSelf(l);
			string name;
			LuaObject.checkType(l, 2, out name);
			Type type;
			LuaObject.checkType(l, 3, out type);
			AssetBundleRequest o = assetBundle.LoadAsync(name, type);
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
	public static int LoadAll(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				AssetBundle assetBundle = (AssetBundle)LuaObject.checkSelf(l);
				UnityEngine.Object[] a = assetBundle.LoadAll();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, a);
				result = 2;
			}
			else if (num == 2)
			{
				AssetBundle assetBundle2 = (AssetBundle)LuaObject.checkSelf(l);
				Type type;
				LuaObject.checkType(l, 2, out type);
				UnityEngine.Object[] a2 = assetBundle2.LoadAll(type);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, a2);
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
	public static int Unload(IntPtr l)
	{
		int result;
		try
		{
			AssetBundle assetBundle = (AssetBundle)LuaObject.checkSelf(l);
			bool unloadAllLoadedObjects;
			LuaObject.checkType(l, 2, out unloadAllLoadedObjects);
			assetBundle.Unload(unloadAllLoadedObjects);
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
	public static int CreateFromMemory_s(IntPtr l)
	{
		int result;
		try
		{
			byte[] binary;
			LuaObject.checkArray<byte>(l, 1, out binary);
			AssetBundleCreateRequest o = AssetBundle.CreateFromMemory(binary);
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
	public static int CreateFromMemoryImmediate_s(IntPtr l)
	{
		int result;
		try
		{
			byte[] binary;
			LuaObject.checkArray<byte>(l, 1, out binary);
			AssetBundle o = AssetBundle.CreateFromMemoryImmediate(binary);
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
	public static int CreateFromFile_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				string path;
				LuaObject.checkType(l, 1, out path);
				AssetBundle o = AssetBundle.CreateFromFile(path);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 2)
			{
				string path2;
				LuaObject.checkType(l, 1, out path2);
				int offset;
				LuaObject.checkType(l, 2, out offset);
				AssetBundle o2 = AssetBundle.CreateFromFile(path2, offset);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o2);
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
	public static int get_mainAsset(IntPtr l)
	{
		int result;
		try
		{
			AssetBundle assetBundle = (AssetBundle)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, assetBundle.mainAsset);
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
		LuaObject.getTypeTable(l, "UnityEngine.AssetBundle");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.Contains));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.Load));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.LoadAsync));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.LoadAll));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.Unload));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.CreateFromMemory_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.CreateFromMemoryImmediate_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.CreateFromFile_s));
		LuaObject.addMember(l, "mainAsset", new LuaCSFunction(Lua_UnityEngine_AssetBundle.get_mainAsset), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_AssetBundle.constructor), typeof(AssetBundle), typeof(UnityEngine.Object));
	}
}
