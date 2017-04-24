using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BuyDragonCoin : CVSReader
	{
		public class RowData
		{
			public int Level;

			public long DragonCoin;

			public int[] DiamondCost;
		}

		public List<BuyDragonCoin.RowData> Table = new List<BuyDragonCoin.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Level",
				"DragonCoin",
				"DiamondCost"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BuyDragonCoin.RowData rowData = new BuyDragonCoin.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.DragonCoin))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.DiamondCost))
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
			base.Write<long>(writer, Fields[this.ColMap[1]], CVSReader.longParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BuyDragonCoin.RowData rowData = new BuyDragonCoin.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.Read<long>(reader, ref rowData.DragonCoin, CVSReader.longParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
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
