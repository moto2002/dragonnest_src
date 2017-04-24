using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationWrap
{
	private static Type classType = typeof(Localization);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Load", new LuaCSFunction(LocalizationWrap.Load)),
			new LuaMethod("LoadCSV", new LuaCSFunction(LocalizationWrap.LoadCSV)),
			new LuaMethod("Set", new LuaCSFunction(LocalizationWrap.Set)),
			new LuaMethod("Get", new LuaCSFunction(LocalizationWrap.Get)),
			new LuaMethod("Exists", new LuaCSFunction(LocalizationWrap.Exists)),
			new LuaMethod("New", new LuaCSFunction(LocalizationWrap._CreateLocalization)),
			new LuaMethod("GetClassType", new LuaCSFunction(LocalizationWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("localizationHasBeenSet", new LuaCSFunction(LocalizationWrap.get_localizationHasBeenSet), new LuaCSFunction(LocalizationWrap.set_localizationHasBeenSet)),
			new LuaField("dictionary", new LuaCSFunction(LocalizationWrap.get_dictionary), new LuaCSFunction(LocalizationWrap.set_dictionary)),
			new LuaField("knownLanguages", new LuaCSFunction(LocalizationWrap.get_knownLanguages), null),
			new LuaField("language", new LuaCSFunction(LocalizationWrap.get_language), new LuaCSFunction(LocalizationWrap.set_language))
		};
		LuaScriptMgr.RegisterLib(L, "Localization", typeof(Localization), regs, fields, null);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLocalization(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Localization class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, LocalizationWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localizationHasBeenSet(IntPtr L)
	{
		LuaScriptMgr.Push(L, Localization.localizationHasBeenSet);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dictionary(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Localization.dictionary);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_knownLanguages(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Localization.knownLanguages);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_language(IntPtr L)
	{
		LuaScriptMgr.Push(L, Localization.language);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localizationHasBeenSet(IntPtr L)
	{
		Localization.localizationHasBeenSet = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dictionary(IntPtr L)
	{
		Localization.dictionary = (Dictionary<string, string[]>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<string, string[]>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_language(IntPtr L)
	{
		Localization.language = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TextAsset asset = (TextAsset)LuaScriptMgr.GetUnityObject(L, 1, typeof(TextAsset));
		Localization.Load(asset);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadCSV(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TextAsset asset = (TextAsset)LuaScriptMgr.GetUnityObject(L, 1, typeof(TextAsset));
		bool b = Localization.LoadCSV(asset);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		Dictionary<string, string> dictionary = (Dictionary<string, string>)LuaScriptMgr.GetNetObject(L, 2, typeof(Dictionary<string, string>));
		Localization.Set(luaString, dictionary);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			string str = Localization.Get(@string);
			LuaScriptMgr.Push(L, str);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int key = (int)LuaDLL.lua_tonumber(L, 1);
			string str2 = Localization.Get(key);
			LuaScriptMgr.Push(L, str2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Localization.Get");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Exists(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool b = Localization.Exists(luaString);
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
