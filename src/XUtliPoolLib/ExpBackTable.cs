using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ExpBackTable : CVSReader
	{
		public class RowData
		{
			public int type;

			public int count;

			public int exp;

			public int freeExpParam;

			public int moneyCostParam;
		}

		public List<ExpBackTable.RowData> Table = new List<ExpBackTable.RowData>();

		public ExpBackTable.RowData GetBytype(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchtype(key, 0, this.Table.Count - 1);
		}

		private ExpBackTable.RowData BinarySearchtype(int key, int min, int max)
		{
			ExpBackTable.RowData rowData = this.Table[min];
			if (rowData.type == key)
			{
				return rowData;
			}
			ExpBackTable.RowData rowData2 = this.Table[max];
			if (rowData2.type == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ExpBackTable.RowData rowData3 = this.Table[num];
			if (rowData3.type.CompareTo(key) > 0)
			{
				return this.BinarySearchtype(key, min, num);
			}
			if (rowData3.type.CompareTo(key) < 0)
			{
				return this.BinarySearchtype(key, num, max);
			}
			return rowData3;
		}

		private void AddRowtype(int key, ExpBackTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ExpBackTable.RowData rowData = this.Table[min];
			if (rowData.type.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ExpBackTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ExpBackTable.RowData rowData2 = this.Table[max];
			if (rowData2.type.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ExpBackTable duplicate id:{0}  lineno: {1}", new object[]
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
			ExpBackTable.RowData rowData3 = this.Table[num];
			if (rowData3.type.CompareTo(key) > 0)
			{
				this.AddRowtype(key, row, min, num);
				return;
			}
			if (rowData3.type.CompareTo(key) < 0)
			{
				this.AddRowtype(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ExpBackTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"type",
				"count",
				"exp",
				"freeExpParam",
				"moneyCostParam"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ExpBackTable.RowData rowData = new ExpBackTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.count))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.exp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.freeExpParam))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.moneyCostParam))
			{
				return false;
			}
			this.AddRowtype(rowData.type, rowData, 0, this.Table.Count - 1);
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ExpBackTable.RowData rowData = new ExpBackTable.RowData();
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.count, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.exp, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.freeExpParam, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.moneyCostParam, CVSReader.intParse);
			this.columnno = 4;
			this.AddRowtype(rowData.type, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
