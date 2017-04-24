using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PkOpenTable : CVSReader
	{
		public class RowData
		{
			public Seq3Ref<uint> date;

			public Seq3Ref<uint> timebegin;

			public Seq3Ref<uint> timeend;

			public uint id;
		}

		public List<PkOpenTable.RowData> Table = new List<PkOpenTable.RowData>();

		public PkOpenTable.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private PkOpenTable.RowData BinarySearchid(uint key, int min, int max)
		{
			PkOpenTable.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			PkOpenTable.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PkOpenTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				return this.BinarySearchid(key, min, num);
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				return this.BinarySearchid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowid(uint key, PkOpenTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PkOpenTable.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PkOpenTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PkOpenTable.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PkOpenTable duplicate id:{0}  lineno: {1}", new object[]
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
			PkOpenTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				this.AddRowid(key, row, min, num);
				return;
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				this.AddRowid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PkOpenTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"date",
				"timebegin",
				"timeend",
				"id"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PkOpenTable.RowData rowData = new PkOpenTable.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.date, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.timebegin, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.timeend, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.id))
			{
				return false;
			}
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.WriteSeq<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse, 3, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 3, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 3, "U");
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PkOpenTable.RowData rowData = new PkOpenTable.RowData();
			base.ReadSeq<uint>(reader, ref rowData.date, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.timebegin, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<uint>(reader, ref rowData.timeend, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 3;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
