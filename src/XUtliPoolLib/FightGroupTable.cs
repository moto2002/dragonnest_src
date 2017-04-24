using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FightGroupTable : CVSReader
	{
		public class RowData
		{
			public string group;

			public string enemy;

			public string role;

			public string neutral;

			public string hostility;

			public string enemygod;

			public string rolegod;

			public string other;
		}

		public List<FightGroupTable.RowData> Table = new List<FightGroupTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"group",
				"enemy",
				"role",
				"neutral",
				"hostility",
				"enemygod",
				"rolegod",
				"other"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FightGroupTable.RowData rowData = new FightGroupTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.group))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.enemy))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.role))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.neutral))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.hostility))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.enemygod))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.rolegod))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.other))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FightGroupTable.RowData rowData = new FightGroupTable.RowData();
			base.Read<string>(reader, ref rowData.group, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.enemy, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.role, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.neutral, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.hostility, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.enemygod, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.rolegod, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.other, CVSReader.stringParse);
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
