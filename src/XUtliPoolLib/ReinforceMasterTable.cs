using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ReinforceMasterTable : CVSReader
	{
		public class RowData
		{
			public uint ReinforceMasterLv;

			public Seq2ListRef<uint> ReinforceMasterAttr;
		}

		public List<ReinforceMasterTable.RowData> Table = new List<ReinforceMasterTable.RowData>();

		public ReinforceMasterTable.RowData GetByReinforceMasterLv(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchReinforceMasterLv(key, 0, this.Table.Count - 1);
		}

		private ReinforceMasterTable.RowData BinarySearchReinforceMasterLv(uint key, int min, int max)
		{
			ReinforceMasterTable.RowData rowData = this.Table[min];
			if (rowData.ReinforceMasterLv == key)
			{
				return rowData;
			}
			ReinforceMasterTable.RowData rowData2 = this.Table[max];
			if (rowData2.ReinforceMasterLv == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ReinforceMasterTable.RowData rowData3 = this.Table[num];
			if (rowData3.ReinforceMasterLv.CompareTo(key) > 0)
			{
				return this.BinarySearchReinforceMasterLv(key, min, num);
			}
			if (rowData3.ReinforceMasterLv.CompareTo(key) < 0)
			{
				return this.BinarySearchReinforceMasterLv(key, num, max);
			}
			return rowData3;
		}

		private void AddRowReinforceMasterLv(uint key, ReinforceMasterTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ReinforceMasterTable.RowData rowData = this.Table[min];
			if (rowData.ReinforceMasterLv.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ReinforceMasterLv == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ReinforceMasterTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ReinforceMasterTable.RowData rowData2 = this.Table[max];
			if (rowData2.ReinforceMasterLv.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ReinforceMasterLv == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ReinforceMasterTable duplicate id:{0}  lineno: {1}", new object[]
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
			ReinforceMasterTable.RowData rowData3 = this.Table[num];
			if (rowData3.ReinforceMasterLv.CompareTo(key) > 0)
			{
				this.AddRowReinforceMasterLv(key, row, min, num);
				return;
			}
			if (rowData3.ReinforceMasterLv.CompareTo(key) < 0)
			{
				this.AddRowReinforceMasterLv(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ReinforceMasterTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ReinforceMasterLv",
				"ReinforceMasterAttr"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ReinforceMasterTable.RowData rowData = new ReinforceMasterTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ReinforceMasterLv))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.ReinforceMasterAttr, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowReinforceMasterLv(rowData.ReinforceMasterLv, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ReinforceMasterTable.RowData rowData = new ReinforceMasterTable.RowData();
			base.Read<uint>(reader, ref rowData.ReinforceMasterLv, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.ReinforceMasterAttr, CVSReader.uintParse);
			this.columnno = 1;
			this.AddRowReinforceMasterLv(rowData.ReinforceMasterLv, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
