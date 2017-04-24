using System;
using System.Collections;
using UnityEngine;

namespace XUpdater
{
	internal sealed class XBundle : MonoBehaviour
	{
		private AssetBundleRequest _assetloader;

		public void GetBundle(WWW www, byte[] data, HandleLoadBundle callback, bool load)
		{
			base.StartCoroutine(this.LoadBundle(www, data, callback, load));
		}

		public void GetAsset(AssetBundle bundle, XResPackage package, HandleLoadAsset callback)
		{
			base.StartCoroutine(this.LoadAsset(bundle, package, callback));
		}

		private IEnumerator LoadBundle(WWW www, byte[] data, HandleLoadBundle callback, bool load)
		{
			AssetBundle bundle = null;
			if (load)
			{
				if (www != null)
				{
					bundle = www.assetBundle;
				}
				else
				{
					bundle = AssetBundle.CreateFromMemoryImmediate(data);
				}
				yield return null;
			}
			if (callback != null)
			{
				callback(bundle);
			}
			if (www != null)
			{
				www.Dispose();
			}
			www = null;
			yield break;
		}

		private IEnumerator LoadAsset(AssetBundle bundle, XResPackage package, HandleLoadAsset callback)
		{
			this._assetloader = bundle.LoadAsync(base.name, XUpdater.Ass.GetType(package.type));
			yield return this._assetloader;
			if (callback != null)
			{
				callback(package, this._assetloader.asset);
			}
			this._assetloader = null;
			yield break;
		}
	}
}
