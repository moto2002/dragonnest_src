using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public abstract class CVSReader
	{
		public abstract class ValueParse<T>
		{
			public abstract T Parse(string Field);

			public abstract int ParseBuffer(string Field);

			public abstract int DefaultValue();

			public abstract void Write(BinaryWriter stream, string data);

			public abstract void Read(BinaryReader stream, ref T t);

			public abstract int ReadBuffer(BinaryReader stream);

			public abstract void SkipBuffer(BinaryReader stream, int count);
		}

		public sealed class UIntParse : CVSReader.ValueParse<uint>
		{
			public override uint Parse(string Field)
			{
				if (Field.Length == 0)
				{
					return 0u;
				}
				return uint.Parse(Field);
			}

			public override int ParseBuffer(string Field)
			{
				if (Field.Length == 0)
				{
					return 0;
				}
				CVSReader.ReAllocBuff<uint>(ref CVSReader.uintBuffer, CVSReader.uintIndex);
				CVSReader.uintBuffer[CVSReader.uintIndex] = uint.Parse(Field);
				return CVSReader.uintIndex++;
			}

			public override int DefaultValue()
			{
				CVSReader.ReAllocBuff<uint>(ref CVSReader.uintBuffer, CVSReader.uintIndex);
				CVSReader.uintBuffer[CVSReader.uintIndex] = 0u;
				return CVSReader.uintIndex++;
			}

			public override void Write(BinaryWriter stream, string data)
			{
				uint value = 0u;
				if (!string.IsNullOrEmpty(data))
				{
					uint.TryParse(data, out value);
				}
				stream.Write(value);
			}

			public override void Read(BinaryReader stream, ref uint t)
			{
				t = stream.ReadUInt32();
			}

			public override int ReadBuffer(BinaryReader stream)
			{
				CVSReader.ReAllocBuff<uint>(ref CVSReader.uintBuffer, CVSReader.uintIndex);
				CVSReader.uintBuffer[CVSReader.uintIndex] = stream.ReadUInt32();
				return CVSReader.uintIndex++;
			}

			public override void SkipBuffer(BinaryReader stream, int count)
			{
				stream.BaseStream.Seek((long)(4 * count), SeekOrigin.Current);
			}
		}

		public sealed class IntParse : CVSReader.ValueParse<int>
		{
			public override int Parse(string Field)
			{
				if (Field.Length == 0)
				{
					return 0;
				}
				return int.Parse(Field);
			}

			public override int ParseBuffer(string Field)
			{
				if (Field.Length == 0)
				{
					return 0;
				}
				CVSReader.ReAllocBuff<int>(ref CVSReader.intBuffer, CVSReader.intIndex);
				CVSReader.intBuffer[CVSReader.intIndex] = int.Parse(Field);
				return CVSReader.intIndex++;
			}

			public override int DefaultValue()
			{
				CVSReader.ReAllocBuff<int>(ref CVSReader.intBuffer, CVSReader.intIndex);
				CVSReader.intBuffer[CVSReader.intIndex] = 0;
				return CVSReader.intIndex++;
			}

			public override void Write(BinaryWriter stream, string data)
			{
				int value = 0;
				if (!string.IsNullOrEmpty(data))
				{
					int.TryParse(data, out value);
				}
				stream.Write(value);
			}

			public override void Read(BinaryReader stream, ref int t)
			{
				t = stream.ReadInt32();
			}

			public override int ReadBuffer(BinaryReader stream)
			{
				CVSReader.ReAllocBuff<int>(ref CVSReader.intBuffer, CVSReader.intIndex);
				CVSReader.intBuffer[CVSReader.intIndex] = stream.ReadInt32();
				return CVSReader.intIndex++;
			}

			public override void SkipBuffer(BinaryReader stream, int count)
			{
				stream.BaseStream.Seek((long)(4 * count), SeekOrigin.Current);
			}
		}

		public sealed class LongParse : CVSReader.ValueParse<long>
		{
			public override long Parse(string Field)
			{
				if (Field.Length == 0)
				{
					return 0L;
				}
				return long.Parse(Field);
			}

			public override int ParseBuffer(string Field)
			{
				if (Field.Length == 0)
				{
					return 0;
				}
				CVSReader.ReAllocBuff<long>(ref CVSReader.longBuffer, CVSReader.longIndex);
				CVSReader.longBuffer[CVSReader.longIndex] = long.Parse(Field);
				return CVSReader.longIndex++;
			}

			public override int DefaultValue()
			{
				CVSReader.ReAllocBuff<long>(ref CVSReader.longBuffer, CVSReader.longIndex);
				CVSReader.longBuffer[CVSReader.longIndex] = 0L;
				return CVSReader.longIndex++;
			}

			public override void Write(BinaryWriter stream, string data)
			{
				long value = 0L;
				if (!string.IsNullOrEmpty(data))
				{
					long.TryParse(data, out value);
				}
				stream.Write(value);
			}

			public override void Read(BinaryReader stream, ref long t)
			{
				t = stream.ReadInt64();
			}

			public override int ReadBuffer(BinaryReader stream)
			{
				CVSReader.ReAllocBuff<long>(ref CVSReader.longBuffer, CVSReader.longIndex);
				CVSReader.longBuffer[CVSReader.longIndex] = stream.ReadInt64();
				return CVSReader.longIndex++;
			}

			public override void SkipBuffer(BinaryReader stream, int count)
			{
				stream.BaseStream.Seek((long)(8 * count), SeekOrigin.Current);
			}
		}

		public sealed class FloatParse : CVSReader.ValueParse<float>
		{
			public override float Parse(string Field)
			{
				if (Field.Length == 0)
				{
					return 0f;
				}
				return float.Parse(Field);
			}

			public override int ParseBuffer(string Field)
			{
				if (Field.Length == 0)
				{
					return -1;
				}
				CVSReader.ReAllocBuff<float>(ref CVSReader.floatBuffer, CVSReader.floatIndex);
				CVSReader.floatBuffer[CVSReader.floatIndex] = float.Parse(Field);
				return CVSReader.floatIndex++;
			}

			public override int DefaultValue()
			{
				CVSReader.ReAllocBuff<float>(ref CVSReader.floatBuffer, CVSReader.floatIndex);
				CVSReader.floatBuffer[CVSReader.floatIndex] = 0f;
				return CVSReader.floatIndex++;
			}

			public override void Write(BinaryWriter stream, string data)
			{
				float value = 0f;
				if (!string.IsNullOrEmpty(data))
				{
					float.TryParse(data, out value);
				}
				stream.Write(value);
			}

			public override void Read(BinaryReader stream, ref float t)
			{
				t = stream.ReadSingle();
			}

			public override int ReadBuffer(BinaryReader stream)
			{
				CVSReader.ReAllocBuff<float>(ref CVSReader.floatBuffer, CVSReader.floatIndex);
				float num = stream.ReadSingle();
				CVSReader.floatBuffer[CVSReader.floatIndex] = num;
				return CVSReader.floatIndex++;
			}

			public override void SkipBuffer(BinaryReader stream, int count)
			{
				stream.BaseStream.Seek((long)(4 * count), SeekOrigin.Current);
			}
		}

		public sealed class DoubleParse : CVSReader.ValueParse<double>
		{
			public override double Parse(string Field)
			{
				if (Field.Length == 0)
				{
					return 0.0;
				}
				return double.Parse(Field);
			}

			public override int ParseBuffer(string Field)
			{
				if (Field.Length == 0)
				{
					return 0;
				}
				CVSReader.ReAllocBuff<double>(ref CVSReader.doubleBuffer, CVSReader.doubleIndex);
				CVSReader.doubleBuffer[CVSReader.doubleIndex] = double.Parse(Field);
				return CVSReader.doubleIndex++;
			}

			public override int DefaultValue()
			{
				CVSReader.ReAllocBuff<double>(ref CVSReader.doubleBuffer, CVSReader.doubleIndex);
				CVSReader.doubleBuffer[CVSReader.doubleIndex] = 0.0;
				return CVSReader.doubleIndex++;
			}

			public override void Write(BinaryWriter stream, string data)
			{
				double value = 0.0;
				if (!string.IsNullOrEmpty(data))
				{
					double.TryParse(data, out value);
				}
				stream.Write(value);
			}

			public override void Read(BinaryReader stream, ref double t)
			{
				t = stream.ReadDouble();
			}

			public override int ReadBuffer(BinaryReader stream)
			{
				CVSReader.ReAllocBuff<double>(ref CVSReader.doubleBuffer, CVSReader.doubleIndex);
				CVSReader.doubleBuffer[CVSReader.doubleIndex] = stream.ReadDouble();
				return CVSReader.doubleIndex++;
			}

			public override void SkipBuffer(BinaryReader stream, int count)
			{
				stream.BaseStream.Seek((long)(8 * count), SeekOrigin.Current);
			}
		}

		public sealed class StringParse : CVSReader.ValueParse<string>
		{
			public override string Parse(string Field)
			{
				return Field;
			}

			public override int ParseBuffer(string Field)
			{
				if (Field.Length == 0)
				{
					return 0;
				}
				string text = CVSReader.LookupInterString(XSingleton<XCommon>.singleton.XHash(Field), Field);
				CVSReader.ReAllocBuff<string>(ref CVSReader.stringBuffer, CVSReader.stringIndex);
				CVSReader.stringBuffer[CVSReader.stringIndex] = text;
				return CVSReader.stringIndex++;
			}

			public override int DefaultValue()
			{
				CVSReader.ReAllocBuff<string>(ref CVSReader.stringBuffer, CVSReader.stringIndex);
				CVSReader.stringBuffer[CVSReader.stringIndex] = "";
				return CVSReader.stringIndex++;
			}

			public override void Write(BinaryWriter stream, string data)
			{
				if (string.IsNullOrEmpty(data))
				{
					stream.Write("");
					return;
				}
				stream.Write(data);
			}

			public override void Read(BinaryReader stream, ref string t)
			{
				t = string.Intern(stream.ReadString());
			}

			public override int ReadBuffer(BinaryReader stream)
			{
				CVSReader.ReAllocBuff<string>(ref CVSReader.stringBuffer, CVSReader.stringIndex);
				CVSReader.stringBuffer[CVSReader.stringIndex] = string.Intern(stream.ReadString());
				return CVSReader.stringIndex++;
			}

			public override void SkipBuffer(BinaryReader stream, int count)
			{
				for (int i = 0; i < count; i++)
				{
					stream.ReadString();
				}
			}
		}

		public struct SeqCache
		{
			public int valueIndex;

			public int indexIndex;
		}

		public static Dictionary<uint, CVSReader.SeqCache> _seqIndex = null;

		public static float[] floatBuffer;

		public static int floatIndex = 0;

		public static uint[] uintBuffer;

		public static int uintIndex = 0;

		public static int[] intBuffer;

		public static int intIndex = 0;

		public static long[] longBuffer;

		public static int longIndex = 0;

		public static double[] doubleBuffer;

		public static int doubleIndex = 0;

		public static string[] stringBuffer;

		public static int stringIndex = 0;

		public static int[] indexBuffer;

		public static int indexIndex = 0;

		protected static CVSReader.FloatParse floatParse = new CVSReader.FloatParse();

		protected static CVSReader.UIntParse uintParse = new CVSReader.UIntParse();

		protected static CVSReader.IntParse intParse = new CVSReader.IntParse();

		protected static CVSReader.LongParse longParse = new CVSReader.LongParse();

		protected static CVSReader.DoubleParse doubleParse = new CVSReader.DoubleParse();

		protected static CVSReader.StringParse stringParse = new CVSReader.StringParse();

		public int lineno = -1;

		public int columnno = -1;

		public static readonly char[] ListSeparator = new char[]
		{
			'|'
		};

		public static readonly char[] SeqSeparator = new char[]
		{
			'='
		};

		protected List<int> ColMap;

		public List<string> Comment;

		public string error
		{
			get
			{
				return " line: " + this.lineno.ToString() + " column: " + this.columnno.ToString();
			}
		}

		public static bool IsInited()
		{
			return CVSReader._seqIndex != null;
		}

		public static void Init()
		{
			CVSReader.Uninit();
			if (CVSReader._seqIndex == null)
			{
				CVSReader._seqIndex = new Dictionary<uint, CVSReader.SeqCache>();
			}
			CVSReader.InitBuff<float>(ref CVSReader.floatBuffer, ref CVSReader.floatIndex, 4f, 0f);
			CVSReader.InitBuff<uint>(ref CVSReader.uintBuffer, ref CVSReader.uintIndex, 16f, 0u);
			CVSReader.InitBuff<int>(ref CVSReader.intBuffer, ref CVSReader.intIndex, 2f, 0);
			CVSReader.InitBuff<long>(ref CVSReader.longBuffer, ref CVSReader.longIndex, 1f, 0L);
			CVSReader.InitBuff<double>(ref CVSReader.doubleBuffer, ref CVSReader.doubleIndex, 0.1f, 0.0);
			CVSReader.InitBuff<string>(ref CVSReader.stringBuffer, ref CVSReader.stringIndex, 1f, "");
			CVSReader.indexIndex = 0;
			CVSReader.indexBuffer = new int[524288];
			int i = 0;
			int num = CVSReader.indexBuffer.Length;
			while (i < num)
			{
				CVSReader.indexBuffer[i] = 0;
				i++;
			}
			CVSReader.indexBuffer[CVSReader.indexIndex++] = 0;
		}

		public static void Uninit()
		{
			if (CVSReader._seqIndex != null)
			{
				CVSReader._seqIndex.Clear();
				CVSReader._seqIndex = null;
				GC.Collect();
			}
		}

		private static void ReAllocBuff<T>(ref T[] buffer, int index)
		{
			if (index >= buffer.Length)
			{
				T[] array = new T[buffer.Length + buffer.Length / 2];
				Array.Copy(buffer, 0, array, 0, buffer.Length);
				buffer = array;
				Seq2Ref<T>.buffRef = buffer;
				Seq3Ref<T>.buffRef = buffer;
				Seq4Ref<T>.buffRef = buffer;
				Seq2ListRef<T>.buffRef = buffer;
				Seq3ListRef<T>.buffRef = buffer;
				Seq4ListRef<T>.buffRef = buffer;
			}
		}

		private static void InitBuff<T>(ref T[] buffer, ref int index, float size, T defalutValue)
		{
			buffer = new T[(int)(1024f * size)];
			int i = 0;
			int num = buffer.Length;
			while (i < num)
			{
				buffer[i] = defalutValue;
				i++;
			}
			index = 6;
			Seq2Ref<T>.buffRef = buffer;
			Seq3Ref<T>.buffRef = buffer;
			Seq4Ref<T>.buffRef = buffer;
			Seq2ListRef<T>.buffRef = buffer;
			Seq3ListRef<T>.buffRef = buffer;
			Seq4ListRef<T>.buffRef = buffer;
		}

		public CVSReader()
		{
			this.lineno = 1;
		}

		private static string LookupInterString(uint hash, string value)
		{
			return string.Intern(value);
		}

		public bool LoadFile(Stream stream, bool append)
		{
			bool flag = true;
			this.ColMap = new List<int>();
			char[] trimChars = new char[]
			{
				'\r',
				'\n'
			};
			if (!append)
			{
				this.ColMap.Clear();
				this.lineno = 1;
				this.OnClear();
			}
			StreamReader streamReader = new StreamReader(stream);
			while (true)
			{
				string text = streamReader.ReadLine();
				if (text == null)
				{
					break;
				}
				text = text.TrimEnd(trimChars);
				string[] fields = text.Split(new char[]
				{
					'\t'
				});
				if (this.lineno == 1)
				{
					flag = this.OnHeaderLine(fields);
				}
				else if (this.lineno == 2)
				{
					flag = this.OnCommentLine(fields);
				}
				else
				{
					flag = this.OnLine(fields);
				}
				if (!flag)
				{
					break;
				}
				this.lineno++;
			}
			streamReader.Close();
			this.ColMap.Clear();
			return flag;
		}

		public void WriteFile(Stream src, Stream des)
		{
			bool flag = true;
			this.ColMap = new List<int>();
			char[] trimChars = new char[]
			{
				'\r',
				'\n'
			};
			StreamReader streamReader = new StreamReader(src);
			BinaryWriter binaryWriter = new BinaryWriter(des);
			int num = 0;
			binaryWriter.Write(num);
			while (true)
			{
				string text = streamReader.ReadLine();
				if (text == null)
				{
					break;
				}
				text = text.TrimEnd(trimChars);
				string[] fields = text.Split(new char[]
				{
					'\t'
				});
				if (this.lineno == 1)
				{
					flag = this.OnHeaderLine(fields);
				}
				else if (this.lineno != 2)
				{
					this.WriteLine(fields, binaryWriter);
					num++;
				}
				if (!flag)
				{
					break;
				}
				this.lineno++;
			}
			binaryWriter.Seek(0, SeekOrigin.Begin);
			binaryWriter.Write(num);
			streamReader.Close();
			binaryWriter.Close();
		}

		public bool ReadFile(Stream stream)
		{
			this.lineno = 1;
			this.OnClear();
			this.columnno = -1;
			BinaryReader binaryReader = new BinaryReader(stream);
			int num = binaryReader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				this.ReadLine(binaryReader);
				this.lineno++;
				if (this.columnno > 0)
				{
					break;
				}
			}
			return this.columnno == -1;
		}

		protected bool MapColHeader(string[] ColHeaders, string[] Fields)
		{
			for (int i = 0; i < ColHeaders.Length; i++)
			{
				this.ColMap.Add(-1);
			}
			for (int i = 0; i < Fields.Length; i++)
			{
				for (int j = 0; j < ColHeaders.Length; j++)
				{
					if (Fields[i] == ColHeaders[j])
					{
						this.ColMap[j] = i;
					}
				}
			}
			for (int i = 0; i < ColHeaders.Length; i++)
			{
				if (this.ColMap[i] == -1)
				{
					this.lineno = 1;
					this.columnno = i;
					return false;
				}
			}
			return true;
		}

		private uint ComputerHash(string s, string append)
		{
			return XSingleton<XCommon>.singleton.XHash(s + append);
		}

		public bool Parse(string Field, ref string t)
		{
			t = CVSReader.LookupInterString(XSingleton<XCommon>.singleton.XHash(Field), Field);
			return true;
		}

		public bool Parse(string Field, ref bool t)
		{
			if (Field.Length == 0)
			{
				t = false;
			}
			if (Field == "true" || Field == "TRUE" || Field == "True" || Field == "1")
			{
				t = true;
			}
			if (Field == "false" || Field == "FALSE" || Field == "False" || Field == "0")
			{
				t = false;
			}
			return true;
		}

		public bool Parse(string Field, ref int t)
		{
			if (Field.Length == 0)
			{
				t = 0;
			}
			else
			{
				t = int.Parse(Field);
			}
			return true;
		}

		public bool Parse(string Field, ref uint t)
		{
			if (Field.Length == 0)
			{
				t = 0u;
			}
			else
			{
				t = uint.Parse(Field);
			}
			return true;
		}

		public bool Parse(string Field, ref float t)
		{
			if (Field.Length == 0)
			{
				t = 0f;
			}
			else
			{
				t = float.Parse(Field);
			}
			return true;
		}

		public bool Parse(string Field, ref double t)
		{
			if (Field.Length == 0)
			{
				t = 0.0;
			}
			else
			{
				t = double.Parse(Field);
			}
			return true;
		}

		public bool Parse(string Field, ref long t)
		{
			if (Field.Length == 0)
			{
				t = 0L;
			}
			else
			{
				t = long.Parse(Field);
			}
			return true;
		}

		public void ParseString(string Field, ref string value)
		{
			value = CVSReader.LookupInterString(XSingleton<XCommon>.singleton.XHash(Field), Field);
		}

		protected bool Parse(string Field, ref string[] b)
		{
			if (Field.Length == 0)
			{
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array != null && array.Length > 0)
			{
				b = new string[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					string text = "";
					this.ParseString(array[i], ref text);
					b[i] = text;
				}
			}
			return true;
		}

		protected bool Parse(string Field, ref uint[] b)
		{
			if (Field.Length == 0)
			{
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array != null && array.Length > 0)
			{
				b = new uint[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					b[i] = CVSReader.uintParse.Parse(array[i]);
				}
			}
			return true;
		}

		protected bool Parse(string Field, ref int[] b)
		{
			if (Field.Length == 0)
			{
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array != null && array.Length > 0)
			{
				b = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					b[i] = CVSReader.intParse.Parse(array[i]);
				}
			}
			return true;
		}

		protected bool Parse(string Field, ref float[] b)
		{
			if (Field.Length == 0)
			{
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array != null && array.Length > 0)
			{
				b = new float[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					b[i] = CVSReader.floatParse.Parse(array[i]);
				}
			}
			return true;
		}

		private int AppendIndexBuffer(int index)
		{
			int result = CVSReader.indexIndex;
			CVSReader.indexBuffer[CVSReader.indexIndex++] = index;
			return result;
		}

		private int AddIndexBuffer(int count)
		{
			int result = CVSReader.indexIndex;
			for (int i = 0; i < count; i++)
			{
				CVSReader.indexBuffer[CVSReader.indexIndex++] = 0;
			}
			return result;
		}

		private int AddIndexBuffer(byte count)
		{
			int result = CVSReader.indexIndex;
			for (byte b = 0; b < count; b += 1)
			{
				CVSReader.indexBuffer[CVSReader.indexIndex++] = 0;
			}
			return result;
		}

		protected int Parse<T>(string Field, ref int valueIndex, CVSReader.ValueParse<T> parse, string post, int size)
		{
			if (!string.IsNullOrEmpty(Field))
			{
				uint key = this.ComputerHash(Field, post);
				CVSReader.SeqCache value;
				value.valueIndex = -1;
				value.indexIndex = 0;
				if (!CVSReader._seqIndex.TryGetValue(key, out value))
				{
					string[] array = Field.Split(new char[]
					{
						'='
					});
					if (array.Length > 0)
					{
						int num = parse.ParseBuffer(array[0]);
						for (int i = 1; i < size; i++)
						{
							if (i < array.Length)
							{
								parse.ParseBuffer(array[i]);
							}
							else
							{
								parse.DefaultValue();
							}
						}
						value.valueIndex = num;
						value.indexIndex = CVSReader.indexIndex;
						CVSReader.indexBuffer[CVSReader.indexIndex++] = num;
						CVSReader._seqIndex[key] = value;
					}
				}
				valueIndex = value.valueIndex;
				return value.indexIndex;
			}
			return 0;
		}

		protected bool Parse<T>(string Field, ref Seq2Ref<T> b, CVSReader.ValueParse<T> parse, string post)
		{
			if (Field.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			lock (CVSReader._seqIndex)
			{
				int num = 0;
				b.indexOffset = this.Parse<T>(Field, ref num, parse, post, 2);
			}
			return true;
		}

		protected bool Parse<T>(string Field, ref Seq2ListRef<T> b, CVSReader.ValueParse<T> parse, string post)
		{
			if (Field.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			lock (CVSReader._seqIndex)
			{
				b.count = (byte)array.Length;
				b.indexOffset = this.AddIndexBuffer(array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					string field = array[i];
					int num = 0;
					this.Parse<T>(field, ref num, parse, post, 2);
					CVSReader.indexBuffer[b.indexOffset + i] = num;
				}
			}
			return true;
		}

		protected bool Parse<T>(string Field, ref Seq3Ref<T> b, CVSReader.ValueParse<T> parse, string post)
		{
			if (Field.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			lock (CVSReader._seqIndex)
			{
				int num = 0;
				b.indexOffset = this.Parse<T>(Field, ref num, parse, post, 3);
			}
			return true;
		}

		protected bool Parse<T>(string Field, ref Seq3ListRef<T> b, CVSReader.ValueParse<T> parse, string post)
		{
			if (Field.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			lock (CVSReader._seqIndex)
			{
				b.count = (byte)array.Length;
				b.indexOffset = this.AddIndexBuffer(array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					string field = array[i];
					int num = 0;
					this.Parse<T>(field, ref num, parse, post, 3);
					CVSReader.indexBuffer[b.indexOffset + i] = num;
				}
			}
			return true;
		}

		protected bool Parse<T>(string Field, ref Seq4Ref<T> b, CVSReader.ValueParse<T> parse, string post)
		{
			if (Field.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			lock (CVSReader._seqIndex)
			{
				int num = 0;
				b.indexOffset = this.Parse<T>(Field, ref num, parse, post, 4);
			}
			return true;
		}

		protected bool Parse<T>(string Field, ref Seq4ListRef<T> b, CVSReader.ValueParse<T> parse, string post)
		{
			if (Field.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			string[] array = Field.Split(new char[]
			{
				'|'
			});
			if (array.Length == 0)
			{
				b.indexOffset = 0;
				return true;
			}
			lock (CVSReader._seqIndex)
			{
				b.count = (byte)array.Length;
				b.indexOffset = this.AddIndexBuffer(array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					string field = array[i];
					int num = 0;
					this.Parse<T>(field, ref num, parse, post, 4);
					CVSReader.indexBuffer[b.indexOffset + i] = num;
				}
			}
			return true;
		}

		private void TrimField(ref string Field)
		{
			string text = Field.Trim();
			if (text.Length != Field.Length)
			{
				Field = text;
			}
		}

		private void TrimField(string[] param)
		{
			for (int i = 0; i < param.Length; i++)
			{
				this.TrimField(ref param[i]);
			}
		}

		protected void Write(BinaryWriter stream, bool v, string Field)
		{
			if (Field.Length == 0)
			{
				v = false;
			}
			this.TrimField(ref Field);
			if (Field == "true" || Field == "TRUE" || Field == "True" || Field == "1")
			{
				v = true;
			}
			if (Field == "false" || Field == "FALSE" || Field == "False" || Field == "0")
			{
				v = false;
			}
			stream.Write(v);
		}

		protected void Write<T>(BinaryWriter stream, string Field, CVSReader.ValueParse<T> parse)
		{
			this.TrimField(ref Field);
			parse.Write(stream, Field);
		}

		protected void WriteArray<T>(BinaryWriter stream, string Field, CVSReader.ValueParse<T> parse)
		{
			byte b = 0;
			string[] array = Field.Split(CVSReader.ListSeparator, StringSplitOptions.RemoveEmptyEntries);
			if (array == null || array.Length == 0)
			{
				stream.Write(b);
				return;
			}
			b = (byte)array.Length;
			stream.Write(b);
			for (byte b2 = 0; b2 < b; b2 += 1)
			{
				string data = array[(int)b2];
				this.TrimField(ref data);
				parse.Write(stream, data);
			}
		}

		protected void WriteSeq<T>(BinaryWriter stream, string Field, CVSReader.ValueParse<T> parse, int count, string post)
		{
			uint value = 0u;
			if (Field.Length == 0)
			{
				stream.Write(value);
				return;
			}
			string[] array = Field.Split(CVSReader.SeqSeparator, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				stream.Write(value);
				return;
			}
			this.TrimField(array);
			string text = array[0];
			for (int i = 1; i < count; i++)
			{
				if (i < array.Length)
				{
					text = text + "=" + array[i];
				}
				else
				{
					text += "=0";
				}
			}
			text += post;
			value = XSingleton<XCommon>.singleton.XHash(text);
			stream.Write(value);
			for (int j = 0; j < count; j++)
			{
				if (j < array.Length)
				{
					parse.Write(stream, array[j]);
				}
				else
				{
					parse.Write(stream, null);
				}
			}
		}

		protected void WriteSeqList<T>(BinaryWriter stream, string Field, CVSReader.ValueParse<T> parse, int count, string post)
		{
			byte b = 0;
			if (Field.Length == 0)
			{
				stream.Write(b);
				return;
			}
			string[] array = Field.Split(CVSReader.ListSeparator, StringSplitOptions.RemoveEmptyEntries);
			if (array == null || array.Length == 0)
			{
				stream.Write(b);
				return;
			}
			b = (byte)array.Length;
			stream.Write(b);
			for (byte b2 = 0; b2 < b; b2 += 1)
			{
				this.WriteSeq<T>(stream, array[(int)b2], parse, count, post);
			}
		}

		private void DebugStreamPos(BinaryReader stream)
		{
			long arg_0B_0 = stream.BaseStream.Position;
			stream.ReadInt64();
		}

		protected bool Read(BinaryReader stream, ref bool v)
		{
			v = stream.ReadBoolean();
			return true;
		}

		protected bool Read<T>(BinaryReader stream, ref T v, CVSReader.ValueParse<T> parse)
		{
			parse.Read(stream, ref v);
			return true;
		}

		protected bool ReadArray<T>(BinaryReader stream, ref T[] v, CVSReader.ValueParse<T> parse)
		{
			byte b = stream.ReadByte();
			if (b > 0)
			{
				v = new T[(int)b];
				for (byte b2 = 0; b2 < b; b2 += 1)
				{
					parse.Read(stream, ref v[(int)b2]);
				}
			}
			else
			{
				v = null;
			}
			return true;
		}

		protected bool Parse<T>(BinaryReader stream, CVSReader.ValueParse<T> parse, byte count, ref int iIndex, ref int vIndex)
		{
			bool result = false;
			uint num = stream.ReadUInt32();
			if (num == 0u)
			{
				iIndex = 0;
				vIndex = 0;
			}
			else
			{
				CVSReader.SeqCache value;
				if (CVSReader._seqIndex.TryGetValue(num, out value))
				{
					parse.SkipBuffer(stream, (int)count);
				}
				else
				{
					value.valueIndex = parse.ReadBuffer(stream);
					for (byte b = 1; b < count; b += 1)
					{
						parse.ReadBuffer(stream);
					}
					value.indexIndex = iIndex;
					CVSReader._seqIndex[num] = value;
					result = true;
				}
				iIndex = value.indexIndex;
				vIndex = value.valueIndex;
			}
			return result;
		}

		protected bool ReadSeq<T>(BinaryReader stream, ref Seq2Ref<T> v, CVSReader.ValueParse<T> parse)
		{
			lock (CVSReader._seqIndex)
			{
				int indexOffset = CVSReader.indexIndex;
				int num = 0;
				bool flag = this.Parse<T>(stream, parse, 2, ref indexOffset, ref num);
				v.indexOffset = indexOffset;
				if (flag)
				{
					CVSReader.indexBuffer[CVSReader.indexIndex++] = num;
				}
			}
			return true;
		}

		protected bool ReadSeqList<T>(BinaryReader stream, ref Seq2ListRef<T> v, CVSReader.ValueParse<T> parse)
		{
			v.count = stream.ReadByte();
			if (v.count > 0)
			{
				lock (CVSReader._seqIndex)
				{
					v.indexOffset = this.AddIndexBuffer(v.count);
					for (byte b = 0; b < v.count; b += 1)
					{
						int num = v.indexOffset + (int)b;
						int num2 = 0;
						this.Parse<T>(stream, parse, 2, ref num, ref num2);
						CVSReader.indexBuffer[v.indexOffset + (int)b] = num2;
					}
					return true;
				}
			}
			v.indexOffset = 0;
			return true;
		}

		protected bool ReadSeq<T>(BinaryReader stream, ref Seq3Ref<T> v, CVSReader.ValueParse<T> parse)
		{
			lock (CVSReader._seqIndex)
			{
				int indexOffset = CVSReader.indexIndex;
				int num = 0;
				bool flag = this.Parse<T>(stream, parse, 3, ref indexOffset, ref num);
				v.indexOffset = indexOffset;
				if (flag)
				{
					CVSReader.indexBuffer[CVSReader.indexIndex++] = num;
				}
			}
			return true;
		}

		protected bool ReadSeqList<T>(BinaryReader stream, ref Seq3ListRef<T> v, CVSReader.ValueParse<T> parse)
		{
			v.count = stream.ReadByte();
			if (v.count > 0)
			{
				lock (CVSReader._seqIndex)
				{
					v.indexOffset = this.AddIndexBuffer(v.count);
					for (byte b = 0; b < v.count; b += 1)
					{
						int num = v.indexOffset + (int)b;
						int num2 = 0;
						this.Parse<T>(stream, parse, 3, ref num, ref num2);
						CVSReader.indexBuffer[v.indexOffset + (int)b] = num2;
					}
					return true;
				}
			}
			v.indexOffset = 0;
			return true;
		}

		protected bool ReadSeq<T>(BinaryReader stream, ref Seq4Ref<T> v, CVSReader.ValueParse<T> parse)
		{
			lock (CVSReader._seqIndex)
			{
				int indexOffset = CVSReader.indexIndex;
				int num = 0;
				bool flag = this.Parse<T>(stream, parse, 4, ref indexOffset, ref num);
				v.indexOffset = indexOffset;
				if (flag)
				{
					CVSReader.indexBuffer[CVSReader.indexIndex++] = num;
				}
			}
			return true;
		}

		protected bool ReadSeqList<T>(BinaryReader stream, ref Seq4ListRef<T> v, CVSReader.ValueParse<T> parse)
		{
			v.count = stream.ReadByte();
			if (v.count > 0)
			{
				lock (CVSReader._seqIndex)
				{
					v.indexOffset = this.AddIndexBuffer(v.count);
					for (byte b = 0; b < v.count; b += 1)
					{
						int num = v.indexOffset + (int)b;
						int num2 = 0;
						this.Parse<T>(stream, parse, 4, ref num, ref num2);
						CVSReader.indexBuffer[v.indexOffset + (int)b] = num2;
					}
					return true;
				}
			}
			v.indexOffset = 0;
			return true;
		}

		protected abstract void OnClear();

		protected abstract bool OnHeaderLine(string[] Fields);

		protected abstract bool OnLine(string[] Fields);

		protected abstract bool OnCommentLine(string[] Fields);

		protected virtual void WriteLine(string[] Fields, BinaryWriter writer)
		{
		}

		protected virtual void ReadLine(BinaryReader reader)
		{
		}
	}
}
