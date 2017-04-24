using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class DictionaryPool<K, V>
	{
		private static readonly ObjectPool<Dictionary<K, V>> s_Pool = new ObjectPool<Dictionary<K, V>>(new ObjectPool<Dictionary<K, V>>.CreateObj(DictionaryPool<K, V>.Create), delegate(Dictionary<K, V> l)
		{
			l.Clear();
		}, delegate(Dictionary<K, V> l)
		{
			l.Clear();
		});

		public static Dictionary<K, V> Create()
		{
			return new Dictionary<K, V>();
		}

		public static Dictionary<K, V> Get()
		{
			return DictionaryPool<K, V>.s_Pool.Get();
		}

		public static void Release(Dictionary<K, V> toRelease)
		{
			DictionaryPool<K, V>.s_Pool.Release(toRelease);
		}
	}
}
