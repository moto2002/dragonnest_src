using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SpriteEvolution : CVSReader
	{
		public class RowData
		{
			public uint SpriteID;

			public uint Quality;

			public uint EvolutionLevel;

			public uint LevelLimit;

			public Seq2Ref<uint> EvolutionCost;

			public Seq2Ref<uint> TrainExp;

			public Seq2Ref<uint> ResetTrainCost;

			public Seq2ListRef<uint> AddAttr;

			public Seq2ListRef<uint> AttrExtra;

			public Seq3ListRef<uint> TrainAttr;
		}

		public List<SpriteEvolution.RowData> Table = new List<SpriteEvolution.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SpriteID",
				"Quality",
				"EvolutionLevel",
				"LevelLimit",
				"EvolutionCost",
				"TrainExp",
				"ResetTrainCost",
				"AddAttr",
				"AttrExtra",
				"TrainAttr"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SpriteEvolution.RowData rowData = new SpriteEvolution.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SpriteID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.EvolutionLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.LevelLimit))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.EvolutionCost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.TrainExp, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.ResetTrainCost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.AddAttr, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.AttrExtra, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[9]], ref rowData.TrainAttr, CVSReader.uintParse, "3U"))
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse, 3, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SpriteEvolution.RowData rowData = new SpriteEvolution.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.EvolutionLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.LevelLimit, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeq<uint>(reader, ref rowData.EvolutionCost, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeq<uint>(reader, ref rowData.TrainExp, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeq<uint>(reader, ref rowData.ResetTrainCost, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.AddAttr, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.AttrExtra, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadSeqList<uint>(reader, ref rowData.TrainAttr, CVSReader.uintParse);
			this.columnno = 9;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
