using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildAuctReward : CVSReader
	{
		public class RowData
		{
			public int ID;

			public string Comment;

			public int ActType;

			public Seq2Ref<int> Rank;

			public Seq2Ref<int> WorldLevel;

			public int BonusType;

			public int[] DropID;

			public uint[] RewardShow;

			public string ActName;

			public int Flow;

			public Seq2ListRef<uint> SItem;

			public Seq3ListRef<float> SItemPro;
		}

		public List<GuildAuctReward.RowData> Table = new List<GuildAuctReward.RowData>();

		public GuildAuctReward.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private GuildAuctReward.RowData BinarySearchID(int key, int min, int max)
		{
			GuildAuctReward.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			GuildAuctReward.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildAuctReward.RowData rowData3 = this.Table[num];
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

		private void AddRowID(int key, GuildAuctReward.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildAuctReward.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildAuctReward duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildAuctReward.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildAuctReward duplicate id:{0}  lineno: {1}", new object[]
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
			GuildAuctReward.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildAuctReward duplicate id:{0}  lineno: {1}", new object[]
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
				"Comment",
				"ActType",
				"Rank",
				"WorldLevel",
				"BonusType",
				"DropID",
				"RewardShow",
				"ActName",
				"Flow",
				"SItem",
				"SItemPro"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildAuctReward.RowData rowData = new GuildAuctReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Comment))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ActType))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[3]], ref rowData.Rank, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[4]], ref rowData.WorldLevel, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BonusType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.DropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.RewardShow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.ActName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Flow))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.SItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[11]], ref rowData.SItemPro, CVSReader.floatParse, "3F"))
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse, 2, "I");
			base.WriteSeq<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[11]], CVSReader.floatParse, 3, "F");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildAuctReward.RowData rowData = new GuildAuctReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ActType, CVSReader.intParse);
			this.columnno = 2;
			base.ReadSeq<int>(reader, ref rowData.Rank, CVSReader.intParse);
			this.columnno = 3;
			base.ReadSeq<int>(reader, ref rowData.WorldLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.BonusType, CVSReader.intParse);
			this.columnno = 5;
			base.ReadArray<int>(reader, ref rowData.DropID, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.RewardShow, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.ActName, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Flow, CVSReader.intParse);
			this.columnno = 9;
			base.ReadSeqList<uint>(reader, ref rowData.SItem, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeqList<float>(reader, ref rowData.SItemPro, CVSReader.floatParse);
			this.columnno = 11;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
