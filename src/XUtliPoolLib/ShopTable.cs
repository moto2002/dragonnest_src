using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ShopTable : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public uint ItemId;

			public Seq2Ref<uint> ConsumeItem;

			public uint Type;

			public uint LevelCondition;

			public uint PowerpointCondition;

			public uint DailyCountCondition;

			public uint CountCondition;

			public Seq2Ref<uint> Benefit;

			public Seq2ListRef<uint> Price;

			public Seq2Ref<uint> LevelShow;

			public uint VIPCondition;

			public uint ArenaCondition;

			public uint PKCondition;

			public uint GuildLevel;

			public Seq2Ref<uint> Slot;

			public bool IsNotBind;

			public uint CookLevel;
		}

		public List<ShopTable.RowData> Table = new List<ShopTable.RowData>();

		public ShopTable.RowData GetByID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private ShopTable.RowData BinarySearchID(uint key, int min, int max)
		{
			ShopTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			ShopTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ShopTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(uint key, ShopTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ShopTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShopTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ShopTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShopTable duplicate id:{0}  lineno: {1}", new object[]
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
			ShopTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShopTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"ItemId",
				"ConsumeItem",
				"Type",
				"LevelCondition",
				"PowerpointCondition",
				"DailyCountCondition",
				"CountCondition",
				"Benefit",
				"Price",
				"LevelShow",
				"VIPCondition",
				"ArenaCondition",
				"PKCondition",
				"GuildLevel",
				"Slot",
				"IsNotBind",
				"CookLevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ShopTable.RowData rowData = new ShopTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ItemId))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.ConsumeItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.LevelCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.PowerpointCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.DailyCountCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.CountCondition))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.Benefit, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.Price, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.LevelShow, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.VIPCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.ArenaCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.PKCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.GuildLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[15]], ref rowData.Slot, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.IsNotBind))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.CookLevel))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[16]]);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ShopTable.RowData rowData = new ShopTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<uint>(reader, ref rowData.ConsumeItem, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.LevelCondition, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.PowerpointCondition, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.DailyCountCondition, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.CountCondition, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeq<uint>(reader, ref rowData.Benefit, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.Price, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadSeq<uint>(reader, ref rowData.LevelShow, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.VIPCondition, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.ArenaCondition, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.PKCondition, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeq<uint>(reader, ref rowData.Slot, CVSReader.uintParse);
			this.columnno = 15;
			base.Read(reader, ref rowData.IsNotBind);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.CookLevel, CVSReader.uintParse);
			this.columnno = 17;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
