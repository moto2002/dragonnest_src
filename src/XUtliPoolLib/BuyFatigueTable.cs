using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BuyFatigueTable : CVSReader
	{
		public class RowData
		{
			public int FatigueID;

			public int Value;

			public int[] DragonCoinCost;

			public int[] DiamondCost;
		}

		public List<BuyFatigueTable.RowData> Table = new List<BuyFatigueTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FatigueID",
				"Value",
				"DragonCoinCost",
				"DiamondCost"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BuyFatigueTable.RowData rowData = new BuyFatigueTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.FatigueID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Value))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.DragonCoinCost))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.DiamondCost))
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
			base.WriteArray<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BuyFatigueTable.RowData rowData = new BuyFatigueTable.RowData();
			base.Read<int>(reader, ref rowData.FatigueID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Value, CVSReader.intParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DragonCoinCost, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
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
