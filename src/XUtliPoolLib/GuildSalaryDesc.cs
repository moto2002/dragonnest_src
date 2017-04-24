using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildSalaryDesc : CVSReader
	{
		public class RowData
		{
			public int Type;

			public string Desc;

			public int Go;

			public string GoLabel;
		}

		public List<GuildSalaryDesc.RowData> Table = new List<GuildSalaryDesc.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"Desc",
				"Go",
				"GoLabel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildSalaryDesc.RowData rowData = new GuildSalaryDesc.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Go))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.GoLabel))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildSalaryDesc.RowData rowData = new GuildSalaryDesc.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Go, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.GoLabel, CVSReader.stringParse);
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
