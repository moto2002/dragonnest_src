using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildBossRewardTable : CVSReader
	{
		public class RowData
		{
			public uint rank;

			public Seq2ListRef<uint> reward;

			public Seq2ListRef<uint> rewardMin;

			public Seq2ListRef<uint> guildreward;

			public Seq2ListRef<uint> guildexp;
		}

		public List<GuildBossRewardTable.RowData> Table = new List<GuildBossRewardTable.RowData>();

		public GuildBossRewardTable.RowData GetByrank(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchrank(key, 0, this.Table.Count - 1);
		}

		private GuildBossRewardTable.RowData BinarySearchrank(uint key, int min, int max)
		{
			GuildBossRewardTable.RowData rowData = this.Table[min];
			if (rowData.rank == key)
			{
				return rowData;
			}
			GuildBossRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.rank == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildBossRewardTable.RowData rowData3 = this.Table[num];
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

		private void AddRowrank(uint key, GuildBossRewardTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildBossRewardTable.RowData rowData = this.Table[min];
			if (rowData.rank.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.rank == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildBossRewardTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildBossRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.rank.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.rank == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildBossRewardTable duplicate id:{0}  lineno: {1}", new object[]
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
			GuildBossRewardTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildBossRewardTable duplicate id:{0}  lineno: {1}", new object[]
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
				"rewardMin",
				"guildreward",
				"guildexp"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildBossRewardTable.RowData rowData = new GuildBossRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.rank))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.rewardMin, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.guildreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.guildexp, CVSReader.uintParse, "2U"))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildBossRewardTable.RowData rowData = new GuildBossRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.rewardMin, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.guildreward, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.guildexp, CVSReader.uintParse);
			this.columnno = 4;
			this.AddRowrank(rowData.rank, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
