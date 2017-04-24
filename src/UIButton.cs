using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
	public static UIButton current;

	public bool dragHighlight;

	public string hoverSprite;

	public string pressedSprite;

	public string disabledSprite;

	public bool pixelSnap;

	public List<EventDelegate> onClick = new List<EventDelegate>();

	[NonSerialized]
	private string mNormalSprite;

	[NonSerialized]
	private UISprite mSprite;

	public Collider cacheCol;

	public Collider2D cacheC2d;

	public override bool isEnabled
	{
		get
		{
			return base.enabled && ((this.cacheCol && this.cacheCol.enabled) || (this.cacheC2d && this.cacheC2d.enabled));
		}
		set
		{
			if (this.isEnabled != value)
			{
				Collider collider = base.collider;
				if (collider != null)
				{
					collider.enabled = value;
				}
				else if (this.cacheC2d != null)
				{
					this.cacheC2d.enabled = value;
					this.SetState((!value) ? UIButtonColor.State.Disabled : UIButtonColor.State.Normal, false);
				}
				else
				{
					base.enabled = value;
				}
			}
		}
	}

	public string normalSprite
	{
		get
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			return this.mNormalSprite;
		}
		set
		{
			if (this.mSprite != null && !string.IsNullOrEmpty(this.mNormalSprite) && this.mNormalSprite == this.mSprite.spriteName)
			{
				this.mNormalSprite = value;
				this.SetSprite(value);
			}
			else
			{
				this.mNormalSprite = value;
				if (this.mState == UIButtonColor.State.Normal)
				{
					this.SetSprite(value);
				}
			}
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		this.mSprite = (this.mWidget as UISprite);
		if (this.mSprite != null)
		{
			this.mNormalSprite = this.mSprite.spriteName;
		}
		if (this.cacheCol == null)
		{
			this.cacheCol = base.collider;
		}
		if (this.cacheC2d == null)
		{
			this.cacheC2d = base.GetComponent<Collider2D>();
		}
	}

	protected override void OnEnable()
	{
		if (this.isEnabled)
		{
			if (this.mInitDone)
			{
				this.mSprite = (this.mWidget as UISprite);
				if (this.mSprite != null)
				{
					this.mNormalSprite = this.mSprite.spriteName;
				}
				this.SetState(UIButtonColor.State.Normal, false);
			}
		}
		else
		{
			this.SetState(UIButtonColor.State.Disabled, true);
		}
	}

	protected override void OnDragOver()
	{
		if (this.isEnabled && (this.dragHighlight || UICamera.currentTouch.pressed == base.gameObject))
		{
			base.OnDragOver();
		}
	}

	protected override void OnDragOut()
	{
		if (this.isEnabled && (this.dragHighlight || UICamera.currentTouch.pressed == base.gameObject))
		{
			base.OnDragOut();
		}
	}

	protected virtual void OnClick()
	{
		if (UIButton.current == null && this.isEnabled)
		{
			UIButton.current = this;
			EventDelegate.Execute(this.onClick);
			UIButton.current = null;
		}
	}

	public override void SetState(UIButtonColor.State state, bool immediate)
	{
		base.SetState(state, immediate);
		switch (state)
		{
		case UIButtonColor.State.Normal:
			this.SetSprite(this.mNormalSprite);
			break;
		case UIButtonColor.State.Hover:
			if (this.changeStateSprite)
			{
				this.SetSprite(this.hoverSprite);
			}
			break;
		case UIButtonColor.State.Pressed:
			if (this.changeStateSprite)
			{
				this.SetSprite(this.pressedSprite);
			}
			break;
		case UIButtonColor.State.Disabled:
			this.SetSprite(this.disabledSprite);
			break;
		}
	}

	protected void SetSprite(string sp)
	{
		if (this.mSprite != null && !string.IsNullOrEmpty(sp) && this.mSprite.spriteName != sp)
		{
			this.mSprite.spriteName = sp;
			if (this.pixelSnap)
			{
				this.mSprite.MakePixelPerfect();
			}
		}
	}
}
