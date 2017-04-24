using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PartnerTable : CVSReader
	{
		public class RowData
		{
			public uint level;

			public uint degree;

			public Seq2Ref<int> buf;
		}

		public List<PartnerTable.RowData> Table = new List<PartnerTable.RowData>();

		public PartnerTable.RowData GetBylevel(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchlevel(key, 0, this.Table.Count - 1);
		}

		private PartnerTable.RowData BinarySearchlevel(uint key, int min, int max)
		{
			PartnerTable.RowData rowData = this.Table[min];
			if (rowData.level == key)
			{
				return rowData;
			}
			PartnerTable.RowData rowData2 = this.Table[max];
			if (rowData2.level == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PartnerTable.RowData rowData3 = this.Table[num];
			if (rowData3.level.CompareTo(key) > 0)
			{
				return this.BinarySearchlevel(key, min, num);
			}
			if (rowData3.level.CompareTo(key) < 0)
			{
				return this.BinarySearchlevel(key, num, max);
			}
			return rowData3;
		}

		private void AddRowlevel(uint key, PartnerTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PartnerTable.RowData rowData = this.Table[min];
			if (rowData.level.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PartnerTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PartnerTable.RowData rowData2 = this.Table[max];
			if (rowData2.level.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PartnerTable duplicate id:{0}  lineno: {1}", new object[]
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
			PartnerTable.RowData rowData3 = this.Table[num];
			if (rowData3.level.CompareTo(key) > 0)
			{
				this.AddRowlevel(key, row, min, num);
				return;
			}
			if (rowData3.level.CompareTo(key) < 0)
			{
				this.AddRowlevel(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PartnerTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"level",
				"degree",
				"buf"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PartnerTable.RowData rowData = new PartnerTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.degree))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.buf, CVSReader.intParse, "2I"))
			{
				return false;
			}
			this.AddRowlevel(rowData.level, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeq<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PartnerTable.RowData rowData = new PartnerTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.degree, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<int>(reader, ref rowData.buf, CVSReader.intParse);
			this.columnno = 2;
			this.AddRowlevel(rowData.level, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
