using System;

namespace XUtliPoolLib
{
	public struct BufferBlock
	{
		public int offset;

		public int size;

		public int capacity;

		public int blockIndex;

		public bool inUse;
	}
}
