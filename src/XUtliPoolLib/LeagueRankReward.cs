using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class LeagueRankReward : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> rank;

			public Seq2ListRef<uint> reward;
		}

		public List<LeagueRankReward.RowData> Table = new List<LeagueRankReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"rank",
				"reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			LeagueRankReward.RowData rowData = new LeagueRankReward.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.rank, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			LeagueRankReward.RowData rowData = new LeagueRankReward.RowData();
			base.ReadSeq<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
