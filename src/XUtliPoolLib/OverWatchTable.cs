using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class OverWatchTable : CVSReader
	{
		public class RowData
		{
			public uint HeroID;

			public uint XEntityStatisticsID;

			public uint BuffID;

			public Seq2Ref<uint> Price;

			public string Name;

			public string Icon;

			public string Description;

			public string CutSceneAniamtion;

			public string CutSceneIdleAni;

			public uint weight;

			public int SortID;

			public string Motto;
		}

		public List<OverWatchTable.RowData> Table = new List<OverWatchTable.RowData>();

		public OverWatchTable.RowData GetByHeroID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchHeroID(key, 0, this.Table.Count - 1);
		}

		private OverWatchTable.RowData BinarySearchHeroID(uint key, int min, int max)
		{
			OverWatchTable.RowData rowData = this.Table[min];
			if (rowData.HeroID == key)
			{
				return rowData;
			}
			OverWatchTable.RowData rowData2 = this.Table[max];
			if (rowData2.HeroID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			OverWatchTable.RowData rowData3 = this.Table[num];
			if (rowData3.HeroID.CompareTo(key) > 0)
			{
				return this.BinarySearchHeroID(key, min, num);
			}
			if (rowData3.HeroID.CompareTo(key) < 0)
			{
				return this.BinarySearchHeroID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowHeroID(uint key, OverWatchTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			OverWatchTable.RowData rowData = this.Table[min];
			if (rowData.HeroID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.HeroID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OverWatchTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			OverWatchTable.RowData rowData2 = this.Table[max];
			if (rowData2.HeroID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.HeroID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OverWatchTable duplicate id:{0}  lineno: {1}", new object[]
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
			OverWatchTable.RowData rowData3 = this.Table[num];
			if (rowData3.HeroID.CompareTo(key) > 0)
			{
				this.AddRowHeroID(key, row, min, num);
				return;
			}
			if (rowData3.HeroID.CompareTo(key) < 0)
			{
				this.AddRowHeroID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: OverWatchTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"HeroID",
				"XEntityStatisticsID",
				"BuffID",
				"Price",
				"Name",
				"Icon",
				"Description",
				"CutSceneAniamtion",
				"CutSceneIdleAni",
				"weight",
				"SortID",
				"Motto"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			OverWatchTable.RowData rowData = new OverWatchTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.HeroID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.XEntityStatisticsID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.BuffID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.Price, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.CutSceneAniamtion))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.CutSceneIdleAni))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.weight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.SortID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.Motto))
			{
				return false;
			}
			this.AddRowHeroID(rowData.HeroID, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			OverWatchTable.RowData rowData = new OverWatchTable.RowData();
			base.Read<uint>(reader, ref rowData.HeroID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.XEntityStatisticsID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.BuffID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeq<uint>(reader, ref rowData.Price, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.CutSceneAniamtion, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.CutSceneIdleAni, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.weight, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Motto, CVSReader.stringParse);
			this.columnno = 11;
			this.AddRowHeroID(rowData.HeroID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
