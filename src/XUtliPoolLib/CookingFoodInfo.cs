using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CookingFoodInfo : CVSReader
	{
		public class RowData
		{
			public uint FoodID;

			public string FoodName;

			public string Desc;

			public uint AddExp;

			public Seq2ListRef<uint> Ingredients;

			public uint BuffID;

			public uint Duration;

			public uint Frequency;

			public uint Level;

			public uint CookBookID;

			public uint NeededExp;

			public uint[] Profession;
		}

		public List<CookingFoodInfo.RowData> Table = new List<CookingFoodInfo.RowData>();

		public CookingFoodInfo.RowData GetByFoodID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchFoodID(key, 0, this.Table.Count - 1);
		}

		private CookingFoodInfo.RowData BinarySearchFoodID(uint key, int min, int max)
		{
			CookingFoodInfo.RowData rowData = this.Table[min];
			if (rowData.FoodID == key)
			{
				return rowData;
			}
			CookingFoodInfo.RowData rowData2 = this.Table[max];
			if (rowData2.FoodID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			CookingFoodInfo.RowData rowData3 = this.Table[num];
			if (rowData3.FoodID.CompareTo(key) > 0)
			{
				return this.BinarySearchFoodID(key, min, num);
			}
			if (rowData3.FoodID.CompareTo(key) < 0)
			{
				return this.BinarySearchFoodID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowFoodID(uint key, CookingFoodInfo.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			CookingFoodInfo.RowData rowData = this.Table[min];
			if (rowData.FoodID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.FoodID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CookingFoodInfo duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			CookingFoodInfo.RowData rowData2 = this.Table[max];
			if (rowData2.FoodID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.FoodID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CookingFoodInfo duplicate id:{0}  lineno: {1}", new object[]
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
			CookingFoodInfo.RowData rowData3 = this.Table[num];
			if (rowData3.FoodID.CompareTo(key) > 0)
			{
				this.AddRowFoodID(key, row, min, num);
				return;
			}
			if (rowData3.FoodID.CompareTo(key) < 0)
			{
				this.AddRowFoodID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: CookingFoodInfo duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"FoodID",
				"FoodName",
				"Desc",
				"AddExp",
				"Ingredients",
				"BuffID",
				"Duration",
				"Frequency",
				"Level",
				"CookBookID",
				"NeededExp",
				"Profession"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CookingFoodInfo.RowData rowData = new CookingFoodInfo.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.FoodID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.FoodName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.AddExp))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.Ingredients, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BuffID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Frequency))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.CookBookID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.NeededExp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.Profession))
			{
				return false;
			}
			this.AddRowFoodID(rowData.FoodID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CookingFoodInfo.RowData rowData = new CookingFoodInfo.RowData();
			base.Read<uint>(reader, ref rowData.FoodID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.FoodName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.AddExp, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.Ingredients, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.BuffID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Duration, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.Frequency, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.CookBookID, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.NeededExp, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadArray<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 11;
			this.AddRowFoodID(rowData.FoodID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
