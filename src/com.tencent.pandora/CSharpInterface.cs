using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	public class CSharpInterface
	{
		public static bool IsIOSPlatform
		{
			get
			{
				return PandoraSettings.IsIOSPlatform;
			}
		}

		public static bool PauseDownloading
		{
			get
			{
				return Pandora.Instance.PauseDownloading;
			}
			set
			{
				Pandora.Instance.PauseDownloading = value;
			}
		}

		public static bool PauseSocketSending
		{
			get
			{
				return Pandora.Instance.PauseSocketSending;
			}
			set
			{
				Pandora.Instance.PauseSocketSending = value;
			}
		}

		public static ulong NowMilliseconds()
		{
			return TimeHelper.NowMilliseconds();
		}

		public static void PlaySound(string id)
		{
			Pandora.Instance.PlaySound(id);
		}

		public static void Report(string content, int id, int type)
		{
			Pandora.Instance.Report(content, id, type);
		}

		public static void ReportError(string error, int id)
		{
			Pandora.Instance.ReportError(error, id);
		}

		public static GameObject CloneAndAddToParent(GameObject template, string name, GameObject parent)
		{
			if (template == null)
			{
				Logger.LogError("源节点不存在");
				return null;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(template) as GameObject;
			gameObject.name = name;
			CSharpInterface.SetParent(gameObject, parent);
			return gameObject;
		}

		public static void SetParent(GameObject child, GameObject parent)
		{
			if (child == null)
			{
				Logger.LogError("源节点不存在");
				return;
			}
			if (parent == null)
			{
				Logger.LogError("父节点不存在");
				return;
			}
			child.transform.SetParent(parent.transform);
			child.transform.localPosition = Vector3.zero;
			child.transform.localScale = Vector3.one;
			child.transform.localRotation = Quaternion.identity;
		}

		public static void SetPanelParent(string panelName, GameObject panelParent)
		{
			Pandora.Instance.SetPanelParent(panelName, panelParent);
		}

		public static bool IsDebug()
		{
			return Pandora.Instance.IsDebug;
		}

		public static string GetPlatformDescription()
		{
			return PandoraSettings.GetPlatformDescription();
		}

		public static string GetSDKVersion()
		{
			return Pandora.Instance.GetUserData().sSdkVersion;
		}

		public static void UnloadUnusedAssets()
		{
			Resources.UnloadUnusedAssets();
		}

		public static bool WriteCookie(string fileName, string content)
		{
			return CookieHelper.Write(fileName, content);
		}

		public static string ReadCookie(string fileName)
		{
			return CookieHelper.Read(fileName);
		}

		public static UserData GetUserData()
		{
			return Pandora.Instance.GetUserData();
		}

		public static RemoteConfig GetRemoteConfig()
		{
			return Pandora.Instance.GetRemoteConfig();
		}

		public static void GetIconSprite(string type, string path, Action<Sprite> callback)
		{
			if (Pandora.Instance.GetIconSprite != null)
			{
				Pandora.Instance.GetIconSprite(type, path, callback);
			}
		}

		public static void ShowImage(string panelName, string url, GameObject go, bool isCacheInMemory, uint callId)
		{
			PanelManager.ShowImage(panelName, url, go, isCacheInMemory, delegate(int returnCode)
			{
				CSharpInterface.OnShowImage(panelName, url, callId, returnCode);
			});
		}

		private static void OnShowImage(string panelName, string url, uint callId, int returnCode)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["PanelName"] = panelName;
			dictionary["Url"] = url;
			dictionary["RetCode"] = returnCode.ToString();
			CSharpInterface.ExecuteLuaCallback(callId, dictionary);
		}

		public static void CacheImage(string url)
		{
			CacheManager.LoadAsset(url, null);
		}

		public static bool IsImageCached(string url)
		{
			return CacheManager.IsAssetExists(url);
		}

		public static void LoadAssetBundle(string url, uint callId)
		{
			AssetManager.GetAssetBundle(url, delegate(AssetBundle assetBundle)
			{
				CSharpInterface.OnLoadAsset(url, assetBundle, callId);
			});
		}

		public static void LoadGameObject(string url, bool isCacheInMemory, uint callId)
		{
			AssetManager.GetGameObject(url, isCacheInMemory, delegate(GameObject gameObject)
			{
				CSharpInterface.OnLoadAsset(url, gameObject, callId);
			});
		}

		public static void LoadImage(string url, bool isCacheInMemory, uint callId)
		{
			AssetManager.GetImage(url, isCacheInMemory, delegate(Texture2D texture)
			{
				CSharpInterface.OnLoadAsset(url, texture, callId);
			});
		}

		private static void OnLoadAsset(string url, UnityEngine.Object obj, uint callId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["Type"] = obj.GetType().ToString();
			dictionary["Url"] = url;
			dictionary["RetCode"] = ((!(obj != null)) ? 1 : 0);
			CSharpInterface.ExecuteLuaCallback(callId, dictionary);
		}

		public static UnityEngine.Object GetAsset(string url)
		{
			return AssetManager.GetAsset(url);
		}

		public static void CacheAsset(string url)
		{
			CacheManager.LoadAsset(url, null);
		}

		public static bool IsAssetCached(string url)
		{
			return CacheManager.IsAssetExists(url);
		}

		public static void ReleaseAsset(string url)
		{
			AssetManager.ReleaseAsset(url);
		}

		public static void LoadWww(string url, string requestJson, bool isPost, uint callId)
		{
			AssetManager.LoadWww(url, requestJson, isPost, delegate(string response)
			{
				CSharpInterface.OnLoadWww(response, callId);
			});
		}

		private static void OnLoadWww(string response, uint callId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["Resp"] = response;
			dictionary["RetCode"] = ((!string.IsNullOrEmpty(response)) ? "0" : "-1");
			CSharpInterface.ExecuteLuaCallback(callId, dictionary);
		}

		public static void CreatePanel(uint callId, string panelName)
		{
			PanelManager.CreatePanel(panelName, delegate(int returnCode)
			{
				CSharpInterface.OnCreatePanel(panelName, callId, returnCode);
			});
		}

		private static void OnCreatePanel(string panelName, uint callId, int returnCode)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["PanelName"] = panelName;
			dictionary["RetCode"] = returnCode.ToString();
			CSharpInterface.ExecuteLuaCallback(callId, dictionary);
			Pandora.Instance.CallGame(Json.Serialize(dictionary));
		}

		public static GameObject GetPanel(string panelName)
		{
			return PanelManager.GetPanel(panelName);
		}

		public static void HidePanel(string panelName)
		{
			PanelManager.Hide(panelName);
		}

		public static void HideAllPanel()
		{
			PanelManager.HideAll();
		}

		public static void DestroyPanel(string panelName)
		{
			PanelManager.Destroy(panelName);
		}

		public static void DestroyAllPanel()
		{
			PanelManager.DestroyAll();
		}

		public static bool GetTotalSwitch()
		{
			return Pandora.Instance.GetRemoteConfig().totalSwitch;
		}

		public static bool GetFunctionSwitch(string functionName)
		{
			return Pandora.Instance.GetRemoteConfig().GetFunctionSwitch(functionName);
		}

		public static void LuaCallGame(string jsonStr)
		{
			Pandora.Instance.CallGame(jsonStr);
		}

		internal static void GameCallLua(string jsonStr)
		{
			try
			{
				if (LuaStateManager.IsInitialized)
				{
					LuaStateManager.CallLuaFunction("Common.CommandFromGame", new object[]
					{
						jsonStr
					});
				}
			}
			catch (Exception ex)
			{
				string text = "Lua执行游戏发送过来的消息失败, " + jsonStr + " " + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 10217591);
			}
		}

		public static void CallBroker(uint callId, string jsonStr, int commandId)
		{
			Pandora.Instance.BrokerSocket.Send(callId, jsonStr, commandId);
		}

		internal static void ExecuteLuaCallback(uint callId, Dictionary<string, object> result)
		{
			string jsonStr = Json.Serialize(result);
			CSharpInterface.ExecuteLuaCallback(callId, jsonStr);
		}

		internal static void ExecuteLuaCallback(uint callId, string jsonStr)
		{
			try
			{
				if (Pandora.Instance.IsDebug)
				{
					Logger.Log("回调Lua, callId " + callId + ": ");
					Logger.Log(jsonStr);
				}
				if (LuaStateManager.IsInitialized)
				{
					LuaStateManager.CallLuaFunction("Common.ExecuteCallback", new object[]
					{
						callId,
						jsonStr
					});
				}
			}
			catch (Exception ex)
			{
				string text = "回调Lua出错了, jsonStr: " + jsonStr + " " + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 10217592);
			}
		}

		public static bool IOSPay(string jsonStr)
		{
			Logger.Log("IOS米大师支付： " + jsonStr);
			return false;
		}

		public static bool AndroidPay(string jsonStr)
		{
			Logger.Log("安卓米大师支付： " + jsonStr);
			return false;
		}

		internal static void IOSPayFinish(string jsonStr)
		{
			try
			{
				if (LuaStateManager.IsInitialized)
				{
					Logger.Log("IOS米大师支付回调Lua层: " + jsonStr);
					LuaStateManager.CallLuaFunction("Common.IOSPayFinish", new object[]
					{
						jsonStr
					});
				}
			}
			catch (Exception ex)
			{
				string text = "IOS米大师支付回调Lua层发生错误\n" + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 0);
			}
		}

		internal static void AndroidPayFinish(string jsonStr)
		{
			try
			{
				if (LuaStateManager.IsInitialized)
				{
					Logger.Log("安卓米大师支付回调Lua层: " + jsonStr);
					LuaStateManager.CallLuaFunction("Common.AndroidPayFinish", new object[]
					{
						jsonStr
					});
				}
			}
			catch (Exception ex)
			{
				string text = "安卓米大师支付回调Lua层发生错误\n" + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 0);
			}
		}
	}
}
