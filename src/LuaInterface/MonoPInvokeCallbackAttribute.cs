using System;

namespace LuaInterface
{
	public class MonoPInvokeCallbackAttribute : Attribute
	{
		private Type type;

		public MonoPInvokeCallbackAttribute(Type t)
		{
			this.type = t;
		}
	}
}
