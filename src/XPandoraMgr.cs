using com.tencent.pandora;
using com.tencent.pandora.MiniJSON;
using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

public class XPandoraMgr : MonoBehaviour, IXInterface, IXPandoraMgr
{
	private bool isInited;

	private bool isSharing;

	private List<ActivityPopInfo> listActivityPopInfo = new List<ActivityPopInfo>();

	private List<ActivityTabInfo> listActivityTabInfo = new List<ActivityTabInfo>();

	public Font font;

	public bool Deprecated
	{
		get;
		set;
	}

	public void Init()
	{
		if (this.isInited)
		{
			return;
		}
		this.isInited = true;
		this.listActivityPopInfo.Clear();
		this.listActivityTabInfo.Clear();
		Pandora.Instance.SetFont(this.font);
		Pandora.Instance.SetPlaySoundDelegate(new Action<string>(NGUITools.PlayFmod));
		bool isProductEnvironment = XSingleton<XUpdater>.singleton.XPlatform.IsPublish();
		XSingleton<XDebug>.singleton.AddGreenLog("Pandora Init isProductEnvironment = " + isProductEnvironment.ToString(), null, null, null, null, null);
		Pandora.Instance.Init(isProductEnvironment, "UIRoot(Clone)");
		Pandora.Instance.SetJsonGameCallback(new Action<string>(this.OnJsonPandoraEvent));
	}

	public void PandoraLogin(string openid, string acctype, string area, string serverID, string appId, string roleID, string accessToken, string payToken, string gameVersion, string platID)
	{
		if (XSingleton<XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Standalone)
		{
			XSingleton<XDebug>.singleton.AddLog("PandoraLogin XPlatformType.Standalone", null, null, null, null, null, XDebugColor.XDebug_None);
			return;
		}
		this.Init();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["sOpenId"] = openid;
		dictionary["sAcountType"] = acctype;
		dictionary["sArea"] = area;
		dictionary["sPartition"] = serverID;
		dictionary["sAppId"] = appId;
		dictionary["sRoleId"] = roleID;
		dictionary["sAccessToken"] = accessToken;
		dictionary["sPayToken"] = payToken;
		dictionary["sGameVer"] = gameVersion;
		dictionary["sPlatID"] = platID;
		Pandora.Instance.SetUserData(dictionary);
		XSingleton<XDebug>.singleton.AddLog(string.Concat(new string[]
		{
			"pandoraSDK param:",
			openid,
			", ",
			acctype,
			", ",
			area,
			", ",
			serverID,
			",",
			appId,
			", ",
			roleID,
			",",
			accessToken,
			",",
			payToken,
			", ",
			gameVersion,
			", ",
			platID
		}), null, null, null, null, null, XDebugColor.XDebug_None);
	}

	public void PandoraLogout()
	{
		this.listActivityPopInfo.Clear();
		this.listActivityTabInfo.Clear();
		Pandora.Instance.Logout();
	}

	public void PandoraInit(bool isProductEnvironment, string rootName = "")
	{
		Pandora.Instance.Init(isProductEnvironment, rootName);
	}

	public void PandoraDo(Dictionary<string, string> commandDict)
	{
		Pandora.Instance.Do(commandDict);
	}

	public void PandoraDoJson(string json)
	{
		Pandora.Instance.DoJson(json);
	}

	public void SetPandoraPanelParent(string panelName, GameObject panelParent)
	{
		XSingleton<XDebug>.singleton.AddGreenLog("Pandora SetPandoraPanelParent panelName = " + panelName, null, null, null, null, null);
		Pandora.Instance.SetPanelParent(panelName, panelParent);
	}

	public void SetFont(Font font)
	{
		Pandora.Instance.SetFont(font);
	}

	public void LoadProgramAsset()
	{
		Pandora.Instance.LoadProgramAsset();
	}

	public void SetUserData(Dictionary<string, string> data)
	{
		Pandora.Instance.SetUserData(data);
	}

