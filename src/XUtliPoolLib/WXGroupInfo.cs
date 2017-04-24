using System;

namespace XUtliPoolLib
{
	public class WXGroupInfo
	{
		public struct Data
		{
			public string flag;

			public int errorCode;

			public string count;

			public string openIdList;
		}

		public int apiId;

		public WXGroupInfo.Data data;
	}
}
