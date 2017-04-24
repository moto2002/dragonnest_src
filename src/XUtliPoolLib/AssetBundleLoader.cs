using System;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	public abstract class AssetBundleLoader
	{
		internal AssetBundleManager.LoadAssetCompleteHandler onComplete;

		public uint bundleName;

		public AssetBundleData bundleData;

		public AssetBundleInfo bundleInfo;

		public AssetBundleManager bundleManager;

		public LoadState state;

		protected AssetBundleLoader[] depLoaders;

		public virtual bool isComplete
		{
			get
			{
				return this.state == LoadState.State_Error || this.state == LoadState.State_Complete;
			}
		}

		public virtual void Load()
		{
		}

		public virtual void LoadImm()
		{
		}

		public virtual void LoadBundle()
		{
		}

		public virtual void LoadBundleImm()
		{
		}

		protected virtual void Complete()
		{
			if (this.onComplete != null)
			{
				AssetBundleManager.LoadAssetCompleteHandler loadAssetCompleteHandler = this.onComplete;
				this.onComplete = null;
				loadAssetCompleteHandler(this.bundleInfo);
			}
			this.bundleManager.LoadComplete(this);
		}

		protected virtual void Error()
		{
			if (this.onComplete != null)
			{
				AssetBundleManager.LoadAssetCompleteHandler loadAssetCompleteHandler = this.onComplete;
				this.onComplete = null;
				loadAssetCompleteHandler(this.bundleInfo);
			}
			this.bundleManager.LoadError(this);
		}

		protected bool UnloadNotLoadingBundle(AssetBundle bundle)
		{
			if (bundle == null)
			{
				int bundleCount = XSingleton<XUpdater>.singleton.ABManager.BundleCount;
				XSingleton<XUpdater>.singleton.ABManager.UnloadNotUsedLoader();
				Resources.UnloadUnusedAssets();
				XSingleton<XDebug>.singleton.AddErrorLog("AssetBundle Count: ", bundleCount.ToString(), " , ", XSingleton<XUpdater>.singleton.ABManager.BundleCount.ToString(), null, null);
				return true;
			}
			return false;
		}
	}
}
