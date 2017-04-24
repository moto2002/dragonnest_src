using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildCheckinBoxTable : CVSReader
	{
		public class RowData
		{
			public uint process;

			public Seq2ListRef<uint> reward;

			public Seq2ListRef<uint> viewabledrop;
		}

		public List<GuildCheckinBoxTable.RowData> Table = new List<GuildCheckinBoxTable.RowData>();

		public GuildCheckinBoxTable.RowData GetByprocess(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchprocess(key, 0, this.Table.Count - 1);
		}

		private GuildCheckinBoxTable.RowData BinarySearchprocess(uint key, int min, int max)
		{
			GuildCheckinBoxTable.RowData rowData = this.Table[min];
			if (rowData.process == key)
			{
				return rowData;
			}
			GuildCheckinBoxTable.RowData rowData2 = this.Table[max];
			if (rowData2.process == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildCheckinBoxTable.RowData rowData3 = this.Table[num];
			if (rowData3.process.CompareTo(key) > 0)
			{
				return this.BinarySearchprocess(key, min, num);
			}
			if (rowData3.process.CompareTo(key) < 0)
			{
				return this.BinarySearchprocess(key, num, max);
			}
			return rowData3;
		}

		private void AddRowprocess(uint key, GuildCheckinBoxTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildCheckinBoxTable.RowData rowData = this.Table[min];
			if (rowData.process.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.process == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildCheckinBoxTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildCheckinBoxTable.RowData rowData2 = this.Table[max];
			if (rowData2.process.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.process == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildCheckinBoxTable duplicate id:{0}  lineno: {1}", new object[]
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
			GuildCheckinBoxTable.RowData rowData3 = this.Table[num];
			if (rowData3.process.CompareTo(key) > 0)
			{
				this.AddRowprocess(key, row, min, num);
				return;
			}
			if (rowData3.process.CompareTo(key) < 0)
			{
				this.AddRowprocess(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildCheckinBoxTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"process",
				"reward",
				"viewabledrop"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildCheckinBoxTable.RowData rowData = new GuildCheckinBoxTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.process))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.viewabledrop, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowprocess(rowData.process, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildCheckinBoxTable.RowData rowData = new GuildCheckinBoxTable.RowData();
			base.Read<uint>(reader, ref rowData.process, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<uint>(reader, ref rowData.viewabledrop, CVSReader.uintParse);
			this.columnno = 2;
			this.AddRowprocess(rowData.process, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
