using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildPkRankReward : CVSReader
	{
		public class RowData
		{
			public uint rank;

			public Seq2ListRef<uint> reward;

			public Seq2ListRef<uint> guildreward;
		}

		public List<GuildPkRankReward.RowData> Table = new List<GuildPkRankReward.RowData>();

		public GuildPkRankReward.RowData GetByrank(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchrank(key, 0, this.Table.Count - 1);
		}

		private GuildPkRankReward.RowData BinarySearchrank(uint key, int min, int max)
		{
			GuildPkRankReward.RowData rowData = this.Table[min];
			if (rowData.rank == key)
			{
				return rowData;
			}
			GuildPkRankReward.RowData rowData2 = this.Table[max];
			if (rowData2.rank == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildPkRankReward.RowData rowData3 = this.Table[num];
			if (rowData3.rank.CompareTo(key) > 0)
			{
				return this.BinarySearchrank(key, min, num);
			}
			if (rowData3.rank.CompareTo(key) < 0)
			{
				return this.BinarySearchrank(key, num, max);
			}
			return rowData3;
		}

		private void AddRowrank(uint key, GuildPkRankReward.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildPkRankReward.RowData rowData = this.Table[min];
			if (rowData.rank.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.rank == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildPkRankReward duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildPkRankReward.RowData rowData2 = this.Table[max];
			if (rowData2.rank.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.rank == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildPkRankReward duplicate id:{0}  lineno: {1}", new object[]
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
			GuildPkRankReward.RowData rowData3 = this.Table[num];
			if (rowData3.rank.CompareTo(key) > 0)
			{
				this.AddRowrank(key, row, min, num);
				return;
			}
			if (rowData3.rank.CompareTo(key) < 0)
			{
				this.AddRowrank(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildPkRankReward duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"rank",
				"reward",
				"guildreward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildPkRankReward.RowData rowData = new GuildPkRankReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.rank))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.guildreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowrank(rowData.rank, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildPkRankReward.RowData rowData = new GuildPkRankReward.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.guildreward, CVSReader.uintParse);
			this.columnno = 2;
			this.AddRowrank(rowData.rank, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
