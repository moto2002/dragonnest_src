using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class CacheLoader : AbstractLoader
	{
		public const int PROGRAME_ASSET_RETRY_COUNT = 3;

		public const int ASSET_RETRY_COUNT = 1;

		private HashSet<string> _programAssetUrlSet = new HashSet<string>();

		private Dictionary<string, RemoteConfig.AssetInfo> _programAssetInfoDict = new Dictionary<string, RemoteConfig.AssetInfo>();

		private Dictionary<string, List<RemoteConfig.AssetInfo>> _programAssetInfoListDict = new Dictionary<string, List<RemoteConfig.AssetInfo>>();

		private Coroutine _progressCoroutine;

		private Queue<string> _failedGroupQueue = new Queue<string>();

		private Queue<string> _succeededGroupQueue = new Queue<string>();

		private Dictionary<string, string> _progressMessage = new Dictionary<string, string>();

		public Action<Dictionary<string, string>> programAssetProgressCallback;

		public override void Initialize()
		{
			this._concurrentCount = 1;
			base.Initialize();
		}

		public void LoadProgramAssetList(string group, List<RemoteConfig.AssetInfo> assetInfoList, Action<List<string>> callback)
		{
			if (this._programAssetInfoListDict.ContainsKey(group))
			{
				string message = "有尚未处理完的加载";
				Logger.LogError(message);
				return;
			}
			this._programAssetInfoListDict.Add(group, assetInfoList);
			List<string> list = new List<string>();
			for (int i = 0; i < assetInfoList.Count; i++)
			{
				string url = assetInfoList[i].url;
				this._programAssetUrlSet.Add(url);
				if (this._programAssetInfoDict.ContainsKey(url))
				{
					this._programAssetInfoDict.Remove(url);
				}
				this._programAssetInfoDict.Add(url, assetInfoList[i]);
				list.Add(url);
			}
			base.LoadAssetList(list, callback, 3);
			this.InvokeLoadStart(group);
			this.StartInspectLoading();
		}

		private void StartInspectLoading()
		{
			if (this._progressCoroutine == null)
			{
				this._progressCoroutine = base.StartCoroutine(this.InspectProgramAssetProgress());
			}
		}

		[DebuggerHidden]
		private IEnumerator InspectProgramAssetProgress()
		{
			CacheLoader.<InspectProgramAssetProgress>c__IteratorA <InspectProgramAssetProgress>c__IteratorA = new CacheLoader.<InspectProgramAssetProgress>c__IteratorA();
			<InspectProgramAssetProgress>c__IteratorA.<>f__this = this;
			return <InspectProgramAssetProgress>c__IteratorA;
		}

		private void InvokeLoadStart(string group)
		{
			if (this.programAssetProgressCallback != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("type", "assetLoadStart");
				dictionary.Add("name", group);
				this.programAssetProgressCallback(dictionary);
			}
		}

		private void InvokeLoadError(string group)
		{
			if (this.programAssetProgressCallback != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("type", "assetLoadError");
				dictionary.Add("name", group);
				this.programAssetProgressCallback(dictionary);
			}
		}

		private void InvokeLoadComplete(string group)
		{
			if (this.programAssetProgressCallback != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("type", "assetLoadComplete");
				dictionary.Add("name", group);
				this.programAssetProgressCallback(dictionary);
			}
		}

		private void InvokeLoadProgress(string group, int progress)
		{
			if (this.programAssetProgressCallback != null)
			{
				if (!this._progressMessage.ContainsKey("type"))
				{
					this._progressMessage.Add("type", "assetLoadProgress");
				}
				if (!this._progressMessage.ContainsKey("name"))
				{
					this._progressMessage.Add("name", group);
				}
				if (!this._progressMessage.ContainsKey("progress"))
				{
					this._progressMessage.Add("progress", "0");
				}
				this._progressMessage["name"] = group;
				this._progressMessage["progress"] = progress.ToString();
				this.programAssetProgressCallback(this._progressMessage);
			}
		}

		public void LoadAsset(string url, Action<string> callback)
		{
			base.LoadAsset(url, callback, 1);
		}

		protected override bool HandleLoadedContent(string url, WWW www)
		{
			if (Pandora.Instance.IsDebug)
			{
				Logger.Log("<color=#0000ff>资源从远端下载到本地成功</color>，url: " + url);
			}
			string path = string.Empty;
			if (!this._programAssetUrlSet.Contains(url))
			{
				path = CacheManager.GetCachedAssetPath(url);
				try
				{
					File.WriteAllBytes(path, www.bytes);
				}
				catch (Exception ex)
				{
					string text = "创建本地文件失败： " + url + " " + ex.Message;
					Pandora.Instance.ReportError(text, 10217584);
					Logger.LogError(text);
				}
				www.Dispose();
				www = null;
				return true;
			}
			path = CacheManager.GetCachedProgramAssetPath(url);
			string fileMd = CachedFileMd5Helper.GetFileMd5(www.bytes);
			RemoteConfig.AssetInfo assetInfo = this._programAssetInfoDict[url];
			if (!PandoraSettings.UseStreamingAssets && assetInfo != null && assetInfo.md5 != fileMd)
			{
				www.Dispose();
				www = null;
				string text2 = "下载到资源计算的Md5值和配置中的Md5值不相等, url: " + url;
				Pandora.Instance.ReportError(text2, 10217583);
				Logger.LogError(text2);
				return false;
			}
			try
			{
				File.WriteAllBytes(path, www.bytes);
			}
			catch (Exception ex2)
			{
				string text3 = "创建本地文件失败： " + url + " " + ex2.Message;
				Pandora.Instance.ReportError(text3, 10217584);
				Logger.LogError(text3);
			}
			www.Dispose();
			www = null;
			return true;
		}

		protected override void HandleError(string url)
		{
			string text = "将资源加载到本地失败，且超过最大重试次数, url: " + url;
			Logger.LogError(text);
			Pandora.Instance.ReportError(text, 10217590);
		}

		public override void Clear()
		{
			this._programAssetUrlSet.Clear();
			this._programAssetInfoDict.Clear();
			this._programAssetInfoListDict.Clear();
			if (this._progressCoroutine != null)
			{
				base.StopCoroutine(this._progressCoroutine);
				this._progressCoroutine = null;
			}
			base.Clear();
		}
	}
}
