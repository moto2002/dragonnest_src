using System;

namespace XUtliPoolLib
{
	public struct SmallBuffer<T>
	{
		public BufferBlock bufferBlock;

		private SmallBufferPool<T> poolRef;

		private T[] bufferRef;

		public T this[int index]
		{
			get
			{
				if (this.bufferRef != null)
				{
					return this.bufferRef[this.bufferBlock.offset + index];
				}
				return default(T);
			}
			set
			{
				if (this.bufferRef != null)
				{
					this.bufferRef[this.bufferBlock.offset + index] = value;
				}
			}
		}

		public T this[uint index]
		{
			get
			{
				return this.bufferRef[(int)(checked((IntPtr)(unchecked((long)this.bufferBlock.offset + (long)((ulong)index)))))];
			}
			set
			{
				this.bufferRef[(int)(checked((IntPtr)(unchecked((long)this.bufferBlock.offset + (long)((ulong)index)))))] = value;
			}
		}

		public int Count
		{
			get
			{
				if (this.bufferRef != null)
				{
					return this.bufferBlock.size;
				}
				return 0;
			}
		}

		public bool IsInit
		{
			get
			{
				return this.bufferRef != null;
			}
		}

		public T[] OriginalBuff
		{
			get
			{
				return this.bufferRef;
			}
		}

		public int StartOffset
		{
			get
			{
				return this.bufferBlock.offset;
			}
		}

		private void Expand(int size)
		{
			T[] sourceArray = this.bufferRef;
			int offset = this.bufferBlock.offset;
			int size2 = this.bufferBlock.size;
			int capacity = this.bufferBlock.capacity;
			this.poolRef.ExpandBlock(ref this, size);
			Array.Copy(sourceArray, offset, this.bufferRef, this.bufferBlock.offset, capacity);
			this.bufferBlock.size = size2;
		}

		private void ReturnBlock()
		{
			if (this.poolRef != null)
			{
				this.poolRef.ReturnBlock(ref this);
			}
		}

		public void Init(BufferBlock bb, SmallBufferPool<T> pool)
		{
			this.ReturnBlock();
			this.bufferBlock = bb;
			this.poolRef = pool;
			this.bufferRef = pool.buffer;
		}

		public void Init(BufferBlock bb, SmallBufferPool<T> pool, T[] buffer)
		{
			this.ReturnBlock();
			this.bufferBlock = bb;
			this.poolRef = pool;
			this.bufferRef = buffer;
		}

		public void UnInit()
		{
			this.poolRef = null;
			this.bufferRef = null;
		}

		public void Add(T value)
		{
			if (this.bufferRef != null)
			{
				if (this.bufferBlock.size == this.bufferBlock.capacity)
				{
					this.Expand(this.bufferBlock.capacity * 2);
				}
				int size;
				this.bufferBlock.size = (size = this.bufferBlock.size) + 1;
				this[size] = value;
			}
		}

		public bool Remove(T item)
		{
			if (this.bufferRef != null)
			{
				T value = default(T);
				for (int i = 0; i < this.bufferBlock.size; i++)
				{
					T t = this[i];
					if (t.Equals(item))
					{
						this.bufferBlock.size = this.bufferBlock.size - 1;
						this[i] = value;
						for (int j = i; j < this.bufferBlock.size; j++)
						{
							this[j] = this[j + 1];
						}
						return true;
					}
				}
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			if (this.bufferRef != null && index < this.bufferBlock.size)
			{
				this.bufferBlock.size = this.bufferBlock.size - 1;
				this[index] = default(T);
				for (int i = index; i < this.bufferBlock.size; i++)
				{
					this[i] = this[i + 1];
				}
			}
		}

		public bool Contains(T item)
		{
			if (this.bufferRef != null)
			{
				for (int i = 0; i < this.bufferBlock.size; i++)
				{
					T t = this[i];
					if (t.Equals(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void Clear()
		{
			this.bufferBlock.size = 0;
		}

		public void DeepClear()
		{
			if (this.bufferRef != null)
			{
				Array.Clear(this.bufferRef, this.bufferBlock.offset, this.bufferBlock.capacity);
			}
		}

		public void Copy(T[] src, int startIndex, int desIndex, int count)
		{
			if (this.bufferRef != null)
			{
				count = ((count < this.bufferBlock.capacity) ? count : this.bufferBlock.capacity);
				Array.Copy(src, startIndex, this.bufferRef, this.bufferBlock.offset + desIndex, count);
				this.bufferBlock.size = count;
			}
		}

		public void SetInvalid()
		{
			this.bufferBlock.blockIndex = -1;
			this.poolRef = null;
			this.bufferRef = null;
		}
	}
}
