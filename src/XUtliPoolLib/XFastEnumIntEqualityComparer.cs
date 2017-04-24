using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace XUtliPoolLib
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct XFastEnumIntEqualityComparer<TEnum> : IEqualityComparer<TEnum> where TEnum : struct
	{
		public static int ToInt(TEnum en)
		{
			return EnumInt32ToInt.Convert<TEnum>(en);
		}

		public bool Equals(TEnum lhs, TEnum rhs)
		{
			return XFastEnumIntEqualityComparer<TEnum>.ToInt(lhs) == XFastEnumIntEqualityComparer<TEnum>.ToInt(rhs);
		}

		public int GetHashCode(TEnum en)
		{
			return XFastEnumIntEqualityComparer<TEnum>.ToInt(en);
		}
	}
}
