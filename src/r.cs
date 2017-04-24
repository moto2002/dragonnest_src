using System;
using System.Reflection;
using UnityEngine;
using WeTest.U3DAutomation;

internal class r
{
	private static r a = new r();

	private static object b;

	private static Type c;

	private static MethodInfo d;

	private static object e;

	private static Assembly f;

	private static i g = null;

	private static MethodInfo h;

	public static r e()
	{
		return r.a;
	}

	private static bool d()
	{
		if (r.f == null)
		{
			r.f = typeof(GameObject).Assembly;
			if (r.f == null)
			{
				return false;
			}
		}
		r.c = r.f.GetType("UnityEngine.AndroidJavaObject");
		if (r.c == null)
		{
			u.b("can't find AndroidJavaObject!");
			return false;
		}
		return true;
	}

	private static bool c()
	{
		if (!r.d())
		{
			u.c("GetAndroidJavaType is false");
			return false;
		}
		MethodInfo[] methods = r.c.GetMethods();
		MethodInfo[] array = methods;
		for (int i = 0; i < array.Length; i++)
		{
			MethodInfo methodInfo = array[i];
			if (methodInfo != null && methodInfo.Name.Equals("CallStatic") && methodInfo.ReturnType == typeof(void))
			{
				r.d = methodInfo;
				break;
			}
		}
		if (r.d == null)
		{
			u.b("can't find CallStatic!");
			return false;
		}
		return true;
	}

	private static bool a(string A_0)
	{
		if (!r.d())
		{
			u.c("GetAndroidJavaType is false");
			return false;
		}
		if (A_0 == null)
		{
			u.b("pameter is null");
			return false;
		}
		MethodInfo[] methods = r.c.GetMethods();
		MethodInfo[] array = methods;
		for (int i = 0; i < array.Length; i++)
		{
			MethodInfo methodInfo = array[i];
			if (methodInfo != null && methodInfo.Name.Equals("CallStatic") && methodInfo.ReturnType.ToString().Equals(A_0))
			{
				r.h = methodInfo;
				break;
			}
		}
		if (r.h == null)
		{
			u.b("can't find scallstatic!");
			return false;
		}
		return true;
	}

	public void a(float A_0, float A_1, MotionEventAction A_2)
	{
		u.d(string.Concat(new object[]
		{
			"Inject Motion event point: ",
			A_0,
			", ",
			A_1
		}));
		u.d("Inject Motion event touch type: " + A_2.ToString());
		if (r.b == null)
		{
			if (!r.c())
			{
				u.b("Inject Motion event error type!");
				return;
			}
			r.b = r.f.CreateInstance("UnityEngine.AndroidJavaClass", true, BindingFlags.Default, null, new object[]
			{
				"com.tencent.wetest.U3DAutomation"
			}, null, null);
		}
		if (r.b == null)
		{
			u.b("Inject Motion event u3dautomation is null!");
			return;
		}
		if (r.d == null && !r.c())
		{
			u.b("mcallstatic == null!");
			return;
		}
		r.d.Invoke(r.b, new object[]
		{
			"InjectTouchEvent",
			new object[]
			{
				(int)A_2,
				A_0,
				A_1
			}
		});
	}

	public void b(float A_0, float A_1)
	{
		this.a(A_0, A_1, MotionEventAction.ACTION_DOWN);
	}

	public void c(float A_0, float A_1)
	{
		this.a(A_0, A_1, MotionEventAction.ACTION_UP);
	}

	public void a(float A_0, float A_1)
	{
		this.a(A_0, A_1, MotionEventAction.ACTION_MOVE);
	}

	public static Point a(GameObject A_0)
	{
		return null;
	}

	public static void b()
	{
		if (r.e == null)
		{
			if (!r.c())
			{
				return;
			}
			r.e = r.f.CreateInstance("UnityEngine.AndroidJavaClass", true, BindingFlags.Default, null, new object[]
			{
				"com.tencent.wetest.Robot"
			}, null, null);
		}
		if (r.e == null)
		{
			return;
		}
		if (r.d == null && !r.c())
		{
			u.b("mcallstatic == null !");
			return;
		}
		r.d.Invoke(r.e, new object[]
		{
			"startAutomation",
			new object[0]
		});
	}

	public static i a()
	{
		u.d("getAndroidMScreen, begin");
		if (r.g != null)
		{
			return r.g;
		}
		if (r.b == null)
		{
			if (!r.d())
			{
				return null;
			}
			r.b = r.f.CreateInstance("UnityEngine.AndroidJavaClass", true, BindingFlags.Default, null, new object[]
			{
				"com.tencent.wetest.U3DAutomation"
			}, null, null);
		}
		if (r.h == null && !r.a("ReturnType"))
		{
			u.b("not get mcallstatic");
			return null;
		}
		MethodInfo methodInfo = r.h.MakeGenericMethod(new Type[]
		{
			typeof(int)
		});
		if (methodInfo == null)
		{
			u.b("callstatic IS NULL");
			return null;
		}
		int num = -1;
		int num2 = -1;
		bool flag = false;
		try
		{
			num = (int)methodInfo.Invoke(r.b, new object[]
			{
				"GetWidth",
				new object[0]
			});
			num2 = (int)methodInfo.Invoke(r.b, new object[]
			{
				"GetHeight",
				new object[0]
			});
			flag = true;
		}
		catch (Exception ex)
		{
			u.b(ex.ToString());
		}
		if (flag)
		{
			r.g = new i(num, num2);
		}
		u.c(string.Concat(new object[]
		{
			"getAndroidMScreen: width=",
			num,
			", height=",
			num2
		}));
		return r.g;
	}
}
