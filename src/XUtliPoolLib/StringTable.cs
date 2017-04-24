using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class StringTable : CVSReader
	{
		public class RowData
		{
			public string Enum;

			public string Text;
		}

		public List<StringTable.RowData> Table = new List<StringTable.RowData>();

		public StringTable.RowData GetByEnum(string key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchEnum(key, 0, this.Table.Count - 1);
		}

		private StringTable.RowData BinarySearchEnum(string key, int min, int max)
		{
			StringTable.RowData rowData = this.Table[min];
			if (rowData.Enum == key)
			{
				return rowData;
			}
			StringTable.RowData rowData2 = this.Table[max];
			if (rowData2.Enum == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			StringTable.RowData rowData3 = this.Table[num];
			if (rowData3.Enum.CompareTo(key) > 0)
			{
				return this.BinarySearchEnum(key, min, num);
			}
			if (rowData3.Enum.CompareTo(key) < 0)
			{
				return this.BinarySearchEnum(key, num, max);
			}
			return rowData3;
		}

		private void AddRowEnum(string key, StringTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			StringTable.RowData rowData = this.Table[min];
			if (rowData.Enum.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Enum == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: StringTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			StringTable.RowData rowData2 = this.Table[max];
			if (rowData2.Enum.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Enum == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: StringTable duplicate id:{0}  lineno: {1}", new object[]
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
			StringTable.RowData rowData3 = this.Table[num];
			if (rowData3.Enum.CompareTo(key) > 0)
			{
				this.AddRowEnum(key, row, min, num);
				return;
			}
			if (rowData3.Enum.CompareTo(key) < 0)
			{
				this.AddRowEnum(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: StringTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Enum",
				"Text"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			StringTable.RowData rowData = new StringTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Enum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Text))
			{
				return false;
			}
			this.AddRowEnum(rowData.Enum, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			string text = Fields[this.ColMap[1]];
			text = XStringFormatHelper.Escape(text);
			base.Write<string>(writer, text, CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			StringTable.RowData rowData = new StringTable.RowData();
			base.Read<string>(reader, ref rowData.Enum, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 1;
			this.AddRowEnum(rowData.Enum, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
