using System;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool<T>
{
	public class BufferQueue
	{
		public Queue<T[]> queue = new Queue<T[]>();

		public int defalutCount = 10;

		public int allocCount;

		public int totalCount;
	}

	private MemoryPool<T>.BufferQueue[] _pool = new MemoryPool<T>.BufferQueue[9];

	public MemoryPool()
	{
		MemoryPool<T>.BufferQueue bufferQueue = new MemoryPool<T>.BufferQueue();
		this._pool[0] = bufferQueue;
		bufferQueue.defalutCount = 1024;
		this.Init(bufferQueue, 32);
		int num = 64;
		int num2 = 256;
		int num3 = 7;
		for (int i = 1; i < num3; i++)
		{
			bufferQueue = new MemoryPool<T>.BufferQueue();
			this._pool[i] = bufferQueue;
			bufferQueue.defalutCount = num2;
			this.Init(bufferQueue, num);
			num *= 2;
			num2 /= 2;
			if (num2 < 10)
			{
				num2 = 16;
			}
		}
		for (int j = num3; j < 9; j++)
		{
			bufferQueue = new MemoryPool<T>.BufferQueue();
			this._pool[j] = bufferQueue;
		}
	}

	private void Init(MemoryPool<T>.BufferQueue bufferQueue, int size)
	{
		for (int i = 0; i < bufferQueue.defalutCount; i++)
		{
			T[] item = new T[size];
			bufferQueue.queue.Enqueue(item);
		}
	}

	private int GetBuffIndex(int length, ref int size)
	{
		if (length == 0)
		{
			return -1;
		}
		if (length <= 32)
		{
			size = 32;
			return 0;
		}
		if (length <= 64)
		{
			size = 64;
			return 1;
		}
		if (length <= 128)
		{
			size = 128;
			return 2;
		}
		if (length <= 256)
		{
			size = 256;
			return 3;
		}
		if (length <= 512)
		{
			size = 512;
			return 4;
		}
		if (length <= 1024)
		{
			size = 1024;
			return 5;
		}
		if (length <= 2048)
		{
			size = 2048;
			return 6;
		}
		if (length <= 4096)
		{
			size = 4096;
			return 7;
		}
		if (length <= 8192)
		{
			size = 8192;
			return 8;
		}
		return -1;
	}

	private MemoryPool<T>.BufferQueue GetBuffQueue(int length)
	{
		if (length == 0)
		{
			return null;
		}
		if (length == 32)
		{
			return this._pool[0];
		}
		if (length == 64)
		{
			return this._pool[1];
		}
		if (length == 128)
		{
			return this._pool[2];
		}
		if (length == 256)
		{
			return this._pool[3];
		}
		if (length == 512)
		{
			return this._pool[4];
		}
		if (length == 1024)
		{
			return this._pool[5];
		}
		if (length == 2048)
		{
			return this._pool[6];
		}
		if (length == 4096)
		{
			return this._pool[7];
		}
		if (length == 8192)
		{
			return this._pool[8];
		}
		return null;
	}

	public T[] GetBuff(int length)
	{
		int num = 0;
		int buffIndex = this.GetBuffIndex(length, ref num);
		if (buffIndex < 0 || buffIndex >= this._pool.Length)
		{
			int num2 = Mathf.Max(length << 1, 32);
			if (num2 >= 65000)
			{
				num2 = 64999;
			}
			return new T[num2];
		}
		MemoryPool<T>.BufferQueue bufferQueue = this._pool[buffIndex];
		if (bufferQueue.queue.Count > 0)
		{
			bufferQueue.allocCount++;
			return bufferQueue.queue.Dequeue();
		}
		bufferQueue.allocCount++;
		bufferQueue.totalCount++;
		return new T[num];
	}

	public void ReturnBuff(T[] buffer)
	{
		if (buffer != null)
		{
			MemoryPool<T>.BufferQueue buffQueue = this.GetBuffQueue(buffer.Length);
			if (buffQueue != null)
			{
				buffQueue.allocCount--;
				buffQueue.queue.Enqueue(buffer);
			}
		}
	}

	public void Clear()
	{
		int num = 7;
		for (int i = 0; i < num; i++)
		{
			MemoryPool<T>.BufferQueue bufferQueue = this._pool[i];
			if (bufferQueue != null)
			{
				while (bufferQueue.queue.Count > bufferQueue.defalutCount)
				{
					bufferQueue.allocCount--;
					T[] array = bufferQueue.queue.Dequeue();
				}
			}
		}
		for (int j = num; j < 9; j++)
		{
			MemoryPool<T>.BufferQueue bufferQueue2 = this._pool[j];
			if (bufferQueue2 != null)
			{
				while (bufferQueue2.queue.Count > 5)
				{
					bufferQueue2.allocCount--;
					T[] array2 = bufferQueue2.queue.Dequeue();
				}
			}
		}
	}

	public void Print()
	{
	}
}
