using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WeTest.U3DAutomation
{
	public class JsonMapper
	{
		private static int a;

		private static IFormatProvider b;

		private static IDictionary<Type, y> c;

		private static IDictionary<Type, y> d;

		private static IDictionary<Type, IDictionary<Type, n>> e;

		private static IDictionary<Type, IDictionary<Type, n>> f;

		private static IDictionary<Type, w> g;

		private static readonly object h;

		private static IDictionary<Type, IDictionary<Type, MethodInfo>> i;

		private static readonly object j;

		private static IDictionary<Type, ab> k;

		private static readonly object l;

		private static IDictionary<Type, IList<p>> m;

		private static readonly object n;

		private static JsonWriter o;

		private static readonly object p;

		[CompilerGenerated]
		private static WrapperFactory q;

		[CompilerGenerated]
		private static y r;

		[CompilerGenerated]
		private static y s;

		[CompilerGenerated]
		private static y t;

		[CompilerGenerated]
		private static y u;

		[CompilerGenerated]
		private static y v;

		[CompilerGenerated]
		private static y w;

		[CompilerGenerated]
		private static y x;

		[CompilerGenerated]
		private static y y;

		[CompilerGenerated]
		private static y z;

		[CompilerGenerated]
		private static y aa;

		[CompilerGenerated]
		private static n ab;

		[CompilerGenerated]
		private static n ac;

		[CompilerGenerated]
		private static n ad;

		[CompilerGenerated]
		private static n ae;

		[CompilerGenerated]
		private static n af;

		[CompilerGenerated]
		private static n ag;

		[CompilerGenerated]
		private static n ah;

		[CompilerGenerated]
		private static n ai;

		[CompilerGenerated]
		private static n aj;

		[CompilerGenerated]
		private static n ak;

		[CompilerGenerated]
		private static n al;

		[CompilerGenerated]
		private static n am;

		[CompilerGenerated]
		private static n an;

		[CompilerGenerated]
		private static WrapperFactory ao;

		[CompilerGenerated]
		private static WrapperFactory ap;

		[CompilerGenerated]
		private static WrapperFactory aq;

		static JsonMapper()
		{
			JsonMapper.h = new object();
			JsonMapper.j = new object();
			JsonMapper.l = new object();
			JsonMapper.n = new object();
			JsonMapper.p = new object();
			JsonMapper.a = 100;
			JsonMapper.g = new Dictionary<Type, w>();
			JsonMapper.i = new Dictionary<Type, IDictionary<Type, MethodInfo>>();
			JsonMapper.k = new Dictionary<Type, ab>();
			JsonMapper.m = new Dictionary<Type, IList<p>>();
			JsonMapper.o = new JsonWriter();
			JsonMapper.b = DateTimeFormatInfo.InvariantInfo;
			JsonMapper.c = new Dictionary<Type, y>();
			JsonMapper.d = new Dictionary<Type, y>();
			JsonMapper.e = new Dictionary<Type, IDictionary<Type, n>>();
			JsonMapper.f = new Dictionary<Type, IDictionary<Type, n>>();
			JsonMapper.f();
			JsonMapper.e();
		}

		private static void c(Type A_0)
		{
			if (JsonMapper.g.ContainsKey(A_0))
			{
				return;
			}
			w value = default(w);
			value.a(A_0.IsArray);
			if (A_0.GetInterface("System.Collections.IList") != null)
			{
				value.b(true);
			}
			PropertyInfo[] properties = A_0.GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				PropertyInfo propertyInfo = properties[i];
				if (!(propertyInfo.Name != "Item"))
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters.Length == 1 && indexParameters[0].ParameterType == typeof(int))
					{
						value.a(propertyInfo.PropertyType);
					}
				}
			}
			lock (JsonMapper.h)
			{
				try
				{
					JsonMapper.g.Add(A_0, value);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void b(Type A_0)
		{
			if (JsonMapper.k.ContainsKey(A_0))
			{
				return;
			}
			ab value = default(ab);
			if (A_0.GetInterface("System.Collections.IDictionary") != null)
			{
				value.a(true);
			}
			value.a(new Dictionary<string, p>());
			PropertyInfo[] properties = A_0.GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				PropertyInfo propertyInfo = properties[i];
				if (propertyInfo.Name == "Item")
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters.Length == 1 && indexParameters[0].ParameterType == typeof(string))
					{
						value.a(propertyInfo.PropertyType);
					}
				}
				else
				{
					p value2 = default(p);
					value2.a = propertyInfo;
					value2.c = propertyInfo.PropertyType;
					value.a().Add(propertyInfo.Name, value2);
				}
			}
			FieldInfo[] fields = A_0.GetFields();
			for (int j = 0; j < fields.Length; j++)
			{
				FieldInfo fieldInfo = fields[j];
				p value3 = default(p);
				value3.a = fieldInfo;
				value3.b = true;
				value3.c = fieldInfo.FieldType;
				value.a().Add(fieldInfo.Name, value3);
			}
			lock (JsonMapper.l)
			{
				try
				{
					JsonMapper.k.Add(A_0, value);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void a(Type A_0)
		{
			if (JsonMapper.m.ContainsKey(A_0))
			{
				return;
			}
			IList<p> list = new List<p>();
			PropertyInfo[] properties = A_0.GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				PropertyInfo propertyInfo = properties[i];
				if (!(propertyInfo.Name == "Item"))
				{
					list.Add(new p
					{
						a = propertyInfo,
						b = false
					});
				}
			}
			FieldInfo[] fields = A_0.GetFields();
			for (int j = 0; j < fields.Length; j++)
			{
				FieldInfo fieldInfo = fields[j];
				list.Add(new p
				{
					a = fieldInfo,
					b = true
				});
			}
			lock (JsonMapper.n)
			{
				try
				{
					JsonMapper.m.Add(A_0, list);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static MethodInfo a(Type A_0, Type A_1)
		{
			lock (JsonMapper.j)
			{
				if (!JsonMapper.i.ContainsKey(A_0))
				{
					JsonMapper.i.Add(A_0, new Dictionary<Type, MethodInfo>());
				}
			}
			if (JsonMapper.i[A_0].ContainsKey(A_1))
			{
				return JsonMapper.i[A_0][A_1];
			}
			MethodInfo method = A_0.GetMethod("op_Implicit", new Type[]
			{
				A_1
			});
			lock (JsonMapper.j)
			{
				try
				{
					JsonMapper.i[A_0].Add(A_1, method);
				}
				catch (ArgumentException)
				{
					return JsonMapper.i[A_0][A_1];
				}
			}
			return method;
		}

		private static object a(Type A_0, JsonReader A_1)
		{
			A_1.Read();
			if (A_1.Token == JsonToken.ArrayEnd)
			{
				return null;
			}
			Type underlyingType = Nullable.GetUnderlyingType(A_0);
			Type type = underlyingType ?? A_0;
			if (A_1.Token == JsonToken.Null)
			{
				if (A_0.IsClass || underlyingType != null)
				{
					return null;
				}
				throw new JsonException(string.Format("Can't assign null to an instance of type {0}", A_0));
			}
			else
			{
				if (A_1.Token != JsonToken.Double && A_1.Token != JsonToken.Int && A_1.Token != JsonToken.Long && A_1.Token != JsonToken.String && A_1.Token != JsonToken.Float && A_1.Token != JsonToken.Boolean)
				{
					object obj = null;
					if (A_1.Token == JsonToken.ArrayStart)
					{
						JsonMapper.c(A_0);
						w w = JsonMapper.g[A_0];
						if (!w.a() && !w.c())
						{
							throw new JsonException(string.Format("Type {0} can't act as an array", A_0));
						}
						IList list;
						Type type2;
						if (!w.a())
						{
							list = (IList)Activator.CreateInstance(A_0);
							type2 = w.b();
						}
						else
						{
							list = new ArrayList();
							type2 = A_0.GetElementType();
						}
						while (true)
						{
							object obj2 = JsonMapper.a(type2, A_1);
							if (obj2 == null && A_1.Token == JsonToken.ArrayEnd)
							{
								break;
							}
							list.Add(obj2);
						}
						if (w.a())
						{
							int count = list.Count;
							obj = Array.CreateInstance(type2, count);
							for (int i = 0; i < count; i++)
							{
								((Array)obj).SetValue(list[i], i);
							}
						}
						else
						{
							obj = list;
						}
					}
					else if (A_1.Token == JsonToken.ObjectStart)
					{
						JsonMapper.b(type);
						ab ab = JsonMapper.k[type];
						obj = Activator.CreateInstance(type);
						string text;
						while (true)
						{
							A_1.Read();
							if (A_1.Token == JsonToken.ObjectEnd)
							{
								return obj;
							}
							text = (string)A_1.Value;
							if (ab.a().ContainsKey(text))
							{
								p p = ab.a()[text];
								if (p.b)
								{
									((FieldInfo)p.a).SetValue(obj, JsonMapper.a(p.c, A_1));
								}
								else
								{
									PropertyInfo propertyInfo = (PropertyInfo)p.a;
									if (propertyInfo.CanWrite)
									{
										propertyInfo.SetValue(obj, JsonMapper.a(p.c, A_1), null);
									}
									else
									{
										JsonMapper.a(p.c, A_1);
									}
								}
							}
							else if (!ab.c())
							{
								if (!A_1.SkipNonMembers)
								{
									break;
								}
								JsonMapper.a(A_1);
							}
							else
							{
								((IDictionary)obj).Add(text, JsonMapper.a(ab.b(), A_1));
							}
						}
						throw new JsonException(string.Format("The type {0} doesn't have the property '{1}'", A_0, text));
					}
					return obj;
				}
				Type type3 = A_1.Value.GetType();
				if (type.IsAssignableFrom(type3))
				{
					return A_1.Value;
				}
				if (JsonMapper.f.ContainsKey(type3) && JsonMapper.f[type3].ContainsKey(type))
				{
					n n = JsonMapper.f[type3][type];
					return n(A_1.Value);
				}
				if (JsonMapper.e.ContainsKey(type3) && JsonMapper.e[type3].ContainsKey(type))
				{
					n n2 = JsonMapper.e[type3][type];
					return n2(A_1.Value);
				}
				if (type.IsEnum)
				{
					return Enum.ToObject(type, A_1.Value);
				}
				MethodInfo methodInfo = JsonMapper.a(type, type3);
				if (methodInfo != null)
				{
					return methodInfo.Invoke(null, new object[]
					{
						A_1.Value
					});
				}
				throw new JsonException(string.Format("Can't assign value '{0}' (type {1}) to type {2}", A_1.Value, type3, A_0));
			}
		}

		private static IJsonWrapper a(WrapperFactory A_0, JsonReader A_1)
		{
			A_1.Read();
			if (A_1.Token == JsonToken.ArrayEnd || A_1.Token == JsonToken.Null)
			{
				return null;
			}
			IJsonWrapper jsonWrapper = A_0();
			if (A_1.Token == JsonToken.String)
			{
				jsonWrapper.SetString((string)A_1.Value);
				return jsonWrapper;
			}
			if (A_1.Token == JsonToken.Double)
			{
				jsonWrapper.SetDouble((double)A_1.Value);
				return jsonWrapper;
			}
			if (A_1.Token == JsonToken.Int)
			{
				jsonWrapper.SetInt((int)A_1.Value);
				return jsonWrapper;
			}
			if (A_1.Token == JsonToken.Long)
			{
				jsonWrapper.SetLong((long)A_1.Value);
				return jsonWrapper;
			}
			if (A_1.Token == JsonToken.Boolean)
			{
				jsonWrapper.SetBoolean((bool)A_1.Value);
				return jsonWrapper;
			}
			if (A_1.Token == JsonToken.ArrayStart)
			{
				jsonWrapper.SetJsonType(JsonType.Array);
				while (true)
				{
					IJsonWrapper jsonWrapper2 = JsonMapper.a(A_0, A_1);
					if (jsonWrapper2 == null && A_1.Token == JsonToken.ArrayEnd)
					{
						break;
					}
					jsonWrapper.Add(jsonWrapper2);
				}
			}
			else if (A_1.Token == JsonToken.ObjectStart)
			{
				jsonWrapper.SetJsonType(JsonType.Object);
				while (true)
				{
					A_1.Read();
					if (A_1.Token == JsonToken.ObjectEnd)
					{
						break;
					}
					string key = (string)A_1.Value;
					jsonWrapper[key] = JsonMapper.a(A_0, A_1);
				}
			}
			return jsonWrapper;
		}

		private static void a(JsonReader A_0)
		{
			if (JsonMapper.q == null)
			{
				JsonMapper.q = new WrapperFactory(JsonMapper.d);
			}
			JsonMapper.ToWrapper(JsonMapper.q, A_0);
		}

		private static void f()
		{
			IDictionary<Type, y> arg_2C_0 = JsonMapper.c;
			Type arg_2C_1 = typeof(byte);
			if (JsonMapper.r == null)
			{
				JsonMapper.r = new y(JsonMapper.j);
			}
			arg_2C_0[arg_2C_1] = JsonMapper.r;
			IDictionary<Type, y> arg_5D_0 = JsonMapper.c;
			Type arg_5D_1 = typeof(char);
			if (JsonMapper.s == null)
			{
				JsonMapper.s = new y(JsonMapper.i);
			}
			arg_5D_0[arg_5D_1] = JsonMapper.s;
			IDictionary<Type, y> arg_8E_0 = JsonMapper.c;
			Type arg_8E_1 = typeof(DateTime);
			if (JsonMapper.t == null)
			{
				JsonMapper.t = new y(JsonMapper.h);
			}
			arg_8E_0[arg_8E_1] = JsonMapper.t;
			IDictionary<Type, y> arg_BF_0 = JsonMapper.c;
			Type arg_BF_1 = typeof(decimal);
			if (JsonMapper.u == null)
			{
				JsonMapper.u = new y(JsonMapper.g);
			}
			arg_BF_0[arg_BF_1] = JsonMapper.u;
			IDictionary<Type, y> arg_F0_0 = JsonMapper.c;
			Type arg_F0_1 = typeof(sbyte);
			if (JsonMapper.v == null)
			{
				JsonMapper.v = new y(JsonMapper.f);
			}
			arg_F0_0[arg_F0_1] = JsonMapper.v;
			IDictionary<Type, y> arg_121_0 = JsonMapper.c;
			Type arg_121_1 = typeof(short);
			if (JsonMapper.w == null)
			{
				JsonMapper.w = new y(JsonMapper.e);
			}
			arg_121_0[arg_121_1] = JsonMapper.w;
			IDictionary<Type, y> arg_152_0 = JsonMapper.c;
			Type arg_152_1 = typeof(ushort);
			if (JsonMapper.x == null)
			{
				JsonMapper.x = new y(JsonMapper.d);
			}
			arg_152_0[arg_152_1] = JsonMapper.x;
			IDictionary<Type, y> arg_183_0 = JsonMapper.c;
			Type arg_183_1 = typeof(uint);
			if (JsonMapper.y == null)
			{
				JsonMapper.y = new y(JsonMapper.c);
			}
			arg_183_0[arg_183_1] = JsonMapper.y;
			IDictionary<Type, y> arg_1B4_0 = JsonMapper.c;
			Type arg_1B4_1 = typeof(ulong);
			if (JsonMapper.z == null)
			{
				JsonMapper.z = new y(JsonMapper.b);
			}
			arg_1B4_0[arg_1B4_1] = JsonMapper.z;
			IDictionary<Type, y> arg_1E5_0 = JsonMapper.c;
			Type arg_1E5_1 = typeof(float);
			if (JsonMapper.aa == null)
			{
				JsonMapper.aa = new y(JsonMapper.a);
			}
			arg_1E5_0[arg_1E5_1] = JsonMapper.aa;
		}

		private static void e()
		{
			if (JsonMapper.ab == null)
			{
				JsonMapper.ab = new n(JsonMapper.m);
			}
			n a_ = JsonMapper.ab;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(byte), a_);
			if (JsonMapper.ac == null)
			{
				JsonMapper.ac = new n(JsonMapper.l);
			}
			a_ = JsonMapper.ac;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(ulong), a_);
			if (JsonMapper.ad == null)
			{
				JsonMapper.ad = new n(JsonMapper.k);
			}
			a_ = JsonMapper.ad;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(sbyte), a_);
			if (JsonMapper.ae == null)
			{
				JsonMapper.ae = new n(JsonMapper.j);
			}
			a_ = JsonMapper.ae;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(short), a_);
			if (JsonMapper.af == null)
			{
				JsonMapper.af = new n(JsonMapper.i);
			}
			a_ = JsonMapper.af;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(ushort), a_);
			if (JsonMapper.ag == null)
			{
				JsonMapper.ag = new n(JsonMapper.h);
			}
			a_ = JsonMapper.ag;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(uint), a_);
			if (JsonMapper.ah == null)
			{
				JsonMapper.ah = new n(JsonMapper.g);
			}
			a_ = JsonMapper.ah;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(float), a_);
			if (JsonMapper.ai == null)
			{
				JsonMapper.ai = new n(JsonMapper.f);
			}
			a_ = JsonMapper.ai;
			JsonMapper.a(JsonMapper.e, typeof(int), typeof(double), a_);
			if (JsonMapper.aj == null)
			{
				JsonMapper.aj = new n(JsonMapper.e);
			}
			a_ = JsonMapper.aj;
			JsonMapper.a(JsonMapper.e, typeof(double), typeof(decimal), a_);
			if (JsonMapper.ak == null)
			{
				JsonMapper.ak = new n(JsonMapper.d);
			}
			a_ = JsonMapper.ak;
			JsonMapper.a(JsonMapper.e, typeof(float), typeof(decimal), a_);
			if (JsonMapper.al == null)
			{
				JsonMapper.al = new n(JsonMapper.c);
			}
			a_ = JsonMapper.al;
			JsonMapper.a(JsonMapper.e, typeof(long), typeof(uint), a_);
			if (JsonMapper.am == null)
			{
				JsonMapper.am = new n(JsonMapper.b);
			}
			a_ = JsonMapper.am;
			JsonMapper.a(JsonMapper.e, typeof(string), typeof(char), a_);
			if (JsonMapper.an == null)
			{
				JsonMapper.an = new n(JsonMapper.a);
			}
			a_ = JsonMapper.an;
			JsonMapper.a(JsonMapper.e, typeof(string), typeof(DateTime), a_);
		}

		private static void a(IDictionary<Type, IDictionary<Type, n>> A_0, Type A_1, Type A_2, n A_3)
		{
			if (!A_0.ContainsKey(A_1))
			{
				A_0.Add(A_1, new Dictionary<Type, n>());
			}
			A_0[A_1][A_2] = A_3;
		}

		private static void a(object A_0, JsonWriter A_1, bool A_2, int A_3)
		{
			if (A_3 > JsonMapper.a)
			{
				throw new JsonException(string.Format("Max allowed object depth reached while trying to export from type {0} {1}", A_0.GetType(), A_3));
			}
			if (A_0 == null)
			{
				A_1.Write(null);
				return;
			}
			if (A_0 is IJsonWrapper)
			{
				if (A_2)
				{
					A_1.TextWriter.Write(((IJsonWrapper)A_0).ToJson());
					return;
				}
				((IJsonWrapper)A_0).ToJson(A_1);
				return;
			}
			else
			{
				if (A_0 is string)
				{
					A_1.Write((string)A_0);
					return;
				}
				if (A_0 is double)
				{
					A_1.Write((double)A_0);
					return;
				}
				if (A_0 is int)
				{
					A_1.Write((int)A_0);
					return;
				}
				if (A_0 is bool)
				{
					A_1.Write((bool)A_0);
					return;
				}
				if (A_0 is long)
				{
					A_1.Write((long)A_0);
					return;
				}
				if (A_0 is Array)
				{
					A_1.WriteArrayStart();
					foreach (object current in ((Array)A_0))
					{
						JsonMapper.a(current, A_1, A_2, A_3 + 1);
					}
					A_1.WriteArrayEnd();
					return;
				}
				if (A_0 is IList)
				{
					A_1.WriteArrayStart();
					foreach (object current2 in ((IList)A_0))
					{
						JsonMapper.a(current2, A_1, A_2, A_3 + 1);
					}
					A_1.WriteArrayEnd();
					return;
				}
				if (A_0 is IDictionary)
				{
					A_1.WriteObjectStart();
					foreach (DictionaryEntry dictionaryEntry in ((IDictionary)A_0))
					{
						A_1.WritePropertyName((string)dictionaryEntry.Key);
						JsonMapper.a(dictionaryEntry.Value, A_1, A_2, A_3 + 1);
					}
					A_1.WriteObjectEnd();
					return;
				}
				Type type = A_0.GetType();
				if (JsonMapper.d.ContainsKey(type))
				{
					y y = JsonMapper.d[type];
					y(A_0, A_1);
					return;
				}
				if (JsonMapper.c.ContainsKey(type))
				{
					y y2 = JsonMapper.c[type];
					y2(A_0, A_1);
					return;
				}
				if (!(A_0 is Enum))
				{
					JsonMapper.a(type);
					IList<p> list = JsonMapper.m[type];
					A_1.WriteObjectStart();
					foreach (p current3 in list)
					{
						if (current3.b)
						{
							A_1.WritePropertyName(current3.a.Name);
							JsonMapper.a(((FieldInfo)current3.a).GetValue(A_0), A_1, A_2, A_3 + 1);
						}
						else
						{
							PropertyInfo propertyInfo = (PropertyInfo)current3.a;
							if (propertyInfo.CanRead)
							{
								A_1.WritePropertyName(current3.a.Name);
								JsonMapper.a(propertyInfo.GetValue(A_0, null), A_1, A_2, A_3 + 1);
							}
						}
					}
					A_1.WriteObjectEnd();
					return;
				}
				Type underlyingType = Enum.GetUnderlyingType(type);
				if (underlyingType == typeof(long) || underlyingType == typeof(uint) || underlyingType == typeof(ulong))
				{
					A_1.Write((ulong)A_0);
					return;
				}
				A_1.Write((int)A_0);
				return;
			}
		}

		public static string ToJson(object obj)
		{
			string result;
			lock (JsonMapper.p)
			{
				JsonMapper.o.Reset();
				JsonMapper.a(obj, JsonMapper.o, true, 0);
				result = JsonMapper.o.ToString();
			}
			return result;
		}

		public static void ToJson(object obj, JsonWriter writer)
		{
			JsonMapper.a(obj, writer, false, 0);
		}

		public static JsonData ToObject(JsonReader reader)
		{
			if (JsonMapper.ao == null)
			{
				JsonMapper.ao = new WrapperFactory(JsonMapper.c);
			}
			return (JsonData)JsonMapper.ToWrapper(JsonMapper.ao, reader);
		}

		public static JsonData ToObject(TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			if (JsonMapper.ap == null)
			{
				JsonMapper.ap = new WrapperFactory(JsonMapper.b);
			}
			return (JsonData)JsonMapper.ToWrapper(JsonMapper.ap, reader2);
		}

		public static JsonData ToObject(string json)
		{
			if (JsonMapper.aq == null)
			{
				JsonMapper.aq = new WrapperFactory(JsonMapper.a);
			}
			return (JsonData)JsonMapper.ToWrapper(JsonMapper.aq, json);
		}

		public static T ToObject<T>(JsonReader reader)
		{
			return (T)((object)JsonMapper.a(typeof(T), reader));
		}

		public static T ToObject<T>(TextReader reader)
		{
			JsonReader a_ = new JsonReader(reader);
			return (T)((object)JsonMapper.a(typeof(T), a_));
		}

		public static T ToObject<T>(string json)
		{
			JsonReader a_ = new JsonReader(json);
			return (T)((object)JsonMapper.a(typeof(T), a_));
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, JsonReader reader)
		{
			return JsonMapper.a(factory, reader);
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, string json)
		{
			JsonReader a_ = new JsonReader(json);
			return JsonMapper.a(factory, a_);
		}

		public static void RegisterExporter<T>(ExporterFunc<T> exporter)
		{
			JsonMapper.<>c__DisplayClass37<T> <>c__DisplayClass = new JsonMapper.<>c__DisplayClass37<T>();
			<>c__DisplayClass.a = exporter;
			y value = new y(<>c__DisplayClass.b);
			JsonMapper.d[typeof(T)] = value;
		}

		public static void RegisterImporter<TJson, TValue>(ImporterFunc<TJson, TValue> importer)
		{
			JsonMapper.<>c__DisplayClass3a<TJson, TValue> <>c__DisplayClass3a = new JsonMapper.<>c__DisplayClass3a<TJson, TValue>();
			<>c__DisplayClass3a.a = importer;
			n a_ = new n(<>c__DisplayClass3a.b);
			JsonMapper.a(JsonMapper.f, typeof(TJson), typeof(TValue), a_);
		}

		public static void UnregisterExporters()
		{
			JsonMapper.d.Clear();
		}

		public static void UnregisterImporters()
		{
			JsonMapper.f.Clear();
		}

		[CompilerGenerated]
		private static IJsonWrapper d()
		{
			return new JsonMockWrapper();
		}

		[CompilerGenerated]
		private static void j(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToInt32((byte)A_0));
		}

		[CompilerGenerated]
		private static void i(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToString((char)A_0));
		}

		[CompilerGenerated]
		private static void h(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToString((DateTime)A_0, JsonMapper.b));
		}

		[CompilerGenerated]
		private static void g(object A_0, JsonWriter A_1)
		{
			A_1.Write((decimal)A_0);
		}

		[CompilerGenerated]
		private static void f(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToInt32((sbyte)A_0));
		}

		[CompilerGenerated]
		private static void e(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToInt32((short)A_0));
		}

		[CompilerGenerated]
		private static void d(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToInt32((ushort)A_0));
		}

		[CompilerGenerated]
		private static void c(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToUInt64((uint)A_0));
		}

		[CompilerGenerated]
		private static void b(object A_0, JsonWriter A_1)
		{
			A_1.Write((ulong)A_0);
		}

		[CompilerGenerated]
		private static void a(object A_0, JsonWriter A_1)
		{
			A_1.Write(Convert.ToDouble((float)A_0));
		}

		[CompilerGenerated]
		private static object m(object A_0)
		{
			return Convert.ToByte((int)A_0);
		}

		[CompilerGenerated]
		private static object l(object A_0)
		{
			return Convert.ToUInt64((int)A_0);
		}

		[CompilerGenerated]
		private static object k(object A_0)
		{
			return Convert.ToSByte((int)A_0);
		}

		[CompilerGenerated]
		private static object j(object A_0)
		{
			return Convert.ToInt16((int)A_0);
		}

		[CompilerGenerated]
		private static object i(object A_0)
		{
			return Convert.ToUInt16((int)A_0);
		}

		[CompilerGenerated]
		private static object h(object A_0)
		{
			return Convert.ToUInt32((int)A_0);
		}

		[CompilerGenerated]
		private static object g(object A_0)
		{
			return Convert.ToSingle((int)A_0);
		}

		[CompilerGenerated]
		private static object f(object A_0)
		{
			return Convert.ToDouble((int)A_0);
		}

		[CompilerGenerated]
		private static object e(object A_0)
		{
			return Convert.ToDecimal((double)A_0);
		}

		[CompilerGenerated]
		private static object d(object A_0)
		{
			return Convert.ToDecimal((float)A_0);
		}

		[CompilerGenerated]
		private static object c(object A_0)
		{
			return Convert.ToUInt32((long)A_0);
		}

		[CompilerGenerated]
		private static object b(object A_0)
		{
			return Convert.ToChar((string)A_0);
		}

		[CompilerGenerated]
		private static object a(object A_0)
		{
			return Convert.ToDateTime((string)A_0, JsonMapper.b);
		}

		[CompilerGenerated]
		private static IJsonWrapper c()
		{
			return new JsonData();
		}

		[CompilerGenerated]
		private static IJsonWrapper b()
		{
			return new JsonData();
		}

		[CompilerGenerated]
		private static IJsonWrapper a()
		{
			return new JsonData();
		}
	}
}
