using System;

namespace XUtliPoolLib
{
	public struct Seq2ListRef<T>
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
				return Seq2ListRef<T>.buffRef[num + key];
			}
		}

		public object Get(int key, int index)
		{
			int num = CVSReader.indexBuffer[this.indexOffset + index];
			return Seq2ListRef<T>.buffRef[num + key];
		}
	}
}
