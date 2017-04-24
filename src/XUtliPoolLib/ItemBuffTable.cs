using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ItemBuffTable : CVSReader
	{
		public class RowData
		{
			public uint ItemId;

			public Seq2ListRef<uint> Buffs;

			public string Name;

			public uint Type;
		}

		public List<ItemBuffTable.RowData> Table = new List<ItemBuffTable.RowData>();

		public ItemBuffTable.RowData GetByItemId(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchItemId(key, 0, this.Table.Count - 1);
		}

		private ItemBuffTable.RowData BinarySearchItemId(uint key, int min, int max)
		{
			ItemBuffTable.RowData rowData = this.Table[min];
			if (rowData.ItemId == key)
			{
				return rowData;
			}
			ItemBuffTable.RowData rowData2 = this.Table[max];
			if (rowData2.ItemId == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ItemBuffTable.RowData rowData3 = this.Table[num];
			if (rowData3.ItemId.CompareTo(key) > 0)
			{
				return this.BinarySearchItemId(key, min, num);
			}
			if (rowData3.ItemId.CompareTo(key) < 0)
			{
				return this.BinarySearchItemId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowItemId(uint key, ItemBuffTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ItemBuffTable.RowData rowData = this.Table[min];
			if (rowData.ItemId.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ItemId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemBuffTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ItemBuffTable.RowData rowData2 = this.Table[max];
			if (rowData2.ItemId.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ItemId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemBuffTable duplicate id:{0}  lineno: {1}", new object[]
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
			ItemBuffTable.RowData rowData3 = this.Table[num];
			if (rowData3.ItemId.CompareTo(key) > 0)
			{
				this.AddRowItemId(key, row, min, num);
				return;
			}
			if (rowData3.ItemId.CompareTo(key) < 0)
			{
				this.AddRowItemId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemBuffTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ItemId",
				"Buffs",
				"Name",
				"Type"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ItemBuffTable.RowData rowData = new ItemBuffTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemId))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Buffs, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Type))
			{
				return false;
			}
			this.AddRowItemId(rowData.ItemId, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ItemBuffTable.RowData rowData = new ItemBuffTable.RowData();
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.Buffs, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 3;
			this.AddRowItemId(rowData.ItemId, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
