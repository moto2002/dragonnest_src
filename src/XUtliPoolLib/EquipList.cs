using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EquipList : CVSReader
	{
		public class RowData
		{
			public int ItemID;

			public int EquipPos;

			public Seq2ListRef<int> Attributes;

			public uint[] DecomposeDropID;

			public Seq3Ref<uint> Jade;

			public uint MaxEnhanceLevel;

			public Seq2ListRef<uint> SmeltNeedItem;

			public uint SmeltNeedMoney;

			public Seq2ListRef<uint> ForgeNeedItem;

			public Seq2Ref<uint> ForgeSpecialItem;

			public uint ForgeLowRate;

			public uint ForgeHighRate;

			public Seq2ListRef<uint> ForgeNeedItemAfter;

			public Seq2Ref<uint> ForgeSpecialItemAfter;

			public uint ForgeLowRateAfter;

			public uint ForgeHighRateAfter;

			public bool IsCanSmelt;
		}

		public List<EquipList.RowData> Table = new List<EquipList.RowData>();

		public EquipList.RowData GetByItemID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchItemID(key, 0, this.Table.Count - 1);
		}

		private EquipList.RowData BinarySearchItemID(int key, int min, int max)
		{
			EquipList.RowData rowData = this.Table[min];
			if (rowData.ItemID == key)
			{
				return rowData;
			}
			EquipList.RowData rowData2 = this.Table[max];
			if (rowData2.ItemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			EquipList.RowData rowData3 = this.Table[num];
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

		private void AddRowItemID(int key, EquipList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			EquipList.RowData rowData = this.Table[min];
			if (rowData.ItemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ItemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EquipList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			EquipList.RowData rowData2 = this.Table[max];
			if (rowData2.ItemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ItemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EquipList duplicate id:{0}  lineno: {1}", new object[]
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
			EquipList.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: EquipList duplicate id:{0}  lineno: {1}", new object[]
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
				"EquipPos",
				"Attributes",
				"DecomposeDropID",
				"Jade",
				"MaxEnhanceLevel",
				"SmeltNeedItem",
				"SmeltNeedMoney",
				"ForgeNeedItem",
				"ForgeSpecialItem",
				"ForgeLowRate",
				"ForgeHighRate",
				"ForgeNeedItemAfter",
				"ForgeSpecialItemAfter",
				"ForgeLowRateAfter",
				"ForgeHighRateAfter",
				"IsCanSmelt"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EquipList.RowData rowData = new EquipList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.EquipPos))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.Attributes, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.DecomposeDropID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.Jade, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MaxEnhanceLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.SmeltNeedItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SmeltNeedMoney))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.ForgeNeedItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.ForgeSpecialItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.ForgeLowRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.ForgeHighRate))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.ForgeNeedItemAfter, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[13]], ref rowData.ForgeSpecialItemAfter, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.ForgeLowRateAfter))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.ForgeHighRateAfter))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.IsCanSmelt))
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
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 3, "U");
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[16]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EquipList.RowData rowData = new EquipList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.EquipPos, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeqList<int>(reader, ref rowData.Attributes, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.DecomposeDropID, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeq<uint>(reader, ref rowData.Jade, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.MaxEnhanceLevel, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.SmeltNeedItem, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SmeltNeedMoney, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.ForgeNeedItem, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeq<uint>(reader, ref rowData.ForgeSpecialItem, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.ForgeLowRate, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.ForgeHighRate, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.ForgeNeedItemAfter, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeq<uint>(reader, ref rowData.ForgeSpecialItemAfter, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.ForgeLowRateAfter, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<uint>(reader, ref rowData.ForgeHighRateAfter, CVSReader.uintParse);
			this.columnno = 15;
			base.Read(reader, ref rowData.IsCanSmelt);
			this.columnno = 16;
			this.AddRowItemID(rowData.ItemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
