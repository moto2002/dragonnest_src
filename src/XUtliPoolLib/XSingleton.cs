using System;

namespace XUtliPoolLib
{
	public abstract class XSingleton<T> : XBaseSingleton where T : new()
	{
		private static readonly T _instance = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);

		public static T singleton
		{
			get
			{
				return XSingleton<T>._instance;
			}
		}

		protected XSingleton()
		{
			if (XSingleton<T>._instance != null)
			{
				T instance = XSingleton<T>._instance;
				throw new XDoubleNewException(instance.ToString() + " can not be created again.");
			}
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}
	}
}
