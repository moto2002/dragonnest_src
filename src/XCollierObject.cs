using System;
using UnityEngine;

public abstract class XCollierObject : MonoBehaviour
{
	public enum XColliderObjectType
	{
		LevelFinishCoin,
		CoinInLevel
	}

	protected Vector3 _enterPoint;

	protected bool _forward_collision;

	private void Start()
	{
	}

	public void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag("Player"))
		{
		}
	}

	public void OnTriggerExit(Collider c)
	{
		if (c.gameObject.CompareTag("Player"))
		{
		}
	}

	protected abstract void XTriggerEnter(Collider c);

	protected abstract void XTriggerExit(Collider c);
}
