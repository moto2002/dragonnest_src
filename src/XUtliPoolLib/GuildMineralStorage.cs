using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildMineralStorage : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public uint itemid;

			public string effect;

			public uint self;

			public string bufficon;

			public string buffdescribe;
		}

		public List<GuildMineralStorage.RowData> Table = new List<GuildMineralStorage.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"itemid",
				"effect",
				"self",
				"bufficon",
				"buffdescribe"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildMineralStorage.RowData rowData = new GuildMineralStorage.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.effect))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.self))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.bufficon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.buffdescribe))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildMineralStorage.RowData rowData = new GuildMineralStorage.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.effect, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.self, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.bufficon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.buffdescribe, CVSReader.stringParse);
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
