using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.SDK
{
	public static class ExtendFunctions
	{
		public static T GetCustomAttribute<T>(this Type obj, bool isInhert) where T : Attribute
		{
			object[] customAttributes = obj.GetCustomAttributes(typeof(T), isInhert);
			T result = (T)((object)null);
			if (customAttributes != null)
			{
				if (customAttributes.Length > 1)
				{
					throw new AmbiguousMatchException("类型" + obj.ToString() + "的属性个数匹配多余一个");
				}
				if (customAttributes.Length == 1)
				{
					result = (customAttributes[0] as T);
				}
			}
			return result;
		}

		public static IEnumerable<T> GetCustomAttributes<T>(this Type obj, bool isInhert) where T : Attribute
		{
			return (T[])obj.GetCustomAttributes(typeof(T), isInhert);
		}
	}
}
