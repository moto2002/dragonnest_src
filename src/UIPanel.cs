using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

[AddComponentMenu("NGUI/UI/NGUI Panel"), ExecuteInEditMode]
public class UIPanel : UIRect, IUIRect, IUIPanel
{
	public enum RenderQueue
	{
		Automatic,
		StartAt,
		Explicit
	}

	public delegate void OnGeometryUpdated();

	public delegate void OnClippingMoved(UIPanel panel);

	public static BetterList<UIPanel> list = new BetterList<UIPanel>();

	public UIPanel.OnGeometryUpdated onGeometryUpdated;

	public bool showVertexCount;

	public int vertexCount;

	public bool showInPanelTool = true;

	public bool generateNormals;

	public bool widgetsAreStatic;

	public bool cullWhileDragging;

	public bool alwaysOnScreen;

	public bool anchorOffset;

	public UIPanel.RenderQueue renderQueue;

	public int startingRenderQueue = 3500;

	[NonSerialized]
	public BetterList<UIWidget> widgets = new BetterList<UIWidget>();

	[NonSerialized]
	public BetterList<UIDrawCall> drawCalls = new BetterList<UIDrawCall>();

	[NonSerialized]
	public Matrix4x4 worldToLocal = Matrix4x4.identity;

	[NonSerialized]
	public Vector4 drawCallClipRange = new Vector4(0f, 0f, 1f, 1f);

	public UIPanel.OnClippingMoved onClipMove;

	[HideInInspector, SerializeField]
	private float mAlpha = 1f;

	public bool useMerge;

	public static bool GlobalUseMerge = false;

	public static bool SelectUseMerge = false;

	[HideInInspector, SerializeField]
	private UIDrawCall.Clipping mClipping;

	[HideInInspector, SerializeField]
	private Vector4 mClipRange = new Vector4(0f, 0f, 300f, 200f);

	[HideInInspector, SerializeField]
	private Vector2 mClipSoftness = new Vector2(4f, 4f);

	[HideInInspector, SerializeField]
	private int mDepth;

	[HideInInspector, SerializeField]
	private int mSortingOrder;

	private bool mRebuild;

	private bool mResized;

	private Camera mCam;

	[SerializeField]
	private Vector2 mClipOffset = Vector2.zero;

	private float mCullTime;

	private float mUpdateTime;

	private int mMatrixFrame = -1;

	private int mAlphaFrameID;

	private int mLayer = -1;

	private static float[] mTemp = new float[4];

	private Vector2 mMin = Vector2.zero;

	private Vector2 mMax = Vector2.zero;

	private bool mHalfPixelOffset;

	private bool mSortWidgets;

	[HideInInspector, SerializeField]
	public bool NeedUpdate = true;

	[NonSerialized]
	public bool mNeedUpdateRuntime = true;

	private UIScrollView sv;

	private UIPanel mParentPanel;

	private static Vector3[] mCorners = new Vector3[4];

	private static int mUpdateFrame = -1;

	private static int mLaterUpdateFrame = -1;

	public int updateFrame = 1;

	private int currentFrame;

	private static int skipFrame = 1;

	private bool isUpdate;

	public static Material mergeMaterial = null;

	private bool mForced;

	public static int nextUnusedDepth
	{
		get
		{
			int num = -2147483648;
			for (int i = 0; i < UIPanel.list.size; i++)
			{
				num = Mathf.Max(num, UIPanel.list[i].depth);
			}
			return (num != -2147483648) ? (num + 1) : 0;
		}
	}

	public override bool canBeAnchored
	{
		get
		{
			return this.mClipping != UIDrawCall.Clipping.None;
		}
	}

