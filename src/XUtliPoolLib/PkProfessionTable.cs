using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PkProfessionTable : CVSReader
	{
		public class RowData
		{
			public int Profession;

			public string Name;

			public double PhysicalAtk;

			public double PhysicalDef;

			public double MaxHP;

			public double HPRecovery;

			public double MagicAtk;

			public double MagicDef;

			public double MaxMP;

			public double MPRecovery;

			public double Critical;

			public double CritResist;

			public uint Level;

			public int[] SceneType;

			public Seq2Ref<uint> SealRange;

			public Seq2ListRef<double> AttrValue_s;
		}

		public List<PkProfessionTable.RowData> Table = new List<PkProfessionTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Profession",
				"Name",
				"PhysicalAtk",
				"PhysicalDef",
				"MaxHP",
				"HPRecovery",
				"MagicAtk",
				"MagicDef",
				"MaxMP",
				"MPRecovery",
				"Critical",
				"CritResist",
				"Level",
				"SceneType",
				"SealRange",
				"AttrValue_s"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PkProfessionTable.RowData rowData = new PkProfessionTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Profession))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.PhysicalAtk))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PhysicalDef))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.MaxHP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.HPRecovery))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MagicAtk))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.MagicDef))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.MaxMP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.MPRecovery))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Critical))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.CritResist))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.SceneType))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[14]], ref rowData.SealRange, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<double>(Fields[this.ColMap[15]], ref rowData.AttrValue_s, CVSReader.doubleParse, "2D"))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<double>(writer, Fields[this.ColMap[2]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[3]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[4]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[5]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[6]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[7]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[8]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[9]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[10]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[11]], CVSReader.doubleParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[13]], CVSReader.intParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<double>(writer, Fields[this.ColMap[15]], CVSReader.doubleParse, 2, "D");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PkProfessionTable.RowData rowData = new PkProfessionTable.RowData();
			base.Read<int>(reader, ref rowData.Profession, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.PhysicalAtk, CVSReader.doubleParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.PhysicalDef, CVSReader.doubleParse);
			this.columnno = 3;
			base.Read<double>(reader, ref rowData.MaxHP, CVSReader.doubleParse);
			this.columnno = 4;
			base.Read<double>(reader, ref rowData.HPRecovery, CVSReader.doubleParse);
			this.columnno = 5;
			base.Read<double>(reader, ref rowData.MagicAtk, CVSReader.doubleParse);
			this.columnno = 6;
			base.Read<double>(reader, ref rowData.MagicDef, CVSReader.doubleParse);
			this.columnno = 7;
			base.Read<double>(reader, ref rowData.MaxMP, CVSReader.doubleParse);
			this.columnno = 8;
			base.Read<double>(reader, ref rowData.MPRecovery, CVSReader.doubleParse);
			this.columnno = 9;
			base.Read<double>(reader, ref rowData.Critical, CVSReader.doubleParse);
			this.columnno = 10;
			base.Read<double>(reader, ref rowData.CritResist, CVSReader.doubleParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadArray<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 13;
			base.ReadSeq<uint>(reader, ref rowData.SealRange, CVSReader.uintParse);
			this.columnno = 14;
			base.ReadSeqList<double>(reader, ref rowData.AttrValue_s, CVSReader.doubleParse);
			this.columnno = 15;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
