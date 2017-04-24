using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Wrap Content")]
public class UIWrapContent : MonoBehaviour
{
	public Vector2 itemSize = new Vector2(100f, 100f);

	public bool cullContent = true;

	public int WidthDimension = 2;

	public bool bBounds = true;

	private float lowerBound;

	private float upperBound = 1600f;

	private float lowerBoundWithEpsilon;

	private float upperBoundWithEpsilon = 1600f;

	private int _ContentCount;

	public int HeightDimemsionMax = 10;

	public WrapContentItemUpdateEventHandler updateHandler;

	private Transform mTrans;

	private UIPanel mPanel;

	private UIScrollView mScroll;

	private UIWidget mPlaceHolder;

	private bool mHorizontal;

	private BetterList<Transform> mChildren = new BetterList<Transform>();

	public BetterList<Transform> ItemList
	{
		get
		{
			return this.mChildren;
		}
	}

	protected virtual void Start()
	{
	}

	protected virtual void OnMove(UIPanel panel)
	{
		this.WrapContent();
	}

	[ContextMenu("Sort Based on Scroll Movement")]
	public void SortBasedOnScrollMovement()
	{
		if (!this.CacheScrollView())
		{
			return;
		}
		this.mChildren.Clear();
		for (int i = 0; i < this.mTrans.childCount; i++)
		{
			this.mChildren.Add(this.mTrans.GetChild(i));
		}
		if (this.mHorizontal)
		{
			this.mChildren.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortHorizontal));
		}
		else
		{
			this.mChildren.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortVertical));
		}
		this.ResetChildPositions();
	}

	[ContextMenu("Sort Alphabetically")]
	public void SortAlphabetically()
	{
		if (!this.CacheScrollView())
		{
			return;
		}
		Vector3 localPosition = base.gameObject.transform.localPosition;
		if (this.mHorizontal)
		{
			localPosition.x = 0f;
		}
		else
		{
			localPosition.y = 0f;
		}
		base.gameObject.transform.localPosition = localPosition;
		this.mChildren.Clear();
		for (int i = 0; i < this.mTrans.childCount; i++)
		{
			this.mChildren.Add(this.mTrans.GetChild(i));
		}
		this.mChildren.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortByName));
		this.ResetChildPositions();
	}

	protected bool CacheScrollView()
	{
		this.mTrans = base.transform;
		this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		this.mScroll = this.mPanel.GetComponent<UIScrollView>();
		if (this.mScroll == null)
		{
			return false;
		}
		if (this.mScroll.movement == UIScrollView.Movement.Horizontal)
		{
			this.mHorizontal = true;
		}
		else
		{
			if (this.mScroll.movement != UIScrollView.Movement.Vertical)
			{
				return false;
			}
			this.mHorizontal = false;
		}
		this.CreatePlaceHolder();
		this.ToggleClipMove(true);
		return true;
	}

	public void OnEnable()
	{
		this.ToggleClipMove(true);
	}

	public void OnDisable()
	{
		this.ToggleClipMove(false);
	}

	private void ToggleClipMove(bool bEnable)
	{
		if (this.mPanel == null)
		{
			return;
		}
		UIPanel expr_18 = this.mPanel;
		expr_18.onClipMove = (UIPanel.OnClippingMoved)Delegate.Remove(expr_18.onClipMove, new UIPanel.OnClippingMoved(this.OnMove));
		if (bEnable)
		{
			UIPanel expr_46 = this.mPanel;
			expr_46.onClipMove = (UIPanel.OnClippingMoved)Delegate.Combine(expr_46.onClipMove, new UIPanel.OnClippingMoved(this.OnMove));
		}
	}

	public void CreatePlaceHolder()
	{
		if (this.bBounds)
		{
			Transform transform = this.mPanel.transform.FindChild("PlaceHolder");
			if (transform == null)
			{
				this.mPlaceHolder = NGUITools.AddWidget<UIWidget>(this.mPanel.gameObject);
				this.mPlaceHolder.name = "PlaceHolder";
			}
			else
			{
				this.mPlaceHolder = transform.GetComponent<UIWidget>();
			}
			if (this.mPlaceHolder == null)
			{
				return;
			}
			this.mPlaceHolder.width = (int)this.itemSize.x;
			this.mPlaceHolder.height = (int)this.itemSize.y;
			if (this.mHorizontal)
			{
				this.mPlaceHolder.pivot = UIWidget.Pivot.Left;
				this.mPlaceHolder.transform.localPosition = new Vector3(-this.itemSize.x / 2f, 0f, 0f);
			}
			else
			{
				this.mPlaceHolder.pivot = UIWidget.Pivot.Top;
				this.mPlaceHolder.transform.localPosition = new Vector3(0f, this.itemSize.y / 2f, 0f);
			}
			this.UpdatePlaceHolder();
		}
	}

	public void UpdatePlaceHolder()
	{
		if (this.bBounds)
		{
			if (this.mHorizontal)
			{
				this.lowerBound = 0f;
				this.lowerBoundWithEpsilon = this.lowerBound - this.itemSize.x / 2f;
				if (this._ContentCount <= 0)
				{
					this.upperBound = 0f;
				}
				else
				{
					this.upperBound = (float)((this._ContentCount - 1) / this.WidthDimension * (int)this.itemSize.x);
				}
				this.upperBoundWithEpsilon = this.upperBound + this.itemSize.x / 2f;
				this.mPlaceHolder.width = (int)this.upperBound + (int)this.itemSize.x;
			}
			else
			{
				if (this._ContentCount <= 0)
				{
					this.lowerBound = 0f;
				}
				else
				{
					this.lowerBound = (float)(-(float)((this._ContentCount - 1) / this.WidthDimension) * (int)this.itemSize.y);
				}
				this.lowerBoundWithEpsilon = this.lowerBound - this.itemSize.y / 2f;
				this.upperBound = 0f;
				this.upperBoundWithEpsilon = this.upperBound + this.itemSize.y / 2f;
				this.mPlaceHolder.height = -(int)this.lowerBound + (int)this.itemSize.y;
			}
		}
	}

	public bool Init()
	{
		if (!this.CacheScrollView())
		{
			return false;
		}
		Vector3 localPosition = base.gameObject.transform.localPosition;
		if (this.mHorizontal)
		{
			localPosition.x = 0f;
		}
		else
		{
			localPosition.y = 0f;
		}
		base.gameObject.transform.localPosition = localPosition;
		return true;
	}

	private void ResetChildPositions()
	{
		this.SetChildPositionOffset(0, true);
	}

	public void SetContentCount(int count)
	{
		this._ContentCount = count;
		this.UpdatePlaceHolder();
	}

	public void AdjustContent()
	{
		float num = (!this.mHorizontal) ? this.mPanel.finalClipRegion.w : this.mPanel.finalClipRegion.z;
		float num2 = (!this.mHorizontal) ? this.mPanel.baseClipRegion.y : this.mPanel.baseClipRegion.x;
		float f;
		float num5;
		if (this.mHorizontal)
		{
			float num3 = this.itemSize.x;
			float num4 = num / 2f + num2 - num3 / 2f - this.mPanel.clipSoftness.x;
			f = this.mPanel.clipOffset.x + num - num4;
			num5 = Mathf.Abs(this.upperBound) + num3;
		}
		else
		{
			float num3 = this.itemSize.y;
			float num4 = num / 2f + num2 - num3 / 2f + this.mPanel.clipSoftness.y;
			f = this.mPanel.clipOffset.y - num + num4;
			num5 = Mathf.Abs(this.lowerBound) + num3;
		}
		if (num < num5)
		{
			if (Mathf.Abs(f) > num5)
			{
				this.SetChildPositionOffset(this._ContentCount - this.mChildren.size, true);
				this.mScroll.NeedRecalcBounds();
				this.mScroll.RestrictWithinBounds(true, this.mHorizontal, !this.mHorizontal);
			}
			else
			{
				this.RefreshAllChildrenContent();
			}
		}
		else
		{
			this.SetChildPositionOffset(0, true);
			this.mScroll.ResetPosition();
		}
		this.WrapContent();
	}

	public void SetChildPositionOffset(int offset = 0, bool bUpdate = true)
	{
		for (int i = 0; i < this.mChildren.size; i++)
		{
			int num = offset + i;
			int num2 = num / this.WidthDimension;
			int num3 = num % this.WidthDimension;
			Transform transform = this.mChildren[i];
			transform.localPosition = ((!this.mHorizontal) ? new Vector3((float)num3 * this.itemSize.x, (float)(-(float)num2) * this.itemSize.y, 0f) : new Vector3((float)num2 * this.itemSize.x, (float)(-(float)num3) * this.itemSize.y, 0f));
			if (bUpdate)
			{
				this.UpdateItem(transform, i);
			}
		}
	}

	public void RefreshAllChildrenContent()
	{
		for (int i = 0; i < this.mChildren.size; i++)
		{
			this.UpdateItem(this.mChildren[i], i);
		}
	}

	public void WrapContent()
	{
		float num = ((!this.mHorizontal) ? this.itemSize.y : this.itemSize.x) * (float)(this.mChildren.size / this.WidthDimension) * 0.5f;
		num = Mathf.Max(num, 1f);
		float num2 = num * 2f;
		float num3 = ((!this.mHorizontal) ? this.itemSize.y : this.itemSize.x) / 2f + num;
		Vector3 a = (!this.mHorizontal) ? new Vector3(0f, num * 2f, 0f) : new Vector3(num * 2f, 0f, 0f);
		Vector3[] worldCorners = this.mPanel.worldCorners;
		for (int i = 0; i < 4; i++)
		{
			Vector3 vector = worldCorners[i];
			vector = this.mTrans.InverseTransformPoint(vector);
			worldCorners[i] = vector;
		}
		Vector3 vector2 = Vector3.Lerp(worldCorners[0], worldCorners[2], 0.5f);
		bool flag = false;
		bool flag2 = true;
		if (this.mHorizontal)
		{
			float num4 = worldCorners[0].x - vector2.x - this.itemSize.x;
			float num5 = worldCorners[2].x - vector2.x + this.itemSize.x;
			int j = 0;
			while (j < this.mChildren.size)
			{
				Transform transform = this.mChildren[j];
				float num6 = transform.localPosition.x - vector2.x;
				if (num6 < -num3)
				{
					int num7 = (int)(-num - num6) / (int)num2 + 1;
					if (!this.bBounds || transform.localPosition.x + num2 * (float)num7 <= this.upperBoundWithEpsilon)
					{
						transform.localPosition += a * (float)num7;
						flag = true;
						num6 = transform.localPosition.x - vector2.x;
					}
				}
				else if (num6 > num3)
				{
					int num7 = (int)(num6 - num) / (int)num2 + 1;
					if (!this.bBounds || transform.localPosition.x - num2 * (float)num7 >= this.lowerBoundWithEpsilon)
					{
						transform.localPosition -= a * (float)num7;
						flag = true;
						num6 = transform.localPosition.x - vector2.x;
					}
				}
				if (this.bBounds)
				{
					if (transform.localPosition.x > this.upperBoundWithEpsilon)
					{
						int num7 = (int)(transform.localPosition.x - this.upperBound) / (int)num2 + 1;
						transform.localPosition -= a * (float)num7;
						flag = (transform.localPosition.x >= this.lowerBoundWithEpsilon);
						flag2 = flag;
						num6 = transform.localPosition.x - vector2.x;
					}
					else if (transform.localPosition.x < this.lowerBoundWithEpsilon)
					{
						int num7 = (int)(this.lowerBound - transform.localPosition.x) / (int)num2 + 1;
						transform.localPosition += a * (float)num7;
						flag = (transform.localPosition.x <= this.upperBoundWithEpsilon);
						flag2 = flag;
						num6 = transform.localPosition.x - vector2.x;
					}
				}
				if (this.cullContent)
				{
					num6 += -this.mTrans.localPosition.x;
					if (!UICamera.IsPressed(transform.gameObject))
					{
						if (flag)
						{
							if (!transform.gameObject.activeSelf)
							{
								NGUITools.SetActive(transform.gameObject, true, false, true);
							}
							this.UpdateItem(transform, j);
							flag = false;
						}
						NGUITools.SetActive(transform.gameObject, flag2 && num6 > num4 && num6 < num5, false, true);
					}
				}
				if (flag)
				{
					this.UpdateItem(transform, j);
				}
				j++;
				flag = false;
				flag2 = true;
			}
		}
		else
		{
			float num8 = worldCorners[0].y - vector2.y - this.itemSize.y;
			float num9 = worldCorners[2].y - vector2.y + this.itemSize.y;
			int k = 0;
			while (k < this.mChildren.size)
			{
				Transform transform2 = this.mChildren[k];
				float num10 = transform2.localPosition.y - vector2.y;
				if (num10 < -num3)
				{
					int num7 = (int)(-num - num10) / (int)num2 + 1;
					if (!this.bBounds || transform2.localPosition.y + num2 * (float)num7 <= this.upperBoundWithEpsilon)
					{
						transform2.localPosition += a * (float)num7;
						flag = true;
						num10 = transform2.localPosition.y - vector2.y;
					}
				}
				else if (num10 > num3)
				{
					int num7 = (int)(num10 - num) / (int)num2 + 1;
					if (!this.bBounds || transform2.localPosition.y - num2 * (float)num7 >= this.lowerBoundWithEpsilon)
					{
						transform2.localPosition -= a * (float)num7;
						flag = true;
						num10 = transform2.localPosition.y - vector2.y;
					}
				}
				if (this.bBounds)
				{
					if (transform2.localPosition.y > this.upperBoundWithEpsilon)
					{
						int num7 = (int)(transform2.localPosition.y - this.upperBound) / (int)num2 + 1;
						transform2.localPosition -= a * (float)num7;
						flag = (transform2.localPosition.y >= this.lowerBoundWithEpsilon);
						flag2 = flag;
						num10 = transform2.localPosition.y - vector2.y;
					}
					else if (transform2.localPosition.y < this.lowerBoundWithEpsilon)
					{
						int num7 = (int)(this.lowerBound - transform2.localPosition.y) / (int)num2 + 1;
						transform2.localPosition += a * (float)num7;
						flag = (transform2.localPosition.y <= this.upperBoundWithEpsilon);
						flag2 = flag;
						num10 = transform2.localPosition.y - vector2.y;
					}
				}
				if (this.cullContent)
				{
					num10 += -this.mTrans.localPosition.y;
					if (!UICamera.IsPressed(transform2.gameObject))
					{
						if (flag)
						{
							if (!transform2.gameObject.activeSelf)
							{
								NGUITools.SetActive(transform2.gameObject, true, false, true);
							}
							this.UpdateItem(transform2, k);
							flag = false;
						}
						else
						{
							NGUITools.SetActive(transform2.gameObject, flag2 && num10 > num8 && num10 < num9, false, true);
						}
					}
				}
				if (flag)
				{
					this.UpdateItem(transform2, k);
				}
				k++;
				flag = false;
				flag2 = true;
			}
		}
	}

	protected virtual void UpdateItem(Transform item, int index)
	{
		int num;
		if (this.mHorizontal)
		{
			num = (int)(item.localPosition.x / this.itemSize.x + 0.5f) * this.WidthDimension + (int)(-item.localPosition.y / this.itemSize.y + 0.5f);
		}
		else
		{
			num = (int)(-item.localPosition.y / this.itemSize.y + 0.5f) * this.WidthDimension + (int)(item.localPosition.x / this.itemSize.x + 0.5f);
		}
		if (num < 0 || num >= this._ContentCount)
		{
			if (item.gameObject.activeSelf)
			{
				NGUITools.SetActive(item.gameObject, false, false, true);
			}
			return;
		}
		if (this.updateHandler != null)
		{
			this.updateHandler(item, num);
		}
	}
}
