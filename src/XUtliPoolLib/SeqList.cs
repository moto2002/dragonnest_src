using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class SeqList<T>
	{
		public List<T> buff;

		private short m_dim = 2;

		private short m_count = 1;

		public short Count
		{
			get
			{
				return this.m_count;
			}
		}

		public short Dim
		{
			get
			{
				return this.m_dim;
			}
		}

		public T this[int index, int dim]
		{
			get
			{
				return this.buff[index * (int)this.m_dim + dim];
			}
			set
			{
				this.buff[index * (int)this.m_dim + dim] = value;
			}
		}

		public SeqList(short dim, short count)
		{
			this.buff = new List<T>();
			this.Reset(dim, count);
		}

		public T Get(int key, int dim)
		{
			return this[key, dim];
		}

		public void Reset(short dim, short count)
		{
			this.m_dim = dim;
			this.m_count = count;
			this.buff.Clear();
			this.buff.Capacity = (int)(this.m_dim * this.m_count);
			for (int i = 0; i < this.buff.Capacity; i++)
			{
				this.buff.Add(default(T));
			}
		}
	}
}
