using System;
using UnityEngine;

public sealed class BugtraceAgent
{
	private const string SDK_PACKAGE = "com.tencent.tp.bugtrace";

	private static bool _isInitialized;

	private static readonly string CLASS_UNITYAGENT = "com.tencent.tp.bugtrace.BugtraceAgent";

	private static AndroidJavaObject _unityAgent;

	public static AndroidJavaObject UnityAgent
	{
		get
		{
			if (BugtraceAgent._unityAgent == null)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(BugtraceAgent.CLASS_UNITYAGENT))
				{
					BugtraceAgent._unityAgent = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
				}
			}
			return BugtraceAgent._unityAgent;
		}
	}

	public static void EnableExceptionHandler()
	{
		if (BugtraceAgent._isInitialized)
		{
			return;
		}
		BugtraceAgent.RegisterExceptionHandler();
		BugtraceAgent._isInitialized = true;
	}

	public static void DisableExceptionHandler()
	{
		if (!BugtraceAgent._isInitialized)
		{
			return;
		}
		BugtraceAgent.UnregisterExceptionHandler();
		BugtraceAgent._isInitialized = false;
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
			BugtraceAgent.HandleException(condition, stack);
		}
	}

	private static void UncaughtExceptionHandler(object sender, UnhandledExceptionEventArgs args)
	{
		Exception ex = (Exception)args.ExceptionObject;
		if (ex != null)
		{
			BugtraceAgent.HandleException(ex.Message, ex.StackTrace);
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
