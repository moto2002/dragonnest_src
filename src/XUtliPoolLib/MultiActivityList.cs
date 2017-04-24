using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class MultiActivityList : CVSReader
	{
		public class RowData
		{
			public int ID;

			public string Name;

			public string OpenWeek;

			public Seq2ListRef<uint> OpenDayTime;

			public uint GuildLevel;

			public int DayCountMax;

			public int SystemID;

			public string RewardTips;

			public string OpenDayTips;

			public string Icon;

			public bool NeedOpenAgain;

			public bool FairMode;

			public uint OpenServerWeek;

			public uint PushIcon;

			public Seq2ListRef<uint> DropItems;

			public bool HadShop;

			public bool WxGuildTask;
		}

		public List<MultiActivityList.RowData> Table = new List<MultiActivityList.RowData>();

		public MultiActivityList.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private MultiActivityList.RowData BinarySearchID(int key, int min, int max)
		{
			MultiActivityList.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			MultiActivityList.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			MultiActivityList.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(int key, MultiActivityList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			MultiActivityList.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: MultiActivityList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			MultiActivityList.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: MultiActivityList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			if (max - min <= 1)
			{
				this.Table.Insert(min + 1, row);
				return;
			}
			int num = min + (max - min) / 2;
			MultiActivityList.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: MultiActivityList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Name",
				"OpenWeek",
				"OpenDayTime",
				"GuildLevel",
				"DayCountMax",
				"SystemID",
				"RewardTips",
				"OpenDayTips",
				"Icon",
				"NeedOpenAgain",
				"FairMode",
				"OpenServerWeek",
				"PushIcon",
				"DropItems",
				"HadShop",
				"WxGuildTask"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			MultiActivityList.RowData rowData = new MultiActivityList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.OpenWeek))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.OpenDayTime, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.GuildLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.DayCountMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.RewardTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.OpenDayTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.NeedOpenAgain))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.FairMode))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.OpenServerWeek))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.PushIcon))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[14]], ref rowData.DropItems, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.HadShop))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.WxGuildTask))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[10]]);
			base.Write(writer, false, Fields[this.ColMap[11]]);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[15]]);
			base.Write(writer, false, Fields[this.ColMap[16]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			MultiActivityList.RowData rowData = new MultiActivityList.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.OpenWeek, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.OpenDayTime, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DayCountMax, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.RewardTips, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.OpenDayTips, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 9;
			base.Read(reader, ref rowData.NeedOpenAgain);
			this.columnno = 10;
			base.Read(reader, ref rowData.FairMode);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.OpenServerWeek, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.PushIcon, CVSReader.uintParse);
			this.columnno = 13;
			base.ReadSeqList<uint>(reader, ref rowData.DropItems, CVSReader.uintParse);
			this.columnno = 14;
			base.Read(reader, ref rowData.HadShop);
			this.columnno = 15;
			base.Read(reader, ref rowData.WxGuildTask);
			this.columnno = 16;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
