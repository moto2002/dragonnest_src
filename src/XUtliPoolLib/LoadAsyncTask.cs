using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public class LoadAsyncTask
	{
		public List<LoadInfo> loadCbList = new List<LoadInfo>();

		public string location = "";

		public uint hash;

		public bool complete;

		public bool isSharedRes = true;

		public LoadFrom type;

		public ResourceRequest loader;

		public bool valid;

		public bool CheckComplete()
		{
			if (this.loader == null)
			{
				return this.complete;
			}
			if (this.loader.isDone)
			{
				this.ResourceLoadCompleteCb(this.loader);
			}
			return this.complete;
		}

		public void CancelLoad(LoadCallBack cb)
		{
			for (int i = this.loadCbList.Count - 1; i >= 0; i--)
			{
				if (this.loadCbList[i].loadCb == cb)
				{
					this.loadCbList.RemoveAt(i);
				}
			}
		}

		private void ReturnNull()
		{
			int i = 0;
			int count = this.loadCbList.Count;
			while (i < count)
			{
				LoadInfo loadInfo = this.loadCbList[i];
				if (loadInfo.loadCb != null)
				{
					loadInfo.loadCb(null, this.location, this.isSharedRes);
				}
				i++;
			}
			this.loadCbList.Clear();
		}

		public void ResourceLoadCompleteCb(ResourceRequest loader)
		{
			this.complete = true;
			if (loader.asset == null)
			{
				XResourceLoaderMgr.LoadErrorLog(this.location);
				this.ReturnNull();
				return;
			}
			if (XSingleton<XResourceLoaderMgr>.singleton.useNewMgr)
			{
				XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo;
				bool objectAsync = XSingleton<XResourceLoaderMgr>.singleton.GetObjectAsync(this.location, this.hash, loader.asset, null, this.isSharedRes, out uniteObjectInfo);
				if (uniteObjectInfo != null)
				{
					int i = 0;
					int count = this.loadCbList.Count;
					while (i < count)
					{
						LoadInfo loadInfo = this.loadCbList[i];
						if (loadInfo.loadCb != null)
						{
							UnityEngine.Object @object = XSingleton<XResourceLoaderMgr>.singleton.GetObject(uniteObjectInfo, this.isSharedRes, loadInfo.usePool, objectAsync);
							loadInfo.loadCb(@object, this.location, this.isSharedRes);
						}
						i++;
					}
					this.loadCbList.Clear();
					return;
				}
			}
			else
			{
				XSingleton<XResourceLoaderMgr>.singleton.AddAssetInPool(loader.asset, this.hash, null);
				int j = 0;
				int count2 = this.loadCbList.Count;
				while (j < count2)
				{
					LoadInfo loadInfo2 = this.loadCbList[j];
					if (loadInfo2.loadCb != null)
					{
						if (this.isSharedRes)
						{
							this.GetSharedResourceCb(loadInfo2.loadCb, null);
						}
						else
						{
							UnityEngine.Object obj = null;
							if (loadInfo2.usePool && XSingleton<XResourceLoaderMgr>.singleton.GetInObjectPool(ref obj, this.hash))
							{
								loadInfo2.loadCb(obj, this.location, this.isSharedRes);
							}
							else
							{
								this.CreateFromPrefabCb(loadInfo2.loadCb, null);
							}
						}
					}
					j++;
				}
				this.loadCbList.Clear();
			}
		}

		public void AssetBundleLoadCompleteCb(AssetBundleInfo info)
		{
			this.complete = true;
			if (info.mainObject == null)
			{
				XResourceLoaderMgr.LoadErrorLog(this.location);
				this.ReturnNull();
				return;
			}
			if (XSingleton<XResourceLoaderMgr>.singleton.useNewMgr)
			{
				XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo;
				bool objectAsync = XSingleton<XResourceLoaderMgr>.singleton.GetObjectAsync(this.location, this.hash, null, info, this.isSharedRes, out uniteObjectInfo);
				if (uniteObjectInfo != null)
				{
					int i = 0;
					int count = this.loadCbList.Count;
					while (i < count)
					{
						LoadInfo loadInfo = this.loadCbList[i];
						if (loadInfo.loadCb != null)
						{
							UnityEngine.Object @object = XSingleton<XResourceLoaderMgr>.singleton.GetObject(uniteObjectInfo, this.isSharedRes, loadInfo.usePool, objectAsync);
							loadInfo.loadCb(@object, this.location, this.isSharedRes);
						}
						i++;
					}
					this.loadCbList.Clear();
					return;
				}
			}
			else
			{
				XSingleton<XResourceLoaderMgr>.singleton.AddAssetInPool(info.mainObject, this.hash, info);
				int j = 0;
				int count2 = this.loadCbList.Count;
				while (j < count2)
				{
					LoadInfo loadInfo2 = this.loadCbList[j];
					if (loadInfo2.loadCb != null)
					{
						if (this.isSharedRes)
						{
							this.GetSharedResourceCb(loadInfo2.loadCb, info);
						}
						else
						{
							UnityEngine.Object obj = null;
							if (loadInfo2.usePool && XSingleton<XResourceLoaderMgr>.singleton.GetInObjectPool(ref obj, this.hash))
							{
								loadInfo2.loadCb(obj, this.location, this.isSharedRes);
							}
							else
							{
								this.CreateFromPrefabCb(loadInfo2.loadCb, info);
							}
						}
					}
					j++;
				}
				this.loadCbList.Clear();
			}
		}

		private void GetSharedResourceCb(LoadCallBack loadCb, AssetBundleInfo info = null)
		{
			UnityEngine.Object assetInPool = XSingleton<XResourceLoaderMgr>.singleton.GetAssetInPool(this.hash);
			XSingleton<XResourceLoaderMgr>.singleton.AssetsRefRetain(this.hash);
			loadCb(assetInPool, this.location, true);
		}

		private void CreateFromPrefabCb(LoadCallBack loadCb, AssetBundleInfo info = null)
		{
			UnityEngine.Object assetInPool = XSingleton<XResourceLoaderMgr>.singleton.GetAssetInPool(this.hash);
			GameObject gameObject = UnityEngine.Object.Instantiate(assetInPool) as GameObject;
			XSingleton<XResourceLoaderMgr>.singleton.AssetsRefRetain(this.hash);
			XSingleton<XResourceLoaderMgr>.singleton.LogReverseID(gameObject, this.hash);
			loadCb(gameObject, this.location, false);
		}
	}
}
