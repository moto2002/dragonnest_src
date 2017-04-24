using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface ILoopItemObject
	{
		int dataIndex
		{
			get;
			set;
		}

		bool isVisible();

		GameObject GetObj();

		void SetHeight(int height);
	}
}
