using FMOD.Studio;
using System;
using UnityEngine;
using XUtliPoolLib;

public class XFmod : MonoBehaviour, IXInterface, IXFmod
{
	private FMOD_StudioEventEmitter _emitter;

	private FMOD_StudioEventEmitter _emitter2;

	private FMOD_StudioEventEmitter _emitter3;

	private FMOD_StudioEventEmitter _emitter4;

	private FMOD_StudioEventEmitter _emitter5;

	private Vector3 _3dPos = Vector3.zero;

	public bool Deprecated
	{
		get;
		set;
	}

	public void Destroy()
	{
		if (this._emitter != null)
		{
			UnityEngine.Object.Destroy(this._emitter);
			this._emitter = null;
		}
		if (this._emitter2 != null)
		{
			UnityEngine.Object.Destroy(this._emitter2);
			this._emitter2 = null;
		}
		if (this._emitter3 != null)
		{
			UnityEngine.Object.Destroy(this._emitter3);
			this._emitter3 = null;
		}
		if (this._emitter4 != null)
		{
			UnityEngine.Object.Destroy(this._emitter4);
			this._emitter4 = null;
		}
	}

	public bool IsPlaying(AudioChannel channel)
	{
		FMOD_StudioEventEmitter emitter = this.GetEmitter(channel);
		return !emitter.HasFinished();
	}

	public void StartEvent(string key, AudioChannel channel = AudioChannel.Action, bool stopPre = true, string para = "", float value = 0f)
	{
		FMOD_StudioEventEmitter emitter = this.GetEmitter(channel);
		if (stopPre)
		{
			emitter.OnDestroy();
		}
		if (!string.IsNullOrEmpty(key))
		{
			emitter.path = key;
		}
		emitter.CacheEventInstance();
		this.SetParamValue(channel, para, value);
		if (this._3dPos != Vector3.zero)
		{
			emitter.Update3DAttributes(this._3dPos);
			this._3dPos = Vector3.zero;
		}
		emitter.StartEvent();
	}

	public void Play(AudioChannel channel = AudioChannel.Action)
	{
		FMOD_StudioEventEmitter emitter = this.GetEmitter(channel);
		if (emitter != null)
		{
			emitter.Play();
		}
	}

	public void Stop(AudioChannel channel = AudioChannel.Action)
	{
		FMOD_StudioEventEmitter emitter = this.GetEmitter(channel);
		if (emitter != null)
		{
			emitter.Stop(STOP_MODE.ALLOWFADEOUT);
		}
	}

	public void PlayOneShot(string key, Vector3 pos)
	{
		FMOD_StudioSystem.instance.PlayOneShot(key, pos);
	}

	public void Update3DAttributes(Vector3 vec, AudioChannel channel = AudioChannel.Action)
	{
		this._3dPos = vec;
	}

	public void SetParamValue(AudioChannel channel, string param, float value)
	{
		if (!string.IsNullOrEmpty(param))
		{
			FMOD_StudioEventEmitter emitter = this.GetEmitter(channel);
			emitter.SetParamValue(param, value);
		}
	}

	public FMOD_StudioEventEmitter GetEmitter(AudioChannel channel)
	{
		switch (channel)
		{
		case AudioChannel.Motion:
			if (this._emitter2 == null)
			{
				this._emitter2 = base.gameObject.AddComponent<FMOD_StudioEventEmitter>();
			}
			return this._emitter2;
		case AudioChannel.Action:
			if (this._emitter == null)
			{
				this._emitter = base.gameObject.AddComponent<FMOD_StudioEventEmitter>();
			}
			return this._emitter;
		case (AudioChannel)3:
		case (AudioChannel)5:
		case (AudioChannel)6:
		case (AudioChannel)7:
			IL_2A:
			if (channel != AudioChannel.SkillCombine)
			{
				return null;
			}
			if (this._emitter5 == null)
			{
				this._emitter5 = base.gameObject.AddComponent<FMOD_StudioEventEmitter>();
			}
			return this._emitter5;
		case AudioChannel.Skill:
			if (this._emitter3 == null)
			{
				this._emitter3 = base.gameObject.AddComponent<FMOD_StudioEventEmitter>();
			}
			return this._emitter3;
		case AudioChannel.Behit:
			if (this._emitter4 == null)
			{
				this._emitter4 = base.gameObject.AddComponent<FMOD_StudioEventEmitter>();
			}
			return this._emitter4;
		}
		goto IL_2A;
	}
}
