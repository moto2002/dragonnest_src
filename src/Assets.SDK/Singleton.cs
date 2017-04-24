using System;
using System.Reflection;

namespace Assets.SDK
{
	public static class Singleton<T> where T : class
	{
		internal static volatile T _instance;

		private static object _lock = new object();

		public static T GetInstance()
		{
			if (Singleton<T>._instance == null)
			{
				object @lock = Singleton<T>._lock;
				lock (@lock)
				{
					if (Singleton<T>._instance == null)
					{
						Type typeFromHandle = typeof(T);
						ConstructorInfo constructor = typeFromHandle.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], new ParameterModifier[0]);
						Singleton<T>._instance = (constructor.Invoke(new object[0]) as T);
						if (Singleton<T>._instance == null)
						{
							throw new Exception("Singleton<T> : T must have a none public ctor.");
						}
					}
				}
			}
			return Singleton<T>._instance;
		}
	}
}
