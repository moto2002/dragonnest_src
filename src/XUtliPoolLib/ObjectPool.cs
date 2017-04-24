using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace XUtliPoolLib
{
	public class ObjectPool<T> : IObjectPool
	{
		public delegate T CreateObj();

		private readonly Stack<T> m_Stack = new Stack<T>();

		private readonly UnityAction<T> m_ActionOnGet;

		private readonly UnityAction<T> m_ActionOnRelease;

		private ObjectPool<T>.CreateObj m_objCreator;

		public static readonly List<IObjectPool> s_AllPool = new List<IObjectPool>();

		public int countAll
		{
			get;
			private set;
		}

		public int countActive
		{
			get
			{
				return this.countAll - this.countInactive;
			}
		}

		public int countInactive
		{
			get
			{
				return this.m_Stack.Count;
			}
		}

		public ObjectPool(ObjectPool<T>.CreateObj creator, UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
			this.m_objCreator = creator;
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
			ObjectPool<T>.s_AllPool.Add(this);
		}

		public T Get()
		{
			T t;
			if (this.m_Stack.Count == 0)
			{
				t = this.m_objCreator();
				this.countAll++;
			}
			else
			{
				t = this.m_Stack.Pop();
			}
			if (this.m_ActionOnGet != null)
			{
				this.m_ActionOnGet(t);
			}
			return t;
		}

		public void Release(T element)
		{
			if (this.m_ActionOnRelease != null)
			{
				this.m_ActionOnRelease(element);
			}
			this.m_Stack.Push(element);
		}

		public void Clear()
		{
			ObjectPool<T>.s_AllPool.Clear();
		}
	}
}
