using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/UI/NGUI Sprite"), ExecuteInEditMode]
public class UISprite : UIWidget
{
	public enum Type
	{
		Simple,
		Sliced,
		Tiled,
		Filled,
		Advanced
	}

	public enum FillDirection
	{
		Horizontal,
		Vertical,
		Radial90,
		Radial180,
		Radial360
	}

	public enum AdvancedType
	{
		Invisible,
		Sliced,
		Tiled
	}

	public enum Flip
	{
		Nothing,
		Horizontally,
		Vertically,
		Both
	}

	public static UISprite current;

	[HideInInspector, SerializeField]
	private UIAtlas mAtlas;

	[HideInInspector, SerializeField]
	private string mSpriteName;

	[HideInInspector, SerializeField]
	private UISprite.Type mType;

	[HideInInspector, SerializeField]
	private UISprite.FillDirection mFillDirection = UISprite.FillDirection.Radial360;

	[HideInInspector, Range(0f, 1f), SerializeField]
	private float mFillAmount = 1f;

	[HideInInspector, SerializeField]
	private bool mInvert;

	[HideInInspector, SerializeField]
	private UISprite.Flip mFlip;

	[HideInInspector, Range(0f, 1f), SerializeField]
	private float mFillScale = 1f;

	[HideInInspector, SerializeField]
	private bool mFillCenter = true;

	[NonSerialized]
	protected UISpriteData mSprite;

	protected Rect mInnerUV = default(Rect);

	protected Rect mOuterUV = default(Rect);

	private bool mSpriteSet;

	[NonSerialized]
	private Collider col;

	[NonSerialized]
	private Collider2D c2d;

	public UISprite.AdvancedType centerType = UISprite.AdvancedType.Sliced;

	public UISprite.AdvancedType leftType = UISprite.AdvancedType.Sliced;

	public UISprite.AdvancedType rightType = UISprite.AdvancedType.Sliced;

	public UISprite.AdvancedType bottomType = UISprite.AdvancedType.Sliced;

	public UISprite.AdvancedType topType = UISprite.AdvancedType.Sliced;

	public List<EventDelegate> onClick = new List<EventDelegate>();

	private static Vector2[] mTempPos = new Vector2[4];

	private static Vector2[] mTempUVs = new Vector2[4];

	public bool isEnabled
	{
		get
		{
			return base.enabled && ((this.col && this.col.enabled) || (this.c2d && this.c2d.enabled));
		}
	}

	public virtual UISprite.Type type
	{
		get
		{
			return this.mType;
		}
		set
		{
			if (this.mType != value)
			{
				this.mType = value;
				this.MarkAsChanged();
			}
		}
	}

	public UISprite.Flip flip
	{
		get
		{
			return this.mFlip;
		}
		set
		{
			if (this.mFlip != value)
			{
				this.mFlip = value;
				this.MarkAsChanged();
			}
		}
	}

	public float FillScale
	{
		get
		{
			return this.mFillScale;
		}
	}

	public override Material material
	{
		get
		{
			return (!(this.mAtlas != null)) ? null : this.mAtlas.spriteMaterial;
		}
	}

