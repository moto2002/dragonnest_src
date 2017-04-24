using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ItemUseButtonList : CVSReader
	{
		public class RowData
		{
			public uint ItemID;

			public string ItemName;

			public string ButtonName;

			public uint SystemID;

			public uint TypeID;
		}

		public List<ItemUseButtonList.RowData> Table = new List<ItemUseButtonList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ItemID",
				"ItemName",
				"ButtonName",
				"SystemID",
				"TypeID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ItemUseButtonList.RowData rowData = new ItemUseButtonList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ItemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ItemName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ButtonName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.TypeID))
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ItemUseButtonList.RowData rowData = new ItemUseButtonList.RowData();
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ItemName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ButtonName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.TypeID, CVSReader.uintParse);
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
