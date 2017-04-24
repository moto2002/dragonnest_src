using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EnhanceTable : CVSReader
	{
		public class RowData
		{
			public uint EquipPos;

			public uint EnhanceLevel;

			public Seq2ListRef<uint> NeedItem;

			public uint SuccessRate;

			public uint UpRate;

			public uint IsNeedBreak;
		}

		public List<EnhanceTable.RowData> Table = new List<EnhanceTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EquipPos",
				"EnhanceLevel",
				"NeedItem",
				"SuccessRate",
				"UpRate",
				"IsNeedBreak"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EnhanceTable.RowData rowData = new EnhanceTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EquipPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.EnhanceLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.NeedItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SuccessRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.UpRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.IsNeedBreak))
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
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EnhanceTable.RowData rowData = new EnhanceTable.RowData();
			base.Read<uint>(reader, ref rowData.EquipPos, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.NeedItem, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.UpRate, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.IsNeedBreak, CVSReader.uintParse);
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
