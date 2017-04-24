using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FirstPassReward : CVSReader
	{
		public class RowData
		{
			public int ID;

			public Seq2Ref<int> Rank;

			public Seq2ListRef<int> Reward;
		}

		public List<FirstPassReward.RowData> Table = new List<FirstPassReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Rank",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FirstPassReward.RowData rowData = new FirstPassReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.Rank, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.Reward, CVSReader.intParse, "2I"))
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
			base.WriteSeq<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FirstPassReward.RowData rowData = new FirstPassReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeq<int>(reader, ref rowData.Rank, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeqList<int>(reader, ref rowData.Reward, CVSReader.intParse);
			this.columnno = 2;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
