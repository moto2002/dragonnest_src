using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetItemTable : CVSReader
	{
		public class RowData
		{
			public uint itemid;

			public uint petid;
		}

		public List<PetItemTable.RowData> Table = new List<PetItemTable.RowData>();

		public PetItemTable.RowData GetByitemid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchitemid(key, 0, this.Table.Count - 1);
		}

		private PetItemTable.RowData BinarySearchitemid(uint key, int min, int max)
		{
			PetItemTable.RowData rowData = this.Table[min];
			if (rowData.itemid == key)
			{
				return rowData;
			}
			PetItemTable.RowData rowData2 = this.Table[max];
			if (rowData2.itemid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PetItemTable.RowData rowData3 = this.Table[num];
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

		private void AddRowitemid(uint key, PetItemTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PetItemTable.RowData rowData = this.Table[min];
			if (rowData.itemid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetItemTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PetItemTable.RowData rowData2 = this.Table[max];
			if (rowData2.itemid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetItemTable duplicate id:{0}  lineno: {1}", new object[]
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
			PetItemTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PetItemTable duplicate id:{0}  lineno: {1}", new object[]
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
				"petid"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetItemTable.RowData rowData = new PetItemTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.petid))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetItemTable.RowData rowData = new PetItemTable.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.petid, CVSReader.uintParse);
			this.columnno = 1;
			this.AddRowitemid(rowData.itemid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
