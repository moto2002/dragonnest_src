using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Center Scroll View on Child")]
public class UICenterOnChild : MonoBehaviour
{
	public float springStrength = 8f;

	public float nextPageThreshold;

	public SpringPanel.OnFinished onFinished;

	private UIScrollView mScrollView;

	private GameObject mCenteredObject;

	public GameObject centeredObject
	{
		get
		{
			return this.mCenteredObject;
		}
	}

	private void OnEnable()
	{
		this.Recenter();
	}

	private void OnDragFinished()
	{
		if (base.enabled)
		{
			this.Recenter();
		}
	}

	private void OnValidate()
	{
		this.nextPageThreshold = Mathf.Abs(this.nextPageThreshold);
	}

	public void Recenter()
	{
		if (this.mScrollView == null)
		{
			this.mScrollView = NGUITools.FindInParents<UIScrollView>(base.gameObject);
			if (this.mScrollView == null)
			{
				base.enabled = false;
				return;
			}
			this.mScrollView.onDragFinished = new UIScrollView.OnDragFinished(this.OnDragFinished);
			if (this.mScrollView.horizontalScrollBar != null)
			{
				this.mScrollView.horizontalScrollBar.onDragFinished = new UIProgressBar.OnDragFinished(this.OnDragFinished);
			}
			if (this.mScrollView.verticalScrollBar != null)
			{
				this.mScrollView.verticalScrollBar.onDragFinished = new UIProgressBar.OnDragFinished(this.OnDragFinished);
			}
		}
		if (this.mScrollView.panel == null)
		{
			return;
		}
		Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
		Vector3 vector = (worldCorners[2] + worldCorners[0]) * 0.5f;
		Vector3 b = vector - this.mScrollView.currentMomentum * (this.mScrollView.momentumAmount * 0.1f);
		this.mScrollView.currentMomentum = Vector3.zero;
		float num = 3.40282347E+38f;
		Transform target = null;
		Transform transform = base.transform;
		int num2 = 0;
		int i = 0;
		int childCount = transform.childCount;
		while (i < childCount)
		{
			Transform child = transform.GetChild(i);
			float num3 = Vector3.SqrMagnitude(child.position - b);
			if (num3 < num)
			{
				num = num3;
				target = child;
				num2 = i;
			}
			i++;
		}
		if (this.nextPageThreshold > 0f && UICamera.currentTouch != null && this.mCenteredObject != null && this.mCenteredObject.transform == transform.GetChild(num2))
		{
			Vector2 totalDelta = UICamera.currentTouch.totalDelta;
			UIScrollView.Movement movement = this.mScrollView.movement;
			float num4;
			if (movement != UIScrollView.Movement.Horizontal)
			{
				if (movement != UIScrollView.Movement.Vertical)
				{
					num4 = totalDelta.magnitude;
				}
				else
				{
					num4 = totalDelta.y;
				}
			}
			else
			{
				num4 = totalDelta.x;
			}
			if (num4 > this.nextPageThreshold)
			{
				if (num2 > 0)
				{
					target = transform.GetChild(num2 - 1);
				}
			}
			else if (num4 < -this.nextPageThreshold && num2 < transform.childCount - 1)
			{
				target = transform.GetChild(num2 + 1);
			}
		}
		this.CenterOn(target, vector);
	}

	private void CenterOn(Transform target, Vector3 panelCenter)
	{
		if (target != null && this.mScrollView != null && this.mScrollView.panel != null)
		{
			Transform cachedTransform = this.mScrollView.panel.cachedTransform;
			this.mCenteredObject = target.gameObject;
			Vector3 a = cachedTransform.InverseTransformPoint(target.position);
			Vector3 b = cachedTransform.InverseTransformPoint(panelCenter);
			Vector3 b2 = a - b;
			if (!this.mScrollView.canMoveHorizontally)
			{
				b2.x = 0f;
			}
			if (!this.mScrollView.canMoveVertically)
			{
				b2.y = 0f;
			}
			b2.z = 0f;
			SpringPanel.Begin(this.mScrollView.panel.cachedGameObject, cachedTransform.localPosition - b2, this.springStrength).onFinished = this.onFinished;
		}
		else
		{
			this.mCenteredObject = null;
		}
	}

	public void CenterOn(Transform target)
	{
		if (this.mScrollView != null && this.mScrollView.panel != null)
		{
			Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
			Vector3 panelCenter = (worldCorners[2] + worldCorners[0]) * 0.5f;
			this.CenterOn(target, panelCenter);
		}
	}
}
