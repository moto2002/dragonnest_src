using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XErrorUnregisteredComponentException : XException
	{
		public XErrorUnregisteredComponentException(string message) : base(message)
		{
		}

		public XErrorUnregisteredComponentException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
