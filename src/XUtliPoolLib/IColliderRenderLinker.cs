using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IColliderRenderLinker : IXInterface
	{
		Renderer[] GetLinkedRender();
	}
}
