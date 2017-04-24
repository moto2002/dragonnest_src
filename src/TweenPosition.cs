using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
	public Vector3 from;

	public Vector3 to;

	public bool nox;

	public bool noy;

	[HideInInspector]
	public bool worldSpace;

	private Transform mTrans;

	private UIRect mRect;

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

	[Obsolete("Use 'value' instead")]
	public Vector3 position
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	public Vector3 value
	{
		get
		{
			return (!this.worldSpace) ? this.cachedTransform.localPosition : this.cachedTransform.position;
		}
		set
		{
			if (this.mRect == null || !this.mRect.isAnchored || this.worldSpace)
			{
				if (this.worldSpace)
				{
					Vector3 position = this.cachedTransform.position;
					this.cachedTransform.position.Set((!this.nox) ? value.x : position.x, (!this.noy) ? value.y : position.y, value.z);
				}
				else
				{
					Vector3 localPosition = this.cachedTransform.localPosition;
					float x = (!this.nox) ? value.x : localPosition.x;
					float y = (!this.noy) ? value.y : localPosition.y;
					this.cachedTransform.localPosition = new Vector3(x, y, value.z);
				}
			}
			else
			{
				value -= this.cachedTransform.localPosition;
				value.Set((!this.nox) ? value.x : 0f, (!this.noy) ? value.y : 0f, value.z);
				NGUIMath.MoveRect(this.mRect, value.x, value.y);
			}
		}
	}

	private void Awake()
	{
		this.mRect = base.GetComponent<UIRect>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
		tweenPosition.from = tweenPosition.value;
		tweenPosition.to = pos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}
}
