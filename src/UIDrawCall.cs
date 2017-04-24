using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

[AddComponentMenu("NGUI/Internal/Draw Call"), ExecuteInEditMode]
public class UIDrawCall : MonoBehaviour
{
	public enum Clipping
	{
		None,
		SoftClip = 3,
		ConstrainButDontClip
	}

	private const int maxIndexBufferCache = 20;

	private static BetterList<UIDrawCall> mActiveList = new BetterList<UIDrawCall>();

	private static BetterList<UIDrawCall> mInactiveList = new BetterList<UIDrawCall>();

	private static Queue<Material> matCache = new Queue<Material>();

	[HideInInspector]
	[NonSerialized]
	public int depthStart = 2147483647;

	[HideInInspector]
	[NonSerialized]
	public int depthEnd = -2147483648;

	[HideInInspector]
	[NonSerialized]
	public UIPanel manager;

	[HideInInspector]
	[NonSerialized]
	public UIPanel panel;

	[HideInInspector]
	[NonSerialized]
	public bool alwaysOnScreen;

	[HideInInspector]
	[NonSerialized]
	public FastListV3 verts = new FastListV3();

	[HideInInspector]
	[NonSerialized]
	public FastListV3 norms = new FastListV3();

	[HideInInspector]
	[NonSerialized]
	public BetterList<Vector4> tans = new BetterList<Vector4>();

	[HideInInspector]
	[NonSerialized]
	public FastListV2 uvs = new FastListV2();

	[HideInInspector]
	[NonSerialized]
	public FastListColor32 cols = new FastListColor32();

	public bool useMerge;

	private Material mMaterial;

	private Texture mTexture;

	private Texture mAlphaTexture;

	public List<Texture> mTextureList;

	public List<Texture> mAlphaTextureList;

	private Shader mShader;

	private int mClipCount;

	private Transform mTrans;

	private Mesh mMesh;

	private MeshFilter mFilter;

	private MeshRenderer mRenderer;

	private Material mDynamicMat;

	private int[] mIndices;

	private bool mRebuildMat = true;

	private bool mLegacyShader;

	private int mRenderQueue = 3500;

	private int mTriangles;

	[NonSerialized]
	public bool isDirty;

	private static List<int[]> mCache = new List<int[]>(20);

	private static string[] ClipRange = new string[]
	{
		"_ClipRange0",
		"_ClipRange1",
		"_ClipRange2",
		"_ClipRange4"
	};

	private static string[] ClipArgs = new string[]
	{
		"_ClipArgs0",
		"_ClipArgs1",
		"_ClipArgs2",
		"_ClipArgs3"
	};

	[Obsolete("Use UIDrawCall.activeList")]
	public static BetterList<UIDrawCall> list
	{
		get
		{
			return UIDrawCall.mActiveList;
		}
	}

	public static BetterList<UIDrawCall> activeList
	{
		get
		{
			return UIDrawCall.mActiveList;
		}
	}

	public static BetterList<UIDrawCall> inactiveList
	{
		get
		{
			return UIDrawCall.mInactiveList;
		}
	}

	public int renderQueue
	{
		get
		{
			return this.mRenderQueue;
		}
		set
		{
			if (this.mRenderQueue != value)
			{
				this.mRenderQueue = value;
				if (this.mDynamicMat != null)
				{
					this.mDynamicMat.renderQueue = value;
				}
			}
		}
	}

	public int sortingOrder
	{
		get
		{
			return (!(this.mRenderer != null)) ? 0 : this.mRenderer.sortingOrder;
		}
		set
		{
			if (this.mRenderer != null && this.mRenderer.sortingOrder != value)
			{
				this.mRenderer.sortingOrder = value;
			}
		}
	}

	public int finalRenderQueue
	{
		get
		{
			return (!(this.mDynamicMat != null)) ? this.mRenderQueue : this.mDynamicMat.renderQueue;
		}
	}

	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	public Material baseMaterial
	{
		get
		{
			return this.mMaterial;
		}
		set
		{
			if (this.mMaterial != value)
			{
				this.mMaterial = value;
				this.mRebuildMat = true;
			}
		}
	}

