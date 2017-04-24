using System;
using UILib;
using UnityEngine;

public abstract class XUIObjectBase : MonoBehaviour, IXUIObject
{
	private IXUIObject m_parent;

	private ulong m_id;

	private bool m_bExculsive;

	public virtual IXUIObject parent
	{
		get
		{
			return this.m_parent;
		}
		set
		{
			this.m_parent = value;
		}
	}

	public ulong ID
	{
		get
		{
			return this.m_id;
		}
		set
		{
			this.m_id = value;
		}
	}

	public bool Exculsive
	{
		get
		{
			return this.m_bExculsive;
		}
		set
		{
			this.m_bExculsive = value;
		}
	}

	public bool IsVisible()
	{
		return base.gameObject.activeInHierarchy;
	}

	public virtual void SetVisible(bool bVisible)
	{
		base.gameObject.SetActive(bVisible);
	}

	public virtual void OnFocus()
	{
		if (this.parent != null)
		{
			this.parent.OnFocus();
		}
	}

	public IXUIObject GetUIObject(string strName)
	{
		Transform transform = base.transform.FindChild(strName);
		if (null != transform)
		{
			return transform.GetComponent<XUIObjectBase>();
		}
		return null;
	}

	public virtual void Highlight(bool bTrue)
	{
	}

	protected virtual void OnPress(bool isPressed)
	{
		this.OnFocus();
	}

	protected virtual void OnDrag(Vector2 delta)
	{
		this.OnFocus();
	}

	public virtual void Init()
	{
	}

	protected virtual void OnAwake()
	{
	}

	protected virtual void OnStart()
	{
	}

	protected virtual void OnUpdate()
	{
	}

	private void Awake()
	{
		this.OnAwake();
	}

	private void Start()
	{
		this.OnStart();
	}

	GameObject IXUIObject.get_gameObject()
	{
		return base.gameObject;
	}
}
