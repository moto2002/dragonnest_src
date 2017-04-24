using System;

namespace com.tencent.pandora
{
	internal class TimeHelper
	{
		public static int NowSeconds()
		{
			return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
		}

		public static ulong NowMilliseconds()
		{
			return (ulong)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
		}
	}
}
