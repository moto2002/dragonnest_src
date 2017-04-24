using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using XUtliPoolLib;

public class LoopScrollView : MonoBehaviour, ILoopScrollView
{
	public enum ArrangeDirection
	{
		Left_to_Right,
		Right_to_Left,
		Up_to_Down,
		Down_to_Up
	}

	public LoopScrollView.ArrangeDirection arrangeDirection = LoopScrollView.ArrangeDirection.Up_to_Down;

	public GameObject itemPrefab;

	public List<LoopItemObject> itemsList;

	public List<LoopItemData> datasList;

	public UIScrollView scrollView;

	public GameObject itemParent;

	private LoopItemObject firstItem;

	private LoopItemObject lastItem;

	public Vector3 itemStartPos = Vector3.zero;

	public DelegateHandler OnItemInit;

	public float gapDis;

	private Vector3 m_TopLeft;

	private Vector3 m_BtmRight;

	private Action onDragFinish;

	public int m_maxViewCnt = 2;

	private bool mTop = true;

	private Queue<LoopItemObject> itemLoop = new Queue<LoopItemObject>();

	private bool activable
	{
		get
		{
			return this.gameobject.activeSelf;
		}
	}

	private bool isPivotLast
	{
		get
		{
			return this.lastItem != null && this.datasList != null && this.datasList.Count > 1 && this.lastItem.dataIndex == this.datasList.Count - 1;
		}
	}

	public GameObject gameobject
	{
		get
		{
			return base.gameObject;
		}
	}

	private void Awake()
	{
		if (this.itemPrefab == null || this.scrollView == null || this.itemParent == null)
		{
			UnityEngine.Debug.LogError("LoopScrollView.Awake not set value in inspector!");
		}
		if (this.m_maxViewCnt < 2)
		{
			UnityEngine.Debug.LogError("Make sure your view cnt more than 2!");
		}
		if (this.arrangeDirection == LoopScrollView.ArrangeDirection.Up_to_Down || this.arrangeDirection == LoopScrollView.ArrangeDirection.Down_to_Up)
		{
			this.scrollView.movement = UIScrollView.Movement.Vertical;
		}
		else
		{
			this.scrollView.movement = UIScrollView.Movement.Horizontal;
		}
		this.scrollView.onDragFinished = new UIScrollView.OnDragFinished(this.OnDragFinish);
	}

	private void Start()
	{
		UIPanel panel = this.scrollView.panel;
		Vector4 baseClipRegion = this.scrollView.panel.baseClipRegion;
		Vector3 localPosition = this.scrollView.transform.localPosition;
		localPosition = new Vector3(localPosition.x + panel.clipOffset.x + baseClipRegion.x, localPosition.y + panel.clipOffset.y + baseClipRegion.y, localPosition.z);
		Vector3 v = new Vector3(localPosition.x - baseClipRegion.z / 2f, localPosition.y + baseClipRegion.w / 2f, localPosition.z);
		Vector3 v2 = new Vector3(localPosition.x + baseClipRegion.z / 2f, localPosition.y - baseClipRegion.w / 2f, localPosition.z);
		this.m_TopLeft = this.scrollView.transform.parent.localToWorldMatrix.MultiplyPoint(v);
		this.m_BtmRight = this.scrollView.transform.parent.localToWorldMatrix.MultiplyPoint(v2);
	}

	private void OnDragFinish()
	{
		if (this.lastItem != null && this.IsScrollLast() && this.onDragFinish != null)
		{
			this.onDragFinish();
		}
	}

	private void FixedUpdate()
	{
		this.Validate();
	}

