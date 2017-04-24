using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	internal class XHeap<T> where T : IComparable<T>, IHere
	{
		private List<T> _heap;

		private int _heapSize;

		public int HeapSize
		{
			get
			{
				return this._heapSize;
			}
		}

		public XHeap()
		{
			this._heap = new List<T>();
			this._heapSize = 0;
		}

		public void PushHeap(T item)
		{
			int count = this._heap.Count;
			if (this._heapSize < count)
			{
				this._heap[this._heapSize] = item;
			}
			else
			{
				this._heap.Add(item);
			}
			item.Here = this._heapSize;
			XHeap<T>.HeapifyUp(this._heap, this._heapSize);
			this._heapSize++;
		}

		public T PopHeap()
		{
			T result = default(T);
			if (this._heapSize > 0)
			{
				this._heapSize--;
				XHeap<T>.Swap(this._heap, 0, this._heapSize);
				XHeap<T>.HeapifyDown(this._heap, 0, this._heapSize);
				result = this._heap[this._heapSize];
				result.Here = -1;
				this._heap[this._heapSize] = default(T);
			}
			return result;
		}

		public void PopHeapAt(int Idx)
		{
			if (this._heapSize > 0 && Idx >= 0 && Idx < this._heapSize)
			{
				this._heapSize--;
				XHeap<T>.Swap(this._heap, Idx, this._heapSize);
				T t = this._heap[this._heapSize];
				if (t.CompareTo(this._heap[Idx]) < 0)
				{
					XHeap<T>.HeapifyDown(this._heap, Idx, this._heapSize);
				}
				else
				{
					T t2 = this._heap[this._heapSize];
					if (t2.CompareTo(this._heap[Idx]) > 0)
					{
						XHeap<T>.HeapifyUp(this._heap, Idx);
					}
				}
				T t3 = this._heap[this._heapSize];
				t3.Here = -1;
				this._heap[this._heapSize] = default(T);
			}
		}

		public void Adjust(T item, bool downwords)
		{
			if (this._heapSize > 1)
			{
				if (downwords)
				{
					XHeap<T>.HeapifyDown(this._heap, item.Here, this._heapSize);
					return;
				}
				XHeap<T>.HeapifyUp(this._heap, item.Here);
			}
		}

		public static void MakeHeap(List<T> list)
		{
			for (int i = list.Count / 2 - 1; i >= 0; i--)
			{
				XHeap<T>.HeapifyDown(list, i, list.Count);
			}
		}

		public static void HeapSort(List<T> list)
		{
			if (list.Count < 2)
			{
				return;
			}
			XHeap<T>.MakeHeap(list);
			for (int i = list.Count - 1; i > 0; i--)
			{
				XHeap<T>.Swap(list, 0, i);
				XHeap<T>.HeapifyDown(list, 0, i);
			}
		}

		public T Peek()
		{
			if (this._heapSize > 0)
			{
				return this._heap[0];
			}
			return default(T);
		}

		public void Clear()
		{
			this._heap.Clear();
			this._heapSize = 0;
		}

		private static void HeapifyDown(List<T> heap, int curIdx, int heapSize)
		{
			while (curIdx < heapSize)
			{
				int num = 2 * curIdx + 1;
				int num2 = 2 * curIdx + 2;
				T other = heap[curIdx];
				int num3 = curIdx;
				if (num < heapSize)
				{
					T t = heap[num];
					if (t.CompareTo(other) < 0)
					{
						other = heap[num];
						num3 = num;
					}
				}
				if (num2 < heapSize)
				{
					T t2 = heap[num2];
					if (t2.CompareTo(other) < 0)
					{
						other = heap[num2];
						num3 = num2;
					}
				}
				if (num3 == curIdx)
				{
					break;
				}
				XHeap<T>.Swap(heap, curIdx, num3);
				curIdx = num3;
			}
		}

		private static void HeapifyUp(List<T> heap, int curIdx)
		{
			while (curIdx > 0)
			{
				int num = (curIdx - 1) / 2;
				T other = heap[num];
				int num2 = num;
				if (num >= 0)
				{
					T t = heap[curIdx];
					if (t.CompareTo(other) < 0)
					{
						num2 = curIdx;
					}
				}
				if (num2 == num)
				{
					break;
				}
				XHeap<T>.Swap(heap, num, num2);
				curIdx = num;
			}
		}

		private static void Swap(List<T> heap, int x, int y)
		{
			T value = heap[x];
			heap[x] = heap[y];
			T t = heap[x];
			t.Here = x;
			heap[y] = value;
			T t2 = heap[y];
			t2.Here = y;
		}
	}
}
