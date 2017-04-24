using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XUIButton : XUIObject, IXUIObject, IXUIButton, IXUICD
{
	private static List<UILabel> tmpLabel = new List<UILabel>();

	private static List<XUILabel> tmpXLabel = new List<XUILabel>();

	private static List<UISprite> tmpSprite = new List<UISprite>();

	private static Color black = new Color(0f, 0f, 0f, 1f);

	private UIEventListener eventListenerCache;

	public int m_ButtonAnimationType;

	public bool ChangeStateSprite;

	public bool m_useSprite;

	public string audioClip;

	public bool m_NeedAudio = true;

	public float CustomClickCD = -1f;

	public int CustomClickCDGroup;

	private XUICD m_CD = new XUICD();

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0f, 2f)]
	public float pitch = 1f;

	private UIButtonOffset m_uiButtonOffset;

	private UIButtonScale m_uiButtonScale;

	private UIButtonColor m_uiButtonColor;

	private UIButton m_uiButton;

	private Collider m_colliderCached;

	private UISprite m_uiSpriteBG;

	private bool m_bEnabled = true;

	private IXTutorial m_tutorial;

	private IXGameUI m_gameui;

	private IXOperationRecord m_operation;

	private ButtonClickEventHandler m_buttonClickEventHandler;

	private ButtonPressEventHandler m_buttonPressEventHandler;

	private ButtonDragEventHandler m_buttonDragEventHandler;

	private bool m_state;

	public int spriteWidth
	{
		get
		{
			return this.m_uiSpriteBG.width;
		}
	}

	public int spriteHeight
	{
		get
		{
			return this.m_uiSpriteBG.height;
		}
	}

	public int spriteDepth
	{
		get
		{
			return this.m_uiSpriteBG.depth;
		}
		set
		{
			this.m_uiSpriteBG.depth = value;
		}
	}

	public void SetSpriteWithPrefix(string prefix)
	{
		this.m_uiButton.normalSprite = prefix + "_0";
		this.m_uiButton.hoverSprite = prefix + "_0";
		this.m_uiButton.pressedSprite = prefix + "_1";
	}

	public void SetSprites(string normal, string hover, string press)
	{
		this.m_uiButton.normalSprite = normal;
		this.m_uiButton.hoverSprite = hover;
		this.m_uiButton.pressedSprite = press;
	}

	public void SetCaption(string strText)
	{
		base.GetComponentsInChildren<UILabel>(true, XUIButton.tmpLabel);
		if (XUIButton.tmpLabel.Count > 0)
		{
			XUIButton.tmpLabel[0].text = strText;
		}
		XUIButton.tmpLabel.Clear();
	}

	public void SetEnable(bool bEnable, bool withcollider = false)
	{
		if (this.m_bEnabled != bEnable)
		{
			if (!bEnable)
			{
				if (this.m_state)
				{
					this._ButtonPress(base.gameObject, false);
				}
				this.m_bEnabled = bEnable;
			}
			else
			{
				this.m_bEnabled = bEnable;
				if (this.m_state)
				{
					this._ButtonPress(base.gameObject, true);
				}
			}
		}
		if (null != this.m_colliderCached)
		{
			this.m_colliderCached.enabled = (bEnable || withcollider);
		}
		if (null != this.m_uiButtonColor)
		{
			this.m_uiButtonColor.enabled = (bEnable || withcollider);
		}
		if (null != this.m_uiButtonScale)
		{
			this.m_uiButtonScale.enabled = bEnable;
		}
		if (null != this.m_uiButtonOffset)
		{
			this.m_uiButtonOffset.enabled = bEnable;
		}
		if (null != this.m_uiSpriteBG)
		{
			this.m_uiSpriteBG.color = ((!bEnable) ? XUISprite.GREY_COLOR : Color.white);
			base.gameObject.GetComponentsInChildren<UISprite>(true, XUIButton.tmpSprite);
			for (int i = 0; i < XUIButton.tmpSprite.Count; i++)
			{
				XUIButton.tmpSprite[i].color = ((!bEnable) ? XUISprite.GREY_COLOR : Color.white);
			}
			XUIButton.tmpSprite.Clear();
		}
		base.gameObject.GetComponentsInChildren<XUILabel>(XUIButton.tmpXLabel);
		for (int j = 0; j < XUIButton.tmpXLabel.Count; j++)
		{
			XUIButton.tmpXLabel[j].SetEnabled(bEnable);
		}
		XUIButton.tmpXLabel.Clear();
	}

	public void SetGrey(bool bGrey)
	{
		if (null != this.m_uiSpriteBG)
		{
			this.m_uiSpriteBG.color = ((!bGrey) ? new Color(0f, 0f, 0f, 1f) : Color.white);
			this.m_uiButtonColor.defaultColor = ((!bGrey) ? XUIButton.black : Color.white);
			this.m_uiButtonColor.hover = ((!bGrey) ? XUIButton.black : Color.white);
			this.m_uiButtonColor.pressed = ((!bGrey) ? XUIButton.black : Color.white);
			base.gameObject.GetComponentsInChildren<UISprite>(XUIButton.tmpSprite);
			for (int i = 0; i < XUIButton.tmpSprite.Count; i++)
			{
				XUIButton.tmpSprite[i].color = ((!bGrey) ? XUIButton.black : Color.white);
			}
			XUIButton.tmpSprite.Clear();
		}
	}

	public void CloseScrollView()
	{
		UIDragScrollView component = base.GetComponent<UIDragScrollView>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void ResetPanel()
	{
		this.m_uiSpriteBG.panel = null;
	}

	private UIEventListener GetUIEventListener()
	{
		if (this.eventListenerCache == null)
		{
			this.eventListenerCache = UIEventListener.Get(base.gameObject);
		}
		return this.eventListenerCache;
	}

	public void RegisterClickEventHandler(ButtonClickEventHandler eventHandler)
	{
		UIEventListener expr_06 = this.GetUIEventListener();
		expr_06.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_06.onClick, new UIEventListener.VoidDelegate(this.OnButtonClick));
		UIEventListener expr_2D = this.GetUIEventListener();
		expr_2D.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_2D.onClick, new UIEventListener.VoidDelegate(this.OnButtonClick));
		this.m_buttonClickEventHandler = eventHandler;
	}

	public ButtonClickEventHandler GetClickEventHandler()
	{
		return this.m_buttonClickEventHandler;
	}

	public ButtonPressEventHandler GetPressEventHandler()
	{
		return this.m_buttonPressEventHandler;
	}

	public void ResetState()
	{
		this.m_state = false;
	}

	public void RegisterPressEventHandler(ButtonPressEventHandler eventHandler)
	{
		UIEventListener.Get(base.gameObject).onPress = new UIEventListener.BoolDelegate(this.OnButtonPressed);
		this.m_buttonPressEventHandler = eventHandler;
	}

	public void RegisterDragEventHandler(ButtonDragEventHandler eventHandler)
	{
		UIEventListener.Get(base.gameObject).onDrag = new UIEventListener.VectorDelegate(this.OnButtonDrag);
		this.m_buttonDragEventHandler = eventHandler;
	}

	private void OnButtonPressed(GameObject button, bool state)
	{
		this.m_state = state;
		if (!this.m_bEnabled)
		{
			return;
		}
		this._ButtonPress(button, state);
	}

	private void OnButtonDrag(GameObject button, Vector2 delta)
	{
		if (!this.m_bEnabled)
		{
			return;
		}
		if (this.m_buttonDragEventHandler != null)
		{
			this.m_buttonDragEventHandler(this, delta);
		}
	}

	private void _ButtonPress(GameObject button, bool state)
	{
		if (this.m_tutorial != null && this.m_tutorial.NoforceClick && this.Exculsive && this.m_buttonPressEventHandler != null)
		{
			this.m_buttonPressEventHandler(this, state);
			if (this.m_operation != null)
			{
				this.m_operation.FindRecordID(button.transform);
			}
			if (state)
			{
				this.m_tutorial.OnTutorialClicked();
			}
		}
		if (this.m_tutorial == null || !this.m_tutorial.Exculsive)
		{
			if (this.m_buttonPressEventHandler != null)
			{
				this.m_buttonPressEventHandler(this, state);
				if (this.m_operation != null && state)
				{
					this.m_operation.FindRecordID(button.transform);
				}
			}
		}
		else if (this.m_tutorial.Exculsive && this.Exculsive)
		{
			if (this.m_buttonPressEventHandler != null)
			{
				this.m_buttonPressEventHandler(this, state);
				if (this.m_operation != null && state)
				{
					this.m_operation.FindRecordID(button.transform);
				}
				if (state)
				{
					this.m_tutorial.OnTutorialClicked();
				}
			}
		}
		else
		{
			XSingleton<XDebug>.singleton.AddLog("Exculsive block", null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}

	private void OnButtonClick(GameObject button)
	{
		if (!this.m_bEnabled)
		{
			return;
		}
		if (this.m_CD.IsInCD())
		{
			return;
		}
		if (this.m_tutorial != null && this.m_tutorial.NoforceClick && this.Exculsive)
		{
			if (this.m_buttonClickEventHandler != null)
			{
				this.m_buttonClickEventHandler(this);
				this.m_tutorial.OnTutorialClicked();
			}
		}
		else if (this.m_tutorial == null || !this.m_tutorial.Exculsive)
		{
			if (this.m_buttonClickEventHandler != null)
			{
				this.m_buttonClickEventHandler(this);
				if (this.m_operation != null)
				{
					this.m_operation.FindRecordID(button.transform);
				}
			}
		}
		else if (this.m_tutorial.Exculsive && this.Exculsive)
		{
			if (this.m_buttonClickEventHandler != null)
			{
				this.m_buttonClickEventHandler(this);
				if (this.m_operation != null)
				{
					this.m_operation.FindRecordID(button.transform);
				}
				this.m_tutorial.OnTutorialClicked();
			}
		}
		else
		{
			XSingleton<XDebug>.singleton.AddLog("Exculsive block", null, null, null, null, null, XDebugColor.XDebug_None);
		}
		if (this.m_NeedAudio && !string.IsNullOrEmpty(this.audioClip))
		{
			NGUITools.PlayFmod("event:/" + this.audioClip);
		}
	}

	public void SetAlpha(float f)
	{
		this.m_uiSpriteBG.alpha = f;
		this.m_uiButtonColor.defaultColor = new Color(this.m_uiButtonColor.defaultColor.r, this.m_uiButtonColor.defaultColor.g, this.m_uiButtonColor.defaultColor.b, f);
		this.m_uiButtonColor.hover.a = f;
		this.m_uiButtonColor.pressed.a = f;
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_gameui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
		this.m_tutorial = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXTutorial>(XSingleton<XCommon>.singleton.XHash("XTutorial"));
		this.m_operation = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXOperationRecord>(XSingleton<XCommon>.singleton.XHash("XOperationRecord"));
		this.m_uiButton = base.GetComponent<UIButton>();
		this.m_uiButtonColor = this.m_uiButton;
		this.m_uiButtonScale = base.GetComponent<UIButtonScale>();
		this.m_uiButtonOffset = base.GetComponent<UIButtonOffset>();
		this.m_uiSpriteBG = base.GetComponentInChildren<UISprite>();
		if (this.m_uiButton != null)
		{
			this.m_colliderCached = this.m_uiButton.cacheCol;
		}
		else
		{
			this.m_colliderCached = base.GetComponent<Collider>();
		}
		this.CloneFromTpl();
		if (this.m_NeedAudio && (string.IsNullOrEmpty(this.audioClip) || !this.audioClip.StartsWith("Audio")))
		{
			this.SetAudioClip("Audio/UI/UI_Button_ok");
		}
		this.m_CD.SetClickCD(this.CustomClickCDGroup, this.CustomClickCD);
		if (this.m_uiButton != null)
		{
			this.m_uiButton.changeStateSprite = this.ChangeStateSprite;
		}
	}

	protected void CloneFromTpl()
	{
		if (this.m_ButtonAnimationType <= 0)
		{
			return;
		}
		GameObject gameObject = this.m_gameui.buttonTpl[this.m_ButtonAnimationType - 1];
		XUICommon.CloneTplTweens(gameObject, base.gameObject);
		if (this.m_useSprite)
		{
			UISprite component = gameObject.GetComponent<UISprite>();
			UIButton component2 = gameObject.GetComponent<UIButton>();
			UISprite component3 = base.gameObject.GetComponent<UISprite>();
			UIButton component4 = base.gameObject.GetComponent<UIButton>();
			component3.spriteName = component.spriteName;
			component4.normalSprite = component2.normalSprite;
			component4.hoverSprite = component2.hoverSprite;
			component4.pressedSprite = component2.pressedSprite;
		}
	}

	public void SetAudioClip(string name)
	{
		if (!this.m_NeedAudio)
		{
			return;
		}
		this.audioClip = name;
	}

	public void SetClickCD(float cd)
	{
		this.CustomClickCD = cd;
		this.m_CD.SetClickCD(this.CustomClickCDGroup, this.CustomClickCD);
	}

	public void ResetCD()
	{
		this.m_CD.Reset();
	}
}
