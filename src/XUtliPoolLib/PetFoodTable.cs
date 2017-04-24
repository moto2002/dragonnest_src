using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetFoodTable : CVSReader
	{
		public class RowData
		{
			public uint itemid;

			public uint exp;

			public string description;

			public uint hungry;

			public int mood;
		}

		public List<PetFoodTable.RowData> Table = new List<PetFoodTable.RowData>();

		public PetFoodTable.RowData GetByitemid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchitemid(key, 0, this.Table.Count - 1);
		}

		private PetFoodTable.RowData BinarySearchitemid(uint key, int min, int max)
		{
			PetFoodTable.RowData rowData = this.Table[min];
			if (rowData.itemid == key)
			{
				return rowData;
			}
			PetFoodTable.RowData rowData2 = this.Table[max];
			if (rowData2.itemid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PetFoodTable.RowData rowData3 = this.Table[num];
			if (rowData3.itemid.CompareTo(key) > 0)
			{
				return this.BinarySearchitemid(key, min, num);
			}
			if (rowData3.itemid.CompareTo(key) < 0)
			{
				return this.BinarySearchitemid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowitemid(uint key, PetFoodTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PetFoodTable.RowData rowData = this.Table[min];
			if (rowData.itemid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetFoodTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PetFoodTable.RowData rowData2 = this.Table[max];
			if (rowData2.itemid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetFoodTable duplicate id:{0}  lineno: {1}", new object[]
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
			PetFoodTable.RowData rowData3 = this.Table[num];
			if (rowData3.itemid.CompareTo(key) > 0)
			{
				this.AddRowitemid(key, row, min, num);
				return;
			}
			if (rowData3.itemid.CompareTo(key) < 0)
			{
				this.AddRowitemid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetFoodTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"itemid",
				"exp",
				"description",
				"hungry",
				"mood"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetFoodTable.RowData rowData = new PetFoodTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.exp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.hungry))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.mood))
			{
				return false;
			}
			this.AddRowitemid(rowData.itemid, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetFoodTable.RowData rowData = new PetFoodTable.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.exp, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.hungry, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.mood, CVSReader.intParse);
			this.columnno = 4;
			this.AddRowitemid(rowData.itemid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
