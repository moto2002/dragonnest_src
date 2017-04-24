using System;
using UILib;
using UnityEngine;

public class XUIDragDropItem : XUIObject, IXUIObject, IXUIDragDropItem
{
	private UIPanel m_panel;

	public UIDragDropItem m_dragdrop;

	public OnDropReleaseEventHandler m_OnFinishHandler;

	public OnDropStartEventHandler m_OnStartHandler;

	private void Awake()
	{
		this.m_dragdrop = base.GetComponent<UIDragDropItem>();
		if (null == this.m_dragdrop)
		{
			Debug.LogError("null == m_dragdrop");
		}
	}

	public void SetCloneOnDrag(bool cloneOnDrag)
	{
		this.m_dragdrop.cloneOnDrag = cloneOnDrag;
	}

	public void SetRestriction(int restriction)
	{
		this.m_dragdrop.restriction = (UIDragDropItem.Restriction)((int)Enum.ToObject(typeof(UIDragDropItem.Restriction), restriction));
	}

	public void SetActive(bool active)
	{
		this.m_dragdrop.enabled = active;
		base.enabled = active;
	}

	public void SetParent(Transform parent, bool addPanel = false, int depth = 0)
	{
		base.transform.parent = parent;
		this.m_panel = base.gameObject.GetComponent<UIPanel>();
		if (addPanel)
		{
			this.m_panel = base.gameObject.GetComponent<UIPanel>();
			if (this.m_panel == null)
			{
				this.m_panel = base.gameObject.AddComponent<UIPanel>();
			}
			this.m_panel.depth = depth;
			this.m_panel.enabled = true;
		}
		else if (this.m_panel != null)
		{
			this.m_panel.enabled = false;
		}
	}

	public void RegisterOnFinishEventHandler(OnDropReleaseEventHandler eventHandler)
	{
		this.m_OnFinishHandler = eventHandler;
		this.m_dragdrop.onFinished.Clear();
		EventDelegate.Add(this.m_dragdrop.onFinished, new EventDelegate.Callback(this.OnFinish));
	}

	public void RegisterOnStartEventHandler(OnDropStartEventHandler eventHandler)
	{
		this.m_OnStartHandler = eventHandler;
		this.m_dragdrop.onStart.Clear();
		EventDelegate.Add(this.m_dragdrop.onStart, new EventDelegate.Callback(this.OnStart));
	}

	public OnDropStartEventHandler GetStartEventHandler()
	{
		return this.m_OnStartHandler;
	}

	public OnDropReleaseEventHandler GetReleaseEventHandler()
	{
		return this.m_OnFinishHandler;
	}

	private void OnFinish()
	{
		if (this.m_OnFinishHandler != null)
		{
			this.m_OnFinishHandler(base.gameObject, UICamera.hoveredObject);
		}
	}

	private new void OnStart()
	{
		if (this.m_OnStartHandler != null)
		{
			this.m_OnStartHandler(base.gameObject);
		}
	}
}
