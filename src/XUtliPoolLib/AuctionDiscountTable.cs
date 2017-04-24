using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AuctionDiscountTable : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public uint Group;

			public float Discount;
		}

		public List<AuctionDiscountTable.RowData> Table = new List<AuctionDiscountTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"Group",
				"Discount"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			AuctionDiscountTable.RowData rowData = new AuctionDiscountTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Group))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Discount))
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
			base.Write<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			AuctionDiscountTable.RowData rowData = new AuctionDiscountTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Group, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.Discount, CVSReader.floatParse);
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
