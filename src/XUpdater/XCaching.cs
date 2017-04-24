using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
	public sealed class XCaching : XSingleton<XCaching>
	{
		private string _version_server;

		private string _host_url;

		internal static readonly string UPDATE_DIRECTORY = "/update/";

		private string _update_path;

		private StringBuilder _log = new StringBuilder();

		private XDownloader _down_loader;

		private MD5CryptoServiceProvider _md5Generator;

		private AsyncExtractRequest _aer;

		private AsyncWriteRequest _meta_awr;

		public string VersionServer
		{
			get
			{
				return this._version_server;
			}
		}

		public string HostUrl
		{
			get
			{
				return this._host_url;
			}
		}

		public string UpdatePath
		{
			get
			{
				return this._update_path;
			}
		}

		public XDownloader Downloader
		{
			get
			{
				return this._down_loader;
			}
		}

		internal string GetLocalPath(XBundleData data)
		{
			return string.Format("{0}{1}.assetbundle", this._update_path, data.Name);
		}

		internal string GetLocalUrl(XBundleData data)
		{
			string arg;
			if (XSingleton<XUpdater>.singleton.RunTimePlatform == BuildTarget.Standalone)
			{
				arg = "file:///";
			}
			else
			{
				arg = "file://";
			}
			string text = string.Format("{0}{1}{2}.assetbundle", arg, this._update_path, data.Name);
			XSingleton<XDebug>.singleton.AddLog("LocalURL: ", text, null, null, null, null, XDebugColor.XDebug_None);
			return text;
		}

		public string GetLoginServerAddress(string loginType)
		{
			IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
			return xPlatform.GetHostWithHttpDns(xPlatform.GetLoginServer(loginType));
		}

		internal string GetDownloadUrl(XBundleData data)
		{
			return this.MakeToken(string.Format("{0}{1}/{2}.assetbundle", this.HostUrl, XSingleton<XUpdater>.singleton.Platform, data.Name));
		}

		internal string MakeToken(string url)
		{
			return string.Format("{0}?token={1}", url, DateTime.Now.Ticks);
		}

		public override bool Init()
		{
			IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
			this._version_server = xPlatform.GetHostWithHttpDns(xPlatform.GetVersionServer());
			this._host_url = xPlatform.GetHostUrl();
			this._md5Generator = new MD5CryptoServiceProvider();
			this._down_loader = XUpdater.XGameRoot.AddComponent<XDownloader>();
			this._update_path = Application.persistentDataPath + XCaching.UPDATE_DIRECTORY;
			return true;
		}

		internal bool EnableCache()
		{
			if (!Directory.Exists(this._update_path))
			{
				XSingleton<XDebug>.singleton.AddLog("Create new path " + this._update_path, null, null, null, null, null, XDebugColor.XDebug_None);
				try
				{
					Directory.CreateDirectory(this._update_path);
					bool result = Directory.Exists(this._update_path);
					return result;
				}
				catch (Exception ex)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Error ", ex.Message), null, null, null, null, null);
					bool result = false;
					return result;
				}
			}
			XSingleton<XDebug>.singleton.AddLog(string.Format("Path {0} exists.", this._update_path), null, null, null, null, null, XDebugColor.XDebug_None);
			return true;
		}

		internal AsyncCachedRequest IsBundleCached(XBundleData bundle, uint size)
		{
			string fullpath = this.GetLocalPath(bundle);
			AsyncCachedRequest req = new AsyncCachedRequest();
			if (bundle.Size < size)
			{
				new Thread(delegate
				{
					if (File.Exists(fullpath))
					{
						byte[] bundle2 = this.LoadFile(fullpath);
						string a = this.CalculateMD5(bundle2);
						req.Cached = (a == bundle.MD5);
						req.MaybeCached = true;
					}
					req.IsDone = true;
				}).Start();
			}
			else
			{
				req.MaybeCached = File.Exists(fullpath);
				req.IsDone = true;
			}
			return req;
		}

		internal bool CleanCache()
		{
			string path = (Application.platform == RuntimePlatform.IPhonePlayer) ? ("/private" + this._update_path) : this._update_path;
			bool result;
			try
			{
				if (Directory.Exists(path))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path);
					directoryInfo.Delete(true);
					bool flag = !Directory.Exists(path);
					if (flag)
					{
						result = this.EnableCache();
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("CleanCache error: ", ex.Message, null, null, null, null);
				result = false;
			}
			return result;
		}

		internal byte[] LoadFile(string fullpath)
		{
			return File.ReadAllBytes(fullpath);
		}

		private AsyncReadRequest LoadFileAsync(string fullpath)
		{
			AsyncReadRequest arr = new AsyncReadRequest();
			new Thread(delegate
			{
				arr.bytes = File.ReadAllBytes(fullpath);
				arr.IsDone = true;
			}).Start();
			return arr;
		}

		internal void Download(XBundleData bundle, HandleFetchBundle callback, float percent)
		{
			this._down_loader.GetBundle(bundle, this.GetDownloadUrl(bundle), new HandleBundleDownload(this.OnBundleDownload), callback, percent);
		}

		internal AsyncWriteRequest Download(string meta, uint size, float percent)
		{
			this._meta_awr = new AsyncWriteRequest();
			this._meta_awr.Size = size;
			this._meta_awr.Location = meta;
			this._meta_awr.Name = meta.Substring(meta.LastIndexOf('/') + 1);
			this._meta_awr.HasError = false;
			string name = meta.Substring(meta.LastIndexOf("/") + 1);
			meta = this.MakeToken(this.HostUrl + XSingleton<XUpdater>.singleton.Platform + meta);
			this._down_loader.GetMeta(meta, name, new XDownloader.HandleBytesDownload(this.OnMetaDownload), percent);
			return this._meta_awr;
		}

		internal bool Extract(XBundleData bundle, HandleFetchBundle callback, float percent)
		{
			if (Application.platform != RuntimePlatform.IPhonePlayer)
			{
				this._down_loader.GetBundle(bundle, this.GetLocalUrl(bundle), null, callback, percent);
				return true;
			}
			if (this._aer == null)
			{
				this._aer = new AsyncExtractRequest();
				new Thread(delegate
				{
					string localPath = this.GetLocalPath(bundle);
					this._aer.Data = File.ReadAllBytes(localPath);
					this._aer.IsDone = true;
				}).Start();
			}
			if (this._aer.IsDone)
			{
				callback(null, this._aer.Data, bundle, false);
				this._aer.Data = null;
				this._aer = null;
				return true;
			}
			return false;
		}

		private void OnMetaDownload(WWW www, string error)
		{
			if (string.IsNullOrEmpty(error))
			{
				byte[] bs = www.bytes;
				new Thread(delegate
				{
					try
					{
						if (XSingleton<XUpdater>.singleton.NeedCheckFile && Path.GetExtension(this._meta_awr.Location).Contains("ab") && (bs[0] != 85 || bs[1] != 110 || bs[2] != 105 || bs[3] != 116 || bs[4] != 121 || bs[5] != 82 || bs[6] != 97 || bs[7] != 119))
						{
							throw new Exception("Meta head check failed.");
						}
						string text = Path.Combine(this._update_path, "AssetBundles");
						string fileName = Path.GetFileName(this._meta_awr.Location);
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						string text2 = Path.Combine(text, fileName);
						File.WriteAllBytes(text2, bs);
						if (XSingleton<XUpdater>.singleton.NeedCheckFile)
						{
							Thread.Sleep(1);
							if (!this.CheckFileSize(text2, (long)((ulong)this._meta_awr.Size)))
							{
								throw new Exception("Meta File size " + this._meta_awr.Size + " not match.");
							}
							XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(text2);
							this._meta_awr.IsDone = true;
						}
						else
						{
							XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(text2);
							this._meta_awr.IsDone = true;
						}
					}
					catch (Exception ex)
					{
						this.OnDownloadFailed(ex.Message, this._meta_awr);
					}
				}).Start();
				return;
			}
			this.OnDownloadFailed(error, this._meta_awr);
		}

		private void OnDownloadFailed(string error, AsyncWriteRequest awr)
		{
			XSingleton<XDebug>.singleton.AddErrorLog("Download Meta ", awr.Name, " error: ", error, null, null);
			awr.HasError = true;
		}

		private AsyncWriteRequest OnBundleDownload(WWW www, XBundleData bundle, string error)
		{
			AsyncWriteRequest req = new AsyncWriteRequest();
			if (string.IsNullOrEmpty(error))
			{
				byte[] bs = www.bytes;
				new Thread(delegate
				{
					req.Location = this.GetLocalPath(bundle);
					try
					{
						File.WriteAllBytes(req.Location, bs);
						req.IsDone = true;
					}
					catch (Exception ex)
					{
						this.OnDownloadFailed(ex.Message, req);
					}
				}).Start();
			}
			else
			{
				this.OnDownloadFailed(error, req);
			}
			return req;
		}

		internal string CalculateMD5(byte[] bundle)
		{
			byte[] value = this._md5Generator.ComputeHash(bundle);
			return BitConverter.ToString(value);
		}

		internal string CalculateMD5(byte[] bundle, int offset, int count)
		{
			byte[] value = this._md5Generator.ComputeHash(bundle, offset, count);
			return BitConverter.ToString(value);
		}

		public bool CheckFileSize(string filePath, long fileSize)
		{
			bool result;
			try
			{
				if (!File.Exists(filePath))
				{
					result = false;
				}
				else
				{
					FileInfo fileInfo = new FileInfo(filePath);
					result = (fileSize == fileInfo.Length);
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XCaching.CheckFileSize: " + ex.Message, null, null, null, null, null);
				result = false;
			}
			return result;
		}

		public override void Uninit()
		{
		}
	}
}
