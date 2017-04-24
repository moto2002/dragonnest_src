using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildBossRoleRewardTable : CVSReader
	{
		public class RowData
		{
			public uint BossID;

			public Seq2Ref<uint> rank;

			public Seq2ListRef<uint> reward;

			public Seq2ListRef<uint> prestige;
		}

		public List<GuildBossRoleRewardTable.RowData> Table = new List<GuildBossRoleRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BossID",
				"rank",
				"reward",
				"prestige"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildBossRoleRewardTable.RowData rowData = new GuildBossRoleRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BossID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.rank, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.prestige, CVSReader.uintParse, "2U"))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildBossRoleRewardTable.RowData rowData = new GuildBossRoleRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.prestige, CVSReader.uintParse);
			this.columnno = 3;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
