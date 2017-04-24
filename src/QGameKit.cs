using System;
using System.Collections.Generic;
using UnityEngine;

public class QGameKit
{
	public enum CaptureType
	{
		AudioCapture = 1,
		AudioApolloVoice,
		AudioCustom = 4,
		VideoCapture = 8,
		VideoCustom = 16
	}

	public enum LoginPlatform
	{
		Guest,
		QQ,
		WeChat
	}

	public enum LiveStatus
	{
		Unknown,
		Uninitialized,
		Prepared,
		LiveStarting,
		LiveStarted,
		LivePaused,
		LiveResume,
		LiveStopping,
		LiveStopped,
		Error
	}

	public enum CommentType
	{
		Normal,
		System,
		Anchor,
		RoomManager,
		LiveManager,
		SuperManager,
		Edit,
		Gift,
		Welcome,
		Vip,
		LoginVisitor
	}

	public enum Environment
	{
		Release,
		Debug
	}

	public enum WebViewStatus
	{
		Open,
		Closed,
		SmallWindow,
		FullScreen
	}

	public class UserAccount
	{
		public QGameKit.LoginPlatform platform;

		public string appId;

		public string id;

		public string token;

		public string phoneNum;

		public long expires;
	}

	public class LiveComment
	{
		public QGameKit.CommentType type;

		public string nick;

		public string content;

		public long timestamp;
	}

	public class ShareContent
	{
		public string fopenId;

		public string title;

		public string description;

		public string targetUrl;

		public string imageUrl;
	}

	public delegate QGameKit.UserAccount UserAccountDelegate();

	public delegate void CommentReceiveDelegate(List<QGameKit.LiveComment> comments);

	public delegate void LogDelegate(string log);

	public delegate void LiveStatusChangedDelegate(QGameKit.LiveStatus newState);

	public delegate void ShareDelegate(QGameKit.ShareContent shareContent);

	public delegate void ErrorCodeListenerDelegate(int errorCode, string errorMessage);

	public delegate void WebViewStatusChangedDelegate(QGameKit.WebViewStatus status);

	public static QGameKit.LiveStatus liveStatus = QGameKit.LiveStatus.Uninitialized;

	private static QGameKitAndroidBridge QGameKitObj;

	public static bool Setup(string gameId, string wnsAppId, QGameKit.CaptureType captureType, QGameKit.UserAccountDelegate accountDelegate, QGameKit.Environment env)
	{
		QGameKit.QGameKitObj = QGameKitAndroidBridge.Setup(gameId, wnsAppId, captureType, accountDelegate, env);
		if (null == QGameKit.QGameKitObj)
		{
			Debug.LogError("QGameKitObj init failed!");
			return false;
		}
		QGameKit.UserAccount account = accountDelegate();
		QGameKit.UpdateUserAccount(account);
		QGameKit.liveStatus = QGameKit.LiveStatus.Prepared;
		return true;
	}

	public static void TearDown()
	{
		QGameKit.QGameKitObj.TearDown();
		QGameKit.liveStatus = QGameKit.LiveStatus.Uninitialized;
	}

	public static bool Reset()
	{
		return QGameKit.QGameKitObj.Reset();
	}

	public static void FrameUpdated()
	{
		QGameKit.QGameKitObj.CaptureFrame();
	}

	public static void EnterLiveHall()
	{
		QGameKit.QGameKitObj.EnterLiveHall();
	}

	public static void DisabledLiveHall()
	{
	}

	public static void EnterLiveHallInGame()
	{
		QGameKit.QGameKitObj.EnterLiveHallInGame();
	}

	public static bool StartLiveBroadcast(string title, string description)
	{
		if (QGameKit.QGameKitObj.StartLiveBroadcast(title, description))
		{
			return true;
		}
		Debug.LogError("StartLiveBroadcast failed!");
		return false;
	}

	public static bool StopLiveBroadcast()
	{
		if (QGameKit.QGameKitObj.StopLiveBroadcast())
		{
			return true;
		}
		Debug.LogError("StopLiveBroadcast failed!");
		return false;
	}

	public static void PauseLiveBroadcast()
	{
		Debug.LogError("PauseLiveBroadcast unsupported yet!");
	}

	public static void ResumeLiveBroadcast()
	{
		Debug.LogError("ResumeLiveBroadcast unsupported yet!");
	}

	public static void ShareLiveBroadcast()
	{
		QGameKit.QGameKitObj.ShareLiveBroadcast();
	}

	public static QGameKit.LiveStatus GetLiveBroadcastStatus()
	{
		return QGameKit.QGameKitObj.GetLiveBroadcastStatus();
	}

	public static int GetErrorCode()
	{
		return QGameKit.QGameKitObj.GetErrorCode();
	}

	public static void UpdateUserAccount(QGameKit.UserAccount account)
	{
		QGameKit.QGameKitObj.UpdateUserAccount(account);
	}

	public static void UpdateUserAccount()
	{
		QGameKit.QGameKitObj.UpdateUserAccount();
	}

	public static void SendComment(QGameKit.LiveComment comment)
	{
		Debug.LogError("SendComment unsupported yet!");
	}

	public static void SetCommentReceiveDelegate(QGameKit.CommentReceiveDelegate commentDelegate)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetCommentReceiveDelegete(commentDelegate);
	}

	public static void SetLogDelegate(QGameKit.LogDelegate logDelegate)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetLogDelegate(logDelegate);
	}

	public static void SetShareDelegate(QGameKit.ShareDelegate shareDelegate)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetShareDelegate(shareDelegate);
	}

	public static void SetDanmakuEnabled(bool enabled)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetDanmakuEnabled(enabled);
	}

	public static void ShowDanmaku()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.ShowDanmaku();
	}

	public static void HideDanmaku()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.HideDanmaku();
	}

	public static void SetShareResult(QGameKit.ShareContent content, int result)
	{
	}

	public static void SetLiveStatusDelegate(QGameKit.LiveStatusChangedDelegate liveStatusDelegate)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetLiveStatusChangedDelegate(liveStatusDelegate);
	}

	public static void SetErrorCodeDelegate(QGameKit.ErrorCodeListenerDelegate errorCodeDelegate)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetErrorCodeDelegate(errorCodeDelegate);
	}

	public static void SetWebViewStatusChangedDelegate(QGameKit.WebViewStatusChangedDelegate webviewDelegate)
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.SetWebViewStatusChangedDelegate(webviewDelegate);
	}

	public static bool IsLiveBroadcastSupported()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return false;
		}
		return QGameKit.QGameKitObj.IsLiveBroadcastSupported();
	}

	public static string GetVersionName()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return null;
		}
		return QGameKit.QGameKitObj.GetVersionName();
	}

	public static bool ShowCamera()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return false;
		}
		return QGameKit.QGameKitObj.ShowCamera();
	}

	public static void HideCamera()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.HideCamera();
	}

	public static void DoOnResume()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.DoOnResume();
	}

	public static void DoOnPause()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.DoOnPause();
	}

	public static void DoOnDestroy()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return;
		}
		QGameKit.QGameKitObj.DoOnDestroy();
	}

	public static bool DoOnBackPressed()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return false;
		}
		return QGameKit.QGameKitObj.DoOnBackPressed();
	}

	public static bool IsSupportCamera()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return false;
		}
		return QGameKit.QGameKitObj.IsSupportCamera();
	}

	public static bool IsSupportLiveHall()
	{
		if (QGameKit.QGameKitObj == null)
		{
			Debug.LogError("QGameKitObj is null!");
			return false;
		}
		return QGameKit.QGameKitObj.IsSupportLiveHall();
	}
}
