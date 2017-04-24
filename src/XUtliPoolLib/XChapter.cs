using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XChapter : CVSReader
	{
		public class RowData
		{
			public int ChapterID;

			public string Comment;

			public int Reward1;

			public int Reward2;

			public int Reward3;

			public int Type;

			public string Pic;

			public int PreChapter;

			public Seq2ListRef<int> Drop;

			public Seq2Ref<int> Difficult;

			public int BossID;
		}

		public List<XChapter.RowData> Table = new List<XChapter.RowData>();

		public XChapter.RowData GetByChapterID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchChapterID(key, 0, this.Table.Count - 1);
		}

		private XChapter.RowData BinarySearchChapterID(int key, int min, int max)
		{
			XChapter.RowData rowData = this.Table[min];
			if (rowData.ChapterID == key)
			{
				return rowData;
			}
			XChapter.RowData rowData2 = this.Table[max];
			if (rowData2.ChapterID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XChapter.RowData rowData3 = this.Table[num];
			if (rowData3.ChapterID.CompareTo(key) > 0)
			{
				return this.BinarySearchChapterID(key, min, num);
			}
			if (rowData3.ChapterID.CompareTo(key) < 0)
			{
				return this.BinarySearchChapterID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowChapterID(int key, XChapter.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XChapter.RowData rowData = this.Table[min];
			if (rowData.ChapterID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ChapterID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XChapter duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XChapter.RowData rowData2 = this.Table[max];
			if (rowData2.ChapterID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ChapterID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XChapter duplicate id:{0}  lineno: {1}", new object[]
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
			XChapter.RowData rowData3 = this.Table[num];
			if (rowData3.ChapterID.CompareTo(key) > 0)
			{
				this.AddRowChapterID(key, row, min, num);
				return;
			}
			if (rowData3.ChapterID.CompareTo(key) < 0)
			{
				this.AddRowChapterID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XChapter duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ChapterID",
				"Comment",
				"Reward1",
				"Reward2",
				"Reward3",
				"Type",
				"Pic",
				"PreChapter",
				"Drop",
				"Difficult",
				"BossID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XChapter.RowData rowData = new XChapter.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ChapterID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Comment))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Reward1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Reward2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Reward3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Pic))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.PreChapter))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[8]], ref rowData.Drop, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[9]], ref rowData.Difficult, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.BossID))
			{
				return false;
			}
			this.AddRowChapterID(rowData.ChapterID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse, 2, "I");
			base.WriteSeq<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XChapter.RowData rowData = new XChapter.RowData();
			base.Read<int>(reader, ref rowData.ChapterID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Reward1, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Reward2, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Reward3, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Pic, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.PreChapter, CVSReader.intParse);
			this.columnno = 7;
			base.ReadSeqList<int>(reader, ref rowData.Drop, CVSReader.intParse);
			this.columnno = 8;
			base.ReadSeq<int>(reader, ref rowData.Difficult, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.BossID, CVSReader.intParse);
			this.columnno = 10;
			this.AddRowChapterID(rowData.ChapterID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
