using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildMineralBattle : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public uint Level;

			public uint Type;

			public uint Mineralcounts;

			public int DifficultLevel;

			public uint BossID;

			public uint Percent;

			public float atkpercent;

			public float defpercent;

			public float lifepercent;

			public Seq2Ref<int> ragebuff;

			public uint MineralReward;

			public Seq2ListRef<uint> MineralBuffReward;

			public uint[] MineralDrop;

			public uint ragetime;
		}

		public List<GuildMineralBattle.RowData> Table = new List<GuildMineralBattle.RowData>();

		public GuildMineralBattle.RowData GetByID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private GuildMineralBattle.RowData BinarySearchID(uint key, int min, int max)
		{
			GuildMineralBattle.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			GuildMineralBattle.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildMineralBattle.RowData rowData3 = this.Table[num];
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

		private void AddRowID(uint key, GuildMineralBattle.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildMineralBattle.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBattle duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildMineralBattle.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBattle duplicate id:{0}  lineno: {1}", new object[]
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
			GuildMineralBattle.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBattle duplicate id:{0}  lineno: {1}", new object[]
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
				"Level",
				"Type",
				"Mineralcounts",
				"DifficultLevel",
				"BossID",
				"Percent",
				"atkpercent",
				"defpercent",
				"lifepercent",
				"ragebuff",
				"MineralReward",
				"MineralBuffReward",
				"MineralDrop",
				"ragetime"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildMineralBattle.RowData rowData = new GuildMineralBattle.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Mineralcounts))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.DifficultLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BossID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Percent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.atkpercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.defpercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.lifepercent))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[10]], ref rowData.ragebuff, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.MineralReward))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.MineralBuffReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.MineralDrop))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.ragetime))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<float>(writer, Fields[this.ColMap[7]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[8]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[9]], CVSReader.floatParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse, 2, "I");
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.WriteArray<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildMineralBattle.RowData rowData = new GuildMineralBattle.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Mineralcounts, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DifficultLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Percent, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<float>(reader, ref rowData.atkpercent, CVSReader.floatParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.defpercent, CVSReader.floatParse);
			this.columnno = 8;
			base.Read<float>(reader, ref rowData.lifepercent, CVSReader.floatParse);
			this.columnno = 9;
			base.ReadSeq<int>(reader, ref rowData.ragebuff, CVSReader.intParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.MineralReward, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.MineralBuffReward, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadArray<uint>(reader, ref rowData.MineralDrop, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.ragetime, CVSReader.uintParse);
			this.columnno = 14;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
