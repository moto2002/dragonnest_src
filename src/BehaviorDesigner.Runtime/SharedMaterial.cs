using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedMaterial : SharedVariable<Material>
	{
		public static implicit operator SharedMaterial(Material value)
		{
			return new SharedMaterial
			{
				mValue = value
			};
		}
	}
}
