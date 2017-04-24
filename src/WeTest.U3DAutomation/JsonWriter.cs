using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace WeTest.U3DAutomation
{
	public class JsonWriter
	{
		private static NumberFormatInfo a;

		private v b;

		private Stack<v> c;

		private bool d;

		private char[] e;

		private int f;

		private int g;

		private StringBuilder h;

		private bool i;

		private bool j;

		private TextWriter k;

		public int IndentValue
		{
			get
			{
				return this.g;
			}
			set
			{
				this.f = this.f / this.g * value;
				this.g = value;
			}
		}

		public bool PrettyPrint
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		public TextWriter TextWriter
		{
			get
			{
				return this.k;
			}
		}

		public bool Validate
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		static JsonWriter()
		{
			JsonWriter.a = NumberFormatInfo.InvariantInfo;
		}

		public JsonWriter()
		{
			this.h = new StringBuilder();
			this.k = new StringWriter(this.h);
			this.d();
		}

		public JsonWriter(StringBuilder sb) : this(new StringWriter(sb))
		{
		}

		public JsonWriter(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.k = writer;
			this.d();
		}

		private void a(h A_0)
		{
			if (!this.b.d)
			{
				this.b.a++;
			}
			if (!this.j)
			{
				return;
			}
			if (this.d)
			{
				throw new JsonException("A complete JSON symbol has already been written");
			}
			switch (A_0)
			{
			case global::h.a:
				if (!this.b.b)
				{
					throw new JsonException("Can't close an array here");
				}
				break;
			case global::h.b:
				if (!this.b.c || this.b.d)
				{
					throw new JsonException("Can't close an object here");
				}
				break;
			case global::h.c:
				if (this.b.c && !this.b.d)
				{
					throw new JsonException("Expected a property");
				}
				break;
			case global::h.d:
				if (!this.b.c || this.b.d)
				{
					throw new JsonException("Can't add a property here");
				}
				break;
			case global::h.e:
				if (!this.b.b && (!this.b.c || !this.b.d))
				{
					throw new JsonException("Can't add a value here");
				}
				break;
			default:
				return;
			}
		}

		private void d()
		{
			this.d = false;
			this.e = new char[4];
			this.f = 0;
			this.g = 4;
			this.i = false;
			this.j = true;
			this.c = new Stack<v>();
			this.b = new v();
			this.c.Push(this.b);
		}

		private static void a(int A_0, char[] A_1)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = A_0 % 16;
				if (num < 10)
				{
					A_1[3 - i] = (char)(48 + num);
				}
				else
				{
					A_1[3 - i] = (char)(65 + (num - 10));
				}
				A_0 >>= 4;
			}
		}

		private void c()
		{
			if (this.i)
			{
				this.f += this.g;
			}
		}

		private void b(string A_0)
		{
			if (this.i && !this.b.d)
			{
				for (int i = 0; i < this.f; i++)
				{
					this.k.Write(' ');
				}
			}
			this.k.Write(A_0);
		}

		private void b()
		{
			this.a(true);
		}

		private void a(bool A_0)
		{
			if (A_0 && !this.b.d && this.b.a > 1)
			{
				this.k.Write(',');
			}
			if (this.i && !this.b.d)
			{
				this.k.Write('\n');
			}
		}

		private void a(string A_0)
		{
			this.b(string.Empty);
			this.k.Write('"');
			int length = A_0.Length;
			int i = 0;
			while (i < length)
			{
				char c = A_0[i];
				switch (c)
				{
				case '\b':
					this.k.Write("\\b");
					break;
				case '\t':
					this.k.Write("\\t");
					break;
				case '\n':
					this.k.Write("\\n");
					break;
				case '\v':
					goto IL_E4;
				case '\f':
					this.k.Write("\\f");
					break;
				case '\r':
					this.k.Write("\\r");
					break;
				default:
					if (c != '"' && c != '\\')
					{
						goto IL_E4;
					}
					this.k.Write('\\');
					this.k.Write(A_0[i]);
					break;
				}
				IL_141:
				i++;
				continue;
				IL_E4:
				if (A_0[i] >= ' ' && A_0[i] <= '~')
				{
					this.k.Write(A_0[i]);
					goto IL_141;
				}
				JsonWriter.a((int)A_0[i], this.e);
				this.k.Write("\\u");
				this.k.Write(this.e);
				goto IL_141;
			}
			this.k.Write('"');
		}

		private void a()
		{
			if (this.i)
			{
				this.f -= this.g;
			}
		}

		public override string ToString()
		{
			if (this.h == null)
			{
				return string.Empty;
			}
			return this.h.ToString();
		}

		public void Reset()
		{
			this.d = false;
			this.c.Clear();
			this.b = new v();
			this.c.Push(this.b);
			if (this.h != null)
			{
				this.h.Remove(0, this.h.Length);
			}
		}

		public void Write(bool boolean)
		{
			this.a(global::h.e);
			this.b();
			this.b(boolean ? "true" : "false");
			this.b.d = false;
		}

		public void Write(decimal number)
		{
			this.a(global::h.e);
			this.b();
			this.b(Convert.ToString(number, JsonWriter.a));
			this.b.d = false;
		}

		public void Write(double number)
		{
			this.a(global::h.e);
			this.b();
			string text = Convert.ToString(number, JsonWriter.a);
			this.b(text);
			if (text.IndexOf('.') == -1 && text.IndexOf('E') == -1)
			{
				this.k.Write(".0");
			}
			this.b.d = false;
		}

		public void Write(int number)
		{
			this.a(global::h.e);
			this.b();
			this.b(Convert.ToString(number, JsonWriter.a));
			this.b.d = false;
		}

		public void Write(long number)
		{
			this.a(global::h.e);
			this.b();
			this.b(Convert.ToString(number, JsonWriter.a));
			this.b.d = false;
		}

		public void Write(string str)
		{
			this.a(global::h.e);
			this.b();
			if (str == null)
			{
				this.b("null");
			}
			else
			{
				this.a(str);
			}
			this.b.d = false;
		}

		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			this.a(global::h.e);
			this.b();
			this.b(Convert.ToString(number, JsonWriter.a));
			this.b.d = false;
		}

		public void WriteArrayEnd()
		{
			this.a(global::h.a);
			this.a(false);
			this.c.Pop();
			if (this.c.Count == 1)
			{
				this.d = true;
			}
			else
			{
				this.b = this.c.Peek();
				this.b.d = false;
			}
			this.a();
			this.b("]");
		}

		public void WriteArrayStart()
		{
			this.a(global::h.c);
			this.b();
			this.b("[");
			this.b = new v();
			this.b.b = true;
			this.c.Push(this.b);
			this.c();
		}

		public void WriteObjectEnd()
		{
			this.a(global::h.b);
			this.a(false);
			this.c.Pop();
			if (this.c.Count == 1)
			{
				this.d = true;
			}
			else
			{
				this.b = this.c.Peek();
				this.b.d = false;
			}
			this.a();
			this.b("}");
		}

		public void WriteObjectStart()
		{
			this.a(global::h.c);
			this.b();
			this.b("{");
			this.b = new v();
			this.b.c = true;
			this.c.Push(this.b);
			this.c();
		}

		public void WritePropertyName(string property_name)
		{
			this.a(global::h.d);
			this.b();
			this.a(property_name);
			if (this.i)
			{
				if (property_name.Length > this.b.e)
				{
					this.b.e = property_name.Length;
				}
				for (int i = this.b.e - property_name.Length; i >= 0; i--)
				{
					this.k.Write(' ');
				}
				this.k.Write(": ");
			}
			else
			{
				this.k.Write(':');
			}
			this.b.d = true;
		}
	}
}
