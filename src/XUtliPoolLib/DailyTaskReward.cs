using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DailyTaskReward : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> level;

			public uint tasktype;

			public uint taskquality;

			public Seq2ListRef<uint> taskreward;

			public uint contribute;

			public Seq2ListRef<uint> extrareward;
		}

		public List<DailyTaskReward.RowData> Table = new List<DailyTaskReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"level",
				"tasktype",
				"taskquality",
				"taskreward",
				"contribute",
				"extrareward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DailyTaskReward.RowData rowData = new DailyTaskReward.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.level, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.tasktype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.taskquality))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.taskreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.contribute))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.extrareward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.Table.Add(rowData);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.WriteSeq<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DailyTaskReward.RowData rowData = new DailyTaskReward.RowData();
			base.ReadSeq<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.taskquality, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.taskreward, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.contribute, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.extrareward, CVSReader.uintParse);
			this.columnno = 5;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
