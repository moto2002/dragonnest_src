using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GlobalTable : CVSReader
	{
		public class RowData
		{
			public string Name;

			public string Value;
		}

		public List<GlobalTable.RowData> Table = new List<GlobalTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Name",
				"Value"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GlobalTable.RowData rowData = new GlobalTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Value))
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
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GlobalTable.RowData rowData = new GlobalTable.RowData();
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Value, CVSReader.stringParse);
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
