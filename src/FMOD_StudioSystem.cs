using FMOD;
using FMOD.Studio;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_StudioSystem : MonoBehaviour
{
	private FMOD.Studio.System system;

	private Dictionary<string, EventDescription> eventDescriptions = new Dictionary<string, EventDescription>();

	public static bool isInitialized;

	private static FMOD_StudioSystem sInstance;

	public static FMOD_StudioSystem instance
	{
		get
		{
			if (FMOD_StudioSystem.sInstance == null)
			{
				GameObject gameObject = new GameObject("FMOD_StudioSystem");
				FMOD_StudioSystem.sInstance = gameObject.AddComponent<FMOD_StudioSystem>();
				if (!UnityUtil.ForceLoadLowLevelBinary())
				{
					UnityUtil.LogError("Unable to load low level binary!");
					return FMOD_StudioSystem.sInstance;
				}
				FMOD_StudioSystem.sInstance.Init();
			}
			return FMOD_StudioSystem.sInstance;
		}
	}

	public FMOD.Studio.System System
	{
		get
		{
			return this.system;
		}
	}

	public void OutputEventsInfo()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- OutputEventsInfo -------------------------</color>");
		UnityEngine.Debug.Log("events cnt: " + this.eventDescriptions.Count);
		foreach (KeyValuePair<string, EventDescription> current in this.eventDescriptions)
		{
			bool flag;
			FMOD_StudioSystem.ERRCHECK(current.Value.is3D(out flag));
			bool flag2;
			FMOD_StudioSystem.ERRCHECK(current.Value.isStream(out flag2));
			EventInstance[] array;
			FMOD_StudioSystem.ERRCHECK(current.Value.getInstanceList(out array));
			string text = "instance info:";
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					EventDescription eventDescription;
					array[i].getDescription(out eventDescription);
					string str;
					eventDescription.getPath(out str);
					text = text + str + " ";
				}
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"key: ",
					current.Key,
					" 3d:",
					flag,
					" isstream:",
					flag2,
					" instances cnt:",
					array.Length,
					" detail: ",
					text
				}));
			}
			else
			{
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"key: ",
					current.Key,
					" 3d:",
					flag,
					" isstream:",
					flag2,
					" instances cnt:0"
				}));
			}
		}
	}

	public void OutputCurrEventsInfo()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- OutputCurrEventsInfo -------------------------</color>");
		int num = 0;
		foreach (KeyValuePair<string, EventDescription> current in this.eventDescriptions)
		{
			int num2 = 0;
			FMOD_StudioSystem.ERRCHECK(current.Value.getInstanceCount(out num2));
			if (num2 > 0)
			{
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"key: ",
					current.Key,
					" instance cnt:",
					num2
				}));
				num++;
			}
		}
		UnityEngine.Debug.Log("RESULT, CNT IS: " + num);
	}

	public void UnloadAllEventsInstances()
	{
		UnityEngine.Debug.Log("<color=yellow>------------------------- UnloadAllEventsInstances -------------------------</color>");
		foreach (KeyValuePair<string, EventDescription> current in this.eventDescriptions)
		{
			EventInstance[] array;
			FMOD_StudioSystem.ERRCHECK(current.Value.getInstanceList(out array));
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i].release();
				}
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"key: ",
					current.Key,
					" instance cnt:",
					array.Length
				}));
			}
		}
	}

	public EventInstance GetEvent(FMODAsset asset)
	{
		return this.GetEvent(asset.id);
	}

	public EventInstance GetEvent(string path)
	{
		EventInstance eventInstance = null;
		if (string.IsNullOrEmpty(path))
		{
			UnityUtil.LogError("Empty event path!");
			return null;
		}
		if (this.eventDescriptions.ContainsKey(path) && this.eventDescriptions[path].isValid())
		{
			FMOD_StudioSystem.ERRCHECK(this.eventDescriptions[path].createInstance(out eventInstance));
		}
		else
		{
			Guid guid = default(Guid);
			if (path.StartsWith("{"))
			{
				FMOD_StudioSystem.ERRCHECK(Util.ParseID(path, out guid));
			}
			else if (path.StartsWith("event:") || path.StartsWith("snapshot:"))
			{
				FMOD_StudioSystem.ERRCHECK(this.system.lookupID(path, out guid));
			}
			else
			{
				UnityUtil.LogError("Expected event path to start with 'event:/' or 'snapshot:/'");
			}
			EventDescription eventDescription = null;
			FMOD_StudioSystem.ERRCHECK(this.system.getEventByID(guid, out eventDescription));
			if (eventDescription != null && eventDescription.isValid())
			{
				this.eventDescriptions[path] = eventDescription;
				FMOD_StudioSystem.ERRCHECK(eventDescription.createInstance(out eventInstance));
			}
		}
		if (eventInstance == null)
		{
			UnityUtil.Log("GetEvent FAILED: \"" + path + "\"");
		}
		return eventInstance;
	}

	public void PlayOneShot(FMODAsset asset, Vector3 position)
	{
		this.PlayOneShot(asset.id, position);
	}

	public void PlayOneShot(string path, Vector3 position)
	{
		this.PlayOneShot(path, position, 1f);
	}

	public void PlayOneShot(string path, Vector3 position, float volume)
	{
		EventInstance @event = this.GetEvent(path);
		if (@event == null)
		{
			UnityUtil.LogWarning("PlayOneShot couldn't find event: \"" + path + "\"");
			return;
		}
		FMOD.Studio.ATTRIBUTES_3D attributes = position.to3DAttributes();
		FMOD_StudioSystem.ERRCHECK(@event.set3DAttributes(attributes));
		FMOD_StudioSystem.ERRCHECK(@event.setVolume(volume));
		FMOD_StudioSystem.ERRCHECK(@event.start());
		FMOD_StudioSystem.ERRCHECK(@event.release());
	}

	public Bus GetBus(string strBus)
	{
		Bus bus = null;
		FMOD_StudioSystem.ERRCHECK(this.system.getBus(strBus, out bus));
		if (bus == null)
		{
			UnityUtil.Log("GetBus FAILED!!!");
		}
		return bus;
	}

	public VCA GetVCA(string path)
	{
		VCA vCA = null;
		FMOD_StudioSystem.ERRCHECK(this.system.getVCA(path, out vCA));
		if (vCA == null)
		{
			UnityUtil.Log("GetVCA FAILED!!!");
		}
		return vCA;
	}

	private void Init()
	{
		UnityUtil.Log("FMOD_StudioSystem: Initialize");
		if (FMOD_StudioSystem.isInitialized)
		{
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UnityUtil.Log("FMOD_StudioSystem: System_Create");
		FMOD_StudioSystem.ERRCHECK(FMOD.Studio.System.create(out this.system));
		FMOD.Studio.INITFLAGS iNITFLAGS = FMOD.Studio.INITFLAGS.NORMAL;
		FMOD.System system;
		FMOD_StudioSystem.ERRCHECK(this.system.getLowLevelSystem(out system));
		FMOD.ADVANCEDSETTINGS aDVANCEDSETTINGS = default(FMOD.ADVANCEDSETTINGS);
		aDVANCEDSETTINGS.randomSeed = (uint)DateTime.Now.Ticks;
		FMOD_StudioSystem.ERRCHECK(system.setAdvancedSettings(ref aDVANCEDSETTINGS));
		UnityUtil.Log("FMOD_StudioSystem: system.init");
		RESULT rESULT = this.system.initialize(1024, iNITFLAGS, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
		if (rESULT == RESULT.ERR_HEADER_MISMATCH)
		{
			UnityUtil.LogError("Version mismatch between C# script and FMOD binary, restart Unity and reimport the integration package to resolve this issue.");
		}
		else
		{
			FMOD_StudioSystem.ERRCHECK(rESULT);
		}
		FMOD_StudioSystem.ERRCHECK(this.system.flushCommands());
		rESULT = this.system.update();
		if (rESULT == RESULT.ERR_NET_SOCKET_ERROR)
		{
			UnityUtil.LogWarning("LiveUpdate disabled: socket in already in use");
			iNITFLAGS &= ~FMOD.Studio.INITFLAGS.LIVEUPDATE;
			FMOD_StudioSystem.ERRCHECK(this.system.release());
			FMOD_StudioSystem.ERRCHECK(FMOD.Studio.System.create(out this.system));
			FMOD_StudioSystem.ERRCHECK(this.system.getLowLevelSystem(out system));
			aDVANCEDSETTINGS = default(FMOD.ADVANCEDSETTINGS);
			aDVANCEDSETTINGS.randomSeed = (uint)DateTime.Now.Ticks;
			FMOD_StudioSystem.ERRCHECK(system.setAdvancedSettings(ref aDVANCEDSETTINGS));
			rESULT = this.system.initialize(1024, iNITFLAGS, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
			FMOD_StudioSystem.ERRCHECK(rESULT);
		}
		FMOD_StudioSystem.isInitialized = true;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (this.system != null && this.system.isValid())
		{
			UnityUtil.Log("Pause state changed to: " + pauseStatus);
			FMOD.System system;
			FMOD_StudioSystem.ERRCHECK(this.system.getLowLevelSystem(out system));
			if (system == null)
			{
				UnityUtil.LogError("Tried to suspend mixer, but no low level system found");
				return;
			}
			if (pauseStatus)
			{
				FMOD_StudioSystem.ERRCHECK(system.mixerSuspend());
			}
			else
			{
				FMOD_StudioSystem.ERRCHECK(system.mixerResume());
			}
		}
	}

	private void Update()
	{
		if (FMOD_StudioSystem.isInitialized && this.system != null)
		{
			FMOD_StudioSystem.ERRCHECK(this.system.update());
		}
	}

	private void OnDisable()
	{
		if (FMOD_StudioSystem.isInitialized)
		{
			UnityUtil.Log("__ SHUT DOWN FMOD SYSTEM __");
			if (this.system != null)
			{
				this.system.release();
			}
			if (this == FMOD_StudioSystem.sInstance)
			{
				FMOD_StudioSystem.sInstance = null;
			}
		}
	}

	private static bool ERRCHECK(RESULT result)
	{
		return UnityUtil.ERRCHECK(result);
	}
}
