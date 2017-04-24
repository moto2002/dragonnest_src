using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
	public class MobileAssetBundleLoader : AssetBundleLoader
	{
		protected int _currentLoadingDepCount;

		protected AssetBundle _bundle;

		protected bool _hasError;

		protected string _assetBundleCachedFile;

		protected string _assetBundleSourceFile;

		public override void Load()
		{
			if (this._hasError)
			{
				this.state = LoadState.State_Error;
			}
			if (this.state == LoadState.State_None)
			{
				this.state = LoadState.State_Loading;
				this.LoadDepends();
				return;
			}
			if (this.state == LoadState.State_Error)
			{
				this.Error();
				return;
			}
			if (this.state == LoadState.State_Complete)
			{
				this.Complete();
			}
		}

		public override void LoadImm()
		{
			if (this._hasError)
			{
				this.state = LoadState.State_Error;
			}
			if (this.state == LoadState.State_None)
			{
				this.state = LoadState.State_Loading;
				this.LoadDependsImm();
				return;
			}
			if (this.state == LoadState.State_Error)
			{
				this.Error();
				return;
			}
			if (this.state == LoadState.State_Complete)
			{
				this.Complete();
			}
		}

		private void LoadDepends()
		{
			if (this.depLoaders == null)
			{
				this.depLoaders = new AssetBundleLoader[this.bundleData.dependencies.Length];
				for (int i = 0; i < this.bundleData.dependencies.Length; i++)
				{
					this.depLoaders[i] = this.bundleManager.CreateLoader(this.bundleData.dependencies[i], null);
				}
			}
			this._currentLoadingDepCount = 0;
			for (int j = 0; j < this.depLoaders.Length; j++)
			{
				AssetBundleLoader assetBundleLoader = this.depLoaders[j];
				if (!assetBundleLoader.isComplete)
				{
					this._currentLoadingDepCount++;
					AssetBundleLoader expr_84 = assetBundleLoader;
					expr_84.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)Delegate.Combine(expr_84.onComplete, new AssetBundleManager.LoadAssetCompleteHandler(this.OnDepComplete));
					assetBundleLoader.Load();
				}
			}
			this.CheckDepComplete();
		}

		private void LoadDependsImm()
		{
			if (this.depLoaders == null)
			{
				this.depLoaders = new AssetBundleLoader[this.bundleData.dependencies.Length];
				for (int i = 0; i < this.bundleData.dependencies.Length; i++)
				{
					this.depLoaders[i] = this.bundleManager.CreateLoader(this.bundleData.dependencies[i], null);
				}
			}
			this._currentLoadingDepCount = 1;
			for (int j = 0; j < this.depLoaders.Length; j++)
			{
				AssetBundleLoader assetBundleLoader = this.depLoaders[j];
				if (assetBundleLoader.state != LoadState.State_Error && assetBundleLoader.state != LoadState.State_Complete)
				{
					this._currentLoadingDepCount++;
					AssetBundleLoader expr_8E = assetBundleLoader;
					expr_8E.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)Delegate.Combine(expr_8E.onComplete, new AssetBundleManager.LoadAssetCompleteHandler(this.OnDepCompleteImm));
					assetBundleLoader.LoadImm();
				}
			}
			this._currentLoadingDepCount--;
			this.CheckDepCompleteImm();
		}

		public override void LoadBundle()
		{
			this._assetBundleCachedFile = Path.Combine(this.bundleManager.pathResolver.BundleCacheDir, this.bundleName + ".ab");
			this._assetBundleSourceFile = this.bundleManager.pathResolver.GetBundleSourceFile(this.bundleName + ".ab", false);
			if (File.Exists(this._assetBundleCachedFile))
			{
				this.bundleManager.StartCoroutine(this.LoadFromCachedFile());
				return;
			}
			this.bundleManager.StartCoroutine(this.LoadFromPackage());
		}

		public override void LoadBundleImm()
		{
			this._assetBundleCachedFile = Path.Combine(this.bundleManager.pathResolver.BundleCacheDir, this.bundleName + ".ab");
			this._assetBundleSourceFile = this.bundleManager.pathResolver.GetBundleSourceFile(this.bundleName + ".ab", false);
			if (File.Exists(this._assetBundleCachedFile))
			{
				this.LoadFromCachedFileImm();
				return;
			}
			this.LoadFromPackageImm();
		}

		protected virtual IEnumerator LoadFromCachedFile()
		{
			if (this.state != LoadState.State_Error)
			{
				this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
				yield return null;
				if (base.UnloadNotLoadingBundle(this._bundle))
				{
					this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
					yield return null;
				}
				this.Complete();
			}
			yield break;
		}

		protected virtual void LoadFromCachedFileImm()
		{
			if (this.state != LoadState.State_Error)
			{
				this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
				if (base.UnloadNotLoadingBundle(this._bundle))
				{
					this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
				}
				this.Complete();
			}
		}

		protected virtual IEnumerator LoadFromPackage()
		{
			if (this.state != LoadState.State_Error)
			{
				this._bundle = AssetBundle.CreateFromFile(this._assetBundleSourceFile);
				yield return null;
				if (base.UnloadNotLoadingBundle(this._bundle))
				{
					this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
					yield return null;
				}
				this.Complete();
			}
			yield break;
		}

		protected virtual void LoadFromPackageImm()
		{
			if (this.state != LoadState.State_Error)
			{
				this._bundle = AssetBundle.CreateFromFile(this._assetBundleSourceFile);
				if (base.UnloadNotLoadingBundle(this._bundle))
				{
					this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
				}
				this.Complete();
			}
		}

		private void OnDepComplete(AssetBundleInfo abi)
		{
			this._currentLoadingDepCount--;
			this.CheckDepComplete();
		}

		private void OnDepCompleteImm(AssetBundleInfo abi)
		{
			this._currentLoadingDepCount--;
			this.CheckDepCompleteImm();
		}

		private void CheckDepComplete()
		{
			if (this._currentLoadingDepCount == 0)
			{
				this.bundleManager.RequestLoadBundle(this);
			}
		}

		private void CheckDepCompleteImm()
		{
			if (this._currentLoadingDepCount == 0)
			{
				this.bundleManager.RequestLoadBundleImm(this);
			}
		}

		protected override void Complete()
		{
			if (this.bundleInfo == null)
			{
				this.state = LoadState.State_Complete;
				this.bundleInfo = this.bundleManager.CreateBundleInfo(this, null, this._bundle);
				this.bundleInfo.isReady = true;
				this.bundleInfo.onUnloaded = new AssetBundleInfo.OnUnloadedHandler(this.OnBundleUnload);
				AssetBundleLoader[] depLoaders = this.depLoaders;
				for (int i = 0; i < depLoaders.Length; i++)
				{
					AssetBundleLoader assetBundleLoader = depLoaders[i];
					this.bundleInfo.AddDependency(assetBundleLoader.bundleInfo);
				}
				this._bundle = null;
			}
			base.Complete();
		}

		private void OnBundleUnload(AssetBundleInfo abi)
		{
			this.bundleInfo = null;
			this.state = LoadState.State_None;
		}

		protected override void Error()
		{
			this._hasError = true;
			this.state = LoadState.State_Error;
			this.bundleInfo = null;
			base.Error();
		}
	}
}
