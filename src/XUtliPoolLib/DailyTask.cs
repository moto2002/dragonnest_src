using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DailyTask : CVSReader
	{
		public class RowData
		{
			public uint taskID;

			public Seq2Ref<uint> level;

			public uint taskquality;

			public uint tasktype;

			public uint[] conditionId;

			public string taskdescription;

			public uint conditionNum;

			public uint NPCID;

			public Seq2ListRef<uint> BQ;
		}

		public List<DailyTask.RowData> Table = new List<DailyTask.RowData>();

		public DailyTask.RowData GetBytaskID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchtaskID(key, 0, this.Table.Count - 1);
		}

		private DailyTask.RowData BinarySearchtaskID(uint key, int min, int max)
		{
			DailyTask.RowData rowData = this.Table[min];
			if (rowData.taskID == key)
			{
				return rowData;
			}
			DailyTask.RowData rowData2 = this.Table[max];
			if (rowData2.taskID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			DailyTask.RowData rowData3 = this.Table[num];
			if (rowData3.taskID.CompareTo(key) > 0)
			{
				return this.BinarySearchtaskID(key, min, num);
			}
			if (rowData3.taskID.CompareTo(key) < 0)
			{
				return this.BinarySearchtaskID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowtaskID(uint key, DailyTask.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			DailyTask.RowData rowData = this.Table[min];
			if (rowData.taskID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.taskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DailyTask duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			DailyTask.RowData rowData2 = this.Table[max];
			if (rowData2.taskID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.taskID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: DailyTask duplicate id:{0}  lineno: {1}", new object[]
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
			DailyTask.RowData rowData3 = this.Table[num];
			if (rowData3.taskID.CompareTo(key) > 0)
			{
				this.AddRowtaskID(key, row, min, num);
				return;
			}
			if (rowData3.taskID.CompareTo(key) < 0)
			{
				this.AddRowtaskID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: DailyTask duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"taskID",
				"level",
				"taskquality",
				"tasktype",
				"conditionId",
				"taskdescription",
				"conditionNum",
				"NPCID",
				"BQ"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DailyTask.RowData rowData = new DailyTask.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.taskID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.level, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.taskquality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.tasktype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.conditionId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.taskdescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.conditionNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.NPCID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.BQ, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowtaskID(rowData.taskID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DailyTask.RowData rowData = new DailyTask.RowData();
			base.Read<uint>(reader, ref rowData.taskID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.taskquality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.conditionId, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.taskdescription, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.conditionNum, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.NPCID, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.BQ, CVSReader.uintParse);
			this.columnno = 8;
			this.AddRowtaskID(rowData.taskID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
