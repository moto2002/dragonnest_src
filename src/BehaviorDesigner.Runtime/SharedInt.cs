using System;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedInt : SharedVariable<int>
	{
		public static implicit operator SharedInt(int value)
		{
			return new SharedInt
			{
				mValue = value
			};
		}
	}
}
