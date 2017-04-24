using System;

namespace XUtliPoolLib
{
	public struct Seq2Ref<T>
	{
		public static T[] buffRef;

		public int indexOffset;

		public T this[int key]
		{
			get
			{
				int num = CVSReader.indexBuffer[this.indexOffset];
				return Seq2Ref<T>.buffRef[num + key];
			}
		}
	}
}
