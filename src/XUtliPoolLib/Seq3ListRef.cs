using System;

namespace XUtliPoolLib
{
	public struct Seq3ListRef<T>
	{
		public static T[] buffRef;

		public byte count;

		public int indexOffset;

		public int Count
		{
			get
			{
				return (int)this.count;
			}
		}

		public T this[int index, int key]
		{
			get
			{
				int num = CVSReader.indexBuffer[this.indexOffset + index];
				return Seq3ListRef<T>.buffRef[num + key];
			}
		}

		public T Get(int key, int index)
		{
			return this[key, index];
		}
	}
}
