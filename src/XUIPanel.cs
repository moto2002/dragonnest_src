using System;
using UILib;
using UnityEngine;

public class XUIPanel : XUIObject, IXUIObject, IXUIPanel
{
	public UIPanel m_uiPanel;

	public Vector2 offset
	{
		get
		{
			return this.m_uiPanel.clipOffset;
		}
		set
		{
			this.m_uiPanel.clipOffset = value;
		}
	}

	public Vector4 ClipRange
	{
		get
		{
			return this.m_uiPanel.baseClipRegion;
		}
		set
		{
			this.m_uiPanel.baseClipRegion = value;
		}
	}

	public Vector2 softness
	{
		get
		{
			return this.m_uiPanel.clipSoftness;
		}
		set
		{
			this.m_uiPanel.clipSoftness = value;
		}
	}

	public Action onMoveDel
	{
		get;
		set;
	}

	public Component UIComponent
	{
		get
		{
			return this.m_uiPanel;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		if (null == this.m_uiPanel)
		{
			this.m_uiPanel = base.GetComponent<UIPanel>();
			if (null == this.m_uiPanel)
			{
				Debug.LogError("null == m_uiPanel");
			}
		}
		UIPanel expr_44 = this.m_uiPanel;
		expr_44.onClipMove = (UIPanel.OnClippingMoved)Delegate.Combine(expr_44.onClipMove, new UIPanel.OnClippingMoved(this.OnMove));
	}

	public void OnMove(UIPanel panel)
	{
		if (this.onMoveDel != null)
		{
			this.onMoveDel();
		}
	}

	public void SetSize(float width, float height)
	{
		Vector4 baseClipRegion = this.m_uiPanel.baseClipRegion;
		this.m_uiPanel.baseClipRegion = new Vector4(baseClipRegion.x, baseClipRegion.y, width, height);
	}

	public Vector4 GetBaseRect()
	{
		return this.m_uiPanel.baseClipRegion;
	}

	public void SetAlpha(float a)
	{
		this.m_uiPanel.alpha = a;
	}

	public float GetAlpha()
	{
		return this.m_uiPanel.alpha;
	}

	public void SetDepth(int d)
	{
		this.m_uiPanel.depth = d;
	}

	public int GetDepth()
	{
		return this.m_uiPanel.depth;
	}

	public bool IsVisible(GameObject go)
	{
		return this.m_uiPanel.IsVisible(go.GetComponent<UIWidget>());
	}

	public static IXUIPanel GetPanel(UIPanel panel)
	{
		if (panel == null)
		{
			return null;
		}
		XUIPanel xUIPanel = panel.GetComponent<XUIPanel>();
		if (xUIPanel == null)
		{
			xUIPanel = panel.gameObject.AddComponent<XUIPanel>();
		}
		return xUIPanel;
	}
}
