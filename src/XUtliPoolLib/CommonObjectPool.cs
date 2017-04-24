using System;

namespace XUtliPoolLib
{
	public class CommonObjectPool<T> where T : new()
	{
		private static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(new ObjectPool<T>.CreateObj(CommonObjectPool<T>.Create), null, null);

		public static T Create()
		{
			if (default(T) != null)
			{
				return default(T);
			}
			return Activator.CreateInstance<T>();
		}

		public static T Get()
		{
			return CommonObjectPool<T>.s_Pool.Get();
		}

		public static void Release(T toRelease)
		{
			CommonObjectPool<T>.s_Pool.Release(toRelease);
		}
	}
}
