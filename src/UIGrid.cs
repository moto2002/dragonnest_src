using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Grid")]
public class UIGrid : UIWidgetContainer
{
	public enum Arrangement
	{
		Horizontal,
		Vertical
	}

	public enum Sorting
	{
		None,
		Alphabetic,
		Horizontal,
		Vertical,
		Custom
	}

	public delegate void OnReposition();

	public UIGrid.Arrangement arrangement;

	public UIGrid.Sorting sorting;

	public UIWidget.Pivot pivot;

	public bool reverse;

	public int maxPerLine;

	public float cellWidth = 200f;

	public float cellHeight = 200f;

	public bool animateSmoothly;

	public float animateSmoothlySpeed = 30f;

	public bool hideInactive = true;

	public bool keepWithinPanel;

	public UIGrid.OnReposition onReposition;

	public BetterList<Transform>.CompareFunc onCustomSort;

	[HideInInspector, SerializeField]
	private bool sorted;

	protected bool mReposition;

	protected UIPanel mPanel;

	protected bool mInitDone;

	private BetterList<Transform> tmplist = new BetterList<Transform>();

	public bool repositionNow
	{
		set
		{
			if (value)
			{
				this.mReposition = true;
				base.enabled = true;
			}
		}
	}

	public UIPanel panel
	{
		get
		{
			return this.mPanel;
		}
	}

