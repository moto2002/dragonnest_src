using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XZeroDelayException : XException
	{
		public XZeroDelayException(string message) : base(message)
		{
		}

		public XZeroDelayException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
