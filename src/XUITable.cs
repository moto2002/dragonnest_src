using System;
using UILib;
using UnityEngine;

public class XUITable : MonoBehaviour, IXUITable
{
	private UITable m_table;

	private void Awake()
	{
		this.m_table = base.GetComponent<UITable>();
		if (null == this.m_table)
		{
			Debug.LogError("null == m_table");
		}
	}

	public void RePositionNow()
	{
		this.m_table.repositionNow = true;
	}

	public void Reposition()
	{
		this.m_table.Reposition();
	}

	public void RePositionOnlyOneLevel()
	{
		this.m_table.RepositionOnlyOneLevel();
	}
}
