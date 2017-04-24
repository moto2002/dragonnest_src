using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class HeroBattleMatch : CVSReader
	{
		public class RowData
		{
			public Seq2Ref<uint> PointBlock;

			public uint ExpandTime;

			public uint SearchTime;
		}

		public List<HeroBattleMatch.RowData> Table = new List<HeroBattleMatch.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"PointBlock",
				"ExpandTime",
				"SearchTime"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			HeroBattleMatch.RowData rowData = new HeroBattleMatch.RowData();
			if (!base.Parse<uint>(Fields[this.ColMap[0]], ref rowData.PointBlock, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ExpandTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SearchTime))
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			HeroBattleMatch.RowData rowData = new HeroBattleMatch.RowData();
			base.ReadSeq<uint>(reader, ref rowData.PointBlock, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ExpandTime, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SearchTime, CVSReader.uintParse);
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
