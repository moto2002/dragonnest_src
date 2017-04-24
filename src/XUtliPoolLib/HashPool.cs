using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class HashPool<T>
	{
		private static readonly ObjectPool<HashSet<T>> s_Pool = new ObjectPool<HashSet<T>>(new ObjectPool<HashSet<T>>.CreateObj(HashPool<T>.Create), delegate(HashSet<T> l)
		{
			l.Clear();
		}, delegate(HashSet<T> l)
		{
			l.Clear();
		});

		public static HashSet<T> Create()
		{
			return new HashSet<T>();
		}

		public static HashSet<T> Get()
		{
			return HashPool<T>.s_Pool.Get();
		}

		public static void Release(HashSet<T> toRelease)
		{
			HashPool<T>.s_Pool.Release(toRelease);
		}
	}
}
