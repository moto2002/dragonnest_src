using System;
using UnityEngine;
using XUtliPoolLib;

[AddComponentMenu("NGUI/UI/NGUI Texture"), ExecuteInEditMode]
public class UITexture : UIWidget
{
	public enum Flip
	{
		Nothing,
		Horizontally,
		Vertically,
		Both
	}

	[HideInInspector, SerializeField]
	protected Rect mRect = new Rect(0f, 0f, 1f, 1f);

	[HideInInspector, SerializeField]
	protected Texture mTexture;

	[HideInInspector, SerializeField]
	protected Material mMat;

	[HideInInspector, SerializeField]
	protected Shader mShader;

	[HideInInspector, SerializeField]
	protected UITexture.Flip mFlip;

	[HideInInspector, SerializeField]
	protected Texture mAlphaTexture;

	private int mPMA = -1;

	protected bool hasLoadAlpha;

	private static Shader sepTexAlpha;

	private static Shader tranTex;

	private static Shader colorTex;

	public override Texture mainTexture
	{
		get
		{
			return this.mTexture;
		}
		set
		{
			if (this.mTexture != value)
			{
				base.RemoveFromPanel();
				this.mTexture = value;
				this.hasLoadAlpha = false;
				this.InitAlphaTexture(false);
				this.MarkAsChanged();
			}
		}
	}

	public override Texture alphaTexture
	{
		get
		{
			return this.mAlphaTexture;
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
				this.mShader = null;
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
			if (this.mShader == null || this.mShader == UITexture.tranTex)
			{
				this.mShader = UITexture.sepTexAlpha;
			}
			return this.mShader;
		}
		set
		{
			if (this.mShader != value)
			{
				base.RemoveFromPanel();
				this.mShader = value;
				this.mPMA = -1;
				this.mMat = null;
				this.MarkAsChanged();
			}
		}
	}

	public UITexture.Flip flip
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

	public bool premultipliedAlpha
	{
		get
		{
			if (this.mPMA == -1)
			{
				Material material = this.material;
				this.mPMA = ((!(material != null) || !(material.shader != null) || !material.shader.name.Contains("Premultiplied")) ? 0 : 1);
			}
			return this.mPMA == 1;
		}
	}

	public Rect uvRect
	{
		get
		{
			return this.mRect;
		}
		set
		{
			if (this.mRect != value)
			{
				this.mRect = value;
				this.MarkAsChanged();
			}
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
			Texture mainTexture = this.mainTexture;
			int num5 = (!(mainTexture != null)) ? this.mWidth : mainTexture.width;
			int num6 = (!(mainTexture != null)) ? this.mHeight : mainTexture.height;
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

	private static Shader GetSepTexAlpha()
	{
		if (UITexture.sepTexAlpha == null)
		{
			UITexture.sepTexAlpha = Shader.Find("Unlit/Seperate Alpha Texture");
		}
		return UITexture.sepTexAlpha;
	}

	private static Shader GetTranTex()
	{
		if (UITexture.tranTex == null)
		{
			UITexture.tranTex = Shader.Find("Unlit/Transparent Colored");
		}
		return UITexture.tranTex;
	}

	protected static Shader GetColorTex()
	{
		if (UITexture.colorTex == null)
		{
			UITexture.colorTex = Shader.Find("Unlit/Color Texture");
		}
		return UITexture.colorTex;
	}

	public void RestAlpha()
	{
		this.hasLoadAlpha = false;
		this.InitAlphaTexture(false);
	}

	protected void ResetShader()
	{
		if (this.mTexture == null)
		{
			this.mShader = null;
			return;
		}
		if (this.mAlphaTexture == null)
		{
			this.mShader = UITexture.GetColorTex();
		}
		else
		{
			this.mShader = UITexture.GetSepTexAlpha();
		}
	}

	protected virtual void InitAlphaTexture(bool init)
	{
		if (this.hasLoadAlpha)
		{
			return;
		}
		this.hasLoadAlpha = true;
		if (this.mTexture == null)
		{
			this.mAlphaTexture = null;
			if (this.mMat != null)
			{
				this.mMat.SetTexture("_MainTex", null);
			}
		}
		else
		{
			this.mAlphaTexture = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture>("atlas/UI/Alpha/" + this.mTexture.name + "_A", ".png", false);
		}
		this.ResetShader();
	}

	protected override void OnStart()
	{
		base.OnStart();
		UITexture.GetSepTexAlpha();
		UITexture.GetTranTex();
		UITexture.GetColorTex();
		this.InitAlphaTexture(true);
	}

	protected override void OnDestroy()
	{
		if (this.mMat != null)
		{
			this.mMat.SetTexture("_MainTex", null);
		}
		if (this.mAlphaTexture != null)
		{
			XSingleton<XResourceLoaderMgr>.singleton.DestroyShareResource("atlas/UI/Alpha/" + this.mAlphaTexture.name, this.mAlphaTexture);
		}
		this.mTexture = null;
		this.mAlphaTexture = null;
		base.OnDestroy();
	}

	public override void MakePixelPerfect()
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture != null)
		{
			int num = mainTexture.width;
			if ((num & 1) == 1)
			{
				num++;
			}
			int num2 = mainTexture.height;
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
		if (this.mTexture == null)
		{
			return;
		}
		Color color = base.color;
		color.a = this.finalAlpha;
		Color32 item = (!this.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		Vector4 drawingDimensions = this.drawingDimensions;
		verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.y));
		verts.Add(new Vector3(drawingDimensions.x, drawingDimensions.w));
		verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.w));
		verts.Add(new Vector3(drawingDimensions.z, drawingDimensions.y));
		if (this.mFlip == UITexture.Flip.Horizontally)
		{
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMin));
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMin));
		}
		else if (this.mFlip == UITexture.Flip.Vertically)
		{
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMin));
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMin));
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMax));
		}
		else if (this.mFlip == UITexture.Flip.Both)
		{
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMin));
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMin));
		}
		else
		{
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMin));
			uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMax));
			uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMin));
		}
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
	}
}
