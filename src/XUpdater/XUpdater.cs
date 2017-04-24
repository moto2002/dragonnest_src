using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
	public sealed class XUpdater : XSingleton<XUpdater>
	{
		public static readonly uint Major_Version = 1u;

		private static XLaunchMode _launch_mode = XLaunchMode.Live;

		public static GameObject XGameRoot = null;

		public static Assembly Ass = Assembly.GetAssembly(typeof(GameObject));

		public static int Md5Length = 16;

		private int _main_threadId;

		private bool _bEditorMode;

		private bool _bFetchVersion;

		private bool _bFetchServer;

		private StringBuilder _log = new StringBuilder();

		private IEnumerator _downloader;

		private IEnumerator _download_prepare;

		private IEnumerator _comparer;

		private IEnumerator _launcher;

		private IEnumerator _finish;

		private byte[] _script;

		private bool _on_file_download_retry;

		private bool _on_file_download_need_retry;

		private bool _update_done;

		private bool _bundle_fetching;

		private bool _asset_loading;

		private XVersion _version_getter;

		private XBundle _bundle_getter;

		private XFileLog _filelog_getter;

		private IFMOD_Listener _fmod_listenter;

		private ITssSdk _tssSdk;

		private IApolloManager _apolloManager;

		private IBroardcast _broadcast;

		private ILuaEngine _lua_engine;

		private IXPandoraMgr _pandoraManager;

		private IXGameSirControl _SirControl;

		private IXVideo _video;

		private IPlatform _platform;

		private BuildTarget _runtime_platform;

		private string _platform_name = "";

		private string _version = "0.0.0";

		private string _target_version = "0.0.0";

		private bool _need_check_file;

		private XFetchVersionNetwork _fetch_version_network;

		private float _fetch_version_time;

		private ulong _update_pakcage_size;

		private XVersionData _server;

		private XVersionData _client;

		private XVersionData _buildin;

		private IResourceHelp _resourcehelp;

		private XBundleData _bundle_data;

		private eUPdatePhase _phase;

		private List<XBundleData> _download_bundle = new List<XBundleData>();

		private List<XBundleData> _cacheload_bundle = new List<XBundleData>();

		private List<XMetaResPackage> _meta_bundle = new List<XMetaResPackage>();

		private Dictionary<uint, UnityEngine.Object> _persist_assets = new Dictionary<uint, UnityEngine.Object>();

		private Dictionary<uint, byte[]> _persist_image = new Dictionary<uint, byte[]>();

		private Dictionary<uint, XBundleData> _assets = new Dictionary<uint, XBundleData>();

		private Dictionary<uint, XResPackage> _res_list = new Dictionary<uint, XResPackage>();

		private Dictionary<uint, AssetBundle> _bundles = new Dictionary<uint, AssetBundle>();

		public AssetBundleManager ABManager;

		private bool ABManagerIsDone;

		public static XLaunchMode LaunchMode
		{
			get
			{
				return XUpdater._launch_mode;
			}
		}

		public bool EditorMode
		{
			get
			{
				return this._bEditorMode;
			}
		}

		public string Version
		{
			get
			{
				return this._version;
			}
		}

		public string TargetVersion
		{
			get
			{
				return this._target_version;
			}
		}

		public bool NeedCheckFile
		{
			get
			{
				return this._need_check_file;
			}
		}

		public BuildTarget RunTimePlatform
		{
			get
			{
				return this._runtime_platform;
			}
		}

		public string Platform
		{
			get
			{
				return this._platform_name;
			}
		}

		public IPlatform XPlatform
		{
			get
			{
				return this._platform;
			}
		}

		public ILuaEngine XLuaEngine
		{
			get
			{
				return this._lua_engine;
			}
		}

		public IApolloManager XApolloManager
		{
			get
			{
				return this._apolloManager;
			}
		}

		public IBroardcast XBroadCast
		{
			get
			{
				return this._broadcast;
			}
		}

		public ITssSdk XTssSdk
		{
			get
			{
				return this._tssSdk;
			}
		}

		public IXPandoraMgr XPandoraManager
		{
			get
			{
				return this._pandoraManager;
			}
		}

		public IXGameSirControl GameSirControl
		{
			get
			{
				return this._SirControl;
			}
		}

		public IResourceHelp XResourceHelp
		{
			get
			{
				return this._resourcehelp;
			}
		}

		public bool IsDone
		{
			get
			{
				return this._update_done;
			}
		}

		internal eUPdatePhase Phase
		{
			set
			{
				this._phase = value;
			}
		}

		public int ManagedThreadId
		{
			get
			{
				return this._main_threadId;
			}
		}

		public bool Reboot
		{
			get;
			set;
		}

		public override bool Init()
		{
			this._main_threadId = Thread.CurrentThread.ManagedThreadId;
			this._bEditorMode = (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer);
			this.Reboot = false;
			XUpdater.XGameRoot = GameObject.Find("XGamePoint");
			this.GetLaunchMode();
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.IPhonePlayer)
			{
				if (platform != RuntimePlatform.Android)
				{
					this._runtime_platform = BuildTarget.Standalone;
					this._platform_name = (this.PatchPrefix() ?? "");
				}
				else
				{
					this._runtime_platform = BuildTarget.Android;
					this._platform_name = this.PatchPrefix() + "Android/";
				}
			}
			else
			{
				this._runtime_platform = BuildTarget.IOS;
				this._platform_name = this.PatchPrefix() + "IOS/";
			}
			this._version_getter = XUpdater.XGameRoot.AddComponent<XVersion>();
			this._bundle_getter = XUpdater.XGameRoot.AddComponent<XBundle>();
			this._filelog_getter = XUpdater.XGameRoot.AddComponent<XFileLog>();
			this._fmod_listenter = (GameObject.Find("Main Camera").GetComponent("FMOD_Listener") as IFMOD_Listener);
			this._tssSdk = (XUpdater.XGameRoot.GetComponent("TssSDKManager") as ITssSdk);
			this._apolloManager = (XUpdater.XGameRoot.GetComponent("ApolloManager") as IApolloManager);
			this._broadcast = (XUpdater.XGameRoot.GetComponent("BroadcastManager") as IBroardcast);
			this._platform = (XUpdater.XGameRoot.GetComponent("XPlatform") as IPlatform);
			this._video = (XUpdater.XGameRoot.GetComponent("XVideoMgr") as IXVideo);
			this._lua_engine = (XUpdater.XGameRoot.GetComponent("LuaEngine") as ILuaEngine);
			this._pandoraManager = (XUpdater.XGameRoot.GetComponent("XPandoraMgr") as IXPandoraMgr);
			this._SirControl = (XUpdater.XGameRoot.GetComponent("XGameSirControl") as IXGameSirControl);
			this._SirControl.Init();
			this.ABManager = XUpdater.XGameRoot.AddComponent<AssetBundleManager>();
			XSingleton<XDebug>.singleton.Init(this._platform, this._filelog_getter);
			XSingleton<XCaching>.singleton.Init();
			XSingleton<XLoadingUI>.singleton.Init();
			UnityEngine.Object.DontDestroyOnLoad(XUpdater.XGameRoot);
			return true;
		}

		public override void Uninit()
		{
			foreach (AssetBundle current in this._bundles.Values)
			{
				current.Unload(false);
			}
			this._assets.Clear();
			this._persist_assets.Clear();
			this._bundles.Clear();
			this._res_list.Clear();
			if (this._video != null && this._video.isPlaying)
			{
				this._video.Stop();
			}
			this._phase = eUPdatePhase.xUP_Prepare;
			this._update_done = false;
			if (this._fetch_version_network != null)
			{
				this._fetch_version_network.Close();
			}
			UnityEngine.Object.Destroy(XUpdater.XGameRoot);
		}

		public void Update()
		{
			switch (this._phase)
			{
			case eUPdatePhase.xUP_Prepare:
				if (this.Preparing())
				{
					this._phase = eUPdatePhase.xUP_FetchVersion;
				}
				else
				{
					XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHLOCALVERSIONERROR"), 255, 255, 255);
					this.OnError();
				}
				break;
			case eUPdatePhase.xUP_FetchVersion:
				if (!this._bFetchVersion)
				{
					if (this._fetch_version_network == null)
					{
						this._fetch_version_network = new XFetchVersionNetwork();
					}
					XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_FETCHVERSION"), 255, 255, 255);
					this._fetch_version_network.Init();
					string[] array = XSingleton<XCaching>.singleton.VersionServer.Split(new char[]
					{
						':'
					});
					if (this._fetch_version_network.Connect(array[0], int.Parse(array[1])))
					{
						this._bFetchVersion = true;
						this._fetch_version_time = Time.time;
					}
					else
					{
						XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHVERSIONERROR"), 255, 255, 255);
						XSingleton<XUpdater>.singleton.OnError();
						this._fetch_version_network.Close();
					}
				}
				else if (Time.time - this._fetch_version_time > 5f)
				{
					XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHVERSIONERROR"), 255, 255, 255);
					XSingleton<XUpdater>.singleton.OnError();
					this._fetch_version_network.Close();
				}
				break;
			case eUPdatePhase.xUP_LoadVersion:
				if (!this._bFetchServer)
				{
					this._cacheload_bundle.Clear();
					this._download_bundle.Clear();
					this._meta_bundle.Clear();
					this._version_getter.ServerDownload(new HandleVersionDownload(this.OnVersionDownloaded), new HandleVersionLoaded(this.OnVersionLoaded));
				}
				this._bFetchServer = true;
				break;
			case eUPdatePhase.xUP_CompareVersion:
				if (this._comparer == null)
				{
					this._comparer = this.VersionComparer();
				}
				else if (!this._comparer.MoveNext())
				{
					this._comparer = null;
				}
				break;
			case eUPdatePhase.xUP_DownLoadBundle:
				if (this._downloader == null)
				{
					this._downloader = this.DownLoadBundles();
				}
				else if (!this._downloader.MoveNext())
				{
					if (this._client.CompareTo(this._server) != 0)
					{
						XSingleton<XUpdater>.singleton.XApolloManager.SetGSDKEvent(2, true, "1-success");
					}
					this._downloader = null;
					this._phase = eUPdatePhase.xUP_ShowVersion;
				}
				break;
			case eUPdatePhase.xUP_ShowVersion:
				this.ShowVersionInfo(this._server, true);
				break;
			case eUPdatePhase.xUP_LaunchGame:
				if (this._launcher == null)
				{
					this._launcher = this.LaunchGame();
				}
				else if (!this._launcher.MoveNext())
				{
					this._launcher = null;
					this.OnEnding();
				}
				break;
			case eUPdatePhase.xUP_Finish:
				if (this._finish == null)
				{
					this._finish = this.Finish();
				}
				else if (!this._finish.MoveNext())
				{
					this._finish = null;
					this._update_done = true;
					XSingleton<XShell>.singleton.StartGame();
				}
				break;
			}
			XSingleton<XLoadingUI>.singleton.OnUpdate();
		}

		public void Begin()
		{
			this._update_done = false;
			this._bFetchVersion = false;
			this._bFetchServer = false;
			if (!XSingleton<XStringTable>.singleton.SyncInit())
			{
				this._log.Remove(0, this._log.Length);
				this._log.Append("Error occurred when loading string table.");
				XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
				XSingleton<XUpdater>.singleton.OnError();
				return;
			}
			if (!this.CheckMemory())
			{
				this._log.Remove(0, this._log.Length);
				this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_EXCLUDE1GPHONE"));
				XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
				XSingleton<XUpdater>.singleton.OnError();
				return;
			}
			if (XSingleton<XCaching>.singleton.EnableCache())
			{
				this._phase = eUPdatePhase.xUP_Prepare;
				return;
			}
			this._log.Remove(0, this._log.Length);
			this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_ACCESSDENIED"));
			XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			XSingleton<XUpdater>.singleton.OnError();
		}

		private IEnumerator Finish()
		{
			if (this._server != null)
			{
				this._server.Bundles.Clear();
				this._version = this._server.ToString();
			}
			this._server = null;
			this._client = null;
			this._buildin = null;
			if (this._video != null)
			{
				this._video.Play(false);
				yield return null;
				while (this._video.isPlaying)
				{
					yield return null;
				}
			}
			UnityEngine.Object.DestroyObject(this._version_getter);
			UnityEngine.Object.DestroyObject(this._bundle_getter);
			yield break;
		}

		public void OnError()
		{
			this._phase = eUPdatePhase.xUP_Error;
		}

		public void DevStart()
		{
			this._phase = eUPdatePhase.xUP_ShowVersion;
		}

		public void OnRetry()
		{
			eUPdatePhase phase = this._phase;
			if (phase != eUPdatePhase.xUP_DownLoadBundle)
			{
				switch (phase)
				{
				case eUPdatePhase.xUP_Finish:
					if (this._video.isPlaying)
					{
						this._video.Stop();
						return;
					}
					break;
				case eUPdatePhase.xUP_Error:
					if (this._server == null)
					{
						this.Begin();
						return;
					}
					break;
				default:
					return;
				}
			}
			else if (this._on_file_download_need_retry)
			{
				this._on_file_download_retry = true;
			}
		}

		private void OnEnding()
		{
			XSingleton<XLoadingUI>.singleton.LoadingOK = true;
			this._download_bundle.Clear();
			this._cacheload_bundle.Clear();
			this._meta_bundle.Clear();
			this._phase = eUPdatePhase.xUP_Ending;
		}

		public UnityEngine.Object ResourceLoad(uint hash)
		{
			UnityEngine.Object result = null;
			XResPackage xResPackage = null;
			if (this._res_list != null && this._res_list.TryGetValue(hash, out xResPackage) && !this._persist_assets.TryGetValue(hash, out result))
			{
				AssetBundle assetBundle = null;
				uint key = XSingleton<XCommon>.singleton.XHash(xResPackage.bundle);
				if (!this._bundles.TryGetValue(key, out assetBundle))
				{
					byte[] binary = null;
					if (!this._persist_image.TryGetValue(key, out binary))
					{
						XBundleData data = null;
						if (!this._assets.TryGetValue(key, out data))
						{
							return null;
						}
						binary = XSingleton<XCaching>.singleton.LoadFile(XSingleton<XCaching>.singleton.GetLocalPath(data));
					}
					assetBundle = AssetBundle.CreateFromMemoryImmediate(binary);
					this._bundles.Add(key, assetBundle);
				}
				string name = xResPackage.location.Substring(xResPackage.location.LastIndexOf('/') + 1);
				result = assetBundle.Load(name, XUpdater.Ass.GetType(xResPackage.type));
			}
			return result;
		}

		private AsyncVersionProcessRequest OnVersionDownloaded(TextAsset text)
		{
			AsyncVersionProcessRequest avpr = new AsyncVersionProcessRequest();
			XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_FETCHMANIFEST"), 255, 255, 255);
			if (text != null)
			{
				byte[] contents = text.bytes;
				new Thread(delegate
				{
					avpr.IsCorrect = this.LoadVersion(contents);
					avpr.IsDone = true;
				}).Start();
			}
			else
			{
				avpr.IsDone = true;
				avpr.IsCorrect = false;
			}
			return avpr;
		}

		private void OnVersionLoaded(bool correct)
		{
			if (correct)
			{
				this._phase = eUPdatePhase.xUP_CompareVersion;
				return;
			}
			this._log.Remove(0, this._log.Length);
			this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_MANIFESTERROR"));
			XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			XSingleton<XUpdater>.singleton.OnError();
		}

		private void OnBundleFetched(WWW www, byte[] bytes, XBundleData data, bool newdownload)
		{
			if (newdownload)
			{
				XSingleton<XDebug>.singleton.AddLog("Finished Download ", data.Name, null, null, null, null, XDebugColor.XDebug_None);
				this._log.Remove(0, this._log.Length);
				this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_DOWNLOAD_FILE_COMPLETE"), data.Name);
				XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Finished Extract ", data.Name, null, null, null, null, XDebugColor.XDebug_None);
				this._log.Remove(0, this._log.Length);
				this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_EXTRACTING_COMPLETE"), data.Name);
				XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			}
			uint key = XSingleton<XCommon>.singleton.XHash(data.Name);
			bool load = false;
			this._bundle_data = data;
			switch (this._bundle_data.Level)
			{
			case AssetLevel.Memory:
				load = true;
				break;
			case AssetLevel.Image:
			{
				byte[] array = new byte[bytes.Length];
				bytes.CopyTo(array, 0);
				this._persist_image.Add(key, array);
				break;
			}
			}
			this._assets.Add(key, this._bundle_data);
			this._bundle_getter.GetBundle(www, bytes, new HandleLoadBundle(this.OnBundleLoaded), load);
		}

		private void OnBundleLoaded(AssetBundle bundle)
		{
			if (bundle != null)
			{
				this._bundles.Add(XSingleton<XCommon>.singleton.XHash(this._bundle_data.Name), bundle);
			}
			this._bundle_fetching = false;
		}

		private void OnAssetLoaded(XResPackage package, UnityEngine.Object asset)
		{
			uint key = XSingleton<XCommon>.singleton.XHash(package.location);
			if (asset != null)
			{
				if (!this._persist_assets.ContainsKey(key))
				{
					this._persist_assets.Add(key, asset);
				}
				else
				{
					this._persist_assets[key] = asset;
				}
			}
			this._asset_loading = false;
		}

		private void UpdateLocalVersion(Stream s)
		{
			this._buildin = this.FetchBuildIn(s);
			this._client = this.FetchBuildOut();
			if (this._buildin != null)
			{
				XSingleton<XDebug>.singleton.AddLog("BuildIn version: ", this._buildin.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
			if (this._client != null)
			{
				XSingleton<XDebug>.singleton.AddLog("BuildOut version: ", this._client.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
			if (this._client == null)
			{
				this._client = new XVersionData(this._buildin);
				if (!XSingleton<XCaching>.singleton.CleanCache())
				{
					this._log.Remove(0, this._log.Length);
					this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DELETEDENIED"));
					XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
					XSingleton<XUpdater>.singleton.OnError();
				}
			}
			else
			{
				int num = this._client.CompareTo(this._buildin);
				if (num < 0)
				{
					this._client.VersionCopy(this._buildin);
					if (!XSingleton<XCaching>.singleton.CleanCache())
					{
						this._log.Remove(0, this._log.Length);
						this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DELETEDENIED"));
						XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
						XSingleton<XUpdater>.singleton.OnError();
					}
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Client version: ", this._client.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		private XVersionData FetchBuildIn(Stream s)
		{
			if (s == null)
			{
				return null;
			}
			StreamReader streamReader = new StreamReader(s);
			string version = streamReader.ReadToEnd();
			return XVersionData.Convert2Version(version);
		}

		private XVersionData FetchBuildOut()
		{
			string localVersion = XVersion.GetLocalVersion();
			XSingleton<XDebug>.singleton.AddLog("Local Version Path " + localVersion, null, null, null, null, null, XDebugColor.XDebug_None);
			XVersionData result = null;
			if (File.Exists(localVersion))
			{
				byte[] buffer = this.XCryptography(File.ReadAllBytes(localVersion));
				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(XVersionData));
					try
					{
						result = (xmlSerializer.Deserialize(memoryStream) as XVersionData);
					}
					catch (Exception ex)
					{
						result = null;
						XSingleton<XDebug>.singleton.AddLog("Build Out Version Fetching FAILED! " + ex.Message, null, null, null, null, null, XDebugColor.XDebug_None);
					}
					finally
					{
						memoryStream.Close();
					}
					return result;
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Local Version Path " + localVersion + " not exists.", null, null, null, null, null, XDebugColor.XDebug_None);
			return result;
		}

		private bool LoadVersion(byte[] text)
		{
			string a = BitConverter.ToString(text, 0, XUpdater.Md5Length);
			string b = XSingleton<XCaching>.singleton.CalculateMD5(text, XUpdater.Md5Length, text.Length - XUpdater.Md5Length);
			if (a == b)
			{
				using (MemoryStream memoryStream = new MemoryStream(text, XUpdater.Md5Length, text.Length - XUpdater.Md5Length))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(XVersionData));
					this._server = (xmlSerializer.Deserialize(memoryStream) as XVersionData);
					if (this._server != null && this._server.Target_Platform == this._runtime_platform)
					{
						XSingleton<XDebug>.singleton.AddLog("Server version: ", this._server.ToString(), null, null, null, null, XDebugColor.XDebug_None);
						return true;
					}
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Analysis Server version error!", null, null, null, null, null, XDebugColor.XDebug_None);
			this._server = null;
			return false;
		}

		private bool CheckMemory()
		{
			return true;
		}

		private bool Preparing()
		{
			Stream stream = null;
			XSingleton<XDebug>.singleton.AddLog("Fetch local version...", null, null, null, null, null, XDebugColor.XDebug_None);
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText("ios-version", false);
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText("android-version", false);
			}
			if (stream != null)
			{
				this.UpdateLocalVersion(stream);
				XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
				return true;
			}
			return XUpdater.LaunchMode == XLaunchMode.Dev;
		}

		private IEnumerator VersionComparer()
		{
			int num = this._client.CompareTo(this._server);
			this._update_pakcage_size = 0uL;
			if (num > 0)
			{
				this._server = this._client;
				this._download_prepare = null;
				this.DownLoadConfirmed(false);
			}
			else if (num == 0 || (num < 0 && this._client.CanUpdated(this._server)))
			{
				if (this._download_prepare == null)
				{
					this._download_prepare = this.DownLoadPrepare();
				}
				while (this._download_prepare.MoveNext())
				{
					yield return null;
				}
				this._download_prepare = null;
				this.DownLoadConfirmed(num != 0);
			}
			else
			{
				this._phase = eUPdatePhase.xUP_Error;
				XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH"), 255, 255, 255);
				this.ShowVersionInfo(this._client, false);
				XSingleton<XLoadingUI>.singleton.SetDownLoad(new XLoadingUI.OnSureCallBack(this.ToAppStore));
			}
			yield break;
		}

		private void ToAppStore()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.IPhonePlayer)
			{
				for (int i = 0; i < this._client.Res.Count; i++)
				{
					if (this._client.Res[i].location == "Table/StringTable")
					{
						XBundleData specificBundle = this._client.GetSpecificBundle(this._client.Res[i].bundle);
						string localPath = XSingleton<XCaching>.singleton.GetLocalPath(specificBundle);
						try
						{
							byte[] array = File.ReadAllBytes(localPath);
							if (array != null)
							{
								AssetBundle assetBundle = AssetBundle.CreateFromMemoryImmediate(array);
								if (assetBundle != null)
								{
									TextAsset textAsset = assetBundle.Load("StringTable", typeof(TextAsset)) as TextAsset;
									if (textAsset != null && !XSingleton<XStringTable>.singleton.ReInit(textAsset.bytes))
									{
										XSingleton<XStringTable>.singleton.SyncInit();
									}
								}
							}
							break;
						}
						catch (Exception ex)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("ToAppStore: ", ex.Message, null, null, null, null);
							break;
						}
					}
				}
				string @string = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_URL");
				XSingleton<XDebug>.singleton.AddLog("AppStore Url: ", @string, null, null, null, null, XDebugColor.XDebug_None);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["url"] = @string;
				dictionary["screendir"] = "SENSOR";
				this._platform.SendExtDara("open_url", Json.Serialize(dictionary));
				return;
			}
			if (platform != RuntimePlatform.Android)
			{
				return;
			}
			for (int j = 0; j < this._client.Res.Count; j++)
			{
				if (this._client.Res[j].location == "Table/StringTable")
				{
					XBundleData specificBundle2 = this._client.GetSpecificBundle(this._client.Res[j].bundle);
					string localPath2 = XSingleton<XCaching>.singleton.GetLocalPath(specificBundle2);
					try
					{
						byte[] array2 = File.ReadAllBytes(localPath2);
						if (array2 != null)
						{
							AssetBundle assetBundle2 = AssetBundle.CreateFromMemoryImmediate(array2);
							if (assetBundle2 != null)
							{
								TextAsset textAsset2 = assetBundle2.Load("StringTable", typeof(TextAsset)) as TextAsset;
								if (textAsset2 != null && !XSingleton<XStringTable>.singleton.ReInit(textAsset2.bytes))
								{
									XSingleton<XStringTable>.singleton.SyncInit();
								}
							}
						}
						break;
					}
					catch (Exception ex2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("ToAndroidAppStore: ", ex2.Message, null, null, null, null);
						break;
					}
				}
			}
			string string2 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_ANDROID_URL");
			XSingleton<XDebug>.singleton.AddLog("AndroidAppStore Url: ", string2, null, null, null, null, XDebugColor.XDebug_None);
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			dictionary2["url"] = string2;
			dictionary2["screendir"] = "SENSOR";
			this._platform.SendExtDara("open_url", Json.Serialize(dictionary2));
		}

		private void DownLoadConfirmedCallBack()
		{
			XSingleton<XUpdater>.singleton.XApolloManager.SetGSDKEvent(1, true, "1-success");
			this._phase = eUPdatePhase.xUP_DownLoadBundle;
		}

		private void DownLoadCancelledCallBack()
		{
			this._phase = eUPdatePhase.xUP_Error;
			XSingleton<XLoadingUI>.singleton.SetStatus("", 255, 255, 255);
			this.ShowVersionInfo(this._client, false);
		}

		private void DownLoadConfirmed(bool updated)
		{
			if (!updated)
			{
				XSingleton<XUpdater>.singleton.XApolloManager.SetGSDKEvent(1, true, "0");
				this._phase = eUPdatePhase.xUP_DownLoadBundle;
				return;
			}
			if (this._update_pakcage_size < 1048576uL)
			{
				this.DownLoadConfirmedCallBack();
				return;
			}
			XSingleton<XLoadingUI>.singleton.SetDialog(this._update_pakcage_size, new XLoadingUI.OnSureCallBack(this.DownLoadConfirmedCallBack), new XLoadingUI.OnSureCallBack(this.DownLoadCancelledCallBack));
			this._phase = eUPdatePhase.xUP_DownLoadConfirm;
		}

		private IEnumerator DownLoadPrepare()
		{
			for (int i = 0; i < this._server.Res.Count; i++)
			{
				if (this._buildin.NeedDownload(this._server.Res[i].bundle))
				{
					XBundleData specificBundle = this._server.GetSpecificBundle(this._server.Res[i].bundle);
					if (specificBundle == null)
					{
						XSingleton<XDebug>.singleton.AddLog("Bundle ", this._server.Res[i].bundle, " is missing in sever bundle set.", null, null, null, XDebugColor.XDebug_None);
					}
					else if (!this._cacheload_bundle.Contains(specificBundle) && !this._download_bundle.Contains(specificBundle))
					{
						AsyncCachedRequest asyncCachedRequest = XSingleton<XCaching>.singleton.IsBundleCached(specificBundle, this._server.MD5_Size);
						while (!asyncCachedRequest.IsDone)
						{
							yield return null;
						}
						if (!asyncCachedRequest.Cached && asyncCachedRequest.MaybeCached)
						{
							XBundleData xBundleData = null;
							foreach (XBundleData current in this._client.Bundles)
							{
								if (current.Name == specificBundle.Name)
								{
									xBundleData = current;
									break;
								}
							}
							asyncCachedRequest.Cached = (xBundleData != null && xBundleData.MD5 == specificBundle.MD5);
						}
						XSingleton<XDebug>.singleton.AddLog("Bundle ", specificBundle.Name, " cached is ", asyncCachedRequest.Cached.ToString(), null, null, XDebugColor.XDebug_None);
						if (asyncCachedRequest.Cached)
						{
							this._cacheload_bundle.Add(specificBundle);
						}
						else
						{
							this._download_bundle.Add(specificBundle);
							this._update_pakcage_size += (ulong)specificBundle.Size;
						}
					}
				}
			}
			this.MetaPrepare(this._server.AB);
			this.MetaPrepare(this._server.Scene);
			this.MetaPrepare(this._server.FMOD);
			yield break;
		}

		private void MetaPrepare(List<XMetaResPackage> meta)
		{
			bool flag = this._platform != null && !this._platform.IsPublish();
			for (int i = 0; i < meta.Count; i++)
			{
				if (this._buildin.NeedDownload(meta[i].bundle) && this._client.NeedDownload(meta[i].bundle))
				{
					if (!this._meta_bundle.Contains(meta[i]))
					{
						this._meta_bundle.Add(meta[i]);
					}
					if (flag)
					{
						XSingleton<XDebug>.singleton.AddLog("Meta ", meta[i].download, " is prepared to downloading...", null, null, null, XDebugColor.XDebug_None);
					}
					this._update_pakcage_size += (ulong)meta[i].Size;
				}
			}
		}

		private IEnumerator DownLoadBundles()
		{
			bool flag = this._platform != null && !this._platform.IsPublish();
			int num = this._download_bundle.Count + this._cacheload_bundle.Count + this._meta_bundle.Count;
			int num2 = 0;
			for (int i = 0; i < this._download_bundle.Count; i++)
			{
				while (this._bundle_fetching)
				{
					yield return null;
				}
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddLog("Updating ", this._download_bundle[i].Name, " ... ", num2.ToString(), "/", num.ToString(), XDebugColor.XDebug_None);
				}
				this._bundle_fetching = true;
				num2++;
				XSingleton<XCaching>.singleton.Download(this._download_bundle[i], new HandleFetchBundle(this.OnBundleFetched), (float)num2 / (float)num);
			}
			for (int j = 0; j < this._cacheload_bundle.Count; j++)
			{
				while (this._bundle_fetching)
				{
					yield return null;
				}
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddLog("Extracting ", this._cacheload_bundle[j].Name, " ... ", num2.ToString(), "/", num.ToString(), XDebugColor.XDebug_None);
				}
				this._bundle_fetching = true;
				num2++;
				if (Application.platform == RuntimePlatform.IPhonePlayer)
				{
					while (!XSingleton<XCaching>.singleton.Extract(this._cacheload_bundle[j], new HandleFetchBundle(this.OnBundleFetched), (float)num2 / (float)num))
					{
						yield return null;
					}
				}
				else
				{
					XSingleton<XCaching>.singleton.Extract(this._cacheload_bundle[j], new HandleFetchBundle(this.OnBundleFetched), (float)num2 / (float)num);
				}
			}
			while (this._bundle_fetching)
			{
				yield return null;
			}
			for (int k = 0; k < this._meta_bundle.Count; k++)
			{
				num2++;
				AsyncWriteRequest asyncWriteRequest = XSingleton<XCaching>.singleton.Download(this._meta_bundle[k].download, this._meta_bundle[k].Size, (float)num2 / (float)num);
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddLog("Download meta ", this._meta_bundle[k].download, " ... ", num2.ToString(), "/", num.ToString(), XDebugColor.XDebug_None);
				}
				while (!asyncWriteRequest.IsDone)
				{
					if (asyncWriteRequest.HasError)
					{
						if (this._on_file_download_retry)
						{
							this._on_file_download_retry = false;
							this._on_file_download_need_retry = false;
							k--;
							num2--;
							this._log.Length = 0;
							this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_RETRY"));
							XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
							yield return null;
							break;
						}
						this._on_file_download_need_retry = true;
						this._log.Length = 0;
						this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DOWNLOADRESFAILED_AND_RETRY"), asyncWriteRequest.Name);
						XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
						yield return null;
					}
					else
					{
						yield return null;
					}
				}
			}
			for (int l = 0; l < this._server.Res.Count; l++)
			{
				if (this.ProcessAssets(this._server.Res[l]))
				{
					if (this._server.Res[l].rtype != ResourceType.Script)
					{
						uint key = XSingleton<XCommon>.singleton.XHash(this._server.Res[l].location);
						this._res_list.Add(key, this._server.Res[l]);
					}
					this._log.Remove(0, this._log.Length);
					this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_PRELOADING"), ((float)l / (float)this._server.Res.Count * 100f).ToString("F0"));
					XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
					if (l << 30 == 0)
					{
						yield return null;
					}
				}
			}
			AsyncLogRequest asyncLogRequest = this.LogNewVersion();
			while (!asyncLogRequest.IsDone)
			{
				Thread.Sleep(1);
			}
			this.XPlatform.SetNoBackupFlag(XVersion.GetLocalVersion());
			yield break;
		}

		private AsyncLogRequest LogNewVersion()
		{
			AsyncLogRequest alr = new AsyncLogRequest();
			if (this._server != this._client)
			{
				new Thread(delegate
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						XmlSerializer xmlSerializer = new XmlSerializer(typeof(XVersionData));
						XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
						xmlSerializerNamespaces.Add(string.Empty, string.Empty);
						xmlSerializer.Serialize(memoryStream, this._server, xmlSerializerNamespaces);
						File.WriteAllBytes(XVersion.GetLocalVersion(), this.XCryptography(memoryStream.ToArray()));
					}
					alr.IsDone = true;
				}).Start();
			}
			else
			{
				alr.IsDone = true;
			}
			return alr;
		}

		private void ShowVersionInfo(XVersionData data, bool launch = true)
		{
			if (data != null)
			{
				this._log.Remove(0, this._log.Length);
				this._log.Append("v").Append(data.ToString());
				XSingleton<XLoadingUI>.singleton.SetVersion(this._log.ToString());
			}
			else
			{
				XSingleton<XLoadingUI>.singleton.SetVersion("Dev 0.0.0");
			}
			if (launch)
			{
				this._phase = eUPdatePhase.xUP_LaunchGame;
			}
		}

		private bool ProcessAssets(XResPackage res)
		{
			AssetBundle assetBundle = null;
			if (this._bundles.TryGetValue(XSingleton<XCommon>.singleton.XHash(res.bundle), out assetBundle))
			{
				string name = res.location.Substring(res.location.LastIndexOf('/') + 1);
				switch (res.rtype)
				{
				case ResourceType.Assets:
					this.OnAssetLoaded(res, assetBundle.Load(name, XUpdater.Ass.GetType(res.type)));
					break;
				case ResourceType.Script:
				{
					TextAsset textAsset = assetBundle.Load(name, XUpdater.Ass.GetType(res.type)) as TextAsset;
					this._script = textAsset.bytes;
					assetBundle.Unload(false);
					this._bundles.Remove(XSingleton<XCommon>.singleton.XHash(res.bundle));
					break;
				}
				}
				return true;
			}
			return false;
		}

		private IEnumerator AsyncProcessAssets(XResPackage package, AssetBundle bundle)
		{
			package.location.Substring(package.location.LastIndexOf('/') + 1);
			this._asset_loading = true;
			this._bundle_getter.GetAsset(bundle, package, new HandleLoadAsset(this.OnAssetLoaded));
			while (this._asset_loading)
			{
				yield return null;
			}
			yield break;
		}

		private IEnumerator LaunchGame()
		{
			XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_LOADING"), 255, 255, 255);
			yield return null;
			this.ABManagerIsDone = false;
			this.ABManager.Init(new Action(this.ABManagerDone));
			while (!this.ABManagerIsDone)
			{
				yield return null;
			}
			this._fmod_listenter.Reload();
			AsyncAssemblyRequest asyncAssemblyRequest = new AsyncAssemblyRequest();
			ResourceRequest resourceRequest = null;
			if (Application.platform == RuntimePlatform.Android && this._script == null && Application.platform == RuntimePlatform.Android)
			{
				resourceRequest = Resources.LoadAsync("XMainClient", typeof(TextAsset));
				yield return resourceRequest;
				this._script = (resourceRequest.asset as TextAsset).bytes;
			}
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.IPhonePlayer)
			{
				if (platform != RuntimePlatform.Android)
				{
				}
				asyncAssemblyRequest.Main = ((this._script == null) ? Assembly.Load("XMainClient") : Assembly.Load(this._script));
			}
			else
			{
				asyncAssemblyRequest.Main = Assembly.Load("XMainClient");
			}
			XSingleton<XShell>.singleton.MakeEntrance(asyncAssemblyRequest.Main);
			if (resourceRequest != null && resourceRequest.asset != null)
			{
				Resources.UnloadAsset(resourceRequest.asset);
			}
			this._script = null;
			this._log.Remove(0, this._log.Length);
			this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_LAUNCHING"));
			XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString(), 255, 255, 255);
			yield return null;
			XSingleton<XShell>.singleton.PreLaunch();
			while (!XSingleton<XShell>.singleton.Launched())
			{
				yield return null;
				XSingleton<XShell>.singleton.Launch();
			}
			this.XLuaEngine.InitLua();
			yield break;
		}

		private byte[] XCryptography(byte[] bs)
		{
			for (int i = 0; i < bs.Length; i++)
			{
				bs[i] ^= 153;
			}
			return bs;
		}

		private string PatchPrefix()
		{
			XLaunchMode launchMode = XUpdater.LaunchMode;
			switch (launchMode)
			{
			case XLaunchMode.Live:
				return "Patch/Live/";
			case XLaunchMode.PreProduct:
				return "Patch/PreProduct/";
			default:
				if (launchMode != XLaunchMode.Dev)
				{
					return "Patch/Live/";
				}
				return "Patch/Dev/";
			}
		}

		private void GetLaunchMode()
		{
			XUpdater._launch_mode = XLaunchMode.Live;
		}

		private void ABManagerDone()
		{
			this.ABManagerIsDone = true;
		}

		public void SetServerVersion(string data)
		{
			string[] array = data.Split(new char[]
			{
				'|'
			});
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.IPhonePlayer)
			{
				if (platform == RuntimePlatform.Android)
				{
					this._target_version = array[1];
				}
			}
			else
			{
				this._target_version = array[0];
			}
			try
			{
				if (array.Length > 2)
				{
					this._need_check_file = (array[2] == "1");
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GetServer CheckFile Flag Error!!!   " + ex.Message, null, null, null, null, null);
			}
			XSingleton<XDebug>.singleton.AddGreenLog(data, null, null, null, null, null);
			this._fetch_version_network.Close();
			this._phase = eUPdatePhase.xUP_LoadVersion;
		}
	}
}
