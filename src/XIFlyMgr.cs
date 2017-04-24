using Assets.SDK;
using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XUtliPoolLib;

internal class XIFlyMgr : MonoBehaviour, IXInterface, IXIFlyMgr
{
	public const string LANGUAGE = "language";

	public const string en_us = "en_us";

	public const string zh_cn = "zh_cn";

	public const string mandarin = "mandarin ";

	public const string ENGINE_TYPE = "engine_type";

	public const string TYPE_LOCAL = "local";

	public const string TYPE_CLOUD = "cloud";

	public const string ACCENT = "accent";

	public const string AUDIO_FORMAT = "audio_format";

	public const string ASR_AUDIO_PATH = "asr_audio_path";

	public const string SPEECH_TIME_OUT = "speech_timeout";

	public const string VAD_BOS = "vad_bos";

	public const string VAD_EOS = "vad_eos";

	private string current;

	private JoyYouSDK _interface;

	public static string PARAMS = "params";

	private string filepath = string.Empty;

	private string cachePath = string.Empty;

	private bool inited;

	[SerializeField]
	private string android_appid = string.Empty;

	[SerializeField]
	private string ios_appid = string.Empty;

	private Action<string> callback;

	private Action<string> voicecallback;

	public bool Deprecated
	{
		get;
		set;
	}

	public bool isListening
	{
		get
		{
			return false;
		}
	}

	private void Start()
	{
		this.InitIFly(this.android_appid);
		this.SetCallback(new Action<string>(this.TextRecCallback));
		this._interface = new JoyYouSDK();
		this.SetParameter("engine_type", "cloud");
		this.SetParameter("audio_format", "pcm");
		this.SetParameter("vad_bos", "8000");
		this.SetParameter("vad_eos", "5000");
		string audioCachePath = this.GetAudioCachePath();
		if (!string.IsNullOrEmpty(audioCachePath))
		{
			this.filepath = audioCachePath + "/record.pcm";
			Debug.Log("PCM filepath: " + this.filepath);
			this.SetParameter("asr_audio_path", this.filepath);
			this.inited = true;
		}
	}

	private void InitIFly(string appid)
	{
		Microphone.IsRecording(null);
	}

	public bool IsIFlyListening()
	{
		return this.isListening;
	}

	public bool IsInited()
	{
		return this.inited;
	}

	public bool IsRecordFileExist()
	{
		return File.Exists(this.filepath);
	}

	public MonoBehaviour GetMonoBehavior()
	{
		return this;
	}

	public void SetParameter(string var1, string var2)
	{
	}

	private void SalfCall(Action action)
	{
		try
		{
			action();
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
	}

	public int StartRecord()
	{
		Debug.Log("SpeechRecognizer:Start");
		int num = 0;
		Debug.Log(string.Format("SpeechRecognizer:Start({0})", num));
		return num;
	}

	public void StopRecord()
	{
		Debug.Log("SpeechRecognizer:Stop");
	}

	public void Cancel()
	{
		Debug.Log("SpeechRecognizer:Cancel");
	}

	private void InitEnd(string code)
	{
		Debug.Log(string.Format("SpeechRecognizer:InitEnd:" + code, new object[0]));
	}

	private void onBeginOfSpeech(string text)
	{
		Debug.Log("onBeginOfSpeech");
	}

	private void onError(string text)
	{
		Debug.Log(string.Format("onError:{0}", text));
	}

	private void onEndOfSpeech(string text)
	{
		Debug.Log("onEndOfSpeech");
	}

	private void onVolumeChanged(string volume)
	{
		if (this.voicecallback != null)
		{
			this.voicecallback(volume);
		}
	}

	public void SetCallback(Action<string> action)
	{
		this.callback = action;
	}

	public void SetVoiceCallback(Action<string> action)
	{
		this.voicecallback = action;
	}

	private void onResult(string text)
	{
		if (this.callback != null)
		{
			this.callback(text);
		}
	}

	private string GetAudioCachePath()
	{
		if (string.IsNullOrEmpty(this.cachePath))
		{
			this.cachePath = Application.persistentDataPath;
			if (string.IsNullOrEmpty(this.cachePath))
			{
				return string.Empty;
			}
			if (!Directory.Exists(this.cachePath))
			{
				Directory.CreateDirectory(this.cachePath);
			}
		}
		return this.cachePath;
	}

	private string GetString(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return path;
		}
		return path.Replace('\\', '/');
	}

