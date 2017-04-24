using System;
using UnityEngine;

public class XUICD
{
	public static readonly float DEFAULT_CLICK_CD = 0f;

	public static readonly float[] CLICK_CD_GROUPS = new float[]
	{
		0f,
		0.5f,
		1f
	};

	protected float m_ClickCD;

	protected float m_ClickTime;

	public void SetClickCD(int customCDGroup, float customCD)
	{
		if (customCD >= 0f)
		{
			this.m_ClickCD = customCD;
		}
		else if (customCDGroup < 0 || customCDGroup >= XUICD.CLICK_CD_GROUPS.Length)
		{
			this.m_ClickCD = XUICD.DEFAULT_CLICK_CD;
		}
		else
		{
			this.m_ClickCD = XUICD.CLICK_CD_GROUPS[customCDGroup];
		}
	}

	public bool IsInCD()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (realtimeSinceStartup - this.m_ClickTime < this.m_ClickCD)
		{
			return true;
		}
		this.m_ClickTime = realtimeSinceStartup;
		return false;
	}

	public void Reset()
	{
		this.m_ClickTime = 0f;
	}
}
