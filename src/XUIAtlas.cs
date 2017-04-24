using System;
using UILib;
using UnityEngine;

public class XUIAtlas : MonoBehaviour, IXUIAtlas
{
	private UIAtlas m_uiAtlas;

	public UIAtlas atlas
	{
		get
		{
			return this.m_uiAtlas;
		}
	}

	private void Awake()
	{
		this.m_uiAtlas = base.GetComponent<UIAtlas>();
		if (null == this.m_uiAtlas)
		{
			Debug.LogError("null == m_uiAtlas");
		}
	}

	private void OnDisable()
	{
		this.m_uiAtlas = null;
	}
}
