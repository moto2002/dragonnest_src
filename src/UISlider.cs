using System;
using UILib;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/NGUI Slider"), ExecuteInEditMode]
public class UISlider : UIProgressBar
{
	private enum Direction
	{
		Horizontal,
		Vertical,
		Upgraded
	}

	[HideInInspector, SerializeField]
	private Transform foreground;

	[HideInInspector, SerializeField]
	private float rawValue = 1f;

	[HideInInspector, SerializeField]
	private UISlider.Direction direction = UISlider.Direction.Upgraded;

	[HideInInspector, SerializeField]
	protected bool mInverted;

	public SliderValueChangeEventHandler eventHandler;

	[Obsolete("Use 'value' instead")]
	public float sliderValue
	{
		get
		{
			return base.value;
		}
		set
		{
			base.value = value;
		}
	}

	[Obsolete("Use 'fillDirection' instead")]
	public bool inverted
	{
		get
		{
			return base.isInverted;
		}
		set
		{
		}
	}

	protected override void Upgrade()
	{
		if (this.direction != UISlider.Direction.Upgraded)
		{
			this.mValue = this.rawValue;
			if (this.foreground != null)
			{
				this.mFG = this.foreground.GetComponent<UIWidget>();
			}
			if (this.direction == UISlider.Direction.Horizontal)
			{
				this.mFill = ((!this.mInverted) ? UIProgressBar.FillDirection.LeftToRight : UIProgressBar.FillDirection.RightToLeft);
			}
			else
			{
				this.mFill = ((!this.mInverted) ? UIProgressBar.FillDirection.BottomToTop : UIProgressBar.FillDirection.TopToBottom);
			}
			this.direction = UISlider.Direction.Upgraded;
		}
	}

	protected override void OnStart()
	{
		GameObject go = (!(this.mBG != null) || !(this.mBG.collider != null)) ? base.gameObject : this.mBG.gameObject;
		UIEventListener uIEventListener = UIEventListener.Get(go);
		UIEventListener expr_46 = uIEventListener;
		expr_46.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(expr_46.onPress, new UIEventListener.BoolDelegate(this.OnPressBackground));
		UIEventListener expr_68 = uIEventListener;
		expr_68.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(expr_68.onDrag, new UIEventListener.VectorDelegate(this.OnDragBackground));
		if (this.thumb != null && this.thumb.collider != null && (this.mFG == null || this.thumb != this.mFG.cachedTransform))
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(this.thumb.gameObject);
			UIEventListener expr_EE = uIEventListener2;
			expr_EE.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(expr_EE.onPress, new UIEventListener.BoolDelegate(this.OnPressForeground));
			UIEventListener expr_110 = uIEventListener2;
			expr_110.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(expr_110.onDrag, new UIEventListener.VectorDelegate(this.OnDragForeground));
		}
	}

	protected void OnPressBackground(GameObject go, bool isPressed)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = base.ScreenToValue(UICamera.lastTouchPosition);
		if (!isPressed && this.onDragFinished != null)
		{
			this.onDragFinished();
		}
	}

	protected void OnDragBackground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = base.ScreenToValue(UICamera.lastTouchPosition);
	}

	protected void OnPressForeground(GameObject go, bool isPressed)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		if (isPressed)
		{
			this.mOffset = ((!(this.mFG == null)) ? (base.value - base.ScreenToValue(UICamera.lastTouchPosition)) : 0f);
		}
		else if (this.onDragFinished != null)
		{
			this.onDragFinished();
		}
	}

	protected void OnDragForeground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = this.mOffset + base.ScreenToValue(UICamera.lastTouchPosition);
		if (this.eventHandler != null)
		{
			this.eventHandler(base.value);
		}
	}

	protected void OnKey(KeyCode key)
	{
		if (base.enabled)
		{
			float num = ((float)this.numberOfSteps <= 1f) ? 0.125f : (1f / (float)(this.numberOfSteps - 1));
			if (base.fillDirection == UIProgressBar.FillDirection.LeftToRight || base.fillDirection == UIProgressBar.FillDirection.RightToLeft)
			{
				if (key == KeyCode.LeftArrow)
				{
					base.value = this.mValue - num;
				}
				else if (key == KeyCode.RightArrow)
				{
					base.value = this.mValue + num;
				}
			}
			else if (key == KeyCode.DownArrow)
			{
				base.value = this.mValue - num;
			}
			else if (key == KeyCode.UpArrow)
			{
				base.value = this.mValue + num;
			}
		}
	}
}
