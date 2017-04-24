using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedVector4 : SharedVariable<Vector4>
	{
		public static implicit operator SharedVector4(Vector4 value)
		{
			return new SharedVector4
			{
				mValue = value
			};
		}
	}
}
