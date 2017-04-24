using System;
using UnityEngine;

[AddComponentMenu("NGUI/UI/NGUI Unity2D Sprite"), ExecuteInEditMode]
public class UI2DSprite : UIWidget
{
	[HideInInspector, SerializeField]
	private Sprite mSprite;

	[HideInInspector, SerializeField]
	private Material mMat;

	[HideInInspector, SerializeField]
	private Shader mShader;

	public Sprite nextSprite;

	private int mPMA = -1;

	public Sprite sprite2D
	{
		get
		{
			return this.mSprite;
		}
		set
		{
			if (this.mSprite != value)
			{
				base.RemoveFromPanel();
				this.mSprite = value;
				this.nextSprite = null;
				this.MarkAsChanged();
			}
		}
	}

	public override Material material
	{
		get
		{
			return this.mMat;
		}
		set
		{
			if (this.mMat != value)
			{
				base.RemoveFromPanel();
				this.mMat = value;
				this.mPMA = -1;
				this.MarkAsChanged();
			}
		}
	}

	public override Shader shader
	{
		get
		{
			if (this.mMat != null)
			{
				return this.mMat.shader;
			}
			if (this.mShader == null)
			{
				this.mShader = Shader.Find("Unlit/Transparent Colored");
			}
			return this.mShader;
		}
		set
		{
			if (this.mShader != value)
			{
				base.RemoveFromPanel();
				this.mShader = value;
				if (this.mMat == null)
				{
					this.mPMA = -1;
					this.MarkAsChanged();
				}
			}
		}
	}

	public override Texture mainTexture
	{
		get
		{
			if (this.mSprite != null)
			{
				return this.mSprite.texture;
			}
			if (this.mMat != null)
			{
				return this.mMat.mainTexture;
			}
			return null;
		}
	}

	public bool premultipliedAlpha
	{
		get
		{
			if (this.mPMA == -1)
			{
				Shader shader = this.shader;
				this.mPMA = ((!(shader != null) || !shader.name.Contains("Premultiplied")) ? 0 : 1);
			}
			return this.mPMA == 1;
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
			int num5 = (!(this.mSprite != null)) ? this.mWidth : Mathf.RoundToInt(this.mSprite.textureRect.width);
			int num6 = (!(this.mSprite != null)) ? this.mHeight : Mathf.RoundToInt(this.mSprite.textureRect.height);
			if ((num5 & 1) != 0)
			{
				num3 -= 1f / (float)num5 * (float)this.mWidth;
			}
			if ((num6 & 1) != 0)
			{
				num4 -= 1f / (float)num6 * (float)this.mHeight;
			}
			return new Vector4((this.mDrawRegion.x != 0f) ? Mathf.Lerp(num, num3, this.mDrawRegion.x) : num, (this.mDrawRegion.y != 0f) ? Mathf.Lerp(num2, num4, this.mDrawRegion.y) : num2, (this.mDrawRegion.z != 1f) ? Mathf.Lerp(num, num3, this.mDrawRegion.z) : num3, (this.mDrawRegion.w != 1f) ? Mathf.Lerp(num2, num4, this.mDrawRegion.w) : num4);
		}
	}

	public Rect uvRect
	{
		get
		{
			Texture mainTexture = this.mainTexture;
			if (mainTexture != null)
			{
				Rect textureRect = this.mSprite.textureRect;
				textureRect.xMin /= (float)mainTexture.width;
				textureRect.xMax /= (float)mainTexture.width;
				textureRect.yMin /= (float)mainTexture.height;
				textureRect.yMax /= (float)mainTexture.height;
				return textureRect;
			}
			return new Rect(0f, 0f, 1f, 1f);
		}
	}

	protected override void OnUpdate()
	{
		if (this.nextSprite != null)
		{
			if (this.nextSprite != this.mSprite)
			{
				this.sprite2D = this.nextSprite;
			}
			this.nextSprite = null;
		}
		base.OnUpdate();
	}

	public override void MakePixelPerfect()
	{
		if (this.mSprite != null)
		{
			Rect textureRect = this.mSprite.textureRect;
			int num = Mathf.RoundToInt(textureRect.width);
			int num2 = Mathf.RoundToInt(textureRect.height);
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
		base.MakePixelPerfect();
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 item = (!this.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		Vector4 drawingDimensions = this.drawingDimensions;
		Rect uvRect = this.uvRect;
		verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.y));
		verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.w));
		verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.w));
		verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.y));
		uvs.Add(new Vector2(uvRect.xMin, uvRect.yMin));
		uvs.Add(new Vector2(uvRect.xMin, uvRect.yMax));
		uvs.Add(new Vector2(uvRect.xMax, uvRect.yMax));
		uvs.Add(new Vector2(uvRect.xMax, uvRect.yMin));
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
	}
}
