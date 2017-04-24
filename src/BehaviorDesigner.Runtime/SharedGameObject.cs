using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedGameObject : SharedVariable<GameObject>
	{
		public static implicit operator SharedGameObject(GameObject value)
		{
			return new SharedGameObject
			{
				mValue = value
			};
		}
	}
}
