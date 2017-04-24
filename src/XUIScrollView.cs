using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XUIScrollView : XUIObject, IXUIScrollView, IXUIObject
{
	private UIScrollView m_uiScrollView;

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiScrollView = base.GetComponent<UIScrollView>();
		if (null == this.m_uiScrollView)
		{
			XSingleton<XDebug>.singleton.AddErrorLog("null == m_uiScrollView", null, null, null, null, null);
		}
	}

	public void ResetPosition()
	{
		this.m_uiScrollView.ResetPosition();
	}

	public void UpdatePosition()
	{
		this.m_uiScrollView.UpdatePosition();
	}

	public void SetCustomMovement(Vector2 movment)
	{
		this.m_uiScrollView.customMovement = movment;
	}

	public void SetPosition(float pos)
	{
		Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.m_uiScrollView.contentPivot);
		this.m_uiScrollView.SetDragAmount(pivotOffset.x, pos, false);
		this.m_uiScrollView.SetDragAmount(pivotOffset.x, pos, true);
	}

	public void SetDragPositionX(float pos)
	{
		Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.m_uiScrollView.contentPivot);
		this.m_uiScrollView.SetDragAmount(pos + pivotOffset.x, pivotOffset.y, false);
		this.m_uiScrollView.SetDragAmount(pos + pivotOffset.x, pivotOffset.y, true);
	}

	public void SetDragFinishDelegate(Delegate func)
	{
		this.m_uiScrollView.onDragFinished = (UIScrollView.OnDragFinished)func;
	}

	public void SetAutoMove(float from, float to, float moveSpeed)
	{
		this.m_uiScrollView.SetAutoMove(from, to, moveSpeed);
	}

	public bool RestrictWithinBounds(bool instant)
	{
		return this.m_uiScrollView.RestrictWithinBounds(instant);
	}

	public void MoveAbsolute(Vector3 absolute)
	{
		this.m_uiScrollView.MoveAbsolute(absolute);
	}

	public void MoveRelative(Vector3 relative)
	{
		this.m_uiScrollView.MoveRelative(relative);
	}

	public void NeedRecalcBounds()
	{
		this.m_uiScrollView.NeedRecalcBounds();
	}
}
