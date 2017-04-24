using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedVector2 : SharedVariable<Vector2>
	{
		public static implicit operator SharedVector2(Vector2 value)
		{
			return new SharedVector2
			{
				mValue = value
			};
		}
	}
}
