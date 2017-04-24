using System;
using System.IO;
using System.Text;

namespace WeTest.U3DAutomation
{
	internal class Lexer
	{
		private delegate bool StateHandler(aa A_0);

		private static int[] a;

		private static Lexer.StateHandler[] b;

		private bool c;

		private bool d;

		private bool e;

		private aa f;

		private int g;

		private int h;

		private TextReader i;

		private int j;

		private StringBuilder k;

		private string l;

		private int m;

		private int n;

		public bool AllowComments
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		public bool AllowSingleQuotedStrings
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		public bool EndOfInput
		{
			get
			{
				return this.e;
			}
		}

		public int Token
		{
			get
			{
				return this.m;
			}
		}

		public string StringValue
		{
			get
			{
				return this.l;
			}
		}

		static Lexer()
		{
			Lexer.d();
		}

		public Lexer(TextReader A_0)
		{
			this.c = true;
			this.d = true;
			this.g = 0;
			this.k = new StringBuilder(128);
			this.j = 1;
			this.e = false;
			this.i = A_0;
			this.f = new aa();
			this.f.c = this;
		}

		private static int b(int A_0)
		{
			switch (A_0)
			{
			case 65:
				break;
			case 66:
				return 11;
			case 67:
				return 12;
			case 68:
				return 13;
			case 69:
				return 14;
			case 70:
				return 15;
			default:
				switch (A_0)
				{
				case 97:
					break;
				case 98:
					return 11;
				case 99:
					return 12;
				case 100:
					return 13;
				case 101:
					return 14;
				case 102:
					return 15;
				default:
					return A_0 - 48;
				}
				break;
			}
			return 10;
		}

		private static void d()
		{
			Lexer.b = new Lexer.StateHandler[]
			{
				new Lexer.StateHandler(Lexer.ab),
				new Lexer.StateHandler(Lexer.aa),
				new Lexer.StateHandler(Lexer.z),
				new Lexer.StateHandler(Lexer.y),
				new Lexer.StateHandler(Lexer.x),
				new Lexer.StateHandler(Lexer.w),
				new Lexer.StateHandler(Lexer.v),
				new Lexer.StateHandler(Lexer.u),
				new Lexer.StateHandler(Lexer.t),
				new Lexer.StateHandler(Lexer.s),
				new Lexer.StateHandler(Lexer.r),
				new Lexer.StateHandler(Lexer.q),
				new Lexer.StateHandler(Lexer.p),
				new Lexer.StateHandler(Lexer.o),
				new Lexer.StateHandler(Lexer.n),
				new Lexer.StateHandler(Lexer.m),
				new Lexer.StateHandler(Lexer.l),
				new Lexer.StateHandler(Lexer.k),
				new Lexer.StateHandler(Lexer.j),
				new Lexer.StateHandler(Lexer.i),
				new Lexer.StateHandler(Lexer.h),
				new Lexer.StateHandler(Lexer.g),
				new Lexer.StateHandler(Lexer.f),
				new Lexer.StateHandler(Lexer.e),
				new Lexer.StateHandler(Lexer.d),
				new Lexer.StateHandler(Lexer.c),
				new Lexer.StateHandler(Lexer.b),
				new Lexer.StateHandler(Lexer.a)
			};
			Lexer.a = new int[]
			{
				65542,
				0,
				65537,
				65537,
				0,
				65537,
				0,
				65537,
				0,
				0,
				65538,
				0,
				0,
				0,
				65539,
				0,
				0,
				65540,
				65541,
				65542,
				0,
				0,
				65541,
				65542,
				0,
				0,
				0,
				0
			};
		}

		private static char a(int A_0)
		{
			if (A_0 <= 92)
			{
				if (A_0 <= 39)
				{
					if (A_0 != 34 && A_0 != 39)
					{
						return '?';
					}
				}
				else if (A_0 != 47 && A_0 != 92)
				{
					return '?';
				}
				return Convert.ToChar(A_0);
			}
			if (A_0 <= 102)
			{
				if (A_0 == 98)
				{
					return '\b';
				}
				if (A_0 == 102)
				{
					return '\f';
				}
			}
			else
			{
				if (A_0 == 110)
				{
					return '\n';
				}
				switch (A_0)
				{
				case 114:
					return '\r';
				case 116:
					return '\t';
				}
			}
			return '?';
		}

