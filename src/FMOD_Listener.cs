using FMOD;
using FMOD.Studio;
using System;
using System.IO;
using UnityEngine;
using XUtliPoolLib;

public class FMOD_Listener : MonoBehaviour, IFMOD_Listener
{
	public string[] pluginPaths = new string[0];

	private Rigidbody cachedRigidBody;

	private bool gui;

	private string pluginPath
	{
		get
		{
			if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				return Application.dataPath + "/Plugins/x86";
			}
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXDashboardPlayer || Application.platform == RuntimePlatform.LinuxPlayer)
			{
				return Application.dataPath + "/Plugins";
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				UnityUtil.LogError("DSP Plugins not currently supported on iOS, contact support@fmod.org for more information");
				return string.Empty;
			}
			if (Application.platform == RuntimePlatform.Android)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
				string name = directoryInfo.Parent.Name;
				return "/data/data/" + name + "/lib";
			}
			UnityUtil.LogError("Unknown platform!");
			return string.Empty;
		}
	}

	private void OnEnable()
	{
		this.Initialize();
		this.cachedRigidBody = base.GetComponent<Rigidbody>();
		this.Update3DAttributes();
	}

	private void OnDisable()
	{
	}

	private void loadBank(string fileName)
	{
		Bank a = null;
		RESULT rESULT = RESULT.OK;
		string text = string.Format("{0}/update/AssetBundles/{1}", Application.persistentDataPath, fileName);
		if (File.Exists(text))
		{
			rESULT = FMOD_StudioSystem.instance.System.loadBankFile(text, LOAD_BANK_FLAGS.NORMAL, out a);
		}
		else if (Path.GetExtension(Application.dataPath) != ".apk")
		{
			string url = string.Format("jar:file://{0}!/assets/{1}", Application.dataPath, fileName);
			using (WWW wWW = new WWW(url))
			{
				while (!wWW.isDone)
				{
				}
				if (!string.IsNullOrEmpty(wWW.error))
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Bank {0} encountered a loading error {1}", fileName, wWW.error), null, null, null, null, null);
					rESULT = RESULT.ERR_EVENT_ALREADY_LOADED;
				}
				else
				{
					rESULT = FMOD_StudioSystem.instance.System.loadBankMemory(wWW.bytes, LOAD_BANK_FLAGS.NORMAL, out a);
				}
			}
		}
		else
		{
			string streamingAsset = this.getStreamingAsset(fileName);
			rESULT = FMOD_StudioSystem.instance.System.loadBankFile(streamingAsset, LOAD_BANK_FLAGS.NORMAL, out a);
		}
		if (rESULT == RESULT.ERR_VERSION)
		{
			XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Bank {0} built with an incompatible version of FMOD Studio.", fileName), null, null, null, null, null);
		}
		else if (rESULT != RESULT.ERR_EVENT_ALREADY_LOADED)
		{
			if (rESULT != RESULT.OK)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Bank {0} encountered a loading error {1}", fileName, rESULT.ToString()), null, null, null, null, null);
			}
		}
		UnityUtil.Log("bank load: " + ((!(a != null)) ? "failed!!" : "suceeded"));
	}

	private string getStreamingAsset(string fileName)
	{
		string str = string.Empty;
		if (Application.platform == RuntimePlatform.Android)
		{
			str = "file:///android_asset";
		}
		else if (Application.platform == RuntimePlatform.MetroPlayerARM || Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64)
		{
			str = "ms-appx:///Data/StreamingAssets";
		}
		else
		{
			str = Application.streamingAssetsPath;
		}
		return str + "/" + fileName;
	}

	private void Initialize()
	{
		if (FMOD_StudioSystem.isInitialized)
		{
			return;
		}
		UnityUtil.Log("Initialize Listener");
		this.LoadPlugins();
		string text = Application.streamingAssetsPath + "/FMOD_bank_list.txt";
		UnityUtil.Log("Loading Banks");
		try
		{
			string localBankListPath = this.GetLocalBankListPath();
			string text2 = string.Format("{0}/update/AssetBundles/FMOD_bank_list.cfg", Application.persistentDataPath);
			string path;
			if (File.Exists(text2))
			{
				path = text2;
			}
			else
			{
				path = localBankListPath;
			}
			AssetBundle assetBundle = AssetBundle.CreateFromFile(path);
			TextAsset textAsset = assetBundle.mainAsset as TextAsset;
			string[] array = textAsset.text.Split(new char[]
			{
				'\n'
			});
			assetBundle.Unload(false);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != string.Empty)
				{
					array[i] = array[i].Replace("\r", string.Empty);
				}
			}
		}
		catch (Exception ex)
		{
			UnityUtil.LogError(string.Concat(new string[]
			{
				"Cannot read ",
				text,
				": ",
				ex.Message,
				" : No banks loaded."
			}));
		}
	}

	private string GetLocalBankListPath()
	{
		string result;
		switch (Application.platform)
		{
		case RuntimePlatform.IPhonePlayer:
			result = string.Format("{0}/Raw/FMOD_bank_list.cfg", Application.dataPath);
			return result;
		case RuntimePlatform.Android:
			result = string.Format("{0}!assets/FMOD_bank_list.cfg", Application.dataPath);
			return result;
		}
		result = string.Format("{0}/StreamingAssets/FMOD_bank_list.cfg", Application.dataPath);
		return result;
	}

	private void Start()
	{
	}

	private void Update()
	{
		this.Update3DAttributes();
		if (Input.GetKeyUp(KeyCode.F6))
		{
			this.gui = !this.gui;
		}
	}

	private void Update3DAttributes()
	{
		FMOD.Studio.System system = FMOD_StudioSystem.instance.System;
		if (system != null && system.isValid())
		{
			FMOD.Studio.ATTRIBUTES_3D attributes = UnityUtil.to3DAttributes(base.gameObject, this.cachedRigidBody);
			this.ERRCHECK(system.setListenerAttributes(0, attributes));
		}
	}

	private void LoadPlugins()
	{
		FMOD.System system = null;
		this.ERRCHECK(FMOD_StudioSystem.instance.System.getLowLevelSystem(out system));
		if (Application.platform == RuntimePlatform.IPhonePlayer && this.pluginPaths.Length != 0)
		{
			UnityUtil.LogError("DSP Plugins not currently supported on iOS, contact support@fmod.org for more information");
			return;
		}
		string[] array = this.pluginPaths;
		for (int i = 0; i < array.Length; i++)
		{
			string rawName = array[i];
			string text = this.pluginPath + "/" + this.GetPluginFileName(rawName);
			UnityUtil.Log("Loading plugin: " + text);
			if (!File.Exists(text))
			{
			}
			uint num;
			this.ERRCHECK(system.loadPlugin(text, out num));
		}
	}

	private string GetPluginFileName(string rawName)
	{
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			return rawName + ".dll";
		}
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXDashboardPlayer)
		{
			return rawName + ".dylib";
		}
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.LinuxPlayer)
		{
			return "lib" + rawName + ".so";
		}
		UnityUtil.LogError("Unknown platform!");
		return string.Empty;
	}

	private void ERRCHECK(RESULT result)
	{
		UnityUtil.ERRCHECK(result);
	}

	public void Reload()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- Reload -------------------------</color>");
		string text = Application.streamingAssetsPath + "/FMOD_bank_list.txt";
		UnityUtil.Log("Loading Banks");
		try
		{
			string localBankListPath = this.GetLocalBankListPath();
			string text2 = string.Format("{0}/update/AssetBundles/FMOD_bank_list.cfg", Application.persistentDataPath);
			string path;
			if (File.Exists(text2))
			{
				path = text2;
			}
			else
			{
				path = localBankListPath;
			}
			AssetBundle assetBundle = AssetBundle.CreateFromFile(path);
			TextAsset textAsset = assetBundle.mainAsset as TextAsset;
			string[] array = textAsset.text.Split(new char[]
			{
				'\n'
			});
			assetBundle.Unload(false);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != string.Empty)
				{
					array[i] = array[i].Replace("\r", string.Empty);
					this.LoadBank(array[i]);
				}
			}
		}
		catch (Exception ex)
		{
			UnityUtil.LogError(string.Concat(new string[]
			{
				"Cannot read ",
				text,
				": ",
				ex.Message,
				" : No banks loaded."
			}));
		}
	}

	private void OutputMemoryInfo()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- MemoryInfo -------------------------</color>");
		float num = 1048576f;
		int num2 = 0;
		int num3 = 0;
		Memory.GetStats(out num2, out num3);
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"currentalloced:",
			(float)num2 / num,
			"MB  maxalloced:",
			(float)num3 / num,
			"MB  "
		}));
	}

	private void OutputCPUInfo()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- CPUInfo -------------------------</color>");
		CPU_USAGE cPU_USAGE;
		FMOD_StudioSystem.instance.System.getCPUUsage(out cPU_USAGE);
		UnityEngine.Debug.Log(string.Format("dspUsage: {0},studioUsage: {1},streamUsage: {2}, geometryUsage: {3}, updateUsage: {4}", new object[]
		{
			cPU_USAGE.dspUsage,
			cPU_USAGE.studioUsage,
			cPU_USAGE.streamUsage,
			cPU_USAGE.geometryUsage,
			cPU_USAGE.updateUsage
		}));
	}

	private void OutputBanksInfo()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- BanksInfo -------------------------</color>");
		Bank[] array;
		FMOD_StudioSystem.instance.System.getBankList(out array);
		UnityEngine.Debug.Log("bank cnt: " + array.Length);
		Bank[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Bank bank = array2[i];
			string text;
			bank.getPath(out text);
			int num;
			bank.getBusCount(out num);
			int num2;
			bank.getEventCount(out num2);
			UnityEngine.Debug.Log(string.Concat(new object[]
			{
				text,
				" bus cnt:",
				num,
				" evt cnt:",
				num2
			}));
			EventDescription[] array3;
			this.ERRCHECK(bank.getEventList(out array3));
			string text2 = text;
			for (int j = 0; j < array3.Length; j++)
			{
				string empty = string.Empty;
				array3[j].getPath(out empty);
				string text3 = text2;
				text2 = string.Concat(new object[]
				{
					text3,
					j,
					":",
					empty,
					"\n "
				});
			}
			UnityEngine.Debug.Log(text2);
		}
	}

	private void OutputSetInfo()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- SettingInfo -------------------------</color>");
		FMOD.System system = null;
		this.ERRCHECK(FMOD_StudioSystem.instance.System.getLowLevelSystem(out system));
		FMOD.ADVANCEDSETTINGS aDVANCEDSETTINGS = default(FMOD.ADVANCEDSETTINGS);
		int num;
		SPEAKERMODE sPEAKERMODE;
		int num2;
		this.ERRCHECK(system.getSoftwareFormat(out num, out sPEAKERMODE, out num2));
		int num3;
		this.ERRCHECK(system.getSoftwareChannels(out num3));
		this.ERRCHECK(system.getAdvancedSettings(ref aDVANCEDSETTINGS));
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"sample rate: ",
			num,
			" mode:",
			sPEAKERMODE,
			" numraw:",
			num2,
			" channels:",
			num3
		}));
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"set cbSize: ",
			aDVANCEDSETTINGS.cbSize,
			" maxMPEG:",
			aDVANCEDSETTINGS.maxMPEGCodecs,
			" stackStream:",
			aDVANCEDSETTINGS.stackSizeStream,
			" stackMix:",
			aDVANCEDSETTINGS.stackSizeMixer,
			" stackNonBlock:",
			aDVANCEDSETTINGS.stackSizeNonBlocking,
			" sample:",
			aDVANCEDSETTINGS.resamplerMethod
		}));
	}

	private void LimitSoftChannels(int num)
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- LimitSoftChannels -------------------------</color>");
		UnityEngine.Debug.Log("Limit Channel to " + num);
		FMOD.System system = null;
		this.ERRCHECK(FMOD_StudioSystem.instance.System.getLowLevelSystem(out system));
		this.ERRCHECK(system.setSoftwareChannels(num));
	}

	private void UnloadBanks()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- UnloadBanks -------------------------</color>");
		Bank[] array;
		FMOD_StudioSystem.instance.System.getBankList(out array);
		UnityEngine.Debug.Log("bank cnt: " + array.Length);
		Bank[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Bank bank = array2[i];
			string str;
			bank.getPath(out str);
			UnityEngine.Debug.Log("unload=>" + str);
			bank.unload();
		}
	}

	private void UnloadAll()
	{
		UnityEngine.Debug.Log("Unload Fmod");
		FMOD_StudioSystem.instance.System.unloadAll();
		this.OutputMemoryInfo();
	}

	private void LoadBank(string bankName)
	{
		UnityEngine.Debug.Log("load bank " + bankName);
		try
		{
			this.loadBank(bankName);
			FMOD_StudioSystem.instance.System.flushCommands();
		}
		catch (Exception ex)
		{
			UnityUtil.LogError(string.Concat(new string[]
			{
				"Cannot read ",
				bankName,
				": ",
				ex.Message,
				" : No banks loaded."
			}));
		}
	}
}
