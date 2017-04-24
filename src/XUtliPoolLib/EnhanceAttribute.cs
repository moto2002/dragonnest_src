using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EnhanceAttribute : CVSReader
	{
		public class RowData
		{
			public uint EquipPos;

			public uint EnhanceLevel;

			public Seq2ListRef<uint> EnhanceAttr;
		}

		public List<EnhanceAttribute.RowData> Table = new List<EnhanceAttribute.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EquipPos",
				"EnhanceLevel",
				"EnhanceAttr"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EnhanceAttribute.RowData rowData = new EnhanceAttribute.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EquipPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.EnhanceLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.EnhanceAttr, CVSReader.uintParse, "2U"))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EnhanceAttribute.RowData rowData = new EnhanceAttribute.RowData();
			base.Read<uint>(reader, ref rowData.EquipPos, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.EnhanceAttr, CVSReader.uintParse);
			this.columnno = 2;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
