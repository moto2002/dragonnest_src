using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FashionRankTable : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<int> FashionRank;

			public Seq2ListRef<int> Reward;
		}

		public List<FashionRankTable.RowData> Table = new List<FashionRankTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FashionRank",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FashionRankTable.RowData rowData = new FashionRankTable.RowData();
			if (!base.Parse<int>(Fields[this.ColMap[0]], ref rowData.FashionRank, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.Reward, CVSReader.intParse, "2I"))
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
			base.WriteSeq<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FashionRankTable.RowData rowData = new FashionRankTable.RowData();
			base.ReadSeq<int>(reader, ref rowData.FashionRank, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeqList<int>(reader, ref rowData.Reward, CVSReader.intParse);
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
