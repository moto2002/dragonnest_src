using AnimationOrTween;
using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Play Tween"), ExecuteInEditMode]
public class UIPlayTween : MonoBehaviour
{
	public static UIPlayTween current;

	public GameObject tweenTarget;

	public int tweenGroup;

	public Trigger trigger;

	public Direction playDirection = Direction.Forward;

	public bool resetOnPlay;

	public bool resetIfDisabled;

	public EnableCondition ifDisabledOnPlay;

	public DisableCondition disableWhenFinished;

	public bool includeChildren;

	public List<EventDelegate> onFinished = new List<EventDelegate>();

	[HideInInspector, SerializeField]
	private GameObject eventReceiver;

	[HideInInspector, SerializeField]
	private string callWhenFinished;

	private List<UITweener> mTweens = new List<UITweener>();

	private bool mStarted;

	private int mActive;

	private bool mActivated;

	[NonSerialized]
	public EventDelegate finishCb;

	[NonSerialized]
	public EventDelegate finishEndCB;

	[NonSerialized]
	private UIToggle toggle;

	[NonSerialized]
	private EventDelegate.Callback onToggle;

	[NonSerialized]
	private EventDelegate.Callback onFinish;

	private void Awake()
	{
		if (this.eventReceiver != null && EventDelegate.IsValid(this.onFinished))
		{
			this.eventReceiver = null;
			this.callWhenFinished = null;
		}
		this.finishCb = new EventDelegate(new EventDelegate.Callback(this.OnFinished));
		this.finishEndCB = new EventDelegate(new EventDelegate.Callback(this.OnFinished));
		this.toggle = base.GetComponent<UIToggle>();
		if (this.toggle != null)
		{
			this.onToggle = new EventDelegate.Callback(this.OnToggle);
		}
	}

