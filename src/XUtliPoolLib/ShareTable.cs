using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ShareTable : CVSReader
	{
		public class RowData
		{
			public int Condition;

			public string Desc;

			public string Title;

			public string Icon;

			public string Link;

			public uint type;

			public int[] param;
		}

		public List<ShareTable.RowData> Table = new List<ShareTable.RowData>();

		public ShareTable.RowData GetByCondition(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchCondition(key, 0, this.Table.Count - 1);
		}

		private ShareTable.RowData BinarySearchCondition(int key, int min, int max)
		{
			ShareTable.RowData rowData = this.Table[min];
			if (rowData.Condition == key)
			{
				return rowData;
			}
			ShareTable.RowData rowData2 = this.Table[max];
			if (rowData2.Condition == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ShareTable.RowData rowData3 = this.Table[num];
			if (rowData3.Condition.CompareTo(key) > 0)
			{
				return this.BinarySearchCondition(key, min, num);
			}
			if (rowData3.Condition.CompareTo(key) < 0)
			{
				return this.BinarySearchCondition(key, num, max);
			}
			return rowData3;
		}

		private void AddRowCondition(int key, ShareTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ShareTable.RowData rowData = this.Table[min];
			if (rowData.Condition.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Condition == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShareTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ShareTable.RowData rowData2 = this.Table[max];
			if (rowData2.Condition.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Condition == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShareTable duplicate id:{0}  lineno: {1}", new object[]
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
			ShareTable.RowData rowData3 = this.Table[num];
			if (rowData3.Condition.CompareTo(key) > 0)
			{
				this.AddRowCondition(key, row, min, num);
				return;
			}
			if (rowData3.Condition.CompareTo(key) < 0)
			{
				this.AddRowCondition(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ShareTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Condition",
				"Desc",
				"Title",
				"Icon",
				"Link",
				"type",
				"param"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ShareTable.RowData rowData = new ShareTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Condition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Title))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Link))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.param))
			{
				return false;
			}
			this.AddRowCondition(rowData.Condition, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ShareTable.RowData rowData = new ShareTable.RowData();
			base.Read<int>(reader, ref rowData.Condition, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Link, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<int>(reader, ref rowData.param, CVSReader.intParse);
			this.columnno = 6;
			this.AddRowCondition(rowData.Condition, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
