using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GameCommunityTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public string ButtonName;

			public bool QQ;

			public bool WX;

			public int OpenLevel;

			public int SysID;

			public bool YK;
		}

		public List<GameCommunityTable.RowData> Table = new List<GameCommunityTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"ButtonName",
				"QQ",
				"WX",
				"OpenLevel",
				"SysID",
				"YK"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GameCommunityTable.RowData rowData = new GameCommunityTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ButtonName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.QQ))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.WX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.OpenLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SysID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.YK))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[2]]);
			base.Write(writer, false, Fields[this.ColMap[3]]);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[6]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GameCommunityTable.RowData rowData = new GameCommunityTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ButtonName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read(reader, ref rowData.QQ);
			this.columnno = 2;
			base.Read(reader, ref rowData.WX);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 5;
			base.Read(reader, ref rowData.YK);
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
