using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider)), RequireComponent(typeof(Rigidbody))]
public class DragonExpeditionGateMono : MonoBehaviour
{
	private Rigidbody rb;

	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.rb.useGravity = false;
	}
}
