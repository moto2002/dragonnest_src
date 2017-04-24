using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(WaterBase))]
public class PlanarReflection : MonoBehaviour
{
	public LayerMask reflectionMask;

	public bool reflectSkybox;

	public Color clearColor = Color.grey;

	public string reflectionSampler = "_ReflectionTex";

	public float clipPlaneOffset = 0.07f;

	private Vector3 oldpos = Vector3.zero;

	private Camera reflectionCamera;

	private Material sharedMaterial;

	private Dictionary<Camera, bool> helperCameras;

	public void Start()
	{
		this.sharedMaterial = ((WaterBase)base.gameObject.GetComponent(typeof(WaterBase))).sharedMaterial;
	}

	private Camera CreateReflectionCameraFor(Camera cam)
	{
		string name = base.gameObject.name + "Reflection" + cam.name;
		GameObject gameObject = GameObject.Find(name);
		if (!gameObject)
		{
			gameObject = new GameObject(name, new Type[]
			{
				typeof(Camera)
			});
		}
		if (!gameObject.GetComponent(typeof(Camera)))
		{
			gameObject.AddComponent(typeof(Camera));
		}
		Camera camera = gameObject.camera;
		camera.backgroundColor = this.clearColor;
		camera.clearFlags = ((!this.reflectSkybox) ? CameraClearFlags.Color : CameraClearFlags.Skybox);
		this.SetStandardCameraParameter(camera, this.reflectionMask);
		if (!camera.targetTexture)
		{
			camera.targetTexture = this.CreateTextureFor(cam);
		}
		return camera;
	}

	private void SetStandardCameraParameter(Camera cam, LayerMask mask)
	{
		cam.cullingMask = (mask & ~(1 << LayerMask.NameToLayer("Water")));
		cam.backgroundColor = Color.black;
		cam.enabled = false;
	}

	private RenderTexture CreateTextureFor(Camera cam)
	{
		return new RenderTexture(Mathf.FloorToInt(cam.pixelWidth * 0.5f), Mathf.FloorToInt(cam.pixelHeight * 0.5f), 24)
		{
			hideFlags = HideFlags.DontSave
		};
	}

	public void RenderHelpCameras(Camera currentCam)
	{
		if (this.helperCameras == null)
		{
			this.helperCameras = new Dictionary<Camera, bool>();
		}
		if (!this.helperCameras.ContainsKey(currentCam))
		{
			this.helperCameras.Add(currentCam, false);
		}
		if (this.helperCameras[currentCam])
		{
			return;
		}
		if (!this.reflectionCamera)
		{
			this.reflectionCamera = this.CreateReflectionCameraFor(currentCam);
		}
		this.RenderReflectionFor(currentCam, this.reflectionCamera);
		this.helperCameras[currentCam] = true;
	}

	public void LateUpdate()
	{
		if (this.helperCameras != null)
		{
			this.helperCameras.Clear();
		}
	}

	public void WaterTileBeingRendered(Transform tr, Camera currentCam)
	{
		this.RenderHelpCameras(currentCam);
		if (this.reflectionCamera && this.sharedMaterial)
		{
			this.sharedMaterial.SetTexture(this.reflectionSampler, this.reflectionCamera.targetTexture);
		}
	}

	public void OnEnable()
	{
		Shader.EnableKeyword("WATER_REFLECTIVE");
		Shader.DisableKeyword("WATER_SIMPLE");
	}

	public void OnDisable()
	{
		Shader.EnableKeyword("WATER_SIMPLE");
		Shader.DisableKeyword("WATER_REFLECTIVE");
	}

	private void RenderReflectionFor(Camera cam, Camera reflectCamera)
	{
		if (!reflectCamera)
		{
			return;
		}
		if (this.sharedMaterial && !this.sharedMaterial.HasProperty(this.reflectionSampler))
		{
			return;
		}
		reflectCamera.cullingMask = (this.reflectionMask & ~(1 << LayerMask.NameToLayer("Water")));
		this.SaneCameraSettings(reflectCamera);
		reflectCamera.backgroundColor = this.clearColor;
		reflectCamera.clearFlags = ((!this.reflectSkybox) ? CameraClearFlags.Color : CameraClearFlags.Skybox);
		if (this.reflectSkybox && cam.gameObject.GetComponent(typeof(Skybox)))
		{
			Skybox skybox = (Skybox)reflectCamera.gameObject.GetComponent(typeof(Skybox));
			if (!skybox)
			{
				skybox = (Skybox)reflectCamera.gameObject.AddComponent(typeof(Skybox));
			}
			skybox.material = ((Skybox)cam.GetComponent(typeof(Skybox))).material;
		}
		GL.SetRevertBackfacing(true);
		Transform transform = base.transform;
		Vector3 eulerAngles = cam.transform.eulerAngles;
		reflectCamera.transform.eulerAngles = new Vector3(-eulerAngles.x, eulerAngles.y, eulerAngles.z);
		reflectCamera.transform.position = cam.transform.position;
		Vector3 position = transform.transform.position;
		position.y = transform.position.y;
		Vector3 up = transform.transform.up;
		float w = -Vector3.Dot(up, position) - this.clipPlaneOffset;
		Vector4 plane = new Vector4(up.x, up.y, up.z, w);
		Matrix4x4 matrix4x = Matrix4x4.zero;
		matrix4x = PlanarReflection.CalculateReflectionMatrix(matrix4x, plane);
		this.oldpos = cam.transform.position;
		Vector3 position2 = matrix4x.MultiplyPoint(this.oldpos);
		reflectCamera.worldToCameraMatrix = cam.worldToCameraMatrix * matrix4x;
		Vector4 clipPlane = this.CameraSpacePlane(reflectCamera, position, up, 1f);
		reflectCamera.projectionMatrix = cam.CalculateObliqueMatrix(clipPlane);
		reflectCamera.transform.position = position2;
		Vector3 eulerAngles2 = cam.transform.eulerAngles;
		reflectCamera.transform.eulerAngles = new Vector3(-eulerAngles2.x, eulerAngles2.y, eulerAngles2.z);
		reflectCamera.Render();
		GL.SetRevertBackfacing(false);
	}

	private void SaneCameraSettings(Camera helperCam)
	{
		helperCam.depthTextureMode = DepthTextureMode.None;
		helperCam.backgroundColor = Color.black;
		helperCam.clearFlags = CameraClearFlags.Color;
		helperCam.renderingPath = RenderingPath.Forward;
	}

	private static Matrix4x4 CalculateReflectionMatrix(Matrix4x4 reflectionMat, Vector4 plane)
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
		return reflectionMat;
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
		Vector3 v = pos + normal * this.clipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(v);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
	}
}
