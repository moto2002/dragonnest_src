using System;

namespace com.tencent.pandora
{
	internal class LuaClassObject
	{
		private Type cls;

		public LuaClassObject(Type t)
		{
			this.cls = t;
		}

		public Type GetClsType()
		{
			return this.cls;
		}
	}
}
