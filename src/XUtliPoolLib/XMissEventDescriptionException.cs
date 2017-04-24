using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XMissEventDescriptionException : XException
	{
		public XMissEventDescriptionException(string message) : base(message)
		{
		}

		public XMissEventDescriptionException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
