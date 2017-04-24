using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FriendSysConfigTable : CVSReader
	{
		public class RowData
		{
			public int TabID;

			public bool IsOpen;

			public string TabName;

			public string Icon;

			public string NumLabel;

			public string RButtonLabel;

			public string LButtonLabel;

			public int NumLimit;
		}

		public List<FriendSysConfigTable.RowData> Table = new List<FriendSysConfigTable.RowData>();

		public FriendSysConfigTable.RowData GetByTabID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchTabID(key, 0, this.Table.Count - 1);
		}

		private FriendSysConfigTable.RowData BinarySearchTabID(int key, int min, int max)
		{
			FriendSysConfigTable.RowData rowData = this.Table[min];
			if (rowData.TabID == key)
			{
				return rowData;
			}
			FriendSysConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.TabID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FriendSysConfigTable.RowData rowData3 = this.Table[num];
			if (rowData3.TabID.CompareTo(key) > 0)
			{
				return this.BinarySearchTabID(key, min, num);
			}
			if (rowData3.TabID.CompareTo(key) < 0)
			{
				return this.BinarySearchTabID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowTabID(int key, FriendSysConfigTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FriendSysConfigTable.RowData rowData = this.Table[min];
			if (rowData.TabID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.TabID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FriendSysConfigTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FriendSysConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.TabID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.TabID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FriendSysConfigTable duplicate id:{0}  lineno: {1}", new object[]
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
			FriendSysConfigTable.RowData rowData3 = this.Table[num];
			if (rowData3.TabID.CompareTo(key) > 0)
			{
				this.AddRowTabID(key, row, min, num);
				return;
			}
			if (rowData3.TabID.CompareTo(key) < 0)
			{
				this.AddRowTabID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FriendSysConfigTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"TabID",
				"IsOpen",
				"TabName",
				"Icon",
				"NumLabel",
				"RButtonLabel",
				"LButtonLabel",
				"NumLimit"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FriendSysConfigTable.RowData rowData = new FriendSysConfigTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TabID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.IsOpen))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.TabName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.NumLabel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.RButtonLabel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.LButtonLabel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.NumLimit))
			{
				return false;
			}
			this.AddRowTabID(rowData.TabID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[1]]);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FriendSysConfigTable.RowData rowData = new FriendSysConfigTable.RowData();
			base.Read<int>(reader, ref rowData.TabID, CVSReader.intParse);
			this.columnno = 0;
			base.Read(reader, ref rowData.IsOpen);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.NumLabel, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.RButtonLabel, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.LButtonLabel, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.NumLimit, CVSReader.intParse);
			this.columnno = 7;
			this.AddRowTabID(rowData.TabID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
