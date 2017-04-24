using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XUILabel : XUIObject, IXUIObject, IXUILabel
{
	public float m_fAlphaVar;

	private int m_id;

	private UILabel m_uiLabel;

	private LabelClickEventHandler m_labelClickEventHandler;

	private bool m_bEnabled = true;

	private Color m_sourceColor;

	private Color m_sourceTop;

	private Color m_sourceBottom;

	private Color m_effectColor;

	private IXTutorial m_tutorial;

	public float AlphaVar
	{
		get
		{
			return this.m_fAlphaVar;
		}
	}

	public float Alpha
	{
		get
		{
			if (null != this.m_uiLabel)
			{
				return this.m_uiLabel.alpha;
			}
			return 1f;
		}
		set
		{
			if (null != this.m_uiLabel)
			{
				this.m_uiLabel.alpha = value;
			}
		}
	}

	public int spriteWidth
	{
		get
		{
			return this.m_uiLabel.width;
		}
	}

	public int spriteHeight
	{
		get
		{
			return this.m_uiLabel.height;
		}
	}

	public int spriteDepth
	{
		get
		{
			return this.m_uiLabel.depth;
		}
		set
		{
			this.m_uiLabel.depth = value;
		}
	}

	public int fontSize
	{
		get
		{
			return this.m_uiLabel.fontSize;
		}
		set
		{
			this.m_uiLabel.fontSize = value;
		}
	}

	public string GetText()
	{
		return this.m_uiLabel.text;
	}

	public Color GetColor()
	{
		return this.m_uiLabel.color;
	}

	public void SetText(string strText)
	{
		if (this.m_uiLabel != null)
		{
			this.m_uiLabel.text = Localization.Get(strText);
		}
	}

	public void SetColor(Color c)
	{
		this.m_uiLabel.color = c;
	}

	public void SetEffectColor(Color c)
	{
		this.m_uiLabel.effectColor = c;
	}

	public void SetGradient(bool bEnable, Color top, Color bottom)
	{
		this.m_uiLabel.applyGradient = bEnable;
		this.m_uiLabel.gradientTop = top;
		this.m_uiLabel.gradientBottom = bottom;
	}

	public void ToggleGradient(bool bEnable)
	{
		this.m_uiLabel.applyGradient = bEnable;
	}

	public void SetRootAsUIPanel(bool bFlg)
	{
		if (bFlg)
		{
			this.m_uiLabel.SetPanel(XSingleton<XUICommon>.singleton.m_uiRootPanel);
		}
		else
		{
			this.m_uiLabel.SetPanel(null);
		}
	}

	public void SetEnabled(bool bEnabled)
	{
		this.m_bEnabled = bEnabled;
		if (this.m_bEnabled)
		{
			this.m_uiLabel.color = this.m_sourceColor;
			this.m_uiLabel.gradientTop = this.m_sourceTop;
			this.m_uiLabel.gradientBottom = this.m_sourceBottom;
			this.m_uiLabel.effectColor = this.m_effectColor;
		}
		else
		{
			this.m_uiLabel.color = new Color(1f, 1f, 1f, 1f);
			float num = this.m_sourceTop.r * 0.3f + this.m_sourceTop.g * 0.587f + this.m_sourceTop.b * 0.114f;
			this.m_uiLabel.gradientTop = new Color(num, num, num);
			num = this.m_sourceBottom.r * 0.3f + this.m_sourceBottom.g * 0.587f + this.m_sourceBottom.b * 0.114f;
			this.m_uiLabel.gradientBottom = new Color(num, num, num);
			num = this.m_effectColor.r * 0.3f + this.m_effectColor.g * 0.587f + this.m_effectColor.b * 0.114f;
			this.m_uiLabel.effectColor = new Color(num, num, num);
		}
	}

	public void RegisterLabelClickEventHandler(LabelClickEventHandler eventHandler)
	{
		UIEventListener.Get(base.gameObject).onClick = new UIEventListener.VoidDelegate(this.OnLabelClick);
		this.m_labelClickEventHandler = eventHandler;
	}

	public void SetIdentity(int i)
	{
		this.m_id = i;
	}

	public bool HasIdentityChanged(int i)
	{
		return this.m_id != i;
	}

	private void OnLabelClick(GameObject button)
	{
		if (this.m_tutorial != null && this.m_tutorial.NoforceClick && this.Exculsive)
		{
			if (this.m_labelClickEventHandler != null)
			{
				this.m_labelClickEventHandler(this);
				this.m_tutorial.OnTutorialClicked();
			}
		}
		else if (this.m_tutorial == null || !this.m_tutorial.Exculsive)
		{
			if (this.m_labelClickEventHandler != null)
			{
				this.m_labelClickEventHandler(this);
			}
		}
		else if (this.m_tutorial.Exculsive && this.Exculsive)
		{
			if (this.m_labelClickEventHandler != null)
			{
				this.m_labelClickEventHandler(this);
				this.m_tutorial.OnTutorialClicked();
			}
		}
		else
		{
			XSingleton<XDebug>.singleton.AddLog("Exculsive block", null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}

	public Vector2 GetPrintSize()
	{
		return this.m_uiLabel.printedSize;
	}

	public void SetDepthOffset(int d)
	{
		UIWidget[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIWidget>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].depth += d;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_tutorial = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXTutorial>(XSingleton<XCommon>.singleton.XHash("XTutorial"));
		this.m_uiLabel = base.GetComponent<UILabel>();
		if (null == this.m_uiLabel)
		{
			Debug.LogError("null == m_uiLabel");
		}
		this.m_sourceColor = this.m_uiLabel.color;
		this.m_sourceTop = this.m_uiLabel.gradientTop;
		this.m_sourceBottom = this.m_uiLabel.gradientBottom;
		this.m_effectColor = this.m_uiLabel.effectColor;
	}
}
