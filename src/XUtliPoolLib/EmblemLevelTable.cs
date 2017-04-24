using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EmblemLevelTable : CVSReader
	{
		public class RowData
		{
			public uint EmblemLevel;

			public uint EXP0;

			public uint EXP1;

			public uint EXP2;

			public uint EXP3;

			public uint EXP4;

			public uint EXP5;

			public float Advance;
		}

		public List<EmblemLevelTable.RowData> Table = new List<EmblemLevelTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EmblemLevel",
				"EXP0",
				"EXP1",
				"EXP2",
				"EXP3",
				"EXP4",
				"EXP5",
				"Advance"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EmblemLevelTable.RowData rowData = new EmblemLevelTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EmblemLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.EXP0))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.EXP1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.EXP2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.EXP3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.EXP4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.EXP5))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Advance))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<float>(writer, Fields[this.ColMap[7]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EmblemLevelTable.RowData rowData = new EmblemLevelTable.RowData();
			base.Read<uint>(reader, ref rowData.EmblemLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.EXP0, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.EXP1, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.EXP2, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.EXP3, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.EXP4, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.EXP5, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<float>(reader, ref rowData.Advance, CVSReader.floatParse);
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
