using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FpStrengthNew : CVSReader
	{
		public class RowData
		{
			public int BQID;

			public int Bqtype;

			public int BQSystem;

			public string BQTips;

			public string BQImageID;

			public string BQName;

			public int ShowLevel;

			public int StarNum;
		}

		public List<FpStrengthNew.RowData> Table = new List<FpStrengthNew.RowData>();

		public FpStrengthNew.RowData GetByBQID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchBQID(key, 0, this.Table.Count - 1);
		}

		private FpStrengthNew.RowData BinarySearchBQID(int key, int min, int max)
		{
			FpStrengthNew.RowData rowData = this.Table[min];
			if (rowData.BQID == key)
			{
				return rowData;
			}
			FpStrengthNew.RowData rowData2 = this.Table[max];
			if (rowData2.BQID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FpStrengthNew.RowData rowData3 = this.Table[num];
			if (rowData3.BQID.CompareTo(key) > 0)
			{
				return this.BinarySearchBQID(key, min, num);
			}
			if (rowData3.BQID.CompareTo(key) < 0)
			{
				return this.BinarySearchBQID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowBQID(int key, FpStrengthNew.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FpStrengthNew.RowData rowData = this.Table[min];
			if (rowData.BQID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.BQID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FpStrengthNew duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FpStrengthNew.RowData rowData2 = this.Table[max];
			if (rowData2.BQID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.BQID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FpStrengthNew duplicate id:{0}  lineno: {1}", new object[]
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
			FpStrengthNew.RowData rowData3 = this.Table[num];
			if (rowData3.BQID.CompareTo(key) > 0)
			{
				this.AddRowBQID(key, row, min, num);
				return;
			}
			if (rowData3.BQID.CompareTo(key) < 0)
			{
				this.AddRowBQID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FpStrengthNew duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BQID",
				"Bqtype",
				"BQSystem",
				"BQTips",
				"BQImageID",
				"BQName",
				"ShowLevel",
				"StarNum"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FpStrengthNew.RowData rowData = new FpStrengthNew.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BQID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Bqtype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.BQSystem))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.BQTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.BQImageID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BQName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.ShowLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.StarNum))
			{
				return false;
			}
			this.AddRowBQID(rowData.BQID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FpStrengthNew.RowData rowData = new FpStrengthNew.RowData();
			base.Read<int>(reader, ref rowData.BQID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Bqtype, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.BQSystem, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.BQTips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.BQImageID, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BQName, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.StarNum, CVSReader.intParse);
			this.columnno = 7;
			this.AddRowBQID(rowData.BQID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
