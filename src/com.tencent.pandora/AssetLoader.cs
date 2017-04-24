using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class AssetLoader : AbstractLoader
	{
		private int _deleteMaxSpan = 1800;

		private int _deleteSpan;

		private Dictionary<string, AssetConfig> _assetConfigDict = new Dictionary<string, AssetConfig>();

		public override void Initialize()
		{
			this._concurrentCount = 8;
			base.Initialize();
			this._deleteMaxSpan = 60 * Application.targetFrameRate;
			base.StartCoroutine(this.DaemonDeleteZeroReferenceAsset());
		}

		public void LoadLuaAssetList(List<string> urlList, Action<List<string>> callback)
		{
			for (int i = 0; i < urlList.Count; i++)
			{
				AssetConfig value = new AssetConfig(AssetType.Lua, true);
				this._assetConfigDict[urlList[i]] = value;
			}
			base.LoadAssetList(urlList, callback, 0);
		}

		public void LoadAsset(string url, AssetConfig config, Action<string> callback)
		{
			this._assetConfigDict[url] = config;
			base.LoadAsset(url, callback, 0);
		}

		protected override bool HandleLoadedContent(string url, WWW www)
		{
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log("<color=#00ff00>资源从本地加载到内存成功</color>, url: " + url);
			}
			AssetPool.AddWww(url, www);
			return AssetPool.ParseAsset(url, this._assetConfigDict[url]);
		}

		protected override void HandleError(string url)
		{
			Logger.LogError("将资源加载到内存失败，且超过最大重试次数, url: " + url);
		}

		[DebuggerHidden]
		private IEnumerator DaemonDeleteZeroReferenceAsset()
		{
			AssetLoader.<DaemonDeleteZeroReferenceAsset>c__Iterator9 <DaemonDeleteZeroReferenceAsset>c__Iterator = new AssetLoader.<DaemonDeleteZeroReferenceAsset>c__Iterator9();
			<DaemonDeleteZeroReferenceAsset>c__Iterator.<>f__this = this;
			return <DaemonDeleteZeroReferenceAsset>c__Iterator;
		}
	}
}
