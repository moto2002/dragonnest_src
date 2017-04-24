using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BattleCommandTable : CVSReader
	{
		public class RowData
		{
			public int id;

			public string name;

			public string content;

			public string sprite;
		}

		public List<BattleCommandTable.RowData> Table = new List<BattleCommandTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"name",
				"content",
				"sprite"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BattleCommandTable.RowData rowData = new BattleCommandTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.content))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.sprite))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BattleCommandTable.RowData rowData = new BattleCommandTable.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.content, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.sprite, CVSReader.stringParse);
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
