using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class CrashMonitor
	{
		public delegate void OnUncaughtExceptionReport(string type, string message, string stackTrace, bool caught);

		public static bool selfCheck = false;

		public static readonly string SELF_CHECK = "WETEST_REGISTER_SELF_CHECK";

		private static int a = 0;

		private static int b = 100;

		private static bool c = false;

		private static int d = 100;

		private static int e = 0;

		private static bool f = false;

		public static bool CLOSE_MONITOR = false;

		private static CrashMonitor.OnUncaughtExceptionReport g;

		public static AndroidJavaObjectWrapper _wetestAgent = null;

		public static readonly string CLASS_UNITYAGENT = "com.tencent.wetest.WetestReport";

		private static Application.LogCallback h = new Application.LogCallback(CrashMonitor._OnLogCallbackHandler);

		public static event CrashMonitor.OnUncaughtExceptionReport UncaughtExceptionReport
		{
			add
			{
				CrashMonitor.OnUncaughtExceptionReport onUncaughtExceptionReport = CrashMonitor.g;
				CrashMonitor.OnUncaughtExceptionReport onUncaughtExceptionReport2;
				do
				{
					onUncaughtExceptionReport2 = onUncaughtExceptionReport;
					CrashMonitor.OnUncaughtExceptionReport value2 = (CrashMonitor.OnUncaughtExceptionReport)Delegate.Combine(onUncaughtExceptionReport2, value);
					onUncaughtExceptionReport = Interlocked.CompareExchange<CrashMonitor.OnUncaughtExceptionReport>(ref CrashMonitor.g, value2, onUncaughtExceptionReport2);
				}
				while (onUncaughtExceptionReport != onUncaughtExceptionReport2);
			}
			remove
			{
				CrashMonitor.OnUncaughtExceptionReport onUncaughtExceptionReport = CrashMonitor.g;
				CrashMonitor.OnUncaughtExceptionReport onUncaughtExceptionReport2;
				do
				{
					onUncaughtExceptionReport2 = onUncaughtExceptionReport;
					CrashMonitor.OnUncaughtExceptionReport value2 = (CrashMonitor.OnUncaughtExceptionReport)Delegate.Remove(onUncaughtExceptionReport2, value);
					onUncaughtExceptionReport = Interlocked.CompareExchange<CrashMonitor.OnUncaughtExceptionReport>(ref CrashMonitor.g, value2, onUncaughtExceptionReport2);
				}
				while (onUncaughtExceptionReport != onUncaughtExceptionReport2);
			}
		}

		public static AndroidJavaObjectWrapper WetestAgent
		{
			get
			{
				if (CrashMonitor._wetestAgent == null)
				{
					try
					{
						CrashMonitor._wetestAgent = new AndroidJavaObjectWrapper(CrashMonitor.CLASS_UNITYAGENT, new object[0]);
					}
					catch (Exception ex)
					{
						u.a(ex.Message + ex.StackTrace);
					}
				}
				return CrashMonitor._wetestAgent;
			}
		}

		[DllImport("crashmonitor")]
		private static extern void InitWetestCrashMonitor();

		[DllImport("crashmonitor")]
		private static extern void ReInitWetestCrashMonitor();

		public static void LogErrorProxy(string type, string message, string stackTrace, string scene, bool uncaught)
		{
			try
			{
				CrashMonitor.WetestAgent.CallStatic("logError", new object[]
				{
					type,
					message,
					stackTrace,
					scene,
					uncaught
				});
			}
			catch (Exception ex)
			{
				u.b(ex.Message);
			}
		}

		public void UnregisterExceptionHandler()
		{
			AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CrashMonitor.a);
			Application.RegisterLogCallback(null);
		}

		public static void RegisterExceptionHandler()
		{
			if (!CrashMonitor.f && !CrashMonitor.CLOSE_MONITOR)
			{
				u.c("Register Exception Handler");
				CrashMonitor.f = true;
				try
				{
					CrashMonitor.UncaughtExceptionReport += new CrashMonitor.OnUncaughtExceptionReport(CrashMonitor.DefaultReportException);
					AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CrashMonitor.a);
					u.c("Current Domain is default domain?" + (AppDomain.CurrentDomain.IsDefaultAppDomain() ? "True" : "False"));
					u.c("Register jvm crash monitor");
					CrashMonitor.WetestAgent.CallStatic("initCrashReport", new object[0]);
					u.c("Register native crash monitor");
					CrashMonitor.InitWetestCrashMonitor();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Register error\n" + ex.Message + "\n" + ex.StackTrace);
					CrashMonitor.CLOSE_MONITOR = true;
				}
			}
		}

		private static void a(object A_0, UnhandledExceptionEventArgs A_1)
		{
			if (A_1 == null || A_1.ExceptionObject == null)
			{
				return;
			}
			try
			{
				if (A_1.ExceptionObject.GetType() != typeof(Exception))
				{
					return;
				}
			}
			catch
			{
				if (UnityEngine.Debug.isDebugBuild)
				{
					UnityEngine.Debug.Log("<WeTestLog>:Failed to get uncaught exception");
				}
				return;
			}
			CrashMonitor.a((Exception)A_1.ExceptionObject, null, true);
		}

		private static void a(Exception A_0, string A_1, bool A_2)
		{
			if (A_0 == null)
			{
				return;
			}
			string name = A_0.GetType().Name;
			string text = A_0.Message;
			if (!string.IsNullOrEmpty(A_1))
			{
				text = string.Format("{0}{1}---{2}", text, Environment.NewLine, A_1);
			}
			StringBuilder stringBuilder = new StringBuilder("");
			StackTrace stackTrace = new StackTrace(A_0, true);
			int frameCount = stackTrace.FrameCount;
			for (int i = 0; i < frameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				stringBuilder.AppendFormat("{0}.{1}", frame.GetMethod().DeclaringType.Name, frame.GetMethod().Name);
				ParameterInfo[] parameters = frame.GetMethod().GetParameters();
				if (parameters == null || parameters.Length == 0)
				{
					stringBuilder.Append(" () ");
				}
				else
				{
					stringBuilder.Append(" (");
					int num = parameters.Length;
					for (int j = 0; j < num; j++)
					{
						ParameterInfo parameterInfo = parameters[j];
						stringBuilder.AppendFormat("{0} {1}", parameterInfo.ParameterType.Name, parameterInfo.Name);
						if (j != num - 1)
						{
							stringBuilder.Append(", ");
						}
					}
					stringBuilder.Append(") ");
				}
				string text2 = frame.GetFileName();
				if (!string.IsNullOrEmpty(text2) && !text2.ToLower().Equals("unknown"))
				{
					text2 = text2.Replace("\\", "/");
					int num2 = text2.ToLower().IndexOf("/assets/");
					if (num2 < 0)
					{
						num2 = text2.ToLower().IndexOf("assets/");
					}
					if (num2 > 0)
					{
						text2 = text2.Substring(num2);
					}
					stringBuilder.AppendFormat("(at {0}:{1})", text2, frame.GetFileLineNumber());
				}
				stringBuilder.AppendLine();
			}
			CrashMonitor.g("UnhandleCaught  " + name, text, stringBuilder.ToString(), true);
		}

		public static void _OnLogCallbackHandler(string condition, string stackTrace, LogType type)
		{
			if (LogType.Log == type)
			{
				return;
			}
			if (!string.IsNullOrEmpty(condition) && condition.Contains("<WeTestLog>"))
			{
				return;
			}
			if (condition.Contains(CrashMonitor.SELF_CHECK))
			{
				CrashMonitor.selfCheck = true;
				return;
			}
			CrashMonitor.a(type, condition, stackTrace);
		}

		public static Application.LogCallback getLogCallBackHandler()
		{
			return new Application.LogCallback(CrashMonitor._OnLogCallbackHandler);
		}

		private static void a(LogType A_0, string A_1, string A_2)
		{
			string text = null;
			string text2 = null;
			if (A_0 != LogType.Exception)
			{
				return;
			}
			if (!string.IsNullOrEmpty(A_1))
			{
				try
				{
					if (LogType.Exception == A_0 && A_1.Contains("Exception"))
					{
						Match match = new Regex("^(?<errorType>\\S+):\\s*(?<errorMessage>.*)").Match(A_1);
						if (match.Success)
						{
							text = match.Groups["errorType"].Value;
							text2 = match.Groups["errorMessage"].Value.Trim();
						}
					}
				}
				catch
				{
				}
				if (string.IsNullOrEmpty(text2))
				{
					text2 = A_1;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				text = string.Format("Unity{0}", A_0.ToString());
			}
			bool caught = true;
			CrashMonitor.g(text, text2, A_2, caught);
		}

		public static void DefaultReportException(string type, string message, string stackTrace, bool uncaught)
		{
			try
			{
				string loadedLevelName = Application.loadedLevelName;
				CrashMonitor.LogErrorProxy(type, message, stackTrace, loadedLevelName, uncaught);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
			}
		}

		public static void SelfCheck()
		{
			if (CrashMonitor.CLOSE_MONITOR)
			{
				return;
			}
			CrashMonitor.a++;
			if (CrashMonitor.a % CrashMonitor.b == 0)
			{
				CrashMonitor.c = true;
				UnityEngine.Debug.LogWarning(CrashMonitor.SELF_CHECK);
				if (CrashMonitor.b < 214748364)
				{
					CrashMonitor.b *= 2;
				}
				return;
			}
			if (CrashMonitor.c && !CrashMonitor.selfCheck)
			{
				CrashMonitor.ReRegisterExceptionHandler();
				CrashMonitor.a = 0;
				CrashMonitor.selfCheck = false;
				CrashMonitor.c = false;
				CrashMonitor.b *= 2;
			}
		}

		public static void NativeCrashMonitorCheck()
		{
			if (CrashMonitor.CLOSE_MONITOR)
			{
				return;
			}
			CrashMonitor.e++;
			if (CrashMonitor.e % CrashMonitor.d == 0)
			{
				CrashMonitor.e = 0;
				try
				{
					CrashMonitor.ReInitWetestCrashMonitor();
				}
				catch (Exception ex)
				{
					u.a(ex.Message + " " + ex.StackTrace);
					CrashMonitor.CLOSE_MONITOR = true;
				}
			}
		}

		public static void ReRegisterExceptionHandler()
		{
			u.c("Register Exception Handler,Agine");
			CrashMonitor.f = true;
			try
			{
				Application.RegisterLogCallback(new Application.LogCallback(CrashMonitor._OnLogCallbackHandler));
				CrashMonitor.InitWetestCrashMonitor();
			}
			catch (Exception)
			{
				Console.WriteLine("Register error");
				CrashMonitor.CLOSE_MONITOR = true;
			}
		}
	}
}
