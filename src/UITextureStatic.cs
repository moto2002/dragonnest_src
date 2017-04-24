using System;
using UnityEngine;

[AddComponentMenu("NGUI/UI/NGUI Texture Static"), ExecuteInEditMode]
public class UITextureStatic : UITexture
{
	protected override void InitAlphaTexture(bool init)
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
		base.ResetShader();
	}
}
