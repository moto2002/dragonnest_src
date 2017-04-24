using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class OperatingActivity : CVSReader
	{
		public class RowData
		{
			public uint OrderId;

			public string SysEnum;

			public uint SysID;

			public string TabName;

			public string TabIcon;
		}

		public List<OperatingActivity.RowData> Table = new List<OperatingActivity.RowData>();

		public OperatingActivity.RowData GetByOrderId(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchOrderId(key, 0, this.Table.Count - 1);
		}

		private OperatingActivity.RowData BinarySearchOrderId(uint key, int min, int max)
		{
			OperatingActivity.RowData rowData = this.Table[min];
			if (rowData.OrderId == key)
			{
				return rowData;
			}
			OperatingActivity.RowData rowData2 = this.Table[max];
			if (rowData2.OrderId == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			OperatingActivity.RowData rowData3 = this.Table[num];
			if (rowData3.OrderId.CompareTo(key) > 0)
			{
				return this.BinarySearchOrderId(key, min, num);
			}
			if (rowData3.OrderId.CompareTo(key) < 0)
			{
				return this.BinarySearchOrderId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowOrderId(uint key, OperatingActivity.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			OperatingActivity.RowData rowData = this.Table[min];
			if (rowData.OrderId.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.OrderId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OperatingActivity duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			OperatingActivity.RowData rowData2 = this.Table[max];
			if (rowData2.OrderId.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.OrderId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: OperatingActivity duplicate id:{0}  lineno: {1}", new object[]
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
			OperatingActivity.RowData rowData3 = this.Table[num];
			if (rowData3.OrderId.CompareTo(key) > 0)
			{
				this.AddRowOrderId(key, row, min, num);
				return;
			}
			if (rowData3.OrderId.CompareTo(key) < 0)
			{
				this.AddRowOrderId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: OperatingActivity duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"OrderId",
				"SysEnum",
				"SysID",
				"TabName",
				"TabIcon"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			OperatingActivity.RowData rowData = new OperatingActivity.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.OrderId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SysEnum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.SysID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TabName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.TabIcon))
			{
				return false;
			}
			this.AddRowOrderId(rowData.OrderId, rowData, 0, this.Table.Count - 1);
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			OperatingActivity.RowData rowData = new OperatingActivity.RowData();
			base.Read<uint>(reader, ref rowData.OrderId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SysEnum, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 4;
			this.AddRowOrderId(rowData.OrderId, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
