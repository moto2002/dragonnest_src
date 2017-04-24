using MiniJSON;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

public class BroadcastManager : MonoBehaviour, IBroardcast
{
	private static string m_token = string.Empty;

	private static string m_openId = string.Empty;

	private static string m_appid = string.Empty;

	private static QGameKit.LoginPlatform m_platf = QGameKit.LoginPlatform.QQ;

	private static GameObject m_gameobject;

	private static QGameKit.ShareContent m_shareContent;

	private bool isConfigOpen = true;

	private static bool enableDanku;

	private static IUiUtility m_uiUtility;

	public void ToStart()
	{
		QGameKit.CaptureType captureType = (QGameKit.CaptureType)10;
		QGameKit.Setup("1105309683", "203090", captureType, new QGameKit.UserAccountDelegate(BroadcastManager.UserAccountDelegate), QGameKit.Environment.Release);
		if (!BroadcastManager.enableDanku)
		{
			QGameKit.SetDanmakuEnabled(true);
			BroadcastManager.enableDanku = true;
		}
		QGameKit.SetLogDelegate(new QGameKit.LogDelegate(BroadcastManager.LogDelegate));
		QGameKit.SetCommentReceiveDelegate(new QGameKit.CommentReceiveDelegate(BroadcastManager.CommentReceiveDelegate));
		QGameKit.SetLiveStatusDelegate(new QGameKit.LiveStatusChangedDelegate(BroadcastManager.LiveStatusChangedDelegate));
		QGameKit.SetShareDelegate(new QGameKit.ShareDelegate(BroadcastManager.ShareDelegate));
		QGameKit.SetErrorCodeDelegate(new QGameKit.ErrorCodeListenerDelegate(BroadcastManager.ErrorCodeListenerDelegate));
	}

	private void OnDestroy()
	{
		this.TearDown();
	}

	private void Update()
	{
		if (BroadcastManager.m_gameobject != null && BroadcastManager.m_shareContent != null)
		{
			this.DoSahre();
			BroadcastManager.m_shareContent = null;
		}
	}

	public static QGameKit.UserAccount UserAccountDelegate()
	{
		return new QGameKit.UserAccount
		{
			platform = BroadcastManager.m_platf,
			appId = BroadcastManager.m_appid,
			id = BroadcastManager.m_openId,
			token = BroadcastManager.m_token
		};
	}

	public bool IsBroadState()
	{
		return true && this.isConfigOpen;
	}

	public bool ShowCamera(bool show)
	{
		Debug.Log("showcamera:" + show);
		if (!QGameKit.IsSupportCamera() || !this.isConfigOpen)
		{
			Hotfix.LuaShowSystemTip("系统版本太低，不支持开启摄像头");
			return false;
		}
		if (show)
		{
			return QGameKit.ShowCamera();
		}
		QGameKit.HideCamera();
		return true;
	}

	public void SetAccount(int platf, string openid, string token)
	{
		BroadcastManager.m_gameobject = base.gameObject;
		int @int = PlayerPrefs.GetInt("BroadcastOpen");
		this.isConfigOpen = (@int == 1);
		if (this.isConfigOpen)
		{
			BroadcastManager.m_openId = openid;
			BroadcastManager.m_token = token;
			if (platf == 3)
			{
				BroadcastManager.m_platf = QGameKit.LoginPlatform.QQ;
				BroadcastManager.m_appid = "1105309683";
			}
			else if (platf == 4)
			{
				BroadcastManager.m_platf = QGameKit.LoginPlatform.WeChat;
				BroadcastManager.m_appid = "wxfdab5af74990787a";
			}
			else
			{
				BroadcastManager.m_platf = QGameKit.LoginPlatform.Guest;
				BroadcastManager.m_appid = "1105309683";
			}
			this.ToStart();
		}
	}

	public void TearDown()
	{
		if (this.isConfigOpen && !string.IsNullOrEmpty(BroadcastManager.m_openId))
		{
			Debug.Log("tear down!");
			QGameKit.TearDown();
		}
	}

	public void StartLiveBroadcast(string title, string desc)
	{
		if (this.isConfigOpen)
		{
			Debug.Log("Start live broadcast");
			QGameKit.LiveStatus errorCode = (QGameKit.LiveStatus)QGameKit.GetErrorCode();
			if (errorCode == QGameKit.LiveStatus.Error)
			{
				QGameKit.Reset();
			}
			QGameKit.StartLiveBroadcast(title, desc);
		}
	}

	public void StopBroadcast()
	{
		if (this.isConfigOpen)
		{
			Debug.Log("stop live broadcast!");
			QGameKit.StopLiveBroadcast();
		}
	}

	public int GetState()
	{
		if (this.isConfigOpen)
		{
			QGameKit.LiveStatus errorCode = (QGameKit.LiveStatus)QGameKit.GetErrorCode();
			Debug.Log("GetState " + errorCode);
			return (int)errorCode;
		}
		return 0;
	}

	public void EnterHall()
	{
		if (this.isConfigOpen)
		{
			Debug.Log("Hall");
			QGameKit.EnterLiveHall();
		}
	}

	public static void LiveStatusChangedDelegate(QGameKit.LiveStatus newState)
	{
		if (BroadcastManager.m_uiUtility == null || BroadcastManager.m_uiUtility.Deprecated)
		{
			BroadcastManager.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (newState == QGameKit.LiveStatus.LiveStarting || newState == QGameKit.LiveStatus.LiveStarted)
		{
			BroadcastManager.m_uiUtility.StartBroadcast(true);
			ApolloManager.sington.Capture(true);
		}
		else if (newState == QGameKit.LiveStatus.LiveStopping || newState == QGameKit.LiveStatus.LiveStopped)
		{
			BroadcastManager.m_uiUtility.StartBroadcast(false);
			ApolloManager.sington.Capture(false);
		}
	}

	public static void ErrorCodeListenerDelegate(int errorCode, string errorMessage)
	{
	}

	public static void LogDelegate(string log)
	{
		Debug.Log(log);
	}

	public static void CommentReceiveDelegate(List<QGameKit.LiveComment> comments)
	{
	}

	public static string UTF8String(string input)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		return uTF8Encoding.GetString(uTF8Encoding.GetBytes(input));
	}

	public static void ShareDelegate(QGameKit.ShareContent shareContent)
	{
		BroadcastManager.m_shareContent = shareContent;
	}

	private void DoSahre()
	{
		XPlatform component = BroadcastManager.m_gameobject.GetComponent<XPlatform>();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["scene"] = "Session";
		dictionary["targetUrl"] = BroadcastManager.m_shareContent.targetUrl;
		dictionary["imageUrl"] = BroadcastManager.m_shareContent.imageUrl;
		dictionary["title"] = BroadcastManager.m_shareContent.title;
		dictionary["description"] = BroadcastManager.m_shareContent.description;
		dictionary["summary"] = string.Empty;
		string json = Json.Serialize(dictionary);
		component.SendGameExData("share_send_to_struct_qq", json);
	}
}
