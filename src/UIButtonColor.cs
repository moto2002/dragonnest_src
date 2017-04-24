using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Color"), ExecuteInEditMode]
public class UIButtonColor : UIWidgetContainer
{
	public enum State
	{
		Normal,
		Hover,
		Pressed,
		Disabled
	}

	public GameObject tweenTarget;

	public Color hover = new Color(0.882352948f, 0.784313738f, 0.5882353f, 1f);

	public Color pressed = new Color(0.7176471f, 0.6392157f, 0.482352942f, 1f);

	public Color disabledColor = Color.grey;

	public bool changeStateSprite;

	public float duration = 0.2f;

	protected Color mColor;

	protected bool mInitDone;

	protected UIWidget mWidget;

	protected UIButtonColor.State mState;

	[NonSerialized]
	private TweenColor tc;

	public UIButtonColor.State state
	{
		get
		{
			return this.mState;
		}
		set
		{
			this.SetState(value, false);
		}
	}

	public Color defaultColor
	{
		get
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			return this.mColor;
		}
		set
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			this.mColor = value;
		}
	}

	public virtual bool isEnabled
	{
		get
		{
			return base.enabled;
		}
		set
		{
			base.enabled = value;
		}
	}

	private void Awake()
	{
		if (!this.mInitDone)
		{
			this.OnInit();
		}
	}

	private void Start()
	{
	}

	protected virtual void OnInit()
	{
		this.mInitDone = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
		this.mWidget = this.tweenTarget.GetComponent<UIWidget>();
		this.tc = this.tweenTarget.GetComponent<TweenColor>();
		if (this.mWidget != null)
		{
			this.mColor = this.mWidget.color;
		}
		else
		{
			Renderer renderer = this.tweenTarget.renderer;
			if (renderer != null)
			{
				this.mColor = ((!Application.isPlaying) ? renderer.sharedMaterial.color : renderer.material.color);
			}
			else
			{
				Light light = this.tweenTarget.light;
				if (light != null)
				{
					this.mColor = light.color;
				}
				else
				{
					this.tweenTarget = null;
					this.mInitDone = false;
				}
			}
		}
	}

	protected virtual void OnEnable()
	{
		if (UICamera.currentTouch != null && UICamera.currentTouch.pressed == base.gameObject)
		{
			this.OnPress(true);
		}
	}

	protected virtual void OnDisable()
	{
		if (this.mInitDone && this.tweenTarget != null)
		{
			this.SetState(UIButtonColor.State.Normal, true);
			if (this.tc != null)
			{
				this.tc.value = this.mColor;
				this.tc.enabled = false;
			}
		}
	}

	protected virtual void OnHover(bool isOver)
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				this.SetState((!isOver) ? UIButtonColor.State.Normal : UIButtonColor.State.Hover, false);
			}
		}
	}

	protected virtual void OnPress(bool isPressed)
	{
		if (this.isEnabled && UICamera.currentTouch != null)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				if (isPressed)
				{
					this.SetState(UIButtonColor.State.Pressed, false);
				}
				else if (UICamera.currentTouch.current == base.gameObject)
				{
					if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
					{
						this.SetState(UIButtonColor.State.Hover, false);
					}
					else if (UICamera.currentScheme == UICamera.ControlScheme.Mouse && UICamera.hoveredObject == base.gameObject)
					{
						this.SetState(UIButtonColor.State.Hover, false);
					}
					else
					{
						this.SetState(UIButtonColor.State.Normal, false);
					}
				}
				else
				{
					this.SetState(UIButtonColor.State.Normal, false);
				}
			}
		}
	}

	protected virtual void OnDragOver()
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				this.SetState(UIButtonColor.State.Pressed, false);
			}
		}
	}

	protected virtual void OnDragOut()
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				this.SetState(UIButtonColor.State.Normal, false);
			}
		}
	}

	protected virtual void OnSelect(bool isSelected)
	{
		if (this.isEnabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller) && this.tweenTarget != null)
		{
			this.OnHover(isSelected);
		}
	}

	public virtual void SetState(UIButtonColor.State state, bool instant)
	{
		if (!this.mInitDone)
		{
			this.mInitDone = true;
			this.OnInit();
		}
		if (this.mState != state)
		{
			this.mState = state;
			if (this.changeStateSprite)
			{
				TweenColor tweenColor;
				switch (this.mState)
				{
				case UIButtonColor.State.Hover:
					tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.hover);
					break;
				case UIButtonColor.State.Pressed:
					tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.pressed);
					break;
				case UIButtonColor.State.Disabled:
					tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.disabledColor);
					break;
				default:
					tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.mColor);
					break;
				}
				if (instant && tweenColor != null)
				{
					tweenColor.value = tweenColor.to;
					tweenColor.enabled = false;
				}
			}
		}
	}
}
