using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XOptions : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int[] Classify;

			public int Sort;

			public string Text;

			public int Type;

			public string Range;

			public string Default;

			public string[] OptionText;
		}

		public List<XOptions.RowData> Table = new List<XOptions.RowData>();

		public XOptions.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private XOptions.RowData BinarySearchID(int key, int min, int max)
		{
			XOptions.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			XOptions.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XOptions.RowData rowData3 = this.Table[num];
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

		private void AddRowID(int key, XOptions.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XOptions.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XOptions duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XOptions.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XOptions duplicate id:{0}  lineno: {1}", new object[]
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
			XOptions.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XOptions duplicate id:{0}  lineno: {1}", new object[]
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
				"Classify",
				"Sort",
				"Text",
				"Type",
				"Range",
				"Default",
				"OptionText"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XOptions.RowData rowData = new XOptions.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Classify))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Sort))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Text))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Range))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Default))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.OptionText))
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
			base.WriteArray<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XOptions.RowData rowData = new XOptions.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.Classify, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Sort, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Range, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Default, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OptionText, CVSReader.stringParse);
			this.columnno = 7;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
