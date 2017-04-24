using System;
using UnityEngine;
using XUtliPoolLib;

public abstract class XWall : MonoBehaviour
{
	protected bool _forward_collision;

	protected IXPlayerAction _interface;

	private BoxCollider _box;

	private Vector3 _left;

	private Vector3 _right;

	private void Awake()
	{
		this._box = base.GetComponent<BoxCollider>();
		this._box.enabled = false;
		Vector3 b = Vector3.Cross(Vector3.up, base.transform.forward) * this._box.size.x * this._box.transform.localScale.x * 0.5f;
		this._left = this._box.center + this._box.transform.position - b;
		this._right = this._box.center + this._box.transform.position + b;
	}

	private void Update()
	{
		if (this._interface == null || this._interface.Deprecated)
		{
			this._interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXPlayerAction>(1u);
		}
		if (this._interface != null && this._interface.IsValid)
		{
			Vector3 vector = this._interface.PlayerPosition(!(this is XCameraWall));
			Vector3 vector2 = this._interface.PlayerLastPosition(!(this is XCameraWall));
			if ((vector2 - vector).sqrMagnitude > 0f)
			{
				this.CollisionDetected(vector, vector2);
			}
		}
	}

	private void CollisionDetected(Vector3 pos, Vector3 last)
	{
		if (XSingleton<XCommon>.singleton.IsLineSegmentCross(last, pos, this._left, this._right))
		{
			Vector3 lhs = pos - last;
			this._forward_collision = (Vector3.Dot(lhs, base.transform.forward) > 0f);
			this.OnTriggered();
		}
	}

	protected abstract void OnTriggered();
}
