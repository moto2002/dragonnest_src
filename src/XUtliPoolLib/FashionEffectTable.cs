using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FashionEffectTable : CVSReader
	{
		public class RowData
		{
			public uint Quality;

			public Seq2ListRef<uint> Effect2;

			public Seq2ListRef<uint> Effect3;

			public Seq2ListRef<uint> Effect4;

			public Seq2ListRef<uint> Effect5;

			public Seq2ListRef<uint> Effect6;

			public Seq2ListRef<uint> Effect7;

			public bool IsThreeSuit;
		}

		public List<FashionEffectTable.RowData> Table = new List<FashionEffectTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Quality",
				"Effect2",
				"Effect3",
				"Effect4",
				"Effect5",
				"Effect6",
				"Effect7",
				"IsThreeSuit"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FashionEffectTable.RowData rowData = new FashionEffectTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Quality))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Effect2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.Effect3, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.Effect4, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.Effect5, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.Effect6, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.Effect7, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.IsThreeSuit))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[7]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FashionEffectTable.RowData rowData = new FashionEffectTable.RowData();
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.Effect2, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.Effect3, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.Effect4, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.Effect5, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.Effect6, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.Effect7, CVSReader.uintParse);
			this.columnno = 6;
			base.Read(reader, ref rowData.IsThreeSuit);
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
