using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Tasharen/Water"), ExecuteInEditMode, RequireComponent(typeof(Renderer))]
public class TasharenWater : MonoBehaviour
{
	public enum Quality
	{
		Fastest,
		Low,
		Medium,
		High,
		Uber
	}

	public TasharenWater.Quality quality = TasharenWater.Quality.High;

	public LayerMask highReflectionMask = -1;

	public LayerMask mediumReflectionMask = -1;

	public bool keepUnderCamera = true;

	private Transform mTrans;

	private Hashtable mCameras = new Hashtable();

	private RenderTexture mTex;

	private int mTexSize;

	private Renderer mRen;

	private static bool mIsRendering;

	public int reflectionTextureSize
	{
		get
		{
			switch (this.quality)
			{
			case TasharenWater.Quality.Medium:
			case TasharenWater.Quality.High:
				return 512;
			case TasharenWater.Quality.Uber:
				return 1024;
			default:
				return 0;
			}
		}
	}

	public LayerMask reflectionMask
	{
		get
		{
			switch (this.quality)
			{
			case TasharenWater.Quality.Medium:
				return this.mediumReflectionMask;
			case TasharenWater.Quality.High:
			case TasharenWater.Quality.Uber:
				return this.highReflectionMask;
			default:
				return 0;
			}
		}
	}

	public bool useRefraction
	{
		get
		{
			return this.quality > TasharenWater.Quality.Fastest;
		}
	}

	private static float SignExt(float a)
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

	private static void CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 b = projection.inverse * new Vector4(TasharenWater.SignExt(clipPlane.x), TasharenWater.SignExt(clipPlane.y), 1f, 1f);
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
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

	public static TasharenWater.Quality GetQuality()
	{
		return (TasharenWater.Quality)PlayerPrefs.GetInt("Water", 3);
	}

	public static void SetQuality(TasharenWater.Quality q)
	{
		TasharenWater[] array = UnityEngine.Object.FindObjectsOfType(typeof(TasharenWater)) as TasharenWater[];
		if (array.Length > 0)
		{
			TasharenWater[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				TasharenWater tasharenWater = array2[i];
				tasharenWater.quality = q;
			}
		}
		else
		{
			PlayerPrefs.SetInt("Water", (int)q);
		}
	}

	private void Awake()
	{
		this.mTrans = base.transform;
		this.mRen = base.renderer;
		this.quality = TasharenWater.GetQuality();
	}

	private void OnDisable()
	{
		this.Clear();
		foreach (DictionaryEntry dictionaryEntry in this.mCameras)
		{
			UnityEngine.Object.DestroyImmediate(((Camera)dictionaryEntry.Value).gameObject);
		}
		this.mCameras.Clear();
	}

	private void Clear()
	{
		if (this.mTex)
		{
			UnityEngine.Object.DestroyImmediate(this.mTex);
			this.mTex = null;
		}
	}

