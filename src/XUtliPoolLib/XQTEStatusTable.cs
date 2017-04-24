using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XQTEStatusTable : CVSReader
	{
		public class RowData
		{
			public string Name;

			public uint Value;
		}

		public List<XQTEStatusTable.RowData> Table = new List<XQTEStatusTable.RowData>();

		public XQTEStatusTable.RowData GetByValue(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchValue(key, 0, this.Table.Count - 1);
		}

		private XQTEStatusTable.RowData BinarySearchValue(uint key, int min, int max)
		{
			XQTEStatusTable.RowData rowData = this.Table[min];
			if (rowData.Value == key)
			{
				return rowData;
			}
			XQTEStatusTable.RowData rowData2 = this.Table[max];
			if (rowData2.Value == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XQTEStatusTable.RowData rowData3 = this.Table[num];
			if (rowData3.Value.CompareTo(key) > 0)
			{
				return this.BinarySearchValue(key, min, num);
			}
			if (rowData3.Value.CompareTo(key) < 0)
			{
				return this.BinarySearchValue(key, num, max);
			}
			return rowData3;
		}

		private void AddRowValue(uint key, XQTEStatusTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XQTEStatusTable.RowData rowData = this.Table[min];
			if (rowData.Value.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Value == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XQTEStatusTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XQTEStatusTable.RowData rowData2 = this.Table[max];
			if (rowData2.Value.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Value == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XQTEStatusTable duplicate id:{0}  lineno: {1}", new object[]
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
			XQTEStatusTable.RowData rowData3 = this.Table[num];
			if (rowData3.Value.CompareTo(key) > 0)
			{
				this.AddRowValue(key, row, min, num);
				return;
			}
			if (rowData3.Value.CompareTo(key) < 0)
			{
				this.AddRowValue(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XQTEStatusTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Name",
				"Value"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XQTEStatusTable.RowData rowData = new XQTEStatusTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Value))
			{
				return false;
			}
			this.AddRowValue(rowData.Value, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XQTEStatusTable.RowData rowData = new XQTEStatusTable.RowData();
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Value, CVSReader.uintParse);
			this.columnno = 1;
			this.AddRowValue(rowData.Value, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
