using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SkillTreeConfigTable : CVSReader
	{
		public class RowData
		{
			public uint Level;

			public int RedPointShowNum;
		}

		public List<SkillTreeConfigTable.RowData> Table = new List<SkillTreeConfigTable.RowData>();

		public SkillTreeConfigTable.RowData GetByLevel(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchLevel(key, 0, this.Table.Count - 1);
		}

		private SkillTreeConfigTable.RowData BinarySearchLevel(uint key, int min, int max)
		{
			SkillTreeConfigTable.RowData rowData = this.Table[min];
			if (rowData.Level == key)
			{
				return rowData;
			}
			SkillTreeConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.Level == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SkillTreeConfigTable.RowData rowData3 = this.Table[num];
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

		private void AddRowLevel(uint key, SkillTreeConfigTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SkillTreeConfigTable.RowData rowData = this.Table[min];
			if (rowData.Level.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SkillTreeConfigTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SkillTreeConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.Level.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Level == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SkillTreeConfigTable duplicate id:{0}  lineno: {1}", new object[]
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
			SkillTreeConfigTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SkillTreeConfigTable duplicate id:{0}  lineno: {1}", new object[]
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
				"RedPointShowNum"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SkillTreeConfigTable.RowData rowData = new SkillTreeConfigTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.RedPointShowNum))
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
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SkillTreeConfigTable.RowData rowData = new SkillTreeConfigTable.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.RedPointShowNum, CVSReader.intParse);
			this.columnno = 1;
			this.AddRowLevel(rowData.Level, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
