using System;
using System.Collections;
using UnityEngine;

namespace XUtliPoolLib
{
	internal class AndroidAssetBundleLoader : MobileAssetBundleLoader
	{
		protected override IEnumerator LoadFromPackage()
		{
			this._bundle = AssetBundle.CreateFromFile(this._assetBundleSourceFile);
			yield return null;
			if (base.UnloadNotLoadingBundle(this._bundle))
			{
				this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
				yield return null;
			}
			this.Complete();
			yield break;
		}

		protected override void LoadFromPackageImm()
		{
			this._bundle = AssetBundle.CreateFromFile(this._assetBundleSourceFile);
			if (base.UnloadNotLoadingBundle(this._bundle))
			{
				this._bundle = AssetBundle.CreateFromFile(this._assetBundleCachedFile);
			}
			this.Complete();
		}
	}
}
