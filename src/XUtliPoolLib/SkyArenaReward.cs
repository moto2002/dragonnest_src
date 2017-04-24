using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SkyArenaReward : CVSReader
	{
		public class RowData
		{
			public int LevelSegment;

			public int Floor;

			public Seq2ListRef<uint> Reward;
		}

		public List<SkyArenaReward.RowData> Table = new List<SkyArenaReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"LevelSegment",
				"Floor",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SkyArenaReward.RowData rowData = new SkyArenaReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.LevelSegment))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Floor))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SkyArenaReward.RowData rowData = new SkyArenaReward.RowData();
			base.Read<int>(reader, ref rowData.LevelSegment, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Floor, CVSReader.intParse);
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
