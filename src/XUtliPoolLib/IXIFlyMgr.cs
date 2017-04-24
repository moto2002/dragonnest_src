using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXIFlyMgr : IXInterface
	{
		int StartRecord();

		void StopRecord();

		void Cancel();

		string StartTransMp3(string destFileName);

		AudioClip GetAudioClip(string filepath);

		void SetCallback(Action<string> action);

		void SetVoiceCallback(Action<string> action);

		bool IsIFlyListening();

		bool IsRecordFileExist();

		bool IsInited();

		bool ScreenShotQQShare(string filepath, string type);

		bool ScreenShotWeChatShare(string filepath, string type);

		bool ScreenShotSave(string filepath);

		bool RefreshAndroidPhotoView(string androidpath);

		bool ShareWechatLink(string desc, string logopath, string url, bool issession);

		bool ShareQZoneLink(string title, string summary, string url, string logopath, bool issession);

		bool OnOpenWebView();

		void OnInitWebViewInfo(int platform, string openid, string serverid, string roleid, string nickname);

		void OnEvalJsScript(string script);

		void OnCloseWebView();

		void OnScreenLock(bool islock);

		void RefershWebViewShow(bool show);

		MonoBehaviour GetMonoBehavior();
	}
}
