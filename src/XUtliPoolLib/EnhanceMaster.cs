using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EnhanceMaster : CVSReader
	{
		public class RowData
		{
			public uint ProfessionId;

			public uint TotalEnhanceLevel;

			public Seq2ListRef<uint> Attribute;
		}

		public List<EnhanceMaster.RowData> Table = new List<EnhanceMaster.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ProfessionId",
				"TotalEnhanceLevel",
				"Attribute"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EnhanceMaster.RowData rowData = new EnhanceMaster.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ProfessionId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TotalEnhanceLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.Attribute, CVSReader.uintParse, "2U"))
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
			EnhanceMaster.RowData rowData = new EnhanceMaster.RowData();
			base.Read<uint>(reader, ref rowData.ProfessionId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TotalEnhanceLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.Attribute, CVSReader.uintParse);
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
