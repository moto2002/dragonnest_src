using System;
using System.Collections;
using System.Collections.Generic;

namespace com.tencent.pandora
{
	public class LuaTable : LuaVar, IEnumerable<LuaTable.TablePair>, IEnumerable
	{
		public struct TablePair
		{
			public object key;

			public object value;
		}

		public class Enumerator : IDisposable, IEnumerator<LuaTable.TablePair>, IEnumerator
		{
			private LuaTable t;

			private int indext = -1;

			private LuaTable.TablePair current = default(LuaTable.TablePair);

			private int iterPhase;

			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			public LuaTable.TablePair Current
			{
				get
				{
					this.current.key = LuaObject.checkVar(this.t.L, -2);
					this.current.value = LuaObject.checkVar(this.t.L, -1);
					return this.current;
				}
			}

			public Enumerator(LuaTable table)
			{
				this.t = table;
				this.Reset();
			}

			public bool MoveNext()
			{
				if (this.indext < 0)
				{
					return false;
				}
				if (this.iterPhase == 0)
				{
					LuaDLL.pua_pushnil(this.t.L);
					this.iterPhase = 1;
				}
				else
				{
					LuaDLL.pua_pop(this.t.L, 1);
				}
				bool flag = LuaDLL.pua_next(this.t.L, this.indext) > 0;
				if (!flag)
				{
					this.iterPhase = 2;
				}
				return flag;
			}

			public void Reset()
			{
				LuaDLL.pua_getref(this.t.L, this.t.Ref);
				this.indext = LuaDLL.pua_gettop(this.t.L);
			}

			public void Dispose()
			{
				if (this.iterPhase == 1)
				{
					LuaDLL.pua_pop(this.t.L, 2);
				}
				LuaDLL.pua_remove(this.t.L, this.indext);
			}
		}

		public object this[string key]
		{
			get
			{
				return this.state.getObject(this.valueref, key);
			}
			set
			{
				this.state.setObject(this.valueref, key, value);
			}
		}

		public object this[int index]
		{
			get
			{
				return this.state.getObject(this.valueref, index);
			}
			set
			{
				this.state.setObject(this.valueref, index, value);
			}
		}

		public LuaTable(IntPtr l, int r) : base(l, r)
		{
		}

		public LuaTable(LuaState l, int r) : base(l, r)
		{
		}

		public LuaTable(LuaState state) : base(state, 0)
		{
			LuaDLL.pua_newtable(base.L);
			this.valueref = LuaDLL.puaL_ref(base.L, LuaIndexes.LUA_REGISTRYINDEX);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public object invoke(string func, params object[] args)
		{
			LuaFunction luaFunction = (LuaFunction)this[func];
			if (luaFunction != null)
			{
				return luaFunction.call(args);
			}
			throw new Exception(string.Format("Can't find {0} function", func));
		}

		public int length()
		{
			int newTop = LuaDLL.pua_gettop(base.L);
			base.push(base.L);
			int result = LuaDLL.pua_rawlen(base.L, -1);
			LuaDLL.pua_settop(base.L, newTop);
			return result;
		}

		public IEnumerator<LuaTable.TablePair> GetEnumerator()
		{
			return new LuaTable.Enumerator(this);
		}
	}
}
