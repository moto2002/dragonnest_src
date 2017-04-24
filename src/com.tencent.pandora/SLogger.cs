using System;

namespace com.tencent.pandora
{
	internal class SLogger
	{
		public static void Log(string msg)
		{
			Logger.Log(msg);
		}

		public static void LogError(string msg)
		{
			Logger.LogError(msg);
		}

		public static void LogWarning(string msg)
		{
			Logger.LogWarning(msg);
		}
	}
}
