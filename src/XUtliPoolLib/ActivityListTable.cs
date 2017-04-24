using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ActivityListTable : CVSReader
	{
		public class RowData
		{
			public uint SysID;

			public string Tittle;

			public string[] TagNames;

			public string Icon;

			public bool FairMode;

			public bool HadShop;

			public Seq2ListRef<uint> DropItems;

			public string Describe;

			public uint SortIndex;
		}

		public List<ActivityListTable.RowData> Table = new List<ActivityListTable.RowData>();

		public ActivityListTable.RowData GetBySysID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			int i = 0;
			int count = this.Table.Count;
			while (i < count)
			{
				if (this.Table[i].SysID == key)
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
				"SysID",
				"Tittle",
				"TagNames",
				"Icon",
				"FairMode",
				"HadShop",
				"DropItems",
				"Describe",
				"SortIndex"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ActivityListTable.RowData rowData = new ActivityListTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SysID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Tittle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TagNames))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.FairMode))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.HadShop))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.DropItems, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Describe))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.SortIndex))
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
			base.WriteArray<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[4]]);
			base.Write(writer, false, Fields[this.ColMap[5]]);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ActivityListTable.RowData rowData = new ActivityListTable.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Tittle, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.TagNames, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read(reader, ref rowData.FairMode);
			this.columnno = 4;
			base.Read(reader, ref rowData.HadShop);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.DropItems, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Describe, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.SortIndex, CVSReader.uintParse);
			this.columnno = 8;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
