using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ActivityTable : CVSReader
	{
		public class RowData
		{
			public uint id;

			public uint count;

			public uint value;

			public string name;

			public string icon;

			public Seq2Ref<uint> level;

			public uint[] weekday;

			public string description;
		}

		public List<ActivityTable.RowData> Table = new List<ActivityTable.RowData>();

		public ActivityTable.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			int i = 0;
			int count = this.Table.Count;
			while (i < count)
			{
				if (this.Table[i].id == key)
				{
					return this.Table[i];
				}
				i++;
			}
			return null;
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"count",
				"value",
				"name",
				"icon",
				"level",
				"weekday",
				"description"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ActivityTable.RowData rowData = new ActivityTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.count))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.value))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.level, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.weekday))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.description))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
			base.WriteArray<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ActivityTable.RowData rowData = new ActivityTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadSeq<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.weekday, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 7;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
