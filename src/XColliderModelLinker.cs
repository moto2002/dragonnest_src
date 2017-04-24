using System;
using System.Collections.Generic;
using UnityEngine;

public class XColliderModelLinker : MonoBehaviour
{
	public List<GameObject> Models = new List<GameObject>();

	public bool Deprecated
	{
		get;
		set;
	}

	private void Start()
	{
	}

	public List<GameObject> GetLinkedModel()
	{
		return this.Models;
	}
}
