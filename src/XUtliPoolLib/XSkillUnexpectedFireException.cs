using System;

namespace XUtliPoolLib
{
	[Serializable]
	public class XSkillUnexpectedFireException : XException
	{
		public XSkillUnexpectedFireException(string message) : base(message)
		{
		}

		public XSkillUnexpectedFireException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
