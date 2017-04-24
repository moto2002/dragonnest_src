using System;
using System.Reflection;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class AndroidJavaObjectWrapper
	{
		private static Assembly a;

		private static Type b;

		public static readonly string AndoridJavaObjectName = "UnityEngine.AndroidJavaObject, UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";

		private static MethodInfo c;

		private static MethodInfo d;

		private static MethodInfo e;

		private static MethodInfo f;

		private object[] g;

		private object h;

		private static void a()
		{
			if (AndroidJavaObjectWrapper.a == null)
			{
				AndroidJavaObjectWrapper.a = typeof(GameObject).Assembly;
				AndroidJavaObjectWrapper.b = AndroidJavaObjectWrapper.a.GetType("UnityEngine.AndroidJavaObject");
				MethodInfo[] methods = AndroidJavaObjectWrapper.b.GetMethods();
				MethodInfo[] array = methods;
				for (int i = 0; i < array.Length; i++)
				{
					MethodInfo methodInfo = array[i];
					if (methodInfo != null && methodInfo.Name.Equals("CallStatic") && methodInfo.ReturnType == typeof(void))
					{
						AndroidJavaObjectWrapper.d = methodInfo;
					}
					else if (methodInfo != null && methodInfo.Name.Equals("CallStatic") && methodInfo.ReturnType.ToString().Equals("ReturnType"))
					{
						AndroidJavaObjectWrapper.f = methodInfo;
					}
					else if (methodInfo != null && methodInfo.Name.Equals("Call") && methodInfo.ReturnType == typeof(void))
					{
						AndroidJavaObjectWrapper.c = methodInfo;
					}
					else if (methodInfo != null && methodInfo.Name.Equals("Call") && methodInfo.ReturnType.ToString().Equals("ReturnType"))
					{
						AndroidJavaObjectWrapper.e = methodInfo;
					}
				}
			}
		}

		public AndroidJavaObjectWrapper(string className, params object[] args)
		{
			AndroidJavaObjectWrapper.a();
			this.h = AndroidJavaObjectWrapper.a.CreateInstance("UnityEngine.AndroidJavaObject", true, BindingFlags.Default, null, new object[]
			{
				className,
				args
			}, null, null);
		}

		public void setAndroidJavaObjectWrapper(object obj)
		{
			this.h = obj;
		}

		public void CallStatic(string methodName, params object[] args)
		{
			AndroidJavaObjectWrapper.d.Invoke(this.h, new object[]
			{
				methodName,
				args
			});
		}

		public void Call(string methodName, params object[] args)
		{
			AndroidJavaObjectWrapper.c.Invoke(this.h, new object[]
			{
				methodName,
				args
			});
		}
	}
}
