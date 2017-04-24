using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class Career : CVSReader
	{
		public class RowData
		{
			public int SortId;

			public string TabName;

			public int ID;
		}

		public List<Career.RowData> Table = new List<Career.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SortId",
				"TabName",
				"ID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			Career.RowData rowData = new Career.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SortId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TabName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ID))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			Career.RowData rowData = new Career.RowData();
			base.Read<int>(reader, ref rowData.SortId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
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