	public void SetGameCallback(Action<Dictionary<string, string>> callback)
	{
		Pandora.Instance.SetGameCallback(callback);
	}

	public void SetJsonGameCallback(Action<string> callback)
	{
		Pandora.Instance.SetJsonGameCallback(callback);
	}

	public void PopPLPanel()
	{
		XSingleton<XDebug>.singleton.AddGreenLog("Pandora ShowPLPanel", null, null, null, null, null);
		for (int i = 0; i < this.listActivityPopInfo.Count; i++)
		{
			this.listActivityPopInfo[i].isClose = false;
		}
		for (int j = 0; j < this.listActivityPopInfo.Count; j++)
		{
			if (this.listActivityPopInfo[j].isReady)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["type"] = "pop";
				dictionary["content"] = this.listActivityPopInfo[j].activityName;
				string jsonStr = MiniJSON.Json.Serialize(dictionary);
				Pandora.Instance.DoJson(jsonStr);
				break;
			}
		}
	}

	public string IsActivityPopReady()
	{
		for (int i = 0; i < this.listActivityPopInfo.Count; i++)
		{
			if (this.listActivityPopInfo[i].isReady)
			{
				return this.listActivityPopInfo[i].activityName;
			}
		}
		return string.Empty;
	}

	public void CloseAllPandoraPanel()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["type"] = "close";
		dictionary["content"] = "all";
		string jsonStr = MiniJSON.Json.Serialize(dictionary);
		Pandora.Instance.DoJson(jsonStr);
	}

	public void ClosePandoraTabPanel()
	{
		for (int i = 0; i < this.listActivityTabInfo.Count; i++)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["type"] = "close";
			dictionary["content"] = this.listActivityTabInfo[i].activityName;
			string text = MiniJSON.Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("Pandora ClosePandoraTabPanel json = " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			Pandora.Instance.DoJson(text);
		}
	}

	public void NoticePandoraShareResult(string result)
	{
		if (this.isSharing)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["type"] = "shareRet";
			dictionary["ret"] = ((!(result == "Success")) ? "1" : "0");
			dictionary["msg"] = ((!(result == "Success")) ? result : string.Empty);
			string jsonStr = MiniJSON.Json.Serialize(dictionary);
			Pandora.Instance.DoJson(jsonStr);
			this.isSharing = false;
		}
	}

	public bool IsActivityTabShow(string tabName)
	{
		for (int i = 0; i < this.listActivityTabInfo.Count; i++)
		{
			if (this.listActivityTabInfo[i].tabName == tabName && this.listActivityTabInfo[i].tabShow)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsActivityTabShowByContent(string tabContent)
	{
		for (int i = 0; i < this.listActivityTabInfo.Count; i++)
		{
			if (this.listActivityTabInfo[i].activityName == tabContent && this.listActivityTabInfo[i].tabShow)
			{
				return true;
			}
		}
		return false;
	}

	private void OnJsonPandoraEvent(string json)
	{
		this._OnJsonPandoraEvent(json);
		HotfixManager.Instance.OnPandoraCallback(json);
	}

	private void _OnJsonPandoraEvent(string json)
	{
		Dictionary<string, object> dictionary = com.tencent.pandora.MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
		if (dictionary == null)
		{
			XSingleton<XDebug>.singleton.AddLog("[PandoraMgr]_OnJsonPandoraEvent dict == null", null, null, null, null, null, XDebugColor.XDebug_None);
			return;
		}
		object obj;
		if (dictionary.TryGetValue("type", out obj))
		{
			string text = obj.ToString();
			string text2 = text;
			switch (text2)
			{
			case "popReady":
				this.OnActivityPopReady(dictionary);
				break;
			case "popStop":
				this.OnActivityPopStop(dictionary);
				break;
			case "popClose":
				this.OnActivityPopClose(dictionary);
				break;
			case "showTab":
				this.OnActivityShowTab(dictionary);
				break;
			case "hideTab":
				this.OnActivityHideTab(dictionary);
				break;
			case "showRedpoint":
				this.OnActivityShowRedPoint(dictionary);
				break;
			case "hideRedpoint":
				this.OnActivityHideRedPoint(dictionary);
				break;
			case "shareWechatLink":
				this.OnActivityWeChatShare(dictionary);
				break;
			case "shareQQLink":
				this.OnActivityQQShare(dictionary);
				break;
			case "showItemTips":
				this.OnActivityShowItemTip(dictionary);
				break;
			}
		}
		object obj2;
		object obj3;
		if (dictionary.TryGetValue("PanelName", out obj2) && dictionary.TryGetValue("RetCode", out obj3))
		{
			int num2 = 0;
			if (int.TryParse(obj3.ToString(), out num2) && num2 == 0)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("PandoraPanelCreate error = " + num2, null, null, null, null, null);
				for (int i = 0; i < this.listActivityPopInfo.Count; i++)
				{
					if (this.listActivityPopInfo[i].activityName == obj2.ToString())
					{
						IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
						if (@interface != null)
						{
							@interface.ShowPandoraPopView(true);
						}
						break;
					}
				}
			}
		}
	}

	private void OnActivityPopReady(Dictionary<string, object> dict)
	{
		object obj;
		if (dict.TryGetValue("content", out obj))
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityPopReady content = " + obj.ToString(), null, null, null, null, null);
			for (int i = 0; i < this.listActivityPopInfo.Count; i++)
			{
				if (this.listActivityPopInfo[i].activityName == obj.ToString())
				{
					this.listActivityPopInfo[i].isReady = true;
					return;
				}
			}
			ActivityPopInfo activityPopInfo = new ActivityPopInfo();
			activityPopInfo.activityName = obj.ToString();
			activityPopInfo.isReady = true;
			activityPopInfo.isClose = false;
			this.listActivityPopInfo.Add(activityPopInfo);
		}
	}

	private void OnActivityPopStop(Dictionary<string, object> dict)
	{
		object obj;
		if (dict.TryGetValue("content", out obj))
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityPopStop content = " + obj.ToString(), null, null, null, null, null);
			for (int i = 0; i < this.listActivityPopInfo.Count; i++)
			{
				if (this.listActivityPopInfo[i].activityName == obj.ToString())
				{
					this.listActivityPopInfo[i].isReady = false;
					return;
				}
			}
			ActivityPopInfo activityPopInfo = new ActivityPopInfo();
			activityPopInfo.activityName = obj.ToString();
			activityPopInfo.isReady = false;
			activityPopInfo.isClose = false;
			this.listActivityPopInfo.Add(activityPopInfo);
		}
	}

	private void OnActivityPopClose(Dictionary<string, object> dict)
	{
		object obj;
		if (dict.TryGetValue("content", out obj))
		{
			string text = obj.ToString();
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityPopClose content = " + text, null, null, null, null, null);
			for (int i = 0; i < this.listActivityPopInfo.Count; i++)
			{
				if (this.listActivityPopInfo[i].activityName == text)
				{
					IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
					if (@interface != null)
					{
						@interface.ShowPandoraPopView(false);
					}
					this.listActivityPopInfo[i].isClose = true;
					break;
				}
			}
			for (int j = 0; j < this.listActivityPopInfo.Count; j++)
			{
				if (this.listActivityPopInfo[j].isReady && !this.listActivityPopInfo[j].isClose)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary["type"] = "pop";
					dictionary["content"] = this.listActivityPopInfo[j].activityName;
					string jsonStr = MiniJSON.Json.Serialize(dictionary);
					Pandora.Instance.DoJson(jsonStr);
					XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityPopClose open = " + this.listActivityPopInfo[j].activityName, null, null, null, null, null);
					break;
				}
			}
		}
	}

	private void OnActivityShowTab(Dictionary<string, object> dict)
	{
		object obj;
		if (!dict.TryGetValue("content", out obj))
		{
			return;
		}
		object obj2;
		dict.TryGetValue("name", out obj2);
		string tabName = (obj2 != null) ? obj2.ToString() : "TabName";
		string text = obj.ToString();
		XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityShowTab content = " + text, null, null, null, null, null);
		for (int i = 0; i < this.listActivityTabInfo.Count; i++)
		{
			if (this.listActivityTabInfo[i].activityName == text)
			{
				this.listActivityTabInfo[i].tabName = tabName;
				this.listActivityTabInfo[i].tabShow = true;
				return;
			}
		}
		ActivityTabInfo activityTabInfo = new ActivityTabInfo();
		activityTabInfo.activityName = text;
		activityTabInfo.tabName = tabName;
		activityTabInfo.tabShow = true;
		activityTabInfo.redPointShow = false;
		this.listActivityTabInfo.Add(activityTabInfo);
	}

	private void OnActivityHideTab(Dictionary<string, object> dict)
	{
		object obj;
		if (!dict.TryGetValue("content", out obj))
		{
			return;
		}
		object obj2;
		dict.TryGetValue("name", out obj2);
		string tabName = (obj2 != null) ? obj2.ToString() : "TabName";
		string text = obj.ToString();
		XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityHideTab content = " + text, null, null, null, null, null);
		for (int i = 0; i < this.listActivityTabInfo.Count; i++)
		{
			if (this.listActivityTabInfo[i].activityName == text)
			{
				this.listActivityTabInfo[i].tabName = tabName;
				this.listActivityTabInfo[i].tabShow = false;
				return;
			}
		}
		ActivityTabInfo activityTabInfo = new ActivityTabInfo();
		activityTabInfo.activityName = text;
		activityTabInfo.tabName = tabName;
		activityTabInfo.tabShow = false;
		activityTabInfo.redPointShow = false;
	}

	private void OnActivityShowRedPoint(Dictionary<string, object> dict)
	{
		object obj;
		if (dict.TryGetValue("content", out obj))
		{
			string text = obj.ToString();
			for (int i = 0; i < this.listActivityTabInfo.Count; i++)
			{
				if (this.listActivityTabInfo[i].activityName == text)
				{
					this.listActivityTabInfo[i].redPointShow = true;
					break;
				}
			}
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityShowRedPoint content = " + text, null, null, null, null, null);
		}
	}

	private void OnActivityHideRedPoint(Dictionary<string, object> dict)
	{
		object obj;
		if (dict.TryGetValue("content", out obj))
		{
			string text = obj.ToString();
			for (int i = 0; i < this.listActivityTabInfo.Count; i++)
			{
				if (this.listActivityTabInfo[i].activityName == text)
				{
					this.listActivityTabInfo[i].redPointShow = false;
					break;
				}
			}
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora OnActivityHideRedPoint content = " + text, null, null, null, null, null);
		}
	}

	private void OnActivityWeChatShare(Dictionary<string, object> dict)
	{
		IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		if (@interface != null && !@interface.CheckWXInstalled())
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora wx not installed", null, null, null, null, null);
			return;
		}
		object sceneObj;
		if (!dict.TryGetValue("scene", out sceneObj))
		{
			return;
		}
		object titleObj;
		dict.TryGetValue("title", out titleObj);
		object descObj;
		dict.TryGetValue("desc", out descObj);
		object urlObj;
		dict.TryGetValue("url", out urlObj);
		object mediaTagNameObj;
		dict.TryGetValue("mediaTagName", out mediaTagNameObj);
		object obj;
		dict.TryGetValue("filePath", out obj);
		object messageExtObj;
		dict.TryGetValue("messageExt", out messageExtObj);
		if (obj != null)
		{
			base.StartCoroutine(this.DownloadPic(obj.ToString(), delegate(string filepath)
			{
				if (!string.IsNullOrEmpty(filepath))
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary["scene"] = ((sceneObj != null) ? sceneObj.ToString() : string.Empty);
					dictionary["title"] = ((titleObj != null) ? titleObj.ToString() : string.Empty);
					dictionary["desc"] = ((descObj != null) ? descObj.ToString() : string.Empty);
					dictionary["url"] = ((urlObj != null) ? urlObj.ToString() : string.Empty);
					dictionary["mediaTagName"] = ((mediaTagNameObj != null) ? mediaTagNameObj.ToString() : string.Empty);
					dictionary["filePath"] = filepath;
					dictionary["messageExt"] = ((messageExtObj != null) ? messageExtObj.ToString() : string.Empty);
					string text = MiniJSON.Json.Serialize(dictionary);
					XSingleton<XDebug>.singleton.AddGreenLog("Pandora pandoraShareWX json = " + text, null, null, null, null, null);
					XPlatform component = this.gameObject.GetComponent<XPlatform>();
					if (component != null)
					{
						XSingleton<XDebug>.singleton.AddGreenLog("Pandora share_send_to_with_url_wx json = " + text, null, null, null, null, null);
						this.isSharing = true;
						component.SendGameExData("share_send_to_with_url_wx", text);
					}
				}
			}));
		}
	}

	private void OnActivityQQShare(Dictionary<string, object> dict)
	{
		IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		if (@interface != null && !@interface.CheckQQInstalled())
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Pandora qqshare not installed", null, null, null, null, null);
			return;
		}
		object sceneObj;
		if (!dict.TryGetValue("scene", out sceneObj))
		{
			return;
		}
		object titleObj;
		dict.TryGetValue("title", out titleObj);
		object summaryObj;
		dict.TryGetValue("summary", out summaryObj);
		object targetUrlObj;
		dict.TryGetValue("targetUrl", out targetUrlObj);
		object obj;
		dict.TryGetValue("imageUrl", out obj);
		if (obj != null)
		{
			base.StartCoroutine(this.DownloadPic(obj.ToString(), delegate(string filepath)
			{
				if (!string.IsNullOrEmpty(filepath))
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary["scene"] = ((sceneObj != null) ? sceneObj.ToString() : string.Empty);
					dictionary["title"] = ((titleObj != null) ? titleObj.ToString() : string.Empty);
					dictionary["summary"] = ((summaryObj != null) ? summaryObj.ToString() : string.Empty);
					dictionary["targetUrl"] = ((targetUrlObj != null) ? targetUrlObj.ToString() : string.Empty);
					dictionary["imageUrl"] = filepath;
					string text = MiniJSON.Json.Serialize(dictionary);
					XSingleton<XDebug>.singleton.AddGreenLog("Pandora pandoraShareQQ json = " + text, null, null, null, null, null);
					XPlatform component = this.gameObject.GetComponent<XPlatform>();
					if (component != null)
					{
						this.isSharing = true;
						component.SendGameExData("share_send_to_struct_qq", text);
					}
				}
			}));
		}
	}

	private void OnActivityShowItemTip(Dictionary<string, object> dict)
	{
		object obj;
		if (dict.TryGetValue("itemId", out obj))
		{
			int num = 0;
			if (int.TryParse(obj.ToString(), out num))
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Pandora itemId = " + num, null, null, null, null, null);
				IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
				if (@interface != null)
				{
					@interface.ShowTooltipDialog(num, null);
				}
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator DownloadPic(string path, Action<string> callback)
	{
		XPandoraMgr.<DownloadPic>c__Iterator14 <DownloadPic>c__Iterator = new XPandoraMgr.<DownloadPic>c__Iterator14();
		<DownloadPic>c__Iterator.path = path;
		<DownloadPic>c__Iterator.callback = callback;
		<DownloadPic>c__Iterator.<$>path = path;
		<DownloadPic>c__Iterator.<$>callback = callback;
		return <DownloadPic>c__Iterator;
	}
}
