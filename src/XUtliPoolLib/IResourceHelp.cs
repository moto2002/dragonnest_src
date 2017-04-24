using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IResourceHelp : IXInterface
	{
		void CheckResource(UnityEngine.Object o, string path);
	}
}
