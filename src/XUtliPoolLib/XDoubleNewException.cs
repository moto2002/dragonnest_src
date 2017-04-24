using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XDoubleNewException : XException
	{
		public XDoubleNewException(string message) : base(message)
		{
		}

		public XDoubleNewException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
