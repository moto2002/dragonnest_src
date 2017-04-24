using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SupplementTable : CVSReader
	{
		public class RowData
		{
			public uint itemid;

			public uint effecttype;

			public uint buffid;

			public uint cooldown;

			public uint islimit;

			public uint bufflevel;

			public Seq2Ref<uint> decompose;
		}

		public List<SupplementTable.RowData> Table = new List<SupplementTable.RowData>();

		public SupplementTable.RowData GetByitemid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchitemid(key, 0, this.Table.Count - 1);
		}

		private SupplementTable.RowData BinarySearchitemid(uint key, int min, int max)
		{
			SupplementTable.RowData rowData = this.Table[min];
			if (rowData.itemid == key)
			{
				return rowData;
			}
			SupplementTable.RowData rowData2 = this.Table[max];
			if (rowData2.itemid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SupplementTable.RowData rowData3 = this.Table[num];
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

		private void AddRowitemid(uint key, SupplementTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SupplementTable.RowData rowData = this.Table[min];
			if (rowData.itemid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SupplementTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SupplementTable.RowData rowData2 = this.Table[max];
			if (rowData2.itemid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.itemid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SupplementTable duplicate id:{0}  lineno: {1}", new object[]
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
			SupplementTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SupplementTable duplicate id:{0}  lineno: {1}", new object[]
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
				"effecttype",
				"buffid",
				"cooldown",
				"islimit",
				"bufflevel",
				"decompose"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SupplementTable.RowData rowData = new SupplementTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.effecttype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.buffid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.cooldown))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.islimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.bufflevel))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.decompose, CVSReader.uintParse, "2U"))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SupplementTable.RowData rowData = new SupplementTable.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.effecttype, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.buffid, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.cooldown, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.islimit, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.bufflevel, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeq<uint>(reader, ref rowData.decompose, CVSReader.uintParse);
			this.columnno = 6;
			this.AddRowitemid(rowData.itemid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