	public Material dynamicMaterial
	{
		get
		{
			return this.mDynamicMat;
		}
	}

	public Texture mainTexture
	{
		get
		{
			return this.mTexture;
		}
		set
		{
			this.mTexture = value;
			if (this.mDynamicMat != null)
			{
				this.mDynamicMat.mainTexture = value;
			}
		}
	}

	public Texture alphaTexture
	{
		get
		{
			return this.mAlphaTexture;
		}
		set
		{
			this.mAlphaTexture = value;
		}
	}

	public Shader shader
	{
		get
		{
			return this.mShader;
		}
		set
		{
			if (this.mShader != value)
			{
				this.mShader = value;
				this.mRebuildMat = true;
			}
		}
	}

	public int triangles
	{
		get
		{
			return (!(this.mMesh != null)) ? 0 : this.mTriangles;
		}
	}

	public bool isClipped
	{
		get
		{
			return this.mClipCount != 0;
		}
	}

	private void CreateMaterial()
	{
		string text = (!(this.mShader != null)) ? ((!(this.mMaterial != null)) ? "Unlit/Seperate Alpha Colored" : this.mMaterial.shader.name) : this.mShader.name;
		text = text.Replace("GUI/Text Shader", "Unlit/Text");
		if (text.Length > 2 && text[text.Length - 2] == ' ')
		{
			int num = (int)text[text.Length - 1];
			if (num > 48 && num <= 57)
			{
				text = text.Substring(0, text.Length - 2);
			}
		}
		if (text.StartsWith("Hidden/"))
		{
			text = text.Substring(7);
		}
		text = text.Replace(" (SoftClip)", string.Empty);
		this.mLegacyShader = false;
		this.mClipCount = this.panel.clipCount;
		Shader shader;
		if (!this.useMerge)
		{
			if (this.mClipCount != 0)
			{
				shader = Shader.Find(string.Concat(new object[]
				{
					"Hidden/",
					text,
					" ",
					this.mClipCount
				}));
				if (shader == null)
				{
					Shader.Find(text + " " + this.mClipCount);
				}
				if (shader == null && this.mClipCount == 1)
				{
					this.mLegacyShader = true;
					shader = Shader.Find(text + " (SoftClip)");
				}
			}
			else
			{
				shader = Shader.Find(text);
			}
			if (shader == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("{0} shader doesn't have a clipped shader version for {1} clip regions", new object[]
				{
					text,
					this.mClipCount
				});
				shader = Shader.Find("Unlit/Seperate Alpha Colored");
			}
		}
		else
		{
			shader = Shader.Find(text);
		}
		if (this.mMaterial != null)
		{
			if (this.mDynamicMat != null)
			{
				this.mDynamicMat.shader = shader;
			}
			else
			{
				this.mDynamicMat = this.GetMaterial(shader);
			}
			if (this.mDynamicMat.HasProperty("_Mask"))
			{
				this.mDynamicMat.SetTexture("_Mask", null);
			}
			this.mDynamicMat.hideFlags = (HideFlags.DontSave | HideFlags.NotEditable);
			this.mDynamicMat.CopyPropertiesFromMaterial(this.mMaterial);
		}
		else
		{
			if (this.mDynamicMat != null)
			{
				this.mDynamicMat.shader = shader;
			}
			else
			{
				this.mDynamicMat = this.GetMaterial(shader);
			}
			if (this.mDynamicMat.HasProperty("_Mask"))
			{
				this.mDynamicMat.SetTexture("_Mask", null);
			}
			this.mDynamicMat.hideFlags = (HideFlags.DontSave | HideFlags.NotEditable);
		}
		if (!this.useMerge)
		{
			if (this.mAlphaTexture != null && this.mDynamicMat.HasProperty("_Mask"))
			{
				this.mDynamicMat.SetTexture("_Mask", this.mAlphaTexture);
			}
		}
		else
		{
			for (int i = 0; i < this.mAlphaTextureList.Count; i++)
			{
				this.mDynamicMat.SetTexture("_Mask" + i, this.mAlphaTextureList[i]);
			}
		}
	}

