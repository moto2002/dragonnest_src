using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class WorldBossRewardTable : CVSReader
	{
		public class RowData
		{
			public int Level;

			public Seq2Ref<uint> Rank;

			public Seq2ListRef<uint> ShowReward;
		}

		public List<WorldBossRewardTable.RowData> Table = new List<WorldBossRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Level",
				"Rank",
				"ShowReward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			WorldBossRewardTable.RowData rowData = new WorldBossRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Rank, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.ShowReward, CVSReader.uintParse, "2U"))
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			WorldBossRewardTable.RowData rowData = new WorldBossRewardTable.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.Rank, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.ShowReward, CVSReader.uintParse);
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
