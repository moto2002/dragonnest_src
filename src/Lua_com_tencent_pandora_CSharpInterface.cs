using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_com_tencent_pandora_CSharpInterface : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			CSharpInterface o = new CSharpInterface();
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
	public static int NowMilliseconds_s(IntPtr l)
	{
		int result;
		try
		{
			ulong o = CSharpInterface.NowMilliseconds();
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
	public static int PlaySound_s(IntPtr l)
	{
		int result;
		try
		{
			string id;
			LuaObject.checkType(l, 1, out id);
			CSharpInterface.PlaySound(id);
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
	public static int Report_s(IntPtr l)
	{
		int result;
		try
		{
			string content;
			LuaObject.checkType(l, 1, out content);
			int id;
			LuaObject.checkType(l, 2, out id);
			int type;
			LuaObject.checkType(l, 3, out type);
			CSharpInterface.Report(content, id, type);
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
	public static int ReportError_s(IntPtr l)
	{
		int result;
		try
		{
			string error;
			LuaObject.checkType(l, 1, out error);
			int id;
			LuaObject.checkType(l, 2, out id);
			CSharpInterface.ReportError(error, id);
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
	public static int CloneAndAddToParent_s(IntPtr l)
	{
		int result;
		try
		{
			GameObject template;
			LuaObject.checkType<GameObject>(l, 1, out template);
			string name;
			LuaObject.checkType(l, 2, out name);
			GameObject parent;
			LuaObject.checkType<GameObject>(l, 3, out parent);
			GameObject o = CSharpInterface.CloneAndAddToParent(template, name, parent);
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
	public static int SetParent_s(IntPtr l)
	{
		int result;
		try
		{
			GameObject child;
			LuaObject.checkType<GameObject>(l, 1, out child);
			GameObject parent;
			LuaObject.checkType<GameObject>(l, 2, out parent);
			CSharpInterface.SetParent(child, parent);
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
	public static int SetPanelParent_s(IntPtr l)
	{
		int result;
		try
		{
			string panelName;
			LuaObject.checkType(l, 1, out panelName);
			GameObject panelParent;
			LuaObject.checkType<GameObject>(l, 2, out panelParent);
			CSharpInterface.SetPanelParent(panelName, panelParent);
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
	public static int IsDebug_s(IntPtr l)
	{
		int result;
		try
		{
			bool b = CSharpInterface.IsDebug();
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
	public static int GetPlatformDescription_s(IntPtr l)
	{
		int result;
		try
		{
			string platformDescription = CSharpInterface.GetPlatformDescription();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, platformDescription);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetSDKVersion_s(IntPtr l)
	{
		int result;
		try
		{
			string sDKVersion = CSharpInterface.GetSDKVersion();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, sDKVersion);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int UnloadUnusedAssets_s(IntPtr l)
	{
		int result;
		try
		{
			CSharpInterface.UnloadUnusedAssets();
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
	public static int WriteCookie_s(IntPtr l)
	{
		int result;
		try
		{
			string fileName;
			LuaObject.checkType(l, 1, out fileName);
			string content;
			LuaObject.checkType(l, 2, out content);
			bool b = CSharpInterface.WriteCookie(fileName, content);
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
	public static int ReadCookie_s(IntPtr l)
	{
		int result;
		try
		{
			string fileName;
			LuaObject.checkType(l, 1, out fileName);
			string s = CSharpInterface.ReadCookie(fileName);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, s);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetUserData_s(IntPtr l)
	{
		int result;
		try
		{
			UserData userData = CSharpInterface.GetUserData();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, userData);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetRemoteConfig_s(IntPtr l)
	{
		int result;
		try
		{
			RemoteConfig remoteConfig = CSharpInterface.GetRemoteConfig();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, remoteConfig);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetIconSprite_s(IntPtr l)
	{
		int result;
		try
		{
			string type;
			LuaObject.checkType(l, 1, out type);
			string path;
			LuaObject.checkType(l, 2, out path);
			Action<Sprite> callback;
			LuaDelegation.checkDelegate(l, 3, out callback);
			CSharpInterface.GetIconSprite(type, path, callback);
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
	public static int ShowImage_s(IntPtr l)
	{
		int result;
		try
		{
			string panelName;
			LuaObject.checkType(l, 1, out panelName);
			string url;
			LuaObject.checkType(l, 2, out url);
			GameObject go;
			LuaObject.checkType<GameObject>(l, 3, out go);
			bool isCacheInMemory;
			LuaObject.checkType(l, 4, out isCacheInMemory);
			uint callId;
			LuaObject.checkType(l, 5, out callId);
			CSharpInterface.ShowImage(panelName, url, go, isCacheInMemory, callId);
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
	public static int CacheImage_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			CSharpInterface.CacheImage(url);
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
	public static int IsImageCached_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			bool b = CSharpInterface.IsImageCached(url);
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
	public static int LoadAssetBundle_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			uint callId;
			LuaObject.checkType(l, 2, out callId);
			CSharpInterface.LoadAssetBundle(url, callId);
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
	public static int LoadGameObject_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			bool isCacheInMemory;
			LuaObject.checkType(l, 2, out isCacheInMemory);
			uint callId;
			LuaObject.checkType(l, 3, out callId);
			CSharpInterface.LoadGameObject(url, isCacheInMemory, callId);
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
	public static int LoadImage_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			bool isCacheInMemory;
			LuaObject.checkType(l, 2, out isCacheInMemory);
			uint callId;
			LuaObject.checkType(l, 3, out callId);
			CSharpInterface.LoadImage(url, isCacheInMemory, callId);
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
	public static int GetAsset_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			UnityEngine.Object asset = CSharpInterface.GetAsset(url);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, asset);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int CacheAsset_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			CSharpInterface.CacheAsset(url);
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
	public static int IsAssetCached_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			bool b = CSharpInterface.IsAssetCached(url);
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
	public static int ReleaseAsset_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			CSharpInterface.ReleaseAsset(url);
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
	public static int LoadWww_s(IntPtr l)
	{
		int result;
		try
		{
			string url;
			LuaObject.checkType(l, 1, out url);
			string requestJson;
			LuaObject.checkType(l, 2, out requestJson);
			bool isPost;
			LuaObject.checkType(l, 3, out isPost);
			uint callId;
			LuaObject.checkType(l, 4, out callId);
			CSharpInterface.LoadWww(url, requestJson, isPost, callId);
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
	public static int CreatePanel_s(IntPtr l)
	{
		int result;
		try
		{
			uint callId;
			LuaObject.checkType(l, 1, out callId);
			string panelName;
			LuaObject.checkType(l, 2, out panelName);
			CSharpInterface.CreatePanel(callId, panelName);
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
	public static int GetPanel_s(IntPtr l)
	{
		int result;
		try
		{
			string panelName;
			LuaObject.checkType(l, 1, out panelName);
			GameObject panel = CSharpInterface.GetPanel(panelName);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, panel);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int HidePanel_s(IntPtr l)
	{
		int result;
		try
		{
			string panelName;
			LuaObject.checkType(l, 1, out panelName);
			CSharpInterface.HidePanel(panelName);
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
	public static int HideAllPanel_s(IntPtr l)
	{
		int result;
		try
		{
			CSharpInterface.HideAllPanel();
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
	public static int DestroyPanel_s(IntPtr l)
	{
		int result;
		try
		{
			string panelName;
			LuaObject.checkType(l, 1, out panelName);
			CSharpInterface.DestroyPanel(panelName);
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
	public static int DestroyAllPanel_s(IntPtr l)
	{
		int result;
		try
		{
			CSharpInterface.DestroyAllPanel();
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
	public static int GetTotalSwitch_s(IntPtr l)
	{
		int result;
		try
		{
			bool totalSwitch = CSharpInterface.GetTotalSwitch();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, totalSwitch);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetFunctionSwitch_s(IntPtr l)
	{
		int result;
		try
		{
			string functionName;
			LuaObject.checkType(l, 1, out functionName);
			bool functionSwitch = CSharpInterface.GetFunctionSwitch(functionName);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, functionSwitch);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int LuaCallGame_s(IntPtr l)
	{
		int result;
		try
		{
			string jsonStr;
			LuaObject.checkType(l, 1, out jsonStr);
			CSharpInterface.LuaCallGame(jsonStr);
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
	public static int CallBroker_s(IntPtr l)
	{
		int result;
		try
		{
			uint callId;
			LuaObject.checkType(l, 1, out callId);
			string jsonStr;
			LuaObject.checkType(l, 2, out jsonStr);
			int commandId;
			LuaObject.checkType(l, 3, out commandId);
			CSharpInterface.CallBroker(callId, jsonStr, commandId);
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
	public static int IOSPay_s(IntPtr l)
	{
		int result;
		try
		{
			string jsonStr;
			LuaObject.checkType(l, 1, out jsonStr);
			bool b = CSharpInterface.IOSPay(jsonStr);
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
	public static int AndroidPay_s(IntPtr l)
	{
		int result;
		try
		{
			string jsonStr;
			LuaObject.checkType(l, 1, out jsonStr);
			bool b = CSharpInterface.AndroidPay(jsonStr);
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
	public static int get_IsIOSPlatform(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, CSharpInterface.IsIOSPlatform);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_PauseDownloading(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, CSharpInterface.PauseDownloading);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_PauseDownloading(IntPtr l)
	{
		int result;
		try
		{
			bool pauseDownloading;
			LuaObject.checkType(l, 2, out pauseDownloading);
			CSharpInterface.PauseDownloading = pauseDownloading;
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
	public static int get_PauseSocketSending(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, CSharpInterface.PauseSocketSending);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_PauseSocketSending(IntPtr l)
	{
		int result;
		try
		{
			bool pauseSocketSending;
			LuaObject.checkType(l, 2, out pauseSocketSending);
			CSharpInterface.PauseSocketSending = pauseSocketSending;
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
		LuaObject.getTypeTable(l, "com.tencent.pandora.CSharpInterface");
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.NowMilliseconds_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.PlaySound_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.Report_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.ReportError_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.CloneAndAddToParent_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.SetParent_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.SetPanelParent_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.IsDebug_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetPlatformDescription_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetSDKVersion_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.UnloadUnusedAssets_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.WriteCookie_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.ReadCookie_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetUserData_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetRemoteConfig_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetIconSprite_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.ShowImage_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.CacheImage_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.IsImageCached_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.LoadAssetBundle_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.LoadGameObject_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.LoadImage_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetAsset_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.CacheAsset_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.IsAssetCached_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.ReleaseAsset_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.LoadWww_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.CreatePanel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetPanel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.HidePanel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.HideAllPanel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.DestroyPanel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.DestroyAllPanel_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetTotalSwitch_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.GetFunctionSwitch_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.LuaCallGame_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.CallBroker_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.IOSPay_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.AndroidPay_s));
		LuaObject.addMember(l, "IsIOSPlatform", new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.get_IsIOSPlatform), null, false);
		LuaObject.addMember(l, "PauseDownloading", new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.get_PauseDownloading), new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.set_PauseDownloading), false);
		LuaObject.addMember(l, "PauseSocketSending", new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.get_PauseSocketSending), new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.set_PauseSocketSending), false);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_com_tencent_pandora_CSharpInterface.constructor), typeof(CSharpInterface));
	}
}
