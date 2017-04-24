using System;

namespace BehaviorDesigner.Runtime
{
	[Serializable]
	public class SharedString : SharedVariable<string>
	{
		public static implicit operator SharedString(string value)
		{
			return new SharedString
			{
				mValue = value
			};
		}
	}
}
