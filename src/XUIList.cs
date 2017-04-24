using System;
using UILib;
using UnityEngine;

public class XUIList : XUIObject, IXUIObject, IXUIList
{
	public UIRect _parent;

	private UIGrid m_uiGrid;

	private OnAfterRepostion onRepositionFinish;

	public void Refresh()
	{
		this.m_uiGrid.repositionNow = true;
	}

	public void CloseList()
	{
		this.m_uiGrid.CloseList();
	}

	public void SetAnimateSmooth(bool b)
	{
		this.m_uiGrid.animateSmoothly = b;
	}

	public void RegisterRepositionHandle(OnAfterRepostion reposition)
	{
		this.onRepositionFinish = reposition;
	}

	private void OnAfterReposition()
	{
		if (this.onRepositionFinish != null)
		{
			this.onRepositionFinish();
		}
	}

	public IUIRect GetParentUIRect()
	{
		return this._parent;
	}

	public IUIPanel GetParentPanel()
	{
		return this.m_uiGrid.panel;
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiGrid = base.GetComponent<UIGrid>();
		if (this.m_uiGrid != null)
		{
			this.m_uiGrid.onReposition = new UIGrid.OnReposition(this.OnAfterReposition);
		}
		else
		{
			Debug.Log("no ngui grid component");
		}
	}
}
