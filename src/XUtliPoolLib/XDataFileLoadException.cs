using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XDataFileLoadException : XException
	{
		public XDataFileLoadException(string message) : base(message)
		{
		}

		public XDataFileLoadException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
