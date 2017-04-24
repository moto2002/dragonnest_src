using System;
using System.Collections;
using System.IO;
using System.Reflection;
using UnityEngine;
using WeTest.U3DAutomation;

namespace Dynamic
{
	public class ThirdManager
	{
		public static ThirdManager instance_ = new ThirdManager();

		public Assembly third_assembly_;

		public static ThirdManager INSTANCE
		{
			get
			{
				return ThirdManager.instance_;
			}
		}

		public void Initialize()
		{
			ThirdManager.INSTANCE.LoadCSharpScript("/data/local/tmp/wetest.u3dautomation.dll");
			ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "Entry");
		}

		public bool IsFileLoaded()
		{
			return this.third_assembly_ != null;
		}

		public void LoadCSharpScript(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					FileStream fileStream = new FileStream(path, FileMode.Open);
					byte[] array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					fileStream.Close();
					this.third_assembly_ = Assembly.Load(array);
				}
			}
			catch (Exception message)
			{
				this.third_assembly_ = null;
				Debug.Log("Find no dynamic lib file.");
				Debug.Log(message);
			}
		}

		public object InvokeStaticFunction(string cls, string func)
		{
			if (!this.IsFileLoaded())
			{
				return null;
			}
			Type type = this.third_assembly_.GetType(cls);
			MethodInfo method = type.GetMethod(func);
			return method.Invoke(null, null);
		}

		public object InvokeFunction(object obj, string cls, string func)
		{
			if (!this.IsFileLoaded())
			{
				return null;
			}
			Type type = this.third_assembly_.GetType(cls);
			MethodInfo method = type.GetMethod(func);
			return method.Invoke(obj, null);
		}

		public static object GetInstance()
		{
			return ThirdManager.INSTANCE;
		}

		public static bool Entry()
		{
			Debug.Log("third entry.");
			return false;
		}

		public static void HandleEvent()
		{
			if (!ThirdManager.INSTANCE.IsFileLoaded())
			{
				m.a().h();
				return;
			}
			ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "HandleEvent");
		}

		public static IEnumerator HandleCommand()
		{
			IEnumerator result;
			if (!ThirdManager.INSTANCE.IsFileLoaded())
			{
				result = m.a().g();
			}
			else
			{
				result = (IEnumerator)ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "HandleCommand");
			}
			return result;
		}

		public static void Start()
		{
			if (!ThirdManager.INSTANCE.IsFileLoaded())
			{
				b.b();
				return;
			}
			ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "Start");
		}

		public static void getAndroidMScreen()
		{
			if (!ThirdManager.INSTANCE.IsFileLoaded())
			{
				r.a();
				return;
			}
			ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "getAndroidMScreen");
		}

		public static void FrameUpdate()
		{
			ThirdManager.ComputeFPS();
			ThirdManager.CrashMonitorSelfCheck();
		}

		public static void ComputeFPS()
		{
			if (!ThirdManager.INSTANCE.IsFileLoaded())
			{
				m.a().c();
				return;
			}
			ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "ComputeFPS");
		}

		public static void CrashMonitorSelfCheck()
		{
			if (!ThirdManager.INSTANCE.IsFileLoaded())
			{
				CrashMonitor.SelfCheck();
				CrashMonitor.NativeCrashMonitorCheck();
				return;
			}
			ThirdManager.INSTANCE.InvokeStaticFunction("Dynamic.ThirdManager", "CrashMonitorSelfCheck");
		}
	}
}
