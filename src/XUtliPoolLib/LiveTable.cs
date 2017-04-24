using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class LiveTable : CVSReader
	{
		public class RowData
		{
			public int Type;

			public string Name;

			public int DNExpType;

			public int SceneType;

			public int TimeSpan;

			public int LiveNum;

			public int MaxWatchNum;

			public int ShowWatch;

			public int ShowPraise;

			public int NoticeWatchNum;

			public int Page;
		}

		public List<LiveTable.RowData> Table = new List<LiveTable.RowData>();

		public LiveTable.RowData GetBySceneType(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSceneType(key, 0, this.Table.Count - 1);
		}

		private LiveTable.RowData BinarySearchSceneType(int key, int min, int max)
		{
			LiveTable.RowData rowData = this.Table[min];
			if (rowData.SceneType == key)
			{
				return rowData;
			}
			LiveTable.RowData rowData2 = this.Table[max];
			if (rowData2.SceneType == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			LiveTable.RowData rowData3 = this.Table[num];
			if (rowData3.SceneType.CompareTo(key) > 0)
			{
				return this.BinarySearchSceneType(key, min, num);
			}
			if (rowData3.SceneType.CompareTo(key) < 0)
			{
				return this.BinarySearchSceneType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSceneType(int key, LiveTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			LiveTable.RowData rowData = this.Table[min];
			if (rowData.SceneType.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SceneType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: LiveTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			LiveTable.RowData rowData2 = this.Table[max];
			if (rowData2.SceneType.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SceneType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: LiveTable duplicate id:{0}  lineno: {1}", new object[]
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
			LiveTable.RowData rowData3 = this.Table[num];
			if (rowData3.SceneType.CompareTo(key) > 0)
			{
				this.AddRowSceneType(key, row, min, num);
				return;
			}
			if (rowData3.SceneType.CompareTo(key) < 0)
			{
				this.AddRowSceneType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: LiveTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"Name",
				"DNExpType",
				"SceneType",
				"TimeSpan",
				"LiveNum",
				"MaxWatchNum",
				"ShowWatch",
				"ShowPraise",
				"NoticeWatchNum",
				"Page"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			LiveTable.RowData rowData = new LiveTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.DNExpType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SceneType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.TimeSpan))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.LiveNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MaxWatchNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.ShowWatch))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.ShowPraise))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.NoticeWatchNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Page))
			{
				return false;
			}
			this.AddRowSceneType(rowData.SceneType, rowData, 0, this.Table.Count - 1);
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
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			LiveTable.RowData rowData = new LiveTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.DNExpType, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.TimeSpan, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.LiveNum, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.MaxWatchNum, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.ShowWatch, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.ShowPraise, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.NoticeWatchNum, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.Page, CVSReader.intParse);
			this.columnno = 10;
			this.AddRowSceneType(rowData.SceneType, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
