using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class OperationRecord : CVSReader
	{
		public class RowData
		{
			public string WindowName;

			public uint RecordID;
		}

		public List<OperationRecord.RowData> Table = new List<OperationRecord.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"WindowName",
				"RecordID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			OperationRecord.RowData rowData = new OperationRecord.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.WindowName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.RecordID))
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
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			OperationRecord.RowData rowData = new OperationRecord.RowData();
			base.Read<string>(reader, ref rowData.WindowName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.RecordID, CVSReader.uintParse);
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
