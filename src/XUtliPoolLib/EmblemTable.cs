using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EmblemTable : CVSReader
	{
		public class RowData
		{
			public uint EmblemID;

			public Seq2ListRef<uint> EmblemAttribute;

			public uint ExpOutput;
		}

		public List<EmblemTable.RowData> Table = new List<EmblemTable.RowData>();

		public EmblemTable.RowData GetByEmblemID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchEmblemID(key, 0, this.Table.Count - 1);
		}

		private EmblemTable.RowData BinarySearchEmblemID(uint key, int min, int max)
		{
			EmblemTable.RowData rowData = this.Table[min];
			if (rowData.EmblemID == key)
			{
				return rowData;
			}
			EmblemTable.RowData rowData2 = this.Table[max];
			if (rowData2.EmblemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			EmblemTable.RowData rowData3 = this.Table[num];
			if (rowData3.EmblemID.CompareTo(key) > 0)
			{
				return this.BinarySearchEmblemID(key, min, num);
			}
			if (rowData3.EmblemID.CompareTo(key) < 0)
			{
				return this.BinarySearchEmblemID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowEmblemID(uint key, EmblemTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			EmblemTable.RowData rowData = this.Table[min];
			if (rowData.EmblemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.EmblemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EmblemTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			EmblemTable.RowData rowData2 = this.Table[max];
			if (rowData2.EmblemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.EmblemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EmblemTable duplicate id:{0}  lineno: {1}", new object[]
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
			EmblemTable.RowData rowData3 = this.Table[num];
			if (rowData3.EmblemID.CompareTo(key) > 0)
			{
				this.AddRowEmblemID(key, row, min, num);
				return;
			}
			if (rowData3.EmblemID.CompareTo(key) < 0)
			{
				this.AddRowEmblemID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: EmblemTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EmblemID",
				"EmblemAttribute",
				"ExpOutput"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EmblemTable.RowData rowData = new EmblemTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EmblemID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.EmblemAttribute, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ExpOutput))
			{
				return false;
			}
			this.AddRowEmblemID(rowData.EmblemID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EmblemTable.RowData rowData = new EmblemTable.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.EmblemAttribute, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ExpOutput, CVSReader.uintParse);
			this.columnno = 2;
			this.AddRowEmblemID(rowData.EmblemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
