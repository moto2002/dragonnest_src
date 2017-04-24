using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/NGUI Progress Bar"), ExecuteInEditMode]
public class UIProgressBar : UIWidgetContainer
{
	public enum FillDirection
	{
		LeftToRight,
		RightToLeft,
		BottomToTop,
		TopToBottom
	}

	public delegate void OnDragFinished();

	public static UIProgressBar current;

	public bool bHideThumbAtEnds = true;

	public UIProgressBar.OnDragFinished onDragFinished;

	public bool bHideFgAtEnds = true;

	public bool UseFillDir;

	public Transform thumb;

	[HideInInspector, SerializeField]
	public UIWidget mBG;

	[HideInInspector, SerializeField]
	public UIWidget mFG;

	[HideInInspector, SerializeField]
	public UIWidget mDG;

	[HideInInspector, SerializeField]
	protected GameObject mFullFx;

	[HideInInspector, SerializeField]
	protected GameObject mFx;

	[HideInInspector, SerializeField]
	protected float mValue = 1f;

	[HideInInspector, SerializeField]
	protected UIProgressBar.FillDirection mFill;

	protected Transform mTrans;

	protected bool mIsDirty;

	protected Camera mCam;

	protected float mOffset;

	protected float mDynamicVal;

	public int numberOfSteps;

	public List<EventDelegate> onChange = new List<EventDelegate>();

	private UIWidget thumbw;

	private Collider thumbCol;

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