	public string StartTransMp3(string destFileName)
	{
		return string.Empty;
	}

	public AudioClip GetAudioClip(string filepath)
	{
		return null;
	}

	private void TextRecCallback(string res)
	{
	}

	public bool ScreenShotQQShare(string filepath, string type)
	{
		if (!File.Exists(filepath))
		{
			return false;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["scene"] = type;
		dictionary["filePath"] = filepath;
		string text = Json.Serialize(dictionary);
		Debug.Log("SharePhotoWithQQ paramStr = " + text);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("share_send_to_with_photo_qq", text);
		return true;
	}

	public bool ScreenShotWeChatShare(string filepath, string type)
	{
		if (!File.Exists(filepath))
		{
			return false;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["scene"] = type;
		dictionary["filePath"] = filepath;
		dictionary["mediaTagName"] = "MSG_INVITE";
		dictionary["messageExt"] = "SharePhotoWithWeixin";
		dictionary["messageAction"] = "WECHAT_SNS_JUMP_APP";
		string text = Json.Serialize(dictionary);
		Debug.Log("SharePhotoWithWeixin paramStr = " + text);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("share_send_to_with_photo_wx", text);
		return true;
	}

	public bool ScreenShotSave(string filepath)
	{
		return true;
	}

	public bool RefreshAndroidPhotoView(string androidpath)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.ryanwebb.androidscreenshot.MainActivity");
		androidJavaClass.CallStatic<bool>("scanMedia", new object[]
		{
			androidpath
		});
		return true;
	}

	public bool OnOpenWebView()
	{
		Debug.Log("OnOpenWebView");
		UniWeb component = base.GetComponent<UniWeb>();
		if (component != null)
		{
			component.OpenWebView();
		}
		return true;
	}

	public void OnCloseWebView()
	{
		UniWeb component = base.GetComponent<UniWeb>();
		if (component != null)
		{
			component.CloseWebView(null);
		}
	}

	public void OnInitWebViewInfo(int platform, string openid, string serverid, string roleid, string nickname)
	{
		UniWeb component = base.GetComponent<UniWeb>();
		if (component != null)
		{
			component.InitWebInfo(platform, openid, serverid, roleid, nickname);
		}
	}

	public bool ShareWechatLink(string desc, string logopath, string url, bool issession)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (issession)
		{
			dictionary["scene"] = "Session";
		}
		else
		{
			dictionary["scene"] = "Timeline";
		}
		dictionary["title"] = desc;
		dictionary["desc"] = desc;
		dictionary["url"] = url;
		dictionary["mediaTagName"] = "MSG_INVITE";
		dictionary["filePath"] = logopath;
		dictionary["messageExt"] = "ShareUrlWithWeixin";
		string text = Json.Serialize(dictionary);
		Debug.Log("ShareUrlWithWeixin paramStr = " + text);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("share_send_to_with_url_wx", text);
		return true;
	}

	public bool ShareQZoneLink(string title, string summary, string url, string logopath, bool issession)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (issession)
		{
			dictionary["scene"] = "Session";
		}
		else
		{
			dictionary["scene"] = "QZone";
		}
		dictionary["title"] = title;
		dictionary["summary"] = summary;
		dictionary["targetUrl"] = url;
		dictionary["imageUrl"] = logopath;
		string text = Json.Serialize(dictionary);
		Debug.Log("ShareWithQQClient paramStr = " + text);
		((I3RDPlatformSDKEX)this._interface).SendGameExtData("share_send_to_struct_qq", text);
		return true;
	}

	public void OnEvalJsScript(string script)
	{
		UniWeb component = base.GetComponent<UniWeb>();
		if (component != null)
		{
			component.EvalJsScript(script);
		}
	}

	public void OnScreenLock(bool islock)
	{
		UniWeb component = base.GetComponent<UniWeb>();
		if (component != null)
		{
			Debug.Log("Will eval screen lock");
			if (islock)
			{
				component.EvalJsScript("DNScreenLock()");
			}
			else
			{
				component.EvalJsScript("DNScreenUnlock()");
			}
		}
	}

	public void RefershWebViewShow(bool show)
	{
		UniWeb component = base.GetComponent<UniWeb>();
		if (component != null)
		{
			Debug.Log("Will eval screen lock");
			component.OnShowWebView(show);
		}
	}
}
