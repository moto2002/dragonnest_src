using System;

namespace WeTest.U3DAutomation
{
	public class JsonException : ApplicationException
	{
		public JsonException()
		{
		}

		internal JsonException(d A_0) : base(string.Format("Invalid token '{0}' in input string", A_0))
		{
		}

		internal JsonException(d A_0, Exception A_1) : base(string.Format("Invalid token '{0}' in input string", A_0), A_1)
		{
		}

		internal JsonException(int A_0) : base(string.Format("Invalid character '{0}' in input string", (char)A_0))
		{
		}

		internal JsonException(int A_0, Exception A_1) : base(string.Format("Invalid character '{0}' in input string", (char)A_0), A_1)
		{
		}

		public JsonException(string message) : base(message)
		{
		}

		public JsonException(string message, Exception inner_exception) : base(message, inner_exception)
		{
		}
	}
}