	public BetterList<Transform> GetChildList()
	{
		this.tmplist.Clear();
		Transform transform = base.transform;
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (!this.hideInactive || (child && NGUITools.GetActive(child.gameObject)))
			{
				this.tmplist.Add(child);
			}
		}
		return this.tmplist;
	}

	public Transform GetChild(int index)
	{
		BetterList<Transform> childList = this.GetChildList();
		return (index >= childList.size) ? null : childList[index];
	}

	public void AddChild(Transform trans)
	{
		this.AddChild(trans, true);
	}

	public void AddChild(Transform trans, bool sort)
	{
		if (trans != null)
		{
			BetterList<Transform> childList = this.GetChildList();
			childList.Add(trans);
			this.ResetPosition(childList);
		}
	}

	public void AddChild(Transform trans, int index)
	{
		if (trans != null)
		{
			if (this.sorting != UIGrid.Sorting.None)
			{
				Debug.LogWarning("The Grid has sorting enabled, so AddChild at index may not work as expected.", this);
			}
			BetterList<Transform> childList = this.GetChildList();
			childList.Insert(index, trans);
			this.ResetPosition(childList);
		}
	}

	public Transform RemoveChild(int index)
	{
		BetterList<Transform> childList = this.GetChildList();
		if (index < childList.size)
		{
			Transform result = childList[index];
			childList.RemoveAt(index);
			this.ResetPosition(childList);
			return result;
		}
		return null;
	}

	public bool RemoveChild(Transform t)
	{
		BetterList<Transform> childList = this.GetChildList();
		if (childList.Remove(t))
		{
			this.ResetPosition(childList);
			return true;
		}
		return false;
	}

	protected virtual void Init()
	{
		this.mInitDone = true;
		this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
	}

	protected virtual void Start()
	{
		if (!this.mInitDone)
		{
			this.Init();
		}
		bool flag = this.animateSmoothly;
		this.animateSmoothly = false;
		this.Reposition();
		this.animateSmoothly = flag;
		base.enabled = false;
	}

	protected virtual void Update()
	{
		if (this.mReposition)
		{
			this.Reposition();
		}
		base.enabled = false;
	}

	public static int SortByName(Transform a, Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	public static int SortHorizontal(Transform a, Transform b)
	{
		return a.localPosition.x.CompareTo(b.localPosition.x);
	}

	public static int SortVertical(Transform a, Transform b)
	{
		return b.localPosition.y.CompareTo(a.localPosition.y);
	}

	protected virtual void Sort(BetterList<Transform> list)
	{
	}

	[ContextMenu("Execute")]
	public virtual void Reposition()
	{
		if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive(this))
		{
			this.mReposition = true;
			return;
		}
		if (this.sorted)
		{
			this.sorted = false;
			if (this.sorting == UIGrid.Sorting.None)
			{
				this.sorting = UIGrid.Sorting.Alphabetic;
			}
			NGUITools.SetDirty(this);
		}
		if (!this.mInitDone)
		{
			this.Init();
		}
		BetterList<Transform> childList = this.GetChildList();
		if (this.sorting != UIGrid.Sorting.None)
		{
			if (this.sorting == UIGrid.Sorting.Alphabetic)
			{
				childList.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortByName));
			}
			else if (this.sorting == UIGrid.Sorting.Horizontal)
			{
				childList.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortHorizontal));
			}
			else if (this.sorting == UIGrid.Sorting.Vertical)
			{
				childList.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortVertical));
			}
			else if (this.onCustomSort != null)
			{
				childList.Sort(this.onCustomSort);
			}
			else
			{
				this.Sort(childList);
			}
		}
		this.ResetPosition(childList);
		if (this.keepWithinPanel)
		{
			this.ConstrainWithinPanel();
		}
		if (this.onReposition != null)
		{
			this.onReposition();
		}
	}

	public void ConstrainWithinPanel()
	{
		if (this.mPanel != null)
		{
			this.mPanel.ConstrainTargetToBounds(base.transform, true);
		}
	}

	protected void ResetPosition(BetterList<Transform> list)
	{
		this.mReposition = false;
		int i = 0;
		int size = list.size;
		while (i < size)
		{
			list[i].parent = null;
			i++;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Transform transform = base.transform;
		int j = 0;
		int size2 = list.size;
		while (j < size2)
		{
			Transform transform2 = list[j];
			transform2.parent = transform;
			float z = transform2.localPosition.z;
			int num5 = (!this.reverse) ? 1 : -1;
			Vector3 vector = (this.arrangement != UIGrid.Arrangement.Horizontal) ? new Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num * (float)num5, z) : new Vector3(this.cellWidth * (float)num * (float)num5, -this.cellHeight * (float)num2, z);
			if (this.animateSmoothly && Application.isPlaying)
			{
				SpringPosition.Begin(transform2.gameObject, vector, this.animateSmoothlySpeed).updateScrollView = true;
			}
			else
			{
				transform2.localPosition = vector;
			}
			num3 = Mathf.Max(num3, num);
			num4 = Mathf.Max(num4, num2);
			if (++num >= this.maxPerLine && this.maxPerLine > 0)
			{
				num = 0;
				num2++;
			}
			j++;
		}
		this.RePivot(num3, num4);
	}

	protected void RePivot(int maxX, int maxY)
	{
		if (this.pivot != UIWidget.Pivot.TopLeft)
		{
			Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.pivot);
			float num;
			float num2;
			if (this.arrangement == UIGrid.Arrangement.Horizontal)
			{
				num = Mathf.Lerp(0f, (float)maxX * this.cellWidth, pivotOffset.x);
				num2 = Mathf.Lerp((float)(-(float)maxY) * this.cellHeight, 0f, pivotOffset.y);
			}
			else
			{
				num = Mathf.Lerp(0f, (float)maxY * this.cellWidth, pivotOffset.x);
				num2 = Mathf.Lerp((float)(-(float)maxX) * this.cellHeight, 0f, pivotOffset.y);
			}
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				SpringPosition component = child.GetComponent<SpringPosition>();
				if (component != null)
				{
					SpringPosition expr_C7_cp_0 = component;
					expr_C7_cp_0.target.x = expr_C7_cp_0.target.x - num;
					SpringPosition expr_DB_cp_0 = component;
					expr_DB_cp_0.target.y = expr_DB_cp_0.target.y - num2;
				}
				else
				{
					Vector3 localPosition = child.localPosition;
					localPosition.x -= num;
					localPosition.y -= num2;
					child.localPosition = localPosition;
				}
			}
		}
	}

	public void CloseList()
	{
		BetterList<Transform> childList = this.GetChildList();
		if (this.sorting != UIGrid.Sorting.None)
		{
			if (this.sorting == UIGrid.Sorting.Alphabetic)
			{
				childList.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortByName));
			}
			else if (this.sorting == UIGrid.Sorting.Horizontal)
			{
				childList.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortHorizontal));
			}
			else if (this.sorting == UIGrid.Sorting.Vertical)
			{
				childList.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortVertical));
			}
			else if (this.onCustomSort != null)
			{
				childList.Sort(this.onCustomSort);
			}
			else
			{
				this.Sort(childList);
			}
		}
		int i = 0;
		int size = childList.size;
		while (i < size)
		{
			childList[i].parent = null;
			i++;
		}
		Transform transform = base.transform;
		int j = 0;
		int size2 = childList.size;
		while (j < size2)
		{
			Transform transform2 = childList[j];
			transform2.parent = transform;
			float z = transform2.localPosition.z;
			int num = (!this.reverse) ? 1 : -1;
			Vector3 pos = (this.arrangement != UIGrid.Arrangement.Horizontal) ? new Vector3(0f, this.cellHeight * -1f, z) : new Vector3(this.cellWidth * -1f * (float)num, 0f, z);
			SpringPosition springPosition = SpringPosition.Begin(transform2.gameObject, pos, 30f);
			springPosition.updateScrollView = true;
			springPosition.onFinished = new SpringPosition.OnFinished(this.OnCloseFinish);
			j++;
		}
	}

	protected void OnCloseFinish(GameObject go)
	{
		go.SetActive(false);
	}
}
