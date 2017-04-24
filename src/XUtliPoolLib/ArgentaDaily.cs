using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ArgentaDaily : CVSReader
	{
		public class RowData
		{
			public uint ID;

			public Seq2ListRef<uint> Reward;

			public string Description;

			public string Title;
		}

		public List<ArgentaDaily.RowData> Table = new List<ArgentaDaily.RowData>();

		public ArgentaDaily.RowData GetByID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private ArgentaDaily.RowData BinarySearchID(uint key, int min, int max)
		{
			ArgentaDaily.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			ArgentaDaily.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ArgentaDaily.RowData rowData3 = this.Table[num];
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

		private void AddRowID(uint key, ArgentaDaily.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ArgentaDaily.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ArgentaDaily duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ArgentaDaily.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ArgentaDaily duplicate id:{0}  lineno: {1}", new object[]
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
			ArgentaDaily.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ArgentaDaily duplicate id:{0}  lineno: {1}", new object[]
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
				"Reward",
				"Description",
				"Title"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ArgentaDaily.RowData rowData = new ArgentaDaily.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.Reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Title))
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
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ArgentaDaily.RowData rowData = new ArgentaDaily.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
