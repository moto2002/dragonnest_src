using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FlowerSendNoticeTable : CVSReader
	{
		public class RowData
		{
			public int ItemID;

			public int Num;

			public uint NoticeID;

			public string ThanksWords;
		}

		public List<FlowerSendNoticeTable.RowData> Table = new List<FlowerSendNoticeTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ItemID",
				"Num",
				"NoticeID",
				"ThanksWords"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FlowerSendNoticeTable.RowData rowData = new FlowerSendNoticeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Num))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.NoticeID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ThanksWords))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FlowerSendNoticeTable.RowData rowData = new FlowerSendNoticeTable.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Num, CVSReader.intParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.NoticeID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ThanksWords, CVSReader.stringParse);
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
