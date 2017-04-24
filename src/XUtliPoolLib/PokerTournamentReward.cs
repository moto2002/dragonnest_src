using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PokerTournamentReward : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> Rank;

			public Seq2ListRef<uint> Reward;
		}

		public List<PokerTournamentReward.RowData> Table = new List<PokerTournamentReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Rank",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PokerTournamentReward.RowData rowData = new PokerTournamentReward.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.Rank, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Reward, CVSReader.uintParse, "2U"))
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
			PokerTournamentReward.RowData rowData = new PokerTournamentReward.RowData();
			base.ReadSeq<uint>(reader, ref rowData.Rank, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
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
