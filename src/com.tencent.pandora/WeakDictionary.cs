using System;
using System.Collections.Generic;

namespace com.tencent.pandora
{
	public class WeakDictionary<K, V>
	{
		private Dictionary<K, WeakReference> _dict = new Dictionary<K, WeakReference>();

		public V this[K key]
		{
			get
			{
				WeakReference weakReference = this._dict[key];
				if (weakReference.IsAlive)
				{
					return (V)((object)weakReference.Target);
				}
				return default(V);
			}
			set
			{
				this.Add(key, value);
			}
		}

		private ICollection<K> Keys
		{
			get
			{
				return this._dict.Keys;
			}
		}

		private ICollection<V> Values
		{
			get
			{
				List<V> list = new List<V>();
				foreach (K current in this._dict.Keys)
				{
					list.Add((V)((object)this._dict[current].Target));
				}
				return list;
			}
		}

		private void Add(K key, V value)
		{
			if (this._dict.ContainsKey(key))
			{
				if (this._dict[key].IsAlive)
				{
					throw new ArgumentException("key exists");
				}
				this._dict[key].Target = value;
			}
			else
			{
				WeakReference value2 = new WeakReference(value);
				this._dict.Add(key, value2);
			}
		}

		private bool ContainsKey(K key)
		{
			return this._dict.ContainsKey(key);
		}

		private bool Remove(K key)
		{
			return this._dict.Remove(key);
		}

		private bool TryGetValue(K key, out V value)
		{
			WeakReference weakReference;
			if (this._dict.TryGetValue(key, out weakReference))
			{
				value = (V)((object)weakReference.Target);
				return true;
			}
			value = default(V);
			return false;
		}
	}
}
