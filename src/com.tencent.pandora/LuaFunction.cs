using System;

namespace com.tencent.pandora
{
	public class LuaFunction : LuaVar
	{
		public LuaFunction(LuaState l, int r) : base(l, r)
		{
		}

		public LuaFunction(IntPtr l, int r) : base(l, r)
		{
		}

		public bool pcall(int nArgs, int errfunc)
		{
			if (!this.state.isMainThread())
			{
				SLogger.LogError("Can't call lua function in bg thread");
				return false;
			}
			LuaDLL.pua_getref(base.L, this.valueref);
			if (!LuaDLL.pua_isfunction(base.L, -1))
			{
				LuaDLL.pua_pop(base.L, 1);
				throw new Exception("Call invalid function.");
			}
			LuaDLL.pua_insert(base.L, -nArgs - 1);
			if (LuaDLL.pua_pcall(base.L, nArgs, -1, errfunc) != 0)
			{
				LuaDLL.pua_pop(base.L, 1);
				return false;
			}
			return true;
		}

		public object pcall(int nARgs)
		{
			int num = LuaObject.pushTry(this.state.L);
			LuaDLL.pua_insert(this.state.L, -nARgs);
			if (this.innerCall(nARgs, num))
			{
				return this.state.topObjects(num - 1);
			}
			return null;
		}

		private bool innerCall(int nArgs, int errfunc)
		{
			bool result = this.pcall(nArgs, errfunc);
			LuaDLL.pua_remove(base.L, errfunc);
			return result;
		}

		public object call()
		{
			int num = LuaObject.pushTry(this.state.L);
			if (this.innerCall(0, num))
			{
				return this.state.topObjects(num - 1);
			}
			return null;
		}

		public object call(params object[] args)
		{
			int num = LuaObject.pushTry(this.state.L);
			int num2 = 0;
			while (args != null && num2 < args.Length)
			{
				LuaObject.pushVar(base.L, args[num2]);
				num2++;
			}
			if (this.innerCall((args == null) ? 0 : args.Length, num))
			{
				return this.state.topObjects(num - 1);
			}
			return null;
		}

		public object call(object a1)
		{
			int num = LuaObject.pushTry(this.state.L);
			LuaObject.pushVar(this.state.L, a1);
			if (this.innerCall(1, num))
			{
				return this.state.topObjects(num - 1);
			}
			return null;
		}

		public object call(object a1, object a2)
		{
			int num = LuaObject.pushTry(this.state.L);
			LuaObject.pushVar(this.state.L, a1);
			LuaObject.pushVar(this.state.L, a2);
			if (this.innerCall(2, num))
			{
				return this.state.topObjects(num - 1);
			}
			return null;
		}

		public object call(object a1, object a2, object a3)
		{
			int num = LuaObject.pushTry(this.state.L);
			LuaObject.pushVar(this.state.L, a1);
			LuaObject.pushVar(this.state.L, a2);
			LuaObject.pushVar(this.state.L, a3);
			if (this.innerCall(3, num))
			{
				return this.state.topObjects(num - 1);
			}
			return null;
		}
	}
}
