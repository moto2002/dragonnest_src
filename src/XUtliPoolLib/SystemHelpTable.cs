using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SystemHelpTable : CVSReader
	{
		public class RowData
		{
			public int SystemID;

			public string SystemDescription;

			public string[] SystemHelp;
		}

		public List<SystemHelpTable.RowData> Table = new List<SystemHelpTable.RowData>();

		public SystemHelpTable.RowData GetBySystemID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSystemID(key, 0, this.Table.Count - 1);
		}

		private SystemHelpTable.RowData BinarySearchSystemID(int key, int min, int max)
		{
			SystemHelpTable.RowData rowData = this.Table[min];
			if (rowData.SystemID == key)
			{
				return rowData;
			}
			SystemHelpTable.RowData rowData2 = this.Table[max];
			if (rowData2.SystemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SystemHelpTable.RowData rowData3 = this.Table[num];
			if (rowData3.SystemID.CompareTo(key) > 0)
			{
				return this.BinarySearchSystemID(key, min, num);
			}
			if (rowData3.SystemID.CompareTo(key) < 0)
			{
				return this.BinarySearchSystemID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSystemID(int key, SystemHelpTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SystemHelpTable.RowData rowData = this.Table[min];
			if (rowData.SystemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SystemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemHelpTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SystemHelpTable.RowData rowData2 = this.Table[max];
			if (rowData2.SystemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SystemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemHelpTable duplicate id:{0}  lineno: {1}", new object[]
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
			SystemHelpTable.RowData rowData3 = this.Table[num];
			if (rowData3.SystemID.CompareTo(key) > 0)
			{
				this.AddRowSystemID(key, row, min, num);
				return;
			}
			if (rowData3.SystemID.CompareTo(key) < 0)
			{
				this.AddRowSystemID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemHelpTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SystemID",
				"SystemDescription",
				"SystemHelp"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SystemHelpTable.RowData rowData = new SystemHelpTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SystemDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SystemHelp))
			{
				return false;
			}
			this.AddRowSystemID(rowData.SystemID, rowData, 0, this.Table.Count - 1);
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
			base.WriteArray<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SystemHelpTable.RowData rowData = new SystemHelpTable.RowData();
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.SystemHelp, CVSReader.stringParse);
			this.columnno = 2;
			this.AddRowSystemID(rowData.SystemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
