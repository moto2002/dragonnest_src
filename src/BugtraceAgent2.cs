using System;
using UnityEngine;

public sealed class BugtraceAgent2
{
	private static bool _isInitialized;

	public static void EnableExceptionHandler()
	{
		if (BugtraceAgent2._isInitialized)
		{
			return;
		}
		BugtraceAgent2.RegisterExceptionHandler();
		BugtraceAgent2._isInitialized = true;
	}

	public static void DisableExceptionHandler()
	{
		if (!BugtraceAgent2._isInitialized)
		{
			return;
		}
		BugtraceAgent2.UnregisterExceptionHandler();
		BugtraceAgent2._isInitialized = false;
	}

	private static void RegisterExceptionHandler()
	{
	}

	private static void UnregisterExceptionHandler()
	{
	}

	private static void LogCallbackHandler(string condition, string stack, LogType type)
	{
		if (type == LogType.Exception)
		{
			BugtraceAgent2.HandleException(condition, stack);
		}
	}

	private static void UncaughtExceptionHandler(object sender, UnhandledExceptionEventArgs args)
	{
		Exception ex = (Exception)args.ExceptionObject;
		if (ex != null)
		{
			BugtraceAgent2.HandleException(ex.Message, ex.StackTrace);
		}
	}

	private static void HandleException(string reason, string stack)
	{
		string text = "crash-reportcsharpexception|";
		text = text + "cause:" + reason;
		text = text + "stack:" + stack;
		try
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tencent.tp.TssJavaMethod");
			if (androidJavaClass != null)
			{
				androidJavaClass.CallStatic("sendCmd", new object[]
				{
					text
				});
			}
		}
		catch
		{
		}
	}
}
