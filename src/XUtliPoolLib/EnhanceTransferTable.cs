using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EnhanceTransferTable : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> originlevel;

			public Seq2Ref<uint> destlevel;

			public uint enhancelevel;

			public Seq2ListRef<uint> percent;

			public Seq2ListRef<uint> item;

			public uint dragoncoin;

			public int tipsID;
		}

		public List<EnhanceTransferTable.RowData> Table = new List<EnhanceTransferTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"originlevel",
				"destlevel",
				"enhancelevel",
				"percent",
				"item",
				"dragoncoin",
				"tipsID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EnhanceTransferTable.RowData rowData = new EnhanceTransferTable.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.originlevel, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.destlevel, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.enhancelevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.percent, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.item, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.dragoncoin))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.tipsID))
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EnhanceTransferTable.RowData rowData = new EnhanceTransferTable.RowData();
			base.ReadSeq<uint>(reader, ref rowData.originlevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.destlevel, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.enhancelevel, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.percent, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.item, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.dragoncoin, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.tipsID, CVSReader.intParse);
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
