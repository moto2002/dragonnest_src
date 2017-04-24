using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class NestListTable : CVSReader
	{
		public class RowData
		{
			public int NestID;

			public int Type;

			public int Difficulty;
		}

		public List<NestListTable.RowData> Table = new List<NestListTable.RowData>();

		public NestListTable.RowData GetByNestID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchNestID(key, 0, this.Table.Count - 1);
		}

		private NestListTable.RowData BinarySearchNestID(int key, int min, int max)
		{
			NestListTable.RowData rowData = this.Table[min];
			if (rowData.NestID == key)
			{
				return rowData;
			}
			NestListTable.RowData rowData2 = this.Table[max];
			if (rowData2.NestID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			NestListTable.RowData rowData3 = this.Table[num];
			if (rowData3.NestID.CompareTo(key) > 0)
			{
				return this.BinarySearchNestID(key, min, num);
			}
			if (rowData3.NestID.CompareTo(key) < 0)
			{
				return this.BinarySearchNestID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowNestID(int key, NestListTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			NestListTable.RowData rowData = this.Table[min];
			if (rowData.NestID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.NestID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestListTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			NestListTable.RowData rowData2 = this.Table[max];
			if (rowData2.NestID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.NestID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestListTable duplicate id:{0}  lineno: {1}", new object[]
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
			NestListTable.RowData rowData3 = this.Table[num];
			if (rowData3.NestID.CompareTo(key) > 0)
			{
				this.AddRowNestID(key, row, min, num);
				return;
			}
			if (rowData3.NestID.CompareTo(key) < 0)
			{
				this.AddRowNestID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestListTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"NestID",
				"Type",
				"Difficulty"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			NestListTable.RowData rowData = new NestListTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.NestID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Difficulty))
			{
				return false;
			}
			this.AddRowNestID(rowData.NestID, rowData, 0, this.Table.Count - 1);
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			NestListTable.RowData rowData = new NestListTable.RowData();
			base.Read<int>(reader, ref rowData.NestID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Difficulty, CVSReader.intParse);
			this.columnno = 2;
			this.AddRowNestID(rowData.NestID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
