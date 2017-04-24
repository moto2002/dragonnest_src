using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag and Drop Item")]
public class UIDragDropItem : MonoBehaviour
{
	public enum Restriction
	{
		None,
		Horizontal,
		Vertical,
		PressAndHold
	}

	public UIDragDropItem.Restriction restriction;

	public bool cloneOnDrag;

	public List<EventDelegate> onFinished = new List<EventDelegate>();

	public List<EventDelegate> onStart = new List<EventDelegate>();

	protected Transform mTrans;

	protected Transform mParent;

	protected Collider mCollider;

	protected UIButton mButton;

	protected UIRoot mRoot;

	protected UIGrid mGrid;

	protected UITable mTable;

	protected int mTouchID = -2147483648;

	protected float mPressTime;

	protected UIDragScrollView mDragScrollView;

	protected virtual void Start()
	{
		this.mTrans = base.transform;
		this.mCollider = base.collider;
		this.mButton = base.GetComponent<UIButton>();
		this.mDragScrollView = base.GetComponent<UIDragScrollView>();
	}

	private void OnPress(bool isPressed)
	{
		if (isPressed)
		{
			this.mPressTime = RealTime.time;
		}
	}

	private void OnDragStart()
	{
		if (!base.enabled || this.mTouchID != -2147483648)
		{
			return;
		}
		if (this.restriction != UIDragDropItem.Restriction.None)
		{
			if (this.restriction == UIDragDropItem.Restriction.Horizontal)
			{
				Vector2 totalDelta = UICamera.currentTouch.totalDelta;
				if (Mathf.Abs(totalDelta.x) < Mathf.Abs(totalDelta.y))
				{
					return;
				}
			}
			else if (this.restriction == UIDragDropItem.Restriction.Vertical)
			{
				Vector2 totalDelta2 = UICamera.currentTouch.totalDelta;
				if (Mathf.Abs(totalDelta2.x) > Mathf.Abs(totalDelta2.y))
				{
					return;
				}
			}
			else if (this.restriction == UIDragDropItem.Restriction.PressAndHold && this.mPressTime + 1f > RealTime.time)
			{
				return;
			}
		}
		if (this.cloneOnDrag)
		{
			GameObject gameObject = NGUITools.AddChild(base.transform.parent.gameObject, base.gameObject);
			gameObject.transform.localPosition = base.transform.localPosition;
			gameObject.transform.localRotation = base.transform.localRotation;
			gameObject.transform.localScale = base.transform.localScale;
			XUIDragDropItem xUIDragDropItem = base.gameObject.GetComponent("XUIDragDropItem") as XUIDragDropItem;
			XUIDragDropItem xUIDragDropItem2 = gameObject.GetComponent("XUIDragDropItem") as XUIDragDropItem;
			if (xUIDragDropItem != null && xUIDragDropItem2 != null)
			{
				xUIDragDropItem2.m_OnFinishHandler = xUIDragDropItem.m_OnFinishHandler;
				xUIDragDropItem2.m_OnStartHandler = xUIDragDropItem.m_OnStartHandler;
			}
			XUISprite xUISprite = base.gameObject.GetComponent("XUISprite") as XUISprite;
			XUISprite xUISprite2 = gameObject.GetComponent("XUISprite") as XUISprite;
			if (xUISprite != null && xUISprite2 != null)
			{
				xUISprite2.ID = xUISprite.ID;
			}
			UIWidget[] componentsInChildren = gameObject.GetComponentsInChildren<UIWidget>();
			UIWidget[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				UIWidget uIWidget = array[i];
				uIWidget.depth += 200;
			}
			UIButtonColor component = gameObject.GetComponent<UIButtonColor>();
			if (component != null)
			{
				component.defaultColor = base.GetComponent<UIButtonColor>().defaultColor;
			}
			UICamera.currentTouch.dragged = gameObject;
			UIDragDropItem component2 = gameObject.GetComponent<UIDragDropItem>();
			component2.Start();
			component2.OnDragDropStart();
		}
		else
		{
			this.OnDragDropStart();
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (!base.enabled || this.mTouchID != UICamera.currentTouchID)
		{
			return;
		}
		this.OnDragDropMove(delta * this.mRoot.pixelSizeAdjustment);
	}

	private void OnDragEnd()
	{
		if (!base.enabled || this.mTouchID != UICamera.currentTouchID)
		{
			return;
		}
		this.OnDragDropRelease(UICamera.hoveredObject);
	}

	protected virtual void OnDragDropStart()
	{
		if (this.mDragScrollView != null)
		{
			this.mDragScrollView.enabled = false;
		}
		if (this.mButton != null)
		{
			this.mButton.isEnabled = false;
		}
		else if (this.mCollider != null)
		{
			this.mCollider.enabled = false;
		}
		this.mTouchID = UICamera.currentTouchID;
		this.mParent = this.mTrans.parent;
		if (this.mRoot == null)
		{
			this.mRoot = NGUITools.FindInParents<UIRoot>(this.mParent);
		}
		this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
		this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
		if (UIDragDropRoot.root != null)
		{
			this.mTrans.parent = UIDragDropRoot.root;
		}
		Vector3 localPosition = this.mTrans.localPosition;
		localPosition.z = 0f;
		this.mTrans.localPosition = localPosition;
		TweenPosition component = base.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		SpringPosition component2 = base.GetComponent<SpringPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGUITools.MarkParentAsChanged(base.gameObject);
		if (this.mTable != null)
		{
			this.mTable.repositionNow = true;
		}
		if (this.mGrid != null)
		{
			this.mGrid.repositionNow = true;
		}
		EventDelegate.Execute(this.onStart);
	}

	protected virtual void OnDragDropMove(Vector3 delta)
	{
		this.mTrans.localPosition += delta;
	}

	protected virtual void OnDragDropRelease(GameObject surface)
	{
		if (!this.cloneOnDrag)
		{
			this.mTouchID = -2147483648;
			if (this.mButton != null)
			{
				this.mButton.isEnabled = true;
			}
			else if (this.mCollider != null)
			{
				this.mCollider.enabled = true;
			}
			UIDragDropContainer uIDragDropContainer = (!surface) ? null : NGUITools.FindInParents<UIDragDropContainer>(surface);
			if (uIDragDropContainer != null)
			{
				this.mTrans.parent = ((!(uIDragDropContainer.reparentTarget != null)) ? uIDragDropContainer.transform : uIDragDropContainer.reparentTarget);
				Vector3 localPosition = this.mTrans.localPosition;
				localPosition.z = 0f;
				this.mTrans.localPosition = localPosition;
			}
			else
			{
				this.mTrans.parent = this.mParent;
			}
			this.mParent = this.mTrans.parent;
			this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
			this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
			if (this.mDragScrollView != null)
			{
				this.mDragScrollView.enabled = true;
			}
			NGUITools.MarkParentAsChanged(base.gameObject);
			if (this.mTable != null)
			{
				this.mTable.repositionNow = true;
			}
			if (this.mGrid != null)
			{
				this.mGrid.repositionNow = true;
			}
			EventDelegate.Execute(this.onFinished);
		}
		else
		{
			NGUITools.Destroy(base.gameObject);
			EventDelegate.Execute(this.onFinished);
		}
	}
}
