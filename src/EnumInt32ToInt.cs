using System;

public class EnumInt32ToInt
{
	public static int Convert<TEnum>(TEnum value) where TEnum : struct
	{
		return value;
	}
}
