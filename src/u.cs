using System;
using UnityEngine;

internal class u
{
	public static void d(string A_0)
	{
	}

	public static void d(string A_0, params object[] A_1)
	{
	}

	public static void c(string A_0)
	{
	}

	public static void c(string A_0, params object[] A_1)
	{
	}

	public static void b(string A_0)
	{
		Debug.LogError("<WeTestLog> [\n" + A_0 + " \n]");
	}

	public static void b(string A_0, params object[] A_1)
	{
		u.b(string.Format(A_0, A_1));
	}

	public static void a(string A_0)
	{
		Debug.LogWarning(A_0);
	}

	public static void a(string A_0, params object[] A_1)
	{
		u.a(string.Format(A_0, A_1));
	}
}
