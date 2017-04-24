using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SuperActivity : CVSReader
	{
		public class RowData
		{
			public uint actid;

			public uint id;

			public string[] childs;

			public uint offset;

			public string icon;

			public string name;

			public uint belong;
		}

		public List<SuperActivity.RowData> Table = new List<SuperActivity.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"actid",
				"id",
				"childs",
				"offset",
				"icon",
				"name",
				"belong"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SuperActivity.RowData rowData = new SuperActivity.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.actid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.childs))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.offset))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.belong))
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
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SuperActivity.RowData rowData = new SuperActivity.RowData();
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.childs, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.offset, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.belong, CVSReader.uintParse);
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
