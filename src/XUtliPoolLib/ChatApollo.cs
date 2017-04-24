using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ChatApollo : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int speak;

			public int music;

			public int click;

			public string note;

			public int opens;

			public int openm;

			public string note2;
		}

		public List<ChatApollo.RowData> Table = new List<ChatApollo.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"speak",
				"music",
				"click",
				"note",
				"opens",
				"openm",
				"note2"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ChatApollo.RowData rowData = new ChatApollo.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.speak))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.music))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.click))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.note))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.opens))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.openm))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.note2))
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ChatApollo.RowData rowData = new ChatApollo.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.speak, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.music, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.click, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.note, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.opens, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.openm, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.note2, CVSReader.stringParse);
			this.columnno = 7;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
