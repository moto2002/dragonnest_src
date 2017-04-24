using System;
using System.Text;
using UnityEngine;

public static class Debugger
{
	private static StringBuilder builder = new StringBuilder();

	public static void Log(string str, params object[] args)
	{
	}

	public static void LogWarning(string str, params object[] args)
	{
		Debugger.builder.Length = 0;
		Debugger.builder.Append("lua=>");
		Debugger.builder.AppendFormat(str, args);
		Debug.LogWarning(Debugger.builder.ToString());
	}

	public static void LogError(string str, params object[] args)
	{
		Debugger.builder.Length = 0;
		Debugger.builder.Append("lua=>");
		Debugger.builder.AppendFormat(str, args);
		Debug.LogError(Debugger.builder.ToString());
	}
}
