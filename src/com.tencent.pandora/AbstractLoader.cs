using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace com.tencent.pandora
{
	internal abstract class AbstractLoader : MonoBehaviour
	{
		internal abstract class Task
		{
			protected AbstractLoader _loader;

			protected bool _isSuccessful = true;

			public abstract bool IsFinished();

			public abstract void ExecuteLoadedCallback();
		}

		internal class BatchTask : AbstractLoader.Task
		{
			private List<string> _urlList;

			private Action<List<string>> _callback;

			public BatchTask(List<string> urlList, Action<List<string>> callback, AbstractLoader loadedr)
			{
				this._urlList = urlList;
				this._callback = callback;
				this._loader = loadedr;
			}

			public override bool IsFinished()
			{
				bool result = true;
				for (int i = 0; i < this._urlList.Count; i++)
				{
					string url = this._urlList[i];
					if (!this._loader.IsLoaded(url) && !this._loader.IsFailed(url))
					{
						result = false;
						break;
					}
				}
				return result;
			}

			public override void ExecuteLoadedCallback()
			{
				for (int i = 0; i < this._urlList.Count; i++)
				{
					if (this._loader.IsFailed(this._urlList[i]))
					{
						this._isSuccessful = false;
						break;
					}
				}
				if (this._callback != null && this._isSuccessful)
				{
					this._callback(this._urlList);
					this._callback = null;
				}
			}
		}

		internal class SingleTask : AbstractLoader.Task
		{
			private string _url;

			private Action<string> _callback;

			public SingleTask(string url, Action<string> callback, AbstractLoader loader)
			{
				this._url = url;
				this._callback = callback;
				this._loader = loader;
			}

			public override bool IsFinished()
			{
				return this._loader.IsLoaded(this._url) || this._loader.IsFailed(this._url);
			}

			public override void ExecuteLoadedCallback()
			{
				this._isSuccessful = !this._loader.IsFailed(this._url);
				if (this._callback != null && this._isSuccessful)
				{
					this._callback(this._url);
					this._callback = null;
				}
			}
		}

		protected Queue<string> _errorQueue;

		protected int _errorRetryMaxSpan = 120;

		protected int _errorRetrySpan;

		protected Dictionary<string, int> _errorRetryCountDict;

		protected Dictionary<string, int> _errorMaxRetryCountDict;

		protected int _concurrentCount = 1;

		protected Queue<string> _toLoadQueue;

		protected Dictionary<string, WWW> _loadingDict;

		protected HashSet<string> _loadedSet;

		protected HashSet<string> _failedSet;

		protected List<AbstractLoader.Task> _taskList;

		public bool PauseDownloading
		{
			get;
			set;
		}

		public virtual void Initialize()
		{
			this._toLoadQueue = new Queue<string>();
			this._loadingDict = new Dictionary<string, WWW>();
			this._loadedSet = new HashSet<string>();
			this._failedSet = new HashSet<string>();
			this._taskList = new List<AbstractLoader.Task>();
			this._errorQueue = new Queue<string>();
			this._errorRetryCountDict = new Dictionary<string, int>();
			this._errorMaxRetryCountDict = new Dictionary<string, int>();
			for (int i = 0; i < this._concurrentCount; i++)
			{
				base.StartCoroutine(this.DaemonLoad());
			}
			base.StartCoroutine(this.DaemonHandleTaskLoaded());
			base.StartCoroutine(this.DaemonHandleError());
		}

		[DebuggerHidden]
		private IEnumerator DaemonLoad()
		{
			AbstractLoader.<DaemonLoad>c__Iterator6 <DaemonLoad>c__Iterator = new AbstractLoader.<DaemonLoad>c__Iterator6();
			<DaemonLoad>c__Iterator.<>f__this = this;
			return <DaemonLoad>c__Iterator;
		}

		public string ReplaceHttpToken(string url)
		{
			return url.Replace("http://", "https://");
		}

		public string GetRandomSeedUrl(string url)
		{
			return this.GetOriginalUrl(url) + "?seed=" + UnityEngine.Random.Range(0, 10000).ToString();
		}

		public string GetOriginalUrl(string url)
		{
			if (!url.Contains("?"))
			{
				return url;
			}
			int length = url.IndexOf("?");
			return url.Substring(0, length);
		}

		[DebuggerHidden]
		private IEnumerator DaemonHandleTaskLoaded()
		{
			AbstractLoader.<DaemonHandleTaskLoaded>c__Iterator7 <DaemonHandleTaskLoaded>c__Iterator = new AbstractLoader.<DaemonHandleTaskLoaded>c__Iterator7();
			<DaemonHandleTaskLoaded>c__Iterator.<>f__this = this;
			return <DaemonHandleTaskLoaded>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator DaemonHandleError()
		{
			AbstractLoader.<DaemonHandleError>c__Iterator8 <DaemonHandleError>c__Iterator = new AbstractLoader.<DaemonHandleError>c__Iterator8();
			<DaemonHandleError>c__Iterator.<>f__this = this;
			return <DaemonHandleError>c__Iterator;
		}

		protected abstract bool HandleLoadedContent(string url, WWW www);

		protected abstract void HandleError(string url);

		public bool IsLoaded(string url)
		{
			return this._loadedSet.Contains(this.GetOriginalUrl(url));
		}

		public bool IsFailed(string url)
		{
			return this._failedSet.Contains(this.GetOriginalUrl(url));
		}

		public bool RemoveFormLoadedSet(string url)
		{
			return this._loadedSet.Remove(this.GetOriginalUrl(url));
		}

		public virtual void LoadAsset(string url, Action<string> callback, int maxRetryCount)
		{
			this.AddAsset(url, maxRetryCount);
			AbstractLoader.SingleTask item = new AbstractLoader.SingleTask(url, callback, this);
			this._taskList.Insert(0, item);
		}

		public virtual void LoadAssetList(List<string> urlList, Action<List<string>> callback, int maxRetryCount)
		{
			for (int i = 0; i < urlList.Count; i++)
			{
				this.AddAsset(urlList[i], maxRetryCount);
			}
			AbstractLoader.BatchTask item = new AbstractLoader.BatchTask(urlList, callback, this);
			this._taskList.Insert(0, item);
		}

		private void AddAsset(string url, int maxRetryCount)
		{
			if (this._loadingDict.ContainsKey(this.GetOriginalUrl(url)) || this._loadedSet.Contains(this.GetOriginalUrl(url)) || this._toLoadQueue.Contains(url))
			{
				return;
			}
			this._failedSet.Remove(url);
			this._toLoadQueue.Enqueue(url);
			this._errorRetryCountDict[this.GetOriginalUrl(url)] = 1;
			this._errorMaxRetryCountDict[this.GetOriginalUrl(url)] = maxRetryCount;
		}

		public virtual void Clear()
		{
			this._toLoadQueue.Clear();
			this._loadingDict.Clear();
			this._loadedSet.Clear();
			this._failedSet.Clear();
			this._taskList.Clear();
			this._errorQueue.Clear();
			this._errorRetryCountDict.Clear();
			this._errorMaxRetryCountDict.Clear();
		}
	}
}
