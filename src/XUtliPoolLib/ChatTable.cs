using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ChatTable : CVSReader
	{
		public class RowData
		{
			public uint id;

			public uint cd;

			public uint level;

			public bool isnotice;

			public bool isrecord;

			public uint length;

			public string sprName;

			public string miniSpr;

			public string name;
		}

		public List<ChatTable.RowData> Table = new List<ChatTable.RowData>();

		public ChatTable.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private ChatTable.RowData BinarySearchid(uint key, int min, int max)
		{
			ChatTable.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			ChatTable.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ChatTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				return this.BinarySearchid(key, min, num);
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				return this.BinarySearchid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowid(uint key, ChatTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ChatTable.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ChatTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ChatTable.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ChatTable duplicate id:{0}  lineno: {1}", new object[]
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
			ChatTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				this.AddRowid(key, row, min, num);
				return;
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				this.AddRowid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ChatTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"cd",
				"level",
				"isnotice",
				"isrecord",
				"length",
				"sprName",
				"miniSpr",
				"name"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ChatTable.RowData rowData = new ChatTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.cd))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.isnotice))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.isrecord))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.length))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.sprName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.miniSpr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.name))
			{
				return false;
			}
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
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
			base.Write(writer, false, Fields[this.ColMap[3]]);
			base.Write(writer, false, Fields[this.ColMap[4]]);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ChatTable.RowData rowData = new ChatTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.cd, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			base.Read(reader, ref rowData.isnotice);
			this.columnno = 3;
			base.Read(reader, ref rowData.isrecord);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.length, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.sprName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.miniSpr, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 8;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
