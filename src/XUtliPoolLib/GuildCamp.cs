using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildCamp : CVSReader
	{
		public class RowData
		{
			public int ID;

			public string Name;

			public string Pic;

			public string Description;

			public string Condition;

			public int Type;

			public string RankDes;

			public long KillID;
		}

		public List<GuildCamp.RowData> Table = new List<GuildCamp.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Name",
				"Pic",
				"Description",
				"Condition",
				"Type",
				"RankDes",
				"KillID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildCamp.RowData rowData = new GuildCamp.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Pic))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Condition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.RankDes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.KillID))
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
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<long>(writer, Fields[this.ColMap[7]], CVSReader.longParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildCamp.RowData rowData = new GuildCamp.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Pic, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Condition, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.RankDes, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<long>(reader, ref rowData.KillID, CVSReader.longParse);
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
