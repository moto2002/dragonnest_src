using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SystemRewardTable : CVSReader
	{
		public class RowData
		{
			public uint Type;

			public string Name;

			public uint SubType;

			public uint Sort;

			public string Remark;

			public Seq2ListRef<uint> Reward;
		}

		public List<SystemRewardTable.RowData> Table = new List<SystemRewardTable.RowData>();

		public SystemRewardTable.RowData GetByType(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchType(key, 0, this.Table.Count - 1);
		}

		private SystemRewardTable.RowData BinarySearchType(uint key, int min, int max)
		{
			SystemRewardTable.RowData rowData = this.Table[min];
			if (rowData.Type == key)
			{
				return rowData;
			}
			SystemRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.Type == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SystemRewardTable.RowData rowData3 = this.Table[num];
			if (rowData3.Type.CompareTo(key) > 0)
			{
				return this.BinarySearchType(key, min, num);
			}
			if (rowData3.Type.CompareTo(key) < 0)
			{
				return this.BinarySearchType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowType(uint key, SystemRewardTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SystemRewardTable.RowData rowData = this.Table[min];
			if (rowData.Type.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemRewardTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SystemRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.Type.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemRewardTable duplicate id:{0}  lineno: {1}", new object[]
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
			SystemRewardTable.RowData rowData3 = this.Table[num];
			if (rowData3.Type.CompareTo(key) > 0)
			{
				this.AddRowType(key, row, min, num);
				return;
			}
			if (rowData3.Type.CompareTo(key) < 0)
			{
				this.AddRowType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SystemRewardTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"Name",
				"SubType",
				"Sort",
				"Remark",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SystemRewardTable.RowData rowData = new SystemRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SubType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Sort))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Remark))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.Reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowType(rowData.Type, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SystemRewardTable.RowData rowData = new SystemRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SubType, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Sort, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Remark, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 5;
			this.AddRowType(rowData.Type, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
