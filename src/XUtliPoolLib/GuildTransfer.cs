using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildTransfer : CVSReader
	{
		public class RowData
		{
			public uint id;

			public string name;

			public string description;

			public uint sceneid;

			public uint max;

			public string icon;
		}

		public List<GuildTransfer.RowData> Table = new List<GuildTransfer.RowData>();

		public GuildTransfer.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private GuildTransfer.RowData BinarySearchid(uint key, int min, int max)
		{
			GuildTransfer.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			GuildTransfer.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildTransfer.RowData rowData3 = this.Table[num];
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

		private void AddRowid(uint key, GuildTransfer.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildTransfer.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildTransfer duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildTransfer.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildTransfer duplicate id:{0}  lineno: {1}", new object[]
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
			GuildTransfer.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildTransfer duplicate id:{0}  lineno: {1}", new object[]
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
				"name",
				"description",
				"sceneid",
				"max",
				"icon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildTransfer.RowData rowData = new GuildTransfer.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.sceneid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.max))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.icon))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildTransfer.RowData rowData = new GuildTransfer.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.max, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
