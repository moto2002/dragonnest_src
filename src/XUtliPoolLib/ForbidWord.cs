using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ForbidWord : CVSReader
	{
		public class RowData
		{
			public string forbidword;
		}

		public List<ForbidWord.RowData> Table = new List<ForbidWord.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"forbidword"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ForbidWord.RowData rowData = new ForbidWord.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.forbidword))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ForbidWord.RowData rowData = new ForbidWord.RowData();
			base.Read<string>(reader, ref rowData.forbidword, CVSReader.stringParse);
			this.columnno = 0;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
