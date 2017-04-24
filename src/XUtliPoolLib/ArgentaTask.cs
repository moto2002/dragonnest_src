using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ArgentaTask : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> LevelRange;

			public uint TaskID;

			public Seq2ListRef<uint> Reward;
		}

		public List<ArgentaTask.RowData> Table = new List<ArgentaTask.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"LevelRange",
				"TaskID",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ArgentaTask.RowData rowData = new ArgentaTask.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.LevelRange, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TaskID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.Reward, CVSReader.uintParse, "2U"))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ArgentaTask.RowData rowData = new ArgentaTask.RowData();
			base.ReadSeq<uint>(reader, ref rowData.LevelRange, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 2;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