	public override float alpha
	{
		get
		{
			return this.mAlpha;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mAlpha != num)
			{
				this.mAlphaFrameID = -1;
				this.mResized = true;
				this.mAlpha = num;
				this.SetDirty();
			}
		}
	}

	public int depth
	{
		get
		{
			return this.mDepth;
		}
		set
		{
			if (this.mDepth != value)
			{
				this.mDepth = value;
				UIPanel.list.Sort(new BetterList<UIPanel>.CompareFunc(UIPanel.CompareFunc));
			}
		}
	}

	public int sortingOrder
	{
		get
		{
			return this.mSortingOrder;
		}
		set
		{
			if (this.mSortingOrder != value)
			{
				this.mSortingOrder = value;
				this.UpdateDrawCalls();
			}
		}
	}

	public float width
	{
		get
		{
			return this.GetViewSize().x;
		}
	}

	public float height
	{
		get
		{
			return this.GetViewSize().y;
		}
	}

	public bool halfPixelOffset
	{
		get
		{
			return this.mHalfPixelOffset;
		}
	}

	public bool usedForUI
	{
		get
		{
			return this.mCam != null && this.mCam.isOrthoGraphic;
		}
	}

	public Vector3 drawCallOffset
	{
		get
		{
			if (this.mHalfPixelOffset && this.mCam != null && this.mCam.isOrthoGraphic)
			{
				float num = 1f / this.GetWindowSize().y / this.mCam.orthographicSize;
				return new Vector3(-num, num);
			}
			return Vector3.zero;
		}
	}

	public UIDrawCall.Clipping clipping
	{
		get
		{
			return this.mClipping;
		}
		set
		{
			if (this.mClipping != value)
			{
				this.mResized = true;
				this.mClipping = value;
				this.mMatrixFrame = -1;
			}
		}
	}

	public UIPanel parentPanel
	{
		get
		{
			return this.mParentPanel;
		}
	}

	public int clipCount
	{
		get
		{
			int num = 0;
			UIPanel uIPanel = this;
			while (uIPanel != null)
			{
				if (uIPanel.mClipping == UIDrawCall.Clipping.SoftClip)
				{
					num++;
				}
				uIPanel = uIPanel.mParentPanel;
			}
			return num;
		}
	}

	public bool hasClipping
	{
		get
		{
			return this.mClipping == UIDrawCall.Clipping.SoftClip;
		}
	}

	public bool hasCumulativeClipping
	{
		get
		{
			return this.clipCount != 0;
		}
	}

	[Obsolete("Use 'hasClipping' or 'hasCumulativeClipping' instead")]
	public bool clipsChildren
	{
		get
		{
			return this.hasCumulativeClipping;
		}
	}

	public Vector2 clipOffset
	{
		get
		{
			return this.mClipOffset;
		}
		set
		{
			if (Mathf.Abs(this.mClipOffset.x - value.x) > 0.001f || Mathf.Abs(this.mClipOffset.y - value.y) > 0.001f)
			{
				this.mResized = true;
				this.mCullTime = ((this.mCullTime != 0f) ? (RealTime.time + 0.15f) : 0.001f);
				this.mClipOffset = value;
				this.mMatrixFrame = -1;
				if (this.onClipMove != null)
				{
					this.onClipMove(this);
				}
			}
		}
	}

	[Obsolete("Use 'finalClipRegion' or 'baseClipRegion' instead")]
	public Vector4 clipRange
	{
		get
		{
			return this.baseClipRegion;
		}
		set
		{
			this.baseClipRegion = value;
		}
	}

	public Vector4 baseClipRegion
	{
		get
		{
			return this.mClipRange;
		}
		set
		{
			if (Mathf.Abs(this.mClipRange.x - value.x) > 0.001f || Mathf.Abs(this.mClipRange.y - value.y) > 0.001f || Mathf.Abs(this.mClipRange.z - value.z) > 0.001f || Mathf.Abs(this.mClipRange.w - value.w) > 0.001f)
			{
				this.mResized = true;
				this.mCullTime = ((this.mCullTime != 0f) ? (RealTime.time + 0.15f) : 0.001f);
				this.mClipRange = value;
				this.mMatrixFrame = -1;
				if (this.sv != null)
				{
					this.sv.UpdatePosition();
				}
				if (this.onClipMove != null)
				{
					this.onClipMove(this);
				}
			}
		}
	}

	public Vector4 finalClipRegion
	{
		get
		{
			Vector2 viewSize = this.GetViewSize();
			if (this.mClipping != UIDrawCall.Clipping.None)
			{
				return new Vector4(this.mClipRange.x + this.mClipOffset.x, this.mClipRange.y + this.mClipOffset.y, viewSize.x, viewSize.y);
			}
			return new Vector4(0f, 0f, viewSize.x, viewSize.y);
		}
	}

	public Vector2 clipSoftness
	{
		get
		{
			return this.mClipSoftness;
		}
		set
		{
			if (this.mClipSoftness != value)
			{
				this.mClipSoftness = value;
			}
		}
	}

	public override Vector3[] localCorners
	{
		get
		{
			if (this.mClipping == UIDrawCall.Clipping.None)
			{
				Vector2 viewSize = this.GetViewSize();
				float num = -0.5f * viewSize.x;
				float num2 = -0.5f * viewSize.y;
				float x = num + viewSize.x;
				float y = num2 + viewSize.y;
				Transform transform = (!(this.mCam != null)) ? null : this.mCam.transform;
				if (transform != null)
				{
					UIPanel.mCorners[0] = transform.TransformPoint(num, num2, 0f);
					UIPanel.mCorners[1] = transform.TransformPoint(num, y, 0f);
					UIPanel.mCorners[2] = transform.TransformPoint(x, y, 0f);
					UIPanel.mCorners[3] = transform.TransformPoint(x, num2, 0f);
					transform = base.cachedTransform;
					for (int i = 0; i < 4; i++)
					{
						UIPanel.mCorners[i] = transform.InverseTransformPoint(UIPanel.mCorners[i]);
					}
				}
				else
				{
					UIPanel.mCorners[0] = new Vector3(num, num2);
					UIPanel.mCorners[1] = new Vector3(num, y);
					UIPanel.mCorners[2] = new Vector3(x, y);
					UIPanel.mCorners[3] = new Vector3(x, num2);
				}
			}
			else
			{
				float num3 = this.mClipOffset.x + this.mClipRange.x - 0.5f * this.mClipRange.z;
				float num4 = this.mClipOffset.y + this.mClipRange.y - 0.5f * this.mClipRange.w;
				float x2 = num3 + this.mClipRange.z;
				float y2 = num4 + this.mClipRange.w;
				UIPanel.mCorners[0] = new Vector3(num3, num4);
				UIPanel.mCorners[1] = new Vector3(num3, y2);
				UIPanel.mCorners[2] = new Vector3(x2, y2);
				UIPanel.mCorners[3] = new Vector3(x2, num4);
			}
			return UIPanel.mCorners;
		}
	}

	public override Vector3[] worldCorners
	{
		get
		{
			if (this.mClipping == UIDrawCall.Clipping.None)
			{
				Vector2 viewSize = this.GetViewSize();
				float num = -0.5f * viewSize.x;
				float num2 = -0.5f * viewSize.y;
				float x = num + viewSize.x;
				float y = num2 + viewSize.y;
				Transform transform = (!(this.mCam != null)) ? null : this.mCam.transform;
				if (transform != null)
				{
					UIPanel.mCorners[0] = transform.TransformPoint(num, num2, 0f);
					UIPanel.mCorners[1] = transform.TransformPoint(num, y, 0f);
					UIPanel.mCorners[2] = transform.TransformPoint(x, y, 0f);
					UIPanel.mCorners[3] = transform.TransformPoint(x, num2, 0f);
				}
			}
			else
			{
				float num3 = this.mClipOffset.x + this.mClipRange.x - 0.5f * this.mClipRange.z;
				float num4 = this.mClipOffset.y + this.mClipRange.y - 0.5f * this.mClipRange.w;
				float x2 = num3 + this.mClipRange.z;
				float y2 = num4 + this.mClipRange.w;
				Transform cachedTransform = base.cachedTransform;
				UIPanel.mCorners[0] = cachedTransform.TransformPoint(num3, num4, 0f);
				UIPanel.mCorners[1] = cachedTransform.TransformPoint(num3, y2, 0f);
				UIPanel.mCorners[2] = cachedTransform.TransformPoint(x2, y2, 0f);
				UIPanel.mCorners[3] = cachedTransform.TransformPoint(x2, num4, 0f);
			}
			return UIPanel.mCorners;
		}
	}

	public static int CompareFunc(UIPanel a, UIPanel b)
	{
		if (!(a != b) || !(a != null) || !(b != null))
		{
			return 0;
		}
		if (a.mDepth < b.mDepth)
		{
			return -1;
		}
		if (a.mDepth > b.mDepth)
		{
			return 1;
		}
		return (a.GetInstanceID() >= b.GetInstanceID()) ? 1 : -1;
	}

	public override Vector3[] GetSides(Transform relativeTo)
	{
		if (this.mClipping != UIDrawCall.Clipping.None || this.anchorOffset)
		{
			Vector2 viewSize = this.GetViewSize();
			Vector2 vector = (this.mClipping == UIDrawCall.Clipping.None) ? Vector2.zero : (this.mClipRange + this.mClipOffset);
			float num = vector.x - 0.5f * viewSize.x;
			float num2 = vector.y - 0.5f * viewSize.y;
			float num3 = num + viewSize.x;
			float num4 = num2 + viewSize.y;
			float x = (num + num3) * 0.5f;
			float y = (num2 + num4) * 0.5f;
			Matrix4x4 localToWorldMatrix = base.cachedTransform.localToWorldMatrix;
			UIPanel.mCorners[0] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(num, y));
			UIPanel.mCorners[1] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(x, num4));
			UIPanel.mCorners[2] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(num3, y));
			UIPanel.mCorners[3] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(x, num2));
			if (relativeTo != null)
			{
				for (int i = 0; i < 4; i++)
				{
					UIPanel.mCorners[i] = relativeTo.InverseTransformPoint(UIPanel.mCorners[i]);
				}
			}
			return UIPanel.mCorners;
		}
		return base.GetSides(relativeTo);
	}

	public override void Invalidate(bool includeChildren)
	{
		this.mAlphaFrameID = -1;
		base.Invalidate(includeChildren);
	}

	public override float CalculateFinalAlpha(int frameID)
	{
		if (this.mAlphaFrameID != frameID)
		{
			this.mAlphaFrameID = frameID;
			UIRect parent = base.parent;
			this.finalAlpha = ((!(base.parent != null)) ? this.mAlpha : (parent.CalculateFinalAlpha(frameID) * this.mAlpha));
		}
		return this.finalAlpha;
	}

	public override void SetRect(float x, float y, float width, float height)
	{
		int num = Mathf.FloorToInt(width + 0.5f);
		int num2 = Mathf.FloorToInt(height + 0.5f);
		num = num >> 1 << 1;
		num2 = num2 >> 1 << 1;
		Transform transform = base.cachedTransform;
		Vector3 localPosition = transform.localPosition;
		localPosition.x = Mathf.Floor(x + 0.5f);
		localPosition.y = Mathf.Floor(y + 0.5f);
		if (num < 2)
		{
			num = 2;
		}
		if (num2 < 2)
		{
			num2 = 2;
		}
		this.baseClipRegion = new Vector4(localPosition.x, localPosition.y, (float)num, (float)num2);
		if (base.isAnchored)
		{
			transform = transform.parent;
			if (this.leftAnchor.target)
			{
				this.leftAnchor.SetHorizontal(transform, x);
			}
			if (this.rightAnchor.target)
			{
				this.rightAnchor.SetHorizontal(transform, x + width);
			}
			if (this.bottomAnchor.target)
			{
				this.bottomAnchor.SetVertical(transform, y);
			}
			if (this.topAnchor.target)
			{
				this.topAnchor.SetVertical(transform, y + height);
			}
		}
	}

	public bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		this.UpdateTransformMatrix(false);
		a = this.worldToLocal.MultiplyPoint3x4(a);
		b = this.worldToLocal.MultiplyPoint3x4(b);
		c = this.worldToLocal.MultiplyPoint3x4(c);
		d = this.worldToLocal.MultiplyPoint3x4(d);
		UIPanel.mTemp[0] = a.x;
		UIPanel.mTemp[1] = b.x;
		UIPanel.mTemp[2] = c.x;
		UIPanel.mTemp[3] = d.x;
		float num = Mathf.Min(UIPanel.mTemp);
		float num2 = Mathf.Max(UIPanel.mTemp);
		UIPanel.mTemp[0] = a.y;
		UIPanel.mTemp[1] = b.y;
		UIPanel.mTemp[2] = c.y;
		UIPanel.mTemp[3] = d.y;
		float num3 = Mathf.Min(UIPanel.mTemp);
		float num4 = Mathf.Max(UIPanel.mTemp);
		return num2 >= this.mMin.x && num4 >= this.mMin.y && num <= this.mMax.x && num3 <= this.mMax.y;
	}

	public bool IsVisible(Vector3 worldPos)
	{
		if (this.mAlpha < 0.001f)
		{
			return false;
		}
		if (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip)
		{
			return true;
		}
		this.UpdateTransformMatrix(false);
		Vector3 vector = this.worldToLocal.MultiplyPoint3x4(worldPos);
		return vector.x >= this.mMin.x && vector.y >= this.mMin.y && vector.x <= this.mMax.x && vector.y <= this.mMax.y;
	}

	public bool IsVisible(UIWidget w)
	{
		if ((this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip) && !w.hideIfOffScreen && (this.mParentPanel == null || this.clipCount == 0))
		{
			return true;
		}
		UIPanel uIPanel = this;
		Vector3[] worldCorners = w.worldCorners;
		while (uIPanel != null)
		{
			if (!this.IsVisible(worldCorners[0], worldCorners[1], worldCorners[2], worldCorners[3]))
			{
				return false;
			}
			uIPanel = uIPanel.mParentPanel;
		}
		return true;
	}

	public bool Affects(UIWidget w)
	{
		if (w == null)
		{
			return false;
		}
		UIPanel panel = w.panel;
		if (panel == null)
		{
			return false;
		}
		UIPanel uIPanel = this;
		while (uIPanel != null)
		{
			if (uIPanel == panel)
			{
				return true;
			}
			if (!uIPanel.hasCumulativeClipping)
			{
				return false;
			}
			uIPanel = uIPanel.mParentPanel;
		}
		return false;
	}

	[ContextMenu("Force Refresh")]
	public void RebuildAllDrawCalls()
	{
		this.mRebuild = true;
	}

	public void SetDirty()
	{
		for (int i = 0; i < this.drawCalls.size; i++)
		{
			this.drawCalls.buffer[i].isDirty = true;
		}
		this.Invalidate(true);
	}

	private void Awake()
	{
		this.mGo = base.gameObject;
		this.mTrans = base.transform;
		this.mHalfPixelOffset = (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.XBOX360 || Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.WindowsEditor);
		if (this.mHalfPixelOffset)
		{
			this.mHalfPixelOffset = (SystemInfo.graphicsShaderLevel < 40);
		}
		this.sv = base.GetComponent<UIScrollView>();
	}

	public void SetEnable()
	{
		base.OnEnable();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		Transform parent = base.cachedTransform.parent;
		this.mParentPanel = ((!(parent != null)) ? null : NGUITools.FindInParents<UIPanel>(parent.gameObject));
		this.UpdateNeedUpdate();
	}

	public override void ParentHasChanged()
	{
		base.ParentHasChanged();
		Transform parent = base.cachedTransform.parent;
		this.mParentPanel = ((!(parent != null)) ? null : NGUITools.FindInParents<UIPanel>(parent.gameObject));
		this.UpdateNeedUpdate();
	}

	public override void SetPanel(UIPanel p)
	{
		Transform parent = base.cachedTransform.parent;
		this.mParentPanel = ((!(parent != null)) ? null : NGUITools.FindInParents<UIPanel>(parent.gameObject));
		this.UpdateNeedUpdate();
	}

	protected override void OnStart()
	{
		this.mLayer = this.mGo.layer;
		UICamera uICamera = UICamera.FindCameraForLayer(this.mLayer);
		this.mCam = ((!(uICamera != null)) ? NGUITools.FindCameraForLayer(this.mLayer) : uICamera.cachedCamera);
	}

	protected override void OnInit()
	{
		base.OnInit();
		if (base.rigidbody == null)
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
		}
		this.mRebuild = true;
		this.mAlphaFrameID = -1;
		this.mMatrixFrame = -1;
		UIPanel.list.Add(this);
		UIPanel.list.Sort(new BetterList<UIPanel>.CompareFunc(UIPanel.CompareFunc));
	}

	protected override void OnDisable()
	{
		for (int i = 0; i < this.drawCalls.size; i++)
		{
			UIDrawCall uIDrawCall = this.drawCalls.buffer[i];
			if (uIDrawCall != null)
			{
				UIDrawCall.Destroy(uIDrawCall);
			}
		}
		this.drawCalls.Clear();
		UIPanel.list.Remove(this);
		this.mAlphaFrameID = -1;
		this.mMatrixFrame = -1;
		if (UIPanel.list.size == 0)
		{
			UIDrawCall.ReleaseAll();
			UIPanel.mLaterUpdateFrame = -1;
			UIPanel.mUpdateFrame = -1;
		}
		base.OnDisable();
	}

	private void UpdateTransformMatrix(bool force = false)
	{
		int frameCount = Time.frameCount;
		if (this.mMatrixFrame != frameCount || force)
		{
			this.mMatrixFrame = frameCount;
			this.worldToLocal = base.cachedTransform.worldToLocalMatrix;
			Vector2 vector = this.GetViewSize() * 0.5f;
			float num = this.mClipOffset.x + this.mClipRange.x;
			float num2 = this.mClipOffset.y + this.mClipRange.y;
			this.mMin.x = num - vector.x;
			this.mMin.y = num2 - vector.y;
			this.mMax.x = num + vector.x;
			this.mMax.y = num2 + vector.y;
		}
	}

	protected override void OnAnchor()
	{
		if (this.mClipping == UIDrawCall.Clipping.None)
		{
			return;
		}
		Transform cachedTransform = base.cachedTransform;
		Transform parent = cachedTransform.parent;
		Vector2 viewSize = this.GetViewSize();
		Vector2 vector = cachedTransform.localPosition;
		float num;
		float num2;
		float num3;
		float num4;
		if (this.leftAnchor.target == this.bottomAnchor.target && this.leftAnchor.target == this.rightAnchor.target && this.leftAnchor.target == this.topAnchor.target)
		{
			Vector3[] sides = this.leftAnchor.GetSides(parent);
			if (sides != null)
			{
				num = NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float)this.leftAnchor.absolute;
				num2 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float)this.rightAnchor.absolute;
				num3 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float)this.bottomAnchor.absolute;
				num4 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float)this.topAnchor.absolute;
			}
			else
			{
				Vector2 vector2 = base.GetLocalPos(this.leftAnchor, parent);
				num = vector2.x + (float)this.leftAnchor.absolute;
				num3 = vector2.y + (float)this.bottomAnchor.absolute;
				num2 = vector2.x + (float)this.rightAnchor.absolute;
				num4 = vector2.y + (float)this.topAnchor.absolute;
			}
		}
		else
		{
			if (this.leftAnchor.target)
			{
				Vector3[] sides2 = this.leftAnchor.GetSides(parent);
				if (sides2 != null)
				{
					num = NGUIMath.Lerp(sides2[0].x, sides2[2].x, this.leftAnchor.relative) + (float)this.leftAnchor.absolute;
				}
				else
				{
					num = base.GetLocalPos(this.leftAnchor, parent).x + (float)this.leftAnchor.absolute;
				}
			}
			else
			{
				num = this.mClipRange.x - 0.5f * viewSize.x;
			}
			if (this.rightAnchor.target)
			{
				Vector3[] sides3 = this.rightAnchor.GetSides(parent);
				if (sides3 != null)
				{
					num2 = NGUIMath.Lerp(sides3[0].x, sides3[2].x, this.rightAnchor.relative) + (float)this.rightAnchor.absolute;
				}
				else
				{
					num2 = base.GetLocalPos(this.rightAnchor, parent).x + (float)this.rightAnchor.absolute;
				}
			}
			else
			{
				num2 = this.mClipRange.x + 0.5f * viewSize.x;
			}
			if (this.bottomAnchor.target)
			{
				Vector3[] sides4 = this.bottomAnchor.GetSides(parent);
				if (sides4 != null)
				{
					num3 = NGUIMath.Lerp(sides4[3].y, sides4[1].y, this.bottomAnchor.relative) + (float)this.bottomAnchor.absolute;
				}
				else
				{
					num3 = base.GetLocalPos(this.bottomAnchor, parent).y + (float)this.bottomAnchor.absolute;
				}
			}
			else
			{
				num3 = this.mClipRange.y - 0.5f * viewSize.y;
			}
			if (this.topAnchor.target)
			{
				Vector3[] sides5 = this.topAnchor.GetSides(parent);
				if (sides5 != null)
				{
					num4 = NGUIMath.Lerp(sides5[3].y, sides5[1].y, this.topAnchor.relative) + (float)this.topAnchor.absolute;
				}
				else
				{
					num4 = base.GetLocalPos(this.topAnchor, parent).y + (float)this.topAnchor.absolute;
				}
			}
			else
			{
				num4 = this.mClipRange.y + 0.5f * viewSize.y;
			}
		}
		num -= vector.x + this.mClipOffset.x;
		num2 -= vector.x + this.mClipOffset.x;
		num3 -= vector.y + this.mClipOffset.y;
		num4 -= vector.y + this.mClipOffset.y;
		float x = Mathf.Lerp(num, num2, 0.5f);
		float y = Mathf.Lerp(num3, num4, 0.5f);
		float num5 = num2 - num;
		float num6 = num4 - num3;
		float num7 = Mathf.Max(20f, this.mClipSoftness.x);
		float num8 = Mathf.Max(20f, this.mClipSoftness.y);
		if (num5 < num7)
		{
			num5 = num7;
		}
		if (num6 < num8)
		{
			num6 = num8;
		}
		this.baseClipRegion = new Vector4(x, y, num5, num6);
	}

	private void Update()
	{
		if (UIPanel.mUpdateFrame != Time.frameCount)
		{
			UIPanel.mUpdateFrame = Time.frameCount;
			for (int i = 0; i < UIPanel.list.size; i++)
			{
				UIPanel uIPanel = UIPanel.list.buffer[i];
				if (uIPanel.isUpdate && uIPanel.mNeedUpdateRuntime)
				{
					int j = 0;
					int size = uIPanel.widgets.size;
					while (j < size)
					{
						UIWidget uIWidget = uIPanel.widgets[j];
						if (uIWidget != null)
						{
							uIWidget.ManualUpdate();
						}
						j++;
					}
				}
			}
		}
	}

	public void UpdateNeedUpdate()
	{
		if (!this.NeedUpdate)
		{
			this.mNeedUpdateRuntime = false;
			return;
		}
		UIPanel parentPanel = this.mParentPanel;
		while (parentPanel != null)
		{
			if (!parentPanel.NeedUpdate)
			{
				this.mNeedUpdateRuntime = false;
				return;
			}
			parentPanel = parentPanel.parentPanel;
			if (parentPanel == null || base.root == null || parentPanel.gameObject == base.root.gameObject)
			{
				break;
			}
		}
		this.mNeedUpdateRuntime = true;
	}

	private void LateUpdate()
	{
		if (UIPanel.mLaterUpdateFrame != Time.frameCount)
		{
			UIPanel.mLaterUpdateFrame = Time.frameCount;
			YBillboard.IsUpdate = (UIPanel.mLaterUpdateFrame % 4 == 0);
			for (int i = 0; i < UIPanel.list.size; i++)
			{
				UIPanel uIPanel = UIPanel.list.buffer[i];
				uIPanel.isUpdate = false;
				if (uIPanel.updateFrame > 1)
				{
					uIPanel.currentFrame++;
					uIPanel.currentFrame %= this.updateFrame;
					if (uIPanel.currentFrame == 0)
					{
						uIPanel.isUpdate = true;
					}
				}
				else
				{
					uIPanel.isUpdate = true;
				}
				if (uIPanel.isUpdate && uIPanel.mNeedUpdateRuntime)
				{
					uIPanel.UpdateSelf();
				}
			}
			int num = 3500;
			for (int j = 0; j < UIPanel.list.size; j++)
			{
				UIPanel uIPanel2 = UIPanel.list.buffer[j];
				if (uIPanel2.isUpdate && uIPanel2.mNeedUpdateRuntime)
				{
					if (uIPanel2.renderQueue == UIPanel.RenderQueue.Automatic)
					{
						uIPanel2.startingRenderQueue = num;
						uIPanel2.UpdateDrawCalls();
						num += uIPanel2.drawCalls.size;
					}
					else if (uIPanel2.renderQueue == UIPanel.RenderQueue.StartAt)
					{
						uIPanel2.UpdateDrawCalls();
						if (uIPanel2.drawCalls.size != 0)
						{
							num = Mathf.Max(num, uIPanel2.startingRenderQueue + uIPanel2.drawCalls.size);
						}
					}
					else
					{
						uIPanel2.UpdateDrawCalls();
						if (uIPanel2.drawCalls.size != 0)
						{
							num = Mathf.Max(num, uIPanel2.startingRenderQueue + 1);
						}
					}
				}
			}
		}
	}

	private void UpdateSelf()
	{
		this.mUpdateTime = RealTime.time;
		this.UpdateTransformMatrix(true);
		this.UpdateLayers();
		this.UpdateWidgets();
		if (this.mRebuild)
		{
			this.mRebuild = false;
			this.FillAllDrawCalls();
		}
		else
		{
			int i = 0;
			while (i < this.drawCalls.size)
			{
				UIDrawCall uIDrawCall = this.drawCalls.buffer[i];
				if (uIDrawCall.isDirty && !this.FillDrawCall(uIDrawCall))
				{
					UIDrawCall.Destroy(uIDrawCall);
					this.drawCalls.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}
	}

	public void SortWidgets()
	{
		this.mSortWidgets = false;
		this.widgets.Sort(new BetterList<UIWidget>.CompareFunc(UIWidget.PanelCompareFunc));
	}

	private void FillAllDrawCallsMerge()
	{
		for (int i = 0; i < this.drawCalls.size; i++)
		{
			UIDrawCall.Destroy(this.drawCalls.buffer[i]);
		}
		this.drawCalls.Clear();
		List<Texture> list = new List<Texture>();
		List<Texture> list2 = new List<Texture>();
		List<Texture> list3 = new List<Texture>();
		UIDrawCall uIDrawCall = null;
		this.vertexCount = 0;
		if (this.mSortWidgets)
		{
			this.SortWidgets();
		}
		for (int j = 0; j < this.widgets.size; j++)
		{
			UIWidget uIWidget = this.widgets.buffer[j];
			if (uIWidget.isVisible && uIWidget.hasVertices)
			{
				Material material = uIWidget.material;
				Texture texture = uIWidget.mainTexture;
				Texture texture2 = texture;
				Texture item;
				if (uIWidget.material != null)
				{
					if (uIWidget.material.HasProperty("_Mask"))
					{
						item = uIWidget.material.GetTexture("_Mask");
					}
					else
					{
						item = texture;
						texture = null;
					}
				}
				else
				{
					item = uIWidget.alphaTexture;
				}
				Shader shader = uIWidget.shader;
				if (shader.name == "GUI/Text Shader")
				{
				}
				int num = -1;
				for (int k = 0; k < list2.Count; k++)
				{
					if (list2[k] == texture2)
					{
						num = k;
						break;
					}
				}
				if (num == -1)
				{
					if (list.Count == 4 && uIDrawCall != null && uIDrawCall.verts.size != 0)
					{
						uIDrawCall.mAlphaTextureList = new List<Texture>(list3);
						uIDrawCall.mTextureList = new List<Texture>(list);
						this.drawCalls.Add(uIDrawCall);
						uIDrawCall.UpdateGeometry();
						uIDrawCall = null;
						list3.Clear();
						list.Clear();
						list2.Clear();
					}
					num = list.Count;
					list.Add(texture);
					list2.Add(texture2);
					list3.Add(item);
				}
				Shader x = shader;
				if (x != null)
				{
					if (uIDrawCall == null)
					{
						uIDrawCall = UIDrawCall.CreateMerge(this, UIPanel.mergeMaterial, UIPanel.mergeMaterial.shader);
						uIDrawCall.depthStart = uIWidget.depth;
						uIDrawCall.depthEnd = uIDrawCall.depthStart;
						uIDrawCall.panel = this;
					}
					else
					{
						int depth = uIWidget.depth;
						if (depth < uIDrawCall.depthStart)
						{
							uIDrawCall.depthStart = depth;
						}
						if (depth > uIDrawCall.depthEnd)
						{
							uIDrawCall.depthEnd = depth;
						}
					}
					uIWidget.drawCall = uIDrawCall;
					if (this.generateNormals)
					{
						uIWidget.WriteToBuffers(uIDrawCall.verts, uIDrawCall.uvs, uIDrawCall.cols, uIDrawCall.norms, uIDrawCall.tans);
					}
					else
					{
						uIWidget.WriteToBuffers(uIDrawCall.verts, uIDrawCall.uvs, uIDrawCall.cols, null, null);
					}
					uIWidget.textureIndex = num;
					uIDrawCall.FillMergeIndex(num, uIWidget.geometry.verts.Count);
					this.vertexCount += uIWidget.geometry.verts.Count;
					if (this.vertexCount > 65000)
					{
						XSingleton<XDebug>.singleton.AddWarningLog2("Too many vertex in one panel:{0} {1}", new object[]
						{
							base.name,
							this.vertexCount.ToString()
						});
					}
				}
			}
			else if (uIWidget.calcRenderQueue)
			{
				uIWidget.drawCall = uIDrawCall;
			}
			else
			{
				uIWidget.drawCall = null;
			}
		}
		if (uIDrawCall != null && uIDrawCall.verts.size != 0)
		{
			uIDrawCall.mAlphaTextureList = list3;
			uIDrawCall.mTextureList = list;
			this.drawCalls.Add(uIDrawCall);
			uIDrawCall.UpdateGeometry();
		}
	}

	private void FillAllDrawCalls()
	{
		if (UIPanel.GlobalUseMerge || (UIPanel.SelectUseMerge && this.useMerge))
		{
			this.FillAllDrawCallsMerge();
			return;
		}
		for (int i = 0; i < this.drawCalls.size; i++)
		{
			UIDrawCall.Destroy(this.drawCalls.buffer[i]);
		}
		this.drawCalls.Clear();
		Material material = null;
		Texture texture = null;
		Texture alphaTex = null;
		Shader shader = null;
		UIDrawCall uIDrawCall = null;
		this.vertexCount = 0;
		if (this.mSortWidgets)
		{
			this.SortWidgets();
		}
		for (int j = 0; j < this.widgets.size; j++)
		{
			UIWidget uIWidget = this.widgets.buffer[j];
			if (uIWidget.isVisible && uIWidget.hasVertices)
			{
				Material material2 = uIWidget.material;
				Texture mainTexture = uIWidget.mainTexture;
				Texture alphaTexture = uIWidget.alphaTexture;
				Shader shader2 = uIWidget.shader;
				if (material != material2 || texture != mainTexture || shader != shader2)
				{
					if (uIDrawCall != null && uIDrawCall.verts.size != 0)
					{
						this.drawCalls.Add(uIDrawCall);
						uIDrawCall.UpdateGeometry();
						uIDrawCall = null;
					}
					material = material2;
					texture = mainTexture;
					alphaTex = alphaTexture;
					shader = shader2;
				}
				if (material != null || shader != null || texture != null)
				{
					if (uIDrawCall == null)
					{
						uIDrawCall = UIDrawCall.Create(this, material, texture, alphaTex, shader);
						uIDrawCall.depthStart = uIWidget.depth;
						uIDrawCall.depthEnd = uIDrawCall.depthStart;
						uIDrawCall.panel = this;
					}
					else
					{
						int depth = uIWidget.depth;
						if (depth < uIDrawCall.depthStart)
						{
							uIDrawCall.depthStart = depth;
						}
						if (depth > uIDrawCall.depthEnd)
						{
							uIDrawCall.depthEnd = depth;
						}
					}
					uIWidget.drawCall = uIDrawCall;
					if (this.generateNormals)
					{
						uIWidget.WriteToBuffers(uIDrawCall.verts, uIDrawCall.uvs, uIDrawCall.cols, uIDrawCall.norms, uIDrawCall.tans);
					}
					else
					{
						uIWidget.WriteToBuffers(uIDrawCall.verts, uIDrawCall.uvs, uIDrawCall.cols, null, null);
					}
					this.vertexCount += uIWidget.geometry.verts.Count;
					if (this.vertexCount > 65000)
					{
						XSingleton<XDebug>.singleton.AddWarningLog2("Too many vertex in one panel:{0} {1}", new object[]
						{
							base.name,
							this.vertexCount.ToString()
						});
					}
				}
			}
			else if (uIWidget.calcRenderQueue)
			{
				uIWidget.drawCall = uIDrawCall;
			}
			else
			{
				uIWidget.drawCall = null;
			}
		}
		if (uIDrawCall != null && uIDrawCall.verts.size != 0)
		{
			this.drawCalls.Add(uIDrawCall);
			uIDrawCall.UpdateGeometry();
		}
	}

	private bool FillDrawCallMerge(UIDrawCall dc)
	{
		if (dc != null)
		{
			dc.isDirty = false;
			int i = 0;
			while (i < this.widgets.size)
			{
				UIWidget uIWidget = this.widgets[i];
				if (uIWidget == null)
				{
					this.widgets.RemoveAt(i);
				}
				else
				{
					if (uIWidget.drawCall == dc)
					{
						if (uIWidget.isVisible && uIWidget.hasVertices)
						{
							if (this.generateNormals)
							{
								uIWidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, dc.norms, dc.tans);
							}
							else
							{
								uIWidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, null, null);
							}
							dc.FillMergeIndex(uIWidget.textureIndex, uIWidget.geometry.verts.Count);
						}
						else if (!uIWidget.calcRenderQueue)
						{
							uIWidget.drawCall = null;
						}
					}
					i++;
				}
			}
			if (dc.verts.size != 0)
			{
				dc.UpdateGeometry();
				return true;
			}
		}
		return false;
	}

	private bool FillDrawCall(UIDrawCall dc)
	{
		if (UIPanel.GlobalUseMerge || (UIPanel.SelectUseMerge && this.useMerge))
		{
			return this.FillDrawCallMerge(dc);
		}
		if (dc != null)
		{
			dc.isDirty = false;
			int i = 0;
			while (i < this.widgets.size)
			{
				UIWidget uIWidget = this.widgets[i];
				if (uIWidget == null)
				{
					this.widgets.RemoveAt(i);
				}
				else
				{
					if (uIWidget.drawCall == dc)
					{
						if (uIWidget.isVisible && uIWidget.hasVertices)
						{
							if (this.generateNormals)
							{
								uIWidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, dc.norms, dc.tans);
							}
							else
							{
								uIWidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, null, null);
							}
						}
						else if (!uIWidget.calcRenderQueue)
						{
							uIWidget.drawCall = null;
						}
					}
					i++;
				}
			}
			if (dc.verts.size != 0)
			{
				dc.UpdateGeometry();
				return true;
			}
		}
		return false;
	}

	private void UpdateDrawCalls()
	{
		Transform cachedTransform = base.cachedTransform;
		bool usedForUI = this.usedForUI;
		if (this.clipping != UIDrawCall.Clipping.None)
		{
			this.drawCallClipRange = this.finalClipRegion;
			this.drawCallClipRange.z = this.drawCallClipRange.z * 0.5f;
			this.drawCallClipRange.w = this.drawCallClipRange.w * 0.5f;
		}
		else
		{
			this.drawCallClipRange = Vector4.zero;
		}
		if (this.drawCallClipRange.z == 0f)
		{
			this.drawCallClipRange.z = (float)Screen.width * 0.5f;
		}
		if (this.drawCallClipRange.w == 0f)
		{
			this.drawCallClipRange.w = (float)Screen.height * 0.5f;
		}
		if (this.halfPixelOffset)
		{
			this.drawCallClipRange.x = this.drawCallClipRange.x - 0.5f;
			this.drawCallClipRange.y = this.drawCallClipRange.y + 0.5f;
		}
		Vector3 vector;
		if (usedForUI)
		{
			Transform parent = base.cachedTransform.parent;
			vector = base.cachedTransform.localPosition;
			if (parent != null)
			{
				float num = Mathf.Round(vector.x);
				float num2 = Mathf.Round(vector.y);
				this.drawCallClipRange.x = this.drawCallClipRange.x + (vector.x - num);
				this.drawCallClipRange.y = this.drawCallClipRange.y + (vector.y - num2);
				vector.x = num;
				vector.y = num2;
				vector = parent.TransformPoint(vector);
			}
			vector += this.drawCallOffset;
		}
		else
		{
			vector = cachedTransform.position;
		}
		Quaternion rotation = cachedTransform.rotation;
		Vector3 lossyScale = cachedTransform.lossyScale;
		for (int i = 0; i < this.drawCalls.size; i++)
		{
			UIDrawCall uIDrawCall = this.drawCalls.buffer[i];
			Transform cachedTransform2 = uIDrawCall.cachedTransform;
			cachedTransform2.position = vector;
			cachedTransform2.rotation = rotation;
			cachedTransform2.localScale = lossyScale;
			uIDrawCall.renderQueue = ((this.renderQueue != UIPanel.RenderQueue.Explicit) ? (this.startingRenderQueue + i) : this.startingRenderQueue);
			uIDrawCall.alwaysOnScreen = (this.alwaysOnScreen && (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip));
			uIDrawCall.sortingOrder = this.mSortingOrder;
		}
	}

	private void UpdateLayers()
	{
		if (this.mLayer != base.cachedGameObject.layer)
		{
			this.mLayer = this.mGo.layer;
			UICamera uICamera = UICamera.FindCameraForLayer(this.mLayer);
			this.mCam = ((!(uICamera != null)) ? NGUITools.FindCameraForLayer(this.mLayer) : uICamera.cachedCamera);
			NGUITools.SetChildLayer(base.cachedTransform, this.mLayer);
			for (int i = 0; i < this.drawCalls.size; i++)
			{
				this.drawCalls.buffer[i].gameObject.layer = this.mLayer;
			}
		}
	}

	private void UpdateWidgets()
	{
		bool flag = !this.cullWhileDragging && this.mCullTime > this.mUpdateTime;
		bool flag2 = false;
		if (this.mForced != flag)
		{
			this.mForced = flag;
			this.mResized = true;
		}
		bool hasCumulativeClipping = this.hasCumulativeClipping;
		int i = 0;
		int size = this.widgets.size;
		while (i < size)
		{
			UIWidget uIWidget = this.widgets.buffer[i];
			if (uIWidget.panel == this && uIWidget.enabled)
			{
				int frameCount = Time.frameCount;
				if (uIWidget.UpdateTransform(frameCount) || this.mResized)
				{
					bool visibleByAlpha = flag || uIWidget.CalculateCumulativeAlpha(frameCount) > 0.001f;
					uIWidget.UpdateVisibility(visibleByAlpha, flag || (!hasCumulativeClipping && !uIWidget.hideIfOffScreen) || this.IsVisible(uIWidget));
				}
				if (uIWidget.UpdateGeometry(frameCount))
				{
					flag2 = true;
					if (!this.mRebuild)
					{
						if (uIWidget.drawCall != null)
						{
							uIWidget.drawCall.isDirty = true;
						}
						else
						{
							this.FindDrawCall(uIWidget);
						}
					}
				}
			}
			i++;
		}
		if (flag2 && this.onGeometryUpdated != null)
		{
			this.onGeometryUpdated();
		}
		this.mResized = false;
	}

	public UIDrawCall FindDrawCall(UIWidget w)
	{
		Material material = w.material;
		Texture mainTexture = w.mainTexture;
		int depth = w.depth;
		for (int i = 0; i < this.drawCalls.size; i++)
		{
			UIDrawCall uIDrawCall = this.drawCalls.buffer[i];
			int num = (i != 0) ? (this.drawCalls.buffer[i - 1].depthEnd + 1) : -2147483648;
			int num2 = (i + 1 != this.drawCalls.size) ? (this.drawCalls.buffer[i + 1].depthStart - 1) : 2147483647;
			if (num <= depth && num2 >= depth)
			{
				if (uIDrawCall.baseMaterial == material && uIDrawCall.mainTexture == mainTexture)
				{
					if (w.isVisible)
					{
						w.drawCall = uIDrawCall;
						if (w.hasVertices)
						{
							uIDrawCall.isDirty = true;
						}
						return uIDrawCall;
					}
				}
				else
				{
					this.mRebuild = true;
				}
				return null;
			}
		}
		this.mRebuild = true;
		return null;
	}

	public void AddWidget(UIWidget w)
	{
		if (this.widgets.size == 0)
		{
			this.widgets.Add(w);
		}
		else if (this.mSortWidgets)
		{
			this.widgets.Add(w);
			this.SortWidgets();
		}
		else if (UIWidget.PanelCompareFunc(w, this.widgets[0]) == -1)
		{
			this.widgets.Insert(0, w);
		}
		else
		{
			int i = this.widgets.size;
			while (i > 0)
			{
				if (UIWidget.PanelCompareFunc(w, this.widgets[--i]) != -1)
				{
					this.widgets.Insert(i + 1, w);
					break;
				}
			}
		}
		this.FindDrawCall(w);
	}

	public void RemoveWidget(UIWidget w)
	{
		if (this.widgets.Remove(w) && w.drawCall != null)
		{
			int depth = w.depth;
			if (depth == w.drawCall.depthStart || depth == w.drawCall.depthEnd)
			{
				this.mRebuild = true;
			}
			w.drawCall.isDirty = true;
			if (this.mRebuild)
			{
				w.drawCall.Clear();
			}
			w.drawCall = null;
		}
	}

	public void Refresh()
	{
		this.mRebuild = true;
		if (UIPanel.list.size > 0)
		{
			UIPanel.list[0].LateUpdate();
		}
	}

	public virtual Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
	{
		Vector4 finalClipRegion = this.finalClipRegion;
		float num = finalClipRegion.z * 0.5f;
		float num2 = finalClipRegion.w * 0.5f;
		Vector2 minRect = new Vector2(min.x, min.y);
		Vector2 maxRect = new Vector2(max.x, max.y);
		Vector2 minArea = new Vector2(finalClipRegion.x - num, finalClipRegion.y - num2);
		Vector2 maxArea = new Vector2(finalClipRegion.x + num, finalClipRegion.y + num2);
		if (this.clipping == UIDrawCall.Clipping.SoftClip)
		{
			minArea.x += this.clipSoftness.x;
			minArea.y += this.clipSoftness.y;
			maxArea.x -= this.clipSoftness.x;
			maxArea.y -= this.clipSoftness.y;
		}
		return NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea);
	}

	public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
	{
		Vector3 b = this.CalculateConstrainOffset(targetBounds.min, targetBounds.max);
		if (b.sqrMagnitude > 0f)
		{
			if (immediate)
			{
				target.localPosition += b;
				targetBounds.center += b;
				SpringPosition component = target.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else
			{
				SpringPosition springPosition = SpringPosition.Begin(target.gameObject, target.localPosition + b, 13f);
				springPosition.ignoreTimeScale = true;
				springPosition.worldSpace = false;
			}
			return true;
		}
		return false;
	}

	public bool ConstrainTargetToBounds(Transform target, bool immediate)
	{
		Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(base.cachedTransform, target);
		return this.ConstrainTargetToBounds(target, ref bounds, immediate);
	}

	public static UIPanel Find(Transform trans)
	{
		return UIPanel.Find(trans, false, -1);
	}

	public static UIPanel Find(Transform trans, bool createIfMissing)
	{
		return UIPanel.Find(trans, createIfMissing, -1);
	}

	public static UIPanel Find(Transform trans, bool createIfMissing, int layer)
	{
		UIPanel uIPanel = null;
		while (uIPanel == null && trans != null)
		{
			uIPanel = trans.GetComponent<UIPanel>();
			if (uIPanel != null)
			{
				return uIPanel;
			}
			if (trans.parent == null)
			{
				break;
			}
			trans = trans.parent;
		}
		return (!createIfMissing) ? null : NGUITools.CreateUI(trans, false, layer);
	}

	private Vector2 GetWindowSize()
	{
		UIRoot root = base.root;
		Vector2 vector = new Vector2((float)Screen.width, (float)Screen.height);
		if (root != null)
		{
			vector *= root.GetPixelSizeAdjustment(Screen.height);
		}
		return vector;
	}

	public Vector2 GetViewSize()
	{
		bool flag = this.mClipping != UIDrawCall.Clipping.None;
		Vector2 vector = (!flag) ? new Vector2((float)Screen.width, (float)Screen.height) : new Vector2(this.mClipRange.z, this.mClipRange.w);
		if (!flag)
		{
			UIRoot root = base.root;
			if (root != null)
			{
				vector *= root.GetPixelSizeAdjustment(Screen.height);
			}
		}
		return vector;
	}
}
