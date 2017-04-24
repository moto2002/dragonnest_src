using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class RecommendFightNum : CVSReader
	{
		public class RowData
		{
			public uint Level;

			public uint SystemID;

			public uint Total;

			public uint Point;
		}

		public List<RecommendFightNum.RowData> Table = new List<RecommendFightNum.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Level",
				"SystemID",
				"Total",
				"Point"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			RecommendFightNum.RowData rowData = new RecommendFightNum.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Total))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Point))
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			RecommendFightNum.RowData rowData = new RecommendFightNum.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Total, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Point, CVSReader.uintParse);
			this.columnno = 3;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
