using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SkillCombo : CVSReader
	{
		public class RowData
		{
			public string skillname;

			public string nextskill0;

			public string nextskill1;

			public string nextskill2;

			public string nextskill3;

			public string nextskill4;
		}

		public List<SkillCombo.RowData> Table = new List<SkillCombo.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"skillname",
				"nextskill0",
				"nextskill1",
				"nextskill2",
				"nextskill3",
				"nextskill4"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SkillCombo.RowData rowData = new SkillCombo.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.skillname))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.nextskill0))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.nextskill1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.nextskill2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.nextskill3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.nextskill4))
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
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SkillCombo.RowData rowData = new SkillCombo.RowData();
			base.Read<string>(reader, ref rowData.skillname, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.nextskill0, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.nextskill1, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.nextskill2, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.nextskill3, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.nextskill4, CVSReader.stringParse);
			this.columnno = 5;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
