using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AttributeEmblem : CVSReader
	{
		public class RowData
		{
			public uint EmblemID;

			public uint Position;

			public uint AttrID;

			public uint Probability;

			public Seq2Ref<uint> InitialRange;

			public Seq2Ref<uint> Range;

			public Seq3ListRef<int> SmeltAttr;

			public Seq3ListRef<int> SmeltAttr2;

			public Seq3ListRef<int> SmeltAttr3;
		}

		public List<AttributeEmblem.RowData> Table = new List<AttributeEmblem.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EmblemID",
				"Position",
				"AttrID",
				"Probability",
				"InitialRange",
				"Range",
				"SmeltAttr",
				"SmeltAttr2",
				"SmeltAttr3"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			AttributeEmblem.RowData rowData = new AttributeEmblem.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EmblemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Position))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.AttrID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Probability))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.InitialRange, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.Range, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.SmeltAttr, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[7]], ref rowData.SmeltAttr2, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[8]], ref rowData.SmeltAttr3, CVSReader.intParse, "3I"))
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 3, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse, 3, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse, 3, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			AttributeEmblem.RowData rowData = new AttributeEmblem.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Position, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.AttrID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Probability, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeq<uint>(reader, ref rowData.InitialRange, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeq<uint>(reader, ref rowData.Range, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr, CVSReader.intParse);
			this.columnno = 6;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr2, CVSReader.intParse);
			this.columnno = 7;
			base.ReadSeqList<int>(reader, ref rowData.SmeltAttr3, CVSReader.intParse);
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
