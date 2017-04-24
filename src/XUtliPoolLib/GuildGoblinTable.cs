using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildGoblinTable : CVSReader
	{
		public class RowData
		{
			public int Level;

			public int UpgradeNum;

			public float HpAddPer;

			public float AttackAddPer;

			public int Contribute;

			public int BigGoblinContribute;

			public Seq2Ref<int> BonusContent;

			public Seq2ListRef<int> DragonCoinFindBack;

			public Seq2ListRef<int> GoldCoinFindBack;

			public Seq2ListRef<uint> guildreward;
		}

		public List<GuildGoblinTable.RowData> Table = new List<GuildGoblinTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Level",
				"UpgradeNum",
				"HpAddPer",
				"AttackAddPer",
				"Contribute",
				"BigGoblinContribute",
				"BonusContent",
				"DragonCoinFindBack",
				"GoldCoinFindBack",
				"guildreward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildGoblinTable.RowData rowData = new GuildGoblinTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.UpgradeNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.HpAddPer))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.AttackAddPer))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Contribute))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BigGoblinContribute))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.BonusContent, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[7]], ref rowData.DragonCoinFindBack, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[8]], ref rowData.GoldCoinFindBack, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.guildreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.Table.Add(rowData);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildGoblinTable.RowData rowData = new GuildGoblinTable.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.UpgradeNum, CVSReader.intParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.HpAddPer, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.AttackAddPer, CVSReader.floatParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Contribute, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.BigGoblinContribute, CVSReader.intParse);
			this.columnno = 5;
			base.ReadSeq<int>(reader, ref rowData.BonusContent, CVSReader.intParse);
			this.columnno = 6;
			base.ReadSeqList<int>(reader, ref rowData.DragonCoinFindBack, CVSReader.intParse);
			this.columnno = 7;
			base.ReadSeqList<int>(reader, ref rowData.GoldCoinFindBack, CVSReader.intParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.guildreward, CVSReader.uintParse);
			this.columnno = 9;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
