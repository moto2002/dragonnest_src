using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CharacterAttributesList : CVSReader
	{
		public class RowData
		{
			public uint AttributeID;

			public string Section;
		}

		public List<CharacterAttributesList.RowData> Table = new List<CharacterAttributesList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"AttributeID",
				"Section"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CharacterAttributesList.RowData rowData = new CharacterAttributesList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.AttributeID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Section))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CharacterAttributesList.RowData rowData = new CharacterAttributesList.RowData();
			base.Read<uint>(reader, ref rowData.AttributeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Section, CVSReader.stringParse);
			this.columnno = 1;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
