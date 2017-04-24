using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildPermissionTable : CVSReader
	{
		public class RowData
		{
			public string GuildID;

			public int GPOS_LEADER;

			public int GPOS_VICELEADER;

			public int GPOS_OFFICER;

			public int GPOS_ELITEMEMBER;

			public int GPOS_MEMBER;
		}

		public List<GuildPermissionTable.RowData> Table = new List<GuildPermissionTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GuildID",
				"GPOS_LEADER",
				"GPOS_VICELEADER",
				"GPOS_OFFICER",
				"GPOS_ELITEMEMBER",
				"GPOS_MEMBER"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildPermissionTable.RowData rowData = new GuildPermissionTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GuildID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.GPOS_LEADER))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.GPOS_VICELEADER))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.GPOS_OFFICER))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.GPOS_ELITEMEMBER))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.GPOS_MEMBER))
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
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildPermissionTable.RowData rowData = new GuildPermissionTable.RowData();
			base.Read<string>(reader, ref rowData.GuildID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.GPOS_LEADER, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.GPOS_VICELEADER, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.GPOS_OFFICER, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.GPOS_ELITEMEMBER, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.GPOS_MEMBER, CVSReader.intParse);
			this.columnno = 5;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
