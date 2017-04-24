using FMOD.Studio;
using System;
using UnityEngine;
using XUtliPoolLib;

public class XFmodBus : MonoBehaviour, IXInterface, IXFmodBus
{
	private Bus bus;

	private VCA mainVCA;

	private VCA bgmVCA;

	private VCA sfxVCA;

	private FMOD_StudioEventEmitter e;

	public bool Deprecated
	{
		get;
		set;
	}

	public void SetBusVolume(string strBus, float volume)
	{
		Bus bus = FMOD_StudioSystem.instance.GetBus(strBus);
		if (bus != null)
		{
			bus.setFaderLevel(volume);
		}
	}

	public void SetMainVolume(float volume)
	{
		if (this.mainVCA == null)
		{
			this.mainVCA = FMOD_StudioSystem.instance.GetVCA("vca:/Main Volume Control");
		}
		if (this.mainVCA != null)
		{
			this.mainVCA.setFaderLevel(volume);
		}
	}

	public void SetBGMVolume(float volume)
	{
		if (this.bgmVCA == null)
		{
			this.bgmVCA = FMOD_StudioSystem.instance.GetVCA("vca:/BGM Volume Control");
		}
		if (this.bgmVCA != null)
		{
			this.bgmVCA.setFaderLevel(volume);
		}
	}

	public void SetSFXVolume(float volume)
	{
		if (this.sfxVCA == null)
		{
			this.sfxVCA = FMOD_StudioSystem.instance.GetVCA("vca:/SFX Volume Control");
		}
		if (this.sfxVCA != null)
		{
			this.sfxVCA.setFaderLevel(volume);
		}
	}

	public void PlayOneShot(string key, Vector3 pos)
	{
		FMOD_StudioSystem.instance.PlayOneShot(key, pos);
	}

	public void StartEvent(string key)
	{
		if (this.e == null)
		{
			this.e = base.gameObject.AddComponent<FMOD_StudioEventEmitter>();
		}
		this.e.path = key;
		this.e.CacheEventInstance();
		this.e.StartEvent();
	}

	public void StopEvent()
	{
		if (this.e == null)
		{
			return;
		}
		this.e.Stop(STOP_MODE.ALLOWFADEOUT);
	}
}