	private void Start()
	{
		this.mStarted = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
	}

	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
		if (UICamera.currentTouch != null)
		{
			if (this.trigger == Trigger.OnPress || this.trigger == Trigger.OnPressTrue)
			{
				this.mActivated = (UICamera.currentTouch.pressed == base.gameObject);
			}
			if (this.trigger == Trigger.OnHover || this.trigger == Trigger.OnHoverTrue)
			{
				this.mActivated = (UICamera.currentTouch.current == base.gameObject);
			}
		}
		if (this.toggle != null)
		{
			EventDelegate.Add(this.toggle.onChange, this.onToggle);
		}
	}

	private void OnDisable()
	{
		if (this.toggle != null)
		{
			EventDelegate.Remove(this.toggle.onChange, this.onToggle);
		}
	}

	private void OnHover(bool isOver)
	{
		if (base.enabled && (this.trigger == Trigger.OnHover || (this.trigger == Trigger.OnHoverTrue && isOver) || (this.trigger == Trigger.OnHoverFalse && !isOver)))
		{
			this.mActivated = (isOver && this.trigger == Trigger.OnHover);
			this.Play(isOver);
		}
	}

	private void OnDragOut()
	{
		if (base.enabled && this.mActivated)
		{
			this.mActivated = false;
			this.Play(false);
		}
	}

	private void OnPress(bool isPressed)
	{
		if (base.enabled && (this.trigger == Trigger.OnPress || (this.trigger == Trigger.OnPressTrue && isPressed) || (this.trigger == Trigger.OnPressFalse && !isPressed)))
		{
			this.mActivated = (isPressed && this.trigger == Trigger.OnPress);
			this.Play(isPressed);
		}
	}

	private void OnClick()
	{
		if (base.enabled && this.trigger == Trigger.OnClick)
		{
			this.Play(true);
		}
	}

	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == Trigger.OnDoubleClick)
		{
			this.Play(true);
		}
	}

	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (this.trigger == Trigger.OnSelect || (this.trigger == Trigger.OnSelectTrue && isSelected) || (this.trigger == Trigger.OnSelectFalse && !isSelected)))
		{
			this.mActivated = (isSelected && this.trigger == Trigger.OnSelect);
			this.Play(isSelected);
		}
	}

	private void OnToggle()
	{
		if (!base.enabled || UIToggle.current == null)
		{
			return;
		}
		if (this.trigger == Trigger.OnActivate || (this.trigger == Trigger.OnActivateTrue && UIToggle.current.value) || (this.trigger == Trigger.OnActivateFalse && !UIToggle.current.value))
		{
			this.Play(UIToggle.current.value);
		}
	}

	private void Update()
	{
		if (NGUITools.mEnableLoadingUpdate && this.disableWhenFinished != DisableCondition.DoNotDisable && this.mTweens.Count > 0)
		{
			bool flag = true;
			bool flag2 = true;
			int count = this.mTweens.Count;
			int i = 0;
			int num = count;
			while (i < num)
			{
				UITweener uITweener = this.mTweens[i];
				if (uITweener.tweenGroup == this.tweenGroup)
				{
					if (uITweener.enabled)
					{
						flag = false;
						break;
					}
					if (uITweener.direction != (Direction)this.disableWhenFinished)
					{
						flag2 = false;
					}
				}
				i++;
			}
			if (flag)
			{
				if (flag2)
				{
					NGUITools.SetActive(this.tweenTarget, false);
				}
				this.mTweens.Clear();
			}
		}
	}

	public void Play(bool forward)
	{
		this.mActive = 0;
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		if (!NGUITools.GetActive(gameObject))
		{
			if (this.ifDisabledOnPlay != EnableCondition.EnableThenPlay)
			{
				return;
			}
			NGUITools.SetActive(gameObject, true, true, false);
		}
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		if (count == 0)
		{
			if (this.disableWhenFinished != DisableCondition.DoNotDisable)
			{
				NGUITools.SetActive(this.tweenTarget, false);
			}
		}
		else
		{
			bool flag = false;
			if (this.playDirection == Direction.Reverse)
			{
				forward = !forward;
			}
			int i = 0;
			int num = count;
			while (i < num)
			{
				if (this.mTweens == null)
				{
					break;
				}
				if (i >= count)
				{
					break;
				}
				UITweener uITweener = this.mTweens[i];
				if (uITweener.tweenGroup == this.tweenGroup)
				{
					if (!flag && !NGUITools.GetActive(gameObject))
					{
						flag = true;
						NGUITools.SetActive(gameObject, true, true, false);
					}
					this.mActive++;
					if (this.playDirection == Direction.Toggle)
					{
						EventDelegate.Add(uITweener.onFinished, this.finishCb, true);
						EventDelegate.Add(uITweener.onFinished, this.finishEndCB, true);
						uITweener.Toggle();
					}
					else
					{
						if (this.resetOnPlay || (this.resetIfDisabled && !uITweener.enabled))
						{
							uITweener.ResetToBeginning(forward);
						}
						EventDelegate.Add(uITweener.onFinished, this.finishCb, true);
						EventDelegate.Add(uITweener.onFinished, this.finishEndCB, true);
						uITweener.Play(forward);
					}
				}
				i++;
			}
		}
	}

	private void OnFinished()
	{
		if (--this.mActive == 0 && UIPlayTween.current == null)
		{
			UIPlayTween.current = this;
			EventDelegate.Execute(this.onFinished);
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				this.eventReceiver.SendMessage(this.callWhenFinished, SendMessageOptions.DontRequireReceiver);
			}
			this.eventReceiver = null;
			UIPlayTween.current = null;
		}
	}

	public void Reset(bool forward)
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		int i = 0;
		int num = count;
		while (i < num)
		{
			this.mTweens[i].enabled = false;
			this.mTweens[i].ResetToBeginning(forward);
			i++;
		}
	}

	public void ResetByGroup(bool forward, int resetGroup)
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		int i = 0;
		int num = count;
		while (i < num)
		{
			if (this.mTweens[i].tweenGroup == resetGroup)
			{
				this.mTweens[i].enabled = false;
				this.mTweens[i].ResetToBeginning(forward);
			}
			i++;
		}
	}

	public void ResetExceptGroup(bool forward, int exceptGroup)
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		int i = 0;
		int num = count;
		while (i < num)
		{
			if (this.mTweens[i].tweenGroup != exceptGroup)
			{
				this.mTweens[i].enabled = false;
				this.mTweens[i].ResetToBeginning(forward);
			}
			i++;
		}
	}

	public void Stop()
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		int i = 0;
		int num = count;
		while (i < num)
		{
			this.mTweens[i].enabled = false;
			i++;
		}
	}

	public void StopByGroup(int resetGroup)
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		int i = 0;
		int num = count;
		while (i < num)
		{
			if (this.mTweens[i].tweenGroup == resetGroup)
			{
				this.mTweens[i].enabled = false;
			}
			i++;
		}
	}

	public void StopExceptGroup(int exceptGroup)
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		this.mTweens.Clear();
		if (this.includeChildren)
		{
			gameObject.GetComponentsInChildren<UITweener>(this.mTweens);
		}
		else
		{
			gameObject.GetComponents<UITweener>(this.mTweens);
		}
		int count = this.mTweens.Count;
		int i = 0;
		int num = count;
		while (i < num)
		{
			if (this.mTweens[i].tweenGroup != exceptGroup)
			{
				this.mTweens[i].enabled = false;
			}
			i++;
		}
	}
}
