using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FpGoToLevelUp : CVSReader
	{
		public class RowData
		{
			public uint Id;

			public string Name;

			public uint SystemId;

			public string Tips;

			public string IconName;

			public uint StarNum;

			public uint IsRecommond;
		}

		public List<FpGoToLevelUp.RowData> Table = new List<FpGoToLevelUp.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Id",
				"Name",
				"SystemId",
				"Tips",
				"IconName",
				"StarNum",
				"IsRecommond"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FpGoToLevelUp.RowData rowData = new FpGoToLevelUp.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SystemId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Tips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.IconName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.StarNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.IsRecommond))
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FpGoToLevelUp.RowData rowData = new FpGoToLevelUp.RowData();
			base.Read<uint>(reader, ref rowData.Id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.StarNum, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.IsRecommond, CVSReader.uintParse);
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