	public void Init(List<LoopItemData> datas, DelegateHandler onItemInitCallback, Action dragFinish, int pivot = 0)
	{
		this.mTop = (pivot == 0);
		this.onDragFinish = dragFinish;
		if (!this.IsEqual(datas))
		{
			if (this.IsAddNew(datas))
			{
				this.AddItem(datas[datas.Count - 1]);
			}
			else if (this.UpdateNewOne(datas))
			{
				this.UpdateItem(datas[datas.Count - 1]);
			}
			else
			{
				this.mTop = (pivot == 0);
				this.OnItemInit = onItemInitCallback;
				this.Resetloop();
				this.datasList = datas;
				this.Validate();
				this.ResetScroll();
				int num = Mathf.Min(this.m_maxViewCnt, this.datasList.Count);
				for (int i = 0; i < num; i++)
				{
					this.Validate();
				}
			}
		}
		base.StopCoroutine(this.YieldScroll());
		if (this.gameobject.activeInHierarchy)
		{
			base.StartCoroutine(this.YieldScroll());
		}
	}

	[DebuggerHidden]
	private IEnumerator YieldScroll()
	{
		LoopScrollView.<YieldScroll>c__Iterator15 <YieldScroll>c__Iterator = new LoopScrollView.<YieldScroll>c__Iterator15();
		<YieldScroll>c__Iterator.<>f__this = this;
		return <YieldScroll>c__Iterator;
	}

	[ContextMenu("top")]
	private void TestTop()
	{
		this.mTop = true;
		this.ResetScroll();
	}

	[ContextMenu("bottom")]
	private void TestBtm()
	{
		this.mTop = false;
		this.ResetScroll();
	}

	private void Resetloop()
	{
		if (this.itemsList != null)
		{
			for (int i = 0; i < this.itemsList.Count; i++)
			{
				this.PutItemToLoop(this.itemsList[i]);
			}
			this.itemsList.Clear();
		}
		if (this.datasList != null)
		{
			this.datasList.Clear();
		}
	}

	public void SetPivot(bool istop)
	{
	}

	private void OnDisable()
	{
		base.StopCoroutine(this.YieldScroll());
	}

	public GameObject GetTpl()
	{
		return this.itemPrefab;
	}

