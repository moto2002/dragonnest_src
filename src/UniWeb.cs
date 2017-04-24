using Assets.SDK;
using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using XUtliPoolLib;

public class UniWeb : MonoBehaviour
{
	private JoyYouSDK _interface;

	private string mAppId = "1105309683";

	private string mOpenid = "0";

	private string mServerid = "0";

	private string mRoleid = "0";

	private string mToken = "0";

	private string mNickName = string.Empty;

	public static IUiUtility m_uiUtility;

	private int _gap = 90;

	private ulong mOpenTime;

	private string mWebViewUrl = "https://apps.game.qq.com/gts/gtp3.0/customize/dn/end.php";

	private UniWebView _webView;

	private string _errorMessage;

	private GameObject _cube;

	private Vector3 _moveVector;

	private bool _is_bgopen = true;

	private void Awake()
	{
		this._interface = new JoyYouSDK();
		UniWeb.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
	}

	public void InitWebInfo(int platform, string openid, string serverid, string roleid, string nickname)
	{
		if (UniWeb.m_uiUtility == null)
		{
			UniWeb.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		if (platform == 0)
		{
			this.mAppId = "1105309683";
		}
		else
		{
			this.mAppId = "wxfdab5af74990787a";
		}
		this.mOpenid = openid;
		this.mServerid = serverid;
		this.mRoleid = roleid;
		this.mNickName = nickname;
		string sDKConfig = ((I3RDPlatformSDKEX)this._interface).GetSDKConfig("get_login_bill", string.Empty);
		object obj = Json.Deserialize(sDKConfig);
		Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
		if (dictionary != null)
		{
			if (dictionary.ContainsKey("token"))
			{
				this.mToken = (dictionary["token"] as string);
			}
			if (dictionary.ContainsKey("openid"))
			{
				this.mOpenid = (dictionary["openid"] as string);
			}
		}
		UnityEngine.Debug.Log("The openid: " + this.mOpenid);
		UnityEngine.Debug.Log("The token: " + this.mToken);
	}

	private void Start()
	{
	}

	public void OpenWebView()
	{
		UnityEngine.Debug.Log("Will do open web view");
		this._gap = this.GetGap();
		DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		this.mOpenTime = (ulong)(DateTime.Now - d).TotalMilliseconds;
		this._webView = base.GetComponent<UniWebView>();
		if (this._webView == null)
		{
			this._webView = base.gameObject.AddComponent<UniWebView>();
			this._webView.OnReceivedMessage += new UniWebView.ReceivedMessageDelegate(this.OnReceivedMessage);
			this._webView.OnLoadComplete += new UniWebView.LoadCompleteDelegate(this.OnLoadComplete);
			this._webView.OnWebViewShouldClose += new UniWebView.WebViewShouldCloseDelegate(this.OnWebViewShouldClose);
			this._webView.OnEvalJavaScriptFinished += new UniWebView.EvalJavaScriptFinishedDelegate(this.OnEvalJavaScriptFinished);
			this._webView.InsetsForScreenOreitation += new UniWebView.InsetsForScreenOreitationDelegate(this.InsetsForScreenOreitation);
		}
		string text = string.Format("{0}?appid={1}&openid={2}&access_token={3}&partition={4}&roleid={5}&entertime={6}&nickname={7}", new object[]
		{
			this.mWebViewUrl,
			this.mAppId,
			this.mOpenid,
			this.mToken,
			this.mServerid,
			this.mRoleid,
			this.mOpenTime,
			WWW.EscapeURL(this.mNickName)
		});
		UnityEngine.Debug.Log("url: " + text);
		this._webView.url = text;
		UnityEngine.Debug.Log("Final url: " + this._webView.url);
		UnityEngine.Debug.Log("Width: " + Screen.width.ToString());
		UnityEngine.Debug.Log("Height: " + Screen.height.ToString());
		UnityEngine.Debug.Log("Webview height: " + this._webView.GetWebViewHeight().ToString());
		this._webView.Load();
	}

	public void CloseWebView(UniWebView webView)
	{
		if (webView == null)
		{
			webView = this._webView;
		}
		if (webView != null)
		{
			webView.Hide();
			UnityEngine.Object.Destroy(webView);
			webView.OnReceivedMessage -= new UniWebView.ReceivedMessageDelegate(this.OnReceivedMessage);
			webView.OnLoadComplete -= new UniWebView.LoadCompleteDelegate(this.OnLoadComplete);
			webView.OnWebViewShouldClose -= new UniWebView.WebViewShouldCloseDelegate(this.OnWebViewShouldClose);
			webView.OnEvalJavaScriptFinished -= new UniWebView.EvalJavaScriptFinishedDelegate(this.OnEvalJavaScriptFinished);
			webView.InsetsForScreenOreitation -= new UniWebView.InsetsForScreenOreitationDelegate(this.InsetsForScreenOreitation);
		}
		this._webView = null;
		this._is_bgopen = true;
		if (UniWeb.m_uiUtility == null)
		{
			UniWeb.m_uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		}
		UniWeb.m_uiUtility.OnSetBg(true);
		UniWeb.m_uiUtility.OnWebViewClose();
	}

	private void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
	{
		if (success)
		{
			webView.Show();
		}
		else
		{
			UnityEngine.Debug.Log("Something wrong in webview loading: " + errorMessage);
			this._errorMessage = errorMessage;
		}
	}

	private void OnReceivedMessage(UniWebView webView, UniWebViewMessage message)
	{
		UnityEngine.Debug.Log("OnReceivedMessage");
		UnityEngine.Debug.Log(message.rawMessage);
		if (string.Equals(message.path, "webview"))
		{
			Vector3 zero = Vector3.zero;
			if (message.args.ContainsKey("funcname"))
			{
				if (string.Equals(message.args["funcname"], "dnqueryuserinfo"))
				{
					if (message.args.ContainsKey("callback"))
					{
						UnityEngine.Debug.Log("Will callback");
						string arg = message.args["callback"];
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						dictionary["appid"] = this.mAppId;
						dictionary["openid"] = this.mOpenid;
						dictionary["access_token"] = this.mToken;
						dictionary["partition"] = this.mServerid;
						dictionary["roleid"] = this.mRoleid;
						dictionary["entertime"] = this.mOpenTime;
						dictionary["nickname"] = this.mNickName;
						string arg2 = Json.Serialize(dictionary);
						string text = string.Format("{0}({1})", arg, arg2);
						UnityEngine.Debug.Log(text);
						webView.EvaluatingJavaScript(text);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnclosewebview"))
				{
					this.CloseWebView(webView);
				}
				else if (string.Equals(message.args["funcname"], "dniswifi"))
				{
					if (message.args.ContainsKey("callback"))
					{
						UnityEngine.Debug.Log("Will dniswifi callback");
						string arg3 = message.args["callback"];
						bool flag = Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
						int num = (!flag) ? 0 : 1;
						string text2 = string.Format("{0}({1})", arg3, num);
						UnityEngine.Debug.Log(text2);
						webView.EvaluatingJavaScript(text2);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnisbgopen"))
				{
					if (message.args.ContainsKey("callback"))
					{
						UnityEngine.Debug.Log("Will dnisbgopen callback");
						string arg4 = message.args["callback"];
						int num2 = (!this._is_bgopen) ? 0 : 1;
						string text3 = string.Format("{0}({1})", arg4, num2);
						UnityEngine.Debug.Log(text3);
						webView.EvaluatingJavaScript(text3);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnopenbg"))
				{
					this._is_bgopen = true;
					UniWeb.m_uiUtility.OnSetBg(true);
				}
				else if (string.Equals(message.args["funcname"], "dnclosebg"))
				{
					this._is_bgopen = false;
					UniWeb.m_uiUtility.OnSetBg(false);
				}
				else if (string.Equals(message.args["funcname"], "dnchangemenu"))
				{
					if (message.args.ContainsKey("menutype"))
					{
						int menutype = int.Parse(message.args["menutype"]);
						UniWeb.m_uiUtility.OnSetWebViewMenu(menutype);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnbackgame"))
				{
					if (message.args.ContainsKey("backtype"))
					{
						int menutype2 = int.Parse(message.args["backtype"]);
						UniWeb.m_uiUtility.OnSetWebViewMenu(menutype2);
					}
					if (message.args.ContainsKey("callback"))
					{
						UnityEngine.Debug.Log("Will dnbackgame callback");
						string arg5 = message.args["callback"];
						string text4 = string.Format("{0}()", arg5);
						UnityEngine.Debug.Log(text4);
						webView.EvaluatingJavaScript(text4);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnrefreshredpoint"))
				{
					if (message.args.ContainsKey("args"))
					{
						string text5 = WWW.UnEscapeURL(message.args["args"]);
						UnityEngine.Debug.Log("dnrefreshredpoint" + text5);
						UniWeb.m_uiUtility.OnWebViewRefershRefPoint(text5);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnsetheaderinfo"))
				{
					if (message.args.ContainsKey("args"))
					{
						string text6 = WWW.UnEscapeURL(message.args["args"]);
						UnityEngine.Debug.Log("dnsetheaderinfo" + text6);
						UniWeb.m_uiUtility.OnWebViewSetheaderInfo(text6);
					}
				}
				else if (string.Equals(message.args["funcname"], "dnshownav"))
				{
					if (message.args.ContainsKey("type"))
					{
						int num3 = int.Parse(message.args["type"]);
						if (num3 == 1)
						{
							this._gap = this.GetGap();
						}
						else
						{
							this._gap = 0;
						}
						this._webView.ForceResize();
					}
				}
				else if (string.Equals(message.args["funcname"], "dncloseloading"))
				{
					if (message.args.ContainsKey("show"))
					{
						int num4 = int.Parse(message.args["show"]);
						UnityEngine.Debug.Log("dncloseloading: " + message.args["show"]);
						UniWeb.m_uiUtility.OnWebViewCloseLoading(num4);
						if (num4 == 1)
						{
							this._webView.Hide();
						}
						else
						{
							this._webView.Show();
						}
					}
				}
				else if (string.Equals(message.args["funcname"], "dnshowreconnect"))
				{
					if (message.args.ContainsKey("show"))
					{
						int num5 = int.Parse(message.args["show"]);
						UnityEngine.Debug.Log("dnshowreconnect: " + message.args["show"]);
						UniWeb.m_uiUtility.OnWebViewShowReconnect(num5);
						if (num5 == 1)
						{
							this._webView.Hide();
						}
						else
						{
							this._webView.Show();
						}
					}
				}
				else if (string.Equals(message.args["funcname"], "dnsetlivetab"))
				{
					UniWeb.m_uiUtility.OnWebViewLiveTab();
				}
				else if (string.Equals(message.args["funcname"], "dnbackhistory"))
				{
					this._webView.GoBack();
				}
				else if (string.Equals(message.args["funcname"], "dnsetshareinfo"))
				{
					string json = WWW.UnEscapeURL(message.args["args"]);
					Dictionary<string, object> dictionary2 = Json.Deserialize(json) as Dictionary<string, object>;
					XPlatform platf = base.gameObject.GetComponent<XPlatform>();
					object title;
					dictionary2.TryGetValue("title", out title);
					object obj;
					dictionary2.TryGetValue("imgurl", out obj);
					object desc;
					dictionary2.TryGetValue("desc", out desc);
					object url;
					dictionary2.TryGetValue("url", out url);
					object type;
					dictionary2.TryGetValue("type", out type);
					if (type.Equals("qq") || type.Equals("qzone"))
					{
						Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
						dictionary3["scene"] = ((!type.Equals("qq")) ? "QZone" : "Session");
						if (url != null)
						{
							dictionary3["targetUrl"] = "https:" + url.ToString();
						}
						if (obj != null)
						{
							dictionary3["imageUrl"] = obj.ToString();
						}
						if (title != null)
						{
							dictionary3["title"] = title.ToString();
						}
						if (desc != null)
						{
							dictionary3["description"] = desc.ToString();
						}
						dictionary3["summary"] = string.Empty;
						string json2 = Json.Serialize(dictionary3);
						platf.SendGameExData("share_send_to_struct_qq", json2);
					}
					else if (type.Equals("weixin") || type.Equals("timeline"))
					{
						if (!base.gameObject.activeSelf)
						{
							return;
						}
						base.StartCoroutine(this.DownloadPic(obj.ToString(), delegate(string filepath)
						{
							if (!string.IsNullOrEmpty(filepath))
							{
								Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
								dictionary4["scene"] = ((!type.Equals("weixin")) ? "Timeline" : "Session");
								if (title != null)
								{
									dictionary4["title"] = title.ToString();
								}
								if (desc != null)
								{
									dictionary4["desc"] = desc.ToString();
								}
								if (url != null)
								{
									dictionary4["url"] = url.ToString();
								}
								dictionary4["mediaTagName"] = "MSG_INVITE";
								dictionary4["filePath"] = filepath;
								dictionary4["messageExt"] = "ShareUrlWithWeixin";
								string json3 = Json.Serialize(dictionary4);
								platf.SendGameExData("share_send_to_with_url_wx", json3);
							}
						}));
					}
					else
					{
						UnityEngine.Debug.LogError("err type: " + type);
					}
				}
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator DownloadPic(string path, Action<string> cb)
	{
		UniWeb.<DownloadPic>c__Iterator17 <DownloadPic>c__Iterator = new UniWeb.<DownloadPic>c__Iterator17();
		<DownloadPic>c__Iterator.path = path;
		<DownloadPic>c__Iterator.cb = cb;
		<DownloadPic>c__Iterator.<$>path = path;
		<DownloadPic>c__Iterator.<$>cb = cb;
		return <DownloadPic>c__Iterator;
	}

	public void ShowAlertInWebview(float time, bool first)
	{
		this._moveVector = Vector3.zero;
		if (first)
		{
			this._webView.EvaluatingJavaScript("sample(" + time + ")");
		}
	}

	private void OnEvalJavaScriptFinished(UniWebView webView, string result)
	{
		UnityEngine.Debug.Log("js result: " + result);
	}

	private bool OnWebViewShouldClose(UniWebView webView)
	{
		if (webView == this._webView)
		{
			this._webView = null;
			return true;
		}
		return false;
	}

	public void EvalJsScript(string jsscript)
	{
		UnityEngine.Debug.Log(jsscript);
		if (jsscript.Contains("DNBackClick"))
		{
			if (this._webView != null)
			{
				try
				{
					this._webView.EvaluatingJavaScript(jsscript);
				}
				catch
				{
					this.CloseWebView(this._webView);
				}
			}
		}
		else if (this._webView != null)
		{
			this._webView.EvaluatingJavaScript(jsscript);
		}
	}

	public void OnShowWebView(bool show)
	{
		if (this._webView != null)
		{
			if (show)
			{
				this._webView.Show();
			}
			else
			{
				this._webView.Hide();
			}
		}
	}

	private int GetGap()
	{
		return 90 * Screen.width / 1920 + (Screen.height - Screen.width * 1080 / 1920) / 2;
	}

	private UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation)
	{
		UnityEngine.Debug.Log("Gap: " + this._gap.ToString());
		return new UniWebViewEdgeInsets(this._gap, 0, 0, 0);
	}
}
