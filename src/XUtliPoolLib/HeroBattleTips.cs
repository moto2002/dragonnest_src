using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class HeroBattleTips : CVSReader
	{
		public class RowData
		{
			public uint id;

			public string tips;
		}

		public List<HeroBattleTips.RowData> Table = new List<HeroBattleTips.RowData>();

		public HeroBattleTips.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private HeroBattleTips.RowData BinarySearchid(uint key, int min, int max)
		{
			HeroBattleTips.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			HeroBattleTips.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			HeroBattleTips.RowData rowData3 = this.Table[num];
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

		private void AddRowid(uint key, HeroBattleTips.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			HeroBattleTips.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: HeroBattleTips duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			HeroBattleTips.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: HeroBattleTips duplicate id:{0}  lineno: {1}", new object[]
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
			HeroBattleTips.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: HeroBattleTips duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"tips"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			HeroBattleTips.RowData rowData = new HeroBattleTips.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.tips))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			HeroBattleTips.RowData rowData = new HeroBattleTips.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
			this.columnno = 1;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
