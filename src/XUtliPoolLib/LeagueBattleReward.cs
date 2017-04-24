using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class LeagueBattleReward : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int type;

			public Seq2ListRef<uint> reward;

			public uint mailid;
		}

		public List<LeagueBattleReward.RowData> Table = new List<LeagueBattleReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"type",
				"reward",
				"mailid"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			LeagueBattleReward.RowData rowData = new LeagueBattleReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.mailid))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			LeagueBattleReward.RowData rowData = new LeagueBattleReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.mailid, CVSReader.uintParse);
			this.columnno = 3;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
