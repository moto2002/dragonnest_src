using System;
using UnityEngine;
using XUtliPoolLib;

public class XOpenFishingUI : MonoBehaviour
{
	private IXPlayerAction _uiOperation;

	private int m_SeatIndex;

	private void Awake()
	{
		this.m_SeatIndex = int.Parse(base.gameObject.name.Substring(base.gameObject.name.Length - 1, 1));
	}

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
				this._uiOperation.GotoFishing(this.m_SeatIndex, true);
			}
		}
	}

	private void OnTriggerStay(Collider c)
	{
		if (c.gameObject.CompareTag("Player"))
		{
			if (this._uiOperation == null || this._uiOperation.Deprecated)
			{
				this._uiOperation = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXPlayerAction>(1u);
			}
			if (this._uiOperation != null)
			{
				this._uiOperation.GotoFishing(this.m_SeatIndex, true);
			}
		}
	}

	private void OnTriggerExit(Collider c)
	{
		if (c.gameObject.CompareTag("Player"))
		{
			if (this._uiOperation == null || this._uiOperation.Deprecated)
			{
				this._uiOperation = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXPlayerAction>(1u);
			}
			if (this._uiOperation != null)
			{
				this._uiOperation.GotoFishing(this.m_SeatIndex, false);
			}
		}
	}
}