	public Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = NGUITools.FindCameraForLayer(base.gameObject.layer);
			}
			return this.mCam;
		}
	}

	public UIWidget foregroundWidget
	{
		get
		{
			return this.mFG;
		}
		set
		{
			if (this.mFG != value)
			{
				this.mFG = value;
				this.mIsDirty = true;
			}
		}
	}

	public UIWidget backgroundWidget
	{
		get
		{
			return this.mBG;
		}
		set
		{
			if (this.mBG != value)
			{
				this.mBG = value;
				this.mIsDirty = true;
			}
		}
	}

	public UIProgressBar.FillDirection fillDirection
	{
		get
		{
			return this.mFill;
		}
		set
		{
			if (this.mFill != value)
			{
				this.mFill = value;
				this.ForceUpdate();
			}
		}
	}

	public float value
	{
		get
		{
			if (this.numberOfSteps > 1)
			{
				return Mathf.Round(this.mValue * (float)(this.numberOfSteps - 1)) / (float)(this.numberOfSteps - 1);
			}
			return this.mValue;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mValue != num)
			{
				float value2 = this.value;
				this.mValue = num;
				if (value2 != this.value)
				{
					this.mIsDirty = true;
					if (num == 0f)
					{
						if (this.bHideFgAtEnds)
						{
							this.mFG.enabled = false;
						}
						if (this.thumb != null && this.bHideThumbAtEnds)
						{
							this.thumb.gameObject.SetActive(false);
						}
					}
					else if (num == 1f)
					{
						this.mFG.enabled = true;
						if (this.thumb != null && this.bHideThumbAtEnds)
						{
							this.thumb.gameObject.SetActive(false);
						}
					}
					else
					{
						this.mFG.enabled = true;
						if (this.thumb != null && this.bHideThumbAtEnds)
						{
							this.thumb.gameObject.SetActive(true);
						}
					}
					if (this.mFullFx != null)
					{
						if (num == 1f)
						{
							this.mFullFx.SetActive(true);
						}
						else
						{
							this.mFullFx.SetActive(false);
						}
					}
					if (UIProgressBar.current == null && NGUITools.GetActive(this) && EventDelegate.IsValid(this.onChange))
					{
						UIProgressBar.current = this;
						EventDelegate.Execute(this.onChange);
						UIProgressBar.current = null;
					}
				}
			}
		}
	}

	public float alpha
	{
		get
		{
			if (this.mFG != null)
			{
				return this.mFG.alpha;
			}
			if (this.mBG != null)
			{
				return this.mBG.alpha;
			}
			return 1f;
		}
		set
		{
			if (this.mFG != null)
			{
				BoxCollider defaultBoxCollider = this.mFG.DefaultBoxCollider;
				this.mFG.alpha = value;
				if (defaultBoxCollider != null)
				{
					defaultBoxCollider.enabled = (this.mFG.alpha > 0.001f);
				}
			}
			if (this.mBG != null)
			{
				BoxCollider defaultBoxCollider2 = this.mBG.DefaultBoxCollider;
				this.mBG.alpha = value;
				if (defaultBoxCollider2 != null)
				{
					defaultBoxCollider2.enabled = (this.mBG.alpha > 0.001f);
				}
			}
			if (this.thumbw != null)
			{
				this.thumbw.alpha = value;
				if (this.thumbCol != null)
				{
					this.thumbCol.enabled = (this.thumbw.alpha > 0.001f);
				}
			}
		}
	}

	protected bool isHorizontal
	{
		get
		{
			return this.mFill == UIProgressBar.FillDirection.LeftToRight || this.mFill == UIProgressBar.FillDirection.RightToLeft;
		}
	}

	protected bool isInverted
	{
		get
		{
			return this.mFill == UIProgressBar.FillDirection.RightToLeft || this.mFill == UIProgressBar.FillDirection.TopToBottom;
		}
	}

	protected void Start()
	{
		this.Upgrade();
		if (this.thumb != null)
		{
			this.thumbw = this.thumb.GetComponent<UIWidget>();
			this.thumbCol = this.thumbw.collider;
		}
		if (Application.isPlaying)
		{
			if (this.mFG == null)
			{
				base.enabled = false;
				return;
			}
			if (this.mBG != null)
			{
				this.mBG.autoResizeBoxCollider = true;
			}
			this.OnStart();
			if (UIProgressBar.current == null && this.onChange != null)
			{
				UIProgressBar.current = this;
				EventDelegate.Execute(this.onChange);
				UIProgressBar.current = null;
			}
		}
		this.ForceUpdate();
	}

	protected virtual void Upgrade()
	{
	}

	protected virtual void OnStart()
	{
	}

	protected void Update()
	{
		if (this.mIsDirty)
		{
			this.ForceUpdate();
		}
	}

	protected void OnValidate()
	{
		if (NGUITools.GetActive(this))
		{
			this.Upgrade();
			this.mIsDirty = true;
			float num = Mathf.Clamp01(this.mValue);
			if (this.mValue != num)
			{
				this.mValue = num;
			}
			if (this.numberOfSteps < 0)
			{
				this.numberOfSteps = 0;
			}
			else if (this.numberOfSteps > 20)
			{
				this.numberOfSteps = 20;
			}
			this.ForceUpdate();
		}
		else
		{
			float num2 = Mathf.Clamp01(this.mValue);
			if (this.mValue != num2)
			{
				this.mValue = num2;
			}
			if (this.numberOfSteps < 0)
			{
				this.numberOfSteps = 0;
			}
			else if (this.numberOfSteps > 20)
			{
				this.numberOfSteps = 20;
			}
		}
	}

	protected float ScreenToValue(Vector2 screenPos)
	{
		Transform cachedTransform = this.cachedTransform;
		Plane plane = new Plane(cachedTransform.rotation * Vector3.back, cachedTransform.position);
		Ray ray = this.cachedCamera.ScreenPointToRay(screenPos);
		float distance;
		if (!plane.Raycast(ray, out distance))
		{
			return this.value;
		}
		return this.LocalToValue(cachedTransform.InverseTransformPoint(ray.GetPoint(distance)));
	}

	protected virtual float LocalToValue(Vector2 localPos)
	{
		if (!(this.mFG != null))
		{
			return this.value;
		}
		Vector3[] localCorners = this.mFG.localCorners;
		Vector3 vector = localCorners[2] - localCorners[0];
		if (this.isHorizontal)
		{
			float num = (localPos.x - localCorners[0].x) / vector.x;
			return (!this.isInverted) ? num : (1f - num);
		}
		float num2 = (localPos.y - localCorners[0].y) / vector.y;
		return (!this.isInverted) ? num2 : (1f - num2);
	}

	public virtual void ForceUpdate()
	{
		this.mIsDirty = false;
		if (this.mFG != null)
		{
			UISprite uISprite = this.mFG as UISprite;
			if (this.isHorizontal)
			{
				if (uISprite != null && uISprite.type == UISprite.Type.Filled)
				{
					uISprite.fillDirection = UISprite.FillDirection.Horizontal;
					uISprite.invert = this.isInverted;
					uISprite.fillAmount = this.value;
				}
				else
				{
					this.mFG.drawRegion = ((!this.isInverted) ? new Vector4(0f, 0f, this.value, 1f) : new Vector4(1f - this.value, 0f, 1f, 1f));
					if (this.mFx != null)
					{
						this.mFx.SetActive(true);
						UIWidget componentInChildren = this.mFx.GetComponentInChildren<UIWidget>();
						if (componentInChildren != null)
						{
							componentInChildren.drawRegion = this.mFG.drawRegion;
						}
					}
				}
				if (this.mDG != null)
				{
					if (this.mDynamicVal > 0f)
					{
						this.mDG.gameObject.SetActive(true);
						this.mDG.drawRegion = ((!this.isInverted) ? new Vector4(0f, 0f, this.mDynamicVal, 1f) : new Vector4(1f - this.mDynamicVal, 0f, 1f, 1f));
					}
					else
					{
						this.mDG.gameObject.SetActive(false);
					}
				}
			}
			else if (uISprite != null && uISprite.type == UISprite.Type.Filled)
			{
				if (!this.UseFillDir)
				{
					uISprite.fillDirection = UISprite.FillDirection.Vertical;
					uISprite.invert = this.isInverted;
				}
				uISprite.fillAmount = this.value;
			}
			else
			{
				this.mFG.drawRegion = ((!this.isInverted) ? new Vector4(0f, 0f, 1f, this.value) : new Vector4(0f, 1f - this.value, 1f, 1f));
			}
		}
		if (this.thumb != null && (this.mFG != null || this.mBG != null))
		{
			Vector3[] array = (!(this.mFG != null)) ? this.mBG.localCorners : this.mFG.localCorners;
			Vector4 vector = (!(this.mFG != null)) ? this.mBG.border : this.mFG.border;
			Vector3[] expr_2D8_cp_0 = array;
			int expr_2D8_cp_1 = 0;
			expr_2D8_cp_0[expr_2D8_cp_1].x = expr_2D8_cp_0[expr_2D8_cp_1].x + vector.x;
			Vector3[] expr_2F2_cp_0 = array;
			int expr_2F2_cp_1 = 1;
			expr_2F2_cp_0[expr_2F2_cp_1].x = expr_2F2_cp_0[expr_2F2_cp_1].x + vector.x;
			Vector3[] expr_30C_cp_0 = array;
			int expr_30C_cp_1 = 2;
			expr_30C_cp_0[expr_30C_cp_1].x = expr_30C_cp_0[expr_30C_cp_1].x - vector.z;
			Vector3[] expr_326_cp_0 = array;
			int expr_326_cp_1 = 3;
			expr_326_cp_0[expr_326_cp_1].x = expr_326_cp_0[expr_326_cp_1].x - vector.z;
			Vector3[] expr_340_cp_0 = array;
			int expr_340_cp_1 = 0;
			expr_340_cp_0[expr_340_cp_1].y = expr_340_cp_0[expr_340_cp_1].y + vector.y;
			Vector3[] expr_35A_cp_0 = array;
			int expr_35A_cp_1 = 1;
			expr_35A_cp_0[expr_35A_cp_1].y = expr_35A_cp_0[expr_35A_cp_1].y - vector.w;
			Vector3[] expr_374_cp_0 = array;
			int expr_374_cp_1 = 2;
			expr_374_cp_0[expr_374_cp_1].y = expr_374_cp_0[expr_374_cp_1].y - vector.w;
			Vector3[] expr_38E_cp_0 = array;
			int expr_38E_cp_1 = 3;
			expr_38E_cp_0[expr_38E_cp_1].y = expr_38E_cp_0[expr_38E_cp_1].y + vector.y;
			Transform transform = (!(this.mFG != null)) ? this.mBG.cachedTransform : this.mFG.cachedTransform;
			for (int i = 0; i < 4; i++)
			{
				array[i] = transform.TransformPoint(array[i]);
			}
			if (this.UseFillDir)
			{
				this.SetThumbRotation();
			}
			else if (this.isHorizontal)
			{
				Vector3 from = Vector3.Lerp(array[0], array[1], 0.5f);
				Vector3 to = Vector3.Lerp(array[2], array[3], 0.5f);
				this.SetThumbPosition(Vector3.Lerp(from, to, (!this.isInverted) ? this.value : (1f - this.value)));
			}
			else
			{
				Vector3 from2 = Vector3.Lerp(array[0], array[3], 0.5f);
				Vector3 to2 = Vector3.Lerp(array[1], array[2], 0.5f);
				this.SetThumbPosition(Vector3.Lerp(from2, to2, (!this.isInverted) ? this.value : (1f - this.value)));
			}
		}
	}

	public void SetDynamicGround(float length, int depth)
	{
		float num = this.mDynamicVal;
		this.mDynamicVal = length;
		if (this.mDG != null)
		{
			this.mDG.depth = depth;
		}
		if (num != this.mDynamicVal)
		{
			this.mIsDirty = true;
		}
	}

	protected void SetThumbPosition(Vector3 worldPos)
	{
		Transform parent = this.thumb.parent;
		if (parent != null)
		{
			worldPos = parent.InverseTransformPoint(worldPos);
			worldPos.x = Mathf.Round(worldPos.x);
			worldPos.y = Mathf.Round(worldPos.y);
			worldPos.z = 0f;
			if (Vector3.Distance(this.thumb.localPosition, worldPos) > 0.001f)
			{
				this.thumb.localPosition = worldPos;
			}
		}
		else if (Vector3.Distance(this.thumb.position, worldPos) > 1E-05f)
		{
			this.thumb.position = worldPos;
		}
	}

	protected void SetThumbRotation()
	{
		if (this.mFG == null)
		{
			return;
		}
		UISprite uISprite = this.mFG as UISprite;
		float num = (!uISprite.invert) ? 1f : -1f;
		this.thumb.localEulerAngles = new Vector3(0f, 0f, uISprite.FillScale * 360f * this.value * num);
	}
}
