using System;
using UnityEngine;

namespace com.tencent.pandora
{
	public class Logger : MonoBehaviour
	{
		public enum Level
		{
			Error,
			Warning,
			Info,
			Debug
		}

		public static Action<string, string, Logger.Level> HandleLog;

		public static bool Enable = true;

		public static Logger.Level LogLevel = Logger.Level.Error;

		public static void Log(string message)
		{
			if (Logger.Enable && Logger.LogLevel >= Logger.Level.Debug)
			{
				Debug.Log(message);
			}
			if (Logger.HandleLog != null)
			{
				Logger.HandleLog(message, StackTraceUtility.ExtractStackTrace(), Logger.Level.Debug);
			}
		}

		public static void LogInfo(string message)
		{
			if (Logger.Enable && Logger.LogLevel >= Logger.Level.Info)
			{
				Debug.Log(message);
			}
			if (Logger.HandleLog != null)
			{
				Logger.HandleLog(message, StackTraceUtility.ExtractStackTrace(), Logger.Level.Info);
			}
		}

		public static void LogWarning(string message)
		{
			if (Logger.Enable && Logger.LogLevel >= Logger.Level.Warning)
			{
				Debug.LogWarning(message);
			}
			if (Logger.HandleLog != null)
			{
				Logger.HandleLog(message, StackTraceUtility.ExtractStackTrace(), Logger.Level.Warning);
			}
		}

		public static void LogError(string message)
		{
			if (Logger.Enable && Logger.LogLevel >= Logger.Level.Error)
			{
				Debug.LogWarning(message);
			}
			if (Logger.HandleLog != null)
			{
				Logger.HandleLog(message, StackTraceUtility.ExtractStackTrace(), Logger.Level.Error);
			}
		}
	}
}
