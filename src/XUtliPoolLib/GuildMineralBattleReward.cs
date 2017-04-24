using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildMineralBattleReward : CVSReader
	{
		public class RowData
		{
			public uint Rank;

			public Seq2ListRef<uint> AdministratorReward1;

			public Seq2ListRef<uint> AdministratorReward2;

			public Seq2ListRef<uint> MembersReward;

			public uint GuildEXP;

			public uint GguildPrestige;

			public Seq2ListRef<int> RewardShow;
		}

		public List<GuildMineralBattleReward.RowData> Table = new List<GuildMineralBattleReward.RowData>();

		public GuildMineralBattleReward.RowData GetByRank(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchRank(key, 0, this.Table.Count - 1);
		}

		private GuildMineralBattleReward.RowData BinarySearchRank(uint key, int min, int max)
		{
			GuildMineralBattleReward.RowData rowData = this.Table[min];
			if (rowData.Rank == key)
			{
				return rowData;
			}
			GuildMineralBattleReward.RowData rowData2 = this.Table[max];
			if (rowData2.Rank == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildMineralBattleReward.RowData rowData3 = this.Table[num];
			if (rowData3.Rank.CompareTo(key) > 0)
			{
				return this.BinarySearchRank(key, min, num);
			}
			if (rowData3.Rank.CompareTo(key) < 0)
			{
				return this.BinarySearchRank(key, num, max);
			}
			return rowData3;
		}

		private void AddRowRank(uint key, GuildMineralBattleReward.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildMineralBattleReward.RowData rowData = this.Table[min];
			if (rowData.Rank.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Rank == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBattleReward duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildMineralBattleReward.RowData rowData2 = this.Table[max];
			if (rowData2.Rank.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Rank == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBattleReward duplicate id:{0}  lineno: {1}", new object[]
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
			GuildMineralBattleReward.RowData rowData3 = this.Table[num];
			if (rowData3.Rank.CompareTo(key) > 0)
			{
				this.AddRowRank(key, row, min, num);
				return;
			}
			if (rowData3.Rank.CompareTo(key) < 0)
			{
				this.AddRowRank(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBattleReward duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Rank",
				"AdministratorReward1",
				"AdministratorReward2",
				"MembersReward",
				"GuildEXP",
				"GguildPrestige",
				"RewardShow"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildMineralBattleReward.RowData rowData = new GuildMineralBattleReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Rank))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.AdministratorReward1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.AdministratorReward2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.MembersReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.GuildEXP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.GguildPrestige))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.RewardShow, CVSReader.intParse, "2I"))
			{
				return false;
			}
			this.AddRowRank(rowData.Rank, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildMineralBattleReward.RowData rowData = new GuildMineralBattleReward.RowData();
			base.Read<uint>(reader, ref rowData.Rank, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.AdministratorReward1, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.AdministratorReward2, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.MembersReward, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildEXP, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.GguildPrestige, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<int>(reader, ref rowData.RewardShow, CVSReader.intParse);
			this.columnno = 6;
			this.AddRowRank(rowData.Rank, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
