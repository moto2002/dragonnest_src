using System;

namespace XUpdater
{
	internal sealed class AsyncWriteRequest
	{
		public bool IsDone;

		public bool HasError;

		public string Location;

		public string Name;

		public uint Size;
	}
}
