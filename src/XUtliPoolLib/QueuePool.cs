using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class QueuePool<T>
	{
		private static readonly ObjectPool<Queue<T>> s_Pool = new ObjectPool<Queue<T>>(new ObjectPool<Queue<T>>.CreateObj(QueuePool<T>.Create), delegate(Queue<T> l)
		{
			l.Clear();
		}, delegate(Queue<T> l)
		{
			l.Clear();
		});

		public static Queue<T> Create()
		{
			return new Queue<T>();
		}

		public static Queue<T> Get()
		{
			return QueuePool<T>.s_Pool.Get();
		}

		public static void Release(Queue<T> toRelease)
		{
			QueuePool<T>.s_Pool.Release(toRelease);
		}
	}
}
