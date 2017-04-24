using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildChallegeTable : CVSReader
	{
		public class RowData
		{
			public int GuildRank;

			public int Mantime;

			public Seq2ListRef<int> Reward;
		}

		public List<GuildChallegeTable.RowData> Table = new List<GuildChallegeTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GuildRank",
				"Mantime",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildChallegeTable.RowData rowData = new GuildChallegeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GuildRank))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Mantime))
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
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildChallegeTable.RowData rowData = new GuildChallegeTable.RowData();
			base.Read<int>(reader, ref rowData.GuildRank, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Mantime, CVSReader.intParse);
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
