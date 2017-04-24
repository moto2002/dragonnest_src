using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class BetterList<T>
	{
		public delegate int CompareFunc(T left, T right);

		[CompilerGenerated]
		private sealed class <GetEnumerator>d__0 : IEnumerator<T>
		{
			private T a;

			private int b;

			public BetterList<T> c;

			public int d;

			bool IEnumerator.f()
			{
				switch (this.b)
				{
				case 0:
					this.b = -1;
					if (this.c.buffer == null)
					{
						return false;
					}
					this.d = 0;
					break;
				case 1:
					this.b = -1;
					this.d++;
					break;
				default:
					return false;
				}
				if (this.d < this.c.size)
				{
					this.a = this.c.buffer[this.d];
					this.b = 1;
					return true;
				}
				return false;
			}

			[DebuggerHidden]
			T IEnumerator<T>.a()
			{
				return this.a;
			}

			[DebuggerHidden]
			void IEnumerator.e()
			{
				throw new NotSupportedException();
			}

			void IDisposable.b()
			{
			}

			[DebuggerHidden]
			object IEnumerator.g()
			{
				return this.a;
			}

			[DebuggerHidden]
			public <GetEnumerator>d__0(int A_0)
			{
				this.b = A_0;
			}
		}

		public T[] buffer;

		public int size;

		[DebuggerHidden]
		public T this[int i]
		{
			get
			{
				return this.buffer[i];
			}
			set
			{
				this.buffer[i] = value;
			}
		}

		[DebuggerHidden, DebuggerStepThrough]
		public IEnumerator<T> GetEnumerator()
		{
			BetterList<T>.<GetEnumerator>d__0 <GetEnumerator>d__ = new BetterList<T>.<GetEnumerator>d__0(0);
			<GetEnumerator>d__.c = this;
			return <GetEnumerator>d__;
		}

		private void b()
		{
			T[] array = (this.buffer != null) ? new T[Mathf.Max(this.buffer.Length << 1, 32)] : new T[32];
			if (this.buffer != null && this.size > 0)
			{
				this.buffer.CopyTo(array, 0);
			}
			this.buffer = array;
		}

		private void a()
		{
			if (this.size > 0)
			{
				if (this.size < this.buffer.Length)
				{
					T[] array = new T[this.size];
					for (int i = 0; i < this.size; i++)
					{
						array[i] = this.buffer[i];
					}
					this.buffer = array;
					return;
				}
			}
			else
			{
				this.buffer = null;
			}
		}

		public void Clear()
		{
			this.size = 0;
		}

		public void Release()
		{
			this.size = 0;
			this.buffer = null;
		}

		public void Add(T item)
		{
			if (this.buffer == null || this.size == this.buffer.Length)
			{
				this.b();
			}
			this.buffer[this.size++] = item;
		}

		public void Insert(int index, T item)
		{
			if (this.buffer == null || this.size == this.buffer.Length)
			{
				this.b();
			}
			if (index > -1 && index < this.size)
			{
				for (int i = this.size; i > index; i--)
				{
					this.buffer[i] = this.buffer[i - 1];
				}
				this.buffer[index] = item;
				this.size++;
				return;
			}
			this.Add(item);
		}

		public bool Contains(T item)
		{
			if (this.buffer == null)
			{
				return false;
			}
			for (int i = 0; i < this.size; i++)
			{
				if (this.buffer[i].Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOf(T item)
		{
			if (this.buffer == null)
			{
				return -1;
			}
			for (int i = 0; i < this.size; i++)
			{
				if (this.buffer[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		public bool Remove(T item)
		{
			if (this.buffer != null)
			{
				EqualityComparer<T> @default = EqualityComparer<T>.Default;
				for (int i = 0; i < this.size; i++)
				{
					if (@default.Equals(this.buffer[i], item))
					{
						this.size--;
						this.buffer[i] = default(T);
						for (int j = i; j < this.size; j++)
						{
							this.buffer[j] = this.buffer[j + 1];
						}
						this.buffer[this.size] = default(T);
						return true;
					}
				}
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			if (this.buffer != null && index > -1 && index < this.size)
			{
				this.size--;
				this.buffer[index] = default(T);
				for (int i = index; i < this.size; i++)
				{
					this.buffer[i] = this.buffer[i + 1];
				}
				this.buffer[this.size] = default(T);
			}
		}

		public T Pop()
		{
			if (this.buffer != null && this.size != 0)
			{
				T result = this.buffer[--this.size];
				this.buffer[this.size] = default(T);
				return result;
			}
			return default(T);
		}

		public T[] ToArray()
		{
			this.a();
			return this.buffer;
		}

		[DebuggerHidden, DebuggerStepThrough]
		public void Sort(BetterList<T>.CompareFunc comparer)
		{
			int num = 0;
			int num2 = this.size - 1;
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = num; i < num2; i++)
				{
					if (comparer(this.buffer[i], this.buffer[i + 1]) > 0)
					{
						T t = this.buffer[i];
						this.buffer[i] = this.buffer[i + 1];
						this.buffer[i + 1] = t;
						flag = true;
					}
					else if (!flag)
					{
						num = ((i == 0) ? 0 : (i - 1));
					}
				}
			}
		}
	}
}
