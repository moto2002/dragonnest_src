using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Table")]
public class UITable : UIWidgetContainer
{
	public enum Direction
	{
		Down,
		Up
	}

	public enum Sorting
	{
		None,
		Alphabetic,
		Horizontal,
		Vertical,
		Custom
	}

	public delegate Bounds CalculateBounds(Transform trans, bool considerInactive);

	public delegate void OnReposition();

	public int columns;

	public UITable.Direction direction;

	public UITable.Sorting sorting;

	public bool hideInactive = true;

	public bool keepWithinPanel;

	public Vector2 padding = Vector2.zero;

	public UITable.OnReposition onReposition;

	protected UIPanel mPanel;

	protected bool mInitDone;

	protected bool mReposition;

	protected List<Transform> mChildren = new List<Transform>();

	[HideInInspector, SerializeField]
	private bool sorted;

	private UIScrollView sv;

	private UITable.CalculateBounds calculateBoundsCb;

	private List<UIWidget> widgets = new List<UIWidget>();

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

	public List<Transform> children
	{
		get
		{
			if (this.mChildren.Count == 0)
			{
				Transform transform = base.transform;
				this.mChildren.Clear();
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform child = transform.GetChild(i);
					if (child && child.gameObject && (!this.hideInactive || NGUITools.GetActive(child.gameObject)))
					{
						this.mChildren.Add(child);
					}
				}
				if (this.sorting != UITable.Sorting.None || this.sorted)
				{
					if (this.sorting == UITable.Sorting.Alphabetic)
					{
						this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortByName));
					}
					else if (this.sorting == UITable.Sorting.Horizontal)
					{
						this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
					}
					else if (this.sorting == UITable.Sorting.Vertical)
					{
						this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortVertical));
					}
					else
					{
						this.Sort(this.mChildren);
					}
				}
			}
			return this.mChildren;
		}
	}

	protected virtual void Sort(List<Transform> list)
	{
		list.Sort(new Comparison<Transform>(UIGrid.SortByName));
	}

	protected void RepositionVariableSize(List<Transform> children, UITable.CalculateBounds calculateBounds = null)
	{
		if (calculateBounds == null)
		{
			calculateBounds = new UITable.CalculateBounds(NGUIMath.CalculateRelativeWidgetBounds);
		}
		float num = 0f;
		float num2 = 0f;
		int num3 = (this.columns <= 0) ? 1 : (children.Count / this.columns + 1);
		int num4 = (this.columns <= 0) ? children.Count : this.columns;
		Bounds[,] array = new Bounds[num3, num4];
		Bounds[] array2 = new Bounds[num4];
		Bounds[] array3 = new Bounds[num3];
		int num5 = 0;
		int num6 = 0;
		int i = 0;
		int count = children.Count;
		while (i < count)
		{
			Transform transform = children[i];
			Bounds bounds = calculateBounds(transform, !this.hideInactive);
			Vector3 localScale = transform.localScale;
			bounds.min = Vector3.Scale(bounds.min, localScale);
			bounds.max = Vector3.Scale(bounds.max, localScale);
			array[num6, num5] = bounds;
			array2[num5].Encapsulate(bounds);
			array3[num6].Encapsulate(bounds);
			if (++num5 >= this.columns && this.columns > 0)
			{
				num5 = 0;
				num6++;
			}
			i++;
		}
		num5 = 0;
		num6 = 0;
		int j = 0;
		int count2 = children.Count;
		while (j < count2)
		{
			Transform transform2 = children[j];
			Bounds bounds2 = array[num6, num5];
			Bounds bounds3 = array2[num5];
			Bounds bounds4 = array3[num6];
			Vector3 localPosition = transform2.localPosition;
			localPosition.x = num + bounds2.extents.x - bounds2.center.x;
			localPosition.x += bounds2.min.x - bounds3.min.x + this.padding.x;
			if (this.direction == UITable.Direction.Down)
			{
				localPosition.y = -num2 - bounds2.extents.y - bounds2.center.y;
				localPosition.y += (bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y) * 0.5f - this.padding.y;
			}
			else
			{
				localPosition.y = num2 + (bounds2.extents.y - bounds2.center.y);
				localPosition.y -= (bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y) * 0.5f - this.padding.y;
			}
			num += bounds3.max.x - bounds3.min.x + this.padding.x * 2f;
			transform2.localPosition = localPosition;
			if (++num5 >= this.columns && this.columns > 0)
			{
				num5 = 0;
				num6++;
				num = 0f;
				num2 += bounds4.size.y + this.padding.y * 2f;
			}
			j++;
		}
	}

	[ContextMenu("Execute")]
	public virtual void Reposition()
	{
		if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive(this))
		{
			this.mReposition = true;
			return;
		}
		if (!this.mInitDone)
		{
			this.Init();
		}
		this.mReposition = false;
		Transform transform = base.transform;
		this.mChildren.Clear();
		List<Transform> children = this.children;
		if (children.Count > 0)
		{
			this.RepositionVariableSize(children, null);
		}
		if (this.keepWithinPanel && this.mPanel != null)
		{
			this.mPanel.ConstrainTargetToBounds(transform, true);
			if (this.sv != null)
			{
				this.sv.UpdateScrollbars(true);
			}
		}
		if (this.onReposition != null)
		{
			this.onReposition();
		}
	}

	protected virtual void Start()
	{
		this.calculateBoundsCb = new UITable.CalculateBounds(this._CalculateBoundsOnlyOneLevel);
		this.Init();
		this.sv = this.mPanel.GetComponent<UIScrollView>();
		this.Reposition();
		base.enabled = false;
	}

	protected virtual void Init()
	{
		this.mInitDone = true;
		this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
	}

	protected virtual void LateUpdate()
	{
		if (this.mReposition)
		{
			this.Reposition();
		}
		base.enabled = false;
	}

	public void RepositionOnlyOneLevel()
	{
		if (!this.mInitDone)
		{
			this.Init();
		}
		this.mReposition = false;
		Transform transform = base.transform;
		this.mChildren.Clear();
		List<Transform> children = this.children;
		if (children.Count > 0)
		{
			this.RepositionVariableSize(children, this.calculateBoundsCb);
		}
	}

	protected Bounds _CalculateBoundsOnlyOneLevel(Transform trans, bool considerInactive)
	{
		if (trans != null)
		{
			this.widgets.Clear();
			int childCount = trans.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = trans.GetChild(i);
				if (considerInactive || child.gameObject.activeSelf)
				{
					UIWidget component = child.GetComponent<UIWidget>();
					if (component != null)
					{
						this.widgets.Add(component);
					}
				}
			}
			if (this.widgets.Count > 0)
			{
				Vector3 vector = new Vector3(3.40282347E+38f, 3.40282347E+38f, 3.40282347E+38f);
				Vector3 vector2 = new Vector3(-3.40282347E+38f, -3.40282347E+38f, -3.40282347E+38f);
				Matrix4x4 worldToLocalMatrix = trans.worldToLocalMatrix;
				bool flag = false;
				int j = 0;
				int count = this.widgets.Count;
				while (j < count)
				{
					UIWidget uIWidget = this.widgets[j];
					if (considerInactive || uIWidget.enabled)
					{
						Vector3[] worldCorners = uIWidget.worldCorners;
						for (int k = 0; k < 4; k++)
						{
							Vector3 lhs = worldToLocalMatrix.MultiplyPoint3x4(worldCorners[k]);
							vector2 = Vector3.Max(lhs, vector2);
							vector = Vector3.Min(lhs, vector);
						}
						flag = true;
					}
					j++;
				}
				if (flag)
				{
					Bounds result = new Bounds(vector, Vector3.zero);
					result.Encapsulate(vector2);
					return result;
				}
			}
		}
		return new Bounds(Vector3.zero, Vector3.zero);
	}
}
