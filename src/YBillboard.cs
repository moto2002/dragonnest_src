using System;
using UnityEngine;

public class YBillboard : MonoBehaviour
{
	private Transform cacheTrans;

	private Transform cacheCameraTrans;

	public static bool IsUpdate;

	private void Awake()
	{
		this.cacheTrans = base.transform;
		if (Camera.main != null)
		{
			this.cacheCameraTrans = Camera.main.transform;
		}
	}

	private void Update()
	{
		if (YBillboard.IsUpdate && this.cacheCameraTrans != null)
		{
			Vector3 eulerAngles = this.cacheTrans.rotation.eulerAngles;
			Vector3 eulerAngles2 = this.cacheCameraTrans.rotation.eulerAngles;
			this.cacheCameraTrans.rotation = Quaternion.Euler(eulerAngles2.x, eulerAngles2.y, eulerAngles.z);
		}
	}
}
