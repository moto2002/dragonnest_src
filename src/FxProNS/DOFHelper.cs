using System;
using System.Collections.Generic;
using UnityEngine;

namespace FxProNS
{
	public class DOFHelper : Singleton<DOFHelper>, IDisposable
	{
		private static Material _mat;

		private DOFHelperParams _p;

		private float _curAutoFocusDist;

		public static Material Mat
		{
			get
			{
				if (null == DOFHelper._mat)
				{
					DOFHelper._mat = new Material(Shader.Find("Hidden/DOFPro"))
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
				return DOFHelper._mat;
			}
		}

		public void SetParams(DOFHelperParams p)
		{
			this._p = p;
		}

		public void Init(bool searchForNonDepthmapAlphaObjects)
		{
			if (this._p == null)
			{
				Debug.LogError("Call SetParams first");
				return;
			}
			if (null == this._p.EffectCamera)
			{
				Debug.LogError("null == p.camera");
				return;
			}
			if (null == DOFHelper.Mat)
			{
				return;
			}
			if (!this._p.UseUnityDepthBuffer)
			{
				this._p.EffectCamera.depthTextureMode = DepthTextureMode.None;
				DOFHelper.Mat.DisableKeyword("USE_CAMERA_DEPTH_TEXTURE");
				DOFHelper.Mat.EnableKeyword("DONT_USE_CAMERA_DEPTH_TEXTURE");
			}
			else
			{
				if (this._p.EffectCamera.depthTextureMode != DepthTextureMode.DepthNormals)
				{
					this._p.EffectCamera.depthTextureMode = DepthTextureMode.Depth;
				}
				DOFHelper.Mat.EnableKeyword("USE_CAMERA_DEPTH_TEXTURE");
				DOFHelper.Mat.DisableKeyword("DONT_USE_CAMERA_DEPTH_TEXTURE");
			}
			this._p.FocalLengthMultiplier = Mathf.Clamp(this._p.FocalLengthMultiplier, 0.01f, 0.99f);
			this._p.DepthCompression = Mathf.Clamp(this._p.DepthCompression, 1f, 10f);
			Shader.SetGlobalFloat("_OneOverDepthScale", this._p.DepthCompression);
			Shader.SetGlobalFloat("_OneOverDepthFar", 1f / this._p.EffectCamera.farClipPlane);
			if (this._p.BokehEnabled)
			{
				DOFHelper.Mat.SetFloat("_BokehThreshold", this._p.BokehThreshold);
				DOFHelper.Mat.SetFloat("_BokehGain", this._p.BokehGain);
				DOFHelper.Mat.SetFloat("_BokehBias", this._p.BokehBias);
			}
		}

		public void SetBlurRadius(int radius)
		{
			Shader.DisableKeyword("BLUR_RADIUS_10");
			Shader.DisableKeyword("BLUR_RADIUS_5");
			Shader.DisableKeyword("BLUR_RADIUS_3");
			Shader.DisableKeyword("BLUR_RADIUS_2");
			Shader.DisableKeyword("BLUR_RADIUS_1");
			if (radius != 10 && radius != 5 && radius != 3 && radius != 2 && radius != 1)
			{
				radius = 5;
			}
			if (radius < 3)
			{
				radius = 3;
			}
			Shader.EnableKeyword("BLUR_RADIUS_" + radius);
		}

		private void CalculateAndUpdateFocalDist()
		{
			if (null == this._p.EffectCamera)
			{
				Debug.LogError("null == p.camera");
				return;
			}
			float num;
			if (!this._p.AutoFocus && null != this._p.Target)
			{
				num = this._p.EffectCamera.WorldToViewportPoint(this._p.Target.position).z;
			}
			else
			{
				num = (this._curAutoFocusDist = Mathf.Lerp(this._curAutoFocusDist, this.CalculateAutoFocusDist(), Time.deltaTime * this._p.AutoFocusSpeed));
			}
			num /= this._p.EffectCamera.farClipPlane;
			num *= this._p.FocalDistMultiplier * this._p.DepthCompression;
			DOFHelper.Mat.SetFloat("_FocalDist", num);
			DOFHelper.Mat.SetFloat("_FocalLength", num * this._p.FocalLengthMultiplier);
		}

		private float CalculateAutoFocusDist()
		{
			if (null == this._p.EffectCamera)
			{
				return 0f;
			}
			RaycastHit raycastHit;
			return (!Physics.Raycast(this._p.EffectCamera.transform.position, this._p.EffectCamera.transform.forward, out raycastHit, float.PositiveInfinity, this._p.AutoFocusLayerMask.value)) ? this._p.EffectCamera.farClipPlane : raycastHit.distance;
		}

		public void RenderCOCTexture(RenderTexture src, RenderTexture dest, float blurScale)
		{
			this.CalculateAndUpdateFocalDist();
			if (null == this._p.EffectCamera)
			{
				Debug.LogError("null == p.camera");
				return;
			}
			if (this._p.EffectCamera.depthTextureMode == DepthTextureMode.None)
			{
				this._p.EffectCamera.depthTextureMode = DepthTextureMode.Depth;
			}
			if (this._p.DOFBlurSize > 0.001f)
			{
				RenderTexture renderTexture = RenderTextureManager.Instance.RequestRenderTexture(src.width, src.height, src.depth, src.format);
				RenderTexture renderTexture2 = RenderTextureManager.Instance.RequestRenderTexture(src.width, src.height, src.depth, src.format);
				Graphics.Blit(src, renderTexture, DOFHelper.Mat, 0);
				DOFHelper.Mat.SetVector("_SeparableBlurOffsets", new Vector4(blurScale, 0f, 0f, 0f));
				Graphics.Blit(renderTexture, renderTexture2, DOFHelper.Mat, 2);
				DOFHelper.Mat.SetVector("_SeparableBlurOffsets", new Vector4(0f, blurScale, 0f, 0f));
				Graphics.Blit(renderTexture2, dest, DOFHelper.Mat, 2);
				RenderTextureManager.Instance.ReleaseRenderTexture(renderTexture);
				RenderTextureManager.Instance.ReleaseRenderTexture(renderTexture2);
			}
			else
			{
				Graphics.Blit(src, dest, DOFHelper.Mat, 0);
			}
		}

		public void RenderDOFBlur(RenderTexture src, RenderTexture dest, RenderTexture cocTexture)
		{
			if (null == cocTexture)
			{
				Debug.LogError("null == cocTexture");
				return;
			}
			DOFHelper.Mat.SetTexture("_COCTex", cocTexture);
			if (this._p.BokehEnabled)
			{
				DOFHelper.Mat.SetFloat("_BlurIntensity", this._p.DOFBlurSize);
				Graphics.Blit(src, dest, DOFHelper.Mat, 4);
			}
			else
			{
				RenderTexture renderTexture = RenderTextureManager.Instance.RequestRenderTexture(src.width, src.height, src.depth, src.format);
				DOFHelper.Mat.SetVector("_SeparableBlurOffsets", new Vector4(this._p.DOFBlurSize, 0f, 0f, 0f));
				Graphics.Blit(src, renderTexture, DOFHelper.Mat, 1);
				DOFHelper.Mat.SetVector("_SeparableBlurOffsets", new Vector4(0f, this._p.DOFBlurSize, 0f, 0f));
				Graphics.Blit(renderTexture, dest, DOFHelper.Mat, 1);
				RenderTextureManager.Instance.ReleaseRenderTexture(renderTexture);
			}
		}

		public void RenderEffect(RenderTexture src, RenderTexture dest)
		{
			this.RenderEffect(src, dest, false);
		}

		public void RenderEffect(RenderTexture src, RenderTexture dest, bool visualizeCOC)
		{
			RenderTexture renderTexture = RenderTextureManager.Instance.RequestRenderTexture(src.width, src.height, src.depth, src.format);
			this.RenderCOCTexture(src, renderTexture, 0f);
			if (visualizeCOC)
			{
				Graphics.Blit(renderTexture, dest);
				RenderTextureManager.Instance.ReleaseRenderTexture(renderTexture);
				RenderTextureManager.Instance.ReleaseAllRenderTextures();
				return;
			}
			this.RenderDOFBlur(src, dest, renderTexture);
			RenderTextureManager.Instance.ReleaseRenderTexture(renderTexture);
		}

		public static GameObject[] GetNonDepthmapAlphaObjects()
		{
			if (!Application.isPlaying)
			{
				return new GameObject[0];
			}
			Renderer[] array = UnityEngine.Object.FindObjectsOfType<Renderer>();
			List<GameObject> list = new List<GameObject>();
			List<Material> list2 = new List<Material>();
			Renderer[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Renderer renderer = array2[i];
				if (renderer.sharedMaterials != null)
				{
					if (!(null != renderer.GetComponent<ParticleSystem>()))
					{
						Material[] sharedMaterials = renderer.sharedMaterials;
						for (int j = 0; j < sharedMaterials.Length; j++)
						{
							Material material = sharedMaterials[j];
							if (!(null == material.shader))
							{
								bool flag = null == material.GetTag("RenderType", false);
								if (flag || (!(material.GetTag("RenderType", false).ToLower() == "transparent") && !(material.GetTag("Queue", false).ToLower() == "transparent")))
								{
									if (material.GetTag("OUTPUT_DEPTH_TO_ALPHA", false) == null || material.GetTag("OUTPUT_DEPTH_TO_ALPHA", false).ToLower() != "true")
									{
										flag = true;
									}
									if (flag)
									{
										if (!list2.Contains(material))
										{
											list2.Add(material);
											Debug.Log("Non-depthmapped: " + DOFHelper.GetFullPath(renderer.gameObject));
											list.Add(renderer.gameObject);
										}
									}
								}
							}
						}
					}
				}
			}
			return list.ToArray();
		}

		public static string GetFullPath(GameObject obj)
		{
			string text = "/" + obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent.gameObject;
				text = "/" + obj.name + text;
			}
			return "'" + text + "'";
		}

		public void Dispose()
		{
			if (null != DOFHelper.Mat)
			{
				UnityEngine.Object.DestroyImmediate(DOFHelper.Mat);
			}
			if (this._p != null && this._p.EffectCamera != null)
			{
				this._p.EffectCamera.depthTextureMode = DepthTextureMode.None;
			}
			RenderTextureManager.Instance.Dispose();
		}
	}
}
