using System;
using System.Collections.Generic;

public class XDataPool<T> where T : XDataBase, new()
{
	private static Queue<T> _pool = new Queue<T>();

	public static T GetData()
	{
		if (XDataPool<T>._pool.Count > 0)
		{
			T result = XDataPool<T>._pool.Dequeue();
			result.Init();
			return result;
		}
		T result2 = Activator.CreateInstance<T>();
		result2.Init();
		return result2;
	}

	public static void Recycle(T data)
	{
		XDataPool<T>._pool.Enqueue(data);
	}
}
