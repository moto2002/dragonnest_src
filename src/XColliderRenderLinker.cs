using System;
using UnityEngine;
using XUtliPoolLib;

public class XColliderRenderLinker : MonoBehaviour, IXInterface, IColliderRenderLinker
{
	public Renderer[] renders;

	public bool Deprecated
	{
		get;
		set;
	}

	public Renderer[] GetLinkedRender()
	{
		return this.renders;
	}
}
