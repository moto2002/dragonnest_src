using AnimationOrTween;
using System;
using UILib;
using UnityEngine;

public class XUIPlayTween : MonoBehaviour, IXUITweenTool
{
	private bool m_bPlayForward;

	private UIPlayTween m_uiPlayTween;

	private GameObject m_objectToPlay;

	private OnTweenFinishEventHandler m_OnFinishHandler;

	private EventDelegate oneCycleFinish;

	private float m_repeatStartTime;

	private float m_repeatDuaration;

	public bool bPlayForward
	{
		get
		{
			return this.m_bPlayForward;
		}
	}

	public int TweenGroup
	{
		get
		{
			return this.m_uiPlayTween.tweenGroup;
		}
	}

	private void Awake()
	{
		this.m_uiPlayTween = base.GetComponent<UIPlayTween>();
		if (null == this.m_uiPlayTween)
		{
			Debug.LogError("null == m_uiPlayTween " + base.gameObject.name);
		}
		this.oneCycleFinish = new EventDelegate(new EventDelegate.Callback(this.OnOneCycleFinish));
	}

	public void PlayTween(bool bForward, float duaration = -1f)
	{
		this.m_uiPlayTween.Play(bForward);
		this.m_bPlayForward = bForward;
		if (duaration > 0f)
		{
			this.m_repeatStartTime = Time.time;
			this.m_repeatDuaration = duaration;
			EventDelegate.Add(this.m_uiPlayTween.onFinished, this.oneCycleFinish);
		}
	}

	public void ResetTween(bool bForward)
	{
		this.m_uiPlayTween.Reset(bForward);
	}

	public void ResetTweenByGroup(bool bForward, int resetGroup)
	{
		this.m_uiPlayTween.ResetByGroup(bForward, resetGroup);
	}

	public void ResetTweenByCurGroup(bool bForward)
	{
		this.m_uiPlayTween.ResetByGroup(bForward, this.m_uiPlayTween.tweenGroup);
	}

	public void ResetTweenExceptGroup(bool bForward, int exceptGroup)
	{
		this.m_uiPlayTween.ResetExceptGroup(bForward, exceptGroup);
	}

	public void StopTween()
	{
		this.m_uiPlayTween.Stop();
	}

	public void StopTweenByGroup(int resetGroup)
	{
		this.m_uiPlayTween.StopByGroup(resetGroup);
	}

	public void StopTweenExceptGroup(int exceptGroup)
	{
		this.m_uiPlayTween.StopExceptGroup(exceptGroup);
	}

	public void SetTargetGameObject(GameObject go)
	{
		this.m_uiPlayTween.tweenTarget = go;
	}

	public void SetPositionTweenPos(int group, Vector3 from, Vector3 to)
	{
		GameObject gameObject = (!(this.m_uiPlayTween.tweenTarget == null)) ? this.m_uiPlayTween.tweenTarget : base.gameObject;
		TweenPosition[] components = gameObject.GetComponents<TweenPosition>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].tweenGroup == group)
			{
				components[i].from = from;
				components[i].to = to;
			}
		}
	}

	public void SetTweenGroup(int group)
	{
		this.m_uiPlayTween.tweenGroup = group;
	}

	public void SetTweenEnabledWhenFinish(bool enabled)
	{
		if (enabled)
		{
			this.m_uiPlayTween.disableWhenFinished = DisableCondition.DoNotDisable;
		}
		else
		{
			this.m_uiPlayTween.disableWhenFinished = DisableCondition.DisableAfterForward;
		}
	}

	public void RegisterOnFinishEventHandler(OnTweenFinishEventHandler eventHandler)
	{
		this.m_OnFinishHandler = eventHandler;
		EventDelegate.Add(this.m_uiPlayTween.onFinished, new EventDelegate.Callback(this.OnFinish));
	}

	private void OnFinish()
	{
		if (this.m_OnFinishHandler != null)
		{
			this.m_OnFinishHandler(this);
		}
	}

	private void OnOneCycleFinish()
	{
		if (Time.time - this.m_repeatStartTime < this.m_repeatDuaration)
		{
			this.m_uiPlayTween.Play(this.m_bPlayForward);
		}
		else
		{
			EventDelegate.Remove(this.m_uiPlayTween.onFinished, this.oneCycleFinish);
		}
	}

	virtual GameObject get_gameObject()
	{
		return base.gameObject;
	}
}
