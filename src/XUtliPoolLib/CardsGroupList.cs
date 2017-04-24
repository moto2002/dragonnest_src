using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CardsGroupList : CVSReader
	{
		public class RowData
		{
			public uint GroupId;

			public uint ShowLevel;

			public uint OpenLevel;

			public string ShowUp;

			public string Detail;

			public string GroupName;

			public uint MapID;

			public uint[] BreakLevel;
		}

		public List<CardsGroupList.RowData> Table = new List<CardsGroupList.RowData>();

		public CardsGroupList.RowData GetByGroupId(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchGroupId(key, 0, this.Table.Count - 1);
		}

		private CardsGroupList.RowData BinarySearchGroupId(uint key, int min, int max)
		{
			CardsGroupList.RowData rowData = this.Table[min];
			if (rowData.GroupId == key)
			{
				return rowData;
			}
			CardsGroupList.RowData rowData2 = this.Table[max];
			if (rowData2.GroupId == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			CardsGroupList.RowData rowData3 = this.Table[num];
			if (rowData3.GroupId.CompareTo(key) > 0)
			{
				return this.BinarySearchGroupId(key, min, num);
			}
			if (rowData3.GroupId.CompareTo(key) < 0)
			{
				return this.BinarySearchGroupId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowGroupId(uint key, CardsGroupList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			CardsGroupList.RowData rowData = this.Table[min];
			if (rowData.GroupId.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.GroupId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsGroupList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			CardsGroupList.RowData rowData2 = this.Table[max];
			if (rowData2.GroupId.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.GroupId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsGroupList duplicate id:{0}  lineno: {1}", new object[]
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
			CardsGroupList.RowData rowData3 = this.Table[num];
			if (rowData3.GroupId.CompareTo(key) > 0)
			{
				this.AddRowGroupId(key, row, min, num);
				return;
			}
			if (rowData3.GroupId.CompareTo(key) < 0)
			{
				this.AddRowGroupId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsGroupList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GroupId",
				"ShowLevel",
				"OpenLevel",
				"ShowUp",
				"Detail",
				"GroupName",
				"MapID",
				"BreakLevel"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CardsGroupList.RowData rowData = new CardsGroupList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GroupId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ShowLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.OpenLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.ShowUp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Detail))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.GroupName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MapID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.BreakLevel))
			{
				return false;
			}
			this.AddRowGroupId(rowData.GroupId, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CardsGroupList.RowData rowData = new CardsGroupList.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ShowLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.OpenLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowUp, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.GroupName, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.MapID, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.BreakLevel, CVSReader.uintParse);
			this.columnno = 7;
			this.AddRowGroupId(rowData.GroupId, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
