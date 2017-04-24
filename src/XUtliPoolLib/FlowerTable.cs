using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FlowerTable : CVSReader
	{
		public class RowData
		{
			public uint count;

			public Seq2Ref<uint> cost;

			public Seq2ListRef<uint> reward;
		}

		public List<FlowerTable.RowData> Table = new List<FlowerTable.RowData>();

		public FlowerTable.RowData GetBycount(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchcount(key, 0, this.Table.Count - 1);
		}

		private FlowerTable.RowData BinarySearchcount(uint key, int min, int max)
		{
			FlowerTable.RowData rowData = this.Table[min];
			if (rowData.count == key)
			{
				return rowData;
			}
			FlowerTable.RowData rowData2 = this.Table[max];
			if (rowData2.count == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FlowerTable.RowData rowData3 = this.Table[num];
			if (rowData3.count.CompareTo(key) > 0)
			{
				return this.BinarySearchcount(key, min, num);
			}
			if (rowData3.count.CompareTo(key) < 0)
			{
				return this.BinarySearchcount(key, num, max);
			}
			return rowData3;
		}

		private void AddRowcount(uint key, FlowerTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FlowerTable.RowData rowData = this.Table[min];
			if (rowData.count.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.count == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FlowerTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FlowerTable.RowData rowData2 = this.Table[max];
			if (rowData2.count.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.count == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FlowerTable duplicate id:{0}  lineno: {1}", new object[]
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
			FlowerTable.RowData rowData3 = this.Table[num];
			if (rowData3.count.CompareTo(key) > 0)
			{
				this.AddRowcount(key, row, min, num);
				return;
			}
			if (rowData3.count.CompareTo(key) < 0)
			{
				this.AddRowcount(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FlowerTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"count",
				"cost",
				"reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FlowerTable.RowData rowData = new FlowerTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.count))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.cost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowcount(rowData.count, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FlowerTable.RowData rowData = new FlowerTable.RowData();
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.cost, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			this.AddRowcount(rowData.count, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
