using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace WeTest.U3DAutomation
{
	public class JsonData : IJsonWrapper, IEquatable<JsonData>
	{
		private IList<JsonData> a;

		private bool b;

		private double c;

		private int d;

		private long e;

		private IDictionary<string, JsonData> f;

		private string g;

		private string h;

		private JsonType i;

		private IList<KeyValuePair<string, JsonData>> j;

		public int Count
		{
			get
			{
				return this.c().Count;
			}
		}

		public bool IsArray
		{
			get
			{
				return this.i == JsonType.Array;
			}
		}

		public bool IsBoolean
		{
			get
			{
				return this.i == JsonType.Boolean;
			}
		}

		public bool IsDouble
		{
			get
			{
				return this.i == JsonType.Double;
			}
		}

		public bool IsInt
		{
			get
			{
				return this.i == JsonType.Int;
			}
		}

		public bool IsLong
		{
			get
			{
				return this.i == JsonType.Long;
			}
		}

		public bool IsObject
		{
			get
			{
				return this.i == JsonType.Object;
			}
		}

		public bool IsString
		{
			get
			{
				return this.i == JsonType.String;
			}
		}

		public ICollection<string> Keys
		{
			get
			{
				this.b();
				return this.f.Keys;
			}
		}

		int ICollection.Count
		{
			get
			{
				return this.Count;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				return this.c().IsSynchronized;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return this.c().SyncRoot;
			}
		}

		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.b().IsFixedSize;
			}
		}

		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.b().IsReadOnly;
			}
		}

		ICollection IDictionary.Keys
		{
			get
			{
				this.b();
				IList<string> list = new List<string>();
				foreach (KeyValuePair<string, JsonData> current in this.j)
				{
					list.Add(current.Key);
				}
				return (ICollection)list;
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				this.b();
				IList<JsonData> list = new List<JsonData>();
				foreach (KeyValuePair<string, JsonData> current in this.j)
				{
					list.Add(current.Value);
				}
				return (ICollection)list;
			}
		}

		bool IJsonWrapper.IsArray
		{
			get
			{
				return this.IsArray;
			}
		}

		bool IJsonWrapper.IsBoolean
		{
			get
			{
				return this.IsBoolean;
			}
		}

		bool IJsonWrapper.IsDouble
		{
			get
			{
				return this.IsDouble;
			}
		}

		bool IJsonWrapper.IsInt
		{
			get
			{
				return this.IsInt;
			}
		}

		bool IJsonWrapper.IsLong
		{
			get
			{
				return this.IsLong;
			}
		}

		bool IJsonWrapper.IsObject
		{
			get
			{
				return this.IsObject;
			}
		}

		bool IJsonWrapper.IsString
		{
			get
			{
				return this.IsString;
			}
		}

		bool IList.IsFixedSize
		{
			get
			{
				return this.a().IsFixedSize;
			}
		}

		bool IList.IsReadOnly
		{
			get
			{
				return this.a().IsReadOnly;
			}
		}

		object IDictionary.this[object key]
		{
			get
			{
				return this.b()[key];
			}
			set
			{
				if (!(key is string))
				{
					throw new ArgumentException("The key has to be a string");
				}
				JsonData value2 = this.a(value);
				this[(string)key] = value2;
			}
		}

		object IOrderedDictionary.this[int idx]
		{
			get
			{
				this.b();
				return this.j[idx].Value;
			}
			set
			{
				this.b();
				JsonData value2 = this.a(value);
				KeyValuePair<string, JsonData> keyValuePair = this.j[idx];
				this.f[keyValuePair.Key] = value2;
				KeyValuePair<string, JsonData> value3 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value2);
				this.j[idx] = value3;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this.a()[index];
			}
			set
			{
				this.a();
				JsonData value2 = this.a(value);
				this[index] = value2;
			}
		}

		public JsonData this[string prop_name]
		{
			get
			{
				this.b();
				return this.f[prop_name];
			}
			set
			{
				this.b();
				KeyValuePair<string, JsonData> keyValuePair = new KeyValuePair<string, JsonData>(prop_name, value);
				if (this.f.ContainsKey(prop_name))
				{
					for (int i = 0; i < this.j.Count; i++)
					{
						if (this.j[i].Key == prop_name)
						{
							this.j[i] = keyValuePair;
							break;
						}
					}
				}
				else
				{
					this.j.Add(keyValuePair);
				}
				this.f[prop_name] = value;
				this.h = null;
			}
		}

		public JsonData this[int index]
		{
			get
			{
				this.c();
				if (this.i == JsonType.Array)
				{
					return this.a[index];
				}
				return this.j[index].Value;
			}
			set
			{
				this.c();
				if (this.i == JsonType.Array)
				{
					this.a[index] = value;
				}
				else
				{
					KeyValuePair<string, JsonData> keyValuePair = this.j[index];
					KeyValuePair<string, JsonData> value2 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value);
					this.j[index] = value2;
					this.f[keyValuePair.Key] = value;
				}
				this.h = null;
			}
		}

		public JsonData()
		{
		}

		public JsonData(bool boolean)
		{
			this.i = JsonType.Boolean;
			this.b = boolean;
		}

		public JsonData(double number)
		{
			this.i = JsonType.Double;
			this.c = number;
		}

		public JsonData(int number)
		{
			this.i = JsonType.Int;
			this.d = number;
		}

		public JsonData(long number)
		{
			this.i = JsonType.Long;
			this.e = number;
		}

		public JsonData(object obj)
		{
			if (obj is bool)
			{
				this.i = JsonType.Boolean;
				this.b = (bool)obj;
				return;
			}
			if (obj is double)
			{
				this.i = JsonType.Double;
				this.c = (double)obj;
				return;
			}
			if (obj is int)
			{
				this.i = JsonType.Int;
				this.d = (int)obj;
				return;
			}
			if (obj is long)
			{
				this.i = JsonType.Long;
				this.e = (long)obj;
				return;
			}
			if (obj is string)
			{
				this.i = JsonType.String;
				this.g = (string)obj;
				return;
			}
			throw new ArgumentException("Unable to wrap the given object with JsonData");
		}

		public JsonData(string str)
		{
			this.i = JsonType.String;
			this.g = str;
		}

		public static implicit operator JsonData(bool data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(double data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(int data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(long data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(string data)
		{
			return new JsonData(data);
		}

		public static explicit operator bool(JsonData data)
		{
			if (data.i != JsonType.Boolean)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.b;
		}

		public static explicit operator double(JsonData data)
		{
			if (data.i != JsonType.Double)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.c;
		}

		public static explicit operator int(JsonData data)
		{
			if (data.i != JsonType.Int)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.d;
		}

		public static explicit operator long(JsonData data)
		{
			if (data.i != JsonType.Long)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.e;
		}

		public static explicit operator string(JsonData data)
		{
			if (data.i != JsonType.String)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a string");
			}
			return data.g;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.c().CopyTo(array, index);
		}

		void IDictionary.Add(object key, object value)
		{
			JsonData value2 = this.a(value);
			this.b().Add(key, value2);
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>((string)key, value2);
			this.j.Add(item);
			this.h = null;
		}

		void IDictionary.Clear()
		{
			this.b().Clear();
			this.j.Clear();
			this.h = null;
		}

		bool IDictionary.Contains(object key)
		{
			return this.b().Contains(key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IOrderedDictionary)this).GetEnumerator();
		}

		void IDictionary.Remove(object key)
		{
			this.b().Remove(key);
			for (int i = 0; i < this.j.Count; i++)
			{
				if (this.j[i].Key == (string)key)
				{
					this.j.RemoveAt(i);
					break;
				}
			}
			this.h = null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.c().GetEnumerator();
		}

		bool IJsonWrapper.GetBoolean()
		{
			if (this.i != JsonType.Boolean)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a boolean");
			}
			return this.b;
		}

		double IJsonWrapper.GetDouble()
		{
			if (this.i != JsonType.Double)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a double");
			}
			return this.c;
		}

		int IJsonWrapper.GetInt()
		{
			if (this.i != JsonType.Int)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return this.d;
		}

		long IJsonWrapper.GetLong()
		{
			if (this.i != JsonType.Long)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return this.e;
		}

		string IJsonWrapper.GetString()
		{
			if (this.i != JsonType.String)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a string");
			}
			return this.g;
		}

		void IJsonWrapper.SetBoolean(bool val)
		{
			this.i = JsonType.Boolean;
			this.b = val;
			this.h = null;
		}

		void IJsonWrapper.SetDouble(double val)
		{
			this.i = JsonType.Double;
			this.c = val;
			this.h = null;
		}

		void IJsonWrapper.SetInt(int val)
		{
			this.i = JsonType.Int;
			this.d = val;
			this.h = null;
		}

		void IJsonWrapper.SetLong(long val)
		{
			this.i = JsonType.Long;
			this.e = val;
			this.h = null;
		}

		void IJsonWrapper.SetString(string val)
		{
			this.i = JsonType.String;
			this.g = val;
			this.h = null;
		}

		string IJsonWrapper.ToJson()
		{
			return this.ToJson();
		}

		void IJsonWrapper.ToJson(JsonWriter writer)
		{
			this.ToJson(writer);
		}

		int IList.Add(object value)
		{
			return this.Add(value);
		}

		void IList.Clear()
		{
			this.a().Clear();
			this.h = null;
		}

		bool IList.Contains(object value)
		{
			return this.a().Contains(value);
		}

		int IList.IndexOf(object value)
		{
			return this.a().IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			this.a().Insert(index, value);
			this.h = null;
		}

		void IList.Remove(object value)
		{
			this.a().Remove(value);
			this.h = null;
		}

		void IList.RemoveAt(int index)
		{
			this.a().RemoveAt(index);
			this.h = null;
		}

		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			this.b();
			return new a(this.j.GetEnumerator());
		}

		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
			string text = (string)key;
			JsonData value2 = this.a(value);
			this[text] = value2;
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>(text, value2);
			this.j.Insert(idx, item);
		}

		void IOrderedDictionary.RemoveAt(int idx)
		{
			this.b();
			this.f.Remove(this.j[idx].Key);
			this.j.RemoveAt(idx);
		}

		private ICollection c()
		{
			if (this.i == JsonType.Array)
			{
				return (ICollection)this.a;
			}
			if (this.i == JsonType.Object)
			{
				return (ICollection)this.f;
			}
			throw new InvalidOperationException("The JsonData instance has to be initialized first");
		}

		private IDictionary b()
		{
			if (this.i == JsonType.Object)
			{
				return (IDictionary)this.f;
			}
			if (this.i != JsonType.None)
			{
				throw new InvalidOperationException("Instance of JsonData is not a dictionary");
			}
			this.i = JsonType.Object;
			this.f = new Dictionary<string, JsonData>();
			this.j = new List<KeyValuePair<string, JsonData>>();
			return (IDictionary)this.f;
		}

		private IList a()
		{
			if (this.i == JsonType.Array)
			{
				return (IList)this.a;
			}
			if (this.i != JsonType.None)
			{
				throw new InvalidOperationException("Instance of JsonData is not a list");
			}
			this.i = JsonType.Array;
			this.a = new List<JsonData>();
			return (IList)this.a;
		}

		private JsonData a(object A_0)
		{
			if (A_0 == null)
			{
				return null;
			}
			if (A_0 is JsonData)
			{
				return (JsonData)A_0;
			}
			return new JsonData(A_0);
		}

		private static void a(IJsonWrapper A_0, JsonWriter A_1)
		{
			if (A_0 == null)
			{
				A_1.Write(null);
				return;
			}
			if (A_0.IsString)
			{
				A_1.Write(A_0.GetString());
				return;
			}
			if (A_0.IsBoolean)
			{
				A_1.Write(A_0.GetBoolean());
				return;
			}
			if (A_0.IsDouble)
			{
				A_1.Write(A_0.GetDouble());
				return;
			}
			if (A_0.IsInt)
			{
				A_1.Write(A_0.GetInt());
				return;
			}
			if (A_0.IsLong)
			{
				A_1.Write(A_0.GetLong());
				return;
			}
			if (A_0.IsArray)
			{
				A_1.WriteArrayStart();
				foreach (object current in A_0)
				{
					JsonData.a((JsonData)current, A_1);
				}
				A_1.WriteArrayEnd();
				return;
			}
			if (A_0.IsObject)
			{
				A_1.WriteObjectStart();
				foreach (DictionaryEntry dictionaryEntry in A_0)
				{
					A_1.WritePropertyName((string)dictionaryEntry.Key);
					JsonData.a((JsonData)dictionaryEntry.Value, A_1);
				}
				A_1.WriteObjectEnd();
			}
		}

		public int Add(object value)
		{
			JsonData value2 = this.a(value);
			this.h = null;
			return this.a().Add(value2);
		}

		public void Clear()
		{
			if (this.IsObject)
			{
				((IDictionary)this).Clear();
				return;
			}
			if (this.IsArray)
			{
				((IList)this).Clear();
			}
		}

		public bool Equals(JsonData x)
		{
			if (x == null)
			{
				return false;
			}
			if (x.i != this.i)
			{
				return false;
			}
			switch (this.i)
			{
			case JsonType.None:
				return true;
			case JsonType.Object:
				return this.f.Equals(x.f);
			case JsonType.Array:
				return this.a.Equals(x.a);
			case JsonType.String:
				return this.g.Equals(x.g);
			case JsonType.Int:
				return this.d.Equals(x.d);
			case JsonType.Long:
				return this.e.Equals(x.e);
			case JsonType.Double:
				return this.c.Equals(x.c);
			case JsonType.Boolean:
				return this.b.Equals(x.b);
			default:
				return false;
			}
		}

		public JsonType GetJsonType()
		{
			return this.i;
		}

		public void SetJsonType(JsonType type)
		{
			if (this.i == type)
			{
				return;
			}
			switch (type)
			{
			case JsonType.Object:
				this.f = new Dictionary<string, JsonData>();
				this.j = new List<KeyValuePair<string, JsonData>>();
				break;
			case JsonType.Array:
				this.a = new List<JsonData>();
				break;
			case JsonType.String:
				this.g = null;
				break;
			case JsonType.Int:
				this.d = 0;
				break;
			case JsonType.Long:
				this.e = 0L;
				break;
			case JsonType.Double:
				this.c = 0.0;
				break;
			case JsonType.Boolean:
				this.b = false;
				break;
			}
			this.i = type;
		}

		public string ToJson()
		{
			if (this.h != null)
			{
				return this.h;
			}
			StringWriter stringWriter = new StringWriter();
			JsonData.a(this, new JsonWriter(stringWriter)
			{
				Validate = false
			});
			this.h = stringWriter.ToString();
			return this.h;
		}

		public void ToJson(JsonWriter writer)
		{
			bool validate = writer.Validate;
			writer.Validate = false;
			JsonData.a(this, writer);
			writer.Validate = validate;
		}

		public override string ToString()
		{
			switch (this.i)
			{
			case JsonType.Object:
				return "JsonData object";
			case JsonType.Array:
				return "JsonData array";
			case JsonType.String:
				return this.g;
			case JsonType.Int:
				return this.d.ToString();
			case JsonType.Long:
				return this.e.ToString();
			case JsonType.Double:
				return this.c.ToString();
			case JsonType.Boolean:
				return this.b.ToString();
			default:
				return "Uninitialized JsonData";
			}
		}
	}
}
