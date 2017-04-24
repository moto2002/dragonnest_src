using System;

namespace XUtliPoolLib
{
	public class Sequence<T, N> where N : INumberEnum, new()
	{
		private T[] seq;

		public T this[int key]
		{
			get
			{
				return this.seq[key];
			}
			set
			{
				this.seq[key] = value;
			}
		}

		public int Length
		{
			get
			{
				return this.seq.Length;
			}
		}

		public Sequence()
		{
			this.seq = new T[INumberEnum.number(typeof(N).Name)];
			for (int i = 0; i < this.seq.Length; i++)
			{
				this.seq[i] = default(T);
			}
		}
	}
}
