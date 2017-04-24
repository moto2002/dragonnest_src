using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FashionList : CVSReader
	{
		public class RowData
		{
			public int ItemID;

			public int EquipPos;

			public string ModelPrefabWarrior;

			public int PresentID;

			public string ModelPrefabSorcer;

			public string ModelPrefabArcher;

			public int[] ReplaceID;

			public string ModelPrefabCleric;

			public string ModelPrefab5;

			public string ModelPrefab6;

			public string ModelPrefab7;

			public string ModelPrefab8;
		}

		public List<FashionList.RowData> Table = new List<FashionList.RowData>();

		public FashionList.RowData GetByItemID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchItemID(key, 0, this.Table.Count - 1);
		}

		private FashionList.RowData BinarySearchItemID(int key, int min, int max)
		{
			FashionList.RowData rowData = this.Table[min];
			if (rowData.ItemID == key)
			{
				return rowData;
			}
			FashionList.RowData rowData2 = this.Table[max];
			if (rowData2.ItemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FashionList.RowData rowData3 = this.Table[num];
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

		private void AddRowItemID(int key, FashionList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FashionList.RowData rowData = this.Table[min];
			if (rowData.ItemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ItemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FashionList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FashionList.RowData rowData2 = this.Table[max];
			if (rowData2.ItemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ItemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FashionList duplicate id:{0}  lineno: {1}", new object[]
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
			FashionList.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FashionList duplicate id:{0}  lineno: {1}", new object[]
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
				"ModelPrefabWarrior",
				"PresentID",
				"ModelPrefabSorcer",
				"ModelPrefabArcher",
				"ReplaceID",
				"ModelPrefabCleric",
				"ModelPrefab5",
				"ModelPrefab6",
				"ModelPrefab7",
				"ModelPrefab8"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FashionList.RowData rowData = new FashionList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.EquipPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ModelPrefabWarrior))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ModelPrefabSorcer))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.ModelPrefabArcher))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ReplaceID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.ModelPrefabCleric))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.ModelPrefab5))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.ModelPrefab6))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.ModelPrefab7))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.ModelPrefab8))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FashionList.RowData rowData = new FashionList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.EquipPos, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ModelPrefabWarrior, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.PresentID, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ModelPrefabSorcer, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ModelPrefabArcher, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<int>(reader, ref rowData.ReplaceID, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ModelPrefabCleric, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.ModelPrefab5, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.ModelPrefab6, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ModelPrefab7, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.ModelPrefab8, CVSReader.stringParse);
			this.columnno = 11;
			this.AddRowItemID(rowData.ItemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
