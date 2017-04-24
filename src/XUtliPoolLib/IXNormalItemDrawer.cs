using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXNormalItemDrawer : IXInterface
	{
		void DrawItem(GameObject go, int itemID, int count, bool showCount);
	}
}
