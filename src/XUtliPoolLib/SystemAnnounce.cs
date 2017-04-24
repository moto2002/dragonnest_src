using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SystemAnnounce : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int SystemID;

			public string SystemDescription;

			public int OpenAnnounceLevel;

			public string[] AnnounceDesc;

			public string AnnounceIcon;

			public string TextSpriteName;

			public string IconName;
		}

		public List<SystemAnnounce.RowData> Table = new List<SystemAnnounce.RowData>();

		public SystemAnnounce.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private SystemAnnounce.RowData BinarySearchID(int key, int min, int max)
		{
			SystemAnnounce.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			SystemAnnounce.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SystemAnnounce.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(int key, SystemAnnounce.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SystemAnnounce.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemAnnounce duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SystemAnnounce.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemAnnounce duplicate id:{0}  lineno: {1}", new object[]
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
			SystemAnnounce.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemAnnounce duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"SystemID",
				"SystemDescription",
				"OpenAnnounceLevel",
				"AnnounceDesc",
				"AnnounceIcon",
				"TextSpriteName",
				"IconName"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SystemAnnounce.RowData rowData = new SystemAnnounce.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SystemDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.OpenAnnounceLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.AnnounceDesc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.AnnounceIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.TextSpriteName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.IconName))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SystemAnnounce.RowData rowData = new SystemAnnounce.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.OpenAnnounceLevel, CVSReader.intParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.AnnounceDesc, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.AnnounceIcon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TextSpriteName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 7;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
