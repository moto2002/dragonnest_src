using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedTransform : SharedVariable<Transform>
	{
		public static implicit operator SharedTransform(Transform value)
		{
			return new SharedTransform
			{
				mValue = value
			};
		}
	}
}
