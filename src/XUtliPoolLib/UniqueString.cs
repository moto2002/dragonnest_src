using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class UniqueString
	{
		private static Dictionary<string, string> m_strings = new Dictionary<string, string>();

		public static string Intern(string str, bool removable = true)
		{
			if (str == null)
			{
				return null;
			}
			string text = UniqueString.IsInterned(str);
			if (text != null)
			{
				return text;
			}
			if (removable)
			{
				UniqueString.m_strings.Add(str, str);
				return str;
			}
			return string.Intern(str);
		}

		public static string IsInterned(string str)
		{
			if (str == null)
			{
				return null;
			}
			string text = string.IsInterned(str);
			if (text != null)
			{
				return text;
			}
			if (UniqueString.m_strings.TryGetValue(str, out text))
			{
				return text;
			}
			return null;
		}

		public static void Clear()
		{
			UniqueString.m_strings.Clear();
		}
	}
}
