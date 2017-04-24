using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace com.tencent.pandora
{
	public class Pandora
	{
		private static Pandora _instance;

		private bool _isInitialized;

		private Vector2 _referenceResolution;

		private GameObject _gameObject;

		private string _rootName;

		private UserData _userData;

		private RemoteConfig _remoteConfig;

		private BrokerSocket _brokerSocket;

		private AtmSocket _atmSocket;

		private LogHook _logHook;

		private Action<string> _jsonGameCallback;

		private Action<Dictionary<string, string>> _gameCallback;

		private Action<string> _playSoundDelegate;

		public Action<string, string, Action<Sprite>> GetIconSprite;

		private Dictionary<string, Font> _fontDict = new Dictionary<string, Font>();

		private int _totalGroupCount;

		private int _loadedGroupCount;

		public static Pandora Instance
		{
			get
			{
				if (Pandora._instance == null)
				{
					Pandora._instance = new Pandora();
				}
				return Pandora._instance;
			}
		}

		public bool EnableLogger
		{
			set
			{
				Logger.Enable = true;
			}
		}

		internal BrokerSocket BrokerSocket
		{
			get
			{
				return this._brokerSocket;
			}
		}

		public bool PauseDownloading
		{
			get
			{
				return CacheManager.PauseDownloading;
			}
			set
			{
				CacheManager.PauseDownloading = value;
			}
		}

		public bool PauseSocketSending
		{
			get
			{
				return this._brokerSocket.PauseSending;
			}
			set
			{
				this._brokerSocket.PauseSending = value;
				this._atmSocket.PauseSending = value;
			}
		}

		public bool IsDebug
		{
			get;
			set;
		}

		public void Init(bool isProductEnvironment, string rootName = "")
		{
			if (!this._isInitialized)
			{
				this._isInitialized = true;
				this._rootName = rootName;
				PandoraSettings.IsProductEnvironment = isProductEnvironment;
				PandoraSettings.ReadEnvironmentSetting();
				this._userData = new UserData();
				LocalDirectoryHelper.Initialize();
				this.CreatePandoraGameObject();
				this.AddLogHook();
				CacheManager.Initialize();
				AssetManager.Initialize();
				PanelManager.Initialize();
				TextPartner.GetFont = new Func<string, Font>(this.GetFont);
				Logger.LogLevel = PandoraSettings.DEFAULT_LOG_LEVEL;
				Logger.LogInfo("<color=#0000ff>Pandora Init " + this.GetSystemInfo() + "</color>");
			}
		}

		private string GetSystemInfo()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DeviceModel=");
			stringBuilder.Append(SystemInfo.deviceModel);
			stringBuilder.Append("&DeviceName=");
			stringBuilder.Append(SystemInfo.deviceName);
			stringBuilder.Append("&DeviceType=");
			stringBuilder.Append(SystemInfo.deviceType);
			stringBuilder.Append("&OperatingSystem=");
			stringBuilder.Append(SystemInfo.operatingSystem);
			stringBuilder.Append("&ProcessorType=");
			stringBuilder.Append(SystemInfo.processorType);
			stringBuilder.Append("&SystemMemorySize=");
			stringBuilder.Append(SystemInfo.systemMemorySize);
			stringBuilder.Append("&GraphicsDeviceName=");
			stringBuilder.Append(SystemInfo.graphicsDeviceName);
			return stringBuilder.ToString();
		}

		private void CreatePandoraGameObject()
		{
			if (!string.IsNullOrEmpty(this._rootName))
			{
				this._gameObject = GameObject.Find(this._rootName);
			}
			if (this._gameObject == null)
			{
				this._gameObject = new GameObject("ui_pandora");
				UIRoot uIRoot = this._gameObject.AddComponent<UIRoot>();
				GameObject gameObject = new GameObject("Camera");
				gameObject.transform.SetParent(this._gameObject.transform);
				Camera camera = gameObject.AddComponent<Camera>();
				camera.cullingMask = LayerMask.GetMask(new string[]
				{
					"UI"
				});
				camera.clearFlags = CameraClearFlags.Depth;
				camera.nearClipPlane = -100f;
				camera.farClipPlane = 100f;
				camera.orthographic = true;
				camera.orthographicSize = 1f;
				UICamera uICamera = gameObject.AddComponent<UICamera>();
				uICamera.eventType = UICamera.EventType.UI;
				uICamera.eventReceiverMask = LayerMask.GetMask(new string[]
				{
					"UI"
				});
				UnityEngine.Object.DontDestroyOnLoad(this._gameObject);
			}
		}

		public void SetPanelParent(string panelName, GameObject panelParent)
		{
			PanelManager.SetPanelParent(panelName, panelParent);
		}

		public GameObject GetGameObject()
		{
			return this._gameObject;
		}

		private void AddLogHook()
		{
			this._logHook = this._gameObject.AddComponent<LogHook>();
		}

		public LogHook GetLogHook()
		{
			return this._logHook;
		}

		public void SetPlaySoundDelegate(Action<string> playSoundDelegate)
		{
			this._playSoundDelegate = playSoundDelegate;
		}

		public void PlaySound(string id)
		{
			if (this._playSoundDelegate != null)
			{
				this._playSoundDelegate(id);
			}
		}

		public void SetGameCallback(Action<Dictionary<string, string>> callback)
		{
			this._gameCallback = callback;
			CacheManager.SetProgramAssetProgressCallback(new Action<Dictionary<string, string>>(this.ProgramAssetProgressCallback));
		}

		public void SetJsonGameCallback(Action<string> callback)
		{
			this._jsonGameCallback = callback;
			CacheManager.SetProgramAssetProgressCallback(new Action<Dictionary<string, string>>(this.ProgramAssetProgressCallback));
		}

		private void ProgramAssetProgressCallback(Dictionary<string, string> dict)
		{
			this.CallGame(Json.Serialize(dict));
		}

		public void CallGame(string jsonStr)
		{
			try
			{
				if (this._jsonGameCallback != null)
				{
					this._jsonGameCallback(jsonStr);
				}
				else if (this._gameCallback != null)
				{
					Dictionary<string, object> dictionary = Json.Deserialize(jsonStr) as Dictionary<string, object>;
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					foreach (KeyValuePair<string, object> current in dictionary)
					{
						dictionary2[current.Key] = ((current.Value != null) ? (current.Value as string) : string.Empty);
					}
					this._gameCallback(dictionary2);
				}
			}
			catch (Exception ex)
			{
				string text = "Lua发送消息,游戏回调发生异常, " + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 10217596);
			}
		}

		public void SetUserData(Dictionary<string, string> data)
		{
			if (this._userData.IsRoleEmpty())
			{
				data["sSdkVersion"] = PandoraSettings.GetSdkVersion();
				this._userData.Assign(data);
				Logger.LogInfo(this._userData.ToString());
				this.LoadRemoteConfig(this._userData);
			}
			else
			{
				this._userData.Refresh(data);
			}
		}

		public UserData GetUserData()
		{
			return this._userData;
		}

		private void LoadRemoteConfig(UserData userData)
		{
			AssetManager.LoadRemoteConfig(userData, new Action<RemoteConfig>(this.OnGetRemoteConfig));
		}

		private void OnGetRemoteConfig(RemoteConfig remoteConfig)
		{
			if (remoteConfig.IsError || remoteConfig.IsEmpty)
			{
				this.CallGame("{\"type\":\"pandoraError\",\"content\":\"cgiFailed\"}");
				return;
			}
			if (!remoteConfig.IsEmpty && !remoteConfig.IsError)
			{
				Logger.LogInfo(this._userData.ToString());
				Logger.LogInfo("<color=#00ff00>匹配到管理端规则：</color>  " + remoteConfig.ruleId.ToString());
				this._remoteConfig = remoteConfig;
				LuaStateManager.Initialize();
				this._atmSocket = this._gameObject.AddComponent<AtmSocket>();
				this._atmSocket.Connect(PandoraSettings.GetAtmHost(), PandoraSettings.GetAtmPort(), new Action(this.OnAtmConnected));
			}
		}

		private void OnAtmConnected()
		{
			this._brokerSocket = this._gameObject.AddComponent<BrokerSocket>();
			this._brokerSocket.AlternateIp1 = this._remoteConfig.brokerAlternateIp1;
			this._brokerSocket.AlternateIp2 = this._remoteConfig.brokerAlternateIp2;
			this._brokerSocket.Connect(this._remoteConfig.brokerHost, this._remoteConfig.brokerPort, new Action(this.OnBrokerConnected));
		}

		private void OnBrokerConnected()
		{
			this.LoadProgramAsset();
		}

		internal void LoadProgramAsset()
		{
			this._totalGroupCount = this._remoteConfig.assetInfoListDict.Keys.Count;
			this._loadedGroupCount = 0;
			foreach (KeyValuePair<string, List<RemoteConfig.AssetInfo>> current in this._remoteConfig.assetInfoListDict)
			{
				AssetManager.LoadProgramAssetList(current.Key, current.Value, new Action<string, List<RemoteConfig.AssetInfo>>(this.OnLoaded));
			}
		}

		public void LoadProgramAsset(string group)
		{
			Logger.Log("用户发起重连请求");
			if (this._userData == null || this._userData.IsRoleEmpty())
			{
				return;
			}
			if (this._remoteConfig == null)
			{
				this.LoadRemoteConfig(this._userData);
				this.ReportError("用户成功发起重连请求!", 10217602);
				return;
			}
			this._totalGroupCount = 1;
			this._loadedGroupCount = 0;
			if (this._remoteConfig != null && this._remoteConfig.assetInfoListDict.ContainsKey(group) && !LuaStateManager.IsGroupLuaExecuting(group))
			{
				AssetManager.LoadProgramAssetList(group, this._remoteConfig.assetInfoListDict[group], new Action<string, List<RemoteConfig.AssetInfo>>(this.OnLoaded));
				this.ReportError("用户成功发起重连请求!", 10217602);
			}
		}

		private void OnLoaded(string group, List<RemoteConfig.AssetInfo> fileInfoList)
		{
			this._loadedGroupCount++;
			if (this._loadedGroupCount >= this._totalGroupCount)
			{
				CacheManager.WriteProgramAssetMeta();
			}
			this.CallGame("{\"type\":\"assetLoadComplete\",\"name\":\"" + group + "\"}");
			LuaStateManager.DoLuaFileInFileInfoList(group, fileInfoList);
		}

		public bool IsProgramAssetReady(string group)
		{
			return (this._remoteConfig != null || this._remoteConfig.assetInfoListDict.ContainsKey(group)) && CacheManager.IsProgramAssetExists(this._remoteConfig.assetInfoListDict[group]);
		}

		public RemoteConfig GetRemoteConfig()
		{
			return this._remoteConfig;
		}

		public void SetFont(Font font)
		{
			if (!this._fontDict.ContainsKey(font.name))
			{
				this._fontDict.Add(font.name, font);
			}
		}

		internal Font GetFont(string name)
		{
			if (this._fontDict.ContainsKey(name))
			{
				return this._fontDict[name];
			}
			Font font = Resources.Load<Font>("StaticUI/" + name);
			if (font != null)
			{
				this._fontDict.Add(name, font);
			}
			return font;
		}

		public void Do(Dictionary<string, string> commandDict)
		{
			CSharpInterface.GameCallLua(Json.Serialize(commandDict));
		}

		public void DoJson(string jsonStr)
		{
			CSharpInterface.GameCallLua(jsonStr);
		}

		public void ReportError(string error, int id = 0)
		{
			this.Report(error, id, 0);
		}

		public void Report(string content, int id, int type)
		{
			if (this._atmSocket != null)
			{
				this._atmSocket.Report(content, id, type);
			}
		}

		public static Dictionary<string, int> GetAssetReferenceCountDict()
		{
			return AssetPool.GetAssetReferenceCountDict();
		}

		public void Logout()
		{
			try
			{
				if (this._isInitialized)
				{
					if (this._atmSocket != null)
					{
						this._atmSocket.Close();
					}
					if (this._brokerSocket != null)
					{
						this._brokerSocket.Close();
					}
					this._userData.Clear();
					PanelManager.DestroyAll();
					LuaStateManager.Reset();
					AssetManager.Clear();
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Pandora Logout发生异常: " + ex.Message);
			}
		}
	}
}
