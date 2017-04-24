using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PayListTable : CVSReader
	{
		public class RowData
		{
			public string ParamID;

			public int Price;

			public int Diamond;

			public int ExtDiamond;

			public string Name;

			public string Icon;

			public string Effect;

			public string Effect2;
		}

		public List<PayListTable.RowData> Table = new List<PayListTable.RowData>();

		public PayListTable.RowData GetByParamID(string key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			int i = 0;
			int count = this.Table.Count;
			while (i < count)
			{
				if (this.Table[i].ParamID == key)
				{
					return this.Table[i];
				}
				i++;
			}
			return null;
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ParamID",
				"Price",
				"Diamond",
				"ExtDiamond",
				"Name",
				"Icon",
				"Effect",
				"Effect2"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PayListTable.RowData rowData = new PayListTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ParamID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Price))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Diamond))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ExtDiamond))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Effect))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Effect2))
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
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PayListTable.RowData rowData = new PayListTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.ExtDiamond, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Effect2, CVSReader.stringParse);
			this.columnno = 7;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
