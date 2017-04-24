using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class DragonNestTable : CVSReader
	{
		public class RowData
		{
			public uint DragonNestID;

			public uint DragonNestType;

			public uint DragonNestDifficulty;

			public uint DragonNestWave;

			public int DragonNestPosX;

			public int DragonNestPosY;

			public string DragonNestIcon;
		}

		public List<DragonNestTable.RowData> Table = new List<DragonNestTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"DragonNestID",
				"DragonNestType",
				"DragonNestDifficulty",
				"DragonNestWave",
				"DragonNestPosX",
				"DragonNestPosY",
				"DragonNestIcon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			DragonNestTable.RowData rowData = new DragonNestTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.DragonNestID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.DragonNestType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.DragonNestDifficulty))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.DragonNestWave))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.DragonNestPosX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.DragonNestPosY))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.DragonNestIcon))
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			DragonNestTable.RowData rowData = new DragonNestTable.RowData();
			base.Read<uint>(reader, ref rowData.DragonNestID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DragonNestType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DragonNestDifficulty, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.DragonNestWave, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DragonNestPosX, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DragonNestPosY, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.DragonNestIcon, CVSReader.stringParse);
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
