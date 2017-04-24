using System;

namespace com.tencent.pandora
{
	public class LuaDelegate : LuaFunction
	{
		public object d;

		public LuaDelegate(IntPtr l, int r) : base(l, r)
		{
		}

		public override void Dispose(bool disposeManagedResources)
		{
			if (this.valueref != 0)
			{
				LuaState.UnRefAction act = delegate(IntPtr l, int r)
				{
					LuaObject.removeDelgate(l, r);
					LuaDLL.pua_unref(l, r);
				};
				this.state.gcRef(act, this.valueref);
				this.valueref = 0;
			}
		}
	}
}
