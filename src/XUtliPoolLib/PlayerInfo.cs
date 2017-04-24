using System;

namespace XUtliPoolLib
{
	public class PlayerInfo
	{
		public struct Data
		{
			public string nickName;

			public string openId;

			public string gender;

			public string pictureSmall;

			public string pictureMiddle;

			public string pictureLarge;

			public string provice;

			public string city;
		}

		public int apiId;

		public PlayerInfo.Data data;
	}
}
