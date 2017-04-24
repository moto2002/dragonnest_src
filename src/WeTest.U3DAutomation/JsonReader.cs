using System;
using System.Collections.Generic;
using System.IO;

namespace WeTest.U3DAutomation
{
	public class JsonReader
	{
		private static IDictionary<int, IDictionary<int, int[]>> a;

		private Stack<int> b;

		private int c;

		private int d;

		private bool e;

		private bool f;

		private Lexer g;

		private bool h;

		private bool i;

		private bool j;

		private TextReader k;

		private bool l;

		private bool m;

		private object n;

		private JsonToken o;

		public bool AllowComments
		{
			get
			{
				return this.g.AllowComments;
			}
			set
			{
				this.g.AllowComments = value;
			}
		}

		public bool AllowSingleQuotedStrings
		{
			get
			{
				return this.g.AllowSingleQuotedStrings;
			}
			set
			{
				this.g.AllowSingleQuotedStrings = value;
			}
		}

		public bool SkipNonMembers
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		public bool EndOfInput
		{
			get
			{
				return this.f;
			}
		}

		public bool EndOfJson
		{
			get
			{
				return this.e;
			}
		}

		public JsonToken Token
		{
			get
			{
				return this.o;
			}
		}

		public object Value
		{
			get
			{
				return this.n;
			}
		}

		static JsonReader()
		{
			JsonReader.c();
		}

		public JsonReader(string json_text) : this(new StringReader(json_text), true)
		{
		}

		public JsonReader(TextReader reader) : this(reader, false)
		{
		}

		private JsonReader(TextReader A_0, bool A_1)
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.h = false;
			this.i = false;
			this.j = false;
			this.b = new Stack<int>();
			this.b.Push(65553);
			this.b.Push(65543);
			this.g = new Lexer(A_0);
			this.f = false;
			this.e = false;
			this.m = true;
			this.k = A_0;
			this.l = A_1;
		}

		private static void c()
		{
			JsonReader.a = new Dictionary<int, IDictionary<int, int[]>>();
			JsonReader.a(global::d.m);
			JsonReader.a(global::d.m, 91, new int[]
			{
				91,
				65549
			});
			JsonReader.a(global::d.n);
			JsonReader.a(global::d.n, 34, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.n, 91, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.n, 93, new int[]
			{
				93
			});
			JsonReader.a(global::d.n, 123, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.n, 65537, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.n, 65538, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.n, 65539, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.n, 65540, new int[]
			{
				65550,
				65551,
				93
			});
			JsonReader.a(global::d.i);
			JsonReader.a(global::d.i, 123, new int[]
			{
				123,
				65545
			});
			JsonReader.a(global::d.j);
			JsonReader.a(global::d.j, 34, new int[]
			{
				65546,
				65547,
				125
			});
			JsonReader.a(global::d.j, 125, new int[]
			{
				125
			});
			JsonReader.a(global::d.k);
			JsonReader.a(global::d.k, 34, new int[]
			{
				65552,
				58,
				65550
			});
			JsonReader.a(global::d.l);
			JsonReader.a(global::d.l, 44, new int[]
			{
				44,
				65546,
				65547
			});
			JsonReader.a(global::d.l, 125, new int[]
			{
				65554
			});
			JsonReader.a(global::d.q);
			JsonReader.a(global::d.q, 34, new int[]
			{
				34,
				65541,
				34
			});
			JsonReader.a(global::d.h);
			JsonReader.a(global::d.h, 91, new int[]
			{
				65548
			});
			JsonReader.a(global::d.h, 123, new int[]
			{
				65544
			});
			JsonReader.a(global::d.o);
			JsonReader.a(global::d.o, 34, new int[]
			{
				65552
			});
			JsonReader.a(global::d.o, 91, new int[]
			{
				65548
			});
			JsonReader.a(global::d.o, 123, new int[]
			{
				65544
			});
			JsonReader.a(global::d.o, 65537, new int[]
			{
				65537
			});
			JsonReader.a(global::d.o, 65538, new int[]
			{
				65538
			});
			JsonReader.a(global::d.o, 65539, new int[]
			{
				65539
			});
			JsonReader.a(global::d.o, 65540, new int[]
			{
				65540
			});
			JsonReader.a(global::d.p);
			JsonReader.a(global::d.p, 44, new int[]
			{
				44,
				65550,
				65551
			});
			JsonReader.a(global::d.p, 93, new int[]
			{
				65554
			});
		}

