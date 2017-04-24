using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildBossConfigTable : CVSReader
	{
		public class RowData
		{
			public uint BossID;

			public uint GuildLevel;

			public uint EnemyID;

			public float AttackPercent;

			public float LifePercent;

			public string BossName;

			public Seq2ListRef<uint> FirsttKillReward;

			public string FirstKillDesignation;

			public Seq2ListRef<uint> JoinReward;

			public Seq2ListRef<uint> KillReward;

			public string WinCutScene;
		}

		public List<GuildBossConfigTable.RowData> Table = new List<GuildBossConfigTable.RowData>();

		public GuildBossConfigTable.RowData GetByBossID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchBossID(key, 0, this.Table.Count - 1);
		}

		private GuildBossConfigTable.RowData BinarySearchBossID(uint key, int min, int max)
		{
			GuildBossConfigTable.RowData rowData = this.Table[min];
			if (rowData.BossID == key)
			{
				return rowData;
			}
			GuildBossConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.BossID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildBossConfigTable.RowData rowData3 = this.Table[num];
			if (rowData3.BossID.CompareTo(key) > 0)
			{
				return this.BinarySearchBossID(key, min, num);
			}
			if (rowData3.BossID.CompareTo(key) < 0)
			{
				return this.BinarySearchBossID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowBossID(uint key, GuildBossConfigTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildBossConfigTable.RowData rowData = this.Table[min];
			if (rowData.BossID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.BossID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildBossConfigTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildBossConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.BossID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.BossID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildBossConfigTable duplicate id:{0}  lineno: {1}", new object[]
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
			GuildBossConfigTable.RowData rowData3 = this.Table[num];
			if (rowData3.BossID.CompareTo(key) > 0)
			{
				this.AddRowBossID(key, row, min, num);
				return;
			}
			if (rowData3.BossID.CompareTo(key) < 0)
			{
				this.AddRowBossID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildBossConfigTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BossID",
				"GuildLevel",
				"EnemyID",
				"AttackPercent",
				"LifePercent",
				"BossName",
				"FirsttKillReward",
				"FirstKillDesignation",
				"JoinReward",
				"KillReward",
				"WinCutScene"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildBossConfigTable.RowData rowData = new GuildBossConfigTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BossID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.GuildLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.EnemyID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.AttackPercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.LifePercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BossName))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.FirsttKillReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.FirstKillDesignation))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.JoinReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.KillReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.WinCutScene))
			{
				return false;
			}
			this.AddRowBossID(rowData.BossID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildBossConfigTable.RowData rowData = new GuildBossConfigTable.RowData();
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.EnemyID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.AttackPercent, CVSReader.floatParse);
			this.columnno = 3;
			base.Read<float>(reader, ref rowData.LifePercent, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BossName, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.FirsttKillReward, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.FirstKillDesignation, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.JoinReward, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.KillReward, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.WinCutScene, CVSReader.stringParse);
			this.columnno = 10;
			this.AddRowBossID(rowData.BossID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
