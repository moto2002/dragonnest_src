using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PowerPointCoeffTable : CVSReader
	{
		public class RowData
		{
			public int AttributeID;

			public uint Profession;

			public double Weight;
		}

		public List<PowerPointCoeffTable.RowData> Table = new List<PowerPointCoeffTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"AttributeID",
				"Profession",
				"Weight"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PowerPointCoeffTable.RowData rowData = new PowerPointCoeffTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.AttributeID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Profession))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Weight))
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
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<double>(writer, Fields[this.ColMap[2]], CVSReader.doubleParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PowerPointCoeffTable.RowData rowData = new PowerPointCoeffTable.RowData();
			base.Read<int>(reader, ref rowData.AttributeID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.Weight, CVSReader.doubleParse);
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
