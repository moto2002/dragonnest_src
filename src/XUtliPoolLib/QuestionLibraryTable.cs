using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class QuestionLibraryTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int QAType;

			public string Question;

			public string[] Answer;

			public int TimeLimit;

			public uint[] Point;

			public Seq2ListRef<int> Luck;
		}

		public List<QuestionLibraryTable.RowData> Table = new List<QuestionLibraryTable.RowData>();

		public QuestionLibraryTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private QuestionLibraryTable.RowData BinarySearchID(int key, int min, int max)
		{
			QuestionLibraryTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			QuestionLibraryTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			QuestionLibraryTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(int key, QuestionLibraryTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			QuestionLibraryTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: QuestionLibraryTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			QuestionLibraryTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: QuestionLibraryTable duplicate id:{0}  lineno: {1}", new object[]
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
			QuestionLibraryTable.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: QuestionLibraryTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"QAType",
				"Question",
				"Answer",
				"TimeLimit",
				"Point",
				"Luck"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			QuestionLibraryTable.RowData rowData = new QuestionLibraryTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.QAType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Question))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Answer))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.TimeLimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Point))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.Luck, CVSReader.intParse, "2I"))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			QuestionLibraryTable.RowData rowData = new QuestionLibraryTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.QAType, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Question, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Answer, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.TimeLimit, CVSReader.intParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.Point, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<int>(reader, ref rowData.Luck, CVSReader.intParse);
			this.columnno = 6;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
