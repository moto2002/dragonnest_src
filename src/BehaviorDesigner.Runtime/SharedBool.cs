using System;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedBool : SharedVariable<bool>
	{
		public static implicit operator SharedBool(bool value)
		{
			return new SharedBool
			{
				mValue = value
			};
		}
	}
}
