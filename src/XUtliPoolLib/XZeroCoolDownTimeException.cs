using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XZeroCoolDownTimeException : XException
	{
		public XZeroCoolDownTimeException(string message) : base(message)
		{
		}

		public XZeroCoolDownTimeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
