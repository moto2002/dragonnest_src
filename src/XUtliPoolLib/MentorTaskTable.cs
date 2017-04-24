using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class MentorTaskTable : CVSReader
	{
		public class RowData
		{
			public uint TaskID;

			public uint TaskType;

			public string TaskName;

			public Seq2Ref<int> TaskVar;

			public Seq2ListRef<int> MasterReward;

			public Seq2ListRef<int> StudentReward;
		}

		public List<MentorTaskTable.RowData> Table = new List<MentorTaskTable.RowData>();

		public MentorTaskTable.RowData GetByTaskID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchTaskID(key, 0, this.Table.Count - 1);
		}

		private MentorTaskTable.RowData BinarySearchTaskID(uint key, int min, int max)
		{
			MentorTaskTable.RowData rowData = this.Table[min];
			if (rowData.TaskID == key)
			{
				return rowData;
			}
			MentorTaskTable.RowData rowData2 = this.Table[max];
			if (rowData2.TaskID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			MentorTaskTable.RowData rowData3 = this.Table[num];
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

		private void AddRowTaskID(uint key, MentorTaskTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			MentorTaskTable.RowData rowData = this.Table[min];
			if (rowData.TaskID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.TaskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: MentorTaskTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			MentorTaskTable.RowData rowData2 = this.Table[max];
			if (rowData2.TaskID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.TaskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: MentorTaskTable duplicate id:{0}  lineno: {1}", new object[]
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
			MentorTaskTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: MentorTaskTable duplicate id:{0}  lineno: {1}", new object[]
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
				"TaskType",
				"TaskName",
				"TaskVar",
				"MasterReward",
				"StudentReward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			MentorTaskTable.RowData rowData = new MentorTaskTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TaskID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TaskType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TaskName))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[3]], ref rowData.TaskVar, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[4]], ref rowData.MasterReward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[5]], ref rowData.StudentReward, CVSReader.intParse, "2I"))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			MentorTaskTable.RowData rowData = new MentorTaskTable.RowData();
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TaskName, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadSeq<int>(reader, ref rowData.TaskVar, CVSReader.intParse);
			this.columnno = 3;
			base.ReadSeqList<int>(reader, ref rowData.MasterReward, CVSReader.intParse);
			this.columnno = 4;
			base.ReadSeqList<int>(reader, ref rowData.StudentReward, CVSReader.intParse);
			this.columnno = 5;
			this.AddRowTaskID(rowData.TaskID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
