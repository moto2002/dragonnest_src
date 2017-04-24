using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
	public class AssetBundleManager : MonoBehaviour
	{
		public delegate void LoadAssetCompleteHandler(AssetBundleInfo info);

		public delegate void LoaderCompleteHandler(AssetBundleLoader info);

		public delegate void LoadProgressHandler(AssetBundleLoadProgress progress);

		private const int MAX_REQUEST = 100;

		public static Version version = new Version(0, 1, 0);

		public static AssetBundleManager Instance;

		public static string NAME = "AssetBundleManager";

		public static bool enableLog = false;

		private int _requestRemain = 100;

		private Queue<AssetBundleLoader> _requestQueue = new Queue<AssetBundleLoader>();

		private List<AssetBundleLoader> _currentLoadQueue = new List<AssetBundleLoader>();

		private HashSet<AssetBundleLoader> _nonCompleteLoaderSet = new HashSet<AssetBundleLoader>();

		private HashSet<AssetBundleLoader> _thisTimeLoaderSet = new HashSet<AssetBundleLoader>();

		private Dictionary<uint, AssetBundleInfo> _loadedAssetBundle = new Dictionary<uint, AssetBundleInfo>();

		private Dictionary<uint, AssetBundleLoader> _loaderCache = new Dictionary<uint, AssetBundleLoader>();

		private bool _isCurrentLoading;

		private Queue<AssetBundleInfo> _requestUnloadBundleQueue = new Queue<AssetBundleInfo>();

		private AssetBundleLoadProgress _progress = new AssetBundleLoadProgress();

		public AssetBundleManager.LoadProgressHandler onProgress;

		public AssetBundlePathResolver pathResolver;

		private AssetBundleDataReader _depInfoReader;

		private Action _initCallback;

		private int _bundleCount;

		public int BundleCount
		{
			get
			{
				return this._bundleCount;
			}
		}

		public AssetBundleDataReader depInfoReader
		{
			get
			{
				return this._depInfoReader;
			}
		}

		public bool isCurrentLoading
		{
			get
			{
				return this._isCurrentLoading;
			}
		}

		public AssetBundleManager()
		{
			AssetBundleManager.Instance = this;
			this.pathResolver = new AssetBundlePathResolver();
		}

		protected void Awake()
		{
			base.InvokeRepeating("CheckUnusedBundle", 0f, 5f);
		}

		public void Init(Action callback)
		{
			this._initCallback = callback;
			this.LoadDepInfo();
		}

		public void Init(Stream depStream, Action callback)
		{
			if (depStream.Length > 4L)
			{
				BinaryReader binaryReader = new BinaryReader(depStream);
				if (binaryReader.ReadChar() == 'A' && binaryReader.ReadChar() == 'B' && binaryReader.ReadChar() == 'D')
				{
					if (binaryReader.ReadChar() == 'T')
					{
						this._depInfoReader = new AssetBundleDataReader();
					}
					else
					{
						this._depInfoReader = new AssetBundleDataBinaryReader();
					}
					depStream.Position = 0L;
					this._depInfoReader.Read(depStream);
				}
			}
			depStream.Close();
			if (callback != null)
			{
				callback();
			}
		}

		private void InitComplete()
		{
			if (this._initCallback != null)
			{
				this._initCallback();
			}
			this._initCallback = null;
		}

		private void LoadDepInfo()
		{
			string path = string.Format("{0}/{1}", this.pathResolver.BundleCacheDir, this.pathResolver.DependFileName);
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				this.Init(fileStream, null);
				fileStream.Close();
			}
			else
			{
				TextAsset textAsset = Resources.Load<TextAsset>("dep");
				if (textAsset != null)
				{
					this.Init(new MemoryStream(textAsset.bytes), null);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("depFile not exist!", null, null, null, null, null);
				}
			}
			this.InitComplete();
		}

		private void OnDestroy()
		{
			this.RemoveAll();
		}

		public uint GetAssetBundleFullName(string shortFileName)
		{
			return this._depInfoReader.GetFullName(shortFileName);
		}

		public AssetBundleLoader Load(string path, AssetBundleManager.LoadAssetCompleteHandler handler = null)
		{
			AssetBundleLoader assetBundleLoader = this.CreateLoader(XSingleton<XCommon>.singleton.XHashLower(path), path);
			if (assetBundleLoader == null)
			{
				return null;
			}
			this._thisTimeLoaderSet.Add(assetBundleLoader);
			if (assetBundleLoader.isComplete)
			{
				if (handler != null)
				{
					handler(assetBundleLoader.bundleInfo);
				}
			}
			else
			{
				if (handler != null)
				{
					AssetBundleLoader expr_42 = assetBundleLoader;
					expr_42.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)Delegate.Combine(expr_42.onComplete, handler);
				}
				this._isCurrentLoading = true;
				if (assetBundleLoader.state < LoadState.State_Loading)
				{
					this._nonCompleteLoaderSet.Add(assetBundleLoader);
				}
				this.StartLoad();
			}
			return assetBundleLoader;
		}

		public AssetBundleInfo LoadImm(string path)
		{
			AssetBundleLoader assetBundleLoader = this.CreateLoader(XSingleton<XCommon>.singleton.XHashLower(path), path);
			if (assetBundleLoader == null)
			{
				return null;
			}
			this._thisTimeLoaderSet.Add(assetBundleLoader);
			if (assetBundleLoader.isComplete)
			{
				return assetBundleLoader.bundleInfo;
			}
			this._isCurrentLoading = true;
			if (assetBundleLoader.state < LoadState.State_Loading)
			{
				this._nonCompleteLoaderSet.Add(assetBundleLoader);
			}
			this.StartLoadImm();
			return assetBundleLoader.bundleInfo;
		}

		internal AssetBundleLoader CreateLoader(uint abFileName, string oriName = null)
		{
			AssetBundleLoader assetBundleLoader;
			if (this._loaderCache.ContainsKey(abFileName))
			{
				assetBundleLoader = this._loaderCache[abFileName];
			}
			else
			{
				AssetBundleData assetBundleData = this._depInfoReader.GetAssetBundleInfo(abFileName);
				if (assetBundleData == null && oriName != null)
				{
					assetBundleData = this._depInfoReader.GetAssetBundleInfoByShortName(oriName.ToLower());
				}
				if (assetBundleData == null)
				{
					return null;
				}
				assetBundleLoader = this.CreateLoader();
				assetBundleLoader.bundleManager = this;
				assetBundleLoader.bundleData = assetBundleData;
				assetBundleLoader.bundleName = assetBundleData.fullName;
				this._loaderCache[abFileName] = assetBundleLoader;
			}
			return assetBundleLoader;
		}

		protected virtual AssetBundleLoader CreateLoader()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.IPhonePlayer)
			{
				return new IOSAssetBundleLoader();
			}
			if (platform == RuntimePlatform.Android)
			{
				return new AndroidAssetBundleLoader();
			}
			return new MobileAssetBundleLoader();
		}

		private void StartLoad()
		{
			if (this._nonCompleteLoaderSet.Count > 0)
			{
				List<AssetBundleLoader> list = ListPool<AssetBundleLoader>.Get();
				list.AddRange(this._nonCompleteLoaderSet);
				this._nonCompleteLoaderSet.Clear();
				List<AssetBundleLoader>.Enumerator enumerator = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this._currentLoadQueue.Add(enumerator.Current);
				}
				this._progress = new AssetBundleLoadProgress();
				this._progress.total = this._currentLoadQueue.Count;
				enumerator = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.Load();
				}
				ListPool<AssetBundleLoader>.Release(list);
			}
		}

		private void StartLoadImm()
		{
			if (this._nonCompleteLoaderSet.Count > 0)
			{
				List<AssetBundleLoader> list = ListPool<AssetBundleLoader>.Get();
				list.AddRange(this._nonCompleteLoaderSet);
				this._nonCompleteLoaderSet.Clear();
				List<AssetBundleLoader>.Enumerator enumerator = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this._currentLoadQueue.Add(enumerator.Current);
				}
				this._progress = new AssetBundleLoadProgress();
				this._progress.total = this._currentLoadQueue.Count;
				enumerator = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.LoadImm();
				}
				ListPool<AssetBundleLoader>.Release(list);
			}
		}

		public void RemoveAll()
		{
			base.StopAllCoroutines();
			this._currentLoadQueue.Clear();
			this._requestQueue.Clear();
			foreach (AssetBundleInfo current in this._loadedAssetBundle.Values)
			{
				current.Dispose();
			}
			this._loadedAssetBundle.Clear();
			this._loaderCache.Clear();
			this._requestUnloadBundleQueue.Clear();
		}

		public AssetBundleInfo GetBundleInfo(uint key)
		{
			Dictionary<uint, AssetBundleInfo>.Enumerator enumerator = this._loadedAssetBundle.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, AssetBundleInfo> current = enumerator.Current;
				AssetBundleInfo value = current.Value;
				if (value.bundleName == key)
				{
					return value;
				}
			}
			return null;
		}

		internal void RequestLoadBundle(AssetBundleLoader loader)
		{
			if (this._requestRemain < 0)
			{
				this._requestRemain = 0;
			}
			if (this._requestRemain == 0)
			{
				this._requestQueue.Enqueue(loader);
				return;
			}
			this.LoadBundle(loader);
		}

		internal void RequestLoadBundleImm(AssetBundleLoader loader)
		{
			if (this._requestRemain < 0)
			{
				this._requestRemain = 0;
			}
			if (this._requestRemain == 0)
			{
				this._requestQueue.Enqueue(loader);
				return;
			}
			this.LoadBundleImm(loader);
		}

		private void CheckRequestList()
		{
			while (this._requestRemain > 0 && this._requestQueue.Count > 0)
			{
				AssetBundleLoader loader = this._requestQueue.Dequeue();
				this.LoadBundle(loader);
			}
		}

		private void LoadBundle(AssetBundleLoader loader)
		{
			if (!loader.isComplete)
			{
				loader.LoadBundle();
				this._requestRemain--;
			}
		}

		private void LoadBundleImm(AssetBundleLoader loader)
		{
			if (!loader.isComplete)
			{
				loader.LoadBundleImm();
				this._requestRemain--;
			}
		}

		internal void LoadError(AssetBundleLoader loader)
		{
			this.LoadComplete(loader);
		}

		internal void LoadComplete(AssetBundleLoader loader)
		{
			this._requestRemain++;
			this._currentLoadQueue.Remove(loader);
			if (this.onProgress != null)
			{
				this._progress.loader = loader;
				this._progress.complete = this._progress.total - this._currentLoadQueue.Count;
				this.onProgress(this._progress);
			}
			if (this._currentLoadQueue.Count == 0 && this._nonCompleteLoaderSet.Count == 0)
			{
				this._isCurrentLoading = false;
				HashSet<AssetBundleLoader>.Enumerator enumerator = this._thisTimeLoaderSet.GetEnumerator();
				while (enumerator.MoveNext())
				{
					AssetBundleLoader current = enumerator.Current;
					if (current.bundleInfo != null)
					{
						current.bundleInfo.ResetLifeTime();
					}
				}
				this._thisTimeLoaderSet.Clear();
				return;
			}
			this.CheckRequestList();
		}

		internal AssetBundleInfo CreateBundleInfo(AssetBundleLoader loader, AssetBundleInfo abi = null, AssetBundle assetBundle = null)
		{
			if (abi == null)
			{
				abi = new AssetBundleInfo();
			}
			abi.bundleName = loader.bundleName;
			abi.bundle = assetBundle;
			abi.data = loader.bundleData;
			this._loadedAssetBundle[abi.bundleName] = abi;
			this._bundleCount++;
			return abi;
		}

		public void DeleteBundleCount()
		{
			this._bundleCount--;
		}

		internal void RemoveBundleInfo(AssetBundleInfo abi)
		{
			abi.Dispose();
			this._loadedAssetBundle.Remove(abi.bundleName);
		}

		private void CheckUnusedBundle()
		{
			this.UnloadUnusedBundle(false);
		}

		public void UnloadUnusedBundle(bool force = false)
		{
			if ((!this._isCurrentLoading && !XSingleton<XResourceLoaderMgr>.singleton.isCurrentLoading) || force)
			{
				List<uint> list = ListPool<uint>.Get();
				list.AddRange(this._loadedAssetBundle.Keys);
				int num = 20;
				int num2 = 0;
				bool flag;
				do
				{
					flag = false;
					int num3 = 0;
					while (num3 < list.Count && !this._isCurrentLoading && num2 < num && ((!this._isCurrentLoading && !XSingleton<XResourceLoaderMgr>.singleton.isCurrentLoading) || force))
					{
						uint key = list[num3];
						AssetBundleInfo assetBundleInfo = this._loadedAssetBundle[key];
						if (assetBundleInfo.isUnused)
						{
							flag = true;
							num2++;
							this.RemoveBundleInfo(assetBundleInfo);
							list.RemoveAt(num3);
							num3--;
						}
						num3++;
					}
				}
				while (flag && !this._isCurrentLoading && !XSingleton<XResourceLoaderMgr>.singleton.isCurrentLoading && num2 < num);
				ListPool<uint>.Release(list);
				while (this._requestUnloadBundleQueue.Count > 0 && !this._isCurrentLoading && !XSingleton<XResourceLoaderMgr>.singleton.isCurrentLoading && num2 < num)
				{
					AssetBundleInfo assetBundleInfo2 = this._requestUnloadBundleQueue.Dequeue();
					if (assetBundleInfo2 != null)
					{
						assetBundleInfo2.UnloadBundle();
						num2++;
					}
				}
			}
		}

		public void UnloadNotUsedLoader()
		{
			List<uint> list = ListPool<uint>.Get();
			list.AddRange(this._loadedAssetBundle.Keys);
			List<AssetBundleLoader> list2 = ListPool<AssetBundleLoader>.Get();
			list2.AddRange(this._nonCompleteLoaderSet);
			list2.AddRange(this._currentLoadQueue);
			List<AssetBundleLoader>.Enumerator enumerator = list2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				this.RemoveLoadingLoader(enumerator.Current.bundleName, list);
			}
			for (int i = 0; i < list.Count; i++)
			{
				AssetBundleInfo abi = this._loadedAssetBundle[list[i]];
				this.RemoveBundleInfo(abi);
				list.RemoveAt(i);
				i--;
			}
			ListPool<uint>.Release(list);
			ListPool<AssetBundleLoader>.Release(list2);
		}

		private void RemoveLoadingLoader(uint hash, List<uint> list)
		{
			AssetBundleData assetBundleInfo = this._depInfoReader.GetAssetBundleInfo(hash);
			list.Remove(assetBundleInfo.fullName);
			for (int i = 0; i < assetBundleInfo.dependencies.Length; i++)
			{
				this.RemoveLoadingLoader(assetBundleInfo.dependencies[i], list);
			}
		}

		public void AddUnloadBundleQueue(AssetBundleInfo info)
		{
			this._requestUnloadBundleQueue.Enqueue(info);
			if (this._requestUnloadBundleQueue.Count > 3)
			{
				this.UnloadUnusedBundle(false);
			}
		}

		public void RemoveBundle(uint key)
		{
			AssetBundleInfo bundleInfo = this.GetBundleInfo(key);
			if (bundleInfo != null)
			{
				this.RemoveBundleInfo(bundleInfo);
			}
		}
	}
}
