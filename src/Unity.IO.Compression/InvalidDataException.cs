using System;
using System.Runtime.Serialization;

namespace Unity.IO.Compression
{
	[Serializable]
	public sealed class InvalidDataException : SystemException
	{
		public InvalidDataException() : base(SR.GetString("Invalid data"))
		{
		}

		public InvalidDataException(string message) : base(message)
		{
		}

		public InvalidDataException(string message, Exception innerException) : base(message, innerException)
		{
		}

		internal InvalidDataException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
