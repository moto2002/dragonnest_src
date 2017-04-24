using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class INumberEnum
	{
		private static Dictionary<uint, int> _numbermap;

		static INumberEnum()
		{
			INumberEnum._numbermap = new Dictionary<uint, int>();
			INumberEnum._numbermap.Add(XSingleton<XCommon>.singleton.XHash(typeof(_2).Name), 2);
			INumberEnum._numbermap.Add(XSingleton<XCommon>.singleton.XHash(typeof(_3).Name), 3);
			INumberEnum._numbermap.Add(XSingleton<XCommon>.singleton.XHash(typeof(_4).Name), 4);
			INumberEnum._numbermap.Add(XSingleton<XCommon>.singleton.XHash(typeof(_5).Name), 5);
			INumberEnum._numbermap.Add(XSingleton<XCommon>.singleton.XHash(typeof(_6).Name), 6);
		}

		public static int number(string name)
		{
			int result = 0;
			if (!INumberEnum._numbermap.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out result))
			{
				throw new ArgumentOutOfRangeException("Error sequence " + name);
			}
			return result;
		}
	}
}
