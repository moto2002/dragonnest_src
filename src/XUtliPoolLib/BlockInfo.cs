using System;

namespace XUtliPoolLib
{
	public struct BlockInfo
	{
		public int size;

		public int count;

		public BlockInfo(int s, int c)
		{
			this.size = s;
			this.count = c;
		}
	}
}
