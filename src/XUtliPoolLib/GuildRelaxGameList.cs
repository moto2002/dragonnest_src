using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildRelaxGameList : CVSReader
	{
		public class RowData
		{
			public string GameBg;

			public string GameTitle;

			public string GameName;

			public int ModuleID;
		}

		public List<GuildRelaxGameList.RowData> Table = new List<GuildRelaxGameList.RowData>();

		public GuildRelaxGameList.RowData GetByModuleID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchModuleID(key, 0, this.Table.Count - 1);
		}

		private GuildRelaxGameList.RowData BinarySearchModuleID(int key, int min, int max)
		{
			GuildRelaxGameList.RowData rowData = this.Table[min];
			if (rowData.ModuleID == key)
			{
				return rowData;
			}
			GuildRelaxGameList.RowData rowData2 = this.Table[max];
			if (rowData2.ModuleID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildRelaxGameList.RowData rowData3 = this.Table[num];
			if (rowData3.ModuleID.CompareTo(key) > 0)
			{
				return this.BinarySearchModuleID(key, min, num);
			}
			if (rowData3.ModuleID.CompareTo(key) < 0)
			{
				return this.BinarySearchModuleID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowModuleID(int key, GuildRelaxGameList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildRelaxGameList.RowData rowData = this.Table[min];
			if (rowData.ModuleID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ModuleID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildRelaxGameList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildRelaxGameList.RowData rowData2 = this.Table[max];
			if (rowData2.ModuleID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ModuleID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildRelaxGameList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			if (max - min <= 1)
			{
				this.Table.Insert(min + 1, row);
				return;
			}
			int num = min + (max - min) / 2;
			GuildRelaxGameList.RowData rowData3 = this.Table[num];
			if (rowData3.ModuleID.CompareTo(key) > 0)
			{
				this.AddRowModuleID(key, row, min, num);
				return;
			}
			if (rowData3.ModuleID.CompareTo(key) < 0)
			{
				this.AddRowModuleID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildRelaxGameList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GameBg",
				"GameTitle",
				"GameName",
				"ModuleID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildRelaxGameList.RowData rowData = new GuildRelaxGameList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GameBg))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.GameTitle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.GameName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ModuleID))
			{
				return false;
			}
			this.AddRowModuleID(rowData.ModuleID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildRelaxGameList.RowData rowData = new GuildRelaxGameList.RowData();
			base.Read<string>(reader, ref rowData.GameBg, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.GameTitle, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.GameName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.ModuleID, CVSReader.intParse);
			this.columnno = 3;
			this.AddRowModuleID(rowData.ModuleID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
