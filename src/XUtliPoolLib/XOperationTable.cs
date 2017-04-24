using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XOperationTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public float Angle;

			public float Distance;

			public bool Vertical;

			public bool Horizontal;

			public float MaxV;

			public float MinV;

			public bool OffSolo;
		}

		public List<XOperationTable.RowData> Table = new List<XOperationTable.RowData>();

		public XOperationTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private XOperationTable.RowData BinarySearchID(int key, int min, int max)
		{
			XOperationTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			XOperationTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XOperationTable.RowData rowData3 = this.Table[num];
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

		private void AddRowID(int key, XOperationTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XOperationTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XOperationTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XOperationTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XOperationTable duplicate id:{0}  lineno: {1}", new object[]
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
			XOperationTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XOperationTable duplicate id:{0}  lineno: {1}", new object[]
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
				"Angle",
				"Distance",
				"Vertical",
				"Horizontal",
				"MaxV",
				"MinV",
				"OffSolo"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XOperationTable.RowData rowData = new XOperationTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Angle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Distance))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Vertical))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Horizontal))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MaxV))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MinV))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.OffSolo))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[1]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
			base.Write(writer, false, Fields[this.ColMap[3]]);
			base.Write(writer, false, Fields[this.ColMap[4]]);
			base.Write<float>(writer, Fields[this.ColMap[5]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse);
			base.Write(writer, false, Fields[this.ColMap[7]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XOperationTable.RowData rowData = new XOperationTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<float>(reader, ref rowData.Angle, CVSReader.floatParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.Distance, CVSReader.floatParse);
			this.columnno = 2;
			base.Read(reader, ref rowData.Vertical);
			this.columnno = 3;
			base.Read(reader, ref rowData.Horizontal);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.MaxV, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.MinV, CVSReader.floatParse);
			this.columnno = 6;
			base.Read(reader, ref rowData.OffSolo);
			this.columnno = 7;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
