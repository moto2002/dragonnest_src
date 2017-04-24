using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ItemBackTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int SystemID;

			public string SystemName;

			public int Type;

			public int CostGold;

			public Seq2ListRef<int> ItemGold;

			public int CostDragonCoin;

			public Seq2ListRef<int> ItemDragonCoin;

			public int count;

			public string Desc;

			public Seq2Ref<int> Level;

			public int FindBackDays;
		}

		public List<ItemBackTable.RowData> Table = new List<ItemBackTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"SystemID",
				"SystemName",
				"Type",
				"CostGold",
				"ItemGold",
				"CostDragonCoin",
				"ItemDragonCoin",
				"count",
				"Desc",
				"Level",
				"FindBackDays"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ItemBackTable.RowData rowData = new ItemBackTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SystemName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.CostGold))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[5]], ref rowData.ItemGold, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.CostDragonCoin))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[7]], ref rowData.ItemDragonCoin, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.count))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[10]], ref rowData.Level, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.FindBackDays))
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
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ItemBackTable.RowData rowData = new ItemBackTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.SystemName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.CostGold, CVSReader.intParse);
			this.columnno = 4;
			base.ReadSeqList<int>(reader, ref rowData.ItemGold, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.CostDragonCoin, CVSReader.intParse);
			this.columnno = 6;
			base.ReadSeqList<int>(reader, ref rowData.ItemDragonCoin, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.count, CVSReader.intParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadSeq<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.FindBackDays, CVSReader.intParse);
			this.columnno = 11;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
