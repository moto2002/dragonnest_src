using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

public class XUIPopupList : XUIObject, IXUIObject, IXUIPopupList
{
	private UIPopupList m_uiPopupList;

	public string value
	{
		get
		{
			return this.m_uiPopupList.value;
		}
		set
		{
			this.m_uiPopupList.value = value;
		}
	}

	public int currentIndex
	{
		get
		{
			return this.m_uiPopupList.items.IndexOf(this.m_uiPopupList.value);
		}
		set
		{
			if (value >= this.m_uiPopupList.items.Count)
			{
				Debug.LogError("Index out of range. " + value);
				return;
			}
			this.m_uiPopupList.value = this.m_uiPopupList.items[value];
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiPopupList = base.GetComponent<UIPopupList>();
		if (null == this.m_uiPopupList)
		{
			Debug.LogError("null == m_uiPopupList");
		}
	}

	public void SetOptionList(List<string> options)
	{
		this.m_uiPopupList.items = options;
	}
}
