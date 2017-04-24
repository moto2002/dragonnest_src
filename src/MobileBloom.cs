using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MobileBloom : MobilePostEffectsBase
{
	public enum Resolution
	{
		Low,
		High
	}

	public enum BlurType
	{
		Standard,
		Sgx
	}

	public enum BlurDir
	{
		vertical,
		horizontal,
		both
	}

	[Range(0f, 1.5f)]
	public float threshhold = 0.25f;

	[Range(0f, 2.5f)]
	public float intensity = 0.75f;

	[Range(0.25f, 5.5f)]
	public float blurSize = 1f;

	private MobileBloom.Resolution resolution;

	[Range(1f, 4f)]
	private int blurIterations = 1;

	private MobileBloom.BlurType blurType = MobileBloom.BlurType.Sgx;

	public MobileBloom.BlurDir blurDir;

	public Shader fastBloomShader;

	private Material fastBloomMaterial;

	private new bool CheckResources()
	{
		base.CheckSupport(false);
		if (this.fastBloomShader == null)
		{
			this.fastBloomShader = Shader.Find("Hidden/FastBloom");
		}
		if (this.fastBloomMaterial == null)
		{
			this.fastBloomMaterial = base.CheckShaderAndCreateMaterial(this.fastBloomShader, this.fastBloomMaterial);
		}
		return this.isSupported;
	}

	private void OnDisable()
	{
		if (this.fastBloomMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.fastBloomMaterial);
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			return;
		}
		int num = (this.resolution != MobileBloom.Resolution.Low) ? 2 : 4;
		float num2 = (this.resolution != MobileBloom.Resolution.Low) ? 1f : 0.5f;
		this.fastBloomMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num2, 0f, this.threshhold, this.intensity));
		source.filterMode = FilterMode.Bilinear;
		int width = source.width / num;
		int height = source.height / num;
		RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);
		renderTexture.filterMode = FilterMode.Bilinear;
		Graphics.Blit(source, renderTexture, this.fastBloomMaterial, 1);
		int num3 = (this.blurType != MobileBloom.BlurType.Standard) ? 2 : 0;
		for (int i = 0; i < this.blurIterations; i++)
		{
			this.fastBloomMaterial.SetVector("_Parameter", new Vector4(this.blurSize * num2 + (float)i * 1f, 0f, this.threshhold, this.intensity));
			if (this.blurDir == MobileBloom.BlurDir.vertical || this.blurDir == MobileBloom.BlurDir.both)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, source.format);
				temporary.filterMode = FilterMode.Bilinear;
				Graphics.Blit(renderTexture, temporary, this.fastBloomMaterial, 2 + num3);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
			if (this.blurDir == MobileBloom.BlurDir.horizontal || this.blurDir == MobileBloom.BlurDir.both)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, source.format);
				temporary.filterMode = FilterMode.Bilinear;
				Graphics.Blit(renderTexture, temporary, this.fastBloomMaterial, 3 + num3);
				RenderTexture.ReleaseTemporary(renderTexture);
				renderTexture = temporary;
			}
		}
		this.fastBloomMaterial.SetTexture("_Bloom", renderTexture);
		Graphics.Blit(source, destination, this.fastBloomMaterial, 0);
		RenderTexture.ReleaseTemporary(renderTexture);
	}
}
