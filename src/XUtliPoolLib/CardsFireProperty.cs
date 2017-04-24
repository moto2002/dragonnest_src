using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CardsFireProperty : CVSReader
	{
		public class RowData
		{
			public uint GroupId;

			public uint FireCounts;

			public Seq2ListRef<uint> Promote;

			public uint BreakLevel;
		}

		public List<CardsFireProperty.RowData> Table = new List<CardsFireProperty.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GroupId",
				"FireCounts",
				"Promote",
				"BreakLevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CardsFireProperty.RowData rowData = new CardsFireProperty.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GroupId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.FireCounts))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.Promote, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.BreakLevel))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CardsFireProperty.RowData rowData = new CardsFireProperty.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.FireCounts, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.Promote, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.BreakLevel, CVSReader.uintParse);
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
