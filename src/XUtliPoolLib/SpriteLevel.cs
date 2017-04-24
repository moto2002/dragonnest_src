using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SpriteLevel : CVSReader
	{
		public class RowData
		{
			public uint Level;

			public uint Quality;

			public uint Exp;

			public double Ratio;
		}

		public List<SpriteLevel.RowData> Table = new List<SpriteLevel.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Level",
				"Quality",
				"Exp",
				"Ratio"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SpriteLevel.RowData rowData = new SpriteLevel.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Exp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Ratio))
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
			base.Write<double>(writer, Fields[this.ColMap[3]], CVSReader.doubleParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SpriteLevel.RowData rowData = new SpriteLevel.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Exp, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.Ratio, CVSReader.doubleParse);
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
