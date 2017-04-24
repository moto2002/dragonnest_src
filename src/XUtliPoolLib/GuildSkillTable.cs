using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildSkillTable : CVSReader
	{
		public class RowData
		{
			public uint skillid;

			public string name;

			public uint level;

			public Seq2ListRef<uint> need;

			public uint rexp;

			public uint glevel;

			public Seq2ListRef<uint> attribute;

			public string icon;

			public string atlas;

			public string currentLevelDescription;

			public uint roleLevel;

			public uint[] profecssion;
		}

		public List<GuildSkillTable.RowData> Table = new List<GuildSkillTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"skillid",
				"name",
				"level",
				"need",
				"rexp",
				"glevel",
				"attribute",
				"icon",
				"atlas",
				"currentLevelDescription",
				"roleLevel",
				"profecssion"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildSkillTable.RowData rowData = new GuildSkillTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.skillid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.need, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.rexp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.glevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.attribute, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.atlas))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.currentLevelDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.roleLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.profecssion))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildSkillTable.RowData rowData = new GuildSkillTable.RowData();
			base.Read<uint>(reader, ref rowData.skillid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.need, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.rexp, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.glevel, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.attribute, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.currentLevelDescription, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.roleLevel, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadArray<uint>(reader, ref rowData.profecssion, CVSReader.uintParse);
			this.columnno = 11;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
