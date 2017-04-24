using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PayAileenTable : CVSReader
	{
		public class RowData
		{
			public string ParamID;

			public int Days;

			public int Price;

			public int VipLimit;

			public string Name;

			public string Icon;

			public string Desc;

			public int Diamond;

			public int[] LevelSealGiftID;

			public int MemberLimit;

			public string ServiceCode;
		}

		public List<PayAileenTable.RowData> Table = new List<PayAileenTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ParamID",
				"Days",
				"Price",
				"VipLimit",
				"Name",
				"Icon",
				"Desc",
				"Diamond",
				"LevelSealGiftID",
				"MemberLimit",
				"ServiceCode"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PayAileenTable.RowData rowData = new PayAileenTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ParamID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Days))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Price))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.VipLimit))
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
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Diamond))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.LevelSealGiftID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.MemberLimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.ServiceCode))
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
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PayAileenTable.RowData rowData = new PayAileenTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Days, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.VipLimit, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 7;
			base.ReadArray<int>(reader, ref rowData.LevelSealGiftID, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.MemberLimit, CVSReader.intParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 10;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
