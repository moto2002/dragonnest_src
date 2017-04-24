using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class NestTypeTable : CVSReader
	{
		public class RowData
		{
			public int TypeID;

			public string TypeName;

			public string TypeBg;

			public string TypeIcon;
		}

		public List<NestTypeTable.RowData> Table = new List<NestTypeTable.RowData>();

		public NestTypeTable.RowData GetByTypeID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchTypeID(key, 0, this.Table.Count - 1);
		}

		private NestTypeTable.RowData BinarySearchTypeID(int key, int min, int max)
		{
			NestTypeTable.RowData rowData = this.Table[min];
			if (rowData.TypeID == key)
			{
				return rowData;
			}
			NestTypeTable.RowData rowData2 = this.Table[max];
			if (rowData2.TypeID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			NestTypeTable.RowData rowData3 = this.Table[num];
			if (rowData3.TypeID.CompareTo(key) > 0)
			{
				return this.BinarySearchTypeID(key, min, num);
			}
			if (rowData3.TypeID.CompareTo(key) < 0)
			{
				return this.BinarySearchTypeID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowTypeID(int key, NestTypeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			NestTypeTable.RowData rowData = this.Table[min];
			if (rowData.TypeID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.TypeID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestTypeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			NestTypeTable.RowData rowData2 = this.Table[max];
			if (rowData2.TypeID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.TypeID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestTypeTable duplicate id:{0}  lineno: {1}", new object[]
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
			NestTypeTable.RowData rowData3 = this.Table[num];
			if (rowData3.TypeID.CompareTo(key) > 0)
			{
				this.AddRowTypeID(key, row, min, num);
				return;
			}
			if (rowData3.TypeID.CompareTo(key) < 0)
			{
				this.AddRowTypeID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestTypeTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"TypeID",
				"TypeName",
				"TypeBg",
				"TypeIcon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			NestTypeTable.RowData rowData = new NestTypeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TypeID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TypeName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TypeBg))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TypeIcon))
			{
				return false;
			}
			this.AddRowTypeID(rowData.TypeID, rowData, 0, this.Table.Count - 1);
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			NestTypeTable.RowData rowData = new NestTypeTable.RowData();
			base.Read<int>(reader, ref rowData.TypeID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TypeName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TypeBg, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TypeIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.AddRowTypeID(rowData.TypeID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
