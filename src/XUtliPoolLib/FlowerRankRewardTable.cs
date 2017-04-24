using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FlowerRankRewardTable : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<int> rank;

			public Seq2ListRef<int> reward;

			public uint yesterday;

			public uint history;
		}

		public List<FlowerRankRewardTable.RowData> Table = new List<FlowerRankRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"rank",
				"reward",
				"yesterday",
				"history"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FlowerRankRewardTable.RowData rowData = new FlowerRankRewardTable.RowData();
			if (!base.Parse<int>(Fields[this.ColMap[0]], ref rowData.rank, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.yesterday))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.history))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FlowerRankRewardTable.RowData rowData = new FlowerRankRewardTable.RowData();
			base.ReadSeq<int>(reader, ref rowData.rank, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeqList<int>(reader, ref rowData.reward, CVSReader.intParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.yesterday, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.history, CVSReader.uintParse);
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
