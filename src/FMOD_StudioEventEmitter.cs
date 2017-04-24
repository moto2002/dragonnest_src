using FMOD;
using FMOD.Studio;
using System;
using UnityEngine;
using XUtliPoolLib;

public class FMOD_StudioEventEmitter : MonoBehaviour
{
	[Serializable]
	public class Parameter
	{
		public string name;

		public float value;
	}

	public FMODAsset asset;

	public string path = string.Empty;

	public bool startEventOnAwake;

	private EventInstance evt;

	private bool hasStarted;

	private bool bManualSetPos;

	private Rigidbody cachedRigidBody;

	private static bool isShuttingDown;

	public void Play()
	{
		if (this.evt != null)
		{
			this.ERRCHECK(this.evt.start());
			return;
		}
		UnityUtil.Log("Tried to play event without a valid instance: " + this.path);
	}

	public void Stop(STOP_MODE stop_mode = STOP_MODE.ALLOWFADEOUT)
	{
		if (this.evt != null)
		{
			this.ERRCHECK(this.evt.stop(stop_mode));
		}
	}

	public ParameterInstance getParameter(string name)
	{
		ParameterInstance result = null;
		this.ERRCHECK(this.evt.getParameter(name, out result));
		return result;
	}

	public void setParameterValue(string name, float value)
	{
		this.ERRCHECK(this.evt.setParameterValue(name, value));
	}

	public PLAYBACK_STATE getPlaybackState()
	{
		if (this.evt == null || !this.evt.isValid())
		{
			return PLAYBACK_STATE.STOPPED;
		}
		PLAYBACK_STATE result = PLAYBACK_STATE.STOPPED;
		if (this.ERRCHECK(this.evt.getPlaybackState(out result)) == RESULT.OK)
		{
			return result;
		}
		return PLAYBACK_STATE.STOPPED;
	}

	private void Start()
	{
		if (this.evt == null || !this.evt.isValid())
		{
			this.CacheEventInstance();
		}
		this.cachedRigidBody = base.GetComponent<Rigidbody>();
		if (this.startEventOnAwake)
		{
			this.StartEvent();
		}
	}

	public void CacheEventInstance()
	{
		if (this.asset != null)
		{
			this.evt = FMOD_StudioSystem.instance.GetEvent(this.asset.id);
		}
		else if (!string.IsNullOrEmpty(this.path))
		{
			this.evt = FMOD_StudioSystem.instance.GetEvent(this.path);
		}
	}

	private void OnApplicationQuit()
	{
		FMOD_StudioEventEmitter.isShuttingDown = true;
	}

	public void OnDestroy()
	{
		if (FMOD_StudioEventEmitter.isShuttingDown)
		{
			return;
		}
		UnityUtil.Log("Destroy called");
		if (this.evt != null && this.evt.isValid())
		{
			if (this.getPlaybackState() != PLAYBACK_STATE.STOPPED)
			{
				UnityUtil.Log("Release evt: " + this.path);
				this.ERRCHECK(this.evt.stop(STOP_MODE.ALLOWFADEOUT));
			}
			this.ERRCHECK(this.evt.release());
			this.evt = null;
		}
	}

	public void StartEvent()
	{
		if (this.evt == null || !this.evt.isValid())
		{
			this.CacheEventInstance();
		}
		if (this.evt != null && this.evt.isValid())
		{
			this.Update3DAttributes();
			this.ERRCHECK(this.evt.start());
		}
		else
		{
			XSingleton<XDebug>.singleton.AddErrorLog("Event retrieval failed: " + this.path, null, null, null, null, null);
		}
		this.hasStarted = true;
	}

	public bool HasFinished()
	{
		return this.hasStarted && (this.evt == null || !this.evt.isValid() || this.getPlaybackState() == PLAYBACK_STATE.STOPPED);
	}

	private void Update()
	{
		if (this.evt != null && this.evt.isValid())
		{
			this.Update3DAttributes();
		}
		else
		{
			this.evt = null;
		}
	}

	private void Update3DAttributes()
	{
		if (this.bManualSetPos)
		{
			return;
		}
		if (this.evt != null && this.evt.isValid())
		{
			FMOD.Studio.ATTRIBUTES_3D attributes = UnityUtil.to3DAttributes(base.gameObject, this.cachedRigidBody);
			this.ERRCHECK(this.evt.set3DAttributes(attributes));
			this.bManualSetPos = false;
		}
	}

	public void Update3DAttributes(Vector3 vec)
	{
		if (this.evt != null && this.evt.isValid())
		{
			FMOD.Studio.ATTRIBUTES_3D attributes = vec.to3DAttributes();
			this.ERRCHECK(this.evt.set3DAttributes(attributes));
			this.bManualSetPos = true;
		}
	}

	private RESULT ERRCHECK(RESULT result)
	{
		UnityUtil.ERRCHECK(result);
		return result;
	}

	public void SetParamValue(string param, float value)
	{
		if (this.evt != null && this.evt.isValid())
		{
			this.ERRCHECK(this.evt.setParameterValue(param, value));
		}
	}
}
