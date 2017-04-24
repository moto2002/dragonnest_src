using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PVPActivityList : CVSReader
	{
		public class RowData
		{
			public uint SysID;

			public string Name;

			public string Description;

			public string Icon;

			public bool FairMode;
		}

		public List<PVPActivityList.RowData> Table = new List<PVPActivityList.RowData>();

		public PVPActivityList.RowData GetBySysID(uint key)
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
				"Name",
				"Description",
				"Icon",
				"FairMode"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PVPActivityList.RowData rowData = new PVPActivityList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SysID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Description))
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
			base.Write(writer, false, Fields[this.ColMap[4]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PVPActivityList.RowData rowData = new PVPActivityList.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read(reader, ref rowData.FairMode);
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
