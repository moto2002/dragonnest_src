using System;
using System.Collections.Generic;
using System.Reflection;

public static class PublicExtensions
{
	public static List<Type[]> CastNumberParameters(object[] param, Type[] paramTypes)
	{
		List<Type[]> list = new List<Type[]>();
		int num = 0;
		for (int i = 0; i < paramTypes.Length; i++)
		{
			if (paramTypes[i] != null && paramTypes[i] == typeof(double))
			{
				num++;
				Type[] array = new Type[paramTypes.Length];
				for (int j = 0; j < array.Length; j++)
				{
					if (i == j)
					{
						array[j] = typeof(double);
					}
					else
					{
						array[j] = paramTypes[j];
					}
				}
				list.Add(array);
				array = new Type[paramTypes.Length];
				for (int k = 0; k < array.Length; k++)
				{
					if (i == k)
					{
						array[k] = typeof(float);
					}
					else
					{
						array[k] = paramTypes[k];
					}
				}
				list.Add(array);
				array = new Type[paramTypes.Length];
				for (int l = 0; l < array.Length; l++)
				{
					if (i == l)
					{
						array[l] = typeof(int);
					}
					else
					{
						array[l] = paramTypes[l];
					}
				}
				list.Add(array);
			}
		}
		if (num == 0)
		{
			list.Add(paramTypes);
			if (paramTypes.Length == 1 && paramTypes[0] == typeof(string))
			{
				list.Add(new Type[0]);
			}
		}
		return list;
	}

	public static T CallPublicMethodGeneric<T>(this object obj, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

	public static object CallPublicMethod(this object obj, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

	public static object CallStaticPublicMethod(string typeName, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

	public static T GetPublicFieldGeneric<T>(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			return (T)((object)fieldInfo.GetValue(obj));
		}
		return default(T);
	}

	public static object GetPublicField(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(obj);
		}
		return null;
	}

	public static object GetStaticPublicField(string typeName, string name)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.Public;
		Type type = Type.GetType(typeName);
		FieldInfo fieldInfo = PublicExtensions.GetFieldInfo(type, name, flags);
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(null);
		}
		return null;
	}

	public static FieldInfo GetFieldInfo(Type type, string name, BindingFlags flags)
	{
		if (type == null)
		{
			return null;
		}
		FieldInfo field = type.GetField(name, flags);
		if (field == null && type.BaseType != null)
		{
			return PublicExtensions.GetFieldInfo(type.BaseType, name, flags);
		}
		return field;
	}

	public static T GetPublicPropertyGeneric<T>(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			return (T)((object)propertyInfo.GetGetMethod(false).Invoke(obj, null));
		}
		return default(T);
	}

	public static object GetPublicProperty(this object obj, string name)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
		Type type = obj.GetType();
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			return propertyInfo.GetGetMethod(false).Invoke(obj, null);
		}
		return null;
	}

	public static object GetStaticPublicProperty(string typeName, string name)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
		Type type = Type.GetType(typeName);
		PropertyInfo propertyInfo = PublicExtensions.GetPropertyInfo(type, name, flags);
		if (propertyInfo != null)
		{
			return propertyInfo.GetValue(null, null);
		}
		return null;
	}

	public static PropertyInfo GetPropertyInfo(Type type, string name, BindingFlags flags)
	{
		if (type == null)
		{
			return null;
		}
		PropertyInfo property = type.GetProperty(name, flags);
		if (property == null && type.BaseType != null)
		{
			return PublicExtensions.GetPropertyInfo(type.BaseType, name, flags);
		}
		return property;
	}

	public static void SetPublicField(this object obj, string name, object value)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

	public static void SetStaticPublicField(string typeName, string name, object value)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

	public static void SetPublicProperty(this object obj, string name, object value)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

	public static void SetStaticPublicProperty(string typeName, string name, object value)
	{
		BindingFlags flags = BindingFlags.Static | BindingFlags.Public;
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
