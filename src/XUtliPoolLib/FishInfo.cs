using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FishInfo : CVSReader
	{
		public class RowData
		{
			public uint FishID;

			public uint Experience;

			public int quality;

			public bool isbind;
		}

		public List<FishInfo.RowData> Table = new List<FishInfo.RowData>();

		public FishInfo.RowData GetByFishID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchFishID(key, 0, this.Table.Count - 1);
		}

		private FishInfo.RowData BinarySearchFishID(uint key, int min, int max)
		{
			FishInfo.RowData rowData = this.Table[min];
			if (rowData.FishID == key)
			{
				return rowData;
			}
			FishInfo.RowData rowData2 = this.Table[max];
			if (rowData2.FishID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FishInfo.RowData rowData3 = this.Table[num];
			if (rowData3.FishID.CompareTo(key) > 0)
			{
				return this.BinarySearchFishID(key, min, num);
			}
			if (rowData3.FishID.CompareTo(key) < 0)
			{
				return this.BinarySearchFishID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowFishID(uint key, FishInfo.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FishInfo.RowData rowData = this.Table[min];
			if (rowData.FishID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.FishID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FishInfo duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FishInfo.RowData rowData2 = this.Table[max];
			if (rowData2.FishID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.FishID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FishInfo duplicate id:{0}  lineno: {1}", new object[]
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
			FishInfo.RowData rowData3 = this.Table[num];
			if (rowData3.FishID.CompareTo(key) > 0)
			{
				this.AddRowFishID(key, row, min, num);
				return;
			}
			if (rowData3.FishID.CompareTo(key) < 0)
			{
				this.AddRowFishID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FishInfo duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FishID",
				"Experience",
				"quality",
				"isbind"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FishInfo.RowData rowData = new FishInfo.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.FishID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Experience))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.quality))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.isbind))
			{
				return false;
			}
			this.AddRowFishID(rowData.FishID, rowData, 0, this.Table.Count - 1);
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[3]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FishInfo.RowData rowData = new FishInfo.RowData();
			base.Read<uint>(reader, ref rowData.FishID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experience, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.quality, CVSReader.intParse);
			this.columnno = 2;
			base.Read(reader, ref rowData.isbind);
			this.columnno = 3;
			this.AddRowFishID(rowData.FishID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
