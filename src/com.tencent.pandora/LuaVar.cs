using System;

namespace com.tencent.pandora
{
	public abstract class LuaVar : IDisposable
	{
		protected LuaState state;

		protected int valueref;

		public IntPtr L
		{
			get
			{
				return this.state.L;
			}
		}

		public int Ref
		{
			get
			{
				return this.valueref;
			}
		}

		public LuaVar()
		{
			this.state = null;
		}

		public LuaVar(LuaState l, int r)
		{
			this.state = l;
			this.valueref = r;
		}

		public LuaVar(IntPtr l, int r)
		{
			this.state = LuaState.get(l);
			this.valueref = r;
		}

		~LuaVar()
		{
			this.Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposeManagedResources)
		{
			if (this.valueref != 0)
			{
				LuaState.UnRefAction act = delegate(IntPtr l, int r)
				{
					LuaDLL.pua_unref(l, r);
				};
				this.state.gcRef(act, this.valueref);
				this.valueref = 0;
			}
		}

		public void push(IntPtr l)
		{
			LuaDLL.pua_getref(l, this.valueref);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj is LuaVar && this == (LuaVar)obj;
		}

		private static int Equals(LuaVar x, LuaVar y)
		{
			x.push(x.L);
			y.push(x.L);
			int result = LuaDLL.pua_equal(x.L, -1, -2);
			LuaDLL.pua_pop(x.L, 2);
			return result;
		}

		public static bool operator ==(LuaVar x, LuaVar y)
		{
			if (x == null || y == null)
			{
				return x == y;
			}
			return LuaVar.Equals(x, y) == 1;
		}

		public static bool operator !=(LuaVar x, LuaVar y)
		{
			if (x == null || y == null)
			{
				return x != y;
			}
			return LuaVar.Equals(x, y) != 1;
		}
	}
}
