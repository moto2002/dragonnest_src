using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ItemComposeTable : CVSReader
	{
		public class RowData
		{
			public int ItemID;

			public Seq2Ref<int> SrcItem1;

			public Seq2Ref<int> SrcItem2;

			public Seq2Ref<int> SrcItem3;

			public int ID;

			public int Coin;

			public int Level;

			public bool IsBind;

			public Seq2Ref<int> SrcItem4;

			public int Type;
		}

		public List<ItemComposeTable.RowData> Table = new List<ItemComposeTable.RowData>();

		public ItemComposeTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private ItemComposeTable.RowData BinarySearchID(int key, int min, int max)
		{
			ItemComposeTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			ItemComposeTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ItemComposeTable.RowData rowData3 = this.Table[num];
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

		private void AddRowID(int key, ItemComposeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ItemComposeTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemComposeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ItemComposeTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemComposeTable duplicate id:{0}  lineno: {1}", new object[]
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
			ItemComposeTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ItemComposeTable duplicate id:{0}  lineno: {1}", new object[]
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
				"SrcItem1",
				"SrcItem2",
				"SrcItem3",
				"ID",
				"Coin",
				"Level",
				"IsBind",
				"SrcItem4",
				"Type"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ItemComposeTable.RowData rowData = new ItemComposeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.SrcItem1, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.SrcItem2, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[3]], ref rowData.SrcItem3, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Coin))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.IsBind))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[8]], ref rowData.SrcItem4, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Type))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse, 2, "I");
			base.WriteSeq<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
			base.WriteSeq<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[7]]);
			base.WriteSeq<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ItemComposeTable.RowData rowData = new ItemComposeTable.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeq<int>(reader, ref rowData.SrcItem1, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeq<int>(reader, ref rowData.SrcItem2, CVSReader.intParse);
			this.columnno = 2;
			base.ReadSeq<int>(reader, ref rowData.SrcItem3, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Coin, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 6;
			base.Read(reader, ref rowData.IsBind);
			this.columnno = 7;
			base.ReadSeq<int>(reader, ref rowData.SrcItem4, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 9;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
