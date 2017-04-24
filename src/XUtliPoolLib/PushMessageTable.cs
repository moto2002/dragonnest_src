using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PushMessageTable : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public uint SubType;

			public uint[] TimeOffset;

			public string Title;

			public string Content;

			public uint IsCommonGlobal;

			public uint[] Time;

			public uint Date;

			public uint[] WeekDay;
		}

		public List<PushMessageTable.RowData> Table = new List<PushMessageTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"SubType",
				"TimeOffset",
				"Title",
				"Content",
				"IsCommonGlobal",
				"Time",
				"Date",
				"WeekDay"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PushMessageTable.RowData rowData = new PushMessageTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SubType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TimeOffset))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Title))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Content))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.IsCommonGlobal))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Time))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Date))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.WeekDay))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PushMessageTable.RowData rowData = new PushMessageTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SubType, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.TimeOffset, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.IsCommonGlobal, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.Date, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.WeekDay, CVSReader.uintParse);
			this.columnno = 8;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
