using System;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

public class XUITexture : XUIObject, IXUIObject, IXUITexture
{
	private IXTutorial m_tutorial;

	private UITexture m_uiTexture;

	private TextureClickEventHandler m_textureClickEventHandler;

	private IXOperationRecord m_operation;

	public float CustomClickCD = -1f;

	public int CustomClickCDGroup;

	public string TexturePath = string.Empty;

	public string HalfTexPath = string.Empty;

	private XUICD m_CD = new XUICD();

	public int spriteWidth
	{
		get
		{
			return this.m_uiTexture.width;
		}
		set
		{
			this.m_uiTexture.width = value;
		}
	}

	public int spriteHeight
	{
		get
		{
			return this.m_uiTexture.height;
		}
		set
		{
			this.m_uiTexture.height = value;
		}
	}

	public int spriteDepth
	{
		get
		{
			return this.m_uiTexture.depth;
		}
		set
		{
			this.m_uiTexture.depth = value;
		}
	}

	public int aspectRatioSource
	{
		get
		{
			return (int)this.m_uiTexture.keepAspectRatio;
		}
		set
		{
			this.m_uiTexture.keepAspectRatio = (UIWidget.AspectRatioSource)value;
		}
	}

	public void SetTexture(Texture texture)
	{
		if (null != this.m_uiTexture && !this.m_uiTexture.Equals(null))
		{
			this.m_uiTexture.mainTexture = texture;
		}
	}

	public Texture GetTexture()
	{
		return this.m_uiTexture.mainTexture;
	}

	public void SetUVRect(Rect rect)
	{
		this.m_uiTexture.uvRect = rect;
	}

	public void SetEnabled(bool bEnabled)
	{
		if (bEnabled)
		{
			this.m_uiTexture.color = Color.white;
		}
		else
		{
			this.m_uiTexture.color = new Color(0f, 0f, 0f, 1f);
		}
	}

	public void SetAlpha(float alpha)
	{
		this.m_uiTexture.alpha = alpha;
	}

	public void MakePixelPerfect()
	{
		this.m_uiTexture.MakePixelPerfect();
	}

	public void RegisterLabelClickEventHandler(TextureClickEventHandler eventHandler)
	{
		UIEventListener.Get(base.gameObject).onClick = new UIEventListener.VoidDelegate(this.OnTextureClick);
		this.m_textureClickEventHandler = eventHandler;
	}

	private void OnTextureClick(GameObject button)
	{
		if (this.m_CD.IsInCD())
		{
			return;
		}
		if (this.m_tutorial != null && this.m_tutorial.NoforceClick && this.Exculsive)
		{
			if (this.m_textureClickEventHandler != null)
			{
				this.m_textureClickEventHandler(this);
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
			if (this.m_textureClickEventHandler != null)
			{
				this.m_textureClickEventHandler(this);
				if (this.m_operation != null)
				{
					this.m_operation.FindRecordID(button.transform);
				}
			}
		}
		else if (this.m_tutorial.Exculsive && this.Exculsive)
		{
			if (this.m_textureClickEventHandler != null)
			{
				this.m_textureClickEventHandler(this);
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
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiTexture = base.GetComponent<UITexture>();
		this.m_tutorial = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXTutorial>(XSingleton<XCommon>.singleton.XHash("XTutorial"));
		this.m_operation = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXOperationRecord>(XSingleton<XCommon>.singleton.XHash("XOperationRecord"));
		if (!string.IsNullOrEmpty(this.TexturePath))
		{
			IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
			Texture sharedResource;
			if (!string.IsNullOrEmpty(this.HalfTexPath) && xPlatform.IsUIHalfResolution())
			{
				sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture>("atlas/UI/" + this.HalfTexPath, ".png", true);
			}
			else
			{
				sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture>("atlas/UI/" + this.TexturePath, ".png", true);
			}
			this.SetTexture(sharedResource);
		}
		if (null == this.m_uiTexture)
		{
			Debug.LogError("null == m_uiTexture");
		}
		this.m_CD.SetClickCD(this.CustomClickCDGroup, this.CustomClickCD);
	}

	public TextureClickEventHandler GetTextureClickHandler()
	{
		return this.m_textureClickEventHandler;
	}

	public void CloseScrollView()
	{
		UIDragScrollView component = base.GetComponent<UIDragScrollView>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void SetClickCD(float cd)
	{
		this.CustomClickCD = cd;
		this.m_CD.SetClickCD(this.CustomClickCDGroup, this.CustomClickCD);
	}
}
