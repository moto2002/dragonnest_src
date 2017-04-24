using System;
using UnityEngine;
using XUtliPoolLib;

public class XOpenDungeonUI : MonoBehaviour
{
	private IXPlayerAction _uiOperation;

	private void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag("Player"))
		{
			if (this._uiOperation == null || this._uiOperation.Deprecated)
			{
				this._uiOperation = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXPlayerAction>(1u);
			}
			if (this._uiOperation != null)
			{
				this._uiOperation.GotoBattle();
			}
		}
	}
}
