using System;

namespace com.tencent.pandora
{
	public class LuaBinderAttribute : Attribute
	{
		public int order;

		public LuaBinderAttribute(int order)
		{
			this.order = order;
		}
	}
}
