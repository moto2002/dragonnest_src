using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedGameObjectList : SharedVariable<List<GameObject>>
	{
		public static implicit operator SharedGameObjectList(List<GameObject> value)
		{
			return new SharedGameObjectList
			{
				mValue = value
			};
		}
	}
}
