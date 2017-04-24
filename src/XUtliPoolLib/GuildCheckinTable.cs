using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildCheckinTable : CVSReader
	{
		public class RowData
		{
			public uint type;

			public Seq2Ref<uint> consume;

			public Seq2Ref<uint> reward;

			public uint process;

			public Seq2ListRef<uint> guildreward;
		}

		public List<GuildCheckinTable.RowData> Table = new List<GuildCheckinTable.RowData>();

		public GuildCheckinTable.RowData GetBytype(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchtype(key, 0, this.Table.Count - 1);
		}

		private GuildCheckinTable.RowData BinarySearchtype(uint key, int min, int max)
		{
			GuildCheckinTable.RowData rowData = this.Table[min];
			if (rowData.type == key)
			{
				return rowData;
			}
			GuildCheckinTable.RowData rowData2 = this.Table[max];
			if (rowData2.type == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildCheckinTable.RowData rowData3 = this.Table[num];
			if (rowData3.type.CompareTo(key) > 0)
			{
				return this.BinarySearchtype(key, min, num);
			}
			if (rowData3.type.CompareTo(key) < 0)
			{
				return this.BinarySearchtype(key, num, max);
			}
			return rowData3;
		}

		private void AddRowtype(uint key, GuildCheckinTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildCheckinTable.RowData rowData = this.Table[min];
			if (rowData.type.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildCheckinTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildCheckinTable.RowData rowData2 = this.Table[max];
			if (rowData2.type.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildCheckinTable duplicate id:{0}  lineno: {1}", new object[]
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
			GuildCheckinTable.RowData rowData3 = this.Table[num];
			if (rowData3.type.CompareTo(key) > 0)
			{
				this.AddRowtype(key, row, min, num);
				return;
			}
			if (rowData3.type.CompareTo(key) < 0)
			{
				this.AddRowtype(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildCheckinTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"type",
				"consume",
				"reward",
				"process",
				"guildreward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildCheckinTable.RowData rowData = new GuildCheckinTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.consume, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[2]], ref rowData.reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.process))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.guildreward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowtype(rowData.type, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildCheckinTable.RowData rowData = new GuildCheckinTable.RowData();
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.consume, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeq<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.process, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.guildreward, CVSReader.uintParse);
			this.columnno = 4;
			this.AddRowtype(rowData.type, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
