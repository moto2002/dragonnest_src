using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildBuffTable : CVSReader
	{
		public class RowData
		{
			public uint id;

			public string name;

			public uint type;

			public uint[] param;

			public uint time;

			public uint self;

			public uint itemid;
		}

		public List<GuildBuffTable.RowData> Table = new List<GuildBuffTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"name",
				"type",
				"param",
				"time",
				"self",
				"itemid"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildBuffTable.RowData rowData = new GuildBuffTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.param))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.time))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.self))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.itemid))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildBuffTable.RowData rowData = new GuildBuffTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.param, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.time, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.self, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 6;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
