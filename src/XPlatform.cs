using Assets.SDK;
using com.tencent.httpdns;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

public class XPlatform : MonoBehaviour, IXInterface, IPlatform
{
	private JoyYouSDK _interface;

	private static string _defaultLoginServer = "qq.lzgjx.qq.com:10004";

	private static string _androidQQLoginServer = "qq.lzgjx.qq.com:10004";

	private static string _androidWeChatLoginServer = "wx.lzgjx.qq.com:10002";

	private static string _iOSQQLoginServer = "qq.lzgjx.qq.com:10003";

	private static string _iOSWeChatLoginServer = "wx.lzgjx.qq.com:10001";

	private static string _iOSGuestLoginServer = "wx.lzgjx.qq.com:10001";

	private static string _versionServer = "wx.lzgjx.qq.com:10000";

	private static string _hostUrl = "https://image.lzgjx.qq.com/Official/";

	private static bool _isPublish = true;

	private static string _testDefaultLoginServer = "test.lzgjx.qq.com:9640";

	private static string _testAndroidQQLoginServer = "test.lzgjx.qq.com:9640";

	private static string _testAndroidWeChatLoginServer = "test.lzgjx.qq.com:9620";

	private static string _testiOSQQLoginServer = "test.lzgjx.qq.com:9630";

	private static string _testiOSWeChatLoginServer = "test.lzgjx.qq.com:9610";

	private static string _testiOSGuestLoginServer = "test.lzgjx.qq.com:9610";

	private static string _testVersionServer = "test.lzgjx.qq.com:9700";

	private static bool _isTestMode;

	private bool m_enableUIHalfReslution;

	private bool m_enableDelayLoadUISprite;

