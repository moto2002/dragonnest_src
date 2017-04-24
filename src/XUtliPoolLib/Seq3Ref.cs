using System;

namespace XUtliPoolLib
{
	public struct Seq3Ref<T>
	{
		public static T[] buffRef;

		public int indexOffset;

		public T this[int key]
		{
			get
			{
				int num = CVSReader.indexBuffer[this.indexOffset];
				return Seq3Ref<T>.buffRef[num + key];
			}
		}
	}
}
