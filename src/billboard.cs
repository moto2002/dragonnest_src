using System;
using UnityEngine;
using XUtliPoolLib;

public class billboard : MonoBehaviour
{
	private IAssociatedCamera _camera;

	private static float updateTime = 0.1f;

	private float time;

	private void Start()
	{
	}

	private void Update()
	{
		if (this._camera == null || this._camera.Deprecated)
		{
			this._camera = XSingleton<XInterfaceMgr>.singleton.GetInterface<IAssociatedCamera>(XSingleton<XCommon>.singleton.XHash("IAssociatedCamera"));
		}
		if (this._camera != null)
		{
			Camera camera = this._camera.Get();
			if (camera != null)
			{
				base.transform.LookAt(camera.transform.position);
			}
		}
	}
}
