using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ActivityChestTable : CVSReader
	{
		public class RowData
		{
			public uint chest;

			public Seq2Ref<uint> level;

			public uint[] dropid;

			public string dropdesc;

			public Seq2ListRef<uint> viewabledrop;
		}

		public List<ActivityChestTable.RowData> Table = new List<ActivityChestTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"chest",
				"level",
				"dropid",
				"dropdesc",
				"viewabledrop"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ActivityChestTable.RowData rowData = new ActivityChestTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.chest))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.level, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.dropid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.dropdesc))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.viewabledrop, CVSReader.uintParse, "2U"))
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteArray<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ActivityChestTable.RowData rowData = new ActivityChestTable.RowData();
			base.Read<uint>(reader, ref rowData.chest, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.dropid, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.dropdesc, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.viewabledrop, CVSReader.uintParse);
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
