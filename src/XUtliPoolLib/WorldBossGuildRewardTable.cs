using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class WorldBossGuildRewardTable : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> Rank;

			public uint Reward;
		}

		public List<WorldBossGuildRewardTable.RowData> Table = new List<WorldBossGuildRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Rank",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			WorldBossGuildRewardTable.RowData rowData = new WorldBossGuildRewardTable.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.Rank, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Reward))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			WorldBossGuildRewardTable.RowData rowData = new WorldBossGuildRewardTable.RowData();
			base.ReadSeq<uint>(reader, ref rowData.Rank, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 1;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
