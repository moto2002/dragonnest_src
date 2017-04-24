using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ShopTypeTable : CVSReader
	{
		public class RowData
		{
			public uint ShopID;

			public string ShopIcon;

			public uint ShopLevel;

			public Seq2ListRef<uint> RefreshCost;

			public uint[] ShopCycle;

			public Seq2ListRef<uint> ShopOpen;

			public string ShopName;

			public uint SystemId;
		}

		public List<ShopTypeTable.RowData> Table = new List<ShopTypeTable.RowData>();

		public ShopTypeTable.RowData GetByShopID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchShopID(key, 0, this.Table.Count - 1);
		}

		private ShopTypeTable.RowData BinarySearchShopID(uint key, int min, int max)
		{
			ShopTypeTable.RowData rowData = this.Table[min];
			if (rowData.ShopID == key)
			{
				return rowData;
			}
			ShopTypeTable.RowData rowData2 = this.Table[max];
			if (rowData2.ShopID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ShopTypeTable.RowData rowData3 = this.Table[num];
			if (rowData3.ShopID.CompareTo(key) > 0)
			{
				return this.BinarySearchShopID(key, min, num);
			}
			if (rowData3.ShopID.CompareTo(key) < 0)
			{
				return this.BinarySearchShopID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowShopID(uint key, ShopTypeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ShopTypeTable.RowData rowData = this.Table[min];
			if (rowData.ShopID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ShopID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShopTypeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ShopTypeTable.RowData rowData2 = this.Table[max];
			if (rowData2.ShopID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ShopID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShopTypeTable duplicate id:{0}  lineno: {1}", new object[]
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
			ShopTypeTable.RowData rowData3 = this.Table[num];
			if (rowData3.ShopID.CompareTo(key) > 0)
			{
				this.AddRowShopID(key, row, min, num);
				return;
			}
			if (rowData3.ShopID.CompareTo(key) < 0)
			{
				this.AddRowShopID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShopTypeTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ShopID",
				"ShopIcon",
				"ShopLevel",
				"RefreshCost",
				"ShopCycle",
				"ShopOpen",
				"ShopName",
				"SystemId"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ShopTypeTable.RowData rowData = new ShopTypeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ShopID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ShopIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ShopLevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.RefreshCost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ShopCycle))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.ShopOpen, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ShopName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SystemId))
			{
				return false;
			}
			this.AddRowShopID(rowData.ShopID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.WriteArray<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ShopTypeTable.RowData rowData = new ShopTypeTable.RowData();
			base.Read<uint>(reader, ref rowData.ShopID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ShopIcon, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ShopLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.RefreshCost, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.ShopCycle, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.ShopOpen, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ShopName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 7;
			this.AddRowShopID(rowData.ShopID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
