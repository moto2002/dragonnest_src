using MiniJSON;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeJson
{
	public class Deserializer
	{
		public abstract class CustomCreator
		{
			public abstract object Create(Dictionary<string, object> src, Dictionary<string, object> parentSrc);

			public abstract Type TypeToCreate();
		}

		private Dictionary<Type, Deserializer.CustomCreator> m_creators;

		public Deserializer()
		{
			this.m_creators = new Dictionary<Type, Deserializer.CustomCreator>();
		}

		public T Deserialize<T>(string json)
		{
			object o = Json.Deserialize(json);
			return this.Deserialize<T>(o);
		}

		public T Deserialize<T>(object o)
		{
			return (T)((object)this.ConvertToType(o, typeof(T), null));
		}

		public void RegisterCreator(Deserializer.CustomCreator creator)
		{
			Type key = creator.TypeToCreate();
			this.m_creators[key] = creator;
		}

		private object DeserializeO(Type destType, Dictionary<string, object> src, Dictionary<string, object> parentSrc)
		{
			object obj = null;
			if (destType == typeof(Dictionary<string, object>))
			{
				return src;
			}
			Deserializer.CustomCreator customCreator;
			if (this.m_creators.TryGetValue(destType, out customCreator))
			{
				obj = customCreator.Create(src, parentSrc);
			}
			if (obj == null)
			{
				object obj2;
				if (src.TryGetValue("$dotNetType", out obj2))
				{
					destType = Type.GetType((string)obj2);
				}
				obj = Activator.CreateInstance(destType);
			}
			this.DeserializeIt(obj, src);
			return obj;
		}

		private void DeserializeIt(object dest, Dictionary<string, object> src)
		{
			Type type = dest.GetType();
			FieldInfo[] fields = type.GetFields();
			this.DeserializeClassFields(dest, fields, src);
		}

		private void DeserializeClassFields(object dest, FieldInfo[] fields, Dictionary<string, object> src)
		{
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				object value;
				if (!fieldInfo.IsStatic && src.TryGetValue(fieldInfo.Name, out value))
				{
					this.DeserializeField(dest, fieldInfo, value, src);
				}
			}
		}

		private void DeserializeField(object dest, FieldInfo info, object value, Dictionary<string, object> src)
		{
			Type fieldType = info.FieldType;
			object obj = this.ConvertToType(value, fieldType, src);
			if (fieldType.IsAssignableFrom(obj.GetType()))
			{
				info.SetValue(dest, obj);
			}
		}

		private object ConvertToType(object value, Type type, Dictionary<string, object> src)
		{
			if (type.IsArray)
			{
				return this.ConvertToArray(value, type, src);
			}
			if (type.IsGenericType)
			{
				return this.ConvertToList(value, type, src);
			}
			if (type == typeof(string))
			{
				return Convert.ToString(value);
			}
			if (type == typeof(byte))
			{
				return Convert.ToByte(value);
			}
			if (type == typeof(sbyte))
			{
				return Convert.ToSByte(value);
			}
			if (type == typeof(short))
			{
				return Convert.ToInt16(value);
			}
			if (type == typeof(ushort))
			{
				return Convert.ToUInt16(value);
			}
			if (type == typeof(int))
			{
				return Convert.ToInt32(value);
			}
			if (type == typeof(uint))
			{
				return Convert.ToUInt32(value);
			}
			if (type == typeof(long))
			{
				return Convert.ToInt64(value);
			}
			if (type == typeof(ulong))
			{
				return Convert.ToUInt64(value);
			}
			if (type == typeof(char))
			{
				return Convert.ToChar(value);
			}
			if (type == typeof(double))
			{
				return Convert.ToDouble(value);
			}
			if (type == typeof(float))
			{
				return Convert.ToSingle(value);
			}
			if (type == typeof(int))
			{
				return Convert.ToInt32(value);
			}
			if (type == typeof(float))
			{
				return Convert.ToSingle(value);
			}
			if (type == typeof(double))
			{
				return Convert.ToDouble(value);
			}
			if (type == typeof(bool))
			{
				return Convert.ToBoolean(value);
			}
			if (type == typeof(bool))
			{
				return Convert.ToBoolean(value);
			}
			if (type.IsValueType)
			{
				return this.DeserializeO(type, (Dictionary<string, object>)value, src);
			}
			if (type.IsClass)
			{
				return this.DeserializeO(type, (Dictionary<string, object>)value, src);
			}
			return value;
		}

		private object ConvertToArray(object value, Type type, Dictionary<string, object> src)
		{
			List<object> list = (List<object>)value;
			int count = list.Count;
			Type elementType = type.GetElementType();
			Array array = Array.CreateInstance(elementType, count);
			int num = 0;
			foreach (object current in list)
			{
				object value2 = this.ConvertToType(current, elementType, src);
				array.SetValue(value2, num);
				num++;
			}
			return array;
		}

		private object ConvertToList(object value, Type type, Dictionary<string, object> src)
		{
			object obj = Activator.CreateInstance(type);
			MethodInfo method = type.GetMethod("Add");
			List<object> list = (List<object>)value;
			Type returnType = type.GetMethod("Find").ReturnType;
			foreach (object current in list)
			{
				object obj2 = this.ConvertToType(current, returnType, src);
				method.Invoke(obj, new object[]
				{
					obj2
				});
			}
			return obj;
		}
	}
}
