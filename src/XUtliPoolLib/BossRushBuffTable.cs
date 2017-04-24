using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BossRushBuffTable : CVSReader
	{
		public class RowData
		{
			public int BossRushBuffID;

			public Seq2Ref<int> AttrBuff;

			public float RewardBuff;

			public string ratestring;

			public string icon;

			public int Quality;

			public string Comment;

			public int type;
		}

		public List<BossRushBuffTable.RowData> Table = new List<BossRushBuffTable.RowData>();

		public BossRushBuffTable.RowData GetByBossRushBuffID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchBossRushBuffID(key, 0, this.Table.Count - 1);
		}

		private BossRushBuffTable.RowData BinarySearchBossRushBuffID(int key, int min, int max)
		{
			BossRushBuffTable.RowData rowData = this.Table[min];
			if (rowData.BossRushBuffID == key)
			{
				return rowData;
			}
			BossRushBuffTable.RowData rowData2 = this.Table[max];
			if (rowData2.BossRushBuffID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			BossRushBuffTable.RowData rowData3 = this.Table[num];
			if (rowData3.BossRushBuffID.CompareTo(key) > 0)
			{
				return this.BinarySearchBossRushBuffID(key, min, num);
			}
			if (rowData3.BossRushBuffID.CompareTo(key) < 0)
			{
				return this.BinarySearchBossRushBuffID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowBossRushBuffID(int key, BossRushBuffTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			BossRushBuffTable.RowData rowData = this.Table[min];
			if (rowData.BossRushBuffID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.BossRushBuffID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossRushBuffTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			BossRushBuffTable.RowData rowData2 = this.Table[max];
			if (rowData2.BossRushBuffID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.BossRushBuffID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossRushBuffTable duplicate id:{0}  lineno: {1}", new object[]
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
			BossRushBuffTable.RowData rowData3 = this.Table[num];
			if (rowData3.BossRushBuffID.CompareTo(key) > 0)
			{
				this.AddRowBossRushBuffID(key, row, min, num);
				return;
			}
			if (rowData3.BossRushBuffID.CompareTo(key) < 0)
			{
				this.AddRowBossRushBuffID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossRushBuffTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BossRushBuffID",
				"AttrBuff",
				"RewardBuff",
				"ratestring",
				"icon",
				"Quality",
				"Comment",
				"type"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BossRushBuffTable.RowData rowData = new BossRushBuffTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BossRushBuffID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.AttrBuff, CVSReader.intParse, "2I"))
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
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.Quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Comment))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.type))
			{
				return false;
			}
			this.AddRowBossRushBuffID(rowData.BossRushBuffID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse, 2, "I");
			base.Write<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BossRushBuffTable.RowData rowData = new BossRushBuffTable.RowData();
			base.Read<int>(reader, ref rowData.BossRushBuffID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeq<int>(reader, ref rowData.AttrBuff, CVSReader.intParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.RewardBuff, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ratestring, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Quality, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 7;
			this.AddRowBossRushBuffID(rowData.BossRushBuffID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
