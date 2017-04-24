using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class EmblemBasic : CVSReader
	{
		public class RowData
		{
			public uint EmblemID;

			public uint Level;

			public uint ProfID;

			public uint EmblemType;

			public uint DragonCoinCost;

			public uint ThirdProb;

			public Seq2ListRef<uint> SmeltNeedItem;

			public uint SmeltNeedMoney;
		}

		public List<EmblemBasic.RowData> Table = new List<EmblemBasic.RowData>();

		public EmblemBasic.RowData GetByEmblemID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchEmblemID(key, 0, this.Table.Count - 1);
		}

		private EmblemBasic.RowData BinarySearchEmblemID(uint key, int min, int max)
		{
			EmblemBasic.RowData rowData = this.Table[min];
			if (rowData.EmblemID == key)
			{
				return rowData;
			}
			EmblemBasic.RowData rowData2 = this.Table[max];
			if (rowData2.EmblemID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			EmblemBasic.RowData rowData3 = this.Table[num];
			if (rowData3.EmblemID.CompareTo(key) > 0)
			{
				return this.BinarySearchEmblemID(key, min, num);
			}
			if (rowData3.EmblemID.CompareTo(key) < 0)
			{
				return this.BinarySearchEmblemID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowEmblemID(uint key, EmblemBasic.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			EmblemBasic.RowData rowData = this.Table[min];
			if (rowData.EmblemID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.EmblemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EmblemBasic duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			EmblemBasic.RowData rowData2 = this.Table[max];
			if (rowData2.EmblemID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.EmblemID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: EmblemBasic duplicate id:{0}  lineno: {1}", new object[]
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
			EmblemBasic.RowData rowData3 = this.Table[num];
			if (rowData3.EmblemID.CompareTo(key) > 0)
			{
				this.AddRowEmblemID(key, row, min, num);
				return;
			}
			if (rowData3.EmblemID.CompareTo(key) < 0)
			{
				this.AddRowEmblemID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: EmblemBasic duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"EmblemID",
				"Level",
				"ProfID",
				"EmblemType",
				"DragonCoinCost",
				"ThirdProb",
				"SmeltNeedItem",
				"SmeltNeedMoney"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			EmblemBasic.RowData rowData = new EmblemBasic.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.EmblemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Level))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ProfID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.EmblemType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.DragonCoinCost))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.ThirdProb))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[6]], ref rowData.SmeltNeedItem, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SmeltNeedMoney))
			{
				return false;
			}
			this.AddRowEmblemID(rowData.EmblemID, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			EmblemBasic.RowData rowData = new EmblemBasic.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.EmblemType, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.DragonCoinCost, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.ThirdProb, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeqList<uint>(reader, ref rowData.SmeltNeedItem, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SmeltNeedMoney, CVSReader.uintParse);
			this.columnno = 7;
			this.AddRowEmblemID(rowData.EmblemID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
