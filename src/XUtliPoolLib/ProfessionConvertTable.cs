using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ProfessionConvertTable : CVSReader
	{
		public class RowData
		{
			public int ProfessionID;

			public int AttributeID;

			public double PhysicalAtk;

			public double PhysicalDef;

			public double MagicAtk;

			public double MagicDef;

			public double Critical;

			public double CritResist;

			public double Stun;

			public double StunResist;

			public double Paralyze;

			public double ParaResist;

			public double MaxHP;

			public double MaxMP;

			public double CombatScore;

			public double CritDamage;
		}

		public List<ProfessionConvertTable.RowData> Table = new List<ProfessionConvertTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ProfessionID",
				"AttributeID",
				"PhysicalAtk",
				"PhysicalDef",
				"MagicAtk",
				"MagicDef",
				"Critical",
				"CritResist",
				"Stun",
				"StunResist",
				"Paralyze",
				"ParaResist",
				"MaxHP",
				"MaxMP",
				"CombatScore",
				"CritDamage"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ProfessionConvertTable.RowData rowData = new ProfessionConvertTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ProfessionID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.AttributeID))
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
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.MagicAtk))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MagicDef))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Critical))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.CritResist))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.Stun))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.StunResist))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Paralyze))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.ParaResist))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.MaxHP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.MaxMP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.CombatScore))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.CritDamage))
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
			base.Write<double>(writer, Fields[this.ColMap[12]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[13]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[14]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[15]], CVSReader.doubleParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ProfessionConvertTable.RowData rowData = new ProfessionConvertTable.RowData();
			base.Read<int>(reader, ref rowData.ProfessionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.AttributeID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.PhysicalAtk, CVSReader.doubleParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.PhysicalDef, CVSReader.doubleParse);
			this.columnno = 3;
			base.Read<double>(reader, ref rowData.MagicAtk, CVSReader.doubleParse);
			this.columnno = 4;
			base.Read<double>(reader, ref rowData.MagicDef, CVSReader.doubleParse);
			this.columnno = 5;
			base.Read<double>(reader, ref rowData.Critical, CVSReader.doubleParse);
			this.columnno = 6;
			base.Read<double>(reader, ref rowData.CritResist, CVSReader.doubleParse);
			this.columnno = 7;
			base.Read<double>(reader, ref rowData.Stun, CVSReader.doubleParse);
			this.columnno = 8;
			base.Read<double>(reader, ref rowData.StunResist, CVSReader.doubleParse);
			this.columnno = 9;
			base.Read<double>(reader, ref rowData.Paralyze, CVSReader.doubleParse);
			this.columnno = 10;
			base.Read<double>(reader, ref rowData.ParaResist, CVSReader.doubleParse);
			this.columnno = 11;
			base.Read<double>(reader, ref rowData.MaxHP, CVSReader.doubleParse);
			this.columnno = 12;
			base.Read<double>(reader, ref rowData.MaxMP, CVSReader.doubleParse);
			this.columnno = 13;
			base.Read<double>(reader, ref rowData.CombatScore, CVSReader.doubleParse);
			this.columnno = 14;
			base.Read<double>(reader, ref rowData.CritDamage, CVSReader.doubleParse);
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
