using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildRankRewardTable : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> Rank;

			public Seq2ListRef<uint> LeaderReward;

			public Seq2ListRef<uint> OfficerRreward;

			public Seq2ListRef<uint> MemberReward;

			public Seq2ListRef<uint> guildreward;
		}

		public List<GuildRankRewardTable.RowData> Table = new List<GuildRankRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Rank",
				"LeaderReward",
				"OfficerRreward",
				"MemberReward",
				"guildreward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildRankRewardTable.RowData rowData = new GuildRankRewardTable.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.Rank, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.LeaderReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.OfficerRreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.MemberReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.guildreward, CVSReader.uintParse, "2U"))
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildRankRewardTable.RowData rowData = new GuildRankRewardTable.RowData();
			base.ReadSeq<uint>(reader, ref rowData.Rank, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.LeaderReward, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.OfficerRreward, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.MemberReward, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.guildreward, CVSReader.uintParse);
			this.columnno = 4;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
