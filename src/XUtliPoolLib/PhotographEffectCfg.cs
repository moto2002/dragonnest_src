using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PhotographEffectCfg : CVSReader
	{
		public class RowData
		{
			public uint EffectID;

			public Seq2ListRef<uint> Condition;

			public string EffectName;

			public string EffectRoute;

			public string ConditionDesc;

			public string desc;

			public uint SystemID;
		}

		public List<PhotographEffectCfg.RowData> Table = new List<PhotographEffectCfg.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EffectID",
				"Condition",
				"EffectName",
				"EffectRoute",
				"ConditionDesc",
				"desc",
				"SystemID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PhotographEffectCfg.RowData rowData = new PhotographEffectCfg.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EffectID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Condition, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.EffectName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.EffectRoute))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.ConditionDesc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.SystemID))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PhotographEffectCfg.RowData rowData = new PhotographEffectCfg.RowData();
			base.Read<uint>(reader, ref rowData.EffectID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.Condition, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.EffectName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.EffectRoute, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ConditionDesc, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
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
