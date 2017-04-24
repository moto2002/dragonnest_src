using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class NoticeTable : CVSReader
	{
		public class RowData
		{
			public uint id;

			public int channel;

			public string info;

			public uint[] timebegin;

			public uint[] timeend;

			public uint timespan;

			public uint priority;

			public uint linkparam;

			public string linkcontent;

			public uint level;
		}

		public List<NoticeTable.RowData> Table = new List<NoticeTable.RowData>();

		public NoticeTable.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private NoticeTable.RowData BinarySearchid(uint key, int min, int max)
		{
			NoticeTable.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			NoticeTable.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			NoticeTable.RowData rowData3 = this.Table[num];
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

		private void AddRowid(uint key, NoticeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			NoticeTable.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NoticeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			NoticeTable.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: NoticeTable duplicate id:{0}  lineno: {1}", new object[]
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
			NoticeTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: NoticeTable duplicate id:{0}  lineno: {1}", new object[]
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
				"channel",
				"info",
				"timebegin",
				"timeend",
				"timespan",
				"priority",
				"linkparam",
				"linkcontent",
				"level"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			NoticeTable.RowData rowData = new NoticeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.channel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.info))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.timebegin))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.timeend))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.timespan))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.priority))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.linkparam))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.linkcontent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.level))
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
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			NoticeTable.RowData rowData = new NoticeTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.channel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.info, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.timebegin, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.timeend, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.timespan, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.priority, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.linkparam, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.linkcontent, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 9;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
