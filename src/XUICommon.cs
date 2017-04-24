using System;
using UnityEngine;
using XUtliPoolLib;

public class XUICommon : XSingleton<XUICommon>
{
	public UIPanel m_uiRootPanel;

	public UIPanel m_inVisiablePanel;

	public void Init(Transform uiRoot)
	{
		this.m_uiRootPanel = uiRoot.GetComponent<UIPanel>();
		this.m_uiRootPanel.updateFrame = 3;
		this.m_inVisiablePanel = null;
		Transform transform = (!(this.m_uiRootPanel != null)) ? null : this.m_uiRootPanel.transform.FindChild("InVisiblePanel");
		if (transform != null)
		{
			this.m_inVisiablePanel = transform.GetComponent<UIPanel>();
		}
	}

	public void SetRootPanelUpdateFreq(int count)
	{
		this.m_uiRootPanel.updateFrame = count;
	}

	public static void CloneTplTweens(GameObject tpl, GameObject clone)
	{
		if (clone.GetComponent<UIPlayTween>() != null)
		{
			return;
		}
		UIPlayTween[] components = tpl.GetComponents<UIPlayTween>();
		for (int i = 0; i < components.Length; i++)
		{
			UIPlayTween uIPlayTween = components[i];
			UIPlayTween uIPlayTween2 = clone.AddComponent<UIPlayTween>();
			uIPlayTween2.tweenGroup = uIPlayTween.tweenGroup;
			uIPlayTween2.trigger = uIPlayTween.trigger;
			uIPlayTween2.playDirection = uIPlayTween.playDirection;
			uIPlayTween2.resetIfDisabled = uIPlayTween.resetIfDisabled;
			uIPlayTween2.resetOnPlay = uIPlayTween.resetOnPlay;
			uIPlayTween2.ifDisabledOnPlay = uIPlayTween.ifDisabledOnPlay;
			uIPlayTween2.disableWhenFinished = uIPlayTween.disableWhenFinished;
		}
		TweenScale[] components2 = tpl.GetComponents<TweenScale>();
		for (int j = 0; j < components2.Length; j++)
		{
			TweenScale tweenScale = components2[j];
			TweenScale tweenScale2 = clone.AddComponent<TweenScale>();
			tweenScale2.from = tweenScale.from;
			tweenScale2.to = tweenScale.to;
			tweenScale2.style = tweenScale.style;
			tweenScale2.animationCurve = tweenScale.animationCurve;
			tweenScale2.duration = tweenScale.duration;
			tweenScale2.delay = tweenScale.delay;
			tweenScale2.tweenGroup = tweenScale.tweenGroup;
			tweenScale2.ignoreTimeScale = tweenScale.ignoreTimeScale;
			tweenScale2.enabled = false;
		}
	}
}