	private bool IsAllInvisible()
	{
		bool result = true;
		for (int i = 0; i < this.itemsList.Count; i++)
		{
			if (this.IsVisible(this.itemsList[i]))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private void Validate()
	{
		if (this.datasList == null || this.datasList.Count == 0)
		{
			return;
		}
		if (this.itemsList == null || this.itemsList.Count == 0)
		{
			this.itemsList = new List<LoopItemObject>();
			LoopItemObject itemFromLoop = this.GetItemFromLoop();
			if (this.mTop)
			{
				this.InitItem(itemFromLoop, 0, this.datasList[0]);
			}
			else
			{
				this.InitItem(itemFromLoop, this.datasList.Count - 1, this.datasList[this.datasList.Count - 1]);
			}
			this.firstItem = (this.lastItem = itemFromLoop);
			this.itemsList.Add(itemFromLoop);
			this.ResetScroll();
		}
		if (this.IsAllInvisible())
		{
			return;
		}
		if (this.IsVisible(this.firstItem))
		{
			if (this.firstItem.dataIndex > 0)
			{
				LoopItemObject itemFromLoop2 = this.GetItemFromLoop();
				int num = this.firstItem.dataIndex - 1;
				this.AddToFront(this.firstItem, itemFromLoop2, num, this.datasList[num]);
				this.firstItem = itemFromLoop2;
				this.itemsList.Insert(0, itemFromLoop2);
			}
		}
		else if (this.itemsList.Count > this.m_maxViewCnt && !this.IsVisible(this.itemsList[0]) && !this.IsVisible(this.itemsList[1]))
		{
			this.itemsList.Remove(this.firstItem);
			this.PutItemToLoop(this.firstItem);
			this.firstItem = this.itemsList[0];
		}
		if (this.IsVisible(this.lastItem))
		{
			if (this.lastItem.dataIndex < this.datasList.Count - 1)
			{
				LoopItemObject itemFromLoop3 = this.GetItemFromLoop();
				int num2 = this.lastItem.dataIndex + 1;
				this.AddToBack(this.lastItem, itemFromLoop3, num2, this.datasList[num2]);
				this.lastItem = itemFromLoop3;
				this.itemsList.Add(itemFromLoop3);
			}
		}
		else if (this.itemsList.Count > this.m_maxViewCnt && !this.IsVisible(this.itemsList[this.itemsList.Count - 1]) && !this.IsVisible(this.itemsList[this.itemsList.Count - 2]))
		{
			this.itemsList.Remove(this.lastItem);
			this.PutItemToLoop(this.lastItem);
			this.lastItem = this.itemsList[this.itemsList.Count - 1];
		}
	}

	private bool IsEqual(List<LoopItemData> datas)
	{
		bool result = true;
		if (datas != null && this.datasList != null && datas.Count == this.datasList.Count)
		{
			for (int i = 0; i < this.datasList.Count; i++)
			{
				if (this.datasList[i].LoopID != datas[i].LoopID)
				{
					result = false;
					break;
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private bool UpdateNewOne(List<LoopItemData> datas)
	{
		bool result = true;
		if (datas != null && this.isPivotLast && datas.Count == this.datasList.Count)
		{
			int num = Mathf.Min(4, this.datasList.Count - 1);
			for (int i = 0; i < num; i++)
			{
				if (this.datasList[i + 1].LoopID != datas[i].LoopID)
				{
					result = false;
					break;
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private bool IsAddNew(List<LoopItemData> datas)
	{
		bool result = true;
		if (datas != null && this.isPivotLast && datas.Count - this.datasList.Count == 1)
		{
			int num = Mathf.Min(4, this.datasList.Count);
			for (int i = 0; i < num; i++)
			{
				if (this.datasList[i].LoopID != datas[i].LoopID)
				{
					result = false;
					break;
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	public void AddItem(LoopItemData data)
	{
		this.datasList.Add(data);
		LoopItemObject itemFromLoop = this.GetItemFromLoop();
		int num = this.datasList.Count - 1;
		this.AddToBack(this.lastItem, itemFromLoop, num, this.datasList[num]);
		this.lastItem = itemFromLoop;
		this.itemsList.Add(itemFromLoop);
	}

	public void UpdateItem(LoopItemData data)
	{
		if (this.datasList.Count > 0)
		{
			this.datasList.RemoveAt(0);
		}
		if (this.itemsList.Contains(this.firstItem))
		{
			this.itemsList.Remove(this.firstItem);
		}
		this.PutItemToLoop(this.firstItem);
		if (this.itemsList.Count > 0)
		{
			this.firstItem = this.itemsList[0];
		}
		this.AddItem(data);
	}

	public bool IsVisible(LoopItemObject obj)
	{
		return this.IsVisible(obj.widget.transform);
	}

	private bool IsVisible(Transform tran)
	{
		bool flag = tran.position.x >= this.m_TopLeft.x && tran.position.x <= this.m_BtmRight.x;
		bool flag2 = tran.position.y >= this.m_BtmRight.y && tran.position.y <= this.m_TopLeft.y;
		return flag && flag2;
	}

	public bool IsScrollLast()
	{
		return this.lastItem == null || !(this.lastItem.widget != null) || this.IsVisible(this.lastItem);
	}

	[ContextMenu("reset pos")]
	public void ResetScroll()
	{
		this.scrollView.ResetPosition((!this.mTop) ? 1f : 0f);
	}

	public void SetClipSize(Vector2 size)
	{
		Vector4 baseClipRegion = this.scrollView.panel.baseClipRegion;
		baseClipRegion.z = size.x;
		baseClipRegion.w = size.y;
		this.scrollView.panel.baseClipRegion = baseClipRegion;
	}

	public void SetDepth(int depth)
	{
		if (this.scrollView.panel != null)
		{
			this.scrollView.panel.depth = depth;
		}
	}

	public GameObject GetFirstItem()
	{
		return this.firstItem.GetObj();
	}

	public GameObject GetLastItem()
	{
		return this.lastItem.GetObj();
	}

	private LoopItemObject CreateItem()
	{
		GameObject gameObject = NGUITools.AddChild(this.itemParent, this.itemPrefab);
		UIWidget component = gameObject.GetComponent<UIWidget>();
		LoopItemObject loopItemObject = new LoopItemObject();
		loopItemObject.widget = component;
		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}
		return loopItemObject;
	}

	private void InitItem(LoopItemObject item, int dataIndex, LoopItemData data)
	{
		item.dataIndex = dataIndex;
		if (this.OnItemInit != null)
		{
			this.OnItemInit(item, data);
		}
		item.widget.transform.localPosition = this.itemStartPos;
	}

	private void AddToFront(LoopItemObject priorItem, LoopItemObject newItem, int newIndex, LoopItemData newData)
	{
		this.InitItem(newItem, newIndex, newData);
		if (this.scrollView.movement == UIScrollView.Movement.Vertical)
		{
			float num = (float)priorItem.widget.height * 0.5f + this.gapDis + (float)newItem.widget.height * 0.5f;
			if (this.arrangeDirection == LoopScrollView.ArrangeDirection.Down_to_Up)
			{
				num *= -1f;
			}
			newItem.widget.transform.localPosition = priorItem.widget.cachedTransform.localPosition + new Vector3(0f, num, 0f);
		}
		else
		{
			float num2 = (float)priorItem.widget.width * 0.5f + this.gapDis + (float)newItem.widget.width * 0.5f;
			if (this.arrangeDirection == LoopScrollView.ArrangeDirection.Right_to_Left)
			{
				num2 *= -1f;
			}
			newItem.widget.transform.localPosition = priorItem.widget.cachedTransform.localPosition - new Vector3(num2, 0f, 0f);
		}
	}

	private void AddToBack(LoopItemObject backItem, LoopItemObject newItem, int newIndex, LoopItemData newData)
	{
		this.InitItem(newItem, newIndex, newData);
		if (this.scrollView.movement == UIScrollView.Movement.Vertical)
		{
			float num = (float)backItem.widget.height * 0.5f + this.gapDis + (float)newItem.widget.height * 0.5f;
			if (this.arrangeDirection == LoopScrollView.ArrangeDirection.Down_to_Up)
			{
				num *= -1f;
			}
			newItem.widget.transform.localPosition = backItem.widget.cachedTransform.localPosition - new Vector3(0f, num, 0f);
		}
		else
		{
			float num2 = (float)backItem.widget.width * 0.5f + this.gapDis + (float)newItem.widget.width * 0.5f;
			if (this.arrangeDirection == LoopScrollView.ArrangeDirection.Right_to_Left)
			{
				num2 *= -1f;
			}
			newItem.widget.transform.localPosition = backItem.widget.cachedTransform.localPosition + new Vector3(num2, 0f, 0f);
		}
	}

	private void CheckBTM()
	{
		if (this.mTop && this.lastItem != null && this.lastItem.widget != null && this.arrangeDirection == LoopScrollView.ArrangeDirection.Up_to_Down && this.m_BtmRight.y > this.lastItem.widget.transform.position.y)
		{
			this.mTop = false;
			this.ResetScroll();
		}
	}

	private LoopItemObject GetItemFromLoop()
	{
		LoopItemObject loopItemObject;
		if (this.itemLoop.Count <= 0)
		{
			loopItemObject = this.CreateItem();
		}
		else
		{
			loopItemObject = this.itemLoop.Dequeue();
		}
		if (!loopItemObject.widget.gameObject.activeSelf)
		{
			loopItemObject.widget.gameObject.SetActive(true);
		}
		return loopItemObject;
	}

	private void PutItemToLoop(LoopItemObject item)
	{
		if (this.itemLoop.Count >= 3)
		{
			UnityEngine.Object.Destroy(item.widget.gameObject);
			return;
		}
		item.dataIndex = -1;
		item.widget.gameObject.SetActive(false);
		this.itemLoop.Enqueue(item);
	}
}
