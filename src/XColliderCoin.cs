using System;
using UnityEngine;
using XUtliPoolLib;

public class XColliderCoin : XCollierObject
{
	public string exString;

	public XCollierObject.XColliderObjectType ColliderObjectType;

	private void Start()
	{
	}

	protected override void XTriggerEnter(Collider c)
	{
		if (this.exString == null || this.exString.Length > 0)
		{
		}
	}

	public new void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag("Player"))
		{
			XFx xFx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Shared/Drop_xishou", false);
			xFx.Play(c.transform, 1f, Vector3.one, true);
			base.transform.position = new Vector3(0f, 0f, 10000f);
		}
	}

	protected override void XTriggerExit(Collider c)
	{
	}
}
