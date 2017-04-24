using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XInvalidSkillException : XException
	{
		public XInvalidSkillException(string message) : base(message)
		{
		}

		public XInvalidSkillException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
