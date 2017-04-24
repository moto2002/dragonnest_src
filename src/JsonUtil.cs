using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtil
{
	public static float ParseFloat(object val, float defVal = 0f)
	{
		if (val != null)
		{
			return float.Parse(val.ToString());
		}
		return defVal;
	}

	public static int ParseInt(object val, int defVal = 0)
	{
		if (val != null)
		{
			return int.Parse(val.ToString());
		}
		return defVal;
	}

	public static bool ParseBool(object val, bool defVal = false)
	{
		if (val == null)
		{
			return defVal;
		}
		bool result;
		try
		{
			result = (JsonUtil.ParseInt(val, defVal ? 1 : 0) != 0);
		}
		catch (Exception)
		{
			try
			{
				result = bool.Parse(val.ToString());
			}
			catch (Exception)
			{
				result = defVal;
			}
		}
		return result;
	}

	public static DateTime ParseDateTime(object val)
	{
		return DateTime.Parse(val.ToString());
	}

	public static string ReadString(IDictionary<string, object> dic, string key, string defVal = "")
	{
		if (dic == null || !dic.ContainsKey(key))
		{
			return defVal;
		}
		if (dic[key] != null)
		{
			return dic[key].ToString();
		}
		return defVal;
	}

	public static int ReadInt(IDictionary<string, object> dic, string key, int defVal = 0)
	{
		if (dic != null && dic.ContainsKey(key))
		{
			return JsonUtil.ParseInt(dic[key], defVal);
		}
		return defVal;
	}

	public static bool ReadBool(IDictionary<string, object> dic, string key, bool defVal = false)
	{
		if (dic != null && dic.ContainsKey(key))
		{
			return JsonUtil.ParseBool(dic[key], defVal);
		}
		return defVal;
	}

	public static float ReadFloat(IDictionary<string, object> dic, string key, float defVal = 0f)
	{
		if (dic != null && dic.ContainsKey(key))
		{
			return JsonUtil.ParseFloat(dic[key], defVal);
		}
		return defVal;
	}

	public static DateTime ReadDateTime(IDictionary<string, object> dic, string key)
	{
		return JsonUtil.ReadDateTime(dic, key, new DateTime(1, 1, 1, 0, 0, 0));
	}

	public static DateTime ReadDateTime(IDictionary<string, object> dic, string key, DateTime defVal)
	{
		if (dic != null && dic.ContainsKey(key))
		{
			try
			{
				DateTime result = JsonUtil.ParseDateTime(dic[key]);
				return result;
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				DateTime result = defVal;
				return result;
			}
			return defVal;
		}
		return defVal;
	}

	public static string ListToJsonStr(List<string> list)
	{
		if (list == null || list.Count < 1)
		{
			return "[]";
		}
		bool flag = true;
		string text = "[";
		foreach (string current in list)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				text += ",";
			}
			text += current;
		}
		text += "]";
		return text;
	}
}
