using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ItemList : CVSReader
	{
		public class RowData
		{
			public int ItemID;

			public string[] ItemName;

			public string ItemDescription;

			public string[] ItemIcon;

			public int ItemType;

			public int ItemQuality;

			public int ReqLevel;

			public int SellPrize;

			public int SortID;

			public string[] ItemAtlas;

			public string DoodadFx;

			public Seq2ListRef<int> Access;

			public int ShowTips;

			public string[] ItemAtlas1;

			public string[] ItemIcon1;

			public bool CanTrade;

			public uint[] AuctionType;

			public int OverCnt;

			public uint AuctPriceRecommend;

			public uint Profession;

			public uint Overlap;

			public string NumberName;

			public uint TimeLimit;

			public Seq2ListRef<uint> Decompose;

			public string ItemEffect;

			public int ReqRoll;

			public uint AuctionGroup;

			public uint IsNeedShowTipsPanel;

			public float[] IconTransform;

			public Seq2Ref<float> AuctionRange;

			public uint IsCanRecycle;

			public Seq2Ref<uint> Sell;
		}

		public List<ItemList.RowData> Table = new List<ItemList.RowData>();

		public ItemList.RowData GetByItemID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchItemID(key, 0, this.Table.Count - 1);
		}

		private ItemList.RowData BinarySearchItemID(int key, int min, int max)
		{
			ItemList.RowData rowData = this.Table[min];
			if (rowData.ItemID == key)
			{
				return rowData;
			}
			ItemList.RowData rowData2 = this.Table[max];
			if (rowData2.ItemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ItemList.RowData rowData3 = this.Table[num];
			if (rowData3.ItemID.CompareTo(key) > 0)
			{
				return this.BinarySearchItemID(key, min, num);
			}
			if (rowData3.ItemID.CompareTo(key) < 0)
			{
				return this.BinarySearchItemID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowItemID(int key, ItemList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ItemList.RowData rowData = this.Table[min];
			if (rowData.ItemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ItemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ItemList.RowData rowData2 = this.Table[max];
			if (rowData2.ItemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ItemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			if (max - min <= 1)
			{
				this.Table.Insert(min + 1, row);
				return;
			}
			int num = min + (max - min) / 2;
			ItemList.RowData rowData3 = this.Table[num];
			if (rowData3.ItemID.CompareTo(key) > 0)
			{
				this.AddRowItemID(key, row, min, num);
				return;
			}
			if (rowData3.ItemID.CompareTo(key) < 0)
			{
				this.AddRowItemID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ItemID",
				"ItemName",
				"ItemDescription",
				"ItemIcon",
				"ItemType",
				"ItemQuality",
				"ReqLevel",
				"SellPrize",
				"SortID",
				"ItemAtlas",
				"DoodadFx",
				"Access",
				"ShowTips",
				"ItemAtlas1",
				"ItemIcon1",
				"CanTrade",
				"AuctionType",
				"OverCnt",
				"AuctPriceRecommend",
				"Profession",
				"Overlap",
				"NumberName",
				"TimeLimit",
				"Decompose",
				"ItemEffect",
				"ReqRoll",
				"AuctionGroup",
				"IsNeedShowTipsPanel",
				"IconTransform",
				"AuctionRange",
				"IsCanRecycle",
				"Sell"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ItemList.RowData rowData = new ItemList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ItemName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ItemDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ItemIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ItemType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.ItemQuality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ReqLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SellPrize))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.SortID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.ItemAtlas))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.DoodadFx))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[11]], ref rowData.Access, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.ShowTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.ItemAtlas1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.ItemIcon1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.CanTrade))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.AuctionType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.OverCnt))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.AuctPriceRecommend))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.Profession))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.Overlap))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.NumberName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.TimeLimit))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[23]], ref rowData.Decompose, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.ItemEffect))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.ReqRoll))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.AuctionGroup))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.IsNeedShowTipsPanel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.IconTransform))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[29]], ref rowData.AuctionRange, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[30]], ref rowData.IsCanRecycle))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[31]], ref rowData.Sell, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowItemID(rowData.ItemID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[12]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[14]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[15]]);
			base.WriteArray<uint>(writer, Fields[this.ColMap[16]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[19]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[21]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[22]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[23]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[24]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[25]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[27]], CVSReader.uintParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[28]], CVSReader.floatParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[29]], CVSReader.floatParse, 2, "F");
			base.Write<uint>(writer, Fields[this.ColMap[30]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[31]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ItemList.RowData rowData = new ItemList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.ItemName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ItemDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.ItemIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ItemType, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.ItemQuality, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.ReqLevel, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.SellPrize, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.ItemAtlas, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.DoodadFx, CVSReader.stringParse);
			this.columnno = 10;
			base.ReadSeqList<int>(reader, ref rowData.Access, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.ShowTips, CVSReader.intParse);
			this.columnno = 12;
			base.ReadArray<string>(reader, ref rowData.ItemAtlas1, CVSReader.stringParse);
			this.columnno = 13;
			base.ReadArray<string>(reader, ref rowData.ItemIcon1, CVSReader.stringParse);
			this.columnno = 14;
			base.Read(reader, ref rowData.CanTrade);
			this.columnno = 15;
			base.ReadArray<uint>(reader, ref rowData.AuctionType, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.OverCnt, CVSReader.intParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.AuctPriceRecommend, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.Overlap, CVSReader.uintParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.NumberName, CVSReader.stringParse);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.TimeLimit, CVSReader.uintParse);
			this.columnno = 22;
			base.ReadSeqList<uint>(reader, ref rowData.Decompose, CVSReader.uintParse);
			this.columnno = 23;
			base.Read<string>(reader, ref rowData.ItemEffect, CVSReader.stringParse);
			this.columnno = 24;
			base.Read<int>(reader, ref rowData.ReqRoll, CVSReader.intParse);
			this.columnno = 25;
			base.Read<uint>(reader, ref rowData.AuctionGroup, CVSReader.uintParse);
			this.columnno = 26;
			base.Read<uint>(reader, ref rowData.IsNeedShowTipsPanel, CVSReader.uintParse);
			this.columnno = 27;
			base.ReadArray<float>(reader, ref rowData.IconTransform, CVSReader.floatParse);
			this.columnno = 28;
			base.ReadSeq<float>(reader, ref rowData.AuctionRange, CVSReader.floatParse);
			this.columnno = 29;
			base.Read<uint>(reader, ref rowData.IsCanRecycle, CVSReader.uintParse);
			this.columnno = 30;
			base.ReadSeq<uint>(reader, ref rowData.Sell, CVSReader.uintParse);
			this.columnno = 31;
			this.AddRowItemID(rowData.ItemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
