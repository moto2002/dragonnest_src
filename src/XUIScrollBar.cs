using System;
using UILib;
using UnityEngine;

public class XUIScrollBar : XUIObject, IXUIScrollBar
{
	private UIScrollBar m_uiScrollBar;

	public float value
	{
		get
		{
			return this.m_uiScrollBar.value;
		}
		set
		{
			this.m_uiScrollBar.value = value;
		}
	}

	public float size
	{
		get
		{
			return this.m_uiScrollBar.barSize;
		}
		set
		{
			this.m_uiScrollBar.barSize = value;
		}
	}

	public void RegisterScrollBarChangeEventHandler(ScrollBarChangeEventHandler eventHandler)
	{
	}

	public void RegisterScrollBarDragFinishedEventHandler(ScrollBarDragFinishedEventHandler eventHandler)
	{
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiScrollBar = base.GetComponent<UIScrollBar>();
		if (null == this.m_uiScrollBar)
		{
			Debug.LogError("null == m_uiScrollBar");
		}
	}
}
