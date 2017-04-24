using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class QuickReplyTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int Type;

			public string Content;
		}

		public List<QuickReplyTable.RowData> Table = new List<QuickReplyTable.RowData>();

		public QuickReplyTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			int i = 0;
			int count = this.Table.Count;
			while (i < count)
			{
				if (this.Table[i].ID == key)
				{
					return this.Table[i];
				}
				i++;
			}
			return null;
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Type",
				"Content"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			QuickReplyTable.RowData rowData = new QuickReplyTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Content))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			QuickReplyTable.RowData rowData = new QuickReplyTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
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
