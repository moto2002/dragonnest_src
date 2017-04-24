using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FightDesignation : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public string Designation;

			public string Explanation;

			public string Effect;

			public string Color;
		}

		public List<FightDesignation.RowData> Table = new List<FightDesignation.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Designation",
				"Explanation",
				"Effect",
				"Color"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FightDesignation.RowData rowData = new FightDesignation.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Designation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Explanation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Effect))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Color))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FightDesignation.RowData rowData = new FightDesignation.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Designation, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
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
