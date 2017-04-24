using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AuctionTypeList : CVSReader
	{
		public class RowData
		{
			public int id;

			public string name;

			public int pretype;
		}

		public List<AuctionTypeList.RowData> Table = new List<AuctionTypeList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"name",
				"pretype"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			AuctionTypeList.RowData rowData = new AuctionTypeList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.pretype))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			AuctionTypeList.RowData rowData = new AuctionTypeList.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.pretype, CVSReader.intParse);
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
