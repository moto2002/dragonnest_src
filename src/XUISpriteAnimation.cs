using System;
using UILib;
using UnityEngine;

public class XUISpriteAnimation : XUIObject, IXUIObject, IXUISpriteAnimation
{
	private UISpriteAnimation m_Animation;

	private SpriteAnimationFinishCallback m_FinishCallback;

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_Animation = base.GetComponent<UISpriteAnimation>();
		if (this.m_Animation == null)
		{
			Debug.Log("no UISpriteAnimation component");
		}
	}

	public void SetNamePrefix(string name)
	{
		this.m_Animation.namePrefix = name;
		this.m_Animation.Reset();
	}

	public void SetFrameRate(int rate)
	{
		this.m_Animation.framesPerSecond = rate;
	}

	public void Reset()
	{
		this.m_Animation.Reset();
		this.m_Animation.LastLoopFinishTime = RealTime.time;
	}

	public void StopAndReset()
	{
		this.m_Animation.StopAndReset();
	}

	public void RegisterFinishCallback(SpriteAnimationFinishCallback callback)
	{
		if (callback != null)
		{
			this.m_FinishCallback = callback;
			this.m_Animation.FinishHandler = new SpriteAnimationFinishEventHandler(this._SpriteAnimationFinished);
		}
	}

	public void MakePixelPerfect()
	{
		if (this.m_Animation != null && this.m_Animation.sprite != null)
		{
			this.m_Animation.sprite.MakePixelPerfect();
		}
	}

	public void _SpriteAnimationFinished()
	{
		if (this.m_FinishCallback != null)
		{
			this.m_FinishCallback(this);
		}
	}
}