		private static bool ab(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h != 32 && (A_0.c.h < 9 || A_0.c.h > 13))
				{
					if (A_0.c.h >= 49 && A_0.c.h <= 57)
					{
						A_0.c.k.Append((char)A_0.c.h);
						A_0.b = 3;
						return true;
					}
					int num = A_0.c.h;
					if (num <= 58)
					{
						if (num <= 39)
						{
							if (num == 34)
							{
								A_0.b = 19;
								A_0.a = true;
								return true;
							}
							if (num != 39)
							{
								return false;
							}
							if (!A_0.c.d)
							{
								return false;
							}
							A_0.c.h = 34;
							A_0.b = 23;
							A_0.a = true;
							return true;
						}
						else
						{
							switch (num)
							{
							case 44:
								break;
							case 45:
								A_0.c.k.Append((char)A_0.c.h);
								A_0.b = 2;
								return true;
							case 46:
								return false;
							case 47:
								if (!A_0.c.c)
								{
									return false;
								}
								A_0.b = 25;
								return true;
							case 48:
								A_0.c.k.Append((char)A_0.c.h);
								A_0.b = 4;
								return true;
							default:
								if (num != 58)
								{
									return false;
								}
								break;
							}
						}
					}
					else if (num <= 102)
					{
						switch (num)
						{
						case 91:
						case 93:
							break;
						case 92:
							return false;
						default:
							if (num != 102)
							{
								return false;
							}
							A_0.b = 12;
							return true;
						}
					}
					else
					{
						if (num == 110)
						{
							A_0.b = 16;
							return true;
						}
						if (num == 116)
						{
							A_0.b = 9;
							return true;
						}
						switch (num)
						{
						case 123:
						case 125:
							break;
						case 124:
							return false;
						default:
							return false;
						}
					}
					A_0.b = 1;
					A_0.a = true;
					return true;
				}
			}
			return true;
		}

		private static bool aa(aa A_0)
		{
			A_0.c.c();
			if (A_0.c.h >= 49 && A_0.c.h <= 57)
			{
				A_0.c.k.Append((char)A_0.c.h);
				A_0.b = 3;
				return true;
			}
			int num = A_0.c.h;
			if (num == 48)
			{
				A_0.c.k.Append((char)A_0.c.h);
				A_0.b = 4;
				return true;
			}
			return false;
		}

		private static bool z(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h >= 48 && A_0.c.h <= 57)
				{
					A_0.c.k.Append((char)A_0.c.h);
				}
				else
				{
					if (A_0.c.h == 32 || (A_0.c.h >= 9 && A_0.c.h <= 13))
					{
						A_0.a = true;
						A_0.b = 1;
						return true;
					}
					int num = A_0.c.h;
					if (num <= 69)
					{
						switch (num)
						{
						case 44:
							break;
						case 45:
							return false;
						case 46:
							A_0.c.k.Append((char)A_0.c.h);
							A_0.b = 5;
							return true;
						default:
							if (num != 69)
							{
								return false;
							}
							goto IL_FF;
						}
					}
					else if (num != 93)
					{
						if (num == 101)
						{
							goto IL_FF;
						}
						if (num != 125)
						{
							return false;
						}
					}
					A_0.c.a();
					A_0.a = true;
					A_0.b = 1;
					return true;
					IL_FF:
					A_0.c.k.Append((char)A_0.c.h);
					A_0.b = 7;
					return true;
				}
			}
			return true;
		}

		private static bool y(aa A_0)
		{
			A_0.c.c();
			if (A_0.c.h == 32 || (A_0.c.h >= 9 && A_0.c.h <= 13))
			{
				A_0.a = true;
				A_0.b = 1;
				return true;
			}
			int num = A_0.c.h;
			if (num <= 69)
			{
				switch (num)
				{
				case 44:
					break;
				case 45:
					return false;
				case 46:
					A_0.c.k.Append((char)A_0.c.h);
					A_0.b = 5;
					return true;
				default:
					if (num != 69)
					{
						return false;
					}
					goto IL_C6;
				}
			}
			else if (num != 93)
			{
				if (num == 101)
				{
					goto IL_C6;
				}
				if (num != 125)
				{
					return false;
				}
			}
			A_0.c.a();
			A_0.a = true;
			A_0.b = 1;
			return true;
			IL_C6:
			A_0.c.k.Append((char)A_0.c.h);
			A_0.b = 7;
			return true;
		}

		private static bool x(aa A_0)
		{
			A_0.c.c();
			if (A_0.c.h >= 48 && A_0.c.h <= 57)
			{
				A_0.c.k.Append((char)A_0.c.h);
				A_0.b = 6;
				return true;
			}
			return false;
		}

		private static bool w(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h >= 48 && A_0.c.h <= 57)
				{
					A_0.c.k.Append((char)A_0.c.h);
				}
				else
				{
					if (A_0.c.h == 32 || (A_0.c.h >= 9 && A_0.c.h <= 13))
					{
						A_0.a = true;
						A_0.b = 1;
						return true;
					}
					int num = A_0.c.h;
					if (num <= 69)
					{
						if (num != 44)
						{
							if (num != 69)
							{
								return false;
							}
							goto IL_C9;
						}
					}
					else if (num != 93)
					{
						if (num == 101)
						{
							goto IL_C9;
						}
						if (num != 125)
						{
							return false;
						}
					}
					A_0.c.a();
					A_0.a = true;
					A_0.b = 1;
					return true;
					IL_C9:
					A_0.c.k.Append((char)A_0.c.h);
					A_0.b = 7;
					return true;
				}
			}
			return true;
		}

		private static bool v(aa A_0)
		{
			A_0.c.c();
			if (A_0.c.h >= 48 && A_0.c.h <= 57)
			{
				A_0.c.k.Append((char)A_0.c.h);
				A_0.b = 8;
				return true;
			}
			switch (A_0.c.h)
			{
			case 43:
			case 45:
				A_0.c.k.Append((char)A_0.c.h);
				A_0.b = 8;
				return true;
			}
			return false;
		}

		private static bool u(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h >= 48 && A_0.c.h <= 57)
				{
					A_0.c.k.Append((char)A_0.c.h);
				}
				else
				{
					if (A_0.c.h == 32 || (A_0.c.h >= 9 && A_0.c.h <= 13))
					{
						A_0.a = true;
						A_0.b = 1;
						return true;
					}
					int num = A_0.c.h;
					if (num == 44 || num == 93 || num == 125)
					{
						A_0.c.a();
						A_0.a = true;
						A_0.b = 1;
						return true;
					}
					return false;
				}
			}
			return true;
		}

		private static bool t(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 114)
			{
				A_0.b = 10;
				return true;
			}
			return false;
		}

		private static bool s(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 117)
			{
				A_0.b = 11;
				return true;
			}
			return false;
		}

		private static bool r(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 101)
			{
				A_0.a = true;
				A_0.b = 1;
				return true;
			}
			return false;
		}

		private static bool q(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 97)
			{
				A_0.b = 13;
				return true;
			}
			return false;
		}

		private static bool p(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 108)
			{
				A_0.b = 14;
				return true;
			}
			return false;
		}

		private static bool o(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 115)
			{
				A_0.b = 15;
				return true;
			}
			return false;
		}

		private static bool n(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 101)
			{
				A_0.a = true;
				A_0.b = 1;
				return true;
			}
			return false;
		}

		private static bool m(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 117)
			{
				A_0.b = 17;
				return true;
			}
			return false;
		}

		private static bool l(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 108)
			{
				A_0.b = 18;
				return true;
			}
			return false;
		}

		private static bool k(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 108)
			{
				A_0.a = true;
				A_0.b = 1;
				return true;
			}
			return false;
		}

		private static bool j(aa A_0)
		{
			while (A_0.c.c())
			{
				int num = A_0.c.h;
				if (num == 34)
				{
					A_0.c.a();
					A_0.a = true;
					A_0.b = 20;
					return true;
				}
				if (num == 92)
				{
					A_0.d = 19;
					A_0.b = 21;
					return true;
				}
				A_0.c.k.Append((char)A_0.c.h);
			}
			return true;
		}

		private static bool i(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 34)
			{
				A_0.a = true;
				A_0.b = 1;
				return true;
			}
			return false;
		}

		private static bool h(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num <= 92)
			{
				if (num <= 39)
				{
					if (num != 34 && num != 39)
					{
						return false;
					}
				}
				else if (num != 47 && num != 92)
				{
					return false;
				}
			}
			else if (num <= 102)
			{
				if (num != 98 && num != 102)
				{
					return false;
				}
			}
			else if (num != 110)
			{
				switch (num)
				{
				case 114:
				case 116:
					break;
				case 115:
					return false;
				case 117:
					A_0.b = 22;
					return true;
				default:
					return false;
				}
			}
			A_0.c.k.Append(Lexer.a(A_0.c.h));
			A_0.b = A_0.d;
			return true;
		}

		private static bool g(aa A_0)
		{
			int num = 0;
			int num2 = 4096;
			A_0.c.n = 0;
			while (A_0.c.c())
			{
				if ((A_0.c.h < 48 || A_0.c.h > 57) && (A_0.c.h < 65 || A_0.c.h > 70) && (A_0.c.h < 97 || A_0.c.h > 102))
				{
					return false;
				}
				A_0.c.n += Lexer.b(A_0.c.h) * num2;
				num++;
				num2 /= 16;
				if (num == 4)
				{
					A_0.c.k.Append(Convert.ToChar(A_0.c.n));
					A_0.b = A_0.d;
					return true;
				}
			}
			return true;
		}

		private static bool f(aa A_0)
		{
			while (A_0.c.c())
			{
				int num = A_0.c.h;
				if (num == 39)
				{
					A_0.c.a();
					A_0.a = true;
					A_0.b = 24;
					return true;
				}
				if (num == 92)
				{
					A_0.d = 23;
					A_0.b = 21;
					return true;
				}
				A_0.c.k.Append((char)A_0.c.h);
			}
			return true;
		}

		private static bool e(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 39)
			{
				A_0.c.h = 34;
				A_0.a = true;
				A_0.b = 1;
				return true;
			}
			return false;
		}

		private static bool d(aa A_0)
		{
			A_0.c.c();
			int num = A_0.c.h;
			if (num == 42)
			{
				A_0.b = 27;
				return true;
			}
			if (num != 47)
			{
				return false;
			}
			A_0.b = 26;
			return true;
		}

		private static bool c(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h == 10)
				{
					A_0.b = 1;
					return true;
				}
			}
			return true;
		}

		private static bool b(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h == 42)
				{
					A_0.b = 28;
					return true;
				}
			}
			return true;
		}

		private static bool a(aa A_0)
		{
			while (A_0.c.c())
			{
				if (A_0.c.h != 42)
				{
					if (A_0.c.h == 47)
					{
						A_0.b = 1;
						return true;
					}
					A_0.b = 27;
					return true;
				}
			}
			return true;
		}

		private bool c()
		{
			if ((this.h = this.b()) != -1)
			{
				return true;
			}
			this.e = true;
			return false;
		}

		private int b()
		{
			if (this.g != 0)
			{
				int result = this.g;
				this.g = 0;
				return result;
			}
			return this.i.Read();
		}

		public bool e()
		{
			this.f.a = false;
			while (true)
			{
				Lexer.StateHandler stateHandler = Lexer.b[this.j - 1];
				if (!stateHandler(this.f))
				{
					break;
				}
				if (this.e)
				{
					return false;
				}
				if (this.f.a)
				{
					goto Block_3;
				}
				this.j = this.f.b;
			}
			throw new JsonException(this.h);
			Block_3:
			this.l = this.k.ToString();
			this.k.Remove(0, this.k.Length);
			this.m = Lexer.a[this.j - 1];
			if (this.m == 65542)
			{
				this.m = this.h;
			}
			this.j = this.f.b;
			return true;
		}

		private void a()
		{
			this.g = this.h;
		}
	}
}
