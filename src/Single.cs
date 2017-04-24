using System;

public class Single<T> where T : new()
{
	private static T s_instance;

	public static T Instance
	{
		get
		{
			return Single<T>.GetInstance();
		}
	}

	protected Single()
	{
	}

	public static void CreateInstance()
	{
		if (Single<T>.s_instance == null)
		{
			Single<T>.s_instance = ((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
			(Single<T>.s_instance as Single<T>).Init();
		}
	}

	public static void DestroyInstance()
	{
		if (Single<T>.s_instance != null)
		{
			(Single<T>.s_instance as Single<T>).UnInit();
			Single<T>.s_instance = default(T);
		}
	}

	public static T GetInstance()
	{
		if (Single<T>.s_instance == null)
		{
			Single<T>.CreateInstance();
		}
		return Single<T>.s_instance;
	}

	public static bool HasInstance()
	{
		return Single<T>.s_instance != null;
	}

	public virtual void Init()
	{
	}

	public virtual void UnInit()
	{
	}
}
