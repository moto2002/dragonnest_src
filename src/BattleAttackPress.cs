using System;
using UnityEngine;

public class BattleAttackPress : MonoBehaviour
{
	private GameObject fx;

	private void Start()
	{
		this.fx = base.transform.parent.FindChild("glow").gameObject;
	}

	private void OnPress(bool state)
	{
		if (!state)
		{
			this.fx.SetActive(false);
		}
	}
}
