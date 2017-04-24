using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedRect : SharedVariable<Rect>
	{
		public static implicit operator SharedRect(Rect value)
		{
			return new SharedRect
			{
				mValue = value
			};
		}
	}
}
