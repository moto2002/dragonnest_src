using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ProfessionGrowthPercentTable : CVSReader
	{
		public class RowData
		{
			public int ProfessionID;

			public int Strength;

			public int Agility;

			public int Intelligence;

			public int Vitality;

			public string ProfessionName;
		}

		public List<ProfessionGrowthPercentTable.RowData> Table = new List<ProfessionGrowthPercentTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ProfessionID",
				"Strength",
				"Agility",
				"Intelligence",
				"Vitality",
				"ProfessionName"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ProfessionGrowthPercentTable.RowData rowData = new ProfessionGrowthPercentTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ProfessionID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Strength))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Agility))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Intelligence))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Vitality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.ProfessionName))
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ProfessionGrowthPercentTable.RowData rowData = new ProfessionGrowthPercentTable.RowData();
			base.Read<int>(reader, ref rowData.ProfessionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Strength, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Agility, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Intelligence, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Vitality, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ProfessionName, CVSReader.stringParse);
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
