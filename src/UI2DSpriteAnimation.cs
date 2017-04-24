using System;
using UnityEngine;

public class UI2DSpriteAnimation : MonoBehaviour
{
	public int framerate = 20;

	public bool ignoreTimeScale = true;

	public Sprite[] frames;

	private SpriteRenderer mUnitySprite;

	private UI2DSprite mNguiSprite;

	private int mIndex;

	private float mUpdate;

	private void Start()
	{
		this.mUnitySprite = base.GetComponent<SpriteRenderer>();
		this.mNguiSprite = base.GetComponent<UI2DSprite>();
		if (this.framerate > 0)
		{
			this.mUpdate = ((!this.ignoreTimeScale) ? Time.time : RealTime.time) + 1f / (float)this.framerate;
		}
	}

	private void Update()
	{
		if (this.framerate != 0 && this.frames != null && this.frames.Length > 0)
		{
			float num = (!this.ignoreTimeScale) ? Time.time : RealTime.time;
			if (this.mUpdate < num)
			{
				this.mUpdate = num;
				this.mIndex = NGUIMath.RepeatIndex((this.framerate <= 0) ? (this.mIndex - 1) : (this.mIndex + 1), this.frames.Length);
				this.mUpdate = num + Mathf.Abs(1f / (float)this.framerate);
				if (this.mUnitySprite != null)
				{
					this.mUnitySprite.sprite = this.frames[this.mIndex];
				}
				else if (this.mNguiSprite != null)
				{
					this.mNguiSprite.nextSprite = this.frames[this.mIndex];
				}
			}
		}
	}
}
