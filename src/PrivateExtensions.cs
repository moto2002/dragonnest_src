using System;
using System.Collections.Generic;
using System.Reflection;

public static class PrivateExtensions
{
	public static T CallPrivateMethodGeneric<T>(this object obj, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		Type[] array = new Type[param.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = param[i].GetType();
		}
		List<Type[]> list = PublicExtensions.CastNumberParameters(param, array);
		MethodInfo methodInfo = null;
		try
		{
			methodInfo = type.GetMethod(name, bindingAttr);
		}
		catch
		{
			for (int j = 0; j < list.Count; j++)
			{
				methodInfo = type.GetMethod(name, list[j]);
				if (methodInfo != null)
				{
					break;
				}
			}
		}
		if (methodInfo == null)
		{
			return default(T);
		}
		ParameterInfo[] parameters = methodInfo.GetParameters();
		object[] array2 = new object[parameters.Length];
		for (int k = 0; k < parameters.Length; k++)
		{
			if (parameters[k].ParameterType != typeof(object))
			{
				array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
			}
			else
			{
				array2[k] = param[k];
			}
		}
		return (T)((object)methodInfo.Invoke(obj, array2));
	}

	public static object CallPrivateMethod(this object obj, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		Type[] array = new Type[param.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = param[i].GetType();
		}
		List<Type[]> list = PublicExtensions.CastNumberParameters(param, array);
		MethodInfo methodInfo = null;
		try
		{
			methodInfo = type.GetMethod(name, bindingAttr);
		}
		catch
		{
			for (int j = 0; j < list.Count; j++)
			{
				methodInfo = type.GetMethod(name, list[j]);
				if (methodInfo != null)
				{
					break;
				}
			}
		}
		if (methodInfo == null)
		{
			return null;
		}
		ParameterInfo[] parameters = methodInfo.GetParameters();
		object[] array2 = new object[parameters.Length];
		for (int k = 0; k < parameters.Length; k++)
		{
			if (parameters[k].ParameterType != typeof(object))
			{
				array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
			}
			else
			{
				array2[k] = param[k];
			}
		}
		return methodInfo.Invoke(obj, array2);
	}

	public static object CallStaticPrivateMethod(string typeName, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = Type.GetType(typeName);
		Type[] array = new Type[param.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = param[i].GetType();
		}
		List<Type[]> list = PublicExtensions.CastNumberParameters(param, array);
		MethodInfo methodInfo = null;
		try
		{
			methodInfo = type.GetMethod(name, bindingAttr);
		}
		catch
		{
			for (int j = 0; j < list.Count; j++)
			{
				methodInfo = type.GetMethod(name, list[j]);
				if (methodInfo != null)
				{
					break;
				}
			}
		}
		if (methodInfo == null)
		{
			return null;
		}
		ParameterInfo[] parameters = methodInfo.GetParameters();
		object[] array2 = new object[parameters.Length];
		for (int k = 0; k < parameters.Length; k++)
		{
			if (parameters[k].ParameterType != typeof(object))
			{
				array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
			}
			else
			{
				array2[k] = param[k];
			}
		}
		return methodInfo.Invoke(null, array2);
	}

	public static T GetPrivateFieldGeneric<T>(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			return (T)((object)fieldInfo.GetValue(obj));
		}
		return default(T);
	}

	public static object GetPrivateField(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(obj);
		}
		return null;
	}

	public static object GetStaticPrivateField(string typeName, string name)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
		Type type = Type.GetType(typeName);
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(null);
		}
		return null;
	}

	public static T GetPrivatePropertyGeneric<T>(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			return (T)((object)propertyInfo.GetGetMethod(true).Invoke(obj, null));
		}
		return default(T);
	}

	public static object GetPrivateProperty(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			return propertyInfo.GetGetMethod(true).Invoke(obj, null);
		}
		return null;
	}

	public static object GetStaticPrivateProperty(string typeName, string name)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = Type.GetType(typeName);
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			return propertyInfo.GetValue(null, null);
		}
		return null;
	}

	public static void SetPrivateField(this object obj, string name, object value)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			if (fieldInfo.FieldType == typeof(int))
			{
				int num = Convert.ToInt32(value);
				fieldInfo.SetValue(obj, num);
				return;
			}
			if (fieldInfo.FieldType == typeof(float))
			{
				float num2 = Convert.ToSingle(value);
				fieldInfo.SetValue(obj, num2);
				return;
			}
			if (fieldInfo.FieldType == typeof(long))
			{
				long num3 = Convert.ToInt64(value);
				fieldInfo.SetValue(obj, num3);
				return;
			}
			fieldInfo.SetValue(obj, value);
		}
	}

	public static void SetStaticPrivateField(string typeName, string name, object value)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = Type.GetType(typeName);
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			if (fieldInfo.FieldType == typeof(int))
			{
				int num = Convert.ToInt32(value);
				fieldInfo.SetValue(null, num);
				return;
			}
			if (fieldInfo.FieldType == typeof(float))
			{
				float num2 = Convert.ToSingle(value);
				fieldInfo.SetValue(null, num2);
				return;
			}
			if (fieldInfo.FieldType == typeof(long))
			{
				long num3 = Convert.ToInt64(value);
				fieldInfo.SetValue(null, num3);
				return;
			}
			fieldInfo.SetValue(null, value);
		}
	}

	public static void SetPrivateProperty(this object obj, string name, object value)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			if (propertyInfo.PropertyType == typeof(int))
			{
				int num = Convert.ToInt32(value);
				propertyInfo.SetValue(obj, num, null);
				return;
			}
			if (propertyInfo.PropertyType == typeof(float))
			{
				float num2 = Convert.ToSingle(value);
				propertyInfo.SetValue(obj, num2, null);
				return;
			}
			if (propertyInfo.PropertyType == typeof(long))
			{
				long num3 = Convert.ToInt64(value);
				propertyInfo.SetValue(obj, num3, null);
				return;
			}
			propertyInfo.SetValue(obj, value, null);
		}
	}

	public static void SetStaticPrivateProperty(string typeName, string name, object value)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
		Type type = Type.GetType(typeName);
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			if (propertyInfo.PropertyType == typeof(int))
			{
				int num = Convert.ToInt32(value);
				propertyInfo.SetValue(null, num, null);
				return;
			}
			if (propertyInfo.PropertyType == typeof(float))
			{
				float num2 = Convert.ToSingle(value);
				propertyInfo.SetValue(null, num2, null);
				return;
			}
			if (propertyInfo.PropertyType == typeof(long))
			{
				long num3 = Convert.ToInt64(value);
				propertyInfo.SetValue(null, num3, null);
				return;
			}
			propertyInfo.SetValue(null, value, null);
		}
	}
}
