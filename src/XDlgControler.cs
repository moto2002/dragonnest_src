using System;
using UnityEngine;
using XUtliPoolLib;

public class XDlgControler : MonoBehaviour
{
	public GameObject m_CachedDlg;

	private IXGameUI m_gameui;

	private void Awake()
	{
		if (this.m_CachedDlg == null)
		{
			this.m_CachedDlg = base.gameObject;
		}
		if (this.m_CachedDlg.GetComponent<UISprite>() == null)
		{
			this.m_CachedDlg.AddComponent<UISprite>();
		}
		base.transform.GetComponent<UIPlayTween>().tweenTarget = this.m_CachedDlg;
		this.m_gameui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
		GameObject dlgControllerTpl = this.m_gameui.DlgControllerTpl;
		bool flag = false;
		bool flag2 = false;
		TweenScale[] components = this.m_CachedDlg.GetComponents<TweenScale>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].tweenGroup == 1)
			{
				flag = true;
			}
			if (components[i].tweenGroup == 2)
			{
				flag2 = true;
			}
		}
		components = dlgControllerTpl.GetComponents<TweenScale>();
		for (int j = 0; j < components.Length; j++)
		{
			if (!flag || components[j].tweenGroup != 1)
			{
				if (!flag2 || components[j].tweenGroup != 2)
				{
					TweenScale tweenScale = this.m_CachedDlg.AddComponent<TweenScale>();
					tweenScale.from = components[j].from;
					tweenScale.to = components[j].to;
					tweenScale.style = components[j].style;
					tweenScale.animationCurve = components[j].animationCurve;
					tweenScale.duration = components[j].duration;
					tweenScale.delay = components[j].delay;
					tweenScale.tweenGroup = components[j].tweenGroup;
					tweenScale.ignoreTimeScale = components[j].ignoreTimeScale;
					tweenScale.enabled = false;
				}
			}
		}
		flag = false;
		flag2 = false;
		TweenPosition[] components2 = this.m_CachedDlg.GetComponents<TweenPosition>();
		for (int k = 0; k < components2.Length; k++)
		{
			if (components2[k].tweenGroup == 1)
			{
				flag = true;
			}
			if (components2[k].tweenGroup == 2)
			{
				flag2 = true;
			}
		}
		components2 = dlgControllerTpl.GetComponents<TweenPosition>();
		for (int l = 0; l < components2.Length; l++)
		{
			if (!flag || components2[l].tweenGroup != 1)
			{
				if (!flag2 || components2[l].tweenGroup != 2)
				{
					TweenPosition tweenPosition = this.m_CachedDlg.AddComponent<TweenPosition>();
					tweenPosition.from = components2[l].from;
					tweenPosition.to = components2[l].to;
					tweenPosition.style = components2[l].style;
					tweenPosition.animationCurve = components2[l].animationCurve;
					tweenPosition.duration = components2[l].duration;
					tweenPosition.delay = components2[l].delay;
					tweenPosition.tweenGroup = components2[l].tweenGroup;
					tweenPosition.ignoreTimeScale = components2[l].ignoreTimeScale;
					tweenPosition.enabled = false;
				}
			}
		}
		flag = false;
		flag2 = false;
		TweenAlpha[] components3 = this.m_CachedDlg.GetComponents<TweenAlpha>();
		for (int m = 0; m < components3.Length; m++)
		{
			if (components3[m].tweenGroup == 1)
			{
				flag = true;
			}
			if (components3[m].tweenGroup == 2)
			{
				flag2 = true;
			}
		}
		components3 = dlgControllerTpl.GetComponents<TweenAlpha>();
		for (int n = 0; n < components3.Length; n++)
		{
			if (!flag || components3[n].tweenGroup != 1)
			{
				if (!flag2 || components3[n].tweenGroup != 2)
				{
					TweenAlpha tweenAlpha = this.m_CachedDlg.AddComponent<TweenAlpha>();
					tweenAlpha.from = components3[n].from;
					tweenAlpha.to = components3[n].to;
					tweenAlpha.style = components3[n].style;
					tweenAlpha.animationCurve = components3[n].animationCurve;
					tweenAlpha.duration = components3[n].duration;
					tweenAlpha.delay = components3[n].delay;
					tweenAlpha.tweenGroup = components3[n].tweenGroup;
					tweenAlpha.ignoreTimeScale = components3[n].ignoreTimeScale;
					tweenAlpha.enabled = false;
				}
			}
		}
	}
}
