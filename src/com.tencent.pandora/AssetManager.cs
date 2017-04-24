using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class AssetManager
	{
		private const string LUA_ASSET_TOKEN = "_lua";

		private static bool _isInitialized;

		private static WwwLoader _wwwLoader;

		private static AssetLoader _assetLoader;

		public static void Initialize()
		{
			if (!AssetManager._isInitialized)
			{
				AssetManager._isInitialized = true;
				GameObject gameObject = Pandora.Instance.GetGameObject();
				AssetManager._wwwLoader = gameObject.AddComponent<WwwLoader>();
				AssetManager._assetLoader = gameObject.AddComponent<AssetLoader>();
				AssetManager._assetLoader.Initialize();
			}
		}

		public static void LoadRemoteConfig(UserData userData, Action<RemoteConfig> callback)
		{
			AssetManager._wwwLoader.LoadRemoteConfig(userData, callback);
		}

		public static void LoadWww(string url, string requestJson, bool isPost, Action<string> callback)
		{
			AssetManager._wwwLoader.LoadWww(url, requestJson, isPost, callback);
		}

		public static void LoadProgramAssetList(string group, List<RemoteConfig.AssetInfo> assetInfoList, Action<string, List<RemoteConfig.AssetInfo>> callback)
		{
			CacheManager.LoadProgramAssetList(group, assetInfoList, delegate(string pGroup, List<RemoteConfig.AssetInfo> pAssetInfoList)
			{
				AssetManager.LoadLuaAssetList(pGroup, pAssetInfoList, callback);
			});
		}

		private static void LoadLuaAssetList(string group, List<RemoteConfig.AssetInfo> assetInfoList, Action<string, List<RemoteConfig.AssetInfo>> callback)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < assetInfoList.Count; i++)
			{
				RemoteConfig.AssetInfo assetInfo = assetInfoList[i];
				if (assetInfo.url.Contains("_lua"))
				{
					if (CacheManager.IsProgramAssetExists(assetInfo.name, assetInfo.md5))
					{
						string cachedProgramAssetUrl = CacheManager.GetCachedProgramAssetUrl(assetInfo.url);
						list.Add(cachedProgramAssetUrl);
					}
					else
					{
						CacheManager.DeleteUnmatchCacheFile(assetInfo.name);
						list.Add(assetInfo.url);
					}
				}
			}
			AssetManager._assetLoader.LoadLuaAssetList(list, delegate(List<string> pLuaAssetUrlList)
			{
				callback(group, assetInfoList);
			});
		}

		public static void GetPanelGameObject(RemoteConfig.AssetInfo assetInfo, Action<GameObject> callback)
		{
			string cachedProgramAssetUrl = CacheManager.GetCachedProgramAssetUrl(assetInfo.url);
			if (AssetPool.HasAsset(cachedProgramAssetUrl))
			{
				AssetManager.OnLoadPrefab(cachedProgramAssetUrl, callback);
			}
			else if (CacheManager.IsProgramAssetExists(assetInfo.name, assetInfo.md5))
			{
				AssetManager.LoadProgramPrefab(assetInfo, true, callback);
			}
			else
			{
				CacheManager.DeleteUnmatchCacheFile(assetInfo.name);
				CacheManager.LoadAsset(assetInfo.url, delegate(string pUrl)
				{
					AssetManager.LoadProgramPrefab(assetInfo, true, callback);
				});
			}
		}

		private static void LoadProgramPrefab(RemoteConfig.AssetInfo assetInfo, bool isCacheInMemory, Action<GameObject> callback)
		{
			string url = assetInfo.url;
			if (CacheManager.IsProgramAssetExists(assetInfo.name, assetInfo.md5))
			{
				url = CacheManager.GetCachedProgramAssetUrl(assetInfo.url);
			}
			AssetConfig config = new AssetConfig(AssetType.Prefab, isCacheInMemory);
			AssetManager._assetLoader.LoadAsset(url, config, delegate(string pUrl)
			{
				AssetManager.OnLoadPrefab(pUrl, callback);
			});
		}

		public static void GetGameObject(string url, Action<GameObject> callback)
		{
			AssetManager.GetGameObject(url, false, callback);
		}

		public static void GetGameObject(string url, bool isCacheInMemory, Action<GameObject> callback)
		{
			string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
			if (AssetPool.HasAsset(cachedAssetUrl))
			{
				AssetManager.OnLoadPrefab(cachedAssetUrl, callback);
			}
			else if (CacheManager.IsAssetExists(url))
			{
				AssetManager.LoadPrefab(cachedAssetUrl, isCacheInMemory, callback);
			}
			else
			{
				CacheManager.LoadAsset(url, delegate(string pUrl)
				{
					AssetManager.LoadPrefab(pUrl, isCacheInMemory, callback);
				});
			}
		}

		private static void LoadPrefab(string url, bool isCacheInMemory, Action<GameObject> callback)
		{
			if (CacheManager.IsAssetExists(url))
			{
				url = CacheManager.GetCachedAssetPath(url);
			}
			AssetConfig config = new AssetConfig(AssetType.Prefab, isCacheInMemory);
			AssetManager._assetLoader.LoadAsset(url, config, delegate(string pUrl)
			{
				AssetManager.OnLoadPrefab(pUrl, callback);
			});
		}

		private static void OnLoadPrefab(string cacheUrl, Action<GameObject> callback)
		{
			GameObject gameObject = AssetPool.GetAsset(cacheUrl) as GameObject;
			GameObject obj = null;
			if (gameObject != null)
			{
				obj = (UnityEngine.Object.Instantiate(gameObject) as GameObject);
			}
			if (callback != null)
			{
				callback(obj);
			}
		}

		public static void GetAssetBundle(string url, Action<AssetBundle> callback)
		{
			string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
			if (AssetPool.HasAsset(cachedAssetUrl))
			{
				AssetManager.OnLoadAssetBundle(cachedAssetUrl, callback);
			}
			else if (CacheManager.IsAssetExists(url))
			{
				AssetManager.LoadAssetBundle(cachedAssetUrl, callback);
			}
			else
			{
				CacheManager.LoadAsset(url, delegate(string pUrl)
				{
					AssetManager.OnCacheLoadAssetBundle(pUrl, callback);
				});
			}
		}

		private static void OnCacheLoadAssetBundle(string url, Action<AssetBundle> callback)
		{
			if (CacheManager.IsAssetExists(url))
			{
				string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
				AssetManager.LoadAssetBundle(cachedAssetUrl, callback);
			}
			else
			{
				AssetManager.LoadAssetBundle(url, callback);
			}
		}

		private static void LoadAssetBundle(string url, Action<AssetBundle> callback)
		{
			AssetConfig config = new AssetConfig(AssetType.Assetbundle, false);
			AssetManager._assetLoader.LoadAsset(url, config, delegate(string pUrl)
			{
				AssetManager.OnLoadAssetBundle(url, callback);
			});
		}

		private static void OnLoadAssetBundle(string cacheUrl, Action<AssetBundle> callback)
		{
			AssetBundle obj = AssetPool.GetAsset(cacheUrl) as AssetBundle;
			if (callback != null)
			{
				callback(obj);
			}
		}

		public static void GetImage(string url, Action<Texture2D> callback)
		{
			AssetManager.GetImage(url, false, callback);
		}

		public static void GetImage(string url, bool isCacheInMemory, Action<Texture2D> callback)
		{
			string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
			if (AssetPool.HasAsset(cachedAssetUrl))
			{
				AssetManager.OnLoadImage(cachedAssetUrl, callback);
			}
			else if (CacheManager.IsAssetExists(url))
			{
				AssetManager.LoadImage(cachedAssetUrl, isCacheInMemory, callback);
			}
			else
			{
				CacheManager.LoadAsset(url, delegate(string pUrl)
				{
					AssetManager.OnCacheLoadImage(pUrl, isCacheInMemory, callback);
				});
			}
		}

		private static void OnCacheLoadImage(string url, bool isCacheInMemory, Action<Texture2D> callback)
		{
			if (CacheManager.IsAssetExists(url))
			{
				string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
				AssetManager.LoadImage(cachedAssetUrl, isCacheInMemory, callback);
			}
			else
			{
				AssetManager.LoadImage(url, isCacheInMemory, callback);
			}
		}

		private static void LoadImage(string url, bool isCacheInMemory, Action<Texture2D> callback)
		{
			AssetConfig config = new AssetConfig(AssetType.Image, isCacheInMemory);
			AssetManager._assetLoader.LoadAsset(url, config, delegate(string pUrl)
			{
				AssetManager.OnLoadImage(url, callback);
			});
		}

		private static void OnLoadImage(string cacheUrl, Action<Texture2D> callback)
		{
			Texture2D obj = AssetPool.GetAsset(cacheUrl) as Texture2D;
			if (callback != null)
			{
				callback(obj);
			}
		}

		public static byte[] GetLuaBytes(string name)
		{
			string key = name + ".lua";
			UnityEngine.Object @object = AssetPool.GetAsset(key);
			if (@object != null)
			{
				return (@object as TextAsset).bytes;
			}
			@object = AssetPool.FindLuaAsset(key);
			if (@object != null)
			{
				return (@object as TextAsset).bytes;
			}
			return null;
		}

		public static void ReleaseProgramAsset(RemoteConfig.AssetInfo assetInfo)
		{
			if (CacheManager.IsProgramAssetExists(assetInfo.name, assetInfo.md5))
			{
				string cachedProgramAssetUrl = CacheManager.GetCachedProgramAssetUrl(assetInfo.url);
				AssetPool.ReleaseAsset(cachedProgramAssetUrl);
			}
			else
			{
				AssetPool.ReleaseAsset(assetInfo.url);
			}
		}

		public static void ReleaseAsset(string url)
		{
			if (CacheManager.IsAssetExists(url))
			{
				string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
				AssetPool.ReleaseAsset(cachedAssetUrl);
			}
			else
			{
				AssetPool.ReleaseAsset(url);
			}
		}

		public static UnityEngine.Object GetAsset(string url)
		{
			string cachedAssetUrl = CacheManager.GetCachedAssetUrl(url);
			return AssetPool.GetAsset(cachedAssetUrl);
		}

		public static void Clear()
		{
			AssetManager._assetLoader.Clear();
			CacheManager.Clear();
			AssetPool.Clear();
		}
	}
}
