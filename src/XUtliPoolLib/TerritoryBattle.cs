using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class TerritoryBattle : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public string territoryname;

			public uint territorylevel;

			public string territorylevelname;

			public string territoryIcon;

			public uint[] territoryLeagues;
		}

		public List<TerritoryBattle.RowData> Table = new List<TerritoryBattle.RowData>();

		public TerritoryBattle.RowData GetByID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private TerritoryBattle.RowData BinarySearchID(uint key, int min, int max)
		{
			TerritoryBattle.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			TerritoryBattle.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			TerritoryBattle.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(uint key, TerritoryBattle.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			TerritoryBattle.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: TerritoryBattle duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			TerritoryBattle.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: TerritoryBattle duplicate id:{0}  lineno: {1}", new object[]
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
			TerritoryBattle.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: TerritoryBattle duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"territoryname",
				"territorylevel",
				"territorylevelname",
				"territoryIcon",
				"territoryLeagues"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			TerritoryBattle.RowData rowData = new TerritoryBattle.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.territoryname))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.territorylevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.territorylevelname))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.territoryIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.territoryLeagues))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			TerritoryBattle.RowData rowData = new TerritoryBattle.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.territoryname, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.territorylevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.territorylevelname, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.territoryIcon, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.territoryLeagues, CVSReader.uintParse);
			this.columnno = 5;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