	public UIAtlas atlas
	{
		get
		{
			return this.mAtlas;
		}
		set
		{
			if (this.mAtlas != value)
			{
				base.RemoveFromPanel();
				this.mAtlas = value;
				this.mSpriteSet = false;
				this.mSprite = null;
				if (string.IsNullOrEmpty(this.mSpriteName) && this.mAtlas != null && this.mAtlas.spriteList.Count > 0)
				{
					this.SetAtlasSprite(this.mAtlas.spriteList[0]);
					this.mSpriteName = this.mSprite.name;
				}
				if (!string.IsNullOrEmpty(this.mSpriteName))
				{
					string spriteName = this.mSpriteName;
					this.mSpriteName = string.Empty;
					this.spriteName = spriteName;
					this.MarkAsChanged();
				}
			}
		}
	}

	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (string.IsNullOrEmpty(this.mSpriteName))
				{
					return;
				}
				this.mSpriteName = string.Empty;
				this.mSprite = null;
				this.mChanged = true;
				this.mSpriteSet = false;
			}
			else if (this.mSpriteName != value)
			{
				this.mSpriteName = value;
				this.mSprite = null;
				this.mChanged = true;
				this.mSpriteSet = false;
			}
		}
	}

	public bool isValid
	{
		get
		{
			return this.GetAtlasSprite() != null;
		}
	}

	[Obsolete("Use 'centerType' instead")]
	public bool fillCenter
	{
		get
		{
			return this.centerType != UISprite.AdvancedType.Invisible;
		}
		set
		{
			if (value != (this.centerType != UISprite.AdvancedType.Invisible))
			{
				this.centerType = ((!value) ? UISprite.AdvancedType.Invisible : UISprite.AdvancedType.Sliced);
				this.MarkAsChanged();
			}
		}
	}

	public UISprite.FillDirection fillDirection
	{
		get
		{
			return this.mFillDirection;
		}
		set
		{
			if (this.mFillDirection != value)
			{
				this.mFillDirection = value;
				this.mChanged = true;
			}
		}
	}

	public float fillAmount
	{
		get
		{
			return this.mFillAmount;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mFillAmount != num)
			{
				this.mFillAmount = num;
				this.mChanged = true;
			}
		}
	}

	public bool invert
	{
		get
		{
			return this.mInvert;
		}
		set
		{
			if (this.mInvert != value)
			{
				this.mInvert = value;
				this.mChanged = true;
			}
		}
	}

	public override Vector4 border
	{
		get
		{
			if (this.type != UISprite.Type.Sliced && this.type != UISprite.Type.Advanced)
			{
				return base.border;
			}
			UISpriteData atlasSprite = this.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return Vector2.zero;
			}
			return new Vector4((float)atlasSprite.borderLeft, (float)atlasSprite.borderBottom, (float)atlasSprite.borderRight, (float)atlasSprite.borderTop);
		}
	}

	public override int minWidth
	{
		get
		{
			if (this.type == UISprite.Type.Sliced || this.type == UISprite.Type.Advanced)
			{
				Vector4 a = this.border;
				if (this.atlas != null)
				{
					a *= this.atlas.pixelSize;
				}
				int num = Mathf.RoundToInt(a.x + a.z);
				UISpriteData atlasSprite = this.GetAtlasSprite();
				if (atlasSprite != null)
				{
					num += atlasSprite.paddingLeft + atlasSprite.paddingRight;
				}
				return Mathf.Max(base.minWidth, ((num & 1) != 1) ? num : (num + 1));
			}
			return base.minWidth;
		}
	}

	public override int minHeight
	{
		get
		{
			if (this.type == UISprite.Type.Sliced || this.type == UISprite.Type.Advanced)
			{
				Vector4 a = this.border;
				if (this.atlas != null)
				{
					a *= this.atlas.pixelSize;
				}
				int num = Mathf.RoundToInt(a.y + a.w);
				UISpriteData atlasSprite = this.GetAtlasSprite();
				if (atlasSprite != null)
				{
					num += atlasSprite.paddingTop + atlasSprite.paddingBottom;
				}
				return Mathf.Max(base.minHeight, ((num & 1) != 1) ? num : (num + 1));
			}
			return base.minHeight;
		}
	}

	public override Vector4 drawingDimensions
	{
		get
		{
			Vector2 pivotOffset = base.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float num3 = num + (float)this.mWidth;
			float num4 = num2 + (float)this.mHeight;
			if (this.GetAtlasSprite() != null && this.mType != UISprite.Type.Tiled)
			{
				int paddingLeft = this.mSprite.paddingLeft;
				int paddingBottom = this.mSprite.paddingBottom;
				int num5 = this.mSprite.paddingRight;
				int num6 = this.mSprite.paddingTop;
				int num7 = this.mSprite.width + paddingLeft + num5;
				int num8 = this.mSprite.height + paddingBottom + num6;
				float num9 = 1f;
				float num10 = 1f;
				if (num7 > 0 && num8 > 0 && (this.mType == UISprite.Type.Simple || this.mType == UISprite.Type.Filled))
				{
					if ((num7 & 1) != 0)
					{
						num5++;
					}
					if ((num8 & 1) != 0)
					{
						num6++;
					}
					num9 = 1f / (float)num7 * (float)this.mWidth;
					num10 = 1f / (float)num8 * (float)this.mHeight;
				}
				if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
				{
					num += (float)num5 * num9;
					num3 -= (float)paddingLeft * num9;
				}
				else
				{
					num += (float)paddingLeft * num9;
					num3 -= (float)num5 * num9;
				}
				if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
				{
					num2 += (float)num6 * num10;
					num4 -= (float)paddingBottom * num10;
				}
				else
				{
					num2 += (float)paddingBottom * num10;
					num4 -= (float)num6 * num10;
				}
			}
			Vector4 vector = (!(this.mAtlas != null)) ? Vector4.zero : (this.border * this.mAtlas.pixelSize);
			float num11 = vector.x + vector.z;
			float num12 = vector.y + vector.w;
			float x = Mathf.Lerp(num, num3 - num11, this.mDrawRegion.x);
			float y = Mathf.Lerp(num2, num4 - num12, this.mDrawRegion.y);
			float z = Mathf.Lerp(num + num11, num3, this.mDrawRegion.z);
			float w = Mathf.Lerp(num2 + num12, num4, this.mDrawRegion.w);
			return new Vector4(x, y, z, w);
		}
	}

	protected virtual Vector4 drawingUVs
	{
		get
		{
			switch (this.mFlip)
			{
			case UISprite.Flip.Horizontally:
				return new Vector4(this.mOuterUV.xMax, this.mOuterUV.yMin, this.mOuterUV.xMin, this.mOuterUV.yMax);
			case UISprite.Flip.Vertically:
				return new Vector4(this.mOuterUV.xMin, this.mOuterUV.yMax, this.mOuterUV.xMax, this.mOuterUV.yMin);
			case UISprite.Flip.Both:
				return new Vector4(this.mOuterUV.xMax, this.mOuterUV.yMax, this.mOuterUV.xMin, this.mOuterUV.yMin);
			default:
				return new Vector4(this.mOuterUV.xMin, this.mOuterUV.yMin, this.mOuterUV.xMax, this.mOuterUV.yMax);
			}
		}
	}

	protected virtual void OnClick()
	{
		if (UISprite.current == null && this.isEnabled)
		{
			UISprite.current = this;
			EventDelegate.Execute(this.onClick);
			UISprite.current = null;
		}
	}

	protected override void OnStart()
	{
		base.OnStart();
		this.col = base.collider;
		this.c2d = base.GetComponent<Collider2D>();
	}

	public UISpriteData GetAtlasSprite()
	{
		if (!this.mSpriteSet)
		{
			this.mSprite = null;
		}
		if (this.mSprite == null && this.mAtlas != null)
		{
			if (!string.IsNullOrEmpty(this.mSpriteName))
			{
				UISpriteData sprite = this.mAtlas.GetSprite(this.mSpriteName);
				if (sprite == null)
				{
					return null;
				}
				this.SetAtlasSprite(sprite);
			}
			if (this.mSprite == null && this.mAtlas.spriteList.Count > 0)
			{
				UISpriteData uISpriteData = this.mAtlas.spriteList[0];
				if (uISpriteData == null)
				{
					return null;
				}
				this.SetAtlasSprite(uISpriteData);
				if (this.mSprite == null)
				{
					Debug.LogError(this.mAtlas.name + " seems to have a null sprite!");
					return null;
				}
				this.mSpriteName = this.mSprite.name;
			}
		}
		return this.mSprite;
	}

	protected void SetAtlasSprite(UISpriteData sp)
	{
		this.mChanged = true;
		this.mSpriteSet = true;
		if (sp != null)
		{
			this.mSprite = sp;
			this.mSpriteName = this.mSprite.name;
		}
		else
		{
			this.mSpriteName = ((this.mSprite == null) ? string.Empty : this.mSprite.name);
			this.mSprite = sp;
		}
	}

	public override void MakePixelPerfect()
	{
		if (!this.isValid)
		{
			return;
		}
		base.MakePixelPerfect();
		UISpriteData atlasSprite = this.GetAtlasSprite();
		if (atlasSprite == null)
		{
			return;
		}
		UISprite.Type type = this.type;
		if (type == UISprite.Type.Simple || type == UISprite.Type.Filled || !atlasSprite.hasBorder)
		{
			Texture mainTexture = this.mainTexture;
			if (mainTexture != null && atlasSprite != null)
			{
				int num = Mathf.RoundToInt(this.atlas.pixelSize * (float)(atlasSprite.width + atlasSprite.paddingLeft + atlasSprite.paddingRight));
				int num2 = Mathf.RoundToInt(this.atlas.pixelSize * (float)(atlasSprite.height + atlasSprite.paddingTop + atlasSprite.paddingBottom));
				if ((num & 1) == 1)
				{
					num++;
				}
				if ((num2 & 1) == 1)
				{
					num2++;
				}
				base.width = num;
				base.height = num2;
			}
		}
	}

	protected override void OnInit()
	{
		if (!this.mFillCenter)
		{
			this.mFillCenter = true;
			this.centerType = UISprite.AdvancedType.Invisible;
		}
		base.OnInit();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (this.mChanged || !this.mSpriteSet)
		{
			this.mSpriteSet = true;
			this.mSprite = null;
			this.mChanged = true;
		}
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		if (this.mSprite == null)
		{
			this.mSprite = this.atlas.GetSprite(this.spriteName);
		}
		if (this.mSprite == null)
		{
			return;
		}
		this.mOuterUV.Set((float)this.mSprite.x, (float)this.mSprite.y, (float)this.mSprite.width, (float)this.mSprite.height);
		this.mInnerUV.Set((float)(this.mSprite.x + this.mSprite.borderLeft), (float)(this.mSprite.y + this.mSprite.borderTop), (float)(this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight), (float)(this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop));
		this.mOuterUV = NGUIMath.ConvertToTexCoords(this.mOuterUV, mainTexture.width, mainTexture.height);
		this.mInnerUV = NGUIMath.ConvertToTexCoords(this.mInnerUV, mainTexture.width, mainTexture.height);
		switch (this.type)
		{
		case UISprite.Type.Simple:
			this.SimpleFill(verts, uvs, cols);
			break;
		case UISprite.Type.Sliced:
			this.SlicedFill(verts, uvs, cols);
			break;
		case UISprite.Type.Tiled:
			this.TiledFill(verts, uvs, cols);
			break;
		case UISprite.Type.Filled:
			this.FilledFill(verts, uvs, cols);
			break;
		case UISprite.Type.Advanced:
			this.AdvancedFill(verts, uvs, cols);
			break;
		}
	}

	protected void SimpleFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Vector4 drawingDimensions = this.drawingDimensions;
		Vector4 drawingUVs = this.drawingUVs;
		verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.y));
		verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.w));
		verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.w));
		verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.y));
		uvs.Add(new Vector2(drawingUVs.x, drawingUVs.y));
		uvs.Add(new Vector2(drawingUVs.x, drawingUVs.w));
		uvs.Add(new Vector2(drawingUVs.z, drawingUVs.w));
		uvs.Add(new Vector2(drawingUVs.z, drawingUVs.y));
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
	}

	protected void SlicedFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		if (!this.mSprite.hasBorder)
		{
			this.SimpleFill(verts, uvs, cols);
			return;
		}
		Vector4 drawingDimensions = this.drawingDimensions;
		Vector4 vector = this.border * this.atlas.pixelSize;
		UISprite.mTempPos[0].x = drawingDimensions.x;
		UISprite.mTempPos[0].y = drawingDimensions.y;
		UISprite.mTempPos[3].x = drawingDimensions.z;
		UISprite.mTempPos[3].y = drawingDimensions.w;
		if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
		{
			UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector.z;
			UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector.x;
			UISprite.mTempUVs[3].x = this.mOuterUV.xMin;
			UISprite.mTempUVs[2].x = this.mInnerUV.xMin;
			UISprite.mTempUVs[1].x = this.mInnerUV.xMax;
			UISprite.mTempUVs[0].x = this.mOuterUV.xMax;
		}
		else
		{
			UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector.x;
			UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector.z;
			UISprite.mTempUVs[0].x = this.mOuterUV.xMin;
			UISprite.mTempUVs[1].x = this.mInnerUV.xMin;
			UISprite.mTempUVs[2].x = this.mInnerUV.xMax;
			UISprite.mTempUVs[3].x = this.mOuterUV.xMax;
		}
		if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
		{
			UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector.w;
			UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector.y;
			UISprite.mTempUVs[3].y = this.mOuterUV.yMin;
			UISprite.mTempUVs[2].y = this.mInnerUV.yMin;
			UISprite.mTempUVs[1].y = this.mInnerUV.yMax;
			UISprite.mTempUVs[0].y = this.mOuterUV.yMax;
		}
		else
		{
			UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector.y;
			UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector.w;
			UISprite.mTempUVs[0].y = this.mOuterUV.yMin;
			UISprite.mTempUVs[1].y = this.mInnerUV.yMin;
			UISprite.mTempUVs[2].y = this.mInnerUV.yMax;
			UISprite.mTempUVs[3].y = this.mOuterUV.yMax;
		}
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		for (int i = 0; i < 3; i++)
		{
			int num = i + 1;
			for (int j = 0; j < 3; j++)
			{
				if (this.centerType != UISprite.AdvancedType.Invisible || i != 1 || j != 1)
				{
					int num2 = j + 1;
					verts.Add(new Vector3(UISprite.mTempPos[i].x, UISprite.mTempPos[j].y));
					verts.Add(new Vector3(UISprite.mTempPos[i].x, UISprite.mTempPos[num2].y));
					verts.Add(new Vector3(UISprite.mTempPos[num].x, UISprite.mTempPos[num2].y));
					verts.Add(new Vector3(UISprite.mTempPos[num].x, UISprite.mTempPos[j].y));
					uvs.Add(new Vector2(UISprite.mTempUVs[i].x, UISprite.mTempUVs[j].y));
					uvs.Add(new Vector2(UISprite.mTempUVs[i].x, UISprite.mTempUVs[num2].y));
					uvs.Add(new Vector2(UISprite.mTempUVs[num].x, UISprite.mTempUVs[num2].y));
					uvs.Add(new Vector2(UISprite.mTempUVs[num].x, UISprite.mTempUVs[j].y));
					cols.Add(item);
					cols.Add(item);
					cols.Add(item);
					cols.Add(item);
				}
			}
		}
	}

	protected void TiledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Texture mainTexture = this.material.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		Vector4 drawingDimensions = this.drawingDimensions;
		Vector4 vector;
		if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
		{
			vector.x = this.mInnerUV.xMax;
			vector.z = this.mInnerUV.xMin;
		}
		else
		{
			vector.x = this.mInnerUV.xMin;
			vector.z = this.mInnerUV.xMax;
		}
		if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
		{
			vector.y = this.mInnerUV.yMax;
			vector.w = this.mInnerUV.yMin;
		}
		else
		{
			vector.y = this.mInnerUV.yMin;
			vector.w = this.mInnerUV.yMax;
		}
		Vector2 a = new Vector2(this.mInnerUV.width * (float)mainTexture.width, this.mInnerUV.height * (float)mainTexture.height);
		a *= this.atlas.pixelSize;
		if (a.x < 2f || a.y < 2f)
		{
			return;
		}
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		float num = drawingDimensions.x;
		float num2 = drawingDimensions.y;
		float x = vector.x;
		float y = vector.y;
		while (num2 < drawingDimensions.w)
		{
			num = drawingDimensions.x;
			float num3 = num2 + a.y;
			float y2 = vector.w;
			if (num3 > drawingDimensions.w)
			{
				y2 = Mathf.Lerp(vector.y, vector.w, (drawingDimensions.w - num2) / a.y);
				num3 = drawingDimensions.w;
			}
			while (num < drawingDimensions.z)
			{
				float num4 = num + a.x;
				float x2 = vector.z;
				if (num4 > drawingDimensions.z)
				{
					x2 = Mathf.Lerp(vector.x, vector.z, (drawingDimensions.z - num) / a.x);
					num4 = drawingDimensions.z;
				}
				verts.Add(new Vector3(num, num2));
				verts.Add(new Vector3(num, num3));
				verts.Add(new Vector3(num4, num3));
				verts.Add(new Vector3(num4, num2));
				uvs.Add(new Vector2(x, y));
				uvs.Add(new Vector2(x, y2));
				uvs.Add(new Vector2(x2, y2));
				uvs.Add(new Vector2(x2, y));
				cols.Add(item);
				cols.Add(item);
				cols.Add(item);
				cols.Add(item);
				num += a.x;
			}
			num2 += a.y;
		}
	}

	protected void FilledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		if (this.mFillAmount < 0.001f)
		{
			return;
		}
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		Vector4 drawingDimensions = this.drawingDimensions;
		Vector4 drawingUVs = this.drawingUVs;
		if (this.mFillDirection == UISprite.FillDirection.Horizontal || this.mFillDirection == UISprite.FillDirection.Vertical)
		{
			if (this.mFillDirection == UISprite.FillDirection.Horizontal)
			{
				float num = (drawingUVs.z - drawingUVs.x) * this.mFillAmount;
				if (this.mInvert)
				{
					drawingDimensions.x = drawingDimensions.z - (drawingDimensions.z - drawingDimensions.x) * this.mFillAmount;
					drawingUVs.x = drawingUVs.z - num;
				}
				else
				{
					drawingDimensions.z = drawingDimensions.x + (drawingDimensions.z - drawingDimensions.x) * this.mFillAmount;
					drawingUVs.z = drawingUVs.x + num;
				}
			}
			else if (this.mFillDirection == UISprite.FillDirection.Vertical)
			{
				float num2 = (drawingUVs.w - drawingUVs.y) * this.mFillAmount;
				if (this.mInvert)
				{
					drawingDimensions.y = drawingDimensions.w - (drawingDimensions.w - drawingDimensions.y) * this.mFillAmount;
					drawingUVs.y = drawingUVs.w - num2;
				}
				else
				{
					drawingDimensions.w = drawingDimensions.y + (drawingDimensions.w - drawingDimensions.y) * this.mFillAmount;
					drawingUVs.w = drawingUVs.y + num2;
				}
			}
		}
		UISprite.mTempPos[0] = new Vector2(drawingDimensions.x, drawingDimensions.y);
		UISprite.mTempPos[1] = new Vector2(drawingDimensions.x, drawingDimensions.w);
		UISprite.mTempPos[2] = new Vector2(drawingDimensions.z, drawingDimensions.w);
		UISprite.mTempPos[3] = new Vector2(drawingDimensions.z, drawingDimensions.y);
		UISprite.mTempUVs[0] = new Vector2(drawingUVs.x, drawingUVs.y);
		UISprite.mTempUVs[1] = new Vector2(drawingUVs.x, drawingUVs.w);
		UISprite.mTempUVs[2] = new Vector2(drawingUVs.z, drawingUVs.w);
		UISprite.mTempUVs[3] = new Vector2(drawingUVs.z, drawingUVs.y);
		if (this.mFillAmount < 1f)
		{
			if (this.mFillDirection == UISprite.FillDirection.Radial90)
			{
				if (UISprite.RadialCut(UISprite.mTempPos, UISprite.mTempUVs, this.mFillAmount, this.mInvert, 0))
				{
					for (int i = 0; i < 4; i++)
					{
						verts.Add(UISprite.mTempPos[i]);
						uvs.Add(UISprite.mTempUVs[i]);
						cols.Add(item);
					}
				}
				return;
			}
			if (this.mFillDirection == UISprite.FillDirection.Radial180)
			{
				for (int j = 0; j < 2; j++)
				{
					float t = 0f;
					float t2 = 1f;
					float t3;
					float t4;
					if (j == 0)
					{
						t3 = 0f;
						t4 = 0.5f;
					}
					else
					{
						t3 = 0.5f;
						t4 = 1f;
					}
					UISprite.mTempPos[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t3);
					UISprite.mTempPos[1].x = UISprite.mTempPos[0].x;
					UISprite.mTempPos[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t4);
					UISprite.mTempPos[3].x = UISprite.mTempPos[2].x;
					UISprite.mTempPos[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t);
					UISprite.mTempPos[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t2);
					UISprite.mTempPos[2].y = UISprite.mTempPos[1].y;
					UISprite.mTempPos[3].y = UISprite.mTempPos[0].y;
					UISprite.mTempUVs[0].x = Mathf.Lerp(drawingUVs.x, drawingUVs.z, t3);
					UISprite.mTempUVs[1].x = UISprite.mTempUVs[0].x;
					UISprite.mTempUVs[2].x = Mathf.Lerp(drawingUVs.x, drawingUVs.z, t4);
					UISprite.mTempUVs[3].x = UISprite.mTempUVs[2].x;
					UISprite.mTempUVs[0].y = Mathf.Lerp(drawingUVs.y, drawingUVs.w, t);
					UISprite.mTempUVs[1].y = Mathf.Lerp(drawingUVs.y, drawingUVs.w, t2);
					UISprite.mTempUVs[2].y = UISprite.mTempUVs[1].y;
					UISprite.mTempUVs[3].y = UISprite.mTempUVs[0].y;
					float value = this.mInvert ? (this.mFillAmount * 2f - (float)(1 - j)) : (this.fillAmount * 2f - (float)j);
					if (UISprite.RadialCut(UISprite.mTempPos, UISprite.mTempUVs, Mathf.Clamp01(value), !this.mInvert, NGUIMath.RepeatIndex(j + 3, 4)))
					{
						for (int k = 0; k < 4; k++)
						{
							verts.Add(UISprite.mTempPos[k]);
							uvs.Add(UISprite.mTempUVs[k]);
							cols.Add(item);
						}
					}
				}
				return;
			}
		}
		if (this.mFillDirection == UISprite.FillDirection.Radial360)
		{
			for (int l = 0; l < 4; l++)
			{
				float t5;
				float t6;
				if (l < 2)
				{
					t5 = 0f;
					t6 = 0.5f;
				}
				else
				{
					t5 = 0.5f;
					t6 = 1f;
				}
				float t7;
				float t8;
				if (l == 0 || l == 3)
				{
					t7 = 0f;
					t8 = 0.5f;
				}
				else
				{
					t7 = 0.5f;
					t8 = 1f;
				}
				UISprite.mTempPos[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t5);
				UISprite.mTempPos[1].x = UISprite.mTempPos[0].x;
				UISprite.mTempPos[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t6);
				UISprite.mTempPos[3].x = UISprite.mTempPos[2].x;
				UISprite.mTempPos[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t7);
				UISprite.mTempPos[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t8);
				UISprite.mTempPos[2].y = UISprite.mTempPos[1].y;
				UISprite.mTempPos[3].y = UISprite.mTempPos[0].y;
				UISprite.mTempUVs[0].x = Mathf.Lerp(drawingUVs.x, drawingUVs.z, t5);
				UISprite.mTempUVs[1].x = UISprite.mTempUVs[0].x;
				UISprite.mTempUVs[2].x = Mathf.Lerp(drawingUVs.x, drawingUVs.z, t6);
				UISprite.mTempUVs[3].x = UISprite.mTempUVs[2].x;
				UISprite.mTempUVs[0].y = Mathf.Lerp(drawingUVs.y, drawingUVs.w, t7);
				UISprite.mTempUVs[1].y = Mathf.Lerp(drawingUVs.y, drawingUVs.w, t8);
				UISprite.mTempUVs[2].y = UISprite.mTempUVs[1].y;
				UISprite.mTempUVs[3].y = UISprite.mTempUVs[0].y;
				float value2 = (!this.mInvert) ? (this.mFillAmount * 4f * this.mFillScale - (float)(3 - NGUIMath.RepeatIndex(l + 2, 4))) : (this.mFillAmount * 4f * this.mFillScale - (float)NGUIMath.RepeatIndex(l + 2, 4));
				if (UISprite.RadialCut(UISprite.mTempPos, UISprite.mTempUVs, Mathf.Clamp01(value2), this.mInvert, NGUIMath.RepeatIndex(l + 2, 4)))
				{
					for (int m = 0; m < 4; m++)
					{
						verts.Add(UISprite.mTempPos[m]);
						uvs.Add(UISprite.mTempUVs[m]);
						cols.Add(item);
					}
				}
			}
			return;
		}
		for (int n = 0; n < 4; n++)
		{
			verts.Add(UISprite.mTempPos[n]);
			uvs.Add(UISprite.mTempUVs[n]);
			cols.Add(item);
		}
	}

	private static bool RadialCut(Vector2[] xy, Vector2[] uv, float fill, bool invert, int corner)
	{
		if (fill < 0.001f)
		{
			return false;
		}
		if ((corner & 1) == 1)
		{
			invert = !invert;
		}
		if (!invert && fill > 0.999f)
		{
			return true;
		}
		float num = Mathf.Clamp01(fill);
		if (invert)
		{
			num = 1f - num;
		}
		num *= 1.57079637f;
		float cos = Mathf.Cos(num);
		float sin = Mathf.Sin(num);
		UISprite.RadialCut(xy, cos, sin, invert, corner);
		UISprite.RadialCut(uv, cos, sin, invert, corner);
		return true;
	}

	private static void RadialCut(Vector2[] xy, float cos, float sin, bool invert, int corner)
	{
		int num = NGUIMath.RepeatIndex(corner + 1, 4);
		int num2 = NGUIMath.RepeatIndex(corner + 2, 4);
		int num3 = NGUIMath.RepeatIndex(corner + 3, 4);
		if ((corner & 1) == 1)
		{
			if (sin > cos)
			{
				cos /= sin;
				sin = 1f;
				if (invert)
				{
					xy[num].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
					xy[num2].x = xy[num].x;
				}
			}
			else if (cos > sin)
			{
				sin /= cos;
				cos = 1f;
				if (!invert)
				{
					xy[num2].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
					xy[num3].y = xy[num2].y;
				}
			}
			else
			{
				cos = 1f;
				sin = 1f;
			}
			if (!invert)
			{
				xy[num3].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
			}
			else
			{
				xy[num].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
			}
		}
		else
		{
			if (cos > sin)
			{
				sin /= cos;
				cos = 1f;
				if (!invert)
				{
					xy[num].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
					xy[num2].y = xy[num].y;
				}
			}
			else if (sin > cos)
			{
				cos /= sin;
				sin = 1f;
				if (invert)
				{
					xy[num2].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
					xy[num3].x = xy[num2].x;
				}
			}
			else
			{
				cos = 1f;
				sin = 1f;
			}
			if (invert)
			{
				xy[num3].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
			}
			else
			{
				xy[num].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
			}
		}
	}

	protected void AdvancedFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		if (!this.mSprite.hasBorder)
		{
			this.SimpleFill(verts, uvs, cols);
			return;
		}
		Texture mainTexture = this.material.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		Vector4 drawingDimensions = this.drawingDimensions;
		Vector4 vector = this.border * this.atlas.pixelSize;
		Vector2 a = new Vector2(this.mInnerUV.width * (float)mainTexture.width, this.mInnerUV.height * (float)mainTexture.height);
		a *= this.atlas.pixelSize;
		if (a.x < 1f)
		{
			a.x = 1f;
		}
		if (a.y < 1f)
		{
			a.y = 1f;
		}
		UISprite.mTempPos[0].x = drawingDimensions.x;
		UISprite.mTempPos[0].y = drawingDimensions.y;
		UISprite.mTempPos[3].x = drawingDimensions.z;
		UISprite.mTempPos[3].y = drawingDimensions.w;
		if (this.mFlip == UISprite.Flip.Horizontally || this.mFlip == UISprite.Flip.Both)
		{
			UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector.z;
			UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector.x;
			UISprite.mTempUVs[3].x = this.mOuterUV.xMin;
			UISprite.mTempUVs[2].x = this.mInnerUV.xMin;
			UISprite.mTempUVs[1].x = this.mInnerUV.xMax;
			UISprite.mTempUVs[0].x = this.mOuterUV.xMax;
		}
		else
		{
			UISprite.mTempPos[1].x = UISprite.mTempPos[0].x + vector.x;
			UISprite.mTempPos[2].x = UISprite.mTempPos[3].x - vector.z;
			UISprite.mTempUVs[0].x = this.mOuterUV.xMin;
			UISprite.mTempUVs[1].x = this.mInnerUV.xMin;
			UISprite.mTempUVs[2].x = this.mInnerUV.xMax;
			UISprite.mTempUVs[3].x = this.mOuterUV.xMax;
		}
		if (this.mFlip == UISprite.Flip.Vertically || this.mFlip == UISprite.Flip.Both)
		{
			UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector.w;
			UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector.y;
			UISprite.mTempUVs[3].y = this.mOuterUV.yMin;
			UISprite.mTempUVs[2].y = this.mInnerUV.yMin;
			UISprite.mTempUVs[1].y = this.mInnerUV.yMax;
			UISprite.mTempUVs[0].y = this.mOuterUV.yMax;
		}
		else
		{
			UISprite.mTempPos[1].y = UISprite.mTempPos[0].y + vector.y;
			UISprite.mTempPos[2].y = UISprite.mTempPos[3].y - vector.w;
			UISprite.mTempUVs[0].y = this.mOuterUV.yMin;
			UISprite.mTempUVs[1].y = this.mInnerUV.yMin;
			UISprite.mTempUVs[2].y = this.mInnerUV.yMax;
			UISprite.mTempUVs[3].y = this.mOuterUV.yMax;
		}
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 c = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		for (int i = 0; i < 3; i++)
		{
			int num = i + 1;
			for (int j = 0; j < 3; j++)
			{
				if (this.centerType != UISprite.AdvancedType.Invisible || i != 1 || j != 1)
				{
					int num2 = j + 1;
					if (i == 1 && j == 1)
					{
						if (this.centerType == UISprite.AdvancedType.Tiled)
						{
							float x = UISprite.mTempPos[i].x;
							float x2 = UISprite.mTempPos[num].x;
							float y = UISprite.mTempPos[j].y;
							float y2 = UISprite.mTempPos[num2].y;
							float x3 = UISprite.mTempUVs[i].x;
							float y3 = UISprite.mTempUVs[j].y;
							for (float num3 = y; num3 < y2; num3 += a.y)
							{
								float num4 = x;
								float num5 = UISprite.mTempUVs[num2].y;
								float num6 = num3 + a.y;
								if (num6 > y2)
								{
									num5 = Mathf.Lerp(y3, num5, (y2 - num3) / a.y);
									num6 = y2;
								}
								while (num4 < x2)
								{
									float num7 = num4 + a.x;
									float num8 = UISprite.mTempUVs[num].x;
									if (num7 > x2)
									{
										num8 = Mathf.Lerp(x3, num8, (x2 - num4) / a.x);
										num7 = x2;
									}
									this.FillBuffers(num4, num7, num3, num6, x3, num8, y3, num5, c, verts, uvs, cols);
									num4 += a.x;
								}
							}
						}
						else if (this.centerType == UISprite.AdvancedType.Sliced)
						{
							this.FillBuffers(UISprite.mTempPos[i].x, UISprite.mTempPos[num].x, UISprite.mTempPos[j].y, UISprite.mTempPos[num2].y, UISprite.mTempUVs[i].x, UISprite.mTempUVs[num].x, UISprite.mTempUVs[j].y, UISprite.mTempUVs[num2].y, c, verts, uvs, cols);
						}
					}
					else if (i == 1)
					{
						if ((j == 0 && this.bottomType == UISprite.AdvancedType.Tiled) || (j == 2 && this.topType == UISprite.AdvancedType.Tiled))
						{
							float x4 = UISprite.mTempPos[i].x;
							float x5 = UISprite.mTempPos[num].x;
							float y4 = UISprite.mTempPos[j].y;
							float y5 = UISprite.mTempPos[num2].y;
							float x6 = UISprite.mTempUVs[i].x;
							float y6 = UISprite.mTempUVs[j].y;
							float y7 = UISprite.mTempUVs[num2].y;
							for (float num9 = x4; num9 < x5; num9 += a.x)
							{
								float num10 = num9 + a.x;
								float num11 = UISprite.mTempUVs[num].x;
								if (num10 > x5)
								{
									num11 = Mathf.Lerp(x6, num11, (x5 - num9) / a.x);
									num10 = x5;
								}
								this.FillBuffers(num9, num10, y4, y5, x6, num11, y6, y7, c, verts, uvs, cols);
							}
						}
						else if ((j == 0 && this.bottomType == UISprite.AdvancedType.Sliced) || (j == 2 && this.topType == UISprite.AdvancedType.Sliced))
						{
							this.FillBuffers(UISprite.mTempPos[i].x, UISprite.mTempPos[num].x, UISprite.mTempPos[j].y, UISprite.mTempPos[num2].y, UISprite.mTempUVs[i].x, UISprite.mTempUVs[num].x, UISprite.mTempUVs[j].y, UISprite.mTempUVs[num2].y, c, verts, uvs, cols);
						}
					}
					else if (j == 1)
					{
						if ((i == 0 && this.leftType == UISprite.AdvancedType.Tiled) || (i == 2 && this.rightType == UISprite.AdvancedType.Tiled))
						{
							float x7 = UISprite.mTempPos[i].x;
							float x8 = UISprite.mTempPos[num].x;
							float y8 = UISprite.mTempPos[j].y;
							float y9 = UISprite.mTempPos[num2].y;
							float x9 = UISprite.mTempUVs[i].x;
							float x10 = UISprite.mTempUVs[num].x;
							float y10 = UISprite.mTempUVs[j].y;
							for (float num12 = y8; num12 < y9; num12 += a.y)
							{
								float num13 = UISprite.mTempUVs[num2].y;
								float num14 = num12 + a.y;
								if (num14 > y9)
								{
									num13 = Mathf.Lerp(y10, num13, (y9 - num12) / a.y);
									num14 = y9;
								}
								this.FillBuffers(x7, x8, num12, num14, x9, x10, y10, num13, c, verts, uvs, cols);
							}
						}
						else if ((i == 0 && this.leftType == UISprite.AdvancedType.Sliced) || (i == 2 && this.rightType == UISprite.AdvancedType.Sliced))
						{
							this.FillBuffers(UISprite.mTempPos[i].x, UISprite.mTempPos[num].x, UISprite.mTempPos[j].y, UISprite.mTempPos[num2].y, UISprite.mTempUVs[i].x, UISprite.mTempUVs[num].x, UISprite.mTempUVs[j].y, UISprite.mTempUVs[num2].y, c, verts, uvs, cols);
						}
					}
					else
					{
						this.FillBuffers(UISprite.mTempPos[i].x, UISprite.mTempPos[num].x, UISprite.mTempPos[j].y, UISprite.mTempPos[num2].y, UISprite.mTempUVs[i].x, UISprite.mTempUVs[num].x, UISprite.mTempUVs[j].y, UISprite.mTempUVs[num2].y, c, verts, uvs, cols);
					}
				}
			}
		}
	}

	private void FillBuffers(float v0x, float v1x, float v0y, float v1y, float u0x, float u1x, float u0y, float u1y, Color col, BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		verts.Add(new Vector3(v0x, v0y));
		verts.Add(new Vector3(v0x, v1y));
		verts.Add(new Vector3(v1x, v1y));
		verts.Add(new Vector3(v1x, v0y));
		uvs.Add(new Vector2(u0x, u0y));
		uvs.Add(new Vector2(u0x, u1y));
		uvs.Add(new Vector2(u1x, u1y));
		uvs.Add(new Vector2(u1x, u0y));
		cols.Add(col);
		cols.Add(col);
		cols.Add(col);
		cols.Add(col);
	}
}
