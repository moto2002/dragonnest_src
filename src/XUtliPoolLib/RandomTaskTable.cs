using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class RandomTaskTable : CVSReader
	{
		public class RowData
		{
			public int TaskID;

			public string TaskTitle;

			public string TaskDescription;

			public int TaskCondition;

			public int TaskParam;

			public Seq2ListRef<int> TaskReward;

			public int TaskType;
		}

		public List<RandomTaskTable.RowData> Table = new List<RandomTaskTable.RowData>();

		public RandomTaskTable.RowData GetByTaskID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchTaskID(key, 0, this.Table.Count - 1);
		}

		private RandomTaskTable.RowData BinarySearchTaskID(int key, int min, int max)
		{
			RandomTaskTable.RowData rowData = this.Table[min];
			if (rowData.TaskID == key)
			{
				return rowData;
			}
			RandomTaskTable.RowData rowData2 = this.Table[max];
			if (rowData2.TaskID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			RandomTaskTable.RowData rowData3 = this.Table[num];
			if (rowData3.TaskID.CompareTo(key) > 0)
			{
				return this.BinarySearchTaskID(key, min, num);
			}
			if (rowData3.TaskID.CompareTo(key) < 0)
			{
				return this.BinarySearchTaskID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowTaskID(int key, RandomTaskTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			RandomTaskTable.RowData rowData = this.Table[min];
			if (rowData.TaskID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.TaskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: RandomTaskTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			RandomTaskTable.RowData rowData2 = this.Table[max];
			if (rowData2.TaskID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.TaskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: RandomTaskTable duplicate id:{0}  lineno: {1}", new object[]
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
			RandomTaskTable.RowData rowData3 = this.Table[num];
			if (rowData3.TaskID.CompareTo(key) > 0)
			{
				this.AddRowTaskID(key, row, min, num);
				return;
			}
			if (rowData3.TaskID.CompareTo(key) < 0)
			{
				this.AddRowTaskID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: RandomTaskTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"TaskID",
				"TaskTitle",
				"TaskDescription",
				"TaskCondition",
				"TaskParam",
				"TaskReward",
				"TaskType"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			RandomTaskTable.RowData rowData = new RandomTaskTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TaskID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TaskTitle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TaskDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TaskCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.TaskParam))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[5]], ref rowData.TaskReward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.TaskType))
			{
				return false;
			}
			this.AddRowTaskID(rowData.TaskID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			RandomTaskTable.RowData rowData = new RandomTaskTable.RowData();
			base.Read<int>(reader, ref rowData.TaskID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TaskTitle, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TaskDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.TaskCondition, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.TaskParam, CVSReader.intParse);
			this.columnno = 4;
			base.ReadSeqList<int>(reader, ref rowData.TaskReward, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.TaskType, CVSReader.intParse);
			this.columnno = 6;
			this.AddRowTaskID(rowData.TaskID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