	private Material RebuildMaterial()
	{
		this.CreateMaterial();
		this.mDynamicMat.renderQueue = this.mRenderQueue;
		if (!this.useMerge)
		{
			if (this.mTexture != null)
			{
				this.mDynamicMat.mainTexture = this.mTexture;
			}
			else
			{
				this.mDynamicMat.mainTexture = null;
			}
		}
		else
		{
			for (int i = 0; i < this.mTextureList.Count; i++)
			{
				this.mDynamicMat.SetTexture("_MainTex" + i, this.mTextureList[i]);
			}
		}
		if (this.mRenderer != null)
		{
			this.mRenderer.sharedMaterial = this.mDynamicMat;
		}
		return this.mDynamicMat;
	}

	private void UpdateMaterials()
	{
		if (this.mRebuildMat || this.mDynamicMat == null || this.mClipCount != this.panel.clipCount)
		{
			this.RebuildMaterial();
			this.mRebuildMat = false;
		}
		else if (this.mRenderer.sharedMaterial != this.mDynamicMat)
		{
			this.mRenderer.sharedMaterials = new Material[]
			{
				this.mDynamicMat
			};
		}
	}

	public void UpdateGeometry()
	{
		int size = this.verts.size;
		if (size > 0 && size == this.uvs.size && size == this.cols.size && size % 4 == 0)
		{
			if (this.mFilter == null)
			{
				this.mFilter = base.gameObject.GetComponent<MeshFilter>();
			}
			if (this.mFilter == null)
			{
				this.mFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			if (this.verts.size < 65000)
			{
				int num = (this.verts.Count >> 1) * 3;
				bool flag = this.mIndices == null || this.mIndices.Length != num;
				if (this.mMesh == null)
				{
					this.mMesh = new Mesh();
					this.mMesh.hideFlags = HideFlags.DontSave;
					this.mMesh.name = ((!(this.mMaterial != null)) ? "Mesh" : this.mMaterial.name);
					this.mMesh.MarkDynamic();
					flag = true;
				}
				bool flag2 = this.uvs.buffer.Length != this.verts.buffer.Length || this.cols.buffer.Length != this.verts.buffer.Length || (this.norms.buffer != null && this.norms.buffer.Length != this.verts.buffer.Length) || (this.tans.buffer != null && this.tans.buffer.Length != this.verts.buffer.Length);
				if (!flag2 && this.panel.renderQueue != UIPanel.RenderQueue.Automatic)
				{
					flag2 = (this.mMesh == null || this.mMesh.vertexCount != this.verts.buffer.Length);
				}
				if (!flag2 && this.verts.size << 1 < this.verts.buffer.Length)
				{
					flag2 = true;
				}
				this.mTriangles = this.verts.size >> 1;
				if (flag2 || this.verts.buffer.Length > 65000)
				{
					if (flag2 || this.mMesh.vertexCount != this.verts.size)
					{
						this.mMesh.Clear();
						flag = true;
					}
					this.mMesh.vertices = this.verts.ToArray();
					this.mMesh.uv = this.uvs.ToArray();
					this.mMesh.colors32 = this.cols.ToArray();
					if (this.norms != null)
					{
						this.mMesh.normals = this.norms.ToArray();
					}
					if (this.tans != null)
					{
						this.mMesh.tangents = this.tans.ToArray();
					}
				}
				else
				{
					if (this.mMesh.vertexCount != this.verts.buffer.Length)
					{
						this.mMesh.Clear();
						flag = true;
					}
					this.mMesh.vertices = this.verts.buffer;
					this.mMesh.uv = this.uvs.buffer;
					this.mMesh.colors32 = this.cols.buffer;
					if (this.norms != null)
					{
						this.mMesh.normals = this.norms.buffer;
					}
					if (this.tans != null)
					{
						this.mMesh.tangents = this.tans.buffer;
					}
				}
				if (flag)
				{
					this.mIndices = this.GenerateCachedIndexBuffer(this.verts.Count, num);
					this.mMesh.triangles = this.mIndices;
				}
				if (flag2 || !this.alwaysOnScreen)
				{
					this.mMesh.RecalculateBounds();
				}
				this.mFilter.mesh = this.mMesh;
			}
			else
			{
				this.mTriangles = 0;
				if (this.mFilter.mesh != null)
				{
					this.mFilter.mesh.Clear();
				}
				Debug.LogError("Too many vertices on one panel: " + this.verts.size);
			}
			if (this.mRenderer == null)
			{
				this.mRenderer = base.gameObject.GetComponent<MeshRenderer>();
			}
			if (this.mRenderer == null)
			{
				this.mRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			this.UpdateMaterials();
		}
		else
		{
			if (this.mFilter.mesh != null)
			{
				this.mFilter.mesh.Clear();
			}
			Debug.LogError("UIWidgets must fill the buffer with 4 vertices per quad. Found " + size);
		}
		this.verts.Clear();
		this.uvs.Clear();
		this.cols.Clear();
		this.norms.Clear();
		this.tans.Clear();
	}

	private int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
	{
		int i = 0;
		int count = UIDrawCall.mCache.Count;
		while (i < count)
		{
			int[] array = UIDrawCall.mCache[i];
			if (array != null && array.Length == indexCount)
			{
				return array;
			}
			i++;
		}
		int[] array2 = new int[indexCount];
		int num = 0;
		for (int j = 0; j < vertexCount; j += 4)
		{
			array2[num++] = j;
			array2[num++] = j + 1;
			array2[num++] = j + 2;
			array2[num++] = j + 2;
			array2[num++] = j + 3;
			array2[num++] = j;
		}
		if (UIDrawCall.mCache.Count > 20)
		{
			UIDrawCall.mCache.RemoveAt(0);
		}
		UIDrawCall.mCache.Add(array2);
		return array2;
	}

	private void OnWillRenderObject()
	{
		this.UpdateMaterials();
		if (this.mDynamicMat == null)
		{
			return;
		}
		if (this.mClipCount == 0)
		{
			if (this.useMerge)
			{
				for (int i = 0; i < 4; i++)
				{
					this.SetClipping(i, new Vector4(0f, 0f, 10000f, 10000f), new Vector2(0f, 0f), 0f);
				}
			}
			return;
		}
		if (!this.mLegacyShader)
		{
			UIPanel parentPanel = this.panel;
			int num = 0;
			while (parentPanel != null)
			{
				if (parentPanel.hasClipping)
				{
					float angle = 0f;
					Vector4 drawCallClipRange = parentPanel.drawCallClipRange;
					if (parentPanel != this.panel)
					{
						Vector3 vector = parentPanel.cachedTransform.InverseTransformPoint(this.panel.cachedTransform.position);
						drawCallClipRange.x -= vector.x;
						drawCallClipRange.y -= vector.y;
						Vector3 eulerAngles = this.panel.cachedTransform.rotation.eulerAngles;
						Vector3 eulerAngles2 = parentPanel.cachedTransform.rotation.eulerAngles;
						Vector3 vector2 = eulerAngles2 - eulerAngles;
						vector2.x = NGUIMath.WrapAngle(vector2.x);
						vector2.y = NGUIMath.WrapAngle(vector2.y);
						vector2.z = NGUIMath.WrapAngle(vector2.z);
						angle = vector2.z;
					}
					this.SetClipping(num++, drawCallClipRange, parentPanel.clipSoftness, angle);
				}
				parentPanel = parentPanel.parentPanel;
			}
			if (this.useMerge)
			{
				for (int j = num; j < 4; j++)
				{
					this.SetClipping(j, new Vector4(0f, 0f, 10000f, 10000f), new Vector2(0f, 0f), 0f);
				}
			}
		}
		else
		{
			Vector2 clipSoftness = this.panel.clipSoftness;
			Vector4 drawCallClipRange2 = this.panel.drawCallClipRange;
			Vector2 mainTextureOffset = new Vector2(-drawCallClipRange2.x / drawCallClipRange2.z, -drawCallClipRange2.y / drawCallClipRange2.w);
			Vector2 mainTextureScale = new Vector2(1f / drawCallClipRange2.z, 1f / drawCallClipRange2.w);
			Vector2 v = new Vector2(1000f, 1000f);
			if (clipSoftness.x > 0f)
			{
				v.x = drawCallClipRange2.z / clipSoftness.x;
			}
			if (clipSoftness.y > 0f)
			{
				v.y = drawCallClipRange2.w / clipSoftness.y;
			}
			this.mDynamicMat.mainTextureOffset = mainTextureOffset;
			this.mDynamicMat.mainTextureScale = mainTextureScale;
			this.mDynamicMat.SetVector("_ClipSharpness", v);
		}
	}

	private void SetClipping(int index, Vector4 cr, Vector2 soft, float angle)
	{
		angle *= -0.0174532924f;
		Vector2 vector = new Vector2(1000f, 1000f);
		if (soft.x > 0f)
		{
			vector.x = cr.z / soft.x;
		}
		if (soft.y > 0f)
		{
			vector.y = cr.w / soft.y;
		}
		if (index < UIDrawCall.ClipRange.Length)
		{
			this.mDynamicMat.SetVector(UIDrawCall.ClipRange[index], new Vector4(-cr.x / cr.z, -cr.y / cr.w, 1f / cr.z, 1f / cr.w));
			this.mDynamicMat.SetVector(UIDrawCall.ClipArgs[index], new Vector4(vector.x, vector.y, Mathf.Sin(angle), Mathf.Cos(angle)));
		}
	}

	private void OnEnable()
	{
		this.mRebuildMat = true;
	}

	private void OnDisable()
	{
		this.depthStart = 2147483647;
		this.depthEnd = -2147483648;
		this.panel = null;
		this.manager = null;
		this.mMaterial = null;
		this.mTexture = null;
		if (this.mDynamicMat != null)
		{
			UIDrawCall.matCache.Enqueue(this.mDynamicMat);
		}
		this.mDynamicMat = null;
	}

	private void OnDestroy()
	{
		this.Clear();
		this.ClearReference();
		if (this.mMaterial != null)
		{
			this.mMaterial = null;
		}
		NGUITools.DestroyImmediate(this.mMesh);
	}

	public void ClearReference()
	{
		this.mTexture = null;
		this.mAlphaTexture = null;
		if (this.mDynamicMat != null)
		{
			UIDrawCall.matCache.Enqueue(this.mDynamicMat);
			this.mDynamicMat = null;
			this.mRebuildMat = true;
		}
	}

	public void Clear()
	{
		this.verts.Clear();
		this.norms.Clear();
		this.tans.Clear();
		this.uvs.Clear();
		this.cols.Clear();
	}

	private Material GetMaterial(Shader shader)
	{
		if (UIDrawCall.matCache.Count > 0)
		{
			Material material = UIDrawCall.matCache.Dequeue();
			if (material != null)
			{
				material.mainTextureOffset = Vector2.zero;
				material.mainTextureScale = Vector2.one;
				material.shader = shader;
				return material;
			}
		}
		return new Material(shader);
	}

	public static UIDrawCall Create(UIPanel panel, Material mat, Texture tex, Texture alphaTex, Shader shader)
	{
		return UIDrawCall.Create(null, panel, mat, tex, alphaTex, shader);
	}

	public void FillMergeIndex(int index, int count)
	{
		Vector2 b = new Vector2((float)index * 2f, (float)index * 2f);
		for (int i = this.uvs.Count - count; i < this.uvs.Count; i++)
		{
			FastListV2 fastListV;
			BetterList<Vector2> expr_30 = fastListV = this.uvs;
			int i2;
			int expr_33 = i2 = i;
			Vector2 a = fastListV[i2];
			expr_30[expr_33] = a + b;
		}
	}

	public static UIDrawCall CreateMerge(UIPanel pan, Material mat, Shader shader)
	{
		UIDrawCall uIDrawCall = UIDrawCall.Create(pan.name);
		uIDrawCall.gameObject.layer = pan.cachedGameObject.layer;
		uIDrawCall.baseMaterial = mat;
		uIDrawCall.mainTexture = null;
		uIDrawCall.alphaTexture = null;
		uIDrawCall.shader = shader;
		uIDrawCall.renderQueue = pan.startingRenderQueue;
		uIDrawCall.sortingOrder = pan.sortingOrder;
		uIDrawCall.manager = pan;
		uIDrawCall.useMerge = true;
		return uIDrawCall;
	}

	private static UIDrawCall Create(string name, UIPanel pan, Material mat, Texture tex, Texture alphaTex, Shader shader)
	{
		UIDrawCall uIDrawCall = UIDrawCall.Create(name);
		uIDrawCall.gameObject.layer = pan.cachedGameObject.layer;
		uIDrawCall.baseMaterial = mat;
		uIDrawCall.mainTexture = tex;
		uIDrawCall.alphaTexture = alphaTex;
		uIDrawCall.shader = shader;
		uIDrawCall.renderQueue = pan.startingRenderQueue;
		uIDrawCall.sortingOrder = pan.sortingOrder;
		uIDrawCall.manager = pan;
		uIDrawCall.useMerge = false;
		return uIDrawCall;
	}

	private static UIDrawCall Create(string name)
	{
		if (UIDrawCall.mInactiveList.size > 0)
		{
			UIDrawCall uIDrawCall = UIDrawCall.mInactiveList.Pop();
			UIDrawCall.mActiveList.Add(uIDrawCall);
			if (name != null)
			{
				uIDrawCall.name = name;
			}
			NGUITools.SetActive(uIDrawCall.gameObject, true, true, false);
			return uIDrawCall;
		}
		GameObject gameObject = new GameObject(name);
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		UIDrawCall uIDrawCall2 = gameObject.AddComponent<UIDrawCall>();
		UIDrawCall.mActiveList.Add(uIDrawCall2);
		return uIDrawCall2;
	}

	public static void ClearAll()
	{
		bool isPlaying = Application.isPlaying;
		int i = UIDrawCall.mActiveList.size;
		while (i > 0)
		{
			UIDrawCall uIDrawCall = UIDrawCall.mActiveList[--i];
			if (uIDrawCall)
			{
				if (isPlaying)
				{
					NGUITools.SetActive(uIDrawCall.gameObject, false);
				}
				else
				{
					NGUITools.DestroyImmediate(uIDrawCall.gameObject);
				}
			}
		}
		UIDrawCall.mActiveList.Clear();
	}

	public static void ReleaseAll()
	{
		UIDrawCall.ClearAll();
		UIDrawCall.ReleaseInactive();
		while (UIDrawCall.matCache.Count > 0)
		{
			Material obj = UIDrawCall.matCache.Dequeue();
			NGUITools.DestroyImmediate(obj);
		}
	}

	public static void ReleaseInactive()
	{
		int i = UIDrawCall.mInactiveList.size;
		while (i > 0)
		{
			UIDrawCall uIDrawCall = UIDrawCall.mInactiveList[--i];
			if (uIDrawCall)
			{
				uIDrawCall.Clear();
				NGUITools.DestroyImmediate(uIDrawCall.gameObject);
			}
		}
		UIDrawCall.mInactiveList.Clear();
		while (UIDrawCall.matCache.Count > 0)
		{
			Material obj = UIDrawCall.matCache.Dequeue();
			NGUITools.DestroyImmediate(obj);
		}
	}

	public static int Count(UIPanel panel)
	{
		int num = 0;
		for (int i = 0; i < UIDrawCall.mActiveList.size; i++)
		{
			if (UIDrawCall.mActiveList[i].manager == panel)
			{
				num++;
			}
		}
		return num;
	}

	public static void Destroy(UIDrawCall dc)
	{
		if (dc)
		{
			if (Application.isPlaying)
			{
				if (UIDrawCall.mActiveList.Remove(dc))
				{
					NGUITools.SetActive(dc.gameObject, false);
					UIDrawCall.mInactiveList.Add(dc);
				}
			}
			else
			{
				UIDrawCall.mActiveList.Remove(dc);
				NGUITools.DestroyImmediate(dc.gameObject);
			}
		}
	}
}
