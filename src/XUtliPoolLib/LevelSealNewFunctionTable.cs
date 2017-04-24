using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class LevelSealNewFunctionTable : CVSReader
	{
		public class RowData
		{
			public int Type;

			public int OpenLevel;

			public string Tag;

			public string IconName;
		}

		public List<LevelSealNewFunctionTable.RowData> Table = new List<LevelSealNewFunctionTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"OpenLevel",
				"Tag",
				"IconName"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			LevelSealNewFunctionTable.RowData rowData = new LevelSealNewFunctionTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.OpenLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Tag))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.IconName))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			LevelSealNewFunctionTable.RowData rowData = new LevelSealNewFunctionTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Tag, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 3;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
