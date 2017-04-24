using System;
using UnityEngine;
using XUtliPoolLib;

[Serializable]
public class LoopItemObject : ILoopItemObject
{
	public UIWidget widget;

	public int _dataIndex = -1;

	public int dataIndex
	{
		get
		{
			return this._dataIndex;
		}
		set
		{
			this._dataIndex = value;
		}
	}

	public bool isVisible()
	{
		LoopScrollView loopScrollView = NGUITools.FindInParents<LoopScrollView>(this.widget.gameObject);
		return loopScrollView != null && loopScrollView.IsVisible(this);
	}

	public GameObject GetObj()
	{
		return this.widget.gameObject;
	}

	public void SetHeight(int height)
	{
		this.widget.height = height;
	}
}