		private static void a(d A_0, int A_1, params int[] A_2)
		{
			JsonReader.a[(int)A_0].Add(A_1, A_2);
		}

		private static void a(d A_0)
		{
			JsonReader.a.Add((int)A_0, new Dictionary<int, int[]>());
		}

		private void a(string A_0)
		{
			double num;
			if ((A_0.IndexOf('.') != -1 || A_0.IndexOf('e') != -1 || A_0.IndexOf('E') != -1) && double.TryParse(A_0, out num))
			{
				this.o = JsonToken.Double;
				this.n = num;
				return;
			}
			int num2;
			if (int.TryParse(A_0, out num2))
			{
				this.o = JsonToken.Int;
				this.n = num2;
				return;
			}
			long num3;
			if (long.TryParse(A_0, out num3))
			{
				this.o = JsonToken.Long;
				this.n = num3;
				return;
			}
			ulong num4;
			if (ulong.TryParse(A_0, out num4))
			{
				this.o = JsonToken.Long;
				this.n = num4;
				return;
			}
			this.o = JsonToken.Int;
			this.n = 0;
		}

		private void b()
		{
			if (this.d == 91)
			{
				this.o = JsonToken.ArrayStart;
				this.i = true;
				return;
			}
			if (this.d == 93)
			{
				this.o = JsonToken.ArrayEnd;
				this.i = true;
				return;
			}
			if (this.d == 123)
			{
				this.o = JsonToken.ObjectStart;
				this.i = true;
				return;
			}
			if (this.d == 125)
			{
				this.o = JsonToken.ObjectEnd;
				this.i = true;
				return;
			}
			if (this.d == 34)
			{
				if (this.h)
				{
					this.h = false;
					this.i = true;
					return;
				}
				if (this.o == JsonToken.None)
				{
					this.o = JsonToken.String;
				}
				this.h = true;
				return;
			}
			else
			{
				if (this.d == 65541)
				{
					this.n = this.g.StringValue;
					return;
				}
				if (this.d == 65539)
				{
					this.o = JsonToken.Boolean;
					this.n = false;
					this.i = true;
					return;
				}
				if (this.d == 65540)
				{
					this.o = JsonToken.Null;
					this.i = true;
					return;
				}
				if (this.d == 65537)
				{
					this.a(this.g.StringValue);
					this.i = true;
					return;
				}
				if (this.d == 65546)
				{
					this.o = JsonToken.PropertyName;
					return;
				}
				if (this.d == 65538)
				{
					this.o = JsonToken.Boolean;
					this.n = true;
					this.i = true;
				}
				return;
			}
		}

		private bool a()
		{
			if (this.f)
			{
				return false;
			}
			this.g.e();
			if (this.g.EndOfInput)
			{
				this.Close();
				return false;
			}
			this.c = this.g.Token;
			return true;
		}

		public void Close()
		{
			if (this.f)
			{
				return;
			}
			this.f = true;
			this.e = true;
			if (this.l)
			{
				this.k.Close();
			}
			this.k = null;
		}

		public bool Read()
		{
			if (this.f)
			{
				return false;
			}
			if (this.e)
			{
				this.e = false;
				this.b.Clear();
				this.b.Push(65553);
				this.b.Push(65543);
			}
			this.h = false;
			this.i = false;
			this.o = JsonToken.None;
			this.n = null;
			if (!this.j)
			{
				this.j = true;
				if (!this.a())
				{
					return false;
				}
			}
			while (!this.i)
			{
				this.d = this.b.Pop();
				this.b();
				if (this.d == this.c)
				{
					if (!this.a())
					{
						if (this.b.Peek() != 65553)
						{
							throw new JsonException("Input doesn't evaluate to proper JSON text");
						}
						return this.i;
					}
				}
				else
				{
					int[] array;
					try
					{
						array = JsonReader.a[this.d][this.c];
					}
					catch (KeyNotFoundException a_)
					{
						throw new JsonException((d)this.c, a_);
					}
					if (array[0] != 65554)
					{
						for (int i = array.Length - 1; i >= 0; i--)
						{
							this.b.Push(array[i]);
						}
					}
				}
			}
			if (this.b.Peek() == 65553)
			{
				this.e = true;
			}
			return true;
		}
	}
}
