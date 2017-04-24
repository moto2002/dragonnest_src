using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
	public sealed class XDownloader : MonoBehaviour
	{
		public delegate void HandleBytesDownload(WWW www, string error);

		private StringBuilder _log = new StringBuilder();

		private WWW _downloader;

		private bool _download = true;

		private uint _token;

		private float _total_percent;

		private string _current_name;

		private XTimerMgr.ElapsedEventHandler _progressCb;

		private void Awake()
		{
			this._progressCb = new XTimerMgr.ElapsedEventHandler(this.Progress);
		}

		internal void GetBundle(XBundleData bundle, string url, HandleBundleDownload callback1, HandleFetchBundle callback2, float percent)
		{
			this._download = url.Contains("?token=");
			this._current_name = bundle.Name;
			this._total_percent = percent;
			base.StartCoroutine(this.Download(bundle, url, callback1, callback2));
		}

		public void GetMeta(string url, string name, XDownloader.HandleBytesDownload callback, float percent)
		{
			this._download = true;
			this._current_name = name;
			this._total_percent = percent;
			base.StartCoroutine(this.MetaDownload(url, callback));
		}

		public void GetBytes(string url, XDownloader.HandleBytesDownload callback)
		{
			base.StartCoroutine(this.BytesDownload(url, callback));
		}

		private IEnumerator MetaDownload(string url, XDownloader.HandleBytesDownload callback)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, this._progressCb, null);
			this._downloader = new WWW(url);
			yield return this._downloader;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			this.Progress(null);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			if (callback != null)
			{
				callback(this._downloader, this._downloader.error);
			}
			this._downloader.Dispose();
			this._downloader = null;
			yield break;
		}

		private IEnumerator BytesDownload(string url, XDownloader.HandleBytesDownload callback)
		{
			WWW wWW = new WWW(url);
			yield return wWW;
			if (callback != null)
			{
				callback(wWW, wWW.error);
			}
			wWW.Dispose();
			wWW = null;
			yield break;
		}

		private IEnumerator Download(XBundleData bundle, string url, HandleBundleDownload callback1, HandleFetchBundle callback2)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, this._progressCb, null);
			this._downloader = new WWW(url);
			yield return this._downloader;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			this.Progress(null);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			bool flag = false;
			if (callback1 != null)
			{
				AsyncWriteRequest asyncWriteRequest = callback1(this._downloader, bundle, this._downloader.error);
				while (!asyncWriteRequest.IsDone)
				{
					if (asyncWriteRequest.HasError)
					{
						flag = true;
						break;
					}
					yield return null;
				}
				XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(asyncWriteRequest.Location);
			}
			if (flag)
			{
				this._log.Length = 0;
				this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DOWNLOADRESFAILED"), bundle.Name);
				XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			}
			else if (callback2 != null)
			{
				callback2(this._downloader, this._downloader.bytes, bundle, this._download);
			}
			this._downloader = null;
			yield break;
		}

		private void Progress(object o)
		{
			this._log.Remove(0, this._log.Length);
			int num = Mathf.FloorToInt(this._total_percent * 100f);
			if (this._download)
			{
				this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_DOWNLOADING"), num);
			}
			else
			{
				this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_EXTRACTING"), num);
			}
			XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, this._progressCb, o);
		}
	}
}
