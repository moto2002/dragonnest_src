using System;
using UnityEngine;

[ExecuteInEditMode]
public class WaterBase : MonoBehaviour
{
	public Material sharedMaterial;

	public WaterQuality waterQuality = WaterQuality.High;

	public bool edgeBlend = true;

	public void UpdateShader()
	{
		if (this.waterQuality > WaterQuality.Medium)
		{
			this.sharedMaterial.shader.maximumLOD = 501;
		}
		else if (this.waterQuality > WaterQuality.Low)
		{
			this.sharedMaterial.shader.maximumLOD = 301;
		}
		else
		{
			this.sharedMaterial.shader.maximumLOD = 201;
		}
		if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.edgeBlend = false;
		}
		if (this.edgeBlend)
		{
			Shader.EnableKeyword("WATER_EDGEBLEND_ON");
			Shader.DisableKeyword("WATER_EDGEBLEND_OFF");
			if (Camera.main)
			{
				Camera.main.depthTextureMode |= DepthTextureMode.Depth;
			}
		}
		else
		{
			Shader.EnableKeyword("WATER_EDGEBLEND_OFF");
			Shader.DisableKeyword("WATER_EDGEBLEND_ON");
		}
	}

	public void WaterTileBeingRendered(Transform tr, Camera currentCam)
	{
		if (currentCam && this.edgeBlend)
		{
			currentCam.depthTextureMode |= DepthTextureMode.Depth;
		}
	}

	public void Update()
	{
		if (this.sharedMaterial)
		{
			this.UpdateShader();
		}
	}
}
