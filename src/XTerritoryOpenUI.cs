using System;
using UnityEngine;
using XUtliPoolLib;

public class XTerritoryOpenUI : MonoBehaviour
{
	private IXPlayerAction _uiOperation;

	public int index;

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
				this._uiOperation.GotoTerritoryBattle(this.index);
			}
		}
	}
}
