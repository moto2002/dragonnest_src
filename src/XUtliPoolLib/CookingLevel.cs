using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CookingLevel : CVSReader
	{
		public class RowData
		{
			public uint CookLevel;

			public uint Experiences;
		}

		public List<CookingLevel.RowData> Table = new List<CookingLevel.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"CookLevel",
				"Experiences"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CookingLevel.RowData rowData = new CookingLevel.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.CookLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Experiences))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CookingLevel.RowData rowData = new CookingLevel.RowData();
			base.Read<uint>(reader, ref rowData.CookLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experiences, CVSReader.uintParse);
			this.columnno = 1;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
