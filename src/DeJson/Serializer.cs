using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace DeJson
{
	public class Serializer
	{
		private StringBuilder m_builder;

		private bool m_includeTypeInfoForDerivedTypes;

		private bool m_prettyPrint;

		private string m_prefix;

		public static string Serialize(object obj, bool includeTypeInfoForDerivedTypes = false, bool prettyPrint = false)
		{
			Serializer serializer = new Serializer(includeTypeInfoForDerivedTypes, prettyPrint);
			serializer.SerializeValue(obj);
			return serializer.GetJson();
		}

		private Serializer(bool includeTypeInfoForDerivedTypes, bool prettyPrint)
		{
			this.m_builder = new StringBuilder();
			this.m_includeTypeInfoForDerivedTypes = includeTypeInfoForDerivedTypes;
			this.m_prettyPrint = prettyPrint;
			this.m_prefix = "";
		}

		private string GetJson()
		{
			return this.m_builder.ToString();
		}

		private void Indent()
		{
			if (this.m_prettyPrint)
			{
				this.m_prefix += "  ";
			}
		}

		private void Outdent()
		{
			if (this.m_prettyPrint)
			{
				this.m_prefix = this.m_prefix.Substring(2);
			}
		}

		private void AddIndent()
		{
			if (this.m_prettyPrint)
			{
				this.m_builder.Append(this.m_prefix);
			}
		}

		private void AddLine()
		{
			if (this.m_prettyPrint)
			{
				this.m_builder.Append("\n");
			}
		}

		private void AddSpace()
		{
			if (this.m_prettyPrint)
			{
				this.m_builder.Append(" ");
			}
		}

		private void SerializeValue(object obj)
		{
			if (obj == null)
			{
				this.m_builder.Append("undefined");
				return;
			}
			Type type = obj.GetType();
			if (type.IsArray)
			{
				this.SerializeArray(obj);
				return;
			}
			if (type == typeof(string))
			{
				this.SerializeString(obj as string);
				return;
			}
			if (type == typeof(char))
			{
				this.SerializeString(obj.ToString());
				return;
			}
			if (type == typeof(bool))
			{
				this.m_builder.Append(((bool)obj) ? "true" : "false");
				return;
			}
			if (type == typeof(bool))
			{
				this.m_builder.Append(((bool)obj) ? "true" : "false");
				this.m_builder.Append(Convert.ChangeType(obj, typeof(string)));
				return;
			}
			if (type == typeof(int))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(byte))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(sbyte))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(short))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(ushort))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(int))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(uint))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(long))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(ulong))
			{
				this.m_builder.Append(obj);
				return;
			}
			if (type == typeof(float))
			{
				this.m_builder.Append(((float)obj).ToString("R", CultureInfo.InvariantCulture));
				return;
			}
			if (type == typeof(double))
			{
				this.m_builder.Append(((double)obj).ToString("R", CultureInfo.InvariantCulture));
				return;
			}
			if (type == typeof(float))
			{
				this.m_builder.Append(((float)obj).ToString("R", CultureInfo.InvariantCulture));
				return;
			}
			if (type == typeof(double))
			{
				this.m_builder.Append(((double)obj).ToString("R", CultureInfo.InvariantCulture));
				return;
			}
			if (type.IsValueType)
			{
				this.SerializeObject(obj);
				return;
			}
			if (type.IsClass)
			{
				this.SerializeObject(obj);
				return;
			}
			throw new InvalidOperationException("unsupport type: " + type.Name);
		}

		private void SerializeArray(object obj)
		{
			this.m_builder.Append("[");
			this.AddLine();
			this.Indent();
			Array array = obj as Array;
			bool flag = true;
			foreach (object current in array)
			{
				if (!flag)
				{
					this.m_builder.Append(",");
					this.AddLine();
				}
				this.AddIndent();
				this.SerializeValue(current);
				flag = false;
			}
			this.AddLine();
			this.Outdent();
			this.AddIndent();
			this.m_builder.Append("]");
		}

		private void SerializeDictionary(IDictionary obj)
		{
			bool flag = true;
			foreach (object current in obj.Keys)
			{
				if (!flag)
				{
					this.m_builder.Append(',');
					this.AddLine();
				}
				this.AddIndent();
				this.SerializeString(current.ToString());
				this.m_builder.Append(':');
				this.AddSpace();
				this.SerializeValue(obj[current]);
				flag = false;
			}
		}

		private void SerializeObject(object obj)
		{
			this.m_builder.Append("{");
			this.AddLine();
			this.Indent();
			bool flag = true;
			if (this.m_includeTypeInfoForDerivedTypes)
			{
				Type type = obj.GetType();
				Type baseType = type.BaseType;
				if (baseType != null && baseType != typeof(object))
				{
					this.AddIndent();
					this.SerializeString("$dotNetType");
					this.m_builder.Append(":");
					this.AddSpace();
					this.SerializeString(type.FullName);
				}
			}
			IDictionary obj2;
			if ((obj2 = (obj as IDictionary)) != null)
			{
				this.SerializeDictionary(obj2);
			}
			else
			{
				FieldInfo[] fields = obj.GetType().GetFields();
				FieldInfo[] array = fields;
				for (int i = 0; i < array.Length; i++)
				{
					FieldInfo fieldInfo = array[i];
					if (!fieldInfo.IsStatic)
					{
						object value = fieldInfo.GetValue(obj);
						if (value != null)
						{
							if (!flag)
							{
								this.m_builder.Append(",");
								this.AddLine();
							}
							this.AddIndent();
							this.SerializeString(fieldInfo.Name);
							this.m_builder.Append(":");
							this.AddSpace();
							this.SerializeValue(value);
							flag = false;
						}
					}
				}
			}
			this.AddLine();
			this.Outdent();
			this.AddIndent();
			this.m_builder.Append("}");
		}

		private void SerializeString(string str)
		{
			this.m_builder.Append('"');
			char[] array = str.ToCharArray();
			char[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				char c = array2[i];
				char c2 = c;
				switch (c2)
				{
				case '\b':
					this.m_builder.Append("\\b");
					break;
				case '\t':
					this.m_builder.Append("\\t");
					break;
				case '\n':
					this.m_builder.Append("\\n");
					break;
				case '\v':
					goto IL_EA;
				case '\f':
					this.m_builder.Append("\\f");
					break;
				case '\r':
					this.m_builder.Append("\\r");
					break;
				default:
					if (c2 != '"')
					{
						if (c2 != '\\')
						{
							goto IL_EA;
						}
						this.m_builder.Append("\\\\");
					}
					else
					{
						this.m_builder.Append("\\\"");
					}
					break;
				}
				IL_133:
				i++;
				continue;
				IL_EA:
				int num = Convert.ToInt32(c);
				if (num >= 32 && num <= 126)
				{
					this.m_builder.Append(c);
					goto IL_133;
				}
				this.m_builder.Append("\\u");
				this.m_builder.Append(num.ToString("x4"));
				goto IL_133;
			}
			this.m_builder.Append('"');
		}
	}
}
