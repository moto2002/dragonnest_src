using System;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

public class XUISprite : XUIObject, IXUIObject, IXUISprite, IUIRect, IUIWidget, IXUICD
{
	public static Color GREY_COLOR = new Color(0f, 0f, 0f, 0.7f);

	public int m_SpriteAnimationType;

	private UISprite m_uiSprite;

	public string audioClip;

	public bool m_NeedAudio = true;

	public float CustomClickCD = -1f;

	public int CustomClickCDGroup;

	private XUICD m_CD = new XUICD();

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0f, 2f)]
	public float pitch = 1f;

	public string SpriteAtlasPath = string.Empty;

	public string HalfPath = string.Empty;

	public string SPriteName = string.Empty;

	private UISpriteAnimation m_Animation;

	private SpriteClickEventHandler m_spriteClickEventHandler;

	private SpriteClickEventHandler m_spriteLongPressEventHandler;

	private SpritePressEventHandler m_spritePressEventHandler;

	private SpriteDragEventHandler m_spriteDragEventHandler;

	private string m_spriteNameCached = string.Empty;

	private string m_spriteAtlasCached = string.Empty;

	private bool m_bEnabled = true;

	private Color m_sourceColor;

	private IXTutorial m_tutorial;

	private IXGameUI m_gameui;

	private IXOperationRecord m_operation;

	private bool m_invalidDrag;

	public IXUIAtlas uiAtlas
	{
		get
		{
			if (!(null != this.m_uiSprite))
			{
				return null;
			}
			if (null == this.m_uiSprite.atlas)
			{
				return null;
			}
			return this.m_uiSprite.atlas.GetComponent<XUIAtlas>();
		}
	}

	public string spriteName
	{
		get
		{
			if (null != this.m_uiSprite)
			{
				return this.m_uiSprite.spriteName;
			}
			return null;
		}
		set
		{
			this.m_uiSprite.spriteName = value;
		}
	}

	public int spriteWidth
	{
		get
		{
			return this.m_uiSprite.width;
		}
		set
		{
			this.m_uiSprite.width = value;
		}
	}

	public int spriteHeight
	{
		get
		{
			return this.m_uiSprite.height;
		}
		set
		{
			this.m_uiSprite.height = value;
		}
	}

	public int spriteDepth
	{
		get
		{
			return this.m_uiSprite.depth;
		}
		set
		{
			this.m_uiSprite.depth = value;
		}
	}

	public Vector4 drawRegion
	{
		get
		{
			return this.m_uiSprite.drawRegion;
		}
		set
		{
			this.m_uiSprite.drawRegion = value;
		}
	}

	public bool ClickCanceled
	{
		get;
		set;
	}

	public bool SetSprite(string strSprite, string strAtlas)
	{
		if (null == this.m_uiSprite)
		{
			return false;
		}
		if (this.m_spriteAtlasCached != strAtlas)
		{
			GameObject sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/" + strAtlas, ".prefab", true);
			this.m_uiSprite.atlas = ((!(sharedResource == null)) ? sharedResource.GetComponent<UIAtlas>() : null);
			this.m_spriteAtlasCached = strAtlas;
		}
		this.m_uiSprite.spriteName = strSprite;
		return true;
	}

	public void MakePixelPerfect()
	{
		if (this.m_uiSprite == null)
		{
			XSingleton<XDebug>.singleton.AddErrorLog("Sprite is Null", null, null, null, null, null);
			return;
		}
		this.m_uiSprite.MakePixelPerfect();
	}

	public void SetRootAsUIPanel(bool bFlg)
	{
		if (bFlg)
		{
			this.m_uiSprite.SetPanel(XSingleton<XUICommon>.singleton.m_uiRootPanel);
		}
		else
		{
			this.m_uiSprite.SetPanel(null);
		}
	}

	public void SetColor(Color c)
	{
		this.m_uiSprite.color = c;
	}

	private void OnLoadAtlasFinished(UnityEngine.Object obj)
	{
		UIAtlas uIAtlas = obj as UIAtlas;
		if (null == uIAtlas)
		{
			Debug.LogError("null == uiAtlas");
			return;
		}
		this.m_uiSprite.atlas = uIAtlas;
		this.m_uiSprite.spriteName = this.m_spriteNameCached;
	}

	public void ResetPanel()
	{
		this.m_uiSprite.panel = null;
	}

	public bool SetSprite(string strSpriteName)
	{
		if (null == this.m_uiSprite)
		{
			return false;
		}
		this.m_uiSprite.spriteName = strSpriteName;
		return true;
	}

	public void SetEnabled(bool bEnabled)
	{
		this.m_bEnabled = bEnabled;
		this.SetGrey(bEnabled);
	}

	public void DelayLoadSprite()
	{
		IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
		if (!string.IsNullOrEmpty(this.HalfPath) && xPlatform.IsUIHalfResolution())
		{
			this.SetSprite(this.SPriteName, this.HalfPath);
		}
		else
		{
			this.SetSprite(this.SPriteName, this.SpriteAtlasPath);
		}
	}

	public void SetGrey(bool bGrey)
	{
		if (bGrey)
		{
			this.m_uiSprite.color = this.m_sourceColor;
		}
		else
		{
			this.m_uiSprite.color = XUISprite.GREY_COLOR;
		}
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = ((!bGrey) ? XUISprite.GREY_COLOR : Color.white);
		}
	}

	public void SetAlpha(float alpha)
	{
		this.m_uiSprite.color = new Color(this.m_uiSprite.color.r, this.m_uiSprite.color.g, this.m_uiSprite.color.b, alpha);
	}

	public float GetAlpha()
	{
		return this.m_uiSprite.alpha;
	}

	public void SetAudioClip(string name)
	{
		this.audioClip = name;
	}

	public void CloseScrollView()
	{
		UIDragScrollView component = base.GetComponent<UIDragScrollView>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void RegisterSpriteClickEventHandler(SpriteClickEventHandler eventHandler)
	{
		UIEventListener expr_0B = UIEventListener.Get(base.gameObject);
		expr_0B.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(expr_0B.onClick, new UIEventListener.VoidDelegate(this.OnSpriteClick));
		UIEventListener expr_37 = UIEventListener.Get(base.gameObject);
		expr_37.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_37.onClick, new UIEventListener.VoidDelegate(this.OnSpriteClick));
		this.m_spriteClickEventHandler = eventHandler;
	}

	public void RegisterSpritePressEventHandler(SpritePressEventHandler eventHandler)
	{
		this.m_spritePressEventHandler = eventHandler;
	}

	public void RegisterSpriteDragEventHandler(SpriteDragEventHandler eventHandler)
	{
		this.m_spriteDragEventHandler = eventHandler;
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_gameui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
		this.m_tutorial = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXTutorial>(XSingleton<XCommon>.singleton.XHash("XTutorial"));
		this.m_operation = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXOperationRecord>(XSingleton<XCommon>.singleton.XHash("XOperationRecord"));
		this.m_uiSprite = base.GetComponent<UISprite>();
		if (!string.IsNullOrEmpty(this.SpriteAtlasPath))
		{
			IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
			if (xPlatform.IsUIDelayLoad() && !string.IsNullOrEmpty(this.HalfPath))
			{
				XUITool.Instance.XGameUI.DelayLoadUISprite(this);
			}
			else if (!string.IsNullOrEmpty(this.HalfPath) && xPlatform.IsUIHalfResolution())
			{
				this.SetSprite(this.SPriteName, this.HalfPath);
			}
			else
			{
				this.SetSprite(this.SPriteName, this.SpriteAtlasPath);
			}
		}
		if (null == this.m_uiSprite)
		{
			Debug.Log("null == m_uiSprite," + base.gameObject.name);
		}
		this.m_sourceColor = this.m_uiSprite.color;
		this.CloneFromTpl();
		if (this.m_NeedAudio && (string.IsNullOrEmpty(this.audioClip) || !this.audioClip.StartsWith("Audio")))
		{
			this.SetAudioClip("Audio/UI/UI_Button_ok");
		}
		this.m_CD.SetClickCD(this.CustomClickCDGroup, this.CustomClickCD);
		this.ClickCanceled = false;
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

	private void OnSpriteClick(GameObject button)
	{
		if (!this.m_bEnabled)
		{
			return;
		}
		if (this.ClickCanceled)
		{
			this.ClickCanceled = false;
			return;
		}
		if (this.m_CD.IsInCD())
		{
			return;
		}
		if (this.m_tutorial != null && this.m_tutorial.NoforceClick && this.Exculsive)
		{
			if (this.m_spriteClickEventHandler != null)
			{
				this.m_spriteClickEventHandler(this);
				if (this.m_operation != null)
				{
					this.m_operation.FindRecordID(button.transform);
				}
			}
			this.m_tutorial.OnTutorialClicked();
			this.Exculsive = false;
		}
		else if (this.m_tutorial == null || !this.m_tutorial.Exculsive)
		{
			if (this.m_spriteClickEventHandler != null)
			{
				this.m_spriteClickEventHandler(this);
				if (this.m_operation != null)
				{
					this.m_operation.FindRecordID(button.transform);
				}
			}
		}
		else if (this.m_tutorial.Exculsive && this.Exculsive)
		{
			if (this.m_spriteClickEventHandler != null)
			{
				this.m_spriteClickEventHandler(this);
				if (this.m_operation != null)
				{
					this.m_operation.FindRecordID(button.transform);
				}
			}
			this.m_tutorial.OnTutorialClicked();
			this.Exculsive = false;
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

	public SpriteClickEventHandler GetSpriteClickHandler()
	{
		return this.m_spriteClickEventHandler;
	}

	public SpritePressEventHandler GetSpritePressHandler()
	{
		return this.m_spritePressEventHandler;
	}

	protected override void OnPress(bool isPressed)
	{
		if (!this.m_bEnabled)
		{
			return;
		}
		if (this.m_spritePressEventHandler != null)
		{
			this.m_spritePressEventHandler(this, isPressed);
		}
	}

	protected override void OnDrag(Vector2 delta)
	{
		if (!this.m_bEnabled)
		{
			return;
		}
		if (this.m_spriteDragEventHandler != null && this.m_invalidDrag)
		{
			this.m_spriteDragEventHandler(delta);
		}
	}

	protected void OnDragOut(GameObject go)
	{
		this.m_invalidDrag = false;
	}

	protected void OnDragOver(GameObject go)
	{
		this.m_invalidDrag = true;
	}

	public void SetFillAmount(float val)
	{
		this.m_uiSprite.fillAmount = val;
	}

	public void SetFlipHorizontal(bool bValue)
	{
		if (bValue)
		{
			this.m_uiSprite.flip = UISprite.Flip.Horizontally;
		}
		else
		{
			this.m_uiSprite.flip = UISprite.Flip.Nothing;
		}
	}

	public void SetFlipVertical(bool bValue)
	{
		if (bValue)
		{
			this.m_uiSprite.flip = UISprite.Flip.Vertically;
		}
		else
		{
			this.m_uiSprite.flip = UISprite.Flip.Nothing;
		}
	}

	public void ResetAnimationAndPlay()
	{
		this.m_Animation = base.GetComponent<UISpriteAnimation>();
		if (this.m_Animation == null)
		{
			return;
		}
		base.gameObject.SetActive(true);
		this.m_Animation.Reset();
		this.m_Animation.LastLoopFinishTime = RealTime.time;
	}

	public void UpdateAnchors()
	{
		this.m_uiSprite.UpdateAnchors();
	}

	public bool IsEnabled()
	{
		return this.m_bEnabled;
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

	public IXUIPanel GetPanel()
	{
		return XUIPanel.GetPanel(this.m_uiSprite.panel);
	}

	virtual Transform get_transform()
	{
		return base.transform;
	}
}
