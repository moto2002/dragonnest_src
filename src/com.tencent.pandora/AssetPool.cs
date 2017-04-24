using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class AssetPool
	{
		internal class Asset
		{
			private int _referenceCount;

			public string Key
			{
				get;
				set;
			}

			public UnityEngine.Object Object
			{
				get;
				set;
			}

			public float ReleaseTime
			{
				get;
				set;
			}

			public int ReferenceCount
			{
				get
				{
					return this._referenceCount;
				}
				set
				{
					this._referenceCount = value;
					if (this._referenceCount == 0)
					{
						this.ReleaseTime = Time.realtimeSinceStartup + 60f;
					}
					else
					{
						this.ReleaseTime = 3.40282347E+38f;
					}
				}
			}

			public Asset(string key, UnityEngine.Object obj, int referenceCount)
			{
				this.Key = key;
				this.Object = obj;
				this.ReferenceCount = referenceCount;
			}
		}

		public const int LUA_INIT_REFERENCE_COUNT = 999;

		public const int DELETE_ASSET_INTERVAL = 60;

		private static Dictionary<string, WWW> _wwwDict = new Dictionary<string, WWW>();

		private static Dictionary<string, AssetPool.Asset> _strongAssetDict = new Dictionary<string, AssetPool.Asset>();

		private static Dictionary<string, AssetPool.Asset> _weakAssetDict = new Dictionary<string, AssetPool.Asset>();

		private static List<string> _deletedKeyList = new List<string>();

		public static void AddWww(string url, WWW www)
		{
			if (!AssetPool._wwwDict.ContainsKey(url))
			{
				AssetPool._wwwDict.Add(url, www);
			}
			else
			{
				Logger.LogError("WWW资源已经存在， Url: " + url);
			}
		}

		public static WWW GetWww(string url)
		{
			if (AssetPool._wwwDict.ContainsKey(url))
			{
				return AssetPool._wwwDict[url];
			}
			return null;
		}

		public static void DisposeWww(string url)
		{
			if (AssetPool._wwwDict.ContainsKey(url))
			{
				AssetPool._wwwDict[url].Dispose();
				AssetPool._wwwDict.Remove(url);
			}
		}

		public static bool ParseAsset(string url, AssetConfig config)
		{
			switch (config.type)
			{
			case AssetType.Lua:
				return AssetPool.ParseLuaAsset(url);
			case AssetType.Prefab:
				return AssetPool.ParsePrefabAsset(url, config.isCacheInMemory);
			case AssetType.Image:
				return AssetPool.ParseImageAsset(url, config.isCacheInMemory);
			case AssetType.Assetbundle:
				return AssetPool.ParseAssetBundle(url);
			default:
				return false;
			}
		}

		public static bool ParseLuaAsset(string url)
		{
			bool result = false;
			WWW www = AssetPool.GetWww(url);
			if (www != null)
			{
				try
				{
					UnityEngine.Object[] array = www.assetBundle.LoadAll(typeof(TextAsset));
					for (int i = 0; i < array.Length; i++)
					{
						UnityEngine.Object @object = array[i];
						AssetPool.AddAsset(@object.name, @object, 999, true);
					}
					www.assetBundle.Unload(false);
					result = true;
				}
				catch (Exception ex)
				{
					string text = "资源解析失败 " + url + "\n" + ex.Message;
					Pandora.Instance.ReportError(text, 10217582);
					Logger.LogError(text);
					LocalDirectoryHelper.DeleteAssetByUrl(url);
				}
				AssetPool.DisposeWww(url);
			}
			return result;
		}

		public static UnityEngine.Object FindLuaAsset(string key)
		{
			foreach (string current in AssetPool._strongAssetDict.Keys)
			{
				if (current.ToLower() == key)
				{
					return AssetPool._strongAssetDict[current].Object;
				}
			}
			return null;
		}

		private static void AddAsset(string key, UnityEngine.Object obj, int referenceCount, bool isCacheInMemory)
		{
			if (AssetPool._strongAssetDict.ContainsKey(key))
			{
				Logger.LogError("StrongAssetDict 重复资源： " + key);
				return;
			}
			if (AssetPool._weakAssetDict.ContainsKey(key))
			{
				Logger.LogError("WeakAssetDict 重复资源： " + key);
				return;
			}
			if (isCacheInMemory)
			{
				AssetPool._strongAssetDict.Add(key, new AssetPool.Asset(key, obj, referenceCount));
			}
			else
			{
				AssetPool._weakAssetDict.Add(key, new AssetPool.Asset(key, obj, 0));
			}
		}

		public static bool HasAsset(string key)
		{
			return AssetPool.IsInStrongDict(key) || AssetPool.IsInWeakDict(key);
		}

		private static bool IsInStrongDict(string key)
		{
			return AssetPool._strongAssetDict.ContainsKey(key);
		}

		private static bool IsInWeakDict(string key)
		{
			return AssetPool._weakAssetDict.ContainsKey(key);
		}

		public static UnityEngine.Object GetAsset(string key)
		{
			if (AssetPool.IsInStrongDict(key))
			{
				AssetPool.Asset asset = AssetPool._strongAssetDict[key];
				asset.ReferenceCount++;
				return asset.Object;
			}
			if (AssetPool.IsInWeakDict(key))
			{
				AssetPool.Asset asset2 = AssetPool._weakAssetDict[key];
				return asset2.Object;
			}
			return null;
		}

		public static void ReleaseAsset(string key)
		{
			if (!AssetPool.IsInStrongDict(key))
			{
				return;
			}
			AssetPool.Asset asset = AssetPool._strongAssetDict[key];
			asset.ReferenceCount--;
		}

		public static bool ParsePrefabAsset(string url, bool isCacheInMemory)
		{
			bool result = false;
			WWW www = AssetPool.GetWww(url);
			if (www != null)
			{
				try
				{
					UnityEngine.Object[] array = new UnityEngine.Object[]
					{
						www.assetBundle.mainAsset
					};
					if (array.Length > 1)
					{
						throw new Exception("资源打包不符合规范，一个AssetBundle中只能有一个Prefab， " + url);
					}
					for (int i = 0; i < array.Length; i++)
					{
						UnityEngine.Object obj = array[i];
						AssetPool.AddAsset(url, obj, 0, isCacheInMemory);
					}
					www.assetBundle.Unload(false);
					result = true;
				}
				catch (Exception ex)
				{
					string text = "资源解析失败： " + url + "\n" + ex.Message;
					Pandora.Instance.ReportError(text, 10217582);
					Logger.LogError(text);
					LocalDirectoryHelper.DeleteAssetByUrl(url);
				}
				AssetPool.DisposeWww(url);
			}
			return result;
		}

		public static bool ParseImageAsset(string url, bool isCacheInMemory)
		{
			bool result = false;
			WWW www = AssetPool.GetWww(url);
			if (www != null)
			{
				try
				{
					Texture2D textureNonReadable = www.textureNonReadable;
					textureNonReadable.name = url;
					AssetPool.AddAsset(url, textureNonReadable, 0, isCacheInMemory);
					result = true;
				}
				catch (Exception ex)
				{
					string text = "资源解析失败： " + url + "\n" + ex.Message;
					Pandora.Instance.ReportError(text, 10217582);
					Logger.LogError(text);
					LocalDirectoryHelper.DeleteAssetByUrl(url);
				}
				AssetPool.DisposeWww(url);
			}
			return result;
		}

		public static bool ParseAssetBundle(string url)
		{
			WWW www = AssetPool.GetWww(url);
			if (www != null)
			{
				AssetPool.AddAsset(url, www.assetBundle, 0, false);
				AssetPool.DisposeWww(url);
			}
			return true;
		}

		public static void Clear()
		{
			AssetPool._strongAssetDict.Clear();
			AssetPool._weakAssetDict.Clear();
		}

		public static List<string> DeleteZeroReferenceAsset()
		{
			AssetPool._deletedKeyList.Clear();
			AssetPool.DeleteZeroReferenceAsset(AssetPool._strongAssetDict);
			AssetPool.DeleteZeroReferenceAsset(AssetPool._weakAssetDict);
			return AssetPool._deletedKeyList;
		}

		private static void DeleteZeroReferenceAsset(Dictionary<string, AssetPool.Asset> assetDict)
		{
			Dictionary<string, AssetPool.Asset>.Enumerator enumerator = assetDict.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, AssetPool.Asset> current = enumerator.Current;
				string key = current.Key;
				KeyValuePair<string, AssetPool.Asset> current2 = enumerator.Current;
				AssetPool.Asset value = current2.Value;
				if (Time.realtimeSinceStartup > value.ReleaseTime)
				{
					AssetPool._deletedKeyList.Add(key);
				}
			}
			for (int i = 0; i < AssetPool._deletedKeyList.Count; i++)
			{
				assetDict.Remove(AssetPool._deletedKeyList[i]);
			}
		}

		public static Dictionary<string, int> GetAssetReferenceCountDict()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (string current in AssetPool._strongAssetDict.Keys)
			{
				dictionary.Add(current, AssetPool._strongAssetDict[current].ReferenceCount);
			}
			return dictionary;
		}
	}
}
