using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FriendTable : CVSReader
	{
		public class RowData
		{
			public uint level;

			public string name;

			public string teamname;

			public string icon;

			public uint degree;

			public uint totaldegree;

			public Seq2Ref<uint> buf;

			public uint dropid;

			public uint noticeid;
		}

		public List<FriendTable.RowData> Table = new List<FriendTable.RowData>();

		public FriendTable.RowData GetBylevel(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchlevel(key, 0, this.Table.Count - 1);
		}

		private FriendTable.RowData BinarySearchlevel(uint key, int min, int max)
		{
			FriendTable.RowData rowData = this.Table[min];
			if (rowData.level == key)
			{
				return rowData;
			}
			FriendTable.RowData rowData2 = this.Table[max];
			if (rowData2.level == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FriendTable.RowData rowData3 = this.Table[num];
			if (rowData3.level.CompareTo(key) > 0)
			{
				return this.BinarySearchlevel(key, min, num);
			}
			if (rowData3.level.CompareTo(key) < 0)
			{
				return this.BinarySearchlevel(key, num, max);
			}
			return rowData3;
		}

		private void AddRowlevel(uint key, FriendTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FriendTable.RowData rowData = this.Table[min];
			if (rowData.level.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FriendTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FriendTable.RowData rowData2 = this.Table[max];
			if (rowData2.level.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FriendTable duplicate id:{0}  lineno: {1}", new object[]
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
			FriendTable.RowData rowData3 = this.Table[num];
			if (rowData3.level.CompareTo(key) > 0)
			{
				this.AddRowlevel(key, row, min, num);
				return;
			}
			if (rowData3.level.CompareTo(key) < 0)
			{
				this.AddRowlevel(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FriendTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"level",
				"name",
				"teamname",
				"icon",
				"degree",
				"totaldegree",
				"buf",
				"dropid",
				"noticeid"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FriendTable.RowData rowData = new FriendTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.teamname))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.degree))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.totaldegree))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.buf, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.dropid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.noticeid))
			{
				return false;
			}
			this.AddRowlevel(rowData.level, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FriendTable.RowData rowData = new FriendTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.teamname, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.degree, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.totaldegree, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeq<uint>(reader, ref rowData.buf, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.dropid, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.noticeid, CVSReader.uintParse);
			this.columnno = 8;
			this.AddRowlevel(rowData.level, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
