using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PkPointTable : CVSReader
	{
		public class RowData
		{
			public uint point;

			public Seq2ListRef<uint> reward;

			public int level;

			public int IconIndex;
		}

		public List<PkPointTable.RowData> Table = new List<PkPointTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"point",
				"reward",
				"level",
				"IconIndex"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PkPointTable.RowData rowData = new PkPointTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.point))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.IconIndex))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PkPointTable.RowData rowData = new PkPointTable.RowData();
			base.Read<uint>(reader, ref rowData.point, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.level, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.IconIndex, CVSReader.intParse);
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
