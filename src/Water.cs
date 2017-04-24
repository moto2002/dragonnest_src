using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Water : MonoBehaviour
{
	public enum WaterMode
	{
		Simple,
		CubeRefl,
		Reflective,
		Refractive
	}

	public Water.WaterMode m_WaterMode = Water.WaterMode.Refractive;

	public bool m_DisablePixelLights = true;

	public int m_TextureSize = 256;

	public float m_ClipPlaneOffset = 0.07f;

	public LayerMask m_ReflectLayers = -1;

	public LayerMask m_RefractLayers = -1;

	private Dictionary<Camera, Camera> m_ReflectionCameras = new Dictionary<Camera, Camera>();

	private Dictionary<Camera, Camera> m_RefractionCameras = new Dictionary<Camera, Camera>();

	private RenderTexture m_ReflectionTexture;

	private RenderTexture m_RefractionTexture;

	private Water.WaterMode m_HardwareWaterSupport = Water.WaterMode.Refractive;

	private int m_OldReflectionTextureSize;

	private int m_OldRefractionTextureSize;

	private static bool s_InsideWater;

	public void OnWillRenderObject()
	{
		if (!base.enabled || !base.renderer || !base.renderer.sharedMaterial || !base.renderer.enabled)
		{
			return;
		}
		Camera current = Camera.current;
		if (!current)
		{
			return;
		}
		if (Water.s_InsideWater)
		{
			return;
		}
		Water.s_InsideWater = true;
		this.m_HardwareWaterSupport = this.FindHardwareWaterSupport();
		Water.WaterMode waterMode = this.GetWaterMode();
		Camera camera;
		Camera camera2;
		this.CreateWaterObjects(current, out camera, out camera2);
		Vector3 position = base.transform.position;
		Vector3 up = base.transform.up;
		int pixelLightCount = QualitySettings.pixelLightCount;
		if (this.m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = 0;
		}
		this.UpdateCameraModes(current, camera);
		this.UpdateCameraModes(current, camera2);
		if (waterMode >= Water.WaterMode.Reflective)
		{
			float w = -Vector3.Dot(up, position) - this.m_ClipPlaneOffset;
			Vector4 plane = new Vector4(up.x, up.y, up.z, w);
			Matrix4x4 zero = Matrix4x4.zero;
			Water.CalculateReflectionMatrix(ref zero, plane);
			Vector3 position2 = current.transform.position;
			Vector3 position3 = zero.MultiplyPoint(position2);
			camera.worldToCameraMatrix = current.worldToCameraMatrix * zero;
			Vector4 clipPlane = this.CameraSpacePlane(camera, position, up, 1f);
			camera.projectionMatrix = current.CalculateObliqueMatrix(clipPlane);
			camera.cullingMask = (-17 & this.m_ReflectLayers.value);
			camera.targetTexture = this.m_ReflectionTexture;
			GL.SetRevertBackfacing(true);
			camera.transform.position = position3;
			Vector3 eulerAngles = current.transform.eulerAngles;
			camera.transform.eulerAngles = new Vector3(-eulerAngles.x, eulerAngles.y, eulerAngles.z);
			camera.Render();
			camera.transform.position = position2;
			GL.SetRevertBackfacing(false);
			base.renderer.sharedMaterial.SetTexture("_ReflectionTex", this.m_ReflectionTexture);
		}
		if (waterMode >= Water.WaterMode.Refractive)
		{
			camera2.worldToCameraMatrix = current.worldToCameraMatrix;
			Vector4 clipPlane2 = this.CameraSpacePlane(camera2, position, up, -1f);
			camera2.projectionMatrix = current.CalculateObliqueMatrix(clipPlane2);
			camera2.cullingMask = (-17 & this.m_RefractLayers.value);
			camera2.targetTexture = this.m_RefractionTexture;
			camera2.transform.position = current.transform.position;
			camera2.transform.rotation = current.transform.rotation;
			camera2.Render();
			base.renderer.sharedMaterial.SetTexture("_RefractionTex", this.m_RefractionTexture);
		}
		if (this.m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = pixelLightCount;
		}
		switch (waterMode)
		{
		case Water.WaterMode.Simple:
			Shader.EnableKeyword("WATER_SIMPLE");
			Shader.DisableKeyword("WATER_REFLECTIVE");
			Shader.DisableKeyword("WATER_REFRACTIVE");
			Shader.DisableKeyword("WATER_CUBEREFL");
			break;
		case Water.WaterMode.CubeRefl:
			Shader.DisableKeyword("WATER_SIMPLE");
			Shader.DisableKeyword("WATER_REFLECTIVE");
			Shader.DisableKeyword("WATER_REFRACTIVE");
			Shader.EnableKeyword("WATER_CUBEREFL");
			break;
		case Water.WaterMode.Reflective:
			Shader.DisableKeyword("WATER_SIMPLE");
			Shader.EnableKeyword("WATER_REFLECTIVE");
			Shader.DisableKeyword("WATER_REFRACTIVE");
			Shader.DisableKeyword("WATER_CUBEREFL");
			break;
		case Water.WaterMode.Refractive:
			Shader.DisableKeyword("WATER_SIMPLE");
			Shader.DisableKeyword("WATER_REFLECTIVE");
			Shader.EnableKeyword("WATER_REFRACTIVE");
			Shader.DisableKeyword("WATER_CUBEREFL");
			break;
		}
		Water.s_InsideWater = false;
	}

	private void OnDisable()
	{
		if (this.m_ReflectionTexture)
		{
			UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
			this.m_ReflectionTexture = null;
		}
		if (this.m_RefractionTexture)
		{
			UnityEngine.Object.DestroyImmediate(this.m_RefractionTexture);
			this.m_RefractionTexture = null;
		}
		foreach (KeyValuePair<Camera, Camera> current in this.m_ReflectionCameras)
		{
			UnityEngine.Object.DestroyImmediate(current.Value.gameObject);
		}
		this.m_ReflectionCameras.Clear();
		foreach (KeyValuePair<Camera, Camera> current2 in this.m_RefractionCameras)
		{
			UnityEngine.Object.DestroyImmediate(current2.Value.gameObject);
		}
		this.m_RefractionCameras.Clear();
	}

	private void Update()
	{
		if (!base.renderer)
		{
			return;
		}
		Material sharedMaterial = base.renderer.sharedMaterial;
		if (!sharedMaterial)
		{
			return;
		}
		Vector4 vector = sharedMaterial.GetVector("WaveSpeed");
		float @float = sharedMaterial.GetFloat("_WaveScale");
		Vector4 vector2 = new Vector4(@float, @float, @float * 0.4f, @float * 0.45f);
		double num = (double)Time.timeSinceLevelLoad / 20.0;
		Vector4 vector3 = new Vector4((float)Math.IEEERemainder((double)(vector.x * vector2.x) * num, 1.0), (float)Math.IEEERemainder((double)(vector.y * vector2.y) * num, 1.0), (float)Math.IEEERemainder((double)(vector.z * vector2.z) * num, 1.0), (float)Math.IEEERemainder((double)(vector.w * vector2.w) * num, 1.0));
		sharedMaterial.SetVector("_WaveOffset", vector3);
		sharedMaterial.SetVector("_WaveScale4", vector2);
		Vector3 size = base.renderer.bounds.size;
		Vector3 s = new Vector3(size.x * vector2.x, size.z * vector2.y, 1f);
		Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(vector3.x, vector3.y, 0f), Quaternion.identity, s);
		sharedMaterial.SetMatrix("_WaveMatrix", matrix);
		s = new Vector3(size.x * vector2.z, size.z * vector2.w, 1f);
		matrix = Matrix4x4.TRS(new Vector3(vector3.z, vector3.w, 0f), Quaternion.identity, s);
		sharedMaterial.SetMatrix("_WaveMatrix2", matrix);
	}

	private void UpdateCameraModes(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox skybox = src.GetComponent(typeof(Skybox)) as Skybox;
			Skybox skybox2 = dest.GetComponent(typeof(Skybox)) as Skybox;
			if (!skybox || !skybox.material)
			{
				skybox2.enabled = false;
			}
			else
			{
				skybox2.enabled = true;
				skybox2.material = skybox.material;
			}
		}
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
	}

	private void CreateWaterObjects(Camera currentCamera, out Camera reflectionCamera, out Camera refractionCamera)
	{
		Water.WaterMode waterMode = this.GetWaterMode();
		reflectionCamera = null;
		refractionCamera = null;
		if (waterMode >= Water.WaterMode.Reflective)
		{
			if (!this.m_ReflectionTexture || this.m_OldReflectionTextureSize != this.m_TextureSize)
			{
				if (this.m_ReflectionTexture)
				{
					UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
				}
				this.m_ReflectionTexture = new RenderTexture(this.m_TextureSize, this.m_TextureSize, 16);
				this.m_ReflectionTexture.name = "__WaterReflection" + base.GetInstanceID();
				this.m_ReflectionTexture.isPowerOfTwo = true;
				this.m_ReflectionTexture.hideFlags = HideFlags.DontSave;
				this.m_OldReflectionTextureSize = this.m_TextureSize;
			}
			this.m_ReflectionCameras.TryGetValue(currentCamera, out reflectionCamera);
			if (!reflectionCamera)
			{
				GameObject gameObject = new GameObject(string.Concat(new object[]
				{
					"Water Refl Camera id",
					base.GetInstanceID(),
					" for ",
					currentCamera.GetInstanceID()
				}), new Type[]
				{
					typeof(Camera),
					typeof(Skybox)
				});
				reflectionCamera = gameObject.camera;
				reflectionCamera.enabled = false;
				reflectionCamera.transform.position = base.transform.position;
				reflectionCamera.transform.rotation = base.transform.rotation;
				reflectionCamera.gameObject.AddComponent("FlareLayer");
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				this.m_ReflectionCameras[currentCamera] = reflectionCamera;
			}
		}
		if (waterMode >= Water.WaterMode.Refractive)
		{
			if (!this.m_RefractionTexture || this.m_OldRefractionTextureSize != this.m_TextureSize)
			{
				if (this.m_RefractionTexture)
				{
					UnityEngine.Object.DestroyImmediate(this.m_RefractionTexture);
				}
				this.m_RefractionTexture = new RenderTexture(this.m_TextureSize, this.m_TextureSize, 16);
				this.m_RefractionTexture.name = "__WaterRefraction" + base.GetInstanceID();
				this.m_RefractionTexture.isPowerOfTwo = true;
				this.m_RefractionTexture.hideFlags = HideFlags.DontSave;
				this.m_OldRefractionTextureSize = this.m_TextureSize;
			}
			this.m_RefractionCameras.TryGetValue(currentCamera, out refractionCamera);
			if (!refractionCamera)
			{
				GameObject gameObject2 = new GameObject(string.Concat(new object[]
				{
					"Water Refr Camera id",
					base.GetInstanceID(),
					" for ",
					currentCamera.GetInstanceID()
				}), new Type[]
				{
					typeof(Camera),
					typeof(Skybox)
				});
				refractionCamera = gameObject2.camera;
				refractionCamera.enabled = false;
				refractionCamera.transform.position = base.transform.position;
				refractionCamera.transform.rotation = base.transform.rotation;
				refractionCamera.gameObject.AddComponent("FlareLayer");
				gameObject2.hideFlags = HideFlags.HideAndDontSave;
				this.m_RefractionCameras[currentCamera] = refractionCamera;
			}
		}
		if (reflectionCamera != null)
		{
			reflectionCamera.useOcclusionCulling = false;
		}
	}

	private Water.WaterMode GetWaterMode()
	{
		if (this.m_HardwareWaterSupport < this.m_WaterMode)
		{
			return this.m_HardwareWaterSupport;
		}
		return this.m_WaterMode;
	}

	private Water.WaterMode FindHardwareWaterSupport()
	{
		int qualityLevel = QualitySettings.GetQualityLevel();
		if (qualityLevel == 0 || qualityLevel == 6)
		{
			return Water.WaterMode.Simple;
		}
		if (!SystemInfo.supportsRenderTextures || !base.renderer)
		{
			return Water.WaterMode.Simple;
		}
		Material sharedMaterial = base.renderer.sharedMaterial;
		if (!sharedMaterial)
		{
			return Water.WaterMode.Simple;
		}
		string tag = sharedMaterial.GetTag("WATERMODE", false);
		if (tag == "Refractive")
		{
			return Water.WaterMode.Refractive;
		}
		if (tag == "Reflective")
		{
			return Water.WaterMode.Reflective;
		}
		return Water.WaterMode.CubeRefl;
	}

	private static float sgn(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 v = pos + normal * this.m_ClipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(v);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
	}

	private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
		reflectionMat.m01 = -2f * plane[0] * plane[1];
		reflectionMat.m02 = -2f * plane[0] * plane[2];
		reflectionMat.m03 = -2f * plane[3] * plane[0];
		reflectionMat.m10 = -2f * plane[1] * plane[0];
		reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
		reflectionMat.m12 = -2f * plane[1] * plane[2];
		reflectionMat.m13 = -2f * plane[3] * plane[1];
		reflectionMat.m20 = -2f * plane[2] * plane[0];
		reflectionMat.m21 = -2f * plane[2] * plane[1];
		reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
		reflectionMat.m23 = -2f * plane[3] * plane[2];
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
	}
}
