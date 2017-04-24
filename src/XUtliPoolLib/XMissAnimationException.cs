using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XMissAnimationException : XException
	{
		public XMissAnimationException(string message) : base(message)
		{
		}

		public XMissAnimationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
