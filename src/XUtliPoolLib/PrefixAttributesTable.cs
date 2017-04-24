using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PrefixAttributesTable : CVSReader
	{
		public class RowData
		{
			public uint EquipID;

			public uint Slot;

			public uint AttrID;

			public Seq3ListRef<uint> AttrRange;

			public uint Prob;
		}

		public List<PrefixAttributesTable.RowData> Table = new List<PrefixAttributesTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EquipID",
				"Slot",
				"AttrID",
				"AttrRange",
				"Prob"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PrefixAttributesTable.RowData rowData = new PrefixAttributesTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EquipID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Slot))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.AttrID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.AttrRange, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Prob))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 3, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PrefixAttributesTable.RowData rowData = new PrefixAttributesTable.RowData();
			base.Read<uint>(reader, ref rowData.EquipID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Slot, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.AttrID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.AttrRange, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Prob, CVSReader.uintParse);
			this.columnno = 4;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
