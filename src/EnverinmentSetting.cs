using System;
using System.Collections.Generic;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

[ExecuteInEditMode]
public class EnverinmentSetting : MonoBehaviour, IEnvSetting
{
	[Serializable]
	public class EnvInfo
	{
		[SerializeField]
		public bool fog = true;

		[SerializeField]
		public Color fogColor;

		[SerializeField]
		public FogMode fogMode = FogMode.Linear;

		[Range(0f, 1f), SerializeField]
		public float fogDensity;

		[SerializeField]
		public float fogStartDistance;

		[SerializeField]
		public float fogEndDistance;

		[SerializeField]
		public string skyboxPath;

		[SerializeField]
		public Color ambientLight;

		public Material skybox
		{
			get;
			set;
		}
	}

	[SerializeField]
	public List<EnverinmentSetting.EnvInfo> envs;

	[NonSerialized]
	private EnverinmentSetting.EnvInfo backup = new EnverinmentSetting.EnvInfo();

	[NonSerialized]
	private int currentIndex = -1;

	[NonSerialized]
	private Material skyBoxBackup;

	[NonSerialized]
	public Material currentSky;

	private void Awake()
	{
		if (Application.isPlaying)
		{
			XSingleton<XShell>.singleton.MonoObjectRegister("EnvSet", this);
		}
		this.backup.fog = RenderSettings.fog;
		this.backup.fogColor = RenderSettings.fogColor;
		this.backup.fogMode = RenderSettings.fogMode;
		this.backup.fogDensity = RenderSettings.fogDensity;
		this.backup.fogStartDistance = RenderSettings.fogStartDistance;
		this.backup.fogEndDistance = RenderSettings.fogEndDistance;
		this.skyBoxBackup = RenderSettings.skybox;
		this.backup.ambientLight = RenderSettings.ambientLight;
	}

	public void EnableSetting(int index)
	{
		if (this.envs != null && index >= 0 && index < this.envs.Count && this.currentIndex != index)
		{
			this.currentIndex = index;
			EnverinmentSetting.EnvInfo envInfo = this.envs[index];
			RenderSettings.fog = envInfo.fog;
			RenderSettings.fogColor = envInfo.fogColor;
			RenderSettings.fogMode = envInfo.fogMode;
			RenderSettings.fogDensity = envInfo.fogDensity;
			RenderSettings.fogStartDistance = envInfo.fogStartDistance;
			RenderSettings.fogEndDistance = envInfo.fogEndDistance;
			if (this.currentSky != null)
			{
				XSingleton<XResourceLoaderMgr>.singleton.DestroyShareResource(envInfo.skyboxPath, this.currentSky);
				this.currentSky = null;
			}
			this.currentSky = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Material>(envInfo.skyboxPath, ".mat", true);
			if (this.currentSky != null)
			{
				RenderSettings.skybox = this.currentSky;
			}
			RenderSettings.ambientLight = envInfo.ambientLight;
		}
	}

	public void ActiveSetting(int index)
	{
		if (this.envs != null && index >= 0 && index < this.envs.Count)
		{
			EnverinmentSetting.EnvInfo envInfo = this.envs[index];
			RenderSettings.fog = envInfo.fog;
			RenderSettings.fogColor = envInfo.fogColor;
			RenderSettings.fogMode = envInfo.fogMode;
			RenderSettings.fogDensity = envInfo.fogDensity;
			RenderSettings.fogStartDistance = envInfo.fogStartDistance;
			RenderSettings.fogEndDistance = envInfo.fogEndDistance;
			if (envInfo.skybox != null)
			{
				RenderSettings.skybox = envInfo.skybox;
			}
			RenderSettings.ambientLight = envInfo.ambientLight;
		}
	}

	public void ResetEnv()
	{
		RenderSettings.fog = this.backup.fog;
		RenderSettings.fogColor = this.backup.fogColor;
		RenderSettings.fogMode = this.backup.fogMode;
		RenderSettings.fogDensity = this.backup.fogDensity;
		RenderSettings.fogStartDistance = this.backup.fogStartDistance;
		RenderSettings.fogEndDistance = this.backup.fogEndDistance;
		RenderSettings.skybox = this.skyBoxBackup;
		RenderSettings.ambientLight = this.backup.ambientLight;
		this.currentIndex = -1;
	}
}