	public static string UrlConfig
	{
		get
		{
			return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}", new object[]
			{
				XPlatform._defaultLoginServer,
				XPlatform._androidQQLoginServer,
				XPlatform._androidWeChatLoginServer,
				XPlatform._iOSQQLoginServer,
				XPlatform._iOSWeChatLoginServer,
				XPlatform._iOSGuestLoginServer,
				XPlatform._versionServer,
				XPlatform._hostUrl,
				XPlatform._isPublish,
				XPlatform._testDefaultLoginServer,
				XPlatform._testAndroidQQLoginServer,
				XPlatform._testAndroidWeChatLoginServer,
				XPlatform._testiOSQQLoginServer,
				XPlatform._testiOSWeChatLoginServer,
				XPlatform._testiOSGuestLoginServer,
				XPlatform._testVersionServer
			});
		}
	}

	public bool Deprecated
	{
		get;
		set;
	}

	private void Awake()
	{
		this._interface = new JoyYouSDK();
		string localConfigPath = this.GetLocalConfigPath();
		string path = string.Format("{0}/config.cfg", Application.persistentDataPath);
		if (File.Exists(path))
		{
			this.LoadConfig(path);
		}
		else
		{
			this.LoadConfig(localConfigPath);
		}
		XPlatform._isTestMode = File.Exists(Path.Combine(Application.persistentDataPath, "TEST_VERSION"));
	}

	private string GetLocalConfigPath()
	{
		string result;
		switch (Application.platform)
		{
		case RuntimePlatform.IPhonePlayer:
			result = string.Format("{0}/Raw/config.cfg", Application.dataPath);
			return result;
		case RuntimePlatform.Android:
			result = string.Format("{0}!assets/config.cfg", Application.dataPath);
			return result;
		}
		result = string.Format("{0}/StreamingAssets/config.cfg", Application.dataPath);
		return result;
	}

	private void LoadConfig(string path)
	{
		AssetBundle assetBundle = AssetBundle.CreateFromFile(path);
		if (assetBundle == null)
		{
			return;
		}
		TextAsset textAsset = assetBundle.mainAsset as TextAsset;
		string[] array = textAsset.text.Split(new char[]
		{
			'|'
		});
		assetBundle.Unload(true);
		XPlatform._defaultLoginServer = array[0];
		XPlatform._androidQQLoginServer = array[1];
		XPlatform._androidWeChatLoginServer = array[2];
		XPlatform._iOSQQLoginServer = array[3];
		XPlatform._iOSWeChatLoginServer = array[4];
		XPlatform._iOSGuestLoginServer = array[5];
		XPlatform._versionServer = array[6];
		XPlatform._hostUrl = array[7];
		XPlatform._isPublish = bool.Parse(array[8]);
		XPlatform._testDefaultLoginServer = array[9];
		XPlatform._testAndroidQQLoginServer = array[10];
		XPlatform._testAndroidWeChatLoginServer = array[11];
		XPlatform._testiOSQQLoginServer = array[12];
		XPlatform._testiOSWeChatLoginServer = array[13];
		XPlatform._testiOSGuestLoginServer = array[14];
		XPlatform._testVersionServer = array[15];
	}

	public void OnPlatformLogin()
	{
		((I3RDPlatformSDK)this._interface).ShowLoginView();
	}

	public void OnQQLogin()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.IPhonePlayer:
			((I3RDPlatformSDK)this._interface).ShowLoginViewWithType(1);
			break;
		case RuntimePlatform.Android:
			((I3RDPlatformSDK)this._interface).ShowLoginView();
			break;
		}
	}

	public void OnWeChatLogin()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.IPhonePlayer:
			((I3RDPlatformSDK)this._interface).ShowLoginViewWithType(2);
			break;
		case RuntimePlatform.Android:
			((IHuanlePlatform)this._interface).HLLogin(string.Empty, string.Empty);
			break;
		}
	}

	public void OnGuestLogin()
	{
		((I3RDPlatformSDK)this._interface).ShowLoginViewWithType(0);
	}

	public void LogOut()
	{
		((I3RDPlatformSDK)this._interface).Logout();
		XSingleton<PDatabase>.singleton.playerInfo = null;
		XSingleton<PDatabase>.singleton.friendsInfo = null;
	}

	public void LoginCallBack(string token)
	{
		IEntrance @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IEntrance>(0u);
		if (@interface == null)
		{
			XSingleton<XDebug>.singleton.AddLog("LoginCallBack is invoked at wrong time, token: ", token, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			@interface.Authorization(token);
		}
	}

	public void LogoutCallBack(string msg)
	{
		IEntrance @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IEntrance>(0u);
		if (@interface == null)
		{
			XSingleton<XDebug>.singleton.AddLog("LogoutCallBack is invoked at wrong time", null, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			@interface.AuthorizationSignOut(msg);
		}
	}

	public void SendGameExData(string type, string json)
	{
		if (this._interface == null)
		{
			XSingleton<XDebug>.singleton.AddLog("SendGameExData error!!!", null, null, null, null, null, XDebugColor.XDebug_None);
		}
		else
		{
			((I3RDPlatformSDKEX)this._interface).SendGameExtData(type, json);
		}
	}

	public void UserViewClosedCallBack(string msg)
	{
		XSingleton<PDatabase>.singleton.HandleExData(msg);
	}

	public void SetPushStatus(bool status)
	{
		if (status)
		{
			((I3RDPlatformSDKEX)this._interface).SendGameExtData("push_setting", "{'status':1}");
		}
		else
		{
			((I3RDPlatformSDKEX)this._interface).SendGameExtData("push_setting", "{'status':0}");
		}
	}

	public void SendUserInfo(uint serverID, ulong roleID)
	{
		string format = "{{ \"zone_id\":{0}, \"role_id\":\"{1}\" }}";
		string jsonData = string.Format(format, serverID, roleID);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("send_user_info", jsonData);
	}

	public string GetHostWithHttpDns(string url)
	{
		return HttpDns.GetHostByName(url);
	}

	public bool CheckStatus(string type, string json)
	{
		return ((I3RDPlatformSDKEX)this._interface).CheckStatus(type, json);
	}

	public string GetSDKConfig(string type, string json)
	{
		return ((I3RDPlatformSDKEX)this._interface).GetSDKConfig(type, json);
	}

	public bool CheckWeChatInstalled()
	{
		return this.CheckStatus("Weixin_Installed", string.Empty);
	}

	public string GetChannelID()
	{
		return this.GetSDKConfig("get_channel_id", string.Empty);
	}

	public string GetBatteryLevel()
	{
		return this.GetSDKConfig("get_battery_level", string.Empty);
	}

	public void ResgiterSDONotification(uint serverid, string rolename)
	{
	}

	public string GetPFToken()
	{
		return "sdo";
	}

	public string GetVersionServer()
	{
		if (XPlatform._isTestMode)
		{
			return XPlatform._testVersionServer;
		}
		return XPlatform._versionServer;
	}

	public string GetHostUrl()
	{
		return XPlatform._hostUrl;
	}

	public string GetLoginServer(string loginType)
	{
		if (XPlatform._isTestMode)
		{
			switch (loginType)
			{
			case "Guest":
				return XPlatform._testiOSGuestLoginServer;
			case "QQ":
				switch (Application.platform)
				{
				case RuntimePlatform.IPhonePlayer:
					return XPlatform._testiOSQQLoginServer;
				case RuntimePlatform.Android:
					return XPlatform._testAndroidQQLoginServer;
				}
				break;
			case "WeChat":
				switch (Application.platform)
				{
				case RuntimePlatform.IPhonePlayer:
					return XPlatform._testiOSWeChatLoginServer;
				case RuntimePlatform.Android:
					return XPlatform._testAndroidWeChatLoginServer;
				}
				break;
			}
			return XPlatform._testDefaultLoginServer;
		}
		switch (loginType)
		{
		case "Guest":
			return XPlatform._iOSGuestLoginServer;
		case "QQ":
			switch (Application.platform)
			{
			case RuntimePlatform.IPhonePlayer:
				return XPlatform._iOSQQLoginServer;
			case RuntimePlatform.Android:
				return XPlatform._androidQQLoginServer;
			}
			break;
		case "WeChat":
			switch (Application.platform)
			{
			case RuntimePlatform.IPhonePlayer:
				return XPlatform._iOSWeChatLoginServer;
			case RuntimePlatform.Android:
				return XPlatform._androidWeChatLoginServer;
			}
			break;
		}
		return XPlatform._defaultLoginServer;
	}

	public bool IsPublish()
	{
		return XPlatform._isPublish;
	}

	public bool IsTestMode()
	{
		return XPlatform._isTestMode;
	}

	public XPlatformType Platfrom()
	{
		return XPlatformType.Android;
	}

	public bool IsEdior()
	{
		return false;
	}

	public void SetNoBackupFlag(string fullpath)
	{
	}

	public int GetQualityLevel()
	{
		if (SystemInfo.maxTextureSize > 8192 && SystemInfo.systemMemorySize > 3192)
		{
			return 3;
		}
		if (SystemInfo.systemMemorySize > 4096 && SystemInfo.graphicsMemorySize >= 1024)
		{
			return 2;
		}
		if (SystemInfo.systemMemorySize <= 2048 || SystemInfo.graphicsMemorySize <= 256)
		{
			return 0;
		}
		if (SystemInfo.systemMemorySize <= 4096 || SystemInfo.graphicsMemorySize <= 512)
		{
			return 1;
		}
		return 1;
	}

	public void EnableUIHalfResolution(bool enable)
	{
		this.m_enableUIHalfReslution = enable;
	}

	public bool IsUIHalfResolution()
	{
		return this.m_enableUIHalfReslution;
	}

	public void EnableUIDelayLoad(bool enable)
	{
		this.m_enableDelayLoadUISprite = enable;
	}

	public bool IsUIDelayLoad()
	{
		return this.m_enableDelayLoadUISprite;
	}

	public void MarkLoadlevel(string scene_name)
	{
	}

	public void MarkLoadlevelCompleted()
	{
	}

	public void MarkLevelEnd()
	{
	}

	public void SetScreenLightness(int percentage)
	{
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("set_screen_lightness", "{'percent':" + percentage.ToString() + "}");
	}

	public void ResetScreenLightness()
	{
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("reset_screen_lightness", string.Empty);
	}

	public string GetPayBill()
	{
		return ((I3RDPlatformSDKEX)this._interface).GetSDKConfig("get_payment_bill", string.Empty);
	}

	public void Pay(int price, string orderId, string paramID, ulong role, uint serverID)
	{
		((I3RDPlatformSDK)this._interface).Pay(price, orderId, paramID, role.ToString(), (int)serverID);
	}

	public string GetMD5(string plainText)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(plainText);
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] array = mD.ComputeHash(bytes);
		string text = null;
		for (int i = 0; i < array.Length; i++)
		{
			text += array[i].ToString("X");
		}
		return text;
	}

	public void PayCallBack(string msg)
	{
		XSingleton<XDebug>.singleton.AddLog("[Pay]CallBack: ", msg, null, null, null, null, XDebugColor.XDebug_None);
		IUiUtility @interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
		if (@interface != null)
		{
			@interface.OnPayCallback(msg);
		}
	}

	public void SendExtDara(string key, string param)
	{
		XSingleton<XDebug>.singleton.AddLog("[SendExtDara] paramStr = ", param, " key =", key, null, null, XDebugColor.XDebug_None);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData(key, param);
	}

	public void CreateWXGroup(string param)
	{
		XSingleton<XDebug>.singleton.AddLog("[CreateWXGroup] paramStr = ", param, null, null, null, null, XDebugColor.XDebug_None);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("create_wx_group", param);
	}

	public void JoinWXGroup(string param)
	{
		XSingleton<XDebug>.singleton.AddLog("[JoinWXGroup] paramStr = ", param, null, null, null, null, XDebugColor.XDebug_None);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("join_wx_group", param);
	}

	public void ShareWithWXGroup(string param)
	{
		XSingleton<XDebug>.singleton.AddLog("[ShareWithWXGroup] paramStr = ", param, null, null, null, null, XDebugColor.XDebug_None);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("share_send_to_struct_wx_union", param);
	}

	public void QueryWXGroup(string param)
	{
		XSingleton<XDebug>.singleton.AddLog("[QueryWXGroup] paramStr = ", param, null, null, null, null, XDebugColor.XDebug_None);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("query_wx_group", param);
	}
}
