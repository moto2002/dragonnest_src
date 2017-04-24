using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildMineralBufflist : CVSReader
	{
		public class RowData
		{
			public uint BuffID;

			public Seq2Ref<uint> AttrBuff;

			public uint RewardBuff;

			public string ratestring;

			public uint type;

			public string icon;

			public uint Quality;
		}

		public List<GuildMineralBufflist.RowData> Table = new List<GuildMineralBufflist.RowData>();

		public GuildMineralBufflist.RowData GetByBuffID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchBuffID(key, 0, this.Table.Count - 1);
		}

		private GuildMineralBufflist.RowData BinarySearchBuffID(uint key, int min, int max)
		{
			GuildMineralBufflist.RowData rowData = this.Table[min];
			if (rowData.BuffID == key)
			{
				return rowData;
			}
			GuildMineralBufflist.RowData rowData2 = this.Table[max];
			if (rowData2.BuffID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildMineralBufflist.RowData rowData3 = this.Table[num];
			if (rowData3.BuffID.CompareTo(key) > 0)
			{
				return this.BinarySearchBuffID(key, min, num);
			}
			if (rowData3.BuffID.CompareTo(key) < 0)
			{
				return this.BinarySearchBuffID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowBuffID(uint key, GuildMineralBufflist.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildMineralBufflist.RowData rowData = this.Table[min];
			if (rowData.BuffID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.BuffID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBufflist duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildMineralBufflist.RowData rowData2 = this.Table[max];
			if (rowData2.BuffID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.BuffID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBufflist duplicate id:{0}  lineno: {1}", new object[]
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
			GuildMineralBufflist.RowData rowData3 = this.Table[num];
			if (rowData3.BuffID.CompareTo(key) > 0)
			{
				this.AddRowBuffID(key, row, min, num);
				return;
			}
			if (rowData3.BuffID.CompareTo(key) < 0)
			{
				this.AddRowBuffID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildMineralBufflist duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BuffID",
				"AttrBuff",
				"RewardBuff",
				"ratestring",
				"type",
				"icon",
				"Quality"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildMineralBufflist.RowData rowData = new GuildMineralBufflist.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BuffID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.AttrBuff, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.RewardBuff))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ratestring))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Quality))
			{
				return false;
			}
			this.AddRowBuffID(rowData.BuffID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildMineralBufflist.RowData rowData = new GuildMineralBufflist.RowData();
			base.Read<uint>(reader, ref rowData.BuffID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.AttrBuff, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.RewardBuff, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ratestring, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 6;
			this.AddRowBuffID(rowData.BuffID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
