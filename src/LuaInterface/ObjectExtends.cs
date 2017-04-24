using System;

namespace LuaInterface
{
	public static class ObjectExtends
	{
		public static object RefObject(this object obj)
		{
			return new WeakReference(obj).Target;
		}
	}
}
