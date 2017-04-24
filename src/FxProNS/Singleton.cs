using System;

namespace FxProNS
{
	public abstract class Singleton<T> where T : class, new()
	{
		private static T instance;

		public static T Instance
		{
			get
			{
				if (Singleton<T>.Compare<T>((T)((object)null), Singleton<T>.instance))
				{
					Singleton<T>.instance = Activator.CreateInstance<T>();
				}
				return Singleton<T>.instance;
			}
		}

		private static bool Compare<T>(T x, T y) where T : class
		{
			return x == y;
		}
	}
}
