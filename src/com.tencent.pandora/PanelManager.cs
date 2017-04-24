using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class PanelManager
	{
		public const int SUCCESS = 0;

		public const int ERROR_ASSET_NOT_EXISTS = -1;

		public const int ERROR_NO_PARENT = -2;

		public const int ERROR_ALREADY_EXISTS = -3;

		private static Dictionary<string, GameObject> _panelParentDict;

		private static Dictionary<string, GameObject> _panelDict;

		public static void Initialize()
		{
			PanelManager._panelParentDict = new Dictionary<string, GameObject>();
			PanelManager._panelDict = new Dictionary<string, GameObject>();
		}

		public static void SetPanelParent(string name, GameObject parent)
		{
			if (!PanelManager._panelParentDict.ContainsKey(name))
			{
				PanelManager._panelParentDict.Add(name, parent);
			}
			else
			{
				PanelManager._panelParentDict[name] = parent;
			}
		}

		public static GameObject GetPanel(string name)
		{
			if (!PanelManager._panelDict.ContainsKey(name))
			{
				Logger.LogWarning("面板不存在， " + name);
				return null;
			}
			return PanelManager._panelDict[name];
		}

		public static void CreatePanel(string name, Action<int> callback)
		{
			string panelAssetFullName = PanelManager.GetPanelAssetFullName(name);
			RemoteConfig.AssetInfo assetInfo = Pandora.Instance.GetRemoteConfig().GetAssetInfo(panelAssetFullName);
			AssetManager.GetPanelGameObject(assetInfo, delegate(GameObject go)
			{
				PanelManager.OnGetGameObject(go, callback);
			});
		}

		public static void OnGetGameObject(GameObject go, Action<int> callback)
		{
			go.name = go.name.Replace("_copy(Clone)", string.Empty);
			string name = go.name;
			Transform transform = null;
			if (PanelManager._panelDict.ContainsKey(name))
			{
				string text = "已经存在同名面板。 " + name;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 0);
				AssetManager.ReleaseProgramAsset(PanelManager.GetPanelAssetAssetInfo(name));
				PanelManager.Destroy(go);
				callback(-3);
				return;
			}
			if (PanelManager._panelParentDict.ContainsKey(name))
			{
				if (PanelManager._panelParentDict[name] == null)
				{
					string text2 = "面板配置的父节点已经不存在: " + name;
					Logger.LogError(text2);
					Pandora.Instance.ReportError(text2, 0);
					AssetManager.ReleaseProgramAsset(PanelManager.GetPanelAssetAssetInfo(name));
					PanelManager.Destroy(go);
					callback(-2);
					return;
				}
				transform = PanelManager._panelParentDict[name].transform;
			}
			if (transform == null)
			{
				transform = Pandora.Instance.GetGameObject().transform;
			}
			go.transform.SetParent(transform);
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			go.transform.localRotation = Quaternion.identity;
			go.SetActive(true);
			PanelManager._panelDict.Add(name, go);
			callback(0);
		}

		public static void ShowImage(string panelName, string url, UITexture uiTexture, bool isCacheInMemory, Action<int> callback)
		{
			if (!PanelManager._panelDict.ContainsKey(panelName))
			{
				Logger.LogError("面板不存在, " + panelName);
				callback(-1);
				return;
			}
			if (uiTexture == null)
			{
				Logger.LogError("面板中指定的Image组件不存在, " + panelName);
				callback(-2);
				return;
			}
			AssetManager.GetImage(url, isCacheInMemory, delegate(Texture2D texture)
			{
				PanelManager.OnGetImage(uiTexture, texture, url, callback);
			});
		}

		public static void ShowImage(string panelName, string url, GameObject go, bool isCacheInMemory, Action<int> callback)
		{
			if (!PanelManager._panelDict.ContainsKey(panelName))
			{
				Logger.LogError("面板不存在, " + panelName);
				callback(-1);
				return;
			}
			if (go == null)
			{
				Logger.LogError("面板中指定的go不存在, " + panelName);
				callback(-3);
				return;
			}
			UITexture uiTexture = go.GetComponent<UITexture>();
			if (uiTexture == null)
			{
				uiTexture = go.AddComponent<UITexture>();
			}
			AssetManager.GetImage(url, isCacheInMemory, delegate(Texture2D texture)
			{
				PanelManager.OnGetImage(uiTexture, texture, url, callback);
			});
		}

		private static void OnGetImage(UITexture uiTexture, Texture2D texture, string url, Action<int> callback)
		{
			if (uiTexture == null)
			{
				Logger.LogError("目标UITexture已经不存在");
				AssetManager.ReleaseAsset(url);
				callback(-4);
				return;
			}
			uiTexture.mainTexture = texture;
			callback(0);
		}

		public static void Hide(string name)
		{
			if (PanelManager._panelDict.ContainsKey(name))
			{
				GameObject gameObject = PanelManager._panelDict[name];
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
		}

		public static void HideAll()
		{
			foreach (KeyValuePair<string, GameObject> current in PanelManager._panelDict)
			{
				PanelManager.Hide(current.Key);
			}
		}

		public static void Destroy(string name)
		{
			if (PanelManager._panelDict.ContainsKey(name))
			{
				GameObject gameObject = PanelManager._panelDict[name];
				if (gameObject != null)
				{
					PanelManager.Destroy(gameObject);
				}
				AssetManager.ReleaseProgramAsset(PanelManager.GetPanelAssetAssetInfo(name));
				PanelManager._panelDict.Remove(name);
			}
		}

		private static void Destroy(GameObject go)
		{
			if (go != null)
			{
				UnityEngine.Object.Destroy(go);
			}
		}

		public static void DestroyAll()
		{
			List<string> list = new List<string>(PanelManager._panelDict.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				PanelManager.Destroy(list[i]);
			}
		}

		private static string GetPanelAssetFullName(string name)
		{
			return CSharpInterface.GetPlatformDescription() + "_" + name.ToLower() + ".assetbundle";
		}

		private static RemoteConfig.AssetInfo GetPanelAssetAssetInfo(string name)
		{
			string panelAssetFullName = PanelManager.GetPanelAssetFullName(name);
			return Pandora.Instance.GetRemoteConfig().GetAssetInfo(panelAssetFullName);
		}
	}
}
