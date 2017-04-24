using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetLevelTable : CVSReader
	{
		public class RowData
		{
			public uint PetsID;

			public uint level;

			public uint exp;

			public Seq2ListRef<uint> PetsAttributes;
		}

		public List<PetLevelTable.RowData> Table = new List<PetLevelTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"PetsID",
				"level",
				"exp",
				"PetsAttributes"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetLevelTable.RowData rowData = new PetLevelTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.PetsID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.exp))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.PetsAttributes, CVSReader.uintParse, "2U"))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetLevelTable.RowData rowData = new PetLevelTable.RowData();
			base.Read<uint>(reader, ref rowData.PetsID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.exp, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.PetsAttributes, CVSReader.uintParse);
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
