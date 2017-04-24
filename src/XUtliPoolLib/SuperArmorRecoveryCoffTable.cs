using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SuperArmorRecoveryCoffTable : CVSReader
	{
		public class RowData
		{
			public int Value;

			public int monster_type;

			public double SupRecoveryChange;
		}

		public List<SuperArmorRecoveryCoffTable.RowData> Table = new List<SuperArmorRecoveryCoffTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Value",
				"monster_type",
				"SupRecoveryChange"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SuperArmorRecoveryCoffTable.RowData rowData = new SuperArmorRecoveryCoffTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Value))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.monster_type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SupRecoveryChange))
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
			base.Write<double>(writer, Fields[this.ColMap[2]], CVSReader.doubleParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SuperArmorRecoveryCoffTable.RowData rowData = new SuperArmorRecoveryCoffTable.RowData();
			base.Read<int>(reader, ref rowData.Value, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.monster_type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.SupRecoveryChange, CVSReader.doubleParse);
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
