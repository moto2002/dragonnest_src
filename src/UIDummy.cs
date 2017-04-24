using System;
using UILib;
using UnityEngine;

[AddComponentMenu("NGUI/UI/NGUI Dummy"), ExecuteInEditMode]
public sealed class UIDummy : UIWidget, IUIDummy, IUIRect, IUIWidget
{
	private int renderQueue = -1;

	public int RenderQueue
	{
		get
		{
			return (!(this.drawCall != null)) ? -1 : this.drawCall.renderQueue;
		}
	}

	public RefreshRenderQueueCb RefreshRenderQueue
	{
		get;
		set;
	}

	protected override void OnInit()
	{
		base.OnInit();
		this.renderQueue = -1;
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}

	public void LateUpdate()
	{
		if (this.renderQueue != this.RenderQueue && this.RefreshRenderQueue != null && this.RefreshRenderQueue(this.RenderQueue + 1))
		{
			this.renderQueue = this.RenderQueue + 1;
		}
	}

	public void Reset()
	{
		this.renderQueue = -1;
	}

	public IXUIPanel GetPanel()
	{
		return XUIPanel.GetPanel(this.panel);
	}

	virtual int get_depth()
	{
		return base.depth;
	}

	virtual void set_depth(int value)
	{
		base.depth = value;
	}
}