	private void CopyCamera(Camera src, Camera dest)
	{
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox component = src.GetComponent<Skybox>();
			Skybox component2 = dest.GetComponent<Skybox>();
			if (!component || !component.material)
			{
				component2.enabled = false;
			}
			else
			{
				component2.enabled = true;
				component2.material = component.material;
			}
		}
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
		dest.depthTextureMode = DepthTextureMode.None;
		dest.renderingPath = RenderingPath.Forward;
	}

	private Camera GetReflectionCamera(Camera current, Material mat, int textureSize)
	{
		if (!this.mTex || this.mTexSize != textureSize)
		{
			if (this.mTex)
			{
				UnityEngine.Object.DestroyImmediate(this.mTex);
			}
			this.mTex = new RenderTexture(textureSize, textureSize, 16);
			this.mTex.name = "__MirrorReflection" + base.GetInstanceID();
			this.mTex.isPowerOfTwo = true;
			this.mTex.hideFlags = HideFlags.DontSave;
			this.mTexSize = textureSize;
		}
		Camera camera = this.mCameras[current] as Camera;
		if (!camera)
		{
			camera = new GameObject(string.Concat(new object[]
			{
				"Mirror Refl Camera id",
				base.GetInstanceID(),
				" for ",
				current.GetInstanceID()
			}), new Type[]
			{
				typeof(Camera),
				typeof(Skybox)
			})
			{
				hideFlags = HideFlags.HideAndDontSave
			}.camera;
			camera.enabled = false;
			Transform transform = camera.transform;
			transform.position = this.mTrans.position;
			transform.rotation = this.mTrans.rotation;
			camera.gameObject.AddComponent("FlareLayer");
			this.mCameras[current] = camera;
		}
		if (mat.HasProperty("_ReflectionTex"))
		{
			mat.SetTexture("_ReflectionTex", this.mTex);
		}
		return camera;
	}

	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(pos);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
	}

	private void LateUpdate()
	{
		if (this.keepUnderCamera)
		{
			Transform transform = Camera.main.transform;
			Vector3 position = transform.position;
			position.y = this.mTrans.position.y;
			if (this.mTrans.position != position)
			{
				this.mTrans.position = position;
			}
		}
	}

	private void OnWillRenderObject()
	{
		if (TasharenWater.mIsRendering)
		{
			return;
		}
		if (!base.enabled || !this.mRen || !this.mRen.enabled)
		{
			this.Clear();
			return;
		}
		Material sharedMaterial = this.mRen.sharedMaterial;
		if (!sharedMaterial)
		{
			return;
		}
		Camera current = Camera.current;
		if (!current)
		{
			return;
		}
		bool supportsImageEffects = SystemInfo.supportsImageEffects;
		if (supportsImageEffects)
		{
			current.depthTextureMode |= DepthTextureMode.Depth;
		}
		else
		{
			this.quality = TasharenWater.Quality.Fastest;
		}
		if (!this.useRefraction)
		{
			sharedMaterial.shader.maximumLOD = ((!supportsImageEffects) ? 100 : 200);
			this.Clear();
			return;
		}
		LayerMask reflectionMask = this.reflectionMask;
		int reflectionTextureSize = this.reflectionTextureSize;
		if (reflectionMask == 0 || reflectionTextureSize < 512)
		{
			sharedMaterial.shader.maximumLOD = 300;
			this.Clear();
		}
		else
		{
			sharedMaterial.shader.maximumLOD = 400;
			TasharenWater.mIsRendering = true;
			Camera reflectionCamera = this.GetReflectionCamera(current, sharedMaterial, reflectionTextureSize);
			Vector3 position = this.mTrans.position;
			Vector3 up = this.mTrans.up;
			this.CopyCamera(current, reflectionCamera);
			float w = -Vector3.Dot(up, position);
			Vector4 plane = new Vector4(up.x, up.y, up.z, w);
			Matrix4x4 zero = Matrix4x4.zero;
			TasharenWater.CalculateReflectionMatrix(ref zero, plane);
			Vector3 position2 = current.transform.position;
			Vector3 position3 = zero.MultiplyPoint(position2);
			reflectionCamera.worldToCameraMatrix = current.worldToCameraMatrix * zero;
			Vector4 clipPlane = this.CameraSpacePlane(reflectionCamera, position, up, 1f);
			Matrix4x4 projectionMatrix = current.projectionMatrix;
			TasharenWater.CalculateObliqueMatrix(ref projectionMatrix, clipPlane);
			reflectionCamera.projectionMatrix = projectionMatrix;
			reflectionCamera.cullingMask = (-17 & reflectionMask.value);
			reflectionCamera.targetTexture = this.mTex;
			GL.SetRevertBackfacing(true);
			reflectionCamera.transform.position = position3;
			Vector3 eulerAngles = current.transform.eulerAngles;
			reflectionCamera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
			reflectionCamera.Render();
			reflectionCamera.transform.position = position2;
			GL.SetRevertBackfacing(false);
			TasharenWater.mIsRendering = false;
		}
	}
}
