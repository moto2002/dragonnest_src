using LuaInterface;
using System;
using UnityEngine;

public class ApplicationWrap
{
	private static Type classType = typeof(Application);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Quit", new LuaCSFunction(ApplicationWrap.Quit)),
			new LuaMethod("CancelQuit", new LuaCSFunction(ApplicationWrap.CancelQuit)),
			new LuaMethod("LoadLevel", new LuaCSFunction(ApplicationWrap.LoadLevel)),
			new LuaMethod("LoadLevelAsync", new LuaCSFunction(ApplicationWrap.LoadLevelAsync)),
			new LuaMethod("LoadLevelAdditiveAsync", new LuaCSFunction(ApplicationWrap.LoadLevelAdditiveAsync)),
			new LuaMethod("LoadLevelAdditive", new LuaCSFunction(ApplicationWrap.LoadLevelAdditive)),
			new LuaMethod("GetStreamProgressForLevel", new LuaCSFunction(ApplicationWrap.GetStreamProgressForLevel)),
			new LuaMethod("CanStreamedLevelBeLoaded", new LuaCSFunction(ApplicationWrap.CanStreamedLevelBeLoaded)),
			new LuaMethod("CaptureScreenshot", new LuaCSFunction(ApplicationWrap.CaptureScreenshot)),
			new LuaMethod("HasProLicense", new LuaCSFunction(ApplicationWrap.HasProLicense)),
			new LuaMethod("ExternalCall", new LuaCSFunction(ApplicationWrap.ExternalCall)),
			new LuaMethod("OpenURL", new LuaCSFunction(ApplicationWrap.OpenURL)),
			new LuaMethod("RegisterLogCallback", new LuaCSFunction(ApplicationWrap.RegisterLogCallback)),
			new LuaMethod("RegisterLogCallbackThreaded", new LuaCSFunction(ApplicationWrap.RegisterLogCallbackThreaded)),
			new LuaMethod("RequestUserAuthorization", new LuaCSFunction(ApplicationWrap.RequestUserAuthorization)),
			new LuaMethod("HasUserAuthorization", new LuaCSFunction(ApplicationWrap.HasUserAuthorization)),
			new LuaMethod("New", new LuaCSFunction(ApplicationWrap._CreateApplication)),
			new LuaMethod("GetClassType", new LuaCSFunction(ApplicationWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("loadedLevel", new LuaCSFunction(ApplicationWrap.get_loadedLevel), null),
			new LuaField("loadedLevelName", new LuaCSFunction(ApplicationWrap.get_loadedLevelName), null),
			new LuaField("isLoadingLevel", new LuaCSFunction(ApplicationWrap.get_isLoadingLevel), null),
			new LuaField("levelCount", new LuaCSFunction(ApplicationWrap.get_levelCount), null),
			new LuaField("streamedBytes", new LuaCSFunction(ApplicationWrap.get_streamedBytes), null),
			new LuaField("isPlaying", new LuaCSFunction(ApplicationWrap.get_isPlaying), null),
			new LuaField("isEditor", new LuaCSFunction(ApplicationWrap.get_isEditor), null),
			new LuaField("isWebPlayer", new LuaCSFunction(ApplicationWrap.get_isWebPlayer), null),
			new LuaField("platform", new LuaCSFunction(ApplicationWrap.get_platform), null),
			new LuaField("isMobilePlatform", new LuaCSFunction(ApplicationWrap.get_isMobilePlatform), null),
			new LuaField("isConsolePlatform", new LuaCSFunction(ApplicationWrap.get_isConsolePlatform), null),
			new LuaField("runInBackground", new LuaCSFunction(ApplicationWrap.get_runInBackground), new LuaCSFunction(ApplicationWrap.set_runInBackground)),
			new LuaField("dataPath", new LuaCSFunction(ApplicationWrap.get_dataPath), null),
			new LuaField("streamingAssetsPath", new LuaCSFunction(ApplicationWrap.get_streamingAssetsPath), null),
			new LuaField("persistentDataPath", new LuaCSFunction(ApplicationWrap.get_persistentDataPath), null),
			new LuaField("temporaryCachePath", new LuaCSFunction(ApplicationWrap.get_temporaryCachePath), null),
			new LuaField("srcValue", new LuaCSFunction(ApplicationWrap.get_srcValue), null),
			new LuaField("absoluteURL", new LuaCSFunction(ApplicationWrap.get_absoluteURL), null),
			new LuaField("unityVersion", new LuaCSFunction(ApplicationWrap.get_unityVersion), null),
			new LuaField("webSecurityEnabled", new LuaCSFunction(ApplicationWrap.get_webSecurityEnabled), null),
			new LuaField("webSecurityHostUrl", new LuaCSFunction(ApplicationWrap.get_webSecurityHostUrl), null),
			new LuaField("targetFrameRate", new LuaCSFunction(ApplicationWrap.get_targetFrameRate), new LuaCSFunction(ApplicationWrap.set_targetFrameRate)),
			new LuaField("systemLanguage", new LuaCSFunction(ApplicationWrap.get_systemLanguage), null),
			new LuaField("backgroundLoadingPriority", new LuaCSFunction(ApplicationWrap.get_backgroundLoadingPriority), new LuaCSFunction(ApplicationWrap.set_backgroundLoadingPriority)),
			new LuaField("internetReachability", new LuaCSFunction(ApplicationWrap.get_internetReachability), null),
			new LuaField("genuine", new LuaCSFunction(ApplicationWrap.get_genuine), null),
			new LuaField("genuineCheckAvailable", new LuaCSFunction(ApplicationWrap.get_genuineCheckAvailable), null)
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Application", typeof(Application), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateApplication(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Application o = new Application();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, ApplicationWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loadedLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.loadedLevel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loadedLevelName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.loadedLevelName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isLoadingLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isLoadingLevel);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_levelCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.levelCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_streamedBytes(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.streamedBytes);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPlaying(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isPlaying);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isEditor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isEditor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isWebPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isWebPlayer);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_platform(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.platform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isMobilePlatform(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isMobilePlatform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isConsolePlatform(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isConsolePlatform);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_runInBackground(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.runInBackground);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.dataPath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_streamingAssetsPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.streamingAssetsPath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_persistentDataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.persistentDataPath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_temporaryCachePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.temporaryCachePath);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_srcValue(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.srcValue);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_absoluteURL(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.absoluteURL);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_unityVersion(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.unityVersion);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_webSecurityEnabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.webSecurityEnabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_webSecurityHostUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.webSecurityHostUrl);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetFrameRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.targetFrameRate);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_systemLanguage(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.systemLanguage);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundLoadingPriority(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.backgroundLoadingPriority);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_internetReachability(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.internetReachability);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_genuine(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.genuine);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_genuineCheckAvailable(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.genuineCheckAvailable);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_runInBackground(IntPtr L)
	{
		Application.runInBackground = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetFrameRate(IntPtr L)
	{
		Application.targetFrameRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundLoadingPriority(IntPtr L)
	{
		Application.backgroundLoadingPriority = (ThreadPriority)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(ThreadPriority)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Quit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Application.Quit();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CancelQuit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Application.CancelQuit();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevel(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			Application.LoadLevel(@string);
			return 0;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int index = (int)LuaDLL.lua_tonumber(L, 1);
			Application.LoadLevel(index);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevel");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevelAsync(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			AsyncOperation o = Application.LoadLevelAsync(@string);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int index = (int)LuaDLL.lua_tonumber(L, 1);
			AsyncOperation o2 = Application.LoadLevelAsync(index);
			LuaScriptMgr.PushObject(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevelAsync");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevelAdditiveAsync(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			AsyncOperation o = Application.LoadLevelAdditiveAsync(@string);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int index = (int)LuaDLL.lua_tonumber(L, 1);
			AsyncOperation o2 = Application.LoadLevelAdditiveAsync(index);
			LuaScriptMgr.PushObject(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevelAdditiveAsync");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadLevelAdditive(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			Application.LoadLevelAdditive(@string);
			return 0;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int index = (int)LuaDLL.lua_tonumber(L, 1);
			Application.LoadLevelAdditive(index);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevelAdditive");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStreamProgressForLevel(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			float streamProgressForLevel = Application.GetStreamProgressForLevel(@string);
			LuaScriptMgr.Push(L, streamProgressForLevel);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int levelIndex = (int)LuaDLL.lua_tonumber(L, 1);
			float streamProgressForLevel2 = Application.GetStreamProgressForLevel(levelIndex);
			LuaScriptMgr.Push(L, streamProgressForLevel2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.GetStreamProgressForLevel");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CanStreamedLevelBeLoaded(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			bool b = Application.CanStreamedLevelBeLoaded(@string);
			LuaScriptMgr.Push(L, b);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int levelIndex = (int)LuaDLL.lua_tonumber(L, 1);
			bool b2 = Application.CanStreamedLevelBeLoaded(levelIndex);
			LuaScriptMgr.Push(L, b2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.CanStreamedLevelBeLoaded");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CaptureScreenshot(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			string luaString = LuaScriptMgr.GetLuaString(L, 1);
			Application.CaptureScreenshot(luaString);
			return 0;
		}
		if (num == 2)
		{
			string luaString2 = LuaScriptMgr.GetLuaString(L, 1);
			int superSize = (int)LuaScriptMgr.GetNumber(L, 2);
			Application.CaptureScreenshot(luaString2, superSize);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Application.CaptureScreenshot");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasProLicense(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		bool b = Application.HasProLicense();
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ExternalCall(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		object[] paramsObject = LuaScriptMgr.GetParamsObject(L, 2, num - 1);
		Application.ExternalCall(luaString, paramsObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenURL(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		Application.OpenURL(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterLogCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
		Application.LogCallback handler;
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			handler = (Application.LogCallback)LuaScriptMgr.GetNetObject(L, 1, typeof(Application.LogCallback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 1);
			handler = delegate(string param0, string param1, LogType param2)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				LuaScriptMgr.Push(L, param2);
				func.PCall(oldTop, 3);
				func.EndPCall(oldTop);
			};
		}
		Application.RegisterLogCallback(handler);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterLogCallbackThreaded(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
		Application.LogCallback handler;
		if (luaTypes != LuaTypes.LUA_TFUNCTION)
		{
			handler = (Application.LogCallback)LuaScriptMgr.GetNetObject(L, 1, typeof(Application.LogCallback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 1);
			handler = delegate(string param0, string param1, LogType param2)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				LuaScriptMgr.Push(L, param2);
				func.PCall(oldTop, 3);
				func.EndPCall(oldTop);
			};
		}
		Application.RegisterLogCallbackThreaded(handler);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RequestUserAuthorization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UserAuthorization mode = (UserAuthorization)((int)LuaScriptMgr.GetNetObject(L, 1, typeof(UserAuthorization)));
		AsyncOperation o = Application.RequestUserAuthorization(mode);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasUserAuthorization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UserAuthorization mode = (UserAuthorization)((int)LuaScriptMgr.GetNetObject(L, 1, typeof(UserAuthorization)));
		bool b = Application.HasUserAuthorization(mode);
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
