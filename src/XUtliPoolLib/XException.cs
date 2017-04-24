using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XException : ApplicationException
	{
		public XException()
		{
		}

		public XException(string message) : base(message)
		{
		}

		public XException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
