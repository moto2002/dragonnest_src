using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CombatParamTable : CVSReader
	{
		public class RowData
		{
			public int PlayerLevel;

			public int CriticalBase;

			public int CritResistBase;

			public int ParalyzeBase;

			public int ParaResistBase;

			public int StunBase;

			public int StunResistBase;

			public int CritDamageBase;

			public int FinalDamageBase;

			public int PhysicalDef;

			public int MagicDef;

			public int ElementAtk;

			public int ElementDef;
		}

		public List<CombatParamTable.RowData> Table = new List<CombatParamTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"PlayerLevel",
				"CriticalBase",
				"CritResistBase",
				"ParalyzeBase",
				"ParaResistBase",
				"StunBase",
				"StunResistBase",
				"CritDamageBase",
				"FinalDamageBase",
				"PhysicalDef",
				"MagicDef",
				"ElementAtk",
				"ElementDef"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CombatParamTable.RowData rowData = new CombatParamTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.PlayerLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.CriticalBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.CritResistBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ParalyzeBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ParaResistBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.StunBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.StunResistBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.CritDamageBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.FinalDamageBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.PhysicalDef))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.MagicDef))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.ElementAtk))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.ElementDef))
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[12]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CombatParamTable.RowData rowData = new CombatParamTable.RowData();
			base.Read<int>(reader, ref rowData.PlayerLevel, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.CriticalBase, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.CritResistBase, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.ParalyzeBase, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ParaResistBase, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.StunBase, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.StunResistBase, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.CritDamageBase, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.FinalDamageBase, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.PhysicalDef, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.MagicDef, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.ElementAtk, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.ElementDef, CVSReader.intParse);
			this.columnno = 12;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
