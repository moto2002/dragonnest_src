using System;
using UnityEngine;
using XUtliPoolLib;

public abstract class XTrigger : MonoBehaviour
{
	protected IXPlayerAction _interface;

	private CapsuleCollider _cap;

	private void Awake()
	{
		this._cap = base.GetComponent<CapsuleCollider>();
		this._cap.enabled = false;
	}

	private void Update()
	{
		if (this._interface == null || this._interface.Deprecated)
		{
			this._interface = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXPlayerAction>(1u);
		}
		if (this._interface != null && this._interface.IsValid)
		{
			Vector3 vector = this._interface.PlayerPosition(true);
			Vector3 a = this._interface.PlayerLastPosition(true);
			if ((a - vector).sqrMagnitude > 0f)
			{
				this.CollisionDetected(vector);
			}
		}
	}

	private void CollisionDetected(Vector3 pos)
	{
		Vector3 vector = pos - (this._cap.transform.position + this._cap.center);
		vector.y = 0f;
		if (vector.sqrMagnitude < this._cap.radius * this._cap.radius)
		{
			this.OnTriggered();
		}
	}

	protected abstract void OnTriggered();
}
