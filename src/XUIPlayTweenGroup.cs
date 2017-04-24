using System;
using UILib;
using UnityEngine;

public class XUIPlayTweenGroup : MonoBehaviour, IXUIPlayTweenGroup
{
	public UIPlayTween[] m_tweenControls;

	void IXUIPlayTweenGroup.PlayTween(bool bForward)
	{
		if (this.m_tweenControls == null || this.m_tweenControls.Length == 0)
		{
			return;
		}
		int i = 0;
		int num = this.m_tweenControls.Length;
		while (i < num)
		{
			this.m_tweenControls[i].Play(bForward);
			i++;
		}
	}

	void IXUIPlayTweenGroup.ResetTween(bool bForward)
	{
		if (this.m_tweenControls == null || this.m_tweenControls.Length == 0)
		{
			return;
		}
		int i = 0;
		int num = this.m_tweenControls.Length;
		while (i < num)
		{
			this.m_tweenControls[i].Reset(bForward);
			i++;
		}
	}

	void IXUIPlayTweenGroup.StopTween()
	{
		if (this.m_tweenControls == null || this.m_tweenControls.Length == 0)
		{
			return;
		}
		int i = 0;
		int num = this.m_tweenControls.Length;
		while (i < num)
		{
			this.m_tweenControls[i].Stop();
			i++;
		}
	}

	private void Awake()
	{
		this.m_tweenControls = base.GetComponents<UIPlayTween>();
	}
}
