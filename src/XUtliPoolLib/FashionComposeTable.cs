using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FashionComposeTable : CVSReader
	{
		public class RowData
		{
			public int FashionID;

			public int FashionLevel;

			public Seq2Ref<uint> SrcItem1;

			public Seq2Ref<uint> SrcItem2;

			public Seq2Ref<uint> SrcItem3;

			public int ComposeCost;

			public Seq2ListRef<uint> Attributes;

			public Seq2ListRef<uint> Decompose;

			public int RequirLevel;
		}

		public List<FashionComposeTable.RowData> Table = new List<FashionComposeTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FashionID",
				"FashionLevel",
				"SrcItem1",
				"SrcItem2",
				"SrcItem3",
				"ComposeCost",
				"Attributes",
				"Decompose",
				"RequirLevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FashionComposeTable.RowData rowData = new FashionComposeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.FashionID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.FashionLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.SrcItem1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.SrcItem2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.SrcItem3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.ComposeCost))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.Attributes, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.Decompose, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.RequirLevel))
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
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FashionComposeTable.RowData rowData = new FashionComposeTable.RowData();
			base.Read<int>(reader, ref rowData.FashionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.FashionLevel, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeq<uint>(reader, ref rowData.SrcItem1, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeq<uint>(reader, ref rowData.SrcItem2, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeq<uint>(reader, ref rowData.SrcItem3, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.ComposeCost, CVSReader.intParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.Attributes, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.Decompose, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.RequirLevel, CVSReader.intParse);
			this.columnno = 8;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
