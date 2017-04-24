using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class CacheManager
	{
		private static Dictionary<string, object> _cachedProgramAssetInfoDict = new Dictionary<string, object>();

		private static string _programAssetMetaPath;

		private static CacheLoader _cacheLoader;

		private static bool _isInitialized = false;

		private static bool _isMetaDirty = false;

		public static bool PauseDownloading
		{
			get
			{
				return CacheManager._cacheLoader.PauseDownloading;
			}
			set
			{
				CacheManager._cacheLoader.PauseDownloading = value;
			}
		}

		public static void Initialize()
		{
			if (!CacheManager._isInitialized)
			{
				CacheManager._isInitialized = true;
				CacheManager.LoadLocalMetaFile();
				GameObject gameObject = Pandora.Instance.GetGameObject();
				CacheManager._cacheLoader = gameObject.AddComponent<CacheLoader>();
				CacheManager._cacheLoader.Initialize();
			}
		}

		public static void SetProgramAssetProgressCallback(Action<Dictionary<string, string>> callback)
		{
			CacheManager._cacheLoader.programAssetProgressCallback = callback;
		}

		private static void LoadLocalMetaFile()
		{
			try
			{
				CacheManager._programAssetMetaPath = LocalDirectoryHelper.GetProgramAssetMetaPath();
				if (File.Exists(CacheManager._programAssetMetaPath))
				{
					string text = File.ReadAllText(CacheManager._programAssetMetaPath);
					if (!string.IsNullOrEmpty(text))
					{
						CacheManager._cachedProgramAssetInfoDict = (Json.Deserialize(text) as Dictionary<string, object>);
					}
					if (CacheManager._cachedProgramAssetInfoDict == null)
					{
						CacheManager._cachedProgramAssetInfoDict = new Dictionary<string, object>();
					}
				}
			}
			catch (Exception ex)
			{
				string text2 = "CachedFile Meta文件读取失败 " + ex.Message;
				Logger.LogError(text2);
				Pandora.Instance.ReportError(text2, 10217587);
			}
		}

		public static void LoadProgramAssetList(string group, List<RemoteConfig.AssetInfo> assetInfoList, Action<string, List<RemoteConfig.AssetInfo>> callback)
		{
			List<RemoteConfig.AssetInfo> list = new List<RemoteConfig.AssetInfo>();
			for (int i = 0; i < assetInfoList.Count; i++)
			{
				RemoteConfig.AssetInfo assetInfo = assetInfoList[i];
				if (PandoraSettings.UseStreamingAssets || !CacheManager.IsProgramAssetExists(assetInfo.name, assetInfo.md5))
				{
					CacheManager.DeleteUnmatchCacheFile(assetInfo.name);
					assetInfo.url = CacheManager.GetAssetRealUrl(assetInfo.url);
					list.Add(assetInfo);
				}
			}
			if (list.Count == 0)
			{
				callback(group, assetInfoList);
			}
			else
			{
				CacheManager._cacheLoader.LoadProgramAssetList(group, list, delegate(List<string> pAssetList)
				{
					CacheManager.OnLoadProgramAssetList(assetInfoList);
					callback(group, assetInfoList);
				});
			}
		}

		private static string GetAssetRealUrl(string url)
		{
			if (!PandoraSettings.UseStreamingAssets)
			{
				return url;
			}
			string fileName = Path.GetFileName(url);
			if (!LocalDirectoryHelper.IsStreamingAssetsExists(fileName))
			{
				return url;
			}
			return LocalDirectoryHelper.GetStreamingAssetsUrl() + "/" + fileName;
		}

		private static void OnLoadProgramAssetList(List<RemoteConfig.AssetInfo> assetInfoList)
		{
			for (int i = 0; i < assetInfoList.Count; i++)
			{
				RemoteConfig.AssetInfo assetInfo = assetInfoList[i];
				CacheManager.RefreshProgramAssetMeta(assetInfo.name, assetInfo.size, assetInfo.md5);
			}
		}

		public static bool IsProgramAssetExists(string assetName, string assetMd5)
		{
			string cachedProgramAssetPath = CacheManager.GetCachedProgramAssetPath(assetName);
			if (!File.Exists(cachedProgramAssetPath))
			{
				return false;
			}
			if (!CacheManager._cachedProgramAssetInfoDict.ContainsKey(assetName))
			{
				return false;
			}
			Dictionary<string, object> dictionary = CacheManager._cachedProgramAssetInfoDict[assetName] as Dictionary<string, object>;
			return dictionary["md5"] as string == assetMd5;
		}

		public static void DeleteUnmatchCacheFile(string assetName)
		{
			string cachedProgramAssetPath = CacheManager.GetCachedProgramAssetPath(assetName);
			if (!File.Exists(cachedProgramAssetPath))
			{
				return;
			}
			try
			{
				File.Delete(cachedProgramAssetPath);
			}
			catch
			{
				Logger.LogError("删除Meta文件中Md5不匹配的文件： " + assetName);
			}
		}

		public static bool IsProgramAssetExists(List<RemoteConfig.AssetInfo> assetInfoList)
		{
			for (int i = 0; i < assetInfoList.Count; i++)
			{
				RemoteConfig.AssetInfo assetInfo = assetInfoList[i];
				if (!CacheManager.IsProgramAssetExists(assetInfo.name, assetInfo.md5))
				{
					return false;
				}
			}
			return true;
		}

		public static string GetCachedProgramAssetPath(string url)
		{
			string fileName = Path.GetFileName(url);
			return Path.Combine(LocalDirectoryHelper.GetProgramAssetFolderPath(), fileName);
		}

		public static string GetCachedProgramAssetUrl(string url)
		{
			return PandoraSettings.GetFileProtocolToken() + CacheManager.GetCachedProgramAssetPath(url);
		}

		public static void RefreshProgramAssetMeta(string name, int size, string md5)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["name"] = name;
			dictionary["size"] = size;
			dictionary["md5"] = md5;
			if (CacheManager._cachedProgramAssetInfoDict.ContainsKey(name))
			{
				Dictionary<string, object> dictionary2 = CacheManager._cachedProgramAssetInfoDict[name] as Dictionary<string, object>;
				if (dictionary2["md5"].ToString() != md5 || dictionary2["size"].ToString() != size.ToString())
				{
					CacheManager._isMetaDirty = true;
					CacheManager._cachedProgramAssetInfoDict[name] = dictionary;
				}
			}
			else
			{
				CacheManager._isMetaDirty = true;
				CacheManager._cachedProgramAssetInfoDict.Add(name, dictionary);
			}
		}

		public static void WriteProgramAssetMeta()
		{
			try
			{
				if (CacheManager._isMetaDirty)
				{
					CacheManager._isMetaDirty = false;
					string contents = Json.Serialize(CacheManager._cachedProgramAssetInfoDict);
					File.WriteAllText(CacheManager._programAssetMetaPath, contents);
				}
			}
			catch (Exception ex)
			{
				string text = "CachedFile Meta文件更新失败 " + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 10217588);
			}
		}

		public static void LoadAsset(string url, Action<string> callback)
		{
			if (CacheManager.IsAssetExists(url))
			{
				if (callback != null)
				{
					callback(url);
				}
			}
			else
			{
				CacheManager._cacheLoader.LoadAsset(url, callback);
			}
		}

		public static bool IsAssetExists(string url)
		{
			string cachedAssetPath = CacheManager.GetCachedAssetPath(url);
			return File.Exists(cachedAssetPath);
		}

		public static string GetCachedAssetPath(string url)
		{
			string fileName = Path.GetFileName(url);
			return Path.Combine(LocalDirectoryHelper.GetAssetFolderPath(), url.GetHashCode().ToString() + "-" + fileName);
		}

		public static string GetCachedAssetUrl(string url)
		{
			return PandoraSettings.GetFileProtocolToken() + CacheManager.GetCachedAssetPath(url);
		}

		public static void Clear()
		{
			CacheManager._cacheLoader.Clear();
		}
	}
}
