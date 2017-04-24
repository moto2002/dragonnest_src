using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XUICheckBox : XUIObject, IXUIObject, IXUICheckBox
{
	public string audioClip;

	public bool m_NeedAudio = true;

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0f, 2f)]
	public float pitch = 1f;

	public int m_SpriteAnimationType;

	private IXTutorial m_tutorial;

	private IXGameUI m_gameui;

	private Collider m_colliderCached;

	private UISprite m_uiSpriteBG;

	private UIToggle m_uiToggle;

	private CheckBoxOnCheckEventHandler m_stateChangeHandler;

	public bool bChecked
	{
		get
		{
			return this.m_uiToggle.value;
		}
		set
		{
			this.m_uiToggle.value = value;
		}
	}

	public int spriteHeight
	{
		get
		{
			return this.m_uiSpriteBG.height;
		}
		set
		{
			this.m_uiSpriteBG.height = value;
		}
	}

	public int spriteWidth
	{
		get
		{
			return this.m_uiSpriteBG.width;
		}
		set
		{
			this.m_uiSpriteBG.width = value;
		}
	}

	public bool bInstantTween
	{
		get
		{
			return this.m_uiToggle.instantTween;
		}
		set
		{
			this.m_uiToggle.instantTween = value;
		}
	}

	public void ForceSetFlag(bool bCheckd)
	{
		this.m_uiToggle.ForceSetActive(bCheckd);
	}

	public void RegisterOnCheckEventHandler(CheckBoxOnCheckEventHandler eventHandler)
	{
		this.m_stateChangeHandler = eventHandler;
		EventDelegate.Add(this.m_uiToggle.onChange, new EventDelegate.Callback(this.OnStateChange));
		UIEventListener expr_2E = UIEventListener.Get(base.gameObject);
		expr_2E.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_2E.onClick, new UIEventListener.VoidDelegate(this.OnTabClick));
		UIEventListener expr_5A = UIEventListener.Get(base.gameObject);
		expr_5A.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_5A.onClick, new UIEventListener.VoidDelegate(this.OnTabClick));
	}

	public CheckBoxOnCheckEventHandler GetCheckEventHandler()
	{
		return this.m_stateChangeHandler;
	}

	public void SetEnable(bool bEnable)
	{
		if (null != this.m_colliderCached)
		{
			this.m_colliderCached.enabled = bEnable;
		}
		if (null != this.m_uiSpriteBG)
		{
			this.m_uiSpriteBG.color = ((!bEnable) ? new Color(0.3f, 0.3f, 0.3f, 1f) : Color.white);
		}
	}

	public void OnStateChange()
	{
		if (this.m_stateChangeHandler != null)
		{
			this.m_stateChangeHandler(this);
		}
	}

	public void SetAlpha(float f)
	{
		this.m_uiSpriteBG.alpha = f;
	}

	private void OnTabClick(GameObject button)
	{
		if (this.m_tutorial != null && this.m_tutorial.Exculsive && this.Exculsive)
		{
			this.m_tutorial.OnTutorialClicked();
		}
		if (this.m_NeedAudio && !string.IsNullOrEmpty(this.audioClip))
		{
			NGUITools.PlayFmod("event:/" + this.audioClip);
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_tutorial = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXTutorial>(XSingleton<XCommon>.singleton.XHash("XTutorial"));
		this.m_gameui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
		this.m_colliderCached = base.collider;
		if (null == this.m_colliderCached)
		{
			Debug.Log("null == m_colliderCached");
		}
		this.m_uiToggle = base.GetComponent<UIToggle>();
		if (null == this.m_uiToggle)
		{
			Debug.Log("null == m_uiToggle");
		}
		this.m_uiSpriteBG = base.GetComponentInChildren<UISprite>();
		if (null == this.m_uiSpriteBG)
		{
			Debug.Log("null == m_uiSpriteBG");
		}
		this.CloneFromTpl();
		if (this.m_NeedAudio && (string.IsNullOrEmpty(this.audioClip) || !this.audioClip.StartsWith("Audio")))
		{
			this.SetAudioClip("Audio/UI/UI_Button_ok");
		}
	}

	protected void CloneFromTpl()
	{
		if (this.m_SpriteAnimationType <= 0)
		{
			return;
		}
		GameObject tpl = this.m_gameui.spriteTpl[this.m_SpriteAnimationType - 1];
		XUICommon.CloneTplTweens(tpl, base.gameObject);
	}

	public void SetAudioClip(string name)
	{
		if (!this.m_NeedAudio)
		{
			return;
		}
		this.audioClip = name;
	}

	public void SetGroup(int group)
	{
		this.m_uiToggle.group = group;
	}
}
