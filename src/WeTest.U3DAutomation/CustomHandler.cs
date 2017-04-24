using System;
using System.Collections.Generic;

namespace WeTest.U3DAutomation
{
	public class CustomHandler
	{
		public delegate string HandleCustom(string message);

		private static Dictionary<string, CustomHandler.HandleCustom> a = new Dictionary<string, CustomHandler.HandleCustom>();

		public static List<string> keys = new List<string>();

		public static void RegisterCallBack(string key, CustomHandler.HandleCustom handle)
		{
			if (CustomHandler.a.ContainsKey(key))
			{
				CustomHandler.a[key] = handle;
			}
			else
			{
				CustomHandler.a.Add(key, handle);
				CustomHandler.keys.Add(key);
			}
			u.d("Register " + key);
		}

		public static bool UnRegisterCallBack(string key)
		{
			if (CustomHandler.a.ContainsKey(key))
			{
				CustomHandler.a.Remove(key);
				CustomHandler.keys.Remove(key);
				return true;
			}
			return false;
		}

		public static bool Call(string key, string arg, out string result)
		{
			result = "";
			if (CustomHandler.a.ContainsKey(key))
			{
				CustomHandler.HandleCustom handleCustom = CustomHandler.a[key];
				try
				{
					result = handleCustom(arg);
				}
				catch (Exception ex)
				{
					u.a(ex.Message + "\n" + ex.StackTrace);
				}
				return true;
			}
			u.a("UnRegitster Function ==>" + key);
			return false;
		}

		public static List<string> GetRegistered()
		{
			return CustomHandler.keys;
		}
	}
}
