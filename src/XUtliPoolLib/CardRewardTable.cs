using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CardRewardTable : CVSReader
	{
		public class RowData
		{
			public uint type;

			public Seq2ListRef<uint> reward;

			public bool packet;

			public uint exp;

			public uint point;

			public Seq2ListRef<uint> matchreward;

			public Seq2ListRef<uint> jokerreward;
		}

		public List<CardRewardTable.RowData> Table = new List<CardRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"type",
				"reward",
				"packet",
				"exp",
				"point",
				"matchreward",
				"jokerreward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CardRewardTable.RowData rowData = new CardRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.packet))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.exp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.point))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.matchreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.jokerreward, CVSReader.uintParse, "2U"))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[2]]);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CardRewardTable.RowData rowData = new CardRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			base.Read(reader, ref rowData.packet);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.exp, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.point, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.matchreward, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.jokerreward, CVSReader.uintParse);
			this.columnno = 6;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
