using System;
using UILib;
using UnityEngine;

public class XUICenterOnClick : XUIObject, IXUIObject, IXUICenterOnClick
{
	private UICenterOnClick m_uiCenterOnClick;

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiCenterOnClick = base.GetComponent<UICenterOnClick>();
		if (null == this.m_uiCenterOnClick)
		{
			Debug.LogError("null == m_uiCenterOnClick");
		}
	}

	public void OnClick()
	{
		this.m_uiCenterOnClick.OnClick();
	}
}
