using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PetMoodTipsTable : CVSReader
	{
		public class RowData
		{
			public uint level;

			public int value;

			public string tip;

			public string icon;

			public uint comprehend;

			public Seq2Ref<int> hourchange;

			public string tips;
		}

		public List<PetMoodTipsTable.RowData> Table = new List<PetMoodTipsTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"level",
				"value",
				"tip",
				"icon",
				"comprehend",
				"hourchange",
				"tips"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PetMoodTipsTable.RowData rowData = new PetMoodTipsTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.value))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.tip))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.comprehend))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[5]], ref rowData.hourchange, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.tips))
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
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse, 2, "I");
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PetMoodTipsTable.RowData rowData = new PetMoodTipsTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.value, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.tip, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.comprehend, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeq<int>(reader, ref rowData.hourchange, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
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
