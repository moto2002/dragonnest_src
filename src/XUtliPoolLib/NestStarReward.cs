using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class NestStarReward : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public uint Stars;

			public uint IsHadTittle;

			public string Tittle;

			public Seq2ListRef<uint> Reward;
		}

		public List<NestStarReward.RowData> Table = new List<NestStarReward.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"Stars",
				"IsHadTittle",
				"Tittle",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			NestStarReward.RowData rowData = new NestStarReward.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Stars))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.IsHadTittle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Tittle))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.Reward, CVSReader.uintParse, "2U"))
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
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			NestStarReward.RowData rowData = new NestStarReward.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Stars, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.IsHadTittle, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tittle, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 4;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
