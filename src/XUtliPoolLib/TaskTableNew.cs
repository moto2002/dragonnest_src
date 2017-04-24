using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class TaskTableNew : CVSReader
	{
		public class RowData
		{
			public uint TaskType;

			public uint TaskID;

			public uint PreTaskID;

			public uint[] TaskTime;

			public uint[] EndTime;

			public uint[] BeginTaskNPCID;

			public uint[] EndTaskNPCID;

			public uint RequiredLevel;

			public string TaskTitle;

			public string TaskDesc;

			public string InprocessDesc;

			public Seq2ListRef<uint> PassScene;

			public Seq2ListRef<uint> TaskScene;

			public Seq2ListRef<uint> TaskItem;

			public Seq2ListRef<uint> TaskMonster;

			public Seq2ListRef<uint> RewardItem;

			public string BeginDesc;

			public string EndDesc;

			public uint[] MailID;
		}

		public List<TaskTableNew.RowData> Table = new List<TaskTableNew.RowData>();

		public TaskTableNew.RowData GetByTaskID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchTaskID(key, 0, this.Table.Count - 1);
		}

		private TaskTableNew.RowData BinarySearchTaskID(uint key, int min, int max)
		{
			TaskTableNew.RowData rowData = this.Table[min];
			if (rowData.TaskID == key)
			{
				return rowData;
			}
			TaskTableNew.RowData rowData2 = this.Table[max];
			if (rowData2.TaskID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			TaskTableNew.RowData rowData3 = this.Table[num];
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

		private void AddRowTaskID(uint key, TaskTableNew.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			TaskTableNew.RowData rowData = this.Table[min];
			if (rowData.TaskID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.TaskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: TaskTableNew duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			TaskTableNew.RowData rowData2 = this.Table[max];
			if (rowData2.TaskID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.TaskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: TaskTableNew duplicate id:{0}  lineno: {1}", new object[]
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
			TaskTableNew.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: TaskTableNew duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"TaskType",
				"TaskID",
				"PreTaskID",
				"TaskTime",
				"EndTime",
				"BeginTaskNPCID",
				"EndTaskNPCID",
				"RequiredLevel",
				"TaskTitle",
				"TaskDesc",
				"InprocessDesc",
				"PassScene",
				"TaskScene",
				"TaskItem",
				"TaskMonster",
				"RewardItem",
				"BeginDesc",
				"EndDesc",
				"MailID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			TaskTableNew.RowData rowData = new TaskTableNew.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TaskType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TaskID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.PreTaskID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TaskTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.EndTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BeginTaskNPCID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.EndTaskNPCID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.RequiredLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.TaskTitle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.TaskDesc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.InprocessDesc))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[11]], ref rowData.PassScene, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[12]], ref rowData.TaskScene, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[13]], ref rowData.TaskItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[14]], ref rowData.TaskMonster, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[15]], ref rowData.RewardItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.BeginDesc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.EndDesc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.MailID))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[16]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[17]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			TaskTableNew.RowData rowData = new TaskTableNew.RowData();
			base.Read<uint>(reader, ref rowData.TaskType, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.PreTaskID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.TaskTime, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.EndTime, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.BeginTaskNPCID, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.EndTaskNPCID, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.RequiredLevel, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.TaskTitle, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.TaskDesc, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.InprocessDesc, CVSReader.stringParse);
			this.columnno = 10;
			base.ReadSeqList<uint>(reader, ref rowData.PassScene, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadSeqList<uint>(reader, ref rowData.TaskScene, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeqList<uint>(reader, ref rowData.TaskItem, CVSReader.uintParse);
			this.columnno = 13;
			base.ReadSeqList<uint>(reader, ref rowData.TaskMonster, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeqList<uint>(reader, ref rowData.RewardItem, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.BeginDesc, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.EndDesc, CVSReader.stringParse);
			this.columnno = 17;
			base.ReadArray<uint>(reader, ref rowData.MailID, CVSReader.uintParse);
			this.columnno = 18;
			this.AddRowTaskID(rowData.TaskID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
