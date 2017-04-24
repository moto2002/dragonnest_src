using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class StageRankTable : CVSReader
	{
		public class RowData
		{
			public uint scendid;

			public Seq3Ref<uint> star2;

			public Seq3Ref<uint> star3;
		}

		public List<StageRankTable.RowData> Table = new List<StageRankTable.RowData>();

		public StageRankTable.RowData GetByscendid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchscendid(key, 0, this.Table.Count - 1);
		}

		private StageRankTable.RowData BinarySearchscendid(uint key, int min, int max)
		{
			StageRankTable.RowData rowData = this.Table[min];
			if (rowData.scendid == key)
			{
				return rowData;
			}
			StageRankTable.RowData rowData2 = this.Table[max];
			if (rowData2.scendid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			StageRankTable.RowData rowData3 = this.Table[num];
			if (rowData3.scendid.CompareTo(key) > 0)
			{
				return this.BinarySearchscendid(key, min, num);
			}
			if (rowData3.scendid.CompareTo(key) < 0)
			{
				return this.BinarySearchscendid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowscendid(uint key, StageRankTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			StageRankTable.RowData rowData = this.Table[min];
			if (rowData.scendid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.scendid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: StageRankTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			StageRankTable.RowData rowData2 = this.Table[max];
			if (rowData2.scendid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.scendid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: StageRankTable duplicate id:{0}  lineno: {1}", new object[]
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
			StageRankTable.RowData rowData3 = this.Table[num];
			if (rowData3.scendid.CompareTo(key) > 0)
			{
				this.AddRowscendid(key, row, min, num);
				return;
			}
			if (rowData3.scendid.CompareTo(key) < 0)
			{
				this.AddRowscendid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: StageRankTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"scendid",
				"star2",
				"star3"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			StageRankTable.RowData rowData = new StageRankTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.scendid))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.star2, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.star3, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			this.AddRowscendid(rowData.scendid, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 3, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 3, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			StageRankTable.RowData rowData = new StageRankTable.RowData();
			base.Read<uint>(reader, ref rowData.scendid, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.star2, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<uint>(reader, ref rowData.star3, CVSReader.uintParse);
			this.columnno = 2;
			this.AddRowscendid(rowData.scendid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
