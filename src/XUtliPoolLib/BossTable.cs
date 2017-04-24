using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BossTable : CVSReader
	{
		public class RowData
		{
			public uint BossID;

			public Seq2ListRef<uint> EnemyID;

			public float AttackPercent;

			public float LifePercent;
		}

		public List<BossTable.RowData> Table = new List<BossTable.RowData>();

		public BossTable.RowData GetByBossID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchBossID(key, 0, this.Table.Count - 1);
		}

		private BossTable.RowData BinarySearchBossID(uint key, int min, int max)
		{
			BossTable.RowData rowData = this.Table[min];
			if (rowData.BossID == key)
			{
				return rowData;
			}
			BossTable.RowData rowData2 = this.Table[max];
			if (rowData2.BossID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			BossTable.RowData rowData3 = this.Table[num];
			if (rowData3.BossID.CompareTo(key) > 0)
			{
				return this.BinarySearchBossID(key, min, num);
			}
			if (rowData3.BossID.CompareTo(key) < 0)
			{
				return this.BinarySearchBossID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowBossID(uint key, BossTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			BossTable.RowData rowData = this.Table[min];
			if (rowData.BossID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.BossID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			BossTable.RowData rowData2 = this.Table[max];
			if (rowData2.BossID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.BossID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossTable duplicate id:{0}  lineno: {1}", new object[]
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
			BossTable.RowData rowData3 = this.Table[num];
			if (rowData3.BossID.CompareTo(key) > 0)
			{
				this.AddRowBossID(key, row, min, num);
				return;
			}
			if (rowData3.BossID.CompareTo(key) < 0)
			{
				this.AddRowBossID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: BossTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BossID",
				"EnemyID",
				"AttackPercent",
				"LifePercent"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BossTable.RowData rowData = new BossTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BossID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.EnemyID, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.AttackPercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.LifePercent))
			{
				return false;
			}
			this.AddRowBossID(rowData.BossID, rowData, 0, this.Table.Count - 1);
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
			base.Write<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BossTable.RowData rowData = new BossTable.RowData();
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.EnemyID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.AttackPercent, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.LifePercent, CVSReader.floatParse);
			this.columnno = 3;
			this.AddRowBossID(rowData.BossID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
