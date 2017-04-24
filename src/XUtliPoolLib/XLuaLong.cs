using System;

namespace XUtliPoolLib
{
	public class XLuaLong
	{
		public string str;

		public XLuaLong(string _str)
		{
			this.str = _str;
		}

		public ulong Get()
		{
			if (string.IsNullOrEmpty(this.str))
			{
				XSingleton<XDebug>.singleton.AddErrorLog("", null, null, null, null, null);
			}
			return ulong.Parse(this.str);
		}
	}
}
