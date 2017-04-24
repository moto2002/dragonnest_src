using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DragonNestType : CVSReader
	{
		public class RowData
		{
			public uint DragonNestType;

			public string TypeName;

			public string TypeBg;

			public string TypeIcon;
		}

		public List<DragonNestType.RowData> Table = new List<DragonNestType.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"DragonNestType",
				"TypeName",
				"TypeBg",
				"TypeIcon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DragonNestType.RowData rowData = new DragonNestType.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.DragonNestType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TypeName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TypeBg))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TypeIcon))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DragonNestType.RowData rowData = new DragonNestType.RowData();
			base.Read<uint>(reader, ref rowData.DragonNestType, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TypeName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TypeBg, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TypeIcon, CVSReader.stringParse);
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
