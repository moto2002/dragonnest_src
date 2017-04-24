using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class VIPTable : CVSReader
	{
		public class RowData
		{
			public int VIP;

			public uint RMB;

			public int BuyGoldTimes;

			public int BuyFatigueTimes;

			public int NestScoreBonus;

			public uint AuctionOnSaleMax;

			public int BuyDragonCoinTimes;

			public int BossRushCount;

			public uint WorldChannelChatTimes;

			public int ItemID;

			public string[] VIPTips;

			public uint GoldClickTimes;

			public uint EquipMax;

			public uint EmblemMax;

			public uint BagMax;
		}

		public List<VIPTable.RowData> Table = new List<VIPTable.RowData>();

		public VIPTable.RowData GetByVIP(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchVIP(key, 0, this.Table.Count - 1);
		}

		private VIPTable.RowData BinarySearchVIP(int key, int min, int max)
		{
			VIPTable.RowData rowData = this.Table[min];
			if (rowData.VIP == key)
			{
				return rowData;
			}
			VIPTable.RowData rowData2 = this.Table[max];
			if (rowData2.VIP == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			VIPTable.RowData rowData3 = this.Table[num];
			if (rowData3.VIP.CompareTo(key) > 0)
			{
				return this.BinarySearchVIP(key, min, num);
			}
			if (rowData3.VIP.CompareTo(key) < 0)
			{
				return this.BinarySearchVIP(key, num, max);
			}
			return rowData3;
		}

		private void AddRowVIP(int key, VIPTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			VIPTable.RowData rowData = this.Table[min];
			if (rowData.VIP.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.VIP == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: VIPTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			VIPTable.RowData rowData2 = this.Table[max];
			if (rowData2.VIP.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.VIP == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: VIPTable duplicate id:{0}  lineno: {1}", new object[]
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
			VIPTable.RowData rowData3 = this.Table[num];
			if (rowData3.VIP.CompareTo(key) > 0)
			{
				this.AddRowVIP(key, row, min, num);
				return;
			}
			if (rowData3.VIP.CompareTo(key) < 0)
			{
				this.AddRowVIP(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: VIPTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"VIP",
				"RMB",
				"BuyGoldTimes",
				"BuyFatigueTimes",
				"NestScoreBonus",
				"AuctionOnSaleMax",
				"BuyDragonCoinTimes",
				"BossRushCount",
				"WorldChannelChatTimes",
				"ItemID",
				"VIPTips",
				"GoldClickTimes",
				"EquipMax",
				"EmblemMax",
				"BagMax"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			VIPTable.RowData rowData = new VIPTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.VIP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.RMB))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.BuyGoldTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.BuyFatigueTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.NestScoreBonus))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.AuctionOnSaleMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.BuyDragonCoinTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.BossRushCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.WorldChannelChatTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.VIPTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.GoldClickTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.EquipMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.EmblemMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.BagMax))
			{
				return false;
			}
			this.AddRowVIP(rowData.VIP, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			VIPTable.RowData rowData = new VIPTable.RowData();
			base.Read<int>(reader, ref rowData.VIP, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.RMB, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.BuyGoldTimes, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.BuyFatigueTimes, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.NestScoreBonus, CVSReader.intParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.AuctionOnSaleMax, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.BuyDragonCoinTimes, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.BossRushCount, CVSReader.intParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.WorldChannelChatTimes, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 9;
			base.ReadArray<string>(reader, ref rowData.VIPTips, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.GoldClickTimes, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.EquipMax, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.EmblemMax, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.BagMax, CVSReader.uintParse);
			this.columnno = 14;
			this.AddRowVIP(rowData.VIP, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
