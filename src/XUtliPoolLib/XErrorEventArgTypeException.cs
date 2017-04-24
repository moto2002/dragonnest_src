using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XErrorEventArgTypeException : XException
	{
		public XErrorEventArgTypeException(string message) : base(message)
		{
		}

		public XErrorEventArgTypeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
