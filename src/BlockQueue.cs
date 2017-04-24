using System;
using System.Collections.Generic;
using System.Threading;

public class BlockQueue<T>
{
	private readonly Queue<T> a = new Queue<T>();

	public int Count
	{
		get
		{
			int count;
			lock (this.a)
			{
				count = this.a.Count;
			}
			return count;
		}
	}

	public void Enqueue(T item)
	{
		lock (this.a)
		{
			this.a.Enqueue(item);
			if (this.a.Count == 1)
			{
				Monitor.PulseAll(this.a);
			}
		}
	}

	public T Dequeue()
	{
		T result;
		lock (this.a)
		{
			while (this.a.Count == 0)
			{
				Monitor.Wait(this.a);
			}
			T t = this.a.Dequeue();
			result = t;
		}
		return result;
	}
}
