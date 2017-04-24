using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Key Navigation")]
public class UIKeyNavigation : MonoBehaviour
{
	public enum Constraint
	{
		None,
		Vertical,
		Horizontal,
		Explicit
	}

	public static BetterList<UIKeyNavigation> list = new BetterList<UIKeyNavigation>();

	public UIKeyNavigation.Constraint constraint;

	public GameObject onUp;

	public GameObject onDown;

	public GameObject onLeft;

	public GameObject onRight;

	public GameObject onClick;

	public bool startsSelected;

	protected virtual void OnEnable()
	{
		UIKeyNavigation.list.Add(this);
		if (this.startsSelected && (UICamera.selectedObject == null || !NGUITools.GetActive(UICamera.selectedObject)))
		{
			UICamera.currentScheme = UICamera.ControlScheme.Controller;
			UICamera.selectedObject = base.gameObject;
		}
	}

	protected virtual void OnDisable()
	{
		UIKeyNavigation.list.Remove(this);
	}

	protected GameObject GetLeft()
	{
		if (NGUITools.GetActive(this.onLeft))
		{
			return this.onLeft;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.left, true);
	}

	private GameObject GetRight()
	{
		if (NGUITools.GetActive(this.onRight))
		{
			return this.onRight;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.right, true);
	}

	protected GameObject GetUp()
	{
		if (NGUITools.GetActive(this.onUp))
		{
			return this.onUp;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.up, false);
	}

	protected GameObject GetDown()
	{
		if (NGUITools.GetActive(this.onDown))
		{
			return this.onDown;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.down, false);
	}

	protected GameObject Get(Vector3 myDir, bool horizontal)
	{
		Transform transform = base.transform;
		myDir = transform.TransformDirection(myDir);
		Vector3 center = UIKeyNavigation.GetCenter(base.gameObject);
		float num = 3.40282347E+38f;
		GameObject result = null;
		for (int i = 0; i < UIKeyNavigation.list.size; i++)
		{
			UIKeyNavigation uIKeyNavigation = UIKeyNavigation.list[i];
			if (!(uIKeyNavigation == this))
			{
				Vector3 direction = UIKeyNavigation.GetCenter(uIKeyNavigation.gameObject) - center;
				float num2 = Vector3.Dot(myDir, direction.normalized);
				if (num2 >= 0.707f)
				{
					direction = transform.InverseTransformDirection(direction);
					if (horizontal)
					{
						direction.y *= 2f;
					}
					else
					{
						direction.x *= 2f;
					}
					float sqrMagnitude = direction.sqrMagnitude;
					if (sqrMagnitude <= num)
					{
						result = uIKeyNavigation.gameObject;
						num = sqrMagnitude;
					}
				}
			}
		}
		return result;
	}

	protected static Vector3 GetCenter(GameObject go)
	{
		UIWidget component = go.GetComponent<UIWidget>();
		if (component != null)
		{
			Vector3[] worldCorners = component.worldCorners;
			return (worldCorners[0] + worldCorners[2]) * 0.5f;
		}
		return go.transform.position;
	}

	protected virtual void OnKey(KeyCode key)
	{
		if (!NGUITools.GetActive(this))
		{
			return;
		}
		GameObject gameObject = null;
		switch (key)
		{
		case KeyCode.UpArrow:
			gameObject = this.GetUp();
			break;
		case KeyCode.DownArrow:
			gameObject = this.GetDown();
			break;
		case KeyCode.RightArrow:
			gameObject = this.GetRight();
			break;
		case KeyCode.LeftArrow:
			gameObject = this.GetLeft();
			break;
		default:
			if (key == KeyCode.Tab)
			{
				if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				{
					gameObject = this.GetLeft();
					if (gameObject == null)
					{
						gameObject = this.GetUp();
					}
					if (gameObject == null)
					{
						gameObject = this.GetDown();
					}
					if (gameObject == null)
					{
						gameObject = this.GetRight();
					}
				}
				else
				{
					gameObject = this.GetRight();
					if (gameObject == null)
					{
						gameObject = this.GetDown();
					}
					if (gameObject == null)
					{
						gameObject = this.GetUp();
					}
					if (gameObject == null)
					{
						gameObject = this.GetLeft();
					}
				}
			}
			break;
		}
		if (gameObject != null)
		{
			UICamera.selectedObject = gameObject;
		}
	}

	protected virtual void OnClick()
	{
		if (NGUITools.GetActive(this) && NGUITools.GetActive(this.onClick))
		{
			UICamera.selectedObject = this.onClick;
		}
	}
}
