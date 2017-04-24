using System;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(WaterBase))]
public class SpecularLighting : MonoBehaviour
{
	public Transform specularLight;

	private WaterBase waterBase;

	public void Start()
	{
		this.waterBase = (WaterBase)base.gameObject.GetComponent(typeof(WaterBase));
	}

	public void Update()
	{
		if (!this.waterBase)
		{
			this.waterBase = (WaterBase)base.gameObject.GetComponent(typeof(WaterBase));
		}
		if (this.specularLight && this.waterBase.sharedMaterial)
		{
			this.waterBase.sharedMaterial.SetVector("_WorldLightDir", this.specularLight.transform.forward);
		}
	}
}
