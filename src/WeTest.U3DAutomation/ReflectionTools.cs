using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class ReflectionTools
	{
		public static Hashtable getTypeInfo(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			Type type = obj.GetType();
			Hashtable hashtable = new Hashtable();
			Hashtable hashtable2 = new Hashtable();
			PropertyInfo[] properties = type.GetProperties();
			try
			{
				PropertyInfo[] array = properties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyInfo propertyInfo = array[i];
					object value = propertyInfo.GetValue(obj, null);
					string name = propertyInfo.Name;
					u.c(string.Concat(new object[]
					{
						"Property Info => ",
						name,
						" value=",
						value
					}));
					if (!hashtable2.Contains(name))
					{
						hashtable2.Add(name, value.ToString());
					}
				}
				hashtable.Add("properties", hashtable2);
			}
			catch (Exception ex)
			{
				u.b(ex.Message + "\n" + ex.StackTrace);
			}
			try
			{
				Type[] interfaces = type.GetInterfaces();
				Hashtable hashtable3 = new Hashtable();
				hashtable.Add("Intefaces", hashtable3);
				Type[] array2 = interfaces;
				for (int j = 0; j < array2.Length; j++)
				{
					Type type2 = array2[j];
					u.c("Interface Info => " + type2.AssemblyQualifiedName + " value=" + type2.ToString());
					if (!hashtable3.Contains(type2.AssemblyQualifiedName))
					{
						hashtable3.Add(type2.AssemblyQualifiedName, type2.Name);
					}
				}
			}
			catch (Exception ex2)
			{
				u.b(ex2.Message + "\n" + ex2.StackTrace);
			}
			try
			{
				MethodInfo[] methods = type.GetMethods();
				Hashtable hashtable4 = new Hashtable();
				hashtable.Add("Methods", hashtable4);
				MethodInfo[] array3 = methods;
				for (int k = 0; k < array3.Length; k++)
				{
					MethodInfo methodInfo = array3[k];
					u.c("Method info => " + methodInfo.Name);
					if (!hashtable4.Contains(methodInfo.Name))
					{
						hashtable4.Add(methodInfo.Name, methodInfo.Name);
					}
				}
			}
			catch (Exception ex3)
			{
				u.b(ex3.Message + "\n" + ex3.StackTrace);
			}
			return hashtable;
		}

		public static void printPropertyInfo(object obj)
		{
			Hashtable typeInfo = ReflectionTools.getTypeInfo(obj);
			if (typeInfo == null)
			{
				return;
			}
			foreach (DictionaryEntry dictionaryEntry in typeInfo)
			{
				Hashtable hashtable = dictionaryEntry.Value as Hashtable;
				foreach (DictionaryEntry dictionaryEntry2 in hashtable)
				{
					u.a(dictionaryEntry2.Key + " = " + dictionaryEntry2.Value);
				}
			}
		}

		public static object GetComponentAttribute(GameObject gameobject, Type t, string attributeName)
		{
			if (gameobject == null || t == null)
			{
				return null;
			}
			Component component = gameobject.GetComponent(t);
			if (component == null)
			{
				return null;
			}
			PropertyInfo propertyInfo = ReflectionTools.b(t, attributeName);
			if (propertyInfo == null || !propertyInfo.CanRead)
			{
				return null;
			}
			return propertyInfo.GetValue(component, null);
		}

		public static object GetComponentAttribute(GameObject gameobject, string componentName, string attributeName)
		{
			if (gameobject == null || componentName == null || attributeName == null)
			{
				return null;
			}
			Component[] components = gameobject.GetComponents<Component>();
			Component component = null;
			Component[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				Component component2 = array[i];
				string name = component2.GetType().Name;
				if (name.Equals(componentName))
				{
					component = component2;
					break;
				}
			}
			if (component == null)
			{
				throw new Exception("Can't find " + componentName);
			}
			PropertyInfo propertyInfo = ReflectionTools.b(component.GetType(), attributeName);
			if (propertyInfo != null && propertyInfo.CanRead)
			{
				return propertyInfo.GetValue(component, null);
			}
			FieldInfo fieldInfo = ReflectionTools.a(component.GetType(), attributeName);
			if (fieldInfo != null)
			{
				return fieldInfo.GetValue(component);
			}
			throw new Exception("unAccess field " + attributeName);
		}

		private static PropertyInfo b(Type A_0, string A_1)
		{
			PropertyInfo property = A_0.GetProperty(A_1);
			if (property != null)
			{
				return property;
			}
			if (A_0.BaseType != null)
			{
				return ReflectionTools.b(A_0.BaseType, A_1);
			}
			return null;
		}

		private static FieldInfo a(Type A_0, string A_1)
		{
			FieldInfo field = A_0.GetField(A_1);
			if (field != null)
			{
				return field;
			}
			if (A_0.BaseType != null)
			{
				return ReflectionTools.a(A_0.BaseType, A_1);
			}
			return null;
		}

		public static List<object> GetComponentInChildrenAttribute(GameObject gameobject, Type t, string attributeName)
		{
			if (t == null)
			{
				return null;
			}
			List<object> list = new List<object>();
			Component[] componentsInChildren = gameobject.GetComponentsInChildren(t);
			if (componentsInChildren == null)
			{
				return null;
			}
			PropertyInfo propertyInfo = ReflectionTools.b(t, attributeName);
			if (propertyInfo == null || !propertyInfo.CanRead)
			{
				return null;
			}
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				object value = propertyInfo.GetValue(componentsInChildren[i], null);
				if (value != null)
				{
					list.Add(value);
				}
			}
			return list;
		}

		public static bool SetComponentAttribute(GameObject obj, Type t, string attributeName, object value)
		{
			if (t == null)
			{
				return false;
			}
			Component component = obj.GetComponent(t);
			if (component == null)
			{
				return false;
			}
			PropertyInfo propertyInfo = ReflectionTools.b(t, attributeName);
			if (!propertyInfo.CanWrite)
			{
				return false;
			}
			propertyInfo.SetValue(component, value, null);
			return true;
		}
	}
}
