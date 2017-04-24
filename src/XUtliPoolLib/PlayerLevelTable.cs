using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PlayerLevelTable : CVSReader
	{
		public class RowData
		{
			public int Level;

			public long Exp;

			public double InitialAttr;

			public double Trans1Attr;

			public double Trans2Attr;

			public double MaxMP;

			public int[] SuperArmorAttack;

			public int[] SuperArmorDefend;

			public int[] SuperArmorMax;

			public int[] SuperArmorRecovery;

			public int AddSkillPoint;

			public double ExpAddition;
		}

		public List<PlayerLevelTable.RowData> Table = new List<PlayerLevelTable.RowData>();

		public PlayerLevelTable.RowData GetByLevel(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchLevel(key, 0, this.Table.Count - 1);
		}

		private PlayerLevelTable.RowData BinarySearchLevel(int key, int min, int max)
		{
			PlayerLevelTable.RowData rowData = this.Table[min];
			if (rowData.Level == key)
			{
				return rowData;
			}
			PlayerLevelTable.RowData rowData2 = this.Table[max];
			if (rowData2.Level == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PlayerLevelTable.RowData rowData3 = this.Table[num];
			if (rowData3.Level.CompareTo(key) > 0)
			{
				return this.BinarySearchLevel(key, min, num);
			}
			if (rowData3.Level.CompareTo(key) < 0)
			{
				return this.BinarySearchLevel(key, num, max);
			}
			return rowData3;
		}

		private void AddRowLevel(int key, PlayerLevelTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PlayerLevelTable.RowData rowData = this.Table[min];
			if (rowData.Level.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlayerLevelTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PlayerLevelTable.RowData rowData2 = this.Table[max];
			if (rowData2.Level.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlayerLevelTable duplicate id:{0}  lineno: {1}", new object[]
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
			PlayerLevelTable.RowData rowData3 = this.Table[num];
			if (rowData3.Level.CompareTo(key) > 0)
			{
				this.AddRowLevel(key, row, min, num);
				return;
			}
			if (rowData3.Level.CompareTo(key) < 0)
			{
				this.AddRowLevel(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PlayerLevelTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Level",
				"Exp",
				"InitialAttr",
				"Trans1Attr",
				"Trans2Attr",
				"MaxMP",
				"SuperArmorAttack",
				"SuperArmorDefend",
				"SuperArmorMax",
				"SuperArmorRecovery",
				"AddSkillPoint",
				"ExpAddition"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PlayerLevelTable.RowData rowData = new PlayerLevelTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Exp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.InitialAttr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Trans1Attr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Trans2Attr))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MaxMP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.SuperArmorAttack))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SuperArmorDefend))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.SuperArmorMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.SuperArmorRecovery))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.AddSkillPoint))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.ExpAddition))
			{
				return false;
			}
			this.AddRowLevel(rowData.Level, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<long>(writer, Fields[this.ColMap[1]], CVSReader.longParse);
			base.Write<double>(writer, Fields[this.ColMap[2]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[3]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[4]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[5]], CVSReader.doubleParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<double>(writer, Fields[this.ColMap[11]], CVSReader.doubleParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PlayerLevelTable.RowData rowData = new PlayerLevelTable.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.Read<long>(reader, ref rowData.Exp, CVSReader.longParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.InitialAttr, CVSReader.doubleParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.Trans1Attr, CVSReader.doubleParse);
			this.columnno = 3;
			base.Read<double>(reader, ref rowData.Trans2Attr, CVSReader.doubleParse);
			this.columnno = 4;
			base.Read<double>(reader, ref rowData.MaxMP, CVSReader.doubleParse);
			this.columnno = 5;
			base.ReadArray<int>(reader, ref rowData.SuperArmorAttack, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.SuperArmorDefend, CVSReader.intParse);
			this.columnno = 7;
			base.ReadArray<int>(reader, ref rowData.SuperArmorMax, CVSReader.intParse);
			this.columnno = 8;
			base.ReadArray<int>(reader, ref rowData.SuperArmorRecovery, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.AddSkillPoint, CVSReader.intParse);
			this.columnno = 10;
			base.Read<double>(reader, ref rowData.ExpAddition, CVSReader.doubleParse);
			this.columnno = 11;
			this.AddRowLevel(rowData.Level, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
