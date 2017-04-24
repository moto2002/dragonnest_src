using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class NestWeekList : CVSReader
	{
		public class RowData
		{
			public int SealType;

			public int[] ExpID;

			public int WeekCount;
		}

		public List<NestWeekList.RowData> Table = new List<NestWeekList.RowData>();

		public NestWeekList.RowData GetBySealType(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSealType(key, 0, this.Table.Count - 1);
		}

		private NestWeekList.RowData BinarySearchSealType(int key, int min, int max)
		{
			NestWeekList.RowData rowData = this.Table[min];
			if (rowData.SealType == key)
			{
				return rowData;
			}
			NestWeekList.RowData rowData2 = this.Table[max];
			if (rowData2.SealType == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			NestWeekList.RowData rowData3 = this.Table[num];
			if (rowData3.SealType.CompareTo(key) > 0)
			{
				return this.BinarySearchSealType(key, min, num);
			}
			if (rowData3.SealType.CompareTo(key) < 0)
			{
				return this.BinarySearchSealType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSealType(int key, NestWeekList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			NestWeekList.RowData rowData = this.Table[min];
			if (rowData.SealType.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SealType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestWeekList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			NestWeekList.RowData rowData2 = this.Table[max];
			if (rowData2.SealType.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SealType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestWeekList duplicate id:{0}  lineno: {1}", new object[]
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
			NestWeekList.RowData rowData3 = this.Table[num];
			if (rowData3.SealType.CompareTo(key) > 0)
			{
				this.AddRowSealType(key, row, min, num);
				return;
			}
			if (rowData3.SealType.CompareTo(key) < 0)
			{
				this.AddRowSealType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: NestWeekList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SealType",
				"ExpID",
				"WeekCount"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			NestWeekList.RowData rowData = new NestWeekList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SealType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ExpID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.WeekCount))
			{
				return false;
			}
			this.AddRowSealType(rowData.SealType, rowData, 0, this.Table.Count - 1);
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			NestWeekList.RowData rowData = new NestWeekList.RowData();
			base.Read<int>(reader, ref rowData.SealType, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.ExpID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.WeekCount, CVSReader.intParse);
			this.columnno = 2;
			this.AddRowSealType(rowData.SealType, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
