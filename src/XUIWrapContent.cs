using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XUIWrapContent : XUIObject, IXUIWrapContent, IXUIObject
{
	private UIWrapContent m_uiWrapContent;

	private WrapItemUpdateEventHandler updateHandler;

	private WrapItemInitEventHandler initHandler;

	private XUIPool m_ItemPool = new XUIPool(null);

	public GameObject Tpl;

	public bool enableBounds
	{
		get
		{
			return this.m_uiWrapContent.bBounds;
		}
		set
		{
			this.m_uiWrapContent.bBounds = value;
		}
	}

	public Vector2 itemSize
	{
		get
		{
			return this.m_uiWrapContent.itemSize;
		}
		set
		{
			this.m_uiWrapContent.itemSize = value;
		}
	}

	public int widthDimension
	{
		get
		{
			return this.m_uiWrapContent.WidthDimension;
		}
		set
		{
			this.m_uiWrapContent.WidthDimension = value;
		}
	}

	public int heightDimensionMax
	{
		get
		{
			return this.m_uiWrapContent.HeightDimemsionMax;
		}
	}

	public int maxItemCount
	{
		get
		{
			return (this.m_uiWrapContent.HeightDimemsionMax + 2) * this.m_uiWrapContent.WidthDimension;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiWrapContent = base.GetComponent<UIWrapContent>();
		if (null == this.m_uiWrapContent)
		{
			Debug.LogError("null == m_uiWrapContent");
		}
		this.m_uiWrapContent.updateHandler = new WrapContentItemUpdateEventHandler(this.OnItemUpdate);
		if (this.Tpl == null)
		{
			Debug.LogError("Tpl == null");
		}
		if (!this.m_uiWrapContent.Init())
		{
			Debug.LogError("m_uiWrapContent.Init Failed");
		}
	}

	protected override void OnStart()
	{
		base.OnStart();
		if (!this.m_ItemPool.IsValid)
		{
			this.m_ItemPool.SetupPool(base.gameObject, this.Tpl, (uint)this.maxItemCount, false);
		}
	}

	protected void _InitContent(int count, bool fadeIn = false)
	{
		int num = Mathf.Min(count, this.maxItemCount);
		if (!this.m_ItemPool.IsValid)
		{
			this.m_ItemPool.SetupPool(base.gameObject, this.Tpl, (uint)this.maxItemCount, false);
		}
		if (fadeIn || num != this.m_ItemPool.ActiveCount)
		{
			BetterList<Transform> itemList = this.m_uiWrapContent.ItemList;
			itemList.Clear();
			if (fadeIn)
			{
				this.m_ItemPool.ReturnAll(false);
			}
			else
			{
				this.m_ItemPool.FakeReturnAll();
			}
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(fadeIn);
				itemList.Add(gameObject.transform);
				this.OnItemInit(gameObject.transform, i);
			}
			if (!fadeIn)
			{
				this.m_ItemPool.ActualReturnAll(false);
			}
			this.m_uiWrapContent.SetChildPositionOffset(0, true);
		}
	}

	private int _GetRowCount(int count, int columnCount)
	{
		if (count <= 0)
		{
			return 0;
		}
		return (count - 1) / columnCount + 1;
	}

	public void SetContentCount(int num, bool fadeIn = false)
	{
		if (this.m_uiWrapContent.WidthDimension != 1)
		{
			num = this._GetRowCount(num, this.m_uiWrapContent.WidthDimension) * this.m_uiWrapContent.WidthDimension;
		}
		this.m_uiWrapContent.SetContentCount(num);
		this._InitContent(num, fadeIn);
		this.m_uiWrapContent.AdjustContent();
	}

	private void OnItemUpdate(Transform item, int index)
	{
		if (this.updateHandler != null)
		{
			this.updateHandler(item, index);
		}
	}

	private void OnItemInit(Transform item, int index)
	{
		if (this.initHandler != null)
		{
			this.initHandler(item, index);
		}
	}

	public void RegisterItemUpdateEventHandler(WrapItemUpdateEventHandler eventHandler)
	{
		this.updateHandler = eventHandler;
	}

	public void RegisterItemInitEventHandler(WrapItemInitEventHandler eventHandler)
	{
		this.initHandler = eventHandler;
	}

	public void ResetPosition()
	{
		this.SetOffset(0);
	}

	public void SetOffset(int offset)
	{
		this.m_uiWrapContent.SetChildPositionOffset(offset, true);
		this.m_uiWrapContent.WrapContent();
	}

	public void InitContent()
	{
		this.m_uiWrapContent.Init();
	}

	public void RefreshAllVisibleContents()
	{
		this.m_uiWrapContent.RefreshAllChildrenContent();
	}

	public void GetActiveList(List<GameObject> ret)
	{
		this.m_ItemPool.GetActiveList(ret);
	}
}
