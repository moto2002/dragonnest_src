using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class ListPool<T>
	{
		private static readonly ObjectPool<List<T>> s_Pool = new ObjectPool<List<T>>(new ObjectPool<List<T>>.CreateObj(ListPool<T>.Create), delegate(List<T> l)
		{
			l.Clear();
		}, delegate(List<T> l)
		{
			l.Clear();
		});

		public static List<T> Create()
		{
			return new List<T>();
		}

		public static List<T> Get()
		{
			return ListPool<T>.s_Pool.Get();
		}

		public static void Release(List<T> toRelease)
		{
			ListPool<T>.s_Pool.Release(toRelease);
		}
	}
}
