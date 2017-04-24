using System;

namespace LuaInterface
{
	internal struct MethodArgs
	{
		public int index;

		public ExtractValue extractValue;

		public bool isParamsArray;

		public Type paramsArrayType;
	}
}
