using System;

namespace XUtliPoolLib
{
	public class WXGroupResult
	{
		public struct Data
		{
			public int errorCode;

			public string flag;
		}

		public int apiId;

		public WXGroupResult.Data data;
	}
}
