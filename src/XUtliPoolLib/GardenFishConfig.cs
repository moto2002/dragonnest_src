using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GardenFishConfig : CVSReader
	{
		public class RowData
		{
			public uint FishLeve;

			public uint Experience;

			public Seq2ListRef<int> FishWeight;

			public uint SuccessRate;
		}

		public List<GardenFishConfig.RowData> Table = new List<GardenFishConfig.RowData>();

		public GardenFishConfig.RowData GetByFishLeve(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchFishLeve(key, 0, this.Table.Count - 1);
		}

		private GardenFishConfig.RowData BinarySearchFishLeve(uint key, int min, int max)
		{
			GardenFishConfig.RowData rowData = this.Table[min];
			if (rowData.FishLeve == key)
			{
				return rowData;
			}
			GardenFishConfig.RowData rowData2 = this.Table[max];
			if (rowData2.FishLeve == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GardenFishConfig.RowData rowData3 = this.Table[num];
			if (rowData3.FishLeve.CompareTo(key) > 0)
			{
				return this.BinarySearchFishLeve(key, min, num);
			}
			if (rowData3.FishLeve.CompareTo(key) < 0)
			{
				return this.BinarySearchFishLeve(key, num, max);
			}
			return rowData3;
		}

		private void AddRowFishLeve(uint key, GardenFishConfig.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GardenFishConfig.RowData rowData = this.Table[min];
			if (rowData.FishLeve.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.FishLeve == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GardenFishConfig duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GardenFishConfig.RowData rowData2 = this.Table[max];
			if (rowData2.FishLeve.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.FishLeve == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GardenFishConfig duplicate id:{0}  lineno: {1}", new object[]
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
			GardenFishConfig.RowData rowData3 = this.Table[num];
			if (rowData3.FishLeve.CompareTo(key) > 0)
			{
				this.AddRowFishLeve(key, row, min, num);
				return;
			}
			if (rowData3.FishLeve.CompareTo(key) < 0)
			{
				this.AddRowFishLeve(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GardenFishConfig duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FishLeve",
				"Experience",
				"FishWeight",
				"SuccessRate"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GardenFishConfig.RowData rowData = new GardenFishConfig.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.FishLeve))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Experience))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.FishWeight, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.SuccessRate))
			{
				return false;
			}
			this.AddRowFishLeve(rowData.FishLeve, rowData, 0, this.Table.Count - 1);
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
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GardenFishConfig.RowData rowData = new GardenFishConfig.RowData();
			base.Read<uint>(reader, ref rowData.FishLeve, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experience, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadSeqList<int>(reader, ref rowData.FishWeight, CVSReader.intParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 3;
			this.AddRowFishLeve(rowData.FishLeve, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
