using System;
using System.IO;
using UnityEngine;

public class Util
{
	public static bool isApplePlatform
	{
		get
		{
			return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
		}
	}

	public static string LuaPath(string name)
	{
		if (name.StartsWith("Hotfix") || name.EndsWith("_pb.lua") || name.StartsWith("Lua"))
		{
			return name;
		}
		if (name.StartsWith(Application.temporaryCachePath))
		{
			return name;
		}
		string dataPath = Application.dataPath;
		string text = name.ToLower();
		if (text.EndsWith(".lua"))
		{
			int length = name.LastIndexOf('.');
			name = name.Substring(0, length);
		}
		name = name.Replace('.', '/');
		return dataPath + "/uLua/lua/" + name + ".lua";
	}

	public static string LuaResourcePath(string name)
	{
		string text = name.ToLower();
		if (text.EndsWith(".lua"))
		{
			int length = name.LastIndexOf('.');
			name = name.Substring(0, length);
		}
		name = name.Replace('.', '/');
		return "lua/" + name + ".lua";
	}

	public static void Log(string str)
	{
		Debug.Log(str);
	}

	public static void LogWarning(string str)
	{
		Debug.LogWarning(str);
	}

	public static void LogError(string str)
	{
		Debug.LogError(str);
	}

	public static void ClearMemory()
	{
		GC.Collect();
		Resources.UnloadUnusedAssets();
		LuaScriptMgr instance = LuaScriptMgr.Instance;
		if (instance != null && instance.lua != null)
		{
			instance.LuaGC(new string[0]);
		}
	}

	private static int CheckRuntimeFile()
	{
		if (!Application.isEditor)
		{
			return 0;
		}
		string path = AppConst.uLuaPath + "/Source/LuaWrap/";
		if (!Directory.Exists(path))
		{
			return -2;
		}
		string[] files = Directory.GetFiles(path);
		if (files.Length == 0)
		{
			return -2;
		}
		return 0;
	}

	public static bool CheckEnvironment()
	{
		return true;
	}
}
