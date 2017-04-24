using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PayWelfareTable : CVSReader
	{
		public class RowData
		{
			public int Order;

			public int SysID;

			public string TabName;

			public string TabIcon;
		}

		public List<PayWelfareTable.RowData> Table = new List<PayWelfareTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Order",
				"SysID",
				"TabName",
				"TabIcon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PayWelfareTable.RowData rowData = new PayWelfareTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Order))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SysID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TabName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TabIcon))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PayWelfareTable.RowData rowData = new PayWelfareTable.RowData();
			base.Read<int>(reader, ref rowData.Order, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
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
