using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Application : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			Application o = new Application();
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
	public static int Quit_s(IntPtr l)
	{
		int result;
		try
		{
			Application.Quit();
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
	public static int CancelQuit_s(IntPtr l)
	{
		int result;
		try
		{
			Application.CancelQuit();
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
	public static int LoadLevel_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(string)))
			{
				string name;
				LuaObject.checkType(l, 1, out name);
				Application.LoadLevel(name);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(int)))
			{
				int index;
				LuaObject.checkType(l, 1, out index);
				Application.LoadLevel(index);
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
	public static int LoadLevelAsync_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(string)))
			{
				string levelName;
				LuaObject.checkType(l, 1, out levelName);
				AsyncOperation o = Application.LoadLevelAsync(levelName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(int)))
			{
				int index;
				LuaObject.checkType(l, 1, out index);
				AsyncOperation o2 = Application.LoadLevelAsync(index);
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
	public static int LoadLevelAdditiveAsync_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(string)))
			{
				string levelName;
				LuaObject.checkType(l, 1, out levelName);
				AsyncOperation o = Application.LoadLevelAdditiveAsync(levelName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(int)))
			{
				int index;
				LuaObject.checkType(l, 1, out index);
				AsyncOperation o2 = Application.LoadLevelAdditiveAsync(index);
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
	public static int LoadLevelAdditive_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(string)))
			{
				string name;
				LuaObject.checkType(l, 1, out name);
				Application.LoadLevelAdditive(name);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(int)))
			{
				int index;
				LuaObject.checkType(l, 1, out index);
				Application.LoadLevelAdditive(index);
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
	public static int GetStreamProgressForLevel_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(string)))
			{
				string levelName;
				LuaObject.checkType(l, 1, out levelName);
				float streamProgressForLevel = Application.GetStreamProgressForLevel(levelName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, streamProgressForLevel);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(int)))
			{
				int levelIndex;
				LuaObject.checkType(l, 1, out levelIndex);
				float streamProgressForLevel2 = Application.GetStreamProgressForLevel(levelIndex);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, streamProgressForLevel2);
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
	public static int CanStreamedLevelBeLoaded_s(IntPtr l)
	{
		int result;
		try
		{
			int total = LuaDLL.pua_gettop(l);
			if (LuaObject.matchType(l, total, 1, typeof(string)))
			{
				string levelName;
				LuaObject.checkType(l, 1, out levelName);
				bool b = Application.CanStreamedLevelBeLoaded(levelName);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, b);
				result = 2;
			}
			else if (LuaObject.matchType(l, total, 1, typeof(int)))
			{
				int levelIndex;
				LuaObject.checkType(l, 1, out levelIndex);
				bool b2 = Application.CanStreamedLevelBeLoaded(levelIndex);
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
	public static int CaptureScreenshot_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				string filename;
				LuaObject.checkType(l, 1, out filename);
				Application.CaptureScreenshot(filename);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				string filename2;
				LuaObject.checkType(l, 1, out filename2);
				int superSize;
				LuaObject.checkType(l, 2, out superSize);
				Application.CaptureScreenshot(filename2, superSize);
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
	public static int HasProLicense_s(IntPtr l)
	{
		int result;
		try
		{
			bool b = Application.HasProLicense();
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
	public static int ExternalCall_s(IntPtr l)
	{
		int result;
		try
		{
			string functionName;
			LuaObject.checkType(l, 1, out functionName);
			object[] args;
			LuaObject.checkParams<object>(l, 2, out args);
			Application.ExternalCall(functionName, args);
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
	public static int OpenURL_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			Application.OpenURL(url);
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
	public static int RegisterLogCallback_s(IntPtr l)
	{
		int result;
		try
		{
			Application.LogCallback handler;
			LuaDelegation.checkDelegate(l, 1, out handler);
			Application.RegisterLogCallback(handler);
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
	public static int RegisterLogCallbackThreaded_s(IntPtr l)
	{
		int result;
		try
		{
			Application.LogCallback handler;
			LuaDelegation.checkDelegate(l, 1, out handler);
			Application.RegisterLogCallbackThreaded(handler);
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
	public static int RequestUserAuthorization_s(IntPtr l)
	{
		int result;
		try
		{
			UserAuthorization mode;
			LuaObject.checkEnum<UserAuthorization>(l, 1, out mode);
			AsyncOperation o = Application.RequestUserAuthorization(mode);
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
	public static int HasUserAuthorization_s(IntPtr l)
	{
		int result;
		try
		{
			UserAuthorization mode;
			LuaObject.checkEnum<UserAuthorization>(l, 1, out mode);
			bool b = Application.HasUserAuthorization(mode);
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
	public static int get_loadedLevel(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.loadedLevel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_loadedLevelName(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.loadedLevelName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isLoadingLevel(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.isLoadingLevel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_levelCount(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.levelCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_streamedBytes(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.streamedBytes);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isPlaying(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.isPlaying);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isEditor(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.isEditor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isWebPlayer(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.isWebPlayer);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_platform(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)Application.platform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isMobilePlatform(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.isMobilePlatform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isConsolePlatform(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.isConsolePlatform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_runInBackground(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.runInBackground);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_runInBackground(IntPtr l)
	{
		int result;
		try
		{
			bool runInBackground;
			LuaObject.checkType(l, 2, out runInBackground);
			Application.runInBackground = runInBackground;
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
	public static int get_dataPath(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.dataPath);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_streamingAssetsPath(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.streamingAssetsPath);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_persistentDataPath(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.persistentDataPath);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_temporaryCachePath(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.temporaryCachePath);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_srcValue(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.srcValue);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_absoluteURL(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.absoluteURL);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_unityVersion(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.unityVersion);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_webSecurityEnabled(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.webSecurityEnabled);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_webSecurityHostUrl(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.webSecurityHostUrl);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_targetFrameRate(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.targetFrameRate);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_targetFrameRate(IntPtr l)
	{
		int result;
		try
		{
			int targetFrameRate;
			LuaObject.checkType(l, 2, out targetFrameRate);
			Application.targetFrameRate = targetFrameRate;
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
	public static int get_systemLanguage(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)Application.systemLanguage);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_backgroundLoadingPriority(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)Application.backgroundLoadingPriority);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_backgroundLoadingPriority(IntPtr l)
	{
		int result;
		try
		{
			ThreadPriority backgroundLoadingPriority;
			LuaObject.checkEnum<ThreadPriority>(l, 2, out backgroundLoadingPriority);
			Application.backgroundLoadingPriority = backgroundLoadingPriority;
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
	public static int get_internetReachability(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)Application.internetReachability);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_genuine(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.genuine);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_genuineCheckAvailable(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, Application.genuineCheckAvailable);
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
		LuaObject.getTypeTable(l, "UnityEngine.Application");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.Quit_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.CancelQuit_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.LoadLevel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.LoadLevelAsync_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.LoadLevelAdditiveAsync_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.LoadLevelAdditive_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.GetStreamProgressForLevel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.CanStreamedLevelBeLoaded_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.CaptureScreenshot_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.HasProLicense_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.ExternalCall_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.OpenURL_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.RegisterLogCallback_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.RegisterLogCallbackThreaded_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.RequestUserAuthorization_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Application.HasUserAuthorization_s));
		LuaObject.addMember(l, "loadedLevel", new LuaCSFunction(Lua_UnityEngine_Application.get_loadedLevel), null, false);
		LuaObject.addMember(l, "loadedLevelName", new LuaCSFunction(Lua_UnityEngine_Application.get_loadedLevelName), null, false);
		LuaObject.addMember(l, "isLoadingLevel", new LuaCSFunction(Lua_UnityEngine_Application.get_isLoadingLevel), null, false);
		LuaObject.addMember(l, "levelCount", new LuaCSFunction(Lua_UnityEngine_Application.get_levelCount), null, false);
		LuaObject.addMember(l, "streamedBytes", new LuaCSFunction(Lua_UnityEngine_Application.get_streamedBytes), null, false);
		LuaObject.addMember(l, "isPlaying", new LuaCSFunction(Lua_UnityEngine_Application.get_isPlaying), null, false);
		LuaObject.addMember(l, "isEditor", new LuaCSFunction(Lua_UnityEngine_Application.get_isEditor), null, false);
		LuaObject.addMember(l, "isWebPlayer", new LuaCSFunction(Lua_UnityEngine_Application.get_isWebPlayer), null, false);
		LuaObject.addMember(l, "platform", new LuaCSFunction(Lua_UnityEngine_Application.get_platform), null, false);
		LuaObject.addMember(l, "isMobilePlatform", new LuaCSFunction(Lua_UnityEngine_Application.get_isMobilePlatform), null, false);
		LuaObject.addMember(l, "isConsolePlatform", new LuaCSFunction(Lua_UnityEngine_Application.get_isConsolePlatform), null, false);
		LuaObject.addMember(l, "runInBackground", new LuaCSFunction(Lua_UnityEngine_Application.get_runInBackground), new LuaCSFunction(Lua_UnityEngine_Application.set_runInBackground), false);
		LuaObject.addMember(l, "dataPath", new LuaCSFunction(Lua_UnityEngine_Application.get_dataPath), null, false);
		LuaObject.addMember(l, "streamingAssetsPath", new LuaCSFunction(Lua_UnityEngine_Application.get_streamingAssetsPath), null, false);
		LuaObject.addMember(l, "persistentDataPath", new LuaCSFunction(Lua_UnityEngine_Application.get_persistentDataPath), null, false);
		LuaObject.addMember(l, "temporaryCachePath", new LuaCSFunction(Lua_UnityEngine_Application.get_temporaryCachePath), null, false);
		LuaObject.addMember(l, "srcValue", new LuaCSFunction(Lua_UnityEngine_Application.get_srcValue), null, false);
		LuaObject.addMember(l, "absoluteURL", new LuaCSFunction(Lua_UnityEngine_Application.get_absoluteURL), null, false);
		LuaObject.addMember(l, "unityVersion", new LuaCSFunction(Lua_UnityEngine_Application.get_unityVersion), null, false);
		LuaObject.addMember(l, "webSecurityEnabled", new LuaCSFunction(Lua_UnityEngine_Application.get_webSecurityEnabled), null, false);
		LuaObject.addMember(l, "webSecurityHostUrl", new LuaCSFunction(Lua_UnityEngine_Application.get_webSecurityHostUrl), null, false);
		LuaObject.addMember(l, "targetFrameRate", new LuaCSFunction(Lua_UnityEngine_Application.get_targetFrameRate), new LuaCSFunction(Lua_UnityEngine_Application.set_targetFrameRate), false);
		LuaObject.addMember(l, "systemLanguage", new LuaCSFunction(Lua_UnityEngine_Application.get_systemLanguage), null, false);
		LuaObject.addMember(l, "backgroundLoadingPriority", new LuaCSFunction(Lua_UnityEngine_Application.get_backgroundLoadingPriority), new LuaCSFunction(Lua_UnityEngine_Application.set_backgroundLoadingPriority), false);
		LuaObject.addMember(l, "internetReachability", new LuaCSFunction(Lua_UnityEngine_Application.get_internetReachability), null, false);
		LuaObject.addMember(l, "genuine", new LuaCSFunction(Lua_UnityEngine_Application.get_genuine), null, false);
		LuaObject.addMember(l, "genuineCheckAvailable", new LuaCSFunction(Lua_UnityEngine_Application.get_genuineCheckAvailable), null, false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Application.constructor), typeof(Application));
	}
}
