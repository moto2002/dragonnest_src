using System;

namespace XUtliPoolLib
{
	public struct Seq4Ref<T>
	{
		public static T[] buffRef;

		public int indexOffset;

		public T this[int key]
		{
			get
			{
				int num = CVSReader.indexBuffer[this.indexOffset];
				return Seq4Ref<T>.buffRef[num + key];
			}
		}
	}
}
