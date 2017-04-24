using System;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
	internal sealed class XVersion : MonoBehaviour
	{
		private delegate void HandleFinishDownload(WWW www, string error);

		public static readonly string LOCAL_VERSION_FILE = "manifest.asset";

		private WWW _server_Version;

		private uint _time_out_token;

		public static string VERSION_FILE
		{
			get
			{
				return string.Format("manifest.{0}.assetbundle", XSingleton<XUpdater>.singleton.TargetVersion.ToString());
			}
		}

		public static string GetLocalVersion()
		{
			return XSingleton<XCaching>.singleton.UpdatePath + XVersion.LOCAL_VERSION_FILE;
		}

		public void ServerDownload(HandleVersionDownload callback1, HandleVersionLoaded callback2)
		{
			XSingleton<XUpdater>.singleton.XApolloManager.SetGSDKEvent(0, true, "success");
			base.StopAllCoroutines();
			string text = XSingleton<XCaching>.singleton.HostUrl + XSingleton<XUpdater>.singleton.Platform;
			XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_CONNECTING"), 255, 255, 255);
			XSingleton<XDebug>.singleton.AddLog("connecting to update server: ", text, null, null, null, null, XDebugColor.XDebug_None);
			this._time_out_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.OnTimeOut), null);
			base.StartCoroutine(this.DownloadVersion(XSingleton<XCaching>.singleton.MakeToken(text + XVersion.VERSION_FILE), callback1, callback2));
		}

		private IEnumerator DownloadVersion(string url, HandleVersionDownload callback1, HandleVersionLoaded callback2)
		{
			this._server_Version = new WWW(url);
			yield return this._server_Version;
			XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_CHECKUPDATING"), 255, 255, 255);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._time_out_token);
			if (this._server_Version != null)
			{
				if (string.IsNullOrEmpty(this._server_Version.error))
				{
					if (callback1 != null)
					{
						AssetBundle assetBundle = this._server_Version.assetBundle;
						if (assetBundle == null)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("load server manifest bundle error.", null, null, null, null, null);
							XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"), 255, 255, 255);
							XSingleton<XUpdater>.singleton.OnError();
						}
						else
						{
							UnityEngine.Object @object = assetBundle.Load("manifest", typeof(TextAsset));
							if (@object == null)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("load server manifest bundle error.", null, null, null, null, null);
								XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"), 255, 255, 255);
								XSingleton<XUpdater>.singleton.OnError();
							}
							else
							{
								AsyncVersionProcessRequest asyncVersionProcessRequest = callback1(@object as TextAsset);
								while (!asyncVersionProcessRequest.IsDone)
								{
									Thread.Sleep(1);
								}
								if (callback2 != null)
								{
									callback2(asyncVersionProcessRequest.IsCorrect);
								}
								assetBundle.Unload(false);
							}
						}
					}
				}
				else if (XUpdater.LaunchMode == XLaunchMode.Dev)
				{
					XSingleton<XUpdater>.singleton.DevStart();
					XSingleton<XUpdater>.singleton.XApolloManager.SetGSDKEvent(1, true, "0");
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog(this._server_Version.error, null, null, null, null, null);
					XSingleton<XUpdater>.singleton.XApolloManager.SetGSDKEvent(1, false, XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"));
					XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"), 255, 255, 255);
					XSingleton<XUpdater>.singleton.OnError();
				}
				this._server_Version.Dispose();
				this._server_Version = null;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("ERROR: _server_Version is NULL!", null, null, null, null, null);
				XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"), 255, 255, 255);
				XSingleton<XUpdater>.singleton.OnError();
			}
			yield break;
		}

		private IEnumerator LocalDownload(XVersion.HandleFinishDownload callback)
		{
			string text = Application.persistentDataPath + XVersion.VERSION_FILE;
			if (!File.Exists(text))
			{
				if (callback != null)
				{
					callback(null, null);
				}
			}
			else
			{
				string url = "file://" + text;
				WWW wWW = new WWW(url);
				yield return wWW;
				if (callback != null)
				{
					callback(wWW, wWW.error);
				}
				wWW.Dispose();
				wWW = null;
			}
			yield break;
		}

		private void OnTimeOut(object o)
		{
			if (XUpdater.LaunchMode == XLaunchMode.Dev)
			{
				XSingleton<XUpdater>.singleton.DevStart();
				if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Connect to update server timeout...", null, null, null, null, null);
				}
			}
			else
			{
				XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_CANNOTCONNECTTOSERVER"), 255, 255, 255);
				XSingleton<XUpdater>.singleton.OnError();
			}
			base.StopAllCoroutines();
			this._server_Version.Dispose();
			this._server_Version = null;
		}
	}
}
