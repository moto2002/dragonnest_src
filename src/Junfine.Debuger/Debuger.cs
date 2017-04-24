using System;
using UnityEngine;

namespace Junfine.Debuger
{
	public class Debuger
	{
		public static bool enableLog = true;

		public static void Log(string str, params object[] args)
		{
			if (!Debuger.enableLog)
			{
				return;
			}
			str = string.Format(str, args);
			Debug.Log(str);
		}

		public static void LogWarning(string str, params object[] args)
		{
			if (!Debuger.enableLog)
			{
				return;
			}
			str = string.Format(str, args);
			Debug.LogWarning(str);
		}

		public static void LogError(string str, params object[] args)
		{
			if (!Debuger.enableLog)
			{
				return;
			}
			str = string.Format(str, args);
			Debug.LogError(str);
		}
	}
}
