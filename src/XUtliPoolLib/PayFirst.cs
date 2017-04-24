using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PayFirst : CVSReader
	{
		public class RowData
		{
			public int Money;

			public int Award;

			public int SystemID;
		}

		public List<PayFirst.RowData> Table = new List<PayFirst.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Money",
				"Award",
				"SystemID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PayFirst.RowData rowData = new PayFirst.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Money))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Award))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SystemID))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PayFirst.RowData rowData = new PayFirst.RowData();
			base.Read<int>(reader, ref rowData.Money, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Award, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
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
